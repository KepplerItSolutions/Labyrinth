using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_ESA_4.Pawn
{
    public abstract class PawnBase
    {
        protected PlayGround internalPlayground;

        public PawnBase(PlayGround playground)
        {
            InitPawn(playground);
            SetPawnToCenter();
        }

        private void InitPawn(PlayGround playground)
        {
            internalPlayground = playground;
        }

        public PawnBase(PlayGround playground, int x, int y)
        {
            InitPawn(playground);
            PawnX = x;
            PawnY = y;
        }
        public int PawnX { get; set; }
        public int PawnY { get; set; }
        protected const string Sign = "@";
        protected const string ItemSign = "o";
        protected const string Wall = "#";

        protected bool CanMove(int newX, int newY)
        {
            return internalPlayground.PlaygroundData[newX, newY] != Wall;
        }

        protected bool CanMove(Point p)
        {
            return CanMove(p.X, p.Y);
        }
        protected void MovePawnAndSetUpPlayground(int lastX, int lastY, int nextX, int nextY)
        {
            internalPlayground.PlaygroundData[lastX, lastY] = string.Empty;
            internalPlayground.PlaygroundData[nextX, nextY] = Sign;          
        }

        protected void SetPawnToCenter()
        {
            int x = 0;
            int y = 0;
            GetCenterPosition(out x, out y);
            this.PawnX = x;
            this.PawnY = y;
            internalPlayground.PlaygroundData[this.PawnX, this.PawnY] = Sign;
        }

        private void GetCenterPosition(out int column, out int row)
        {
            column = internalPlayground.PlaygroundData.GetLength(0) / 2;
            row = internalPlayground.PlaygroundData.GetLength(1) / 2;
        }
    }
}
