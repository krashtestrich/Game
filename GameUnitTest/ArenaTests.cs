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
            Arena a = new Arena();
            Character c = new Character();
            c.SetName("YoMomma");
            a.AddCharacterToArena(c);

            Assert.IsTrue(a.Characters.Exists(i => i.Name == "YoMomma"));
        }

        [TestMethod]
        public void ArenaFloorCanBeCreated()
        {
            Arena a = new Arena();
            a.BuildArenaFloor(5);

            Assert.IsTrue(a.ArenaFloor.Length == 25);
        }

        [TestMethod]
        public void GetDistanceBetweenFloorPositionsWorksShortDistance()
        {
            ArenaFloorPosition p1 = new ArenaFloorPosition(0, 0);
            ArenaFloorPosition p2 = new ArenaFloorPosition(1, 2);
            var d = ArenaHelper.GetDistanceBetweenFloorPositions(p1, p2);
            Assert.IsTrue(d == 1);
        }

        [TestMethod]
        public void GetDistanceBetweenFloorPositionsWorksLongDistance()
        {
            ArenaFloorPosition p1 = new ArenaFloorPosition(0, 1);
            ArenaFloorPosition p2 = new ArenaFloorPosition(10, 25);
            var d = ArenaHelper.GetDistanceBetweenFloorPositions(p1, p2);
            Assert.IsTrue(d == 10);
        }
    }
}
