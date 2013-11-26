using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Equipments;
using GameLogic.Equipments.Weapons;

namespace GameLogic
{
    public class Shop : IShop
    {
        #region Equipment
        private List<Equipment> equipment;

        public List<Equipment> Equipment
        {
            get
            {
                return equipment;
            }
        }

        private void PopulateShop()
        {
            equipment.Add(new Sword());
            equipment.Add(new BigSword());
        }
        #endregion        

        #region Player
        private Player playerAtShop;
        public Player PlayerAtShop
        {
            get
            {
                return playerAtShop;
            }
        }

        public void AddPlayerToShop(Player p)
        {
            playerAtShop = p;
        }
        #endregion
        public Shop()
        {
            equipment = new List<Equipment>();
            PopulateShop();
        }
    }
}
