using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoC
{
    class DefaultEffect : IEffectable
    {
        IGameObject IEffectable.Owner
        {
            get { return null; }
        }

        bool IEffectable.IsExecutable(News news)
        {
            return true;
        }

        void IEffectable.Execute(News news, IGameObject obj)
        {
            return;
        }

        IEffectable[] IEffectable.PartialEffects
        {
            get { return null; }
        }

        bool IEffectable.IsPartialExecutable(News news, out long index)
        {
            index = -1;
            return false;
        }

        string IGameObject.GetName(long securityClearance)
        {
            return String.Empty;
        }

        string IGameObject.Name
        {
            get { return String.Empty; }
        }

        string IGameObject.GetDescritption(long securityClearance)
        {
            return String.Empty;
        }

        bool IGameObject.HasAttribute(string name, long securityClearance)
        {
            return false;
        }

        T IGameObject.GetAttribute<T>(string name, long securityClearance)
        {
            return default(T);
        }

        IDisposable IObservable<News>.Subscribe(IObserver<News> observer)
        {
            return System.Reactive.Disposables.Disposable.Empty;
        }
    }
}
