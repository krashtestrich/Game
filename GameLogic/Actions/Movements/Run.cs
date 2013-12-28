using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Actions.Movements
{
    public class Run : Move, IAction
    {
        public string Name
        {
            get { return "Run"; }
        }

        public override int Distance
        {
            get { return 3; }
        }
    }
}
