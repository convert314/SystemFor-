using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoC
{
    public sealed class DefaultEffect : IEffectable
    {
        private static readonly DefaultEffect _instance = new DefaultEffect();

        private DefaultEffect() { }

        public static DefaultEffect Instance
        {
            get { return _instance; }
        }

        public IGameObject Owner
        {
            get { return null; }
        }

        public bool IsExecutable(News news)
        {
            return true;
        }

        public void Execute(News news, IGameObject obj)
        {
            return;
        }

        public IEffectable[] PartialEffectables
        {
            get { return null; }
        }

        public bool IsPartialExecutable(News news, out Int64[] index)
        {
            index = new Int64[0];
            return false;
        }

        public string GetName(long securityClearance)
        {
            return String.Empty;
        }

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
