using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClassLibrary.Simple
{
    /// <summary>
    /// 単体テストの対象となる「何かを実行するクラス」です。静的メソッドのみを取り扱います。
    /// </summary>
    public static class StaticSomethingExecutor
    {
        /// <summary>
        /// 静的なメソッドで、引数を全て足して返します。ただし、引数が first=10, second=100, third=1000 を超える場合は例外になります。
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="third"></param>
        /// <returns></returns>
        public static int PlusArguments(int first, int second, int third)
        {
            if (first > 10) throw new ArgumentOutOfRangeException("first", "first に 10 より大きい値が指定されました。10 以下の値を指定してください。");
            if (second > 100) throw new ArgumentOutOfRangeException("first", "second に 100 より大きい値が指定されました。100 以下の値を指定してください。");
            if (third > 1000) throw new ArgumentOutOfRangeException("first", "third に 1000 より大きい値が指定されました。1000 以下の値を指定してください。");

            return first + second + third;
        } // end function

        /// <summary>
        /// 静的なメソッドで、引数が自然数（0を含む正の整数）かどうか？を返します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns>自然数の時は True を返します。それ以外は False を返します。</returns>
        public static bool IsNaturalNumber(int value)
        {
            return (value >= 0);
        } // end function

    } // end class
} // end namespace
