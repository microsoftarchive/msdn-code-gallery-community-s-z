using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using SampleClassLibrary.SystemFakes;
using Net.Surviveplus.UnitTestPlus;

namespace SampleUnitTest.SystemFakes
{
    [TestClass]
    public class DateTimeUserTest
    {

        [TestMethod()]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void Execute_正常系_引数がaでNowプロパティが2015年1月2日の時にTrueを返すこと()
        {

            var target = new DateTimeUser();

            // プロパティ
            var props = new
            {
                Now = new System.DateTime(2015, 1, 2),
            };
            ReportingConsole.WriteProperties(props);
            target.Now = props.Now;

            // メソッド引数・結果期待値（戻り値）
            var args = new
            {
                userName = "a",
            };
            var expected = true;
            ReportingConsole.WriteArgsAndExpected(args, expected);

            // 実行と結果
            var actual = target.Execute(args.userName);
            ReportingConsole.WriteActual(actual);

            Assert.AreEqual<bool>(expected, actual);

        } // end function

        [TestMethod()]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void Execute_異常系_引数がaでNowプロパティが2014年12月31日の時にFalseを返すこと()
        {

            var target = new DateTimeUser();

            // プロパティ
            var props = new
            {
                Now = new System.DateTime(2014, 12, 31),
            };
            ReportingConsole.WriteProperties(props);
            target.Now = props.Now;

            // メソッド引数・結果期待値（戻り値）
            var args = new
            {
                userName = "a",
            };
            var expected = false;
            ReportingConsole.WriteArgsAndExpected(args, expected);

            // 実行と結果
            var actual = target.Execute(args.userName);
            ReportingConsole.WriteActual(actual);

            Assert.AreEqual<bool>(expected, actual);

        } // end function

    } // end class
} // end namespace
