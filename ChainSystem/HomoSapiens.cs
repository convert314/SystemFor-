using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoC;

namespace CoC.ChainSystem
{
    public class HomoSapiens : BasicStatus, IHomoSapiens
    {
        public HomoSapiens() : base() {    
        }
        public HomoSapiens(Int16 STR, Int16 DEX, Int16 INT, Int16 CON, Int16 APP, Int16 POW, Int16 SIZ, Int16 EDU,
            Int16 IDEA, Int16 LUCK, Int16 KNOWLEDGE, Dice DB,
            Int16 MaxHP, Int16 HP, Int16 MaxMP, Int16 MP, Int16 MaxSAN, Int16 SAN,
            Sex SEX, Int64 AGE, String OCCUPATION, String SCHOOL, String BIRTHPLACE)
            : base(STR, DEX, INT, CON, APP, POW, SIZ, EDU,
            IDEA, LUCK, KNOWLEDGE, DB,
            MaxHP, HP, MaxMP, MP, MaxSAN, SAN,
            SEX, AGE, OCCUPATION, SCHOOL, BIRTHPLACE)
        {
        }
    }
}
