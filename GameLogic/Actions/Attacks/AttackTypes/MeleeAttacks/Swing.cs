using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Actions.Attacks.AttackTypes.MeleeAttacks
{
    public class Swing : MeleeAttack
    {        
        public string Name
        {
	        get { return "Swing"; }
        }

        public int BaseDamageModifier
        {
            get { return 0; }
        }

        public int BonusDamageModifier
        {
            get { return 0; }
        }

        public int MinRange
        {
            get { return 1; }
        }

        public int MaxRange
        {   
            get { return 1; }
        }
    }
}
