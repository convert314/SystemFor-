﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoC
{
    public class Skill : ISkill
    {
        protected Int32 _experience = 0;
        protected Byte _star = 0;
        protected readonly String _name;
        protected readonly IEffectable _effect;
        protected readonly String _description;

        protected Skill() { }
        protected Skill(String name)
        {
            _name = name;
        }
        protected Skill(String name, String description)
        {
            _name = name;
            _description = description;
        }
        protected Skill(String name, String description, IEffectable effect) {
            _name = name;
            _description = description;
            _effect = effect;
        }

        public string Name
        {
            get { return _name ?? String.Empty; }
        }

        public String Description { get { return _description ?? String.Empty; } }

        public Int32 Experience
        {
            get { return _experience; }
        }

        public Byte Star
        {
            get { return _star; }
        }

        public Boolean IsSuccess()
        {
            var res = Dice.D1D100.Cast();
            if (res <= 5)
            {
                _star++;
                LevelUp();
            }
            return res <= _experience;
        }

        public IEffectable Effect
        {
            get { return _effect ?? DefaultEffect.Instance; }
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
                else
                {
                    _star = (Byte)(level + 1);
                }
            }
        }
    }
}
