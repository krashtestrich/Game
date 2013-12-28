using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Maths
{
    public static class MathematicalFunctions
    {
        public static double PythagorusGetHypotenusLengthFromRightAngledLengths(double x, double y)
        {
            return (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
        }
    }
}
