using System.Drawing;
using B_ESA_4.Playground.Fields;

namespace B_ESA_4.Playground
{    
    public class PlayGround 
    {
        public Field Pawn { get; private set; }
        private Field[,] PlaygroundData { get; set; }

        public int Width { get; private set; }
        public int Height { get; private set; }
        

        public PlayGround(Field[,] playgroundData)
        {
            PlaygroundData = playgroundData;
            if (!FindPawn())
                throw new PawnMissingException();
            Width = PlaygroundData.GetLength(0);
            Height = PlaygroundData.GetLength(1);
        }
        private bool FindPawn()
        {
            for (int column = 0; column < PlaygroundData.GetLength(0); column++)
            {
                for (int row = 0; row < PlaygroundData.GetLength(1); row++)
                {
                    var pawn = PlaygroundData[column, row] as PlayerField;
                    if (pawn != null)
                    {
                        Pawn = pawn;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool StillContainsItem()
        {
            bool result = false;
            for (int column = 0; column < PlaygroundData.GetLength(0); column++)
            {
                for (int row = 0; row < PlaygroundData.GetLength(1); row++)
                {
                    if (PlaygroundData[column, row] is ItemField)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public Field this[Point location]
        {
            get { return this[location.X, location.Y]; }
            set { this[location.X, location.Y] = value; }
        }

        public Field this[int x, int y]
        {
            get { return PlaygroundData[x, y]; }
            set { PlaygroundData[x, y] = value; }
        }
        

        public bool CanMove(Point p)
        {
            return !(this[p.X, p.Y] is WallField)
                   && Pawn.Location.SquareDistance(p) >= 1
                   && p.Y >= 0 && p.Y < Height
                   && p.X >= 0 && p.X < Width;
        }

        public void MovePawnUp()
        {
            MovePawn(Pawn.Location.UpperNeighbour());
        }
        public void MovePawnDown()
        {
            MovePawn(Pawn.Location.LowerNeighbour());
        }

        public void MovePawnLeft()
        {
            MovePawn(Pawn.Location.LeftNeighbour());
        }

        public void MovePawnRight()
        {
            MovePawn(Pawn.Location.RightNeighbour());
        }


        public void MovePawn(Point next)
        {
            if (!CanMove(next))
                return;

            this[Pawn.Location] = new EmptyField() { Location = Pawn.Location };
            Pawn = new PlayerField() { Location = next };
            this[next] = Pawn;
        }
    }  
}
