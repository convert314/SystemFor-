using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoC;

namespace CoC.ChainSystem
{
    public class HomoSapiens : BasicStatus, IHomoSapiens, IGameObject, IObservable<News>
    {
        private String _name;

        public String Id
        {
            get { return _name; }
            set { _name = value; }
        }

        public HomoSapiens()
            : base()
        {
            _name = String.Empty;
        }
        public HomoSapiens(String name, Int16 strength, Int16 dexterity, Int16 intelligence, Int16 constitution, Int16 appearance, Int16 power, Int16 size, Int16 education,
            Int16 idea, Int16 luck, Int16 knowledge, Dice damageBonus,
            Int16 maxHitPoint, Int16 hitPoint, Int16 maxMagicPoint, Int16 magicPoint, Int16 maxSanityPoint, Int16 sanityPoint,
            Sex sexuality, Int64 age, String occupation, String school, String birthPlace)
            : base(strength, dexterity, intelligence, constitution, appearance, power, size, education,
            idea, luck, knowledge, damageBonus,
            maxHitPoint, hitPoint, maxMagicPoint, magicPoint, maxSanityPoint, sanityPoint,
            sexuality, age, occupation, school, birthPlace)
        {
            _name = name;
        }

        private Dictionary<String, Int16> _dict1 = new Dictionary<String, Int16>();
        private Dictionary<String, String> _dict2 = new Dictionary<String, String>();
        private void RegisterDictionary()
        {
            #region dict1
            _dict1["Strength"] = Strength;
            _dict1["STR"] = Strength;
            _dict1["Dexterity"] = Dexterity;
            _dict1["DEX"] = Dexterity;
            _dict1["Intelligence"] = Intelligence;
            _dict1["INT"] = Intelligence;
            _dict1["Constitution"] = Constitution;
            _dict1["CON"] = Constitution;
            _dict1["Appearance"] = Appearance;
            _dict1["APP"] = Appearance;
            _dict1["Power"] = Power;
            _dict1["POW"] = Power;
            _dict1["Size"] = Size;
            _dict1["SIZ"] = Size;
            _dict1["Education"] = Education;
            _dict1["EDU"] = Education;
            _dict1["Idea"] = Idea;
            _dict1["IDEA"] = Idea;
            _dict1["Luck"] = Luck;
            _dict1["LUCK"] = Luck;
            _dict1["Knowledge"] = Knowledge;
            _dict1["KNOWLEDGE"] = Knowledge;
            _dict1["MaxHitPoint"] = MaxHitPoint;
            _dict1["Max Hit Point"] = MaxHitPoint;
            _dict1["MaxHP"] = MaxHitPoint;
            _dict1["MaxmagicPoint"] = MaxMagicPoint;
            _dict1["Max Magic Point"] = MaxMagicPoint;
            _dict1["MaxMP"] = MaxMagicPoint;
            _dict1["MaxSanityPoint"] = MaxSanityPoint;
            _dict1["Max Sanity Point"] = MaxSanityPoint;
            _dict1["MaxSP"] = MaxSanityPoint;
            _dict1["HitPoint"] = HitPoint;
            _dict1["Hit Point"] = HitPoint;
            _dict1["HP"] = HitPoint;
            _dict1["MagicPoint"] = MagicPoint;
            _dict1["Magic Point"] = MagicPoint;
            _dict1["MP"] = MagicPoint;
            _dict1["SanityPoint"] = SanityPoint;
            _dict1["Sanity Point"] = SanityPoint;
            _dict1["SP"] = SanityPoint;
#endregion
            #region dict2
            _dict2["Damage Bonus"] = DamageBonus.ToString();
            _dict2["DamageBonus"] = _dict2["Damage Bonus"];
            _dict2["DB"] = _dict2["Damage Bonus"];
            _dict2["SEX"] = Sexuality.ToString();
            _dict2["Sexuality"] = _dict2["SEX"];
            _dict2["SEXUALITY"] = _dict2["SEX"];
            _dict2["Sex"] = _dict2["SEX"];
            _dict2["OCCUPATION"] = Occupation;
            _dict2["Occupation"] = Occupation;
            _dict2["SCHOOL"] = School;
            _dict2["School"] = School;
            _dict2["BIRTHPLACE"] = BirthPlace;
            _dict2["BirthPlace"] = BirthPlace;
            _dict2["Birth Place"] = BirthPlace;
            #endregion
        }

        public string GetName(long securityClearance)
        {
            return _name;
        }
        public string GetDescritption(long securityClearance)
        {
            return String.Empty;
        }
        public bool HasAttribute(string name, long securityClearance)
        {
            return (!String.IsNullOrEmpty(name)) && (name.ToLower() == "age" || _dict1.ContainsKey(name) || _dict2.ContainsKey(name));
        }
        public Object GetAttribute(String name, Int64 securityClearance)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentException();
            if (_dict2.ContainsKey(name)) return _dict2[name];
            else if (_dict1.ContainsKey(name)) return _dict1[name];
            else if (name.ToLower() == "age") return Age;
            throw new ArgumentException();
        }
        public IDisposable Subscribe(IObserver<News> observer)
        {
            throw new NotImplementedException();
        }
    }
}
