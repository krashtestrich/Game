using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Battle
{
    public class Battle
    {
        private int _turn;
        private bool _isPlayersTurn; 

        public Battle()
        {
            _turn = 1;
            _isPlayersTurn = true;
        }
    }
}
