using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_ESA_4
{
    public class PointExtended
    {
        public PointExtended(Point point)
        {
            Origin = point;
        }

        public int X
        { get { return Origin.X; }  }
        public int Y
        { get { return Origin.Y; } }
        public Point Left
        {
            get
            { return new Point(Origin.X - 1, Origin.Y); }
        }
        public Point Right
        {
            get { return new Point(Origin.X + 1, Origin.Y); }
        }
        public Point Up
        {
            get { return new Point(Origin.X, Origin.Y - 1); }
        }
        public Point Down
        {
            get { return new Point(Origin.X, Origin.Y + 1); }
        }
        public Point Origin { get; set; }
    }
}
