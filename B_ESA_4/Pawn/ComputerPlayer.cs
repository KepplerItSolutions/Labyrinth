﻿using B_ESA_4.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Timers;

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
            pointsToSearch.Enqueue(new Point(PawnX, PawnY));

            while (pointsToSearch.Any())
            {
                Point p = pointsToSearch.Dequeue();

                if (!IsItem(p))
                {                                       
                    //var lowerNeighbour = p.LowerNeighbor();
                    var leftNeighbour = p.LeftNeighbor();
                    var rightNeighbour = p.RightNeighbor();
                    
                    if (CanMove(p.UpperNeighbor()))
                    {
                        AddPointIfNotExistent(p.UpperNeighbor(), p);
                    }
                    
                    if (CanMove(p.LowerNeighbor()))
                    {
                        AddPointIfNotExistent(p.LowerNeighbor(), p);
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
            if(itemPositions.ContainsKey(neighborPoint))
                return;
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

                MovePawnAndSetUpPlayground(PawnX, PawnY, moveToPoint.X, moveToPoint.Y);
                Thread.Sleep(1000);               
                PawnX = moveToPoint.X;
                PawnY = moveToPoint.Y;                
            }
        }

        private bool IsItem(Point p)
        {
            return internalPlayground.PlaygroundData[p.X, p.Y] == CommonConstants.ItemSign;
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
