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
                Point p = pointsToSearch.Dequeue();
                addedPoint = p;

                if (!IsItem(p.X, p.Y))
                {
                    // oben
                    if (CanMove(p.X - 1, p.Y))
                    {
                        if (!itemPositions.ContainsKey(new Point(p.X - 1, p.Y)))
                        {
                            addedPoint = new Point(p.X - 1, p.Y);
                            itemPositions.Add(addedPoint, new Point(p.X, p.Y));
                            pointsToSearch.Enqueue(new Point(p.X - 1, p.Y));
                        }
                    }
                    // unten
                    if (CanMove(p.X + 1, p.Y))
                    {
                        if (!itemPositions.ContainsKey(new Point(p.X + 1, p.Y)))
                        {
                            addedPoint = new Point(p.X + 1, p.Y);
                            itemPositions.Add(addedPoint, new Point(p.X, p.Y));
                            pointsToSearch.Enqueue(new Point(p.X + 1, p.Y));
                        }
                    }
                    // links
                    if (CanMove(p.X, p.Y - 1))
                    {
                        if (!itemPositions.ContainsKey(new Point(p.X, p.Y - 1)))
                        {
                            addedPoint = new Point(p.X, p.Y - 1);
                            itemPositions.Add(addedPoint, new Point(p.X, p.Y));
                            pointsToSearch.Enqueue(new Point(p.X, p.Y - 1));
                        }
                    }
                    // rechts
                    if (CanMove(p.X, p.Y + 1))
                    {
                        if (!itemPositions.ContainsKey(new Point(p.X, p.Y + 1)))
                        {
                            addedPoint = new Point(p.X, p.Y + 1);
                            itemPositions.Add(addedPoint, new Point(p.X, p.Y));
                            pointsToSearch.Enqueue(new Point(p.X, p.Y + 1));
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
