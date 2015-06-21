using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoC
{
    public sealed class DefaultEffect : IEffectable
    {
        private DefaultEffect() { }

        public static DefaultEffect Instance { get; } = new DefaultEffect();

        public IGameObject Owner => null;

        public bool IsExecutable(News news) => false;

        public void Execute(News news, IGameObject obj)
        {
            return;
        }

        public IEffectable[] PartialEffectables => null;

        public bool IsPartialExecutable(News news, out Int64[] index)
        {
            index = new Int64[0];
            return false;
        }

        public string GetName(long securityClearance) => String.Empty;

        public string Id
        {
            get { return String.Empty; }
        }

        public string GetDescritption(long securityClearance)
        {
            return String.Empty;
        }

        public bool HasAttribute(string name, long securityClearance)
        {
            return false;
        }

        public IDisposable Subscribe(IObserver<News> observer)
        {
            return System.Reactive.Disposables.Disposable.Empty;
        }

        public object GetAttribute(string name, long securityClearance)
        {
            return null;
        }
    }
}
