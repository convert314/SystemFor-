using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoC
{
    /// <summary>
    /// 名と説明を持ち、属性を持つゲームオブジェクトが実装するべきインターフェース
    /// </summary>
    public interface IGameObject : IObservable<News>
    {
        /// <summary>
        /// セキュリティクリアランスに応じた名前を名乗るメソッド
        /// </summary>
        /// <param name="securityClearance">セキュリティクリアランス。0で一般公開されている情報レベル。Int64.MaxValueを指定された時、Idと同じ値を返すべきである。</param>
        /// <returns>セキュリティクリアランスによって知ることができる程度の名前</returns>
        String GetName(Int64 securityClearance);
        /// <summary>
        /// プログラム内で参照される本当の名前
        /// </summary>
        String Id { get; }
        /// <summary>
        /// セキュリティクリアランスに応じた説明をするメソッド
        /// </summary>
        /// <param name="securityClearance">セキュリティクリアランス。0で一般公開されている情報レベル。Int64.MaxValueを指定された時、全ての情報を網羅した説明を返すべきである。</param>
        /// <returns>セキュリティクリアランスによって知ることができる程度の説明文</returns>
        String GetDescritption(Int64 securityClearance);
        /// <summary>
        /// 属性がオブジェクトに備わっているかどうかを調べるメソッド
        /// </summary>
        /// <param name="name">属性の名前</param>
        /// <param name="securityClearance">セキュリティクリアランス。Int64.MaxValueを指定された時、嘘偽りなく真実の情報を返す。</param>
        /// <returns>属性が存在するかどうかを表すSystem.Boolean値</returns>
        Boolean HasAttribute(String name, Int64 securityClearance);
        /// <summary>
        /// 属性を返す。存在しない場合nullを返す。
        /// </summary>
        /// <param name="name">属性の名前</param>
        /// <param name="securityClearance">セキュリティクリアランス。Int64.MaxValueを指定された時、嘘偽りなく真実の属性を返す。</param>
        /// <returns>System.Objectにキャストされた属性</returns>
        Object GetAttribute(String name, Int64 securityClearance);
    }
}
