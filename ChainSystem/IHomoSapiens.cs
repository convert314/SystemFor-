using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSystem
{
    public interface IHomoSapiens
    {
        Int16 MaxHitPoint { get; set; }
        Int16 HitPoint { get; set; }
        Int16 MaxMagicPoint { get; set; }
        Int16 MagicPoint { get; set; }
        Int16 MaxSanityPoint { get; set; }
        Int16 SanityPoint { get; set; }

        Int16 Strength { get; set; }
        Int16 Intelligence { get; set; }
        Int16 Constitution { get; set; }
        Int16 Dexterity { get; set; }
        Int16 Appearance { get; set; }
        Int16 Education { get; set; }
        Int16 Size { get; set; }

        Int16 Luck { get; set; }
        Int16 Idea { get; set; }
        Int16 Knowledge { get; set; }
    }
}
