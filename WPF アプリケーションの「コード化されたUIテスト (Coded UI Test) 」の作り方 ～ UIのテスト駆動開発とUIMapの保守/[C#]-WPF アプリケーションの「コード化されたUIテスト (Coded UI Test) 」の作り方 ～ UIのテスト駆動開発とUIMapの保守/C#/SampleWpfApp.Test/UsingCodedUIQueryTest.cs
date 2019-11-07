using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Net.Surviveplus.CodedUITestPlus;
using System.Linq;
using Net.Surviveplus.CodedUIQuery;
using System.Diagnostics.CodeAnalysis;

namespace SampleWpfApp.Test
{
	/// <summary>
	/// Summary description for CodedUITest1
	/// </summary>
	[CodedUITest]
	public class UsingCodedUIQueryTest
	{
		public UsingCodedUIQueryTest() {
		}

		[TestMethod]
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA2204:Literals should be spelled correctly")]
		public void CodedUITestMethod1() {
			// To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.

			using (var app = App.LaunchSolutionProject( this, "SampleWpfApp" )) {

				OperationAssert.TextIs(
					"最初に 0.5 秒以内にホーム画面が表示されること",
					"HOME",
					app.Element.Sleep( TimeSpan.FromSeconds( 0.5 ) ).Find( "(pageTitle)" ).MoveMouseTo() );

				OperationAssert.IsNullOrOffscreen(
					"最初にリストアイテムが表示されていないこと",
					app.Element.Find( "(mainList)" ).MoveMouseTo().Children( "{ListViewItem}" ) );

				OperationAssert.IsSingle(
					"追加ボタンを押せること",
					app.Element.Find( "(appBarAddButton)" ).MoveMouseTo().Click() );

				OperationAssert.TextIs(
					"0.5秒以内に、編集画面に遷移したこと",
					"ADD NEW ITEM",
					app.Element.Sleep( TimeSpan.FromSeconds(0.5) ).Find( "(pageTitle)") );

				OperationAssert.TextIs(
					"Name にテキストを入力出来ること",
					"New Item 1",
					app.Element.Find( "(name)" ).MoveMouseTo().SendKeys( "{END}" ).InputText( " 1" ).Sleep( TimeSpan.FromSeconds( 0.5 ) ) );

				OperationAssert.TextIs(
					"Description テキストを入力出来ること",
					"TEST1",
					app.Element.Find( "(Description)" ).MoveMouseTo().InputText( "TEST1" ) );

				OperationAssert.IsSingle(
					"OKボタンを押せること",
					app.Element.Find( "(OKButton)" ).MoveMouseTo().Click() );

				OperationAssert.TextIs(
					"0.5秒以内に、ホーム画面に遷移したこと",
					"HOME",
					app.Element.Sleep( TimeSpan.FromSeconds( 0.5 ) ).Find( "(pageTitle)").MoveMouseTo() );

				OperationAssert.IsSingle(
					"リストアイテムが1つ追加されて表示されていること",
					app.Element.Find( "(mainList)" ).MoveMouseTo().Children( "{ListViewItem}" ) );


				// 最後に目視のため 0.5 秒待ちます。
				app.Element.Sleep( TimeSpan.FromSeconds( 0.5 ) ).Count();

			} // end using(app)

		} // end function

		[TestMethod()]
		#region コード分析（命名規則）抑制
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA2204:Literals should be spelled correctly" ),
		 System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly" ),
		 System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores" ),
		 System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly" )]
		#endregion
		public void SampleApp_正常系_連続して3アイテム追加出来ること() {

			using (var app = App.LaunchSolutionProject( this, "SampleWpfApp" )) {

				var counter = 0;
				Func<string> getCountText = () => " " + (counter +=1).ToString();

				Action<string> execute = (itemName) =>
				{
					OperationAssert.IsSingle( "追加ボタンを押す", app.Element.WaitForFind( "(appBarAddButton)", TimeSpan.FromSeconds( 0.5 ) ).MoveMouseTo().Click());
					OperationAssert.TextIs( "name にテキストを入力", itemName, app.Element.WaitForFind( "(name)", TimeSpan.FromSeconds( 0.5 ) ).MoveMouseTo().SetText( "" ).InputText( itemName ) );
					OperationAssert.TextIs( "Description にテキストを入力", "Test Item", app.Element.Find( "(Description)" ).MoveMouseTo().SetText( "" ).InputText( "Test Item" ) );
					OperationAssert.IsSingle( "OKボタンを押す", app.Element.Find( "(OKButton)" ).MoveMouseTo().Click() );
				};

				execute( "TEST ITEM" + getCountText() );
				execute( "TEST ITEM" + getCountText() );
				execute( "TEST ITEM" + getCountText() );

				OperationAssert.CountIs(
					"リストアイテムが3つ追加されて表示されていること",
					3,
					app.Element.Find( "(mainList)" ).MoveMouseTo().Children( "{ListViewItem}" ) );

				// 最後に目視のため 0.5 秒待ちます。
				app.Element.Sleep( TimeSpan.FromSeconds( 0.5 ) ).Count();

			} // end using

		} // end function

		#region Additional test attributes

		// You can use the following additional attributes as you write your tests:

		////Use TestInitialize to run code before running each test 
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{        
		//    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
		//}

		////Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{        
		//    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
		//}

		#endregion

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}
		private TestContext testContextInstance;
	}
}
