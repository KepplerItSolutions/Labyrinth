using System.Drawing;

namespace B_ESA_4.Pawn
{
    public interface IPawn
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void Dispose();  
    }
}
