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
            var res = Dice.D1D100.Cast();
            if (res <= 5)
            {
                _star++;
                LevelUp();
            }
            return res <= _experience;
        }

        IEffectable ISkill.Effect
        {
            get { return new DefaultEffect(); }
        }

        public void LevelUp()
        {
            var level = _experience / 100;
            if (level < 0)
            {
                _experience += _star;
                _star = 0;
            }
            else if (_star > level + 1)
            {
                if (Dice.D1D100.Cast() <= 100 - (_experience % 100))
                {
                    _experience++;
                    _star -= (Byte)(level + 2);
                }
                else {
                    _star = (Byte)(level + 1);
                }
            }
        }
    }
}
