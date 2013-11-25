using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public static class CharacterFactory
    {
        public static ICharacter Character
        {
            get
            {
                return CharacterFactory._character == null ? new Character() : CharacterFactory._character;
            }
            set
            {
                CharacterFactory._character = value;
            }
        }

        private static ICharacter _character = null;
    }
}
