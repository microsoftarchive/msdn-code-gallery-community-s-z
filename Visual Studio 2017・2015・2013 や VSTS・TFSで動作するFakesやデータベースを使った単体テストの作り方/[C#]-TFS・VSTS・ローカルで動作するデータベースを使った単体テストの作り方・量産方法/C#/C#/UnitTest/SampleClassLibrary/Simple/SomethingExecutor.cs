using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClassLibrary.Simple
{
    /// <summary>
    /// 単体テストの対象となる「何かを実行するクラス」です。
    /// 処理にプロパティを伴うインスタンスメソッドを取り扱います。
    /// </summary>
    public class SomethingExecutor
    {
        /// <summary>
        /// インスタンスを初期化します。
        /// </summary>
        public SomethingExecutor()
        {
        } // end constructor

        /// <summary>
        /// ExecutedCount プロパティの初期値をしていして、インスタンスを初期化します。
        /// </summary>
        /// <param name="executedCount"></param>
        public SomethingExecutor(int executedCount)
        {
            this.ExecutedCount = executedCount;
        } // end constructor

        /// <summary>
        /// 整数を設定または取得します。
        /// テスト用のメソッドのために事前に設定しておくべきプロパティとして用意しています。
        /// </summary>
        public int BaseValue { get; set; }

        /// <summary>
        /// 実行回数を設定または取得します。
        /// テスト用のメソッド実行後に変化するプロパティとして用意しています。
        /// </summary>
        public int ExecutedCount { get; private set; }

        /// <summary>
        /// BaseValue プロパティと指定された引数を全て足して返します。
        /// ただし、BaseValue プロパティが 0 以下の値の時、例外になります。
        /// また、実行後は ExecutedCount プロパティが 1 加算されます。
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public int PlusBaseAndArguments(int first, int second)
        {
            if (this.BaseValue <= 0) throw new InvalidOperationException("BaseValue プロパティが 0 以下です。PlusBaseAndArguments メソッドを実行する前に、BaseValue プロパティに 0 より大きい値を指定してください。");

            try
            {
                return this.BaseValue + first + second;
            }
            finally
            {
                this.ExecutedCount += 1;
            } // end try

        } // end function

    } // end class
} // end namespace
