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

using System.Linq;
using Net.Surviveplus.CodedUIQuery;
using Net.Surviveplus.CodedUITestPlus;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace SampleWpfApp.Test
{
	/// <summary>
	/// Summary description for CodedUITest1
	/// </summary>
	[CodedUITest]
	public class UsingUIMapTest
	{
		public UsingUIMapTest() {
		}

		[TestMethod]
		#region コード分析（命名規則）抑制
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA2204:Literals should be spelled correctly" ),
		 System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly" ),
		 System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores" ),
		 System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly" )]
		#endregion
		public void CodedUITestMethod1() {
			// To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.

			using (var app = App.LaunchSolutionProject(this, "SampleWpfApp") ) {

				OperationAssert.TextIs(
					"最初に 0.5 秒以内にホーム画面が表示されること",
					"HOME",
					app.Element.Sleep( TimeSpan.FromSeconds( 0.5 ) ).Find( "(pageTitle)" ) );

				Console.WriteLine( "UIMap でのテストを実施します。" );
				this.UIMap.AddNewItem1();

				Console.WriteLine( "UIMap での検証を実施します。" );
				this.UIMap.AssertListItemCount1();

				Console.WriteLine( "テストを完了しました。" );
			} // end using
		} // end function

		[TestMethod]
		#region コード分析（命名規則）抑制
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA2204:Literals should be spelled correctly" ),
		 System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly" ),
		 System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores" ),
		 System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly" )]
		#endregion
		public void CodedUITestMethod1Customized() {
			// To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.

			using (var app = App.LaunchSolutionProject( this, "SampleWpfApp" )) {

				Console.WriteLine( "カスタマイズした UIMap でのテストを実施します。" );
				this.UIMap.AddNewItem1Customized();
				this.UIMap.AssertListItemCount1();
				Console.WriteLine( "テストを完了しました。" );

			} // end using
		} // end function

		[TestMethod]
		#region コード分析（命名規則）抑制
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA2204:Literals should be spelled correctly" ),
		 System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly" ),
		 System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores" ),
		 System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly" )]
		#endregion
		public void CodedUITestMethod1Original() {

			using (var app = App.LaunchSolutionProject( this, "SampleWpfApp" )) {

				// UIMap.cs からコピーして使用して実装しました。
				// using を追加し、this を UIMap に変更します。

				#region Variable Declarations
				WinTitleBar uIMainWindowTitleBar = UIMap.UIMainWindowWindow.UIMainWindowTitleBar;
				WpfText uIHOMEText = UIMap.UIMainWindowWindow1.UIMainFramePane.UIHOMEText;
				WpfTable uIMainListTable = UIMap.UIMainWindowWindow1.UIMainFramePane.UIMainListTable;
				WpfButton uIAddButton = UIMap.UIMainWindowWindow1.UIMainFramePane.UIAddButton;
				WpfText uIADDNEWITEMText = UIMap.UIMainWindowWindow1.UIMainFramePane.UIADDNEWITEMText;
				WpfEdit uINameEdit = UIMap.UIMainWindowWindow1.UIMainFramePane.UINameEdit;
				WpfEdit uIDescriptionEdit = UIMap.UIMainWindowWindow1.UIMainFramePane.UIDescriptionEdit;
				WpfButton uIOKButton = UIMap.UIMainWindowWindow1.UIMainFramePane.UIOKButton;
				WpfCell uINewItem1Cell = UIMap.UIMainWindowWindow1.UIMainFramePane.UIMainListTable.UIItemDataItem.UINewItem1Cell;
				#endregion

				// 最初に検証を追加しました。
				System.Threading.Thread.Sleep( TimeSpan.FromSeconds( 0.5 ) );
				Assert.AreEqual( "HOME", uIHOMEText.Name, "0.5秒以内に、ホーム画面に遷移したこと" );

				// ※ CodedUITestPlus を使って以下のようにも書けます。
				//OperationAssert.TextIs(
				//	"最初に 0.5 秒以内にホーム画面が表示されること",
				//	"HOME",
				//	app.Element.Sleep( TimeSpan.FromSeconds( 0.5 ) ).Find( "(pageTitle)" ).MoveMouseTo() );

				// ※録画時にクリックしなかった要素（UIMap にマッピングされなかった要素）は、CodedUITestPlus で独自にクエリします。


				Assert.AreEqual( 0, uIMainListTable.RowCount, "最初にリストアイテムが表示されていないこと" );

				Console.WriteLine( "Click 'MainWindow' title bar" );
				Mouse.Click( uIMainWindowTitleBar, new Point( 148, 7 ) );

				Console.WriteLine( "Click 'HOME' label" );
				Mouse.Click( uIHOMEText, new Point( 46, 24 ) );

				Console.WriteLine( "Click 'mainList' table" );
				Mouse.Click( uIMainListTable, new Point( 226, 168 ) );

				Console.WriteLine( "Click 'Add' button" );
				Mouse.Click( uIAddButton, new Point( 15, 6 ) );

				// UIMap に記録された Mouse.Click( uIADDNEWITEMText, new Point( 99, 17 ) ); を検証に変更しました。
				System.Threading.Thread.Sleep( TimeSpan.FromSeconds( 0.5 ) );
				Assert.AreEqual( "ADD NEW ITEM", uIADDNEWITEMText.Name, "0.5秒以内に、編集画面に遷移したこと" );

				Console.WriteLine( "Type 'New Item 1' in 'name' text box" );
				uINameEdit.Text = UIMap.AddNewItem1Params.UINameEditText;

				Console.WriteLine( "Type 'TEST1' in 'Description' text box" );
				uIDescriptionEdit.Text = UIMap.AddNewItem1ParamsCustomized.UIDescriptionEditText;

				Console.WriteLine( "Click 'OK' button" );
				Mouse.Click( uIOKButton, new Point( 11, 22 ) );

				// UIMap に記録された  Mouse.Click( uIHOMEText, new Point( 55, 13 ) ); を検証に変更しました。
				System.Threading.Thread.Sleep( TimeSpan.FromSeconds( 0.5 ) );
				Assert.AreEqual( "HOME", uIHOMEText.Name, "0.5秒以内に、ホーム画面に遷移したこと" );

				Console.WriteLine( "Click 'New Item 1' cell" );
				Mouse.Click( uINewItem1Cell, new Point( 42, 6 ) );

				Assert.AreEqual( 1, uIMainListTable.RowCount, "リストアイテムが1つ追加されて表示されていること" );

			} // end using

		} // end function

		[TestMethod]
		#region コード分析（命名規則）抑制
		[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA2204:Literals should be spelled correctly" ),
		 System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly" ),
		 System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores" ),
		 System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly" )]
		#endregion
		public void CodedUITestMethod1Original3Times() {

			using (var app = App.LaunchSolutionProject( this, "SampleWpfApp" )) {
				#region Variable Declarations
				//WinTitleBar uIMainWindowTitleBar = UIMap.UIMainWindowWindow.UIMainWindowTitleBar;
				//WpfText uIHOMEText = UIMap.UIMainWindowWindow1.UIMainFramePane.UIHOMEText;
				WpfTable uIMainListTable = UIMap.UIMainWindowWindow1.UIMainFramePane.UIMainListTable;
				WpfButton uIAddButton = UIMap.UIMainWindowWindow1.UIMainFramePane.UIAddButton;
				//WpfText uIADDNEWITEMText = UIMap.UIMainWindowWindow1.UIMainFramePane.UIADDNEWITEMText;
				WpfEdit uINameEdit = UIMap.UIMainWindowWindow1.UIMainFramePane.UINameEdit;
				WpfEdit uIDescriptionEdit = UIMap.UIMainWindowWindow1.UIMainFramePane.UIDescriptionEdit;
				WpfButton uIOKButton = UIMap.UIMainWindowWindow1.UIMainFramePane.UIOKButton;
				//WpfCell uINewItem1Cell = UIMap.UIMainWindowWindow1.UIMainFramePane.UIMainListTable.UIItemDataItem.UINewItem1Cell;
				#endregion

				var counter = 0;
				Func<string> getCountText = () => " " + (counter +=1).ToString();

				Action<string> execute = ( itemName ) =>
				{
					System.Threading.Thread.Sleep( TimeSpan.FromSeconds( 0.5 ) );
					Console.WriteLine( "Click 'Add' button" );
					Mouse.Click( uIAddButton, new Point( 15, 6 ) );

					Console.WriteLine( "Type 'New Item 1' in 'name' text box" );
					uINameEdit.Text = itemName;

					Console.WriteLine( "Type 'Test Item' in 'Description' text box" );
					uIDescriptionEdit.Text = "Test Item";

					Console.WriteLine( "Click 'OK' button" );
					Mouse.Click( uIOKButton, new Point( 11, 22 ) );
				};

				execute( "TEST ITEM" + getCountText() );
				execute( "TEST ITEM" + getCountText() );
				execute( "TEST ITEM" + getCountText() );

				Assert.AreEqual( 3, uIMainListTable.RowCount, "リストアイテムが3つ追加されて表示されていること" );

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

		public UIMap UIMap {
			get {
				if ((this.map == null)) {
					this.map = new UIMap();
				}

				return this.map;
			}
		}

		private UIMap map;
	}
}
