using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B_ESA_4.Playground;

namespace B_ESA_4.Pawn
{
    public class ManualMovingPawn : PawnBase, IPawn
    {
        public ManualMovingPawn(PlayGround playground)
            :base(playground)
        {

        }

        public ManualMovingPawn(PlayGround playground, int x, int y)
            : base(playground, x, y)
        {

        }

        public void MoveUp()
        {
            if (CanMove(this.PawnX, this.PawnY - 1))
            {
                MovePawnAndSetUpPlayground(this.PawnX, this.PawnY, this.PawnX, this.PawnY - 1);
                this.PawnY--;
            }
        }

        public void MoveDown()
        {
            if (CanMove(this.PawnX, this.PawnY + 1))
            {
                MovePawnAndSetUpPlayground(this.PawnX, this.PawnY, this.PawnX, this.PawnY + 1);
                this.PawnY++;
            }
        }

        public void MoveLeft()
        {
            if (CanMove(this.PawnX - 1, this.PawnY))
            {
                MovePawnAndSetUpPlayground(this.PawnX, this.PawnY, this.PawnX - 1, this.PawnY);
                this.PawnX--;
            }
        }

        public void MoveRight()
        {
            if (CanMove(this.PawnX + 1, this.PawnY))
            {
                MovePawnAndSetUpPlayground(this.PawnX, this.PawnY, this.PawnX + 1, this.PawnY);
                this.PawnX++;
            }
        }

        public void Dispose()
        {
            
        }
    }
}
