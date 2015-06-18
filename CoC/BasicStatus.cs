using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoC;

namespace CoC
{
    public class BasicStatus
    {
        internal class FundamentalStatus {
            private Int16 _strength;
            private Int16 _dexterity;
            private Int16 _intelligence;
            private Int16 _constitution;
            private Int16 _appearance;
            private Int16 _maxMagicPoint;
            private Int16 _size;
            private Int16 _education;
            public FundamentalStatus(Int16 strength,
                Int16 dexterity,
                Int16 intelligence,
                Int16 constitution,
                Int16 appearance,
                Int16 maxMagicPoint,
                Int16 size,
                Int16 education) {
                _strength= strength;
                _dexterity= dexterity;
                _intelligence= intelligence;
                _constitution= constitution;
                _appearance= appearance;
                _maxMagicPoint = maxMagicPoint;
                _size= size;
                _education= education;
            }
        }

        private FundamentalStatus _foundation;
    }
}
