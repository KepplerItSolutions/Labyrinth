using System.Drawing;

namespace B_ESA_4.Playground
{    
    public class PlayGround 
    {
        public Field Pawn { get; private set; }
        private Field[,] _playgroundData { get; set; }

        public int Width { get; private set; }
        public int Height { get; private set; }
        

        public PlayGround(Field[,] playgroundData)
        {
            _playgroundData = playgroundData;
            if (!FindPawn())
                throw new PawnMissingException();
            Width = _playgroundData.GetLength(0);
            Height = _playgroundData.GetLength(1);
        }
        private bool FindPawn()
        {
            for (int column = 0; column < _playgroundData.GetLength(0); column++)
            {
                for (int row = 0; row < _playgroundData.GetLength(1); row++)
                {
                    var pawn = _playgroundData[column, row] as PlayerField;
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
            for (int column = 0; column < _playgroundData.GetLength(0); column++)
            {
                for (int row = 0; row < _playgroundData.GetLength(1); row++)
                {
                    if (_playgroundData[column, row] is ItemField)
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
            get { return _playgroundData[x, y]; }
            set { _playgroundData[x, y] = value; }
        }

        public bool CanMove(int newX, int newY)
        {
            return !(this[newX, newY] is WallField); 
            //TODO: check ob auch nur ein Feld weit
            //TODO: Check ob an Spielfeldgrenze
        }

        public bool CanMove(Point p)
        {
            return CanMove(p.X, p.Y);
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
