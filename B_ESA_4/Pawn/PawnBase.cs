using B_ESA_4.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B_ESA_4.Playground;

namespace B_ESA_4.Pawn
{
    public abstract class PawnBase
    {
        protected PlayGround internalPlayground;

        public PawnBase(PlayGround playground)
        {
            InitPawn(playground);
        }

        private void InitPawn(PlayGround playground)
        {
            internalPlayground = playground;
        }

        public PawnBase(PlayGround playground, int x, int y)
        {
            InitPawn(playground);
            Location = new Point(x, y);
        }
        public int PawnX { get; set; }
        public int PawnY { get; set; }
        protected const string Sign = "@";
        protected const string ItemSign = "o";
        protected const string Wall = "#";

        public Point Location { get; set; }

        protected bool CanMove(int newX, int newY)
        {
            return !(internalPlayground[newX, newY] is WallField);
        }

        protected bool CanMove(Point p)
        {
            return CanMove(p.X, p.Y);
        }
        protected Point MovePawnAndSetUpPlayground(Point last, Point next)
        {
            if (!CanMove(next))
                return last;

            internalPlayground[last] = new EmptyField() {Location = last};
            internalPlayground[next] = new PlayerField() {Location = next};
            return next;
        }
    }
}
