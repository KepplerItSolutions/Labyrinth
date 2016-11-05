using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_ESA_3
{
    public class Point
    {
        public float xValue;
        public float yValue;

        public Point(float x, float y)
        {
            xValue = x;
            yValue = y;
        }

        public static Point operator +(Point a, Point b)
        {
            Point result = new Point(a.xValue + b.xValue, a.yValue + b.yValue);
            return result;
        }

        public static bool TryParse(string x, string y, out Point p)
        {
            float xVal = 0;
            float yVal = 0;
            
            if (float.TryParse(x, out xVal) && float.TryParse(y, out yVal))
            {
                p = new Point(xVal, yVal);
                return true;
            }
            else
            {
                p = null;
                return false;
            }
        }

        public static bool TryParse(string input, out Point p)
        {
            string[] xy = input.Split(',');
            if (xy.Length == 2)
            {
                TryParse(xy[0], xy[1], out p);
                return true;
            }
            else
            {
                p = null;
                return false;
            }
        }
    }
}
