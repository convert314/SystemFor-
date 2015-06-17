using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSystem
{
    /// <summary>
    /// ＴＲＰＧにおけるダイス判定を扱うクラス
    /// </summary>
    public sealed class Dice : Tuple<Dictionary<Byte, Int64>, Int64>, System.Collections.IStructuralEquatable, System.Collections.IStructuralComparable, IComparable
    {
        /// <summary>
        /// 固定値
        /// </summary>
        public Int64 Constant
        {
            get { return Item2; }
        }
        /// <summary>
        /// !xDyにおけるxの配列
        /// </summary>
        public Int64[] Counts
        {
            get { return Item1.Values.ToArray(); }
        }
        /// <summary>
        /// !xDyにおけるyの配列　（yは１以上１００以下であるべき）
        /// </summary>
        public Byte[] Ranges
        {
            get { return Item1.Keys.ToArray(); }
        }

        /// <summary>
        /// 指定された面数がゲームにおいて使用されるダイスの面数の範囲内にあるかどうか判定する
        /// </summary>
        /// <param name="range">面数</param>
        /// <returns>許容範囲内にあるかどうか</returns>
        private static Boolean IsValidRange(Byte range)
        {
            return range > 0 && range <= 100;
        }
        private static Boolean IsValidRange(IEnumerable<Byte> ranges)
        {
            return ranges.All(range => range > 0 && range <= 100);
        }

        #region Constructor
        public Dice() : base(new Dictionary<Byte, Int64>(), 0) { }
        public Dice(Int64[] counts, Byte[] ranges, Int64 constant)
            : base(ranges.Zip(counts, (range, count) => new Tuple<Byte, Int64>(range, count)).ToDictionary(t => t.Item1, t => t.Item2), constant)
        {
            if (counts == null || ranges == null) throw new ArgumentNullException();
            if (!IsValidRange(ranges)) throw new ArgumentException();
        }
        public Dice(Int64[] counts, Byte[] ranges) : this(counts, ranges, 0) { }
        public Dice(IEnumerable<Int64> counts, IEnumerable<Byte> ranges) : this(counts, ranges, 0) { }
        public Dice(IEnumerable<Int64> counts, IEnumerable<Byte> ranges, Int64 constant) : this(counts.ToArray(), ranges.ToArray(), constant) { }
        public Dice(Int64 count, Byte range, Int64 constant) : this(new Int64[1] { count }, new Byte[1] { range }, constant) { }
        public Dice(Int64 count, Byte range) : this(count, range, 0) { }
        public Dice(Int64 constant) : base(new Dictionary<Byte, Int64>(), constant) { }
        public Dice(IDictionary<Int64, Byte> countRangeDictionary, Int64 constant)
            : base(countRangeDictionary.ToDictionary(keyval => keyval.Value, keyval => keyval.Key), constant)
        {
            if (countRangeDictionary == null) throw new ArgumentNullException();
            if (!IsValidRange(countRangeDictionary.Values)) throw new ArgumentException();
        }
        public Dice(IDictionary<Int64, Byte> countRangeDictionary) : this(countRangeDictionary, 0) { }
        public Dice(IDictionary<Byte, Int64> rangeCountDictionary, Int64 constant)
            : base(rangeCountDictionary as Dictionary<Byte, Int64>, constant)
        {
            if (Item1 == null) throw new ArgumentNullException();
            if (!IsValidRange(Item1.Keys)) throw new ArgumentException();
        }
        public Dice(IDictionary<Byte, Int64> rangeCountDictionary)
            : base(rangeCountDictionary as Dictionary<Byte, Int64>, 0)
        {
            if (Item1 == null) throw new ArgumentNullException();
            if (!IsValidRange(Item1.Keys)) throw new ArgumentException();
        }
        #endregion

        /// <summary>
        /// ダイスを振る
        /// 実行するたびに値が変化する
        /// </summary>
        /// <returns>ダイスの値の合計に固定値を加えたもの</returns>
        public Int64 Cast(Random random)
        {
            Int64 answer = 0;
            foreach (var t in Item1)
                for (Int64 i = 0; i < t.Value; i++)
                    answer += random.Next(t.Key) + 1;
            return answer + Item2;
        }
        public Int64 Cast()
        {
            return Cast(new Random());
        }

        /// <summary>
        /// 1d100ダイス
        /// </summary>
        public static readonly Dice D1D100 = new Dice(1, 100);
        /// <summary>
        /// 1d10ダイス
        /// </summary>
        public static readonly Dice D1D10 = new Dice(1, 10);
        /// <summary>
        /// 3d6ダイス
        /// </summary>
        public static readonly Dice D3D6 = new Dice(3, 6);

        /// <summary>
        /// Keyである面数が一致したKey Value Pair同士をValueを足して統合する
        /// Valueが0となった場合そのKey Value Pairは戻り値のDictionaryには含まれない
        /// 参照透過的である
        /// </summary>
        /// <param name="obj0">1つめのDictionary</param>
        /// <param name="obj1">2つめのDictionary</param>
        /// <returns>Mergeされて新たに作られたDictionary</returns>
        private static Dictionary<Byte, Int64> MergeDictionary(Dictionary<Byte, Int64> obj0, Dictionary<Byte, Int64> obj1)
        {
            var answer = new Dictionary<Byte, Int64>(obj0);
            foreach (var keyval in obj1)
            {
                if (answer.ContainsKey(keyval.Key))
                {
                    if (answer[keyval.Key] + keyval.Value == 0)
                        answer.Remove(keyval.Key);
                    answer[keyval.Key] += keyval.Value;
                }
                else
                {
                    answer.Add(keyval.Key, keyval.Value);
                }
            }
            return answer;
        }

        #region Operator
        public static Dice operator +(Dice obj0, Dice obj1)
        {
            return new Dice(MergeDictionary(obj0.Item1, obj1.Item1), obj0.Constant + obj1.Constant);
        }
        public static Dice operator +(Dice obj, Int64 constant)
        {
            return new Dice(obj.Item1, obj.Constant + constant);
        }
        public static Dice operator +(Int64 constant, Dice obj)
        {
            return new Dice(obj.Item1, constant + obj.Constant);
        }
        public static Dice operator -(Dice obj)
        {
            return new Dice(obj.Counts.Select(count => -count), obj.Ranges, -obj.Constant);
        }
        public static Dice operator -(Dice obj0, Dice obj1)
        {
            return new Dice(MergeDictionary(obj0.Item1, obj1.Item1.ToDictionary(keyval => keyval.Key, keyval => -(keyval.Value))), obj0.Constant - obj1.Constant);
        }
        public static Dice operator -(Dice obj, Int64 constant)
        {
            return new Dice(obj.Item1, obj.Constant - constant);
        }
        public static Dice operator -(Int64 constant, Dice obj)
        {
            return (-obj) + constant;
        }
        public static Dice operator *(Dice obj, Int64 count)
        {
            switch (count)
            {
                case 0: return new Dice();
                case 1: return obj;
                case -1: return -obj;
                default: return new Dice(obj.Item1.ToDictionary(keyval => keyval.Key, keyval => keyval.Value * count), obj.Constant * count);
            }
        }
        public static Dice operator *(Int64 count, Dice obj)
        {
            return obj * count;
        }
        public static Boolean operator ==(Dice obj0, Dice obj1)
        {
            return obj0.Equals(obj1);
        }
        public static Boolean operator !=(Dice obj0, Dice obj1)
        {
            return !obj0.Equals(obj1);
        }
        public static explicit operator Dice(Int64 constant)
        {
            return new Dice(constant);
        }
        public static explicit operator Dice(Int32 constant)
        {
            return new Dice(constant);
        }
        public static explicit operator Dice(Int16 constant)
        {
            return new Dice(constant);
        }
        public static explicit operator Dice(Byte constant)
        {
            return new Dice(constant);
        }
        #endregion
        #region Override
        public override string ToString()
        {
            var answer = new StringBuilder();
            var constant = Math.Abs(Constant);
            switch (Item1.Count)
            {
                case 1:
                    {
                        var keyval = Item1.First();
                        if (keyval.Value >= 0)
                        {
                            for (Int64 i = 0; i < keyval.Value / 10; i++)
                            {
                                if (i == 0) answer.Append("!10d").Append(keyval.Key);
                                answer.Append("+!10d").Append(keyval.Key);
                            }
                            if (keyval.Value % 10 != 0)
                            {
                                answer.Append("+!").Append(keyval.Value % 10).Append('d').Append(keyval.Key);
                            }
                        }
                        else
                        {
                            var val = Math.Abs(keyval.Value);
                            for (Int64 i = 0; i < val / 10; i++)
                            {
                                answer.Append("-!10d").Append(keyval.Key);
                            }
                            if (val % 10 != 0)
                            {
                                answer.Append("-!").Append(val % 10).Append('d').Append(keyval.Key);
                            }
                        }
                    }
                    break;
                case 0:
                    break;
                default:
                    foreach (var keyval in Item1)
                    {
                        var val = Math.Abs(keyval.Value);
                        if (keyval.Value >= 0)
                        {
                            for (Int64 i = 0; i < val / 10; i++) {
                                answer.Append("+!10d").Append(keyval.Key);
                            }
                            if (val % 10 != 0) {
                                answer.Append("+!").Append(val % 10).Append('d').Append(keyval.Key);
                            }
                        }
                        else 
                        {
                            for (Int64 i = 0; i < val / 10; i++)
                            {
                                answer.Append("-!10d").Append(keyval.Key);
                            }
                            if (val % 10 != 0)
                            {
                                answer.Append("-!").Append(val % 10).Append('d').Append(keyval.Key);
                            }
                        }
                    }
                    break;
            }
            switch (Math.Sign(Constant))
            {
                case 1:
                    answer.Append('+').Append(Constant);
                    break;
                case -1:
                    answer.Append(Constant);
                    break;
            }
            return answer.ToString();
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Dice);
        }
        public Boolean Equals(Dice obj)
        {
            return obj != null && this.Item1.SequenceEqual(obj.Item1) && this.Item2 == obj.Item2;
        }
        #endregion
    }
}
