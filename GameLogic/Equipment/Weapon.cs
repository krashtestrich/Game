using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Actions;
using GameLogic.Actions.Attacks;

namespace GameLogic.Equipments
{
    public abstract class Weapon : Equipment
    {
        public override string EquipmentType
        {
            get {                             
                return "Weapon"; 
            }
        }

        public virtual int GetDamage()
        {
            return BaseDamage + r.Next(0, BonusDamage);
        }

        #region Abstract Properties
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
