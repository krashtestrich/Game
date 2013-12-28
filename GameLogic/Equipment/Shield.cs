using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Equipments
{
    public abstract class Shield : Equipment
    {
        public override string EquipmentType
        {
            get { return "Shield"; }
        }

    }
}
