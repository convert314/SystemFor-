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
        public BasicStatus()
        {
            _sexuality = Sex.NoSex;
            _school = String.Empty;
            _occupation = String.Empty;
            _birthPlace = String.Empty;
            _fundamental = new FundamentalStatus();
            _advanced = new AdvancedStatus(_fundamental);
            _age = Dice.Cast(1, (Byte)(80 - _fundamental.Education), _fundamental.Education);
        }
        public BasicStatus(Int16 strength, Int16 dexterity, Int16 intelligence, Int16 constitution, Int16 appearance, Int16 power, Int16 size, Int16 education,
            Int16 idea, Int16 luck, Int16 knowledge, Dice damageBonus, Int16 maxHitPoint, Int16 hitPoint, Int16 maxMagicPoint, Int16 magicPoint, Int16 maxSanityPoint, Int16 sanityPoint,
            Sex sexuality, Int64 age, String occupation, String school, String birthPlace)
        {
            _fundamental = new FundamentalStatus(strength, dexterity, intelligence, constitution, appearance, power, size, education);
            _advanced = new AdvancedStatus(idea, luck, knowledge, damageBonus, maxHitPoint, hitPoint, maxMagicPoint, magicPoint, maxSanityPoint, sanityPoint);
            _sexuality = sexuality;
            _age = age;
            _occupation = occupation;
            _school = school;
            _birthPlace = birthPlace;
        }
        protected internal BasicStatus(FundamentalStatus fundamental, AdvancedStatus advanced, Sex sexuality, Int64 age, String occupation, String school, String birthPlace)
        {
            _fundamental = fundamental;
            _advanced = advanced;
            _age = age;
            _sexuality = sexuality;
            _occupation = occupation;
            _school = school;
            _birthPlace = birthPlace;
        }


        protected internal class FundamentalStatus
        {
            public Int16 Strength { get; set; }
            public Int16 Dexterity { get; set; }
            public Int16 Intelligence { get; set; }
            public Int16 Constitution { get; set; }
            public Int16 Appearance { get; set; }
            public Int16 Power { get; set; }
            public Int16 Size { get; set; }
            public Int16 Education { get; set; }
            public FundamentalStatus()
            {
                Strength = (Int16)Dice.Cast(3, 6);
                Dexterity = (Int16)Dice.Cast(3, 6);
                Intelligence = (Int16)Dice.Cast(3, 6);
                Constitution = (Int16)Dice.Cast(3, 6);
                Appearance = (Int16)Dice.Cast(3, 6);
                Power = (Int16)Dice.Cast(3, 6);
                Size = (Int16)Dice.Cast(2, 6, 6);
                Education = (Int16)Dice.Cast(3, 6, 3);
            }
            public FundamentalStatus(
                Int16 strength,
                Int16 dexterity,
                Int16 intelligence,
                Int16 constitution,
                Int16 appearance,
                Int16 power,
                Int16 size,
                Int16 education)
            {
                Strength = strength;
                Dexterity = dexterity;
                Intelligence = intelligence;
                Constitution = constitution;
                Appearance = appearance;
                Power = power;
                Size = size;
                Education = education;
            }
        }
        /// <summary>
        /// 【筋力】【敏捷】【知能】【健康】【魅力】【精神力】【体格】【教養】
        /// </summary>
        protected FundamentalStatus _fundamental;

        protected internal class AdvancedStatus
        {
            private Int16 _idea;
            private Int16 _luck;
            private Int16 _knowledge;
            private Dice _damageBonus;
            private Int16 _maxHitPoint;
            private Int16 _hitPoint;
            private Int16 _maxMagicPoint;
            private Int16 _magicPoint;
            private Int16 _maxSanityPoint;
            private Int16 _sanityPoint;
            public Int16 Idea { get; set; }
            public Int16 Luck { get; set; }
            public Int16 Knowledge { get; set; }
            public Dice DamageBonus { get; set; }
            public Int16 MaxHitPoint { get; set; }
            public Int16 HitPoint { get; set; }
            public Int16 MaxMagicPoint { get; set; }
            public Int16 MagicPoint { get; set; }
            public Int16 MaxSanityPoint { get; set; }
            public Int16 SanityPoint
            {
                get { return _sanityPoint; }
                set { _sanityPoint = value; }
            }

            public AdvancedStatus() : this(new FundamentalStatus())
            {

            }
            public AdvancedStatus(FundamentalStatus fund)
            {
                _idea = (Int16)(5 * fund.Intelligence);
                _luck = (Int16)(5 * fund.Appearance);
                _knowledge = (Int16)(5 * fund.Education);
                //Damage Bonusの算出
                CalculateDamageBonus(fund);

                _hitPoint = _maxHitPoint = (Int16)(Math.Ceiling((Double)(fund.Constitution + fund.Size) * 0.5));
                _magicPoint = _maxMagicPoint = fund.Power;
                _maxSanityPoint = 99;
                _sanityPoint = (Int16)(5 * fund.Power);
            }

            private void CalculateDamageBonus(FundamentalStatus fund)
            {
                var strsiz = fund.Strength + fund.Size;
                if (strsiz >= 2 && strsiz <= 12)
                    _damageBonus = new Dice(-1, 6);
                else if (strsiz > 12 && strsiz <= 16)
                    _damageBonus = new Dice(-1, 4);
                else if (strsiz > 16 && strsiz <= 24)
                    _damageBonus = new Dice();
                else if (strsiz > 24 && strsiz <= 32)
                    _damageBonus = new Dice(1, 4);
                else if (strsiz > 32)
                {
                    {
                        var level = (strsiz - 33) / 8;
                        // (0), (1,2), (3,4,5), (6,7,8,9), (10,11,12,13,14).........
                        for (int i = 1, add = 0; true; i++)
                        {
                            if (level >= add && level < add + i)
                            {
                                _damageBonus = new Dice(i, 6);
                                break;
                            }
                            add += i;
                        }
                    }
                }
                else
                {
                    {
                        var level = (-strsiz + 2) / 8;
                        // (0), (1,2), (3,4,5), (6,7,8,9), (10,11,12,13,14).........
                        for (int i = 1, add = 0; true; i++)
                        {
                            if (level >= add && level < add + i)
                            {
                                _damageBonus = new Dice(-i - 1, 6);
                                break;
                            }
                            add += i;
                        }
                    }
                }
            }
            public AdvancedStatus(
                Int16 idea,
                Int16 luck,
                Int16 knowledge,
                Dice damageBonus,
                Int16 maxHitPoint,
                Int16 hitPoint,
                Int16 maxMagicPoint,
                Int16 magicPoint,
                Int16 maxSanityPoint,
                Int16 sanityPoint)
            {
                _idea = idea;
                _luck = luck;
                _knowledge = knowledge;
                _damageBonus = damageBonus;
                _maxHitPoint = maxHitPoint;
                _hitPoint = hitPoint;
                _maxMagicPoint = maxMagicPoint;
                _magicPoint = magicPoint;
                _maxSanityPoint = maxSanityPoint;
                _sanityPoint = sanityPoint;
            }
        }
        /// <summary>
        /// 【アイデア】【幸運】【知識】【ダメージボーナス】【耐久値上限】【耐久値】【MP上限】【MP】【SAN値上限】【SAN値】
        /// </summary>
        protected internal AdvancedStatus _advanced;

        /// <summary>
        /// 無性、単性、男性、女性、第三性、トランスジェンダー（生まれつきの体は男性）、トランスジェンダー（生まれつきの体は女性）、男性仮性半陰陽、女性仮性半陰陽
        /// </summary>
        public enum Sex : byte { NoSex = 0, UniSex = 1, Male = 2, Female = 3, ThirdSex = 4, TransGenderBodyMale = 5, TransGenderBodyFemale = 6, MalePseudohermaphroditism = 7, FemalePseudohermaphroditism = 8 }
        private Sex _sexuality;
        /// <summary>
        /// 【性別】
        /// </summary>
        public Sex Sexuality
        {
            get { return _sexuality; }
            set { _sexuality = value; }
        }

        private Int64 _age;
        /// <summary>
        /// 年齢
        /// </summary>
        public Int64 Age
        {
            get { return _age; }
            set { _age = value; }
        }

        private String _occupation;
        /// <summary>
        /// 職業
        /// </summary>
        public String Occupation
        {
            get { return _occupation; }
            set { _occupation = value; }
        }

        private String _school;
        /// <summary>
        /// 出身校、あるいは在籍校
        /// </summary>
        public String School
        {
            get { return _school; }
            set { _school = value; }
        }

        private String _birthPlace;
        /// <summary>
        /// 出身地
        /// </summary>
        public String BirthPlace
        {
            get { return _birthPlace; }
            set { _birthPlace = value; }
        }

        public Int16 Strength { get { return _fundamental.Strength; } set { _fundamental.Strength = value; } }
        public Int16 Dexterity { get { return _fundamental.Dexterity; } set { _fundamental.Dexterity = value; } }
        public Int16 Intelligence { get { return _fundamental.Intelligence; } set { _fundamental.Intelligence = value; } }
        public Int16 Constitution { get { return _fundamental.Constitution; } set { _fundamental.Constitution = value; } }
        public Int16 Appearance { get { return _fundamental.Appearance; } set { _fundamental.Appearance = value; } }
        public Int16 Power { get { return _fundamental.Power; } set { _fundamental.Power = value; } }
        public Int16 Size { get { return _fundamental.Size; } set { _fundamental.Size = value; } }
        public Int16 Education { get { return _fundamental.Education; } set { _fundamental.Education = value; } }
        public Int16 Idea { get { return _advanced.Idea; } set { _advanced.Idea = value; } }
        public Int16 Luck { get { return _advanced.Luck; } set { _advanced.Luck = value; } }
        public Int16 Knowledge { get { return _advanced.Knowledge; } set { _advanced.Knowledge = value; } }
        public Dice DamageBonus { get { return _advanced.DamageBonus; } set { _advanced.DamageBonus = value; } }
        public Int16 MaxHitPoint { get { return _advanced.MaxHitPoint; } set { _advanced.MaxHitPoint = value; } }
        public Int16 HitPoint { get { return _advanced.HitPoint; } set { _advanced.HitPoint = value; } }
        public Int16 MaxMagicPoint { get { return _advanced.MaxMagicPoint; } set { _advanced.MaxMagicPoint = value; } }
        public Int16 MagicPoint { get { return _advanced.MagicPoint; } set { _advanced.MagicPoint = value; } }
        public Int16 MaxSanityPoint { get { return _advanced.MaxSanityPoint; } set { _advanced.MaxSanityPoint = value; } }
        public Int16 SanityPoint { get { return _advanced.SanityPoint; } set { _advanced.SanityPoint = value; } }
    }
}