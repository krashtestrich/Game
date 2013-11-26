﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public abstract class Equipment
    {
        #region Name

        public abstract string Name
        {
            get;
        }
    
        #endregion

        #region Equipment Type
        private string equipmentType;

        public abstract string EquipmentType
        {
            get;
        }

        #endregion

        #region Slots
        private List<Slot> slots;

        public void AddSlotType(Slot slot)
        {
            slots.Add(slot);
        } 

        public List<Slot> Slots
        {
            get
            {
                return slots;
            }
        }
        #endregion

        #region Price
        private int price;
        public abstract int Price
        {
            get;
        }

        #endregion

        public Equipment()
        {
            slots = new List<Slot>();
        }
    }
}
