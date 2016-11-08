using System.Drawing;

namespace B_ESA_4
{
    public static class PointExtensions
    {
        public static Point LeftNeighbour(this Point p)
        {
            return new Point(p.X - 1, p.Y);
        }

        public static Point RightNeighbour(this Point p)
        {
            return new Point(p.X + 1, p.Y);
        }

        public static Point UpperNeighbour(this Point p)
        {
            return new Point(p.X, p.Y - 1);
        }

        public static Point LowerNeighbour(this Point p)
        {
            return new Point(p.X, p.Y + 1);
        }

        public static int SquareDistance(this Point p1, Point p2)
        {
            var distX = (p2.X - p1.X);
            var distY = (p2.Y - p2.Y);
            return distX*distX + distY*distY;
        }
    }
}
