using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoC
{
    public interface IEffectable : IObservable<News>
    {
        /// <summary>
        /// 所有者のIGameObjectです。
        /// 全てのIEffectableには効果の所有者があるべきです。
        /// </summary>
        IGameObject Owner { get; }
        /// <summary>
        /// Newsを受け取って実行可能かどうか判断します。
        /// </summary>
        /// <param name="news">Coc.News型の情報です。この情報のみに基づいて実行可能かどうか判断します。</param>
        /// <returns>実行可能かどうかを表すSystem.Boolean型</returns>
        Boolean IsExecutable(News news);
        /// <summary>
        /// Newsをもとに対象のIGameObjectに操作を施します。
        /// </summary>
        /// <param name="news">Coc.News型の情報です。操作するための大事な情報です。</param>
        /// <param name="obj">操作対象のCoC.IGameObjectです。</param>
        void Execute(News news, IGameObject obj);
        /// <summary>
        /// 効果によっては複数のIEffectableから構成されています。
        /// その複数のIEffectableの配列を表すプロパティです。
        /// </summary>
        IEffectable[] PartialEffectables { get; }
        /// <summary>
        /// PartialIEffectablesの内実行可能なものがあるかどうか調べます。
        /// 実行可能なIEffectableが存在する場合、そのインデックスを返します。
        /// </summary>
        /// <param name="news"></param>
        /// <param name="index">
        /// out Int64[]
        /// 実行可能なインデックスの配列です。
        /// 存在しない場合要素数0の配列を返します。
        /// </param>
        /// <returns>実行可能なIEffectableが存在するかどうかを表すSystem.Boolean値</returns>
        Boolean IsPartialExecutable(News news, out Int64[] index);
    }
}
