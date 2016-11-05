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

            while (pointsToSearch.Count > 0)
            {
                PointExtended p = new PointExtended(pointsToSearch.Dequeue());
                addedPoint = p.Origin;

                if (!IsItem(p.X, p.Y))
                {
                    // oben
                    if (CanMove(p.Up))
                    {
                        if (!itemPositions.ContainsKey(p.Up))
                        {
                            addedPoint = p.Up;
                            itemPositions.Add(addedPoint, p.Origin);
                            pointsToSearch.Enqueue(addedPoint);
                        }
                    }
                    // unten
                    if (CanMove(p.Down))
                    {
                        if (!itemPositions.ContainsKey(p.Down))
                        {
                            addedPoint = p.Down;
                            itemPositions.Add(addedPoint, p.Origin);
                            pointsToSearch.Enqueue(p.Down);
                        }
                    }
                    // links
                    if (CanMove(p.Left))
                    {
                        if (!itemPositions.ContainsKey(p.Left))
                        {
                            addedPoint = p.Left;
                            itemPositions.Add(addedPoint, p.Origin);
                            pointsToSearch.Enqueue(p.Left);
                        }
                    }
                    // rechts
                    if (CanMove(p.Right))
                    {
                        if (!itemPositions.ContainsKey(p.Right))
                        {
                            addedPoint = p.Right;
                            itemPositions.Add(addedPoint, p.Origin);
                            pointsToSearch.Enqueue(p.Right);
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
