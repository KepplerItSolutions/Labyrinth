using B_ESA_4.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B_ESA_4.Playground;

namespace B_ESA_4.Pawn
{
    public abstract class PawnBase
    {
        protected PlayGround InternalPlayground;

        public PawnBase(PlayGround playground)
        {
            InitPawn(playground);
        }

        private void InitPawn(PlayGround playground)
        {
            InternalPlayground = playground;
        }

        public PawnBase(PlayGround playground, int x, int y)
        {
            InitPawn(playground);
        }

    }
}
