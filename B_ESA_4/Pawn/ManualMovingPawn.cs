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
            internalPlayground.MovePawnUp();
        }

        public void MoveDown()
        {
            internalPlayground.MovePawnDown();
        }

        public void MoveLeft()
        {
            internalPlayground.MovePawnLeft();
        }

        public void MoveRight()
        {
            internalPlayground.MovePawnRight();
        }

        public void Dispose()
        {
            
        }
    }
}
