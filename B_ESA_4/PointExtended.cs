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
        public Point Left { get; set; }
        public Point Right { get; set; }
        public Point Up { get; set; }
        public Point Down { get; set; }
        public Point Origin { get; set; }
    }
}
