using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Actions
{
    public interface IAction<TSource, TTarget>
    {
        bool CanBePerformed(TSource s, TTarget t);
    }

    public interface IAction
    {
        string Name { get; }
    }
}
