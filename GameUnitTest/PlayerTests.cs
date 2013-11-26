using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;
using GameLogic.Equipments.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameUnitTest
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void PlayerCanHaveCashSet()
        {
            Player p = new Player();
            int startingCash = p.Cash;
            p.SetCash(startingCash + 100);
            Assert.IsTrue(p.Cash == (startingCash + 100));
        }

        [TestMethod]
        public void PlayerCanHaveCashAdded()
        {
            Player p = new Player();
            int startingCash = p.Cash;
            p.AddCash(10);
            Assert.IsTrue(p.Cash == (startingCash + 10));
        }

        [TestMethod]
        public void PlayerCanAffordAffordableEquipment()
        {
            Player p = new Player();
            Sword s = new Sword();
            if (p.Cash < s.Price)
            {
                p.AddCash(s.Price);
            }
            Assert.IsTrue(p.CanAffordEquipment(s));
        }

        [TestMethod]
        public void PlayerCannotAffordUnaffordableEquipment()
        {
            Player p = new Player();
            Sword s = new Sword();
            if (p.Cash >= s.Price) 
            {
                p.SetCash(s.Price-100);
            }
            Assert.IsFalse(p.CanAffordEquipment(s));
        }
    }
}
