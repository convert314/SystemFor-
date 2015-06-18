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
        public BasicStatus() {
            _sexuality = Sex.NoSex;
            _school = String.Empty;
            _occupation = String.Empty;
            _birthPlace = String.Empty;
            _fundamental = new FundamentalStatus();
            _advanced = new AdvancedStatus(_fundamental);
            _age = Dice.Cast(1, (Byte)(80 - _fundamental.Education), _fundamental.Education);
        }
        public BasicStatus(Int16 STR, Int16 DEX, Int16 INT, Int16 CON, Int16 APP, Int16 POW, Int16 SIZ, Int16 EDU,
            Int16 IDEA, Int16 LUCK, Int16 KNOWLEDGE, Dice DB, Int16 MaxHP, Int16 HP, Int16 MaxMP, Int16 MP, Int16 MaxSAN, Int16 SAN,
            Sex SEX, Int64 AGE, String OCCUPATION, String SCHOOL, String BIRTHPLACE) {
            _fundamental = new FundamentalStatus(STR, DEX, INT, CON, APP, POW, SIZ, EDU);
            _advanced = new AdvancedStatus(IDEA, LUCK, KNOWLEDGE, DB, MaxHP, HP, MaxMP, MP, MaxSAN, SAN);
            _sexuality = SEX;
            _age = AGE;
            _occupation = OCCUPATION;
            _school = SCHOOL;
            _birthPlace = BIRTHPLACE;
        }
        public BasicStatus(FundamentalStatus fundamental, AdvancedStatus advanced, Sex SEX, Int64 AGE, String OCCUPATION, String SCHOOL, String BIRTHPLACE) {
            _fundamental = fundamental;
            _advanced = advanced;
            _age = AGE;
            _sexuality = SEX;
            _occupation = OCCUPATION;
            _school = SCHOOL;
            _birthPlace = BIRTHPLACE;
        }


        protected internal class FundamentalStatus
        {
            private Int16 _strength;
            private Int16 _dexterity;
            private Int16 _intelligence;
            private Int16 _constitution;
            private Int16 _appearance;
            private Int16 _power;
            private Int16 _size;
            private Int16 _education;
            public Int16 Strength
            {
                get { return _strength; }
                set { _strength = value; }
            }
            public Int16 Dexterity
            {
                get { return _dexterity; }
                set { _dexterity = value; }
            }
            public Int16 Intelligence
            {
                get { return _intelligence; }
                set { _intelligence = value; }
            }
            public Int16 Constitution
            {
                get { return _constitution; }
                set { _constitution = value; }
            }
            public Int16 Appearance
            {
                get { return _appearance; }
                set { _appearance = value; }
            }
            public Int16 Power
            {
                get { return _power; }
                set { _power = value; }
            }
            public Int16 Size
            {
                get { return _size; }
                set { _size = value; }
            }
            public Int16 Education
            {
                get { return _education; }
                set { _education = value; }
            }

            public FundamentalStatus()
            {
                _strength = (Int16)Dice.Cast(3, 6);
                _dexterity = (Int16)Dice.Cast(3, 6);
                _intelligence = (Int16)Dice.Cast(3, 6);
                _constitution = (Int16)Dice.Cast(3, 6);
                _appearance = (Int16)Dice.Cast(3, 6);
                _power = (Int16)Dice.Cast(3, 6);
                _size = (Int16)Dice.Cast(2, 6, 6);
                _education = (Int16)Dice.Cast(3, 6, 3);
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
                _strength = strength;
                _dexterity = dexterity;
                _intelligence = intelligence;
                _constitution = constitution;
                _appearance = appearance;
                _power = power;
                _size = size;
                _education = education;
            }
        }
        /// <summary>
        /// 【筋力】【敏捷】【知能】【健康】【魅力】【精神力】【体格】【教養】
        /// </summary>
        private FundamentalStatus _fundamental;

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
            public Int16 Idea
            {
                get { return _idea; }
                set { _idea = value; }
            }
            public Int16 Luck
            {
                get { return _luck; }
                set { _luck = value; }
            }
            public Int16 Knowledge
            {
                get { return _knowledge; }
                set { _knowledge = value; }
            }
            public Dice DamageBonus
            {
                get { return _damageBonus; }
                set { _damageBonus = value; }
            }
            public Int16 MaxHitPoint
            {
                get { return _maxHitPoint; }
                set { _maxHitPoint = value; }
            }
            public Int16 HitPoint
            {
                get { return _hitPoint; }
                set { _hitPoint = value; }
            }
            public Int16 MaxMagicPoint
            {
                get { return _maxMagicPoint; }
                set { _maxMagicPoint = value; }
            }
            public Int16 MagicPoint
            {
                get { return _magicPoint; }
                set { _magicPoint = value; }
            }
            public Int16 MaxSanityPoint
            {
                get { return _maxSanityPoint; }
                set { _maxSanityPoint = value; }
            }
            public Int16 SanityPoint
            {
                get { return _sanityPoint; }
                set { _sanityPoint = value; }
            }

            public AdvancedStatus(): this(new FundamentalStatus()) {
            
            }
            public AdvancedStatus(FundamentalStatus fund) {
                _idea = (Int16)(5 * fund.Intelligence);
                _luck = (Int16)(5 * fund.Appearance);
                _knowledge = (Int16)(5 * fund.Education);
                #region Damage Bonusの算出
                var strsiz = fund.Strength + fund.Size;
                if (strsiz >= 2 && strsiz <= 12)
                    _damageBonus = new Dice(-1, 6);
                else if (strsiz > 12 && strsiz <= 16)
                    _damageBonus = new Dice(-1, 4);
                else if (strsiz > 16 && strsiz <= 24)
                    _damageBonus = new Dice();
                else if (strsiz > 24 && strsiz <= 32)
                    _damageBonus = new Dice(1, 4);
                else if(strsiz > 32)
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
#endregion
                _maxHitPoint = (Int16)(Math.Ceiling((Double)(fund.Constitution + fund.Size) * 0.5));
                _hitPoint = _maxHitPoint;
                _maxMagicPoint = fund.Power;
                _magicPoint = _maxMagicPoint;
                _maxSanityPoint = 99;
                _sanityPoint = (Int16)(5 * fund.Power);
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
                Int16 sanityPoint) {
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
        private AdvancedStatus _advanced;

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
        public Dice DamageBonnus { get { return _advanced.DamageBonus; } set { _advanced.DamageBonus = value; } }
        public Int16 MaxHitPoint { get { return _advanced.MaxHitPoint; } set { _advanced.MaxHitPoint = value; } }
        public Int16 HitPoint { get { return _advanced.HitPoint; } set { _advanced.HitPoint = value; } }
        public Int16 MaxMagicPoint { get { return _advanced.MaxMagicPoint; } set { _advanced.MaxMagicPoint = value; } }
        public Int16 MagicPoint { get { return _advanced.MagicPoint; } set { _advanced.MagicPoint = value; } }
        public Int16 MaxSanityPoint { get { return _advanced.MaxSanityPoint; } set { _advanced.MaxSanityPoint = value; } }
        public Int16 SanityPoint { get { return _advanced.SanityPoint; } set { _advanced.SanityPoint = value; } }
    }
}