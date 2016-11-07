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
            Location = MovePawnAndSetUpPlayground(Location, Location.UpperNeighbour());
        }

        public void MoveDown()
        {
            Location = MovePawnAndSetUpPlayground(Location, Location.LowerNeighbour());
        }

        public void MoveLeft()
        {
            Location = MovePawnAndSetUpPlayground(Location, Location.LeftNeighbour());
        }

        public void MoveRight()
        {
            Location = MovePawnAndSetUpPlayground(Location, Location.RightNeighbour());
        }

        public void Dispose()
        {
            
        }
    }
}
