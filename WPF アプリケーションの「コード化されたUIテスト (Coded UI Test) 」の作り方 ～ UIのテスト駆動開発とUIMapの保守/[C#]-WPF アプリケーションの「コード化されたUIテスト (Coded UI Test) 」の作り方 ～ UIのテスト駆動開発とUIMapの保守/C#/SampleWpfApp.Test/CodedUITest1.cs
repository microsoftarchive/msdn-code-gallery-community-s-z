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

namespace SampleWpfApp.Test
{
	/// <summary>
	/// Summary description for CodedUITest1
	/// </summary>
	[CodedUITest]
	public class CodedUITest1
	{
		public CodedUITest1() {
		}

		[TestMethod]
		public void CodedUITestMethod1() {
			// To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.

			this.UIMap.AddNewItem1();
			this.UIMap.AssertListItemCount1();

			// ※このテストは Visual Studio Coded UI Test 標準機能で作成したままです。
			// 　テスト前にアプリが起動されていることが前提で、起動していない場合は失敗します。
			// 　また、終了も制御しないため２回連続で実行すると失敗します。
			//（最後にアイテムが１つ追加されたことを検証している。２回連続すると２つ目が追加されるため）
		}

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
