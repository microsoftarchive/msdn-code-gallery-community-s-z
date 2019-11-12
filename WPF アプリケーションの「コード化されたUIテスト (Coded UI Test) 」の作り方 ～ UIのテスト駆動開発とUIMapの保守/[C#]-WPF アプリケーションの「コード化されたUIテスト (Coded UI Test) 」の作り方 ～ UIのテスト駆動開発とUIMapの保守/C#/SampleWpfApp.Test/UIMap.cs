namespace SampleWpfApp.Test
{
	using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
	using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
	using System;
	using System.Collections.Generic;
	using System.CodeDom.Compiler;
	using Microsoft.VisualStudio.TestTools.UITest.Extension;
	using Microsoft.VisualStudio.TestTools.UITesting;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
	using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
	using MouseButtons = System.Windows.Forms.MouseButtons;
	using System.Drawing;
	using System.Windows.Input;
	using System.Text.RegularExpressions;

	using System.Linq;
	using Net.Surviveplus.CodedUITestPlus;
	using Net.Surviveplus.CodedUIQuery;

	public partial class UIMap
	{

		/// <summary>
		/// AddNewItem1 - Use 'AddNewItem1Params' to pass parameters into this method.
		/// </summary>
		public void AddNewItem1Customized() {
			#region Variable Declarations
			WinTitleBar uIMainWindowTitleBar = this.UIMainWindowWindow.UIMainWindowTitleBar;
			WpfText uIHOMEText = this.UIMainWindowWindow1.UIMainFramePane.UIHOMEText;
			WpfTable uIMainListTable = this.UIMainWindowWindow1.UIMainFramePane.UIMainListTable;
			WpfButton uIAddButton = this.UIMainWindowWindow1.UIMainFramePane.UIAddButton;
			WpfText uIADDNEWITEMText = this.UIMainWindowWindow1.UIMainFramePane.UIADDNEWITEMText;
			WpfEdit uINameEdit = this.UIMainWindowWindow1.UIMainFramePane.UINameEdit;
			WpfEdit uIDescriptionEdit = this.UIMainWindowWindow1.UIMainFramePane.UIDescriptionEdit;
			WpfButton uIOKButton = this.UIMainWindowWindow1.UIMainFramePane.UIOKButton;
			WpfCell uINewItem1Cell = this.UIMainWindowWindow1.UIMainFramePane.UIMainListTable.UIItemDataItem.UINewItem1Cell;
			#endregion

			//
			// UIMap.Designer.cs から UIMap.cs にコードを移すと、UIMap.uitest 画面に表示されなくなります。
			// AddNewItem1Customized は説明のために複製して作成したものです。
			//

			// 最後のマウス操作が記録されませんでした。

			// 最初に検証を追加しました。
			System.Threading.Thread.Sleep( TimeSpan.FromSeconds( 0.5 ) );
			Assert.AreEqual( "HOME", uIHOMEText.Name, "0.5秒以内に、ホーム画面に遷移したこと" );
			
			// ※ CodedUITestPlus を使って以下のようにも書けます。
			//OperationAssert.TextIs(
			//	"最初に 0.5 秒以内にホーム画面が表示されること",
			//	"HOME",
			//	this.mUIMainWindowWindow.Query().Sleep( TimeSpan.FromSeconds( 0.5 ) ).Find( "(pageTitle)" ) );

			// ※録画時にクリックしなかった要素（UIMap にマッピングされなかった要素）は、CodedUITestPlus で独自にクエリします。

			Console.WriteLine( "Click 'MainWindow' title bar" );
			Mouse.Click( uIMainWindowTitleBar, new Point( 148, 7 ) );

			Console.WriteLine( "Click 'HOME' label" );
			Mouse.Click( uIHOMEText, new Point( 46, 24 ) );

			Console.WriteLine( "Click 'mainList' table" );
			Mouse.Click( uIMainListTable, new Point( 226, 168 ) );

			Console.WriteLine( "Click 'Add' button" );
			Mouse.Click( uIAddButton, new Point( 15, 6 ) );

			// UIMap に記録された Mouse.Click( uIADDNEWITEMText, new Point( 99, 17 ) ); を検証に変更しました。
			Assert.AreEqual( "ADD NEW ITEM", uIADDNEWITEMText.Name, "0.5秒以内に、編集画面に遷移したこと" );

			Console.WriteLine( "Type 'New Item 1' in 'name' text box" );
			uINameEdit.Text = this.AddNewItem1Params.UINameEditText;

			Console.WriteLine( "Type 'TEST1' in 'Description' text box" );
			uIDescriptionEdit.Text = this.AddNewItem1ParamsCustomized.UIDescriptionEditText;

			Console.WriteLine( "Click 'OK' button" );
			Mouse.Click( uIOKButton, new Point( 11, 22 ) );

			// UIMap に記録された  Mouse.Click( uIHOMEText, new Point( 55, 13 ) ); を検証に変更しました。
			System.Threading.Thread.Sleep( TimeSpan.FromSeconds( 0.5 ) );
			Assert.AreEqual( "HOME", uIHOMEText.Name, "0.5秒以内に、ホーム画面に遷移したこと" );

			Console.WriteLine( "Click 'New Item 1' cell" );
			Mouse.Click( uINewItem1Cell, new Point( 42, 6 ) );
		}

		public virtual AddNewItem1ParamsCustomized AddNewItem1ParamsCustomized {
			get {
				if ((this.mAddNewItem1ParamsCustomized == null)) {
					this.mAddNewItem1ParamsCustomized = new AddNewItem1ParamsCustomized();
				}
				return this.mAddNewItem1ParamsCustomized;
			}
		}

		private AddNewItem1ParamsCustomized mAddNewItem1ParamsCustomized;
	}
	/// <summary>
	/// Parameters to be passed into 'AddNewItem1'
	/// </summary>
	[GeneratedCode( "Coded UITest Builder", "12.0.31101.0" )]
	public class AddNewItem1ParamsCustomized
	{

		#region Fields
		/// <summary>
		/// Type 'New Item 1' in 'name' text box
		/// </summary>
		public string UINameEditText = "New Item 1";

		/// <summary>
		/// Type 'TEST1' in 'Description' text box
		/// </summary>
		public string UIDescriptionEditText = "TEST1";
		#endregion
}
}
