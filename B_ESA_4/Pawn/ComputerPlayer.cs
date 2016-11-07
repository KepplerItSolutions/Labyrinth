using B_ESA_4.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            Point addedPoint = new Point(0, 0);

            while (pointsToSearch.Any())
            {
                Point p = pointsToSearch.Dequeue();
                addedPoint = p;

                if (!IsItem(p.X, p.Y))
                {
                    // oben
                    if (CanMove(p.UpperNeighbor()) && !itemPositions.ContainsKey(p.UpperNeighbor()))
                    {
                        addedPoint = p.UpperNeighbor();
                        AddPoint(addedPoint, p);
                    }
                    // unten
                    if (CanMove(p.LowerNeighbor()) && !itemPositions.ContainsKey(p.LowerNeighbor()))
                    {
                        addedPoint = p.LowerNeighbor();
                        AddPoint(addedPoint, p);
                    }
                    // links
                    if (CanMove(p.LeftNeighbor()) && !itemPositions.ContainsKey(p.LeftNeighbor()))
                    {
                        addedPoint = p.LeftNeighbor();
                        AddPoint(addedPoint, p);
                    }
                    // rechts
                    if (CanMove(p.RightNeighbor()) && !itemPositions.ContainsKey(p.RightNeighbor()))
                    {
                        addedPoint = p.RightNeighbor();
                        AddPoint(addedPoint, p);
                    }
                }
                else
                {
                    CreatePath(new Point(PawnX, PawnY), addedPoint);
                    break;
                }
            }            
        }

        private void AddPoint(Point neighborPoint, Point origin)
        {            
            itemPositions.Add(neighborPoint, origin);
            pointsToSearch.Enqueue(neighborPoint);         
        }

        private void CreatePath(Point pawnPosition, Point itemPosition)
        {
            Stack<Point> wayFromOrigin = new Stack<Point>();

            wayFromOrigin.Push(itemPosition);
            Point fromPoint = (Point)itemPositions[itemPosition];

            while (fromPoint != pawnPosition)
            {
                wayFromOrigin.Push(fromPoint);                
                fromPoint = (Point)itemPositions[fromPoint];                             
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

        private bool IsItem(int x, int y)
        {
            return internalPlayground.PlaygroundData[x, y] == CommonConstants.ItemSign;
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
