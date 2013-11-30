using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Actions
{
    public abstract class Attack
    {
        private string name;
        private int baseDamageModifier;
        private int bonusDamageModifier;
        private int minRange;
        private int maxRange;

        public string Name
        {
            get;
            set;
        }

        public int BaseDamageModifier
        {
            get;
            set;
        }

        public int BonusDamageModifier
        {
            get;
            set;
        }

        public int MinRange
        {
            get;            
            set;        
        }

        public int MaxRange
        {
            get;
            set;
        }
    }

    public abstract class Attack<T> : Attack
    {

    }
}
