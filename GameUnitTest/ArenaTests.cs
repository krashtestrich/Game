using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLogic;
using GameLogic.Arena;

namespace GameUnitTest
{
    [TestClass]
    public class ArenaTests
    {
        [TestMethod]
        public void CharacterCanBeAddedToArena()
        {
            var a = new Arena();
            a.BuildArenaFloor(5);
            var c = new Character();
            c.SetName("YoMomma");
            a.AddCharacterToArena(c);

            Assert.IsTrue(a.Characters.Exists(i => i.Name == "YoMomma"));
        }

        [TestMethod]
        [ExpectedException(typeof (Exception))]
        public void CharacterCannotBeAddedToArenaWhenFloorNotBuilt()
        {
            var a = new Arena();
            var c = new Character();
            c.SetName("YoMomma");
            a.AddCharacterToArena(c);
        }

        [TestMethod]
        public void PlayerCanBeAddedToArena()
        {
            var p = new Player();
            var a = new Arena();
            a.BuildArenaFloor(5);
            a.AddPlayerToArena(p);
            Assert.IsTrue(a.Player == p);
        }

        [TestMethod]
        [ExpectedException(typeof (Exception))]
        public void PlayerCannotBeAddedToArenaWhenFloorNotBuilt()
        {
            var p = new Player();
            var a = new Arena();
            a.AddPlayerToArena(p);
        }

        [TestMethod]
        public void PlayerAddedToArenaDefaultLocationIsBottomCentreOfArenaForOddWidth()
        {
            var p = new Player();
            var a = new Arena();
            a.BuildArenaFloor(5);
            a.AddPlayerToArena(p);
            a.SetDefaultPlayerLocation();
            Assert.IsTrue(p.CharacterLocation.XCoord == a.ArenaFloor.GetLength(0) - 1 && p.CharacterLocation.YCoord == 2);
        }

        [TestMethod]
        public void PlayerAddedToArenaDefaultLocationIsBottomLeftCentreOfArenaForEvenWidth()
        {
            var p = new Player();
            var a = new Arena();
            a.BuildArenaFloor(8);
            a.AddPlayerToArena(p);
            a.SetDefaultPlayerLocation();
            Assert.IsTrue(p.CharacterLocation.XCoord == a.ArenaFloor.GetLength(0) - 1 && p.CharacterLocation.YCoord == 3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PlayerDefaultLocationCannotBeSetIfArenaFloorNull()
        {
            var p = new Player();
            var a = new Arena();
            a.AddPlayerToArena(p);
            a.SetDefaultPlayerLocation();
        }

        [TestMethod]
        [ExpectedException(typeof (Exception))]
        public void PlayerDefaultLocationCannotBeSetIfPlayerNull()
        {
            var a = new Arena();
            a.BuildArenaFloor(5);
            a.SetDefaultPlayerLocation();
        }

        [TestMethod]
        public void ArenaFloorCanBeCreated()
        {
            var a = new Arena();
            a.BuildArenaFloor(5);

            Assert.IsTrue(a.ArenaFloor.Length == 25);
        }

        [TestMethod]
        public void GetDistanceBetweenFloorPositionsWorksShortDistance()
        {
            var p1 = new ArenaFloorPosition(0, 0);
            var p2 = new ArenaFloorPosition(1, 2);
            var d = ArenaHelper.GetDistanceBetweenFloorPositions(p1, p2);
            Assert.IsTrue(d == 1);
        }

        [TestMethod]
        public void GetDistanceBetweenFloorPositionsWorksLongDistance()
        {
            var p1 = new ArenaFloorPosition(0, 1);
            var p2 = new ArenaFloorPosition(10, 25);
            var d = ArenaHelper.GetDistanceBetweenFloorPositions(p1, p2);
            Assert.IsTrue(d == 10);
        }
    }
}
