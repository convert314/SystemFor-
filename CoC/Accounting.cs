using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoC
{
    public sealed class Accounting : ISkill
    {
        Int32 _experience = 0;
        Byte _star = 0;

        string ISkill.Name
        {
            get { return "会計学"; }
        }

        Int32 ISkill.Experience
        {
            get { return _experience; }
        }

        Byte ISkill.Star
        {
            get { return _star; }
        }

        Boolean ISkill.IsSuccess()
        {
            throw new NotImplementedException();
        }

        IEffectable ISkill.Effect
        {
            get { throw new NotImplementedException(); }
        }
    

int ISkill.Experience
{
	get { throw new NotImplementedException(); }
}

byte ISkill.Star
{
	get { throw new NotImplementedException(); }
}
}
}
