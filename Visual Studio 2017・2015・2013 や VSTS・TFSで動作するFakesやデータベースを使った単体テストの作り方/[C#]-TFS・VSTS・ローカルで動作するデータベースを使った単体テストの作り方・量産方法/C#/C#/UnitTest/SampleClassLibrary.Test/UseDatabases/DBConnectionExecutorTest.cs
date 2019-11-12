using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Surviveplus.UnitTestPlus;
using SampleClassLibrary.UseDatabases;


namespace SampleUnitTest.UseDatabases
{
    /// <summary>
    /// DBConnectionExecutor のテスト クラスです。すべての DBConnectionExecutor 単体テストテストをここに含めます。
    /// </summary>
    /// <remarks>Team Foundation Server, Visual Studio Online の自動ビルド・自動テストに登録するため、クラス名は必ず Test で終わる必要があります。</remarks>
    [TestClass]
    public partial class DBConnectionExecutorTest
    {
        /// <summary>
        /// 現在のテストの実行についての情報および機能を提供するテスト コンテキストを取得または設定します。
        /// </summary>
        public TestContext TestContext { get; set; }

        #region 追加のテスト属性

        /// <summary>
        ///  テストを作成するときに、次の追加属性を使用することができます:
        ///  クラスの最初のテストを実行する前にコードを実行するには、ClassInitialize を使用
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            ReportingConsole.Culture = new System.Globalization.CultureInfo("ja-JP");
        } // end function

        /// <summary>
        /// クラスのすべてのテストを実行した後にコードを実行するには、ClassCleanup を使用
        /// </summary>
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
        } // end function

        /// <summary>
        /// 各テストを実行する前にコードを実行するには、TestInitialize を使用
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            // テスト実行 前 毎に TestContext の内容をコンソールに出力するには、下記のコメントアウトを解除します。
            //ReportingConsole.WriteTestContext( this.TestContext );
        } // end function

        /// <summary>
        /// 各テストを実行した後にコードを実行するには、TestCleanup を使用
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            // テスト実行 後 毎に TestContext の内容をコンソールに出力するには、下記のコメントアウトを解除します。
            //ReportingConsole.WriteTestContext( this.TestContext );
        } // end function

        #endregion


        [TestMethod()]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void Execute_正常系_初期データに登録されていないテキストをアップデート出来ること()
        {

            // テスト用DBファイルを使用します。
            using (var db = new UnitTestDatabases(this))
            {
                db.AttachFiles();

                var target = new DBConnectionExecutor();

                // プロパティ
                var props = new
                {
                    Environment = new DBConnectionExecutorEnvironment()
                    {
                        EntityConnectionString = db.CreateAttachedEntityConnectionString("UnitTestSampleModel", "UnitTestSample")
                    }
                };
                ReportingConsole.WriteProperties(props);
                target.Environment = props.Environment;

                // メソッド引数
                var args = "Sample";
                ReportingConsole.WriteArgsWithNoExpected(args, NoExpectedReason.Void);

                // 実行と確認
                target.Execute(args);

            } // end using(db)
        } // end function

        [TestMethod()]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void Count_正常系_初期データ3件登録されていてExecuteでデータを1件登録した後にCountで4が取得出来ること()
        {

            // テスト用DBファイルを使用します。
            using (var db = new UnitTestDatabases(this))
            {
                db.AttachFiles();

                var target = new DBConnectionExecutor();

                // プロパティ
                var props = new
                {
                    Environment = new DBConnectionExecutorEnvironment()
                    {
                        EntityConnectionString = db.CreateAttachedEntityConnectionString("UnitTestSampleModel", "UnitTestSample"),
                        CommandConnectionString = db.CreateAttachedConnectionString("UnitTestSample"),
                    }
                };
                ReportingConsole.WriteProperties(props);
                target.Environment = props.Environment;

                // メソッド引数
                var args = "Sample";
                var expected = new
                {
                    Count = 4
                };
                ReportingConsole.WriteArgsAndExpected(args, expected);

                // 実行と確認
                target.Execute(args);
                var actual = target.Count();

                Assert.AreEqual(expected.Count, actual);

            } // end using(db)

        } // end function


        [TestMethod()]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void Count_正常系_BACPACで初期データ3件登録されていてExecuteでデータを1件登録した後にCountで4が取得出来ること()
        {

            // テスト用DBファイルを使用します。
            using (var db = new UnitTestDatabases(this, "BACPAC"))
            {
                db.AttachFiles();

                var target = new DBConnectionExecutor();

                // プロパティ
                var props = new
                {
                    Environment = new DBConnectionExecutorEnvironment()
                    {
                        EntityConnectionString = db.CreateAttachedEntityConnectionString("UnitTestSampleModel", "UnitTestSample"),
                        CommandConnectionString = db.CreateAttachedConnectionString("UnitTestSample"),
                    }
                };
                ReportingConsole.WriteProperties(props);
                target.Environment = props.Environment;

                // メソッド引数
                var args = "Sample";
                var expected = new
                {
                    Count = 4
                };
                ReportingConsole.WriteArgsAndExpected(args, expected);

                // 実行と確認
                target.Execute(args);
                var actual = target.Count();

                Assert.AreEqual(expected.Count, actual);

            } // end using(db)

        } // end function

        [TestMethod()]
        #region コード分析（命名規則）抑制
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly"),
          SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores"),
          SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        #endregion
        public void Count_正常系_DACPACで初期データが登録されていないときExecuteでデータを1件登録した後にCountで1が取得出来ること()
        {

            // DACPAC にはスキーマしか含まれない（データが含まれない）ので、1件挿入後の Count は 1になります。

            // テスト用DBファイルを使用します。
            using (var db = new UnitTestDatabases(this, "DACPAC"))
            {
                db.AttachFiles();

                var target = new DBConnectionExecutor();

                // プロパティ
                var props = new
                {
                    Environment = new DBConnectionExecutorEnvironment()
                    {
                        EntityConnectionString = db.CreateAttachedEntityConnectionString("UnitTestSampleModel", "UnitTestSample"),
                        CommandConnectionString = db.CreateAttachedConnectionString("UnitTestSample"),
                    }
                };
                ReportingConsole.WriteProperties(props);
                target.Environment = props.Environment;

                // メソッド引数
                var args = "Sample";
                var expected = new
                {
                    Count = 1
                };
                ReportingConsole.WriteArgsAndExpected(args, expected);

                // 実行と確認
                target.Execute(args);
                var actual = target.Count();

                Assert.AreEqual(expected.Count, actual);

            } // end using(db)

        } // end function


    } // end class

} // end namespace
