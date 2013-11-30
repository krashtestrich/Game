using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Arena
{
    public class ArenaFloorPosition
    {
        private int xCoord;
        public int XCoord
        {
            get
            {
                return xCoord;
            }
        }
        public void SetXCoord(int x)
        {
            xCoord = x;
        }

        private int yCoord;
        public int YCoord
        {
            get
            {
                return yCoord;
            }
        }
        public void SetYCoord(int y)
        {
            yCoord = y;
        }

        public ArenaFloorPosition(int x, int y)
        {
            xCoord = x;
            yCoord = y;
        }
    }
}
