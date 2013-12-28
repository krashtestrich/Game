using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Actions;
using GameLogic.Actions.Attacks;
using GameLogic.Slots;

namespace GameLogic.Equipments.Weapons
{
    public sealed class BigSword : Weapon
    {     
        public override string Name
        {
            get
            {
                return "Big Sword";
            }
        }

        public override int BaseDamage
        {
            get { return 20; }
        }

        public override int BonusDamage
        {
            get { return 5; }
        }

        public override int Price
        {
            get { return 75; }
        }

        public override List<IAction> Actions
        {
            get
            {
                return new List<IAction>()
                    {
                        new Swing()
                    };
            }
        }

        public BigSword()
        {
            AddSlotType(new Hand());
            AddSlotType(new Hand());
        }
    }
}
