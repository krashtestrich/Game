using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLogic.Maths;

namespace GameUnitTest
{
    [TestClass]
    public class MathsTests
    {
        [TestMethod]
        public void GetHypotenusLengthFromPythagorusWorks()
        {
            var a = 2;
            var b = 3;
            var c = MathematicalFunctions.PythagorusGetHypotenusLengthFromRightAngledLengths(2, 3);
            c = Math.Round(c, 2);
            Assert.IsTrue(c == 3.61);
        }
    }
}
