using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Actions.Attacks
{
	public class Swing : Attack, IAction
	{
        public string Name
		{
			get { return "Swing"; }
		}

		public override int BaseDamageModifier
		{
			get { return 0; }
		}

        public override int BonusDamageModifier
		{
			get { return 0; }
		}

        public override int MinRange
		{
			get { return 1; }
		}

        public override int MaxRange
		{   
			get { return 1; }
		}        
	}
}
