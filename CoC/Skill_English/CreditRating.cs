using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoC.Skill.English
{
    public sealed class CreditRating : Skill, ISkill
    {
        public CreditRating()
            : base("Credit Rating", @"Narrowly, how prosperous and confident the investigator seems to be. This is the investigator’s chance to panhandle or get a loan from a bank or business, and it is also the chance for the investigator to pass a bad check or to bluff past a demand for credentials.")
        {
            _experience = 15;
        }
    }
}
