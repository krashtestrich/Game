using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Actions.Attacks;
using GameLogic.Arena;
using GameLogic.Equipments;

namespace GameLogic.Actions
{
    public abstract class Attack : Action<Character, Character>
    {
        public abstract int BaseDamageModifier
        {
            get;           
        }

        public abstract int BonusDamageModifier
        {
            get;            
        }

        public abstract int MinRange
        {
            get;                             
        }

        public abstract int MaxRange
        {
            get;
        }

        public override bool CanBePerformed(Character c, Character t)
        {
            var distance = ArenaHelper.GetDistanceBetweenFloorPositions(c.CharacterLocation, t.CharacterLocation);
            return distance <= MaxRange
                && distance >= MinRange;
        }
    } 
}