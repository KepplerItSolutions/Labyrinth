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
            searchTick = new System.Timers.Timer(1000);
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
                    if (CanMove(p.UpperNeighbor()))
                    {
                        if (!itemPositions.ContainsKey(p.UpperNeighbor()))
                        {
                            addedPoint = AddPoint(p.UpperNeighbor(), p);
                        }
                    }
                    // unten
                    if (CanMove(p.LowerNeighbor()))
                    {
                        if (!itemPositions.ContainsKey(p.LowerNeighbor()))
                        {
                            addedPoint = AddPoint(p.LowerNeighbor(), p);
                        }
                    }
                    // links
                    if (CanMove(p.LeftNeighbor()))
                    {
                        if (!itemPositions.ContainsKey(p.LeftNeighbor()))
                        {
                            addedPoint = AddPoint(p.LeftNeighbor(), p);
                        }
                    }
                    // rechts
                    if (CanMove(p.RightNeighbor()))
                    {
                        if (!itemPositions.ContainsKey(p.RightNeighbor()))
                        {
                            addedPoint = AddPoint(p.RightNeighbor(), p);
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            CreatePath(new Point(PawnX, PawnY), addedPoint);
        }

        private Point AddPoint(Point neighborPoint, Point origin)
        {
            Point addedPoint = neighborPoint;
            itemPositions.Add(addedPoint, origin);
            pointsToSearch.Enqueue(addedPoint);
            return addedPoint;
        }

        private void CreatePath(Point originPoint, Point lastPoint)
        {
            Stack<Point> wayFromOrigin = new Stack<Point>();

            wayFromOrigin.Push(lastPoint);
            Point fromPoint = (Point)itemPositions[lastPoint];

            while (fromPoint != originPoint)
            {
                wayFromOrigin.Push(fromPoint);                
                fromPoint = (Point)itemPositions[fromPoint];                             
            }

            while (wayFromOrigin.Count > 0)
            {
                Point moveToPoint = wayFromOrigin.Pop();
                MovePawnAndSetUpPlayground(PawnX, PawnY, moveToPoint.X, moveToPoint.Y);
                Thread.Sleep(350);
                PawnX = moveToPoint.X;
                PawnY = moveToPoint.Y;                
            }
        }

        private bool IsItem(int x, int y)
        {
            return internalPlayground.PlaygroundData[x, y] == ItemSign;
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
