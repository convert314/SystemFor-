using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoC
{
    public interface IEffectable : IGameObject, IObservable<News>
    {
        IGameObject Owner { get; }
        Boolean IsExecutable(News news);
        void Execute(News news, IGameObject obj);
        IEffectable[] PartialEffects { get; }
        Boolean IsPartialExecutable(News news, out Int64 index);
    }
}
