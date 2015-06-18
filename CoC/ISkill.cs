using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoC
{
    public interface ISkill
    {
        String Name { get; }
        Int32 Experience { get; }
        Byte Star { get; }
        Boolean IsSuccess();
        IEffectable Effect { get; }
        void LevelUp();
    }
}
