using B_ESA_4.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Timers;
using B_ESA_4.Playground;
using System.Diagnostics;
using B_ESA_4.Playground.Fields;

namespace B_ESA_4.Pawn
{
    public class ComputerPlayer : PawnBase, IPawn, IDisposable
    {
        Hashtable _itemPositions;
        Queue<Point> _pointsToSearch;
        System.Timers.Timer _searchTick;
        bool _searching;

        public ComputerPlayer(PlayGround playground)
            : base(playground)
        {
            InitComputerPlayer();
        }

        private void InitComputerPlayer()
        {
            _itemPositions = new Hashtable();
            _pointsToSearch = new Queue<Point>();
            _searchTick = new System.Timers.Timer(10);
            _searchTick.Elapsed += SearchTick_Elapsed;
            _searchTick.Start();
        }

        public ComputerPlayer(PlayGround playground, int x, int y)
            : base(playground, x, y)
        {
            InitComputerPlayer();
        }

        private void SearchTick_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!_searching)
            {
                _searching = true;
                if (!InternalPlayground.StillContainsItem())
                {
                    _searchTick.Stop();
                }
                SearchItems();
                _searching = false;
            }
        }

        private void SearchItems()
        {
            _itemPositions.Clear();
            _pointsToSearch.Clear();
            _pointsToSearch.Enqueue(InternalPlayground.Pawn.Location);


            while (_pointsToSearch.Any())
            {
                Point p = _pointsToSearch.Dequeue();

                if (!IsItem(p))
                {
                    var upperNeighbour = p.UpperNeighbour();
                    var lowerNeighbour = p.LowerNeighbour();
                    var leftNeighbour = p.LeftNeighbour();
                    var rightNeighbour = p.RightNeighbour();

                    if (InternalPlayground.CanMove(upperNeighbour))
                    {
                        AddPointIfNotExistent(upperNeighbour, p);
                    }

                    if (InternalPlayground.CanMove(lowerNeighbour))
                    {
                        AddPointIfNotExistent(lowerNeighbour, p);
                    }

                    if (InternalPlayground.CanMove(leftNeighbour))
                    {
                        AddPointIfNotExistent(leftNeighbour, p);
                    }

                    if (InternalPlayground.CanMove(rightNeighbour))
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
            if(itemPositions.ContainsKey(neighborPoint))
                return;
            itemPositions.Add(neighborPoint, origin);
            pointsToSearch.Enqueue(neighborPoint);
        }

        private void CreatePath(Point itemPosition)
        {
            Stack<Point> wayFromOrigin = new Stack<Point>();

            wayFromOrigin.Push(itemPosition);
            Point fromPoint = itemPosition;

            while (_itemPositions.ContainsKey(fromPoint))
            {
                fromPoint = (Point)_itemPositions[fromPoint];
                if(fromPoint != InternalPlayground.Pawn.Location)
                    wayFromOrigin.Push(fromPoint);
            }

            while (wayFromOrigin.Any())
            {
                Point moveToPoint = wayFromOrigin.Pop();
                InternalPlayground.MovePawn(moveToPoint);
                Thread.Sleep(1000);
            }
        }
        
        private bool IsItem(Point p)
        {
            return InternalPlayground[p] is ItemField;
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
            _searchTick.Elapsed -= SearchTick_Elapsed;
            _searchTick.Stop();
            _searchTick = null;
        }
    }

}