using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Actions
{
    public abstract class Action<TSource, TTarget> : IAction<TSource, TTarget>
    {
        public abstract bool CanBePerformed(TSource s, TTarget t);
    }

    public abstract class Action : IAction
    {
        public abstract string Name
        {
            get;
        }        
    }
}
