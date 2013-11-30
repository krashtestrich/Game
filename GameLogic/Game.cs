using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Game
    {
        protected Arena.Arena arena;
        protected Player player;

        protected void CreateArena()
        {
            arena = new Arena.Arena();
            player = new Player();
        }
    }
}
