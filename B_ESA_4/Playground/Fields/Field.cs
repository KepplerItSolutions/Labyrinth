using System.Drawing;

namespace B_ESA_4.Playground.Fields
{
    public abstract class Field
    {
        public abstract char Symbol { get; }
        public Point Location { get; set; }
    }
}