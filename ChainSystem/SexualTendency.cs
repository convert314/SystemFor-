using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSystem
{
    public sealed class SexualTendency
    {
        Int16 MaxHomo { get; set; }
        Int16 MinHomo { get; set; }
        Int16 Homo { get; set; }
        Int16 MaxHetero { get; set; }
        Int16 MinHetero { get; set; }
        Int16 Hetero { get; set; }

        public SexualTendency() { }
        public SexualTendency(Random random) {
        
        }
    }
}
