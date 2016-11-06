using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_ESA_4.Pawn
{
    public interface IPawn
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void Dispose();  
        int PawnX { get; set; }
        int PawnY { get; set; }
    }
}
