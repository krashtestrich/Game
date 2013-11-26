using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Equipments
{
    public abstract class Weapon : Equipment
    {
        public override string EquipmentType
        {
            get { return "Weapon"; }
        }

        #region Abstract Properties
        public abstract string WeaponType
        {
            get;           
        }
        public abstract int BaseDamage
        {
            get;
        }

        public abstract int BonusDamage
        {
           get;
        }
        #endregion
    }
}
