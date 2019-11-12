using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Net.Surviveplus.UnitTestPlus;
using SampleClassLibrary.Simple;

namespace SampleUnitTest.Simple
{
    [TestClass]
    public class SomethingExecutorTest
    {

        [TestMethod()]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void PlusBaseAndArguments_正常系＿実行回数が100でベース値が1かつ引数が1と2の時に4が返りかつ実行回数が101になること()
        {

            // コンストラクタ引数
            var constructor = new
            {
                executedCount = 100
            };

            ReportingConsole.WriteConstructorArgs(constructor);
            var target = new SomethingExecutor(constructor.executedCount);

            // プロパティ
            var props = new
            {
                BaseValue = 1,
            };
            ReportingConsole.WriteProperties(props);
            target.BaseValue = props.BaseValue;

            // メソッド引数・結果期待値（戻り値、プロパティ）
            var args = new
            {
                first = 1,
                second = 2,
            };
            var expected = new
            {
                returnValue = 4,
                ExecutedCount = 101
            };
            ReportingConsole.WriteArgsAndExpected(args, expected);

            // 実行と確認
            var actual = new
            {
                returnValue = target.PlusBaseAndArguments(args.first, args.second),
                ExecutedCount = target.ExecutedCount
            };
            ReportingConsole.WriteActual(actual);

            Assert.AreEqual<int>(expected.returnValue, actual.returnValue);
            Assert.AreEqual<int>(expected.ExecutedCount, actual.ExecutedCount);


        } // end function


    } // end class
} // end namespace
