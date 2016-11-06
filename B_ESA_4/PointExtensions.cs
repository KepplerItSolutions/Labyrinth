﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_ESA_4
{
    public static class PointExtensions
    {
        public static Point LeftNeighbor(this Point p)
        {
            return new Point(p.X - 1, p.Y);
        }

        public static Point RightNeighbor(this Point p)
        {
            return new Point(p.X + 1, p.Y);
        }

        public static Point UpperNeighbor(this Point p)
        {
            return new Point(p.X, p.Y - 1);
        }

        public static Point LowerNeighbor(this Point p)
        {
            return new Point(p.X, p.Y + 1);
        }
    }
}
