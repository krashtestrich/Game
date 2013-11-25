using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLogic;

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
    }
}
