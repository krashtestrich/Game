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
using GameLogic.Actions.Attacks;
using GameLogic.Actions;

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
            var e = new TestHelpers.TestWeapon();
            Assert.IsTrue(c.CanEquipEquipment(e));
        }

        [TestMethod]
        public void CannotEquipEquipmentIfCharacterDoesNotHaveEnoughFreeSlots()
        {
            var c = new Character();
            var e = new TestHelpers.TestWeapon();
            e.AddSlotType(new Hand());
            e.AddSlotType(new Hand());
            e.AddSlotType(new Hand());
            Assert.IsFalse(c.CanEquipEquipment(e));
        }

        [TestMethod]
        public void EquipEquipmentAddsEquipmentToCharactersEquipment()
        {
            var c = new Character();
            var e = new TestHelpers.TestWeapon();
            c.EquipEquipment(e);
            Assert.IsTrue(c.CharacterEquipment.Exists(x => x == e));
        }

        [TestMethod]
        public void EquipEquipmentUpdatesCharacterEquipmentSlotsToUsed()
        {
            var c = new Character();
            var e = new TestHelpers.TestWeapon();
            e.AddSlotType(new Hand());
            c.EquipEquipment(e);
            Assert.IsTrue(c.Slots.Exists(x => !x.SlotFree && x.SlotEquipmentName == e.Name));
        }

        [TestMethod]
        [ExpectedException(typeof (Exception))]
        public void EquipEquipmentWhenCharacterDoesNotHaveEnoughFreeSlotsThrowsException()
        {
            var c = new Character();
            var e = new TestHelpers.TestWeapon();
            e.AddSlotType(new Hand());
            e.AddSlotType(new Hand());
            e.AddSlotType(new Hand());
            c.EquipEquipment(e);
        }

        [TestMethod]
        public void UnEquipEquipmentRemovesEquipmentFromCharactersEquipment()
        {
            var c = new Character();
            var e = new TestHelpers.TestWeapon();
            c.EquipEquipment(e);
            c.UnEquipEquipment(e);
            Assert.IsFalse(c.CharacterEquipment.Exists(x => x == e));
        }

        [TestMethod]
        public void UnEquipEquipmentFreesCharactersEquipmentSlots()
        {
            var c = new Character();
            var e = new TestHelpers.TestWeapon();
            c.EquipEquipment(e);
            c.UnEquipEquipment(e);
            Assert.IsFalse(c.Slots.Exists(x => !x.SlotFree || x.SlotEquipmentName == e.Name));
        }

        [TestMethod]
        public void CharacterLocationCanBeSet()
        {
            var c = new Character();
            c.SetCharacterLocation(1, 2);
            Assert.IsTrue(c.CharacterLocation.XCoord == 1 && c.CharacterLocation.YCoord == 2);
        }

        [TestMethod]
        public void CharacterCanPerformAttackActionWhenWithinRange()
        {
            var c = new Character();
            c.SetCharacterLocation(0, 0); 
            var o = new Character();
            o.SetCharacterLocation(1, 1);
            var e = new TestHelpers.TestWeapon();
            c.EquipEquipment(e);
            var s = new TestHelpers.TestAttack();
            Assert.IsTrue(s.CanBePerformed(c, o));
        }

        [TestMethod]
        public void CharacterCannotPerformAttackWhenOutOfRange()
        {
            var c = new Character();
            c.SetCharacterLocation(0, 0);
            var o = new Character();
            o.SetCharacterLocation(10, 10);
            var e = new TestHelpers.TestWeapon();
            c.EquipEquipment(e);
            var s = new TestHelpers.TestAttack();
            Assert.IsFalse(s.CanBePerformed(c, o));
        }

        [TestMethod]
        public void PlayerHasAvailableActionFromEquippedEquipment()
        {
            var c = new Character();
            var e = new TestHelpers.TestWeapon();
            c.EquipEquipment(e);
            Assert.IsTrue(c.AvailableActions.Exists(i => i.Name == "Test Attack"));
        }

        [TestMethod]
        public void PlayerHasAvailableActionsFromEquippedEquipment()
        {
            var c = new Character();
            var e = new TestHelpers.TestWeapon();
            c.EquipEquipment(e);
            var e2 = new TestHelpers.TestWeapon2();
            c.EquipEquipment(e2);
            Assert.IsTrue(c.AvailableActions.Exists(i => i.Name == "Test Attack") && c.AvailableActions.Exists(i => i.Name == "Test Attack2"));
        }

        [TestMethod]
        public void PlayerAvailableActionsAreDistinct()
        {
            var c = new Character();
            var e = new TestHelpers.TestWeapon();
            c.EquipEquipment(e);
            c.EquipEquipment(e);
            Assert.IsTrue(c.AvailableActions.FindAll(i => i.Name == "Test Attack").Count == 1);
        }

        [TestMethod]
        public void WeaponDamageGetsCalculated()
        {
            var w = new TestHelpers.TestWeapon();
            var dmg = w.GetDamage();
            Assert.IsTrue((w.BaseDamage + w.BonusDamage) >= dmg && dmg >= w.BaseDamage);
        }
    }
}
