using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Net.Surviveplus.UnitTestPlus;
using SampleClassLibrary.Simple;

namespace SampleUnitTest.Simple
{
    [TestClass]
    public class StaticSomethingExecutorTest
    {
        #region PlusArguments メソッドテスト　正常系1

        [TestMethod]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void PlusArguments＿正常系＿引数が1と2と3の時に6が返ること()
        {

            var args = new
            {
                first = 1,
                second = 2,
                third = 3,
            };
            var expected = 6;
            ReportingConsole.WriteArgsAndExpected(args, expected);

            var actual = StaticSomethingExecutor.PlusArguments(args.first, args.second, args.third);
            ReportingConsole.WriteActual(actual);

            Assert.AreEqual<int>(expected, actual);

        } // end function

        [TestMethod]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void PlusArguments＿正常系＿引数が2と3と5の時に10が返ること()
        {

            var args = new
            {
                first = 2,
                second = 3,
                third = 5,
            };
            var expected = 10;
            ReportingConsole.WriteArgsAndExpected(args, expected);

            var actual = StaticSomethingExecutor.PlusArguments(args.first, args.second, args.third);
            ReportingConsole.WriteActual(actual);

            Assert.AreEqual<int>(expected, actual);

        } // end function

        [TestMethod]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void PlusArguments＿正常系＿引数が10と100と1000の時に1110が返ること()
        {

            var args = new
            {
                first = 10,
                second = 100,
                third = 1000,
            };
            var expected = 1110;
            ReportingConsole.WriteArgsAndExpected(args, expected);

            var actual = StaticSomethingExecutor.PlusArguments(args.first, args.second, args.third);
            ReportingConsole.WriteActual(actual);

            Assert.AreEqual<int>(expected, actual);

        } // end function



        #endregion

        #region PlusArguments メソッドテスト　異常系1

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void PlusArguments＿異常系＿引数が11と100と1000の時にArgumentOutOfRangeException例外がスローされること()
        {

            var args = new
            {
                first = 11,
                second = 100,
                third = 1000,
            };
            ReportingConsole.WriteArgsWithNoExpected(args, NoExpectedReason.ThrowException);

            var actual = StaticSomethingExecutor.PlusArguments(args.first, args.second, args.third);
            ReportingConsole.WriteNotThrownException(actual);
        } // end function

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void PlusArguments＿異常系＿引数が10と101と1000の時にArgumentOutOfRangeException例外がスローされること()
        {

            var args = new
            {
                first = 10,
                second = 101,
                third = 1000,
            };
            ReportingConsole.WriteArgsWithNoExpected(args, NoExpectedReason.ThrowException);

            var actual = StaticSomethingExecutor.PlusArguments(args.first, args.second, args.third);
            ReportingConsole.WriteNotThrownException(actual);
        } // end function

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void PlusArguments＿異常系＿引数が10と100と1001の時にArgumentOutOfRangeException例外がスローされること()
        {

            var args = new
            {
                first = 10,
                second = 100,
                third = 1001,
            };
            ReportingConsole.WriteArgsWithNoExpected(args, NoExpectedReason.ThrowException);

            var actual = StaticSomethingExecutor.PlusArguments(args.first, args.second, args.third);
            ReportingConsole.WriteNotThrownException(actual);
        } // end function


        #endregion

        #region IsNaturalNumber＿正常系

        [TestMethod]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void IsNaturalNumber＿正常系＿引数が10の時Trueが返ること()
        {

            var args = 10;
            var expected = true;
            ReportingConsole.WriteArgsAndExpected(args, expected);

            var actual = StaticSomethingExecutor.IsNaturalNumber(args);
            ReportingConsole.WriteActual(actual);

            Assert.AreEqual<bool>(expected, actual);
        } // end sub

        #endregion

    } // end class
} // end namespace
