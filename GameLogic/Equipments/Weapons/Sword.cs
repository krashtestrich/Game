using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Equipments.Weapons
{
    public sealed class Sword : Weapon
    {
        public override string WeaponType
        {
            get
            {
                return "Sword";
            }
        }

        public override int BaseDamage
        {
            get { return 10; }
        }

        public override int BonusDamage
        {
            get { return 5; }
        }
    }
}
