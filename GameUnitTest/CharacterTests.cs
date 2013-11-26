using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLogic;
using GameLogic.Slots;
using GameLogic.Equipments;
using GameLogic.Equipments.Weapons;
using Moq;

namespace GameUnitTest
{
    [TestClass]
    public class CharacterTests
    {
        private Mock<ICharacter> _mockCharacter = null;

        [TestMethod]
        public void CanEquipEquipmentIfCharacterHasFreeSlots()
        {
            var c = new Character();
            var e = new Sword();
            Assert.IsTrue(c.CanEquipEquipment(e));
        }

        [TestMethod]
        public void CannotEquipEquipmentIfCharacterDoesNotHaveEnoughFreeSlots()
        {
            var c = new Character();
            var e = new Sword();
            e.AddSlotType(new Hand());
            e.AddSlotType(new Hand());
            e.AddSlotType(new Hand());
            Assert.IsFalse(c.CanEquipEquipment(e));
        }

        [TestMethod]
        public void EquipEquipmentWorks()
        {
            var c = new Character();
            var e = new Sword();
            c.EquipEquipment(e);
            Assert.IsTrue(c.CharacterEquipment.Exists(x => x == e));
        }

        [TestMethod]
        [ExpectedException(typeof (Exception))]
        public void EquipEquipmentWhenCharacterDoesNotHaveEnoughFreeSlotsThrowsException()
        {
            var c = new Character();
            var e = new Sword();
            e.AddSlotType(new Hand());
            e.AddSlotType(new Hand());
            c.EquipEquipment(e);
        }
    }
}
