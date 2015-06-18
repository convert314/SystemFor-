using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoC.Skill.English
{
    public sealed class Accounting : Skill, ISkill
    {
        public Accounting()
            : base("Accounting", @"Grants understanding of accountancy procedures, and reveals the financial functioning of a business or person. Inspecting the books, one might detect cheated employees, siphoned-off funds, payment of bribes or blackmail, and whether or not the financial condition is better or worse than claimed. Looking through old accounts, one could see how money was gained or lost in the past (grain, slave-trading, whiskey-running, etc.) and to whom and for what payment was made.")
        {

        }
    }
}
