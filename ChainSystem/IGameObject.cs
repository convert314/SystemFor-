using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSystem
{
    public interface IGameObject : IObservable<News>
    {
        String GetName(Int64 securityClearance);
        String Name { get; }
        String GetDescritption(Int64 securityClearance);
        Boolean HasAttribute(String name, Int64 securityClearance);
        T GetAttribute<T>(String name, Int64 securityClearance);
    }
}
