using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_ESA_2
{
    public class PointComparer : IComparer
    {
        public int Compare(object pointOne, object pointTwo)
        {
            Point one = pointOne as Point;
            Point two = pointTwo as Point;
            int result = CompareInt(one.y, two.y);
            if (result == 0)
            {
                result = CompareInt(one.x, two.x);
            }
            return result;
        }

        private int CompareInt(int one, int two)
        {
            if (one < two)
            {
                return -1;
            }
            else if (one > two)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return x + "," + y;
        }
    }

    public class ArrayListTest
    {
        public static void Main(string[] args)
        {
            ArrayList AL = new ArrayList();
            Random R = new Random();
            for (int i = 0; i < 10; i++)
            {
                Point p = new Point(R.Next(50), R.Next(50));
                AL.Add(p);
            }

            Console.WriteLine("Zufällig erzeugte Punkte in der ursrpünglichen Reihenfolge.\n(x, y)");
            PrintValues(AL);
            AL.Sort(new PointComparer());
            Console.WriteLine("Sortiere Punkte.\n(x, y)");
            PrintValues(AL);
            Console.WriteLine("Sortierrichtlinie: P1 < P2 wenn P1.y < P2.y\nWenn P1.y == P2.y gilt:\nP1 < P2 wenn P1.x < P2.x");         
        }

        private static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.WriteLine("{0}", obj);
            Console.WriteLine();
        }
    }
}
