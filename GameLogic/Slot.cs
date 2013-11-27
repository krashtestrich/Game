using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Slot
    {
        #region Slot Free
        private bool slotFree;        

        public bool SlotFree
        {
            get
            {
                return this.slotFree;
            }            
        }

        public void SetSlotFree(bool free, string equipName)
        {
            this.slotFree = free;
            this.slotEquipmentName = equipName;
        }

        private string slotEquipmentName;

        public string SlotEquipmentName
        {
            get
            {
                return slotEquipmentName;
            }
        }

        #endregion

        #region Slot Type
        private string slotType;

        public string SlotType
        {
            get
            {
                return this.slotType;
            }
        }
        #endregion

        public Slot()
        {
            this.slotFree = true;
        }
    }
}
