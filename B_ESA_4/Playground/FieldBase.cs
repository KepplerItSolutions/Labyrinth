using System.Drawing;

namespace B_ESA_4.Playground
{
    public abstract class Field
    {
        public abstract char Symbol { get; }
        public Point Location { get; set; }
    }

    public class WallField : Field
    {
        public override char Symbol { get; } = '#';
    }

    public class PlayerField : Field
    {
        public override char Symbol { get; } = '@';
    }

    public class ItemField : Field
    {
        public override char Symbol { get; } = 'o';
    }

    public class EmptyField : Field
    {
        public override char Symbol { get; } = ' ';
    }
}