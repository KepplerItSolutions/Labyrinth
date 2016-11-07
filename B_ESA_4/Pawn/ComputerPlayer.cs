using B_ESA_4.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Timers;
using B_ESA_4.Playground;

namespace B_ESA_4.Pawn
{
    public class ComputerPlayer : PawnBase, IPawn, IDisposable
    {
        Hashtable itemPositions;
        Queue<Point> pointsToSearch;
        System.Timers.Timer searchTick;
        bool searching;

        public ComputerPlayer(PlayGround playground)
            : base(playground)
        {
            InitComputerPlayer();
        }

        private void InitComputerPlayer()
        {
            itemPositions = new Hashtable();
            pointsToSearch = new Queue<Point>();
            searchTick = new System.Timers.Timer(10);
            searchTick.Elapsed += SearchTick_Elapsed;
            searchTick.Start();
        }

        public ComputerPlayer(PlayGround playground, int x, int y)
            : base(playground, x, y)
        {
            InitComputerPlayer();
        }

        private void SearchTick_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!searching)
            {
                searching = true;
                if (!internalPlayground.StillContainsItem())
                {
                    searchTick.Stop();
                }
                SearchItems();
                searching = false;
            }
        }

        private void SearchItems()
        {
            itemPositions.Clear();
            pointsToSearch.Clear();
            pointsToSearch.Enqueue(Location);

            while (pointsToSearch.Any())
            {
                Point p = pointsToSearch.Dequeue();

                if (!IsItem(p))
                {
                    var upperNeighbour = p.UpperNeighbour();
                    var lowerNeighbour = p.LowerNeighbour();
                    var leftNeighbour = p.LeftNeighbour();
                    var rightNeighbour = p.RightNeighbour();

                    if (CanMove(upperNeighbour))
                    {
                        AddPointIfNotExistent(upperNeighbour, p);
                    }

                    if (CanMove(lowerNeighbour))
                    {
                        AddPointIfNotExistent(lowerNeighbour, p);
                    }

                    if (CanMove(leftNeighbour))
                    {
                        AddPointIfNotExistent(leftNeighbour, p);
                    }

                    if (CanMove(rightNeighbour))
                    {
                        AddPointIfNotExistent(rightNeighbour, p);
                    }
                }
                else
                {
                    CreatePath(p);
                    break;
                }
            }
        }

        private void AddPointIfNotExistent(Point neighborPoint, Point origin)
        {
            if (itemPositions.ContainsKey(neighborPoint))
                return;
            AddPoint(neighborPoint, origin);
        }

        private void AddPoint(Point neighborPoint, Point origin)
        {
            itemPositions.Add(neighborPoint, origin);
            pointsToSearch.Enqueue(neighborPoint);
        }

        private void CreatePath(Point itemPosition)
        {
            Stack<Point> wayFromOrigin = new Stack<Point>();

            wayFromOrigin.Push(itemPosition);
            Point fromPoint = (Point)itemPositions[itemPosition];

            while (itemPositions.ContainsKey(fromPoint))
            {
                fromPoint = (Point)itemPositions[fromPoint];
                wayFromOrigin.Push(fromPoint);
            }

            while (wayFromOrigin.Any())
            {
                Point moveToPoint = wayFromOrigin.Pop();

                MovePawnAndSetUpPlayground(Location, moveToPoint);
                Thread.Sleep(1000);
                PawnX = moveToPoint.X;
                PawnY = moveToPoint.Y;
            }
        }

        private bool IsItem(Point p)
        {
            return internalPlayground[p] is ItemField;
        }

        public void MoveUp()
        {
        }

        public void MoveDown()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void Dispose()
        {
            searchTick.Elapsed -= SearchTick_Elapsed;
            searchTick.Stop();
            searchTick = null;
        }
    }

}