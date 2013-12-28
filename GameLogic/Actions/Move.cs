using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Arena;

namespace GameLogic.Actions
{
    public abstract class Move : Action<Character, Arena.Arena>
    {
        public abstract int Distance
        { get; }

        public override bool CanBePerformed(Character c, Arena.Arena arena)
        {
            return false;
        }
    }
}
