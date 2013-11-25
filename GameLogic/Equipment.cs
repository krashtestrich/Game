using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public abstract class Equipment
    {
        #region Name
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        #endregion

        #region Equipment Type
        private string equipmentType;

        public string EquipmentType
        {
            get
            {
                return this.equipmentType;
            }
        }

        #endregion

        #region Slots
        private List<Slot> slots;

        public void AddSlotType(Slot slot)
        {
            this.slots.Add(slot);
        }

        public List<Slot> Slots
        {
            get
            {
                return slots;
            }
        }
        #endregion

        public Equipment()
        {
            slots = new List<Slot>();
        }
    }
}
