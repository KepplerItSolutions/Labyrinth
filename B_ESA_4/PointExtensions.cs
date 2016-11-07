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
    }
}
