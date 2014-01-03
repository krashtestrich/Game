using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Actions
{
    public abstract class Action<TSource, TTarget> : IAction<TSource, TTarget>
    {
        protected Random _r;
        public abstract bool CanBePerformed(TSource s, TTarget t);
        public abstract void Perform(TSource s, TTarget t);
        protected Action()
        {
            _r = new Random();
        }
    }

    public abstract class Action : IAction
    {
        public abstract string Name
        {
            get;
        }        
    }
}
