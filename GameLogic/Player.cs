using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Player : Character
    {
        private int cash;
        public int Cash
        {
            get
            {
                return cash;
            }
        }

        public void SetCash(int amount)
        {
            cash = amount;
        }

        public void AddCash(int amount)
        {
            cash += amount;
        }

        #region Shop Stuff
        public bool CanAffordEquipment(Equipment e)
        {
            return (cash >= e.Price);
        }

        public void PurchaseEquipment(Equipment e)
        {
            if (CanAffordEquipment(e) && CanEquipEquipment(e))
            {
                cash -= e.Price;
                EquipEquipment(e);
            }
            else
            {
                throw new Exception("Player tried to purchase unaffordable or unwearable Equipment.");
            }
        }

        public void SellEquipment(Equipment e)
        {
            cash += (int)Math.Round(e.Price * 0.75, MidpointRounding.ToEven);
            UnEquipEquipment(e);
        }
        #endregion

        public Player()
        {
            SetHealth(100);
            SetCash(100);
        }
    }
}
