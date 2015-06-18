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

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public HomoSapiens()
            : base()
        {
            _name = String.Empty;
        }
        public HomoSapiens(String NAME, Int16 STR, Int16 DEX, Int16 INT, Int16 CON, Int16 APP, Int16 POW, Int16 SIZ, Int16 EDU,
            Int16 IDEA, Int16 LUCK, Int16 KNOWLEDGE, Dice DB,
            Int16 MaxHP, Int16 HP, Int16 MaxMP, Int16 MP, Int16 MaxSAN, Int16 SAN,
            Sex SEX, Int64 AGE, String OCCUPATION, String SCHOOL, String BIRTHPLACE)
            : base(STR, DEX, INT, CON, APP, POW, SIZ, EDU,
            IDEA, LUCK, KNOWLEDGE, DB,
            MaxHP, HP, MaxMP, MP, MaxSAN, SAN,
            SEX, AGE, OCCUPATION, SCHOOL, BIRTHPLACE)
        {
            _name = NAME;
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

        string IGameObject.GetName(long securityClearance)
        {
            return _name;
        }

        string IGameObject.GetDescritption(long securityClearance)
        {
            return String.Empty;
        }

        bool IGameObject.HasAttribute(string name, long securityClearance)
        {
            throw new NotImplementedException();
        }

        Object IGameObject.GetAttribute(String name, Int64 securityClearance)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentException();
            if (_dict2.ContainsKey(name)) return _dict2[name];
            else if (_dict1.ContainsKey(name)) return _dict1[name];
            else if (name.ToLower() == "age") return Age;
            throw new ArgumentException();
        }

        IDisposable IObservable<News>.Subscribe(IObserver<News> observer)
        {
            throw new NotImplementedException();
        }
    }
}
