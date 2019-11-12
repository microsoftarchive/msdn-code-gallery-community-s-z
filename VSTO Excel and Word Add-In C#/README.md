# VSTO Excel and Word Add-In C#
## Requires
- Visual Studio 2010
## License
- MIT
## Technologies
- C#
- VSTO
- Windows Forms
## Topics
- C#
- VSTO
- Windows Forms
- VSTO Application
## Updated
- 08/17/2015
## Description

<h1>Introduction</h1>
<div><em><img id="141290" src="141290-1.jpg" alt="" width="555" height="358"></em></div>
<div><em><span style="font:14px/21px Roboto,sans-serif; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">The main purpose
 of this article is to explain how to create simple Excel and Microsoft Word Add-Ins using</span><strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:Roboto,sans-serif; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Visual
 Studio Tools for Office</strong><span style="font:14px/21px Roboto,sans-serif; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff"><span class="Apple-converted-space">&nbsp;</span>(VSTO).
 VSTO is available as an add-in tool with Microsoft Visual Studio. Using Visual Studio we can develop our own custom controls for Office tools like Excel, Word and and so on.</span><br style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span style="font:14px/21px Roboto,sans-serif; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">In my demo program I have
 used Visual Studio 2010 and Office 2007.</span></em></div>
<div><em></em>&nbsp;</div>
<h1><span>Building the Sample</span></h1>
<div><em><span style="font:14px/21px Roboto,sans-serif; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">This article
 explains a few basic things to create our own Custom Add-Ins for Excel and Word as follows.</span></em></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px">1. Excel Add-Ins</strong></div>
<ul style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<li style="outline:0px">Add text to any Excel selected active Excel cell. </li><li style="outline:0px">Add an image to Excel from our Custom Control. </li><li style="outline:0px">Load data from a database and display the search result data in Excel.
</li></ul>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px">2. Word Add-Ins</strong></div>
<p style="outline:0px"><img id="141291" src="141291-2.jpg" alt="" width="562" height="203"></p>
<ul style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<li style="outline:0px">Export Word to PDF. </li><li style="outline:0px">Add Image to Word Document. </li><li style="outline:0px">Add Table to Word document. </li></ul>
<div><span style="font-size:20px; font-weight:bold">Description</span></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px">Creating Excel Add-Ins<br style="outline:0px">
</strong><br style="outline:0px">
In my example I have used Visual Studio 2010 and Office 2007.<br style="outline:0px">
<br style="outline:0px">
To create our own Custom Control Add-Ins for Excel.<br style="outline:0px">
<br style="outline:0px">
<strong style="outline:0px">Step 1</strong></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
Create a new project and select Office 2007 Excel AddIn as in the following Image. Select your Project Folder and enter your Project Name.</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<img id="141292" src="141292-3.jpg" alt="" width="584" height="475"></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px">Step 2</strong></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
Now we can see that the Excel<span class="Apple-converted-space">&nbsp;</span><strong style="outline:0px">ThisAddIn.Cs</strong><span class="Apple-converted-space">&nbsp;</span>file has been created in our project folder and we can find two default methods
 in this class as in the following image. &ldquo;<strong style="outline:0px">ThisAddIn_Startup</strong>&rdquo; In this event we can display our own custom Control Add-Ins to Excel. We can see the details in the code part.</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<img id="141293" src="141293-4.jpg" alt="" width="556" height="202"></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
&nbsp;</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px">Step 3</strong></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
Add a new UserControl to your project to create your own Custom Excel Control Add-In.<br style="outline:0px">
<br style="outline:0px">
Right-click your project-&gt;Click Add New Item-&gt;Add User Control and Name the control as you wish. Add all your Controls and design your user control depending on your requirement.</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<img id="141294" src="141294-5.jpg" alt="" width="362" height="363"></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
In my example, I am performing 3 types of actions in User Controls.</div>
<ol style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<li style="outline:0px"><strong style="outline:0px">Add Text:</strong><span class="Apple-converted-space">&nbsp;</span>In this button click event I will insert the text from the Text box to the Active Selected Excel Cell. Using &ldquo;<strong style="outline:0px">Globals.ThisAddIn.Application.ActiveCell</strong>&rdquo;
 we can get the current active Excel cell. We store the result in an Excel range and now using the range, value&nbsp;and color we can set our own text and colors to the active Excel Cell.
</li></ol>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnAddText_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Excel.Range&nbsp;objRange&nbsp;=&nbsp;Globals.ThisAddIn.Application.ActiveCell;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;objRange.Interior.Color&nbsp;=&nbsp;Color.Pink;&nbsp;<span class="cs__com">//Active&nbsp;Cell&nbsp;back&nbsp;Color&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;objRange.Borders.Color&nbsp;=&nbsp;Color.Red;<span class="cs__com">//&nbsp;Active&nbsp;Cell&nbsp;border&nbsp;Color&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;objRange.Borders.LineStyle&nbsp;=&nbsp;Excel.XlLineStyle.xlContinuous;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;objRange.Value&nbsp;=&nbsp;txtActiveCellText.Text;&nbsp;<span class="cs__com">//Active&nbsp;Cell&nbsp;Text&nbsp;Add&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;objRange.Columns.AutoFit();&nbsp;&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;2. &nbsp;<strong style="outline:0px; text-align:left; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:Roboto,sans-serif; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Add
 Image:</strong><span style="font:14px/21px Roboto,sans-serif; text-align:left; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff"><span class="Apple-converted-space">&nbsp;</span>using
 the Open File Dialog we can select our own image that needs to be added to the Excel file. Using the Excel.Shape we can add our selected image to the Excel file.</span></div>
</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnAddImage_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OpenFileDialog&nbsp;dlg&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OpenFileDialog();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dlg.FileName&nbsp;=&nbsp;<span class="cs__string">&quot;*&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dlg.DefaultExt&nbsp;=&nbsp;<span class="cs__string">&quot;bmp&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dlg.ValidateNames&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dlg.Filter&nbsp;=&nbsp;<span class="cs__string">&quot;Bitmap&nbsp;Image&nbsp;(.bmp)|*.bmp|Gif&nbsp;Image&nbsp;(.gif)|*.gif|JPEG&nbsp;Image&nbsp;(.jpeg)|*.jpeg|Png&nbsp;Image&nbsp;(.png)|*.png&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(dlg.ShowDialog()&nbsp;==&nbsp;System.Windows.Forms.DialogResult.OK)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;dImg&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Bitmap(dlg.FileName);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Excel.Shape&nbsp;IamgeAdd&nbsp;=&nbsp;Globals.ThisAddIn.Application.ActiveSheet.Shapes.AddPicture(dlg.FileName,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Microsoft.Office.Core.MsoTriState.msoFalse,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Microsoft.Office.Core.MsoTriState.msoCTrue,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">20</span>,&nbsp;<span class="cs__number">30</span>,&nbsp;dImg.Width,&nbsp;dImg.Height);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Windows.Forms.Clipboard.Clear.aspx" target="_blank" title="Auto generated link to System.Windows.Forms.Clipboard.Clear">System.Windows.Forms.Clipboard.Clear</a>();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="outline:0px; text-align:left; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:Roboto,sans-serif; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Search
 and bind Db Data to Excel:<span class="Apple-converted-space">&nbsp;</span></strong><span style="font:14px/21px Roboto,sans-serif; text-align:left; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">Now
 we can create our own Custom Search control to be used in Excel to search our data from the database and bind the result to the Excel file.</span><br style="font:14px/21px Roboto,sans-serif; outline:0px; text-align:left; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<br style="font:14px/21px Roboto,sans-serif; outline:0px; text-align:left; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px; text-align:left; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:Roboto,sans-serif; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Creating
 the table</strong></div>
</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__com">--&nbsp;Create&nbsp;Table&nbsp;ItemMaster&nbsp;in&nbsp;your&nbsp;SQL&nbsp;Server&nbsp;-&nbsp;This&nbsp;table&nbsp;will&nbsp;be&nbsp;used&nbsp;for&nbsp;search&nbsp;and&nbsp;bind&nbsp;result&nbsp;to&nbsp;excel.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">ItemMasters</span>](&nbsp;&nbsp;&nbsp;
[<span class="sql__id">Item_Code</span>]&nbsp;[<span class="sql__keyword">varchar</span>](<span class="sql__number">20</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;&nbsp;&nbsp;
[<span class="sql__id">Item_Name</span>]&nbsp;[<span class="sql__keyword">varchar</span>](<span class="sql__number">100</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="sql__com">--&nbsp;insert&nbsp;sample&nbsp;data&nbsp;to&nbsp;Item&nbsp;Master&nbsp;table&nbsp;&nbsp;</span>&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ItemMasters</span>]&nbsp;([<span class="sql__id">Item_Code</span>],[<span class="sql__id">Item_Name</span>])&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">VALUES</span>&nbsp;(<span class="sql__string">'Item001'</span>,<span class="sql__string">'Coke'</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ItemMasters</span>]&nbsp;([<span class="sql__id">Item_Code</span>],[<span class="sql__id">Item_Name</span>])&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">VALUES</span>&nbsp;(<span class="sql__string">'Item002'</span>,<span class="sql__string">'Coffee'</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ItemMasters</span>]&nbsp;([<span class="sql__id">Item_Code</span>],[<span class="sql__id">Item_Name</span>])&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">VALUES</span>&nbsp;(<span class="sql__string">'Item003'</span>,<span class="sql__string">'Chiken&nbsp;Burger'</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ItemMasters</span>]&nbsp;([<span class="sql__id">Item_Code</span>],[<span class="sql__id">Item_Name</span>])&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">VALUES</span>&nbsp;(<span class="sql__string">'Item004'</span>,<span class="sql__string">'Potato&nbsp;Fry'</span>)&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font:14px/21px Roboto,sans-serif; text-align:left; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">In
 the button search click event we search for the data from the database and bind the result to an Excel cell using<span class="Apple-converted-space">&nbsp;</span></span><strong style="outline:0px; text-align:left; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:Roboto,sans-serif; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">&ldquo;Globals.ThisAddIn.Application.ActiveSheet.Cells</strong><span style="font:14px/21px Roboto,sans-serif; text-align:left; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">&rdquo;.
 This will add the result to the active Excel sheet.</span></div>
</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;btnSearch_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span><span class="js__statement">try</span><span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Data.DataTable&nbsp;dt&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.DataTable.aspx" target="_blank" title="Auto generated link to System.Data.DataTable">System.Data.DataTable</a>();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">String</span>&nbsp;ConnectionString&nbsp;=&nbsp;<span class="js__string">&quot;Data&nbsp;Source=YOURDATASOURCE;Initial&nbsp;Catalog=YOURDATABASENAME;User&nbsp;id&nbsp;=&nbsp;UID;password=password&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlConnection&nbsp;con&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SqlConnection(ConnectionString);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">String</span>&nbsp;Query&nbsp;=&nbsp;<span class="js__string">&quot;&nbsp;Select&nbsp;Item_Code,Item_Name&nbsp;FROM&nbsp;ItemMasters&nbsp;Where&nbsp;Item_Name&nbsp;LIKE&nbsp;'&quot;</span>&nbsp;&#43;&nbsp;txtItemName.Text.Trim()&nbsp;&#43;&nbsp;<span class="js__string">&quot;%'&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlCommand&nbsp;cmd&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SqlCommand(Query,&nbsp;con);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandType&nbsp;=&nbsp;System.Data.CommandType.Text;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Data.SqlClient.SqlDataAdapter&nbsp;sda&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.SqlClient.SqlDataAdapter.aspx" target="_blank" title="Auto generated link to System.Data.SqlClient.SqlDataAdapter">System.Data.SqlClient.SqlDataAdapter</a>(cmd);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sda.Fill(dt);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(dt.Rows.Count&nbsp;&lt;=&nbsp;<span class="js__num">0</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">return</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Globals.ThisAddIn.Application.ActiveSheet.Cells.ClearContents();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Globals.ThisAddIn.Application.ActiveSheet.Cells[<span class="js__num">1</span>,&nbsp;<span class="js__num">1</span>].Value2&nbsp;=&nbsp;<span class="js__string">&quot;Item&nbsp;Code&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Globals.ThisAddIn.Application.ActiveSheet.Cells[<span class="js__num">1</span>,&nbsp;<span class="js__num">2</span>].Value2&nbsp;=&nbsp;<span class="js__string">&quot;Item&nbsp;Name&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(int&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;=&nbsp;dt.Rows.Count&nbsp;-&nbsp;<span class="js__num">1</span>;&nbsp;i&#43;&#43;)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Globals.ThisAddIn.Application.ActiveSheet.Cells[i&nbsp;&#43;&nbsp;<span class="js__num">2</span>,&nbsp;<span class="js__num">1</span>].Value2&nbsp;=&nbsp;dt.Rows[i][<span class="js__num">0</span>].ToString();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Globals.ThisAddIn.Application.ActiveSheet.Cells[i&nbsp;&#43;&nbsp;<span class="js__num">2</span>,&nbsp;<span class="js__num">2</span>].Value2&nbsp;=&nbsp;dt.Rows[i][<span class="js__num">1</span>].ToString();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__statement">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px">Step 4</strong></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
Now we have created our own User Control to be added to our Excel Add-Ins. To add this user control to our Excel Add-In as we have already seen that the Excel Addin class &ldquo;<strong style="outline:0px">ThisAddIn.Cs</strong>&rdquo; has start and stop events.
 Using the Office &ldquo;<strong style="outline:0px">CustomTaskpane</strong>&rdquo; we can add our usercontrol to Excel as an Add-In as in the following.</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;Microsoft.Office.Tools.CustomTaskPane&nbsp;customPane;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
private&nbsp;<span class="js__operator">void</span>&nbsp;ThisAddIn_Startup(object&nbsp;sender,&nbsp;System.EventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ShowShanuControl();&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
public&nbsp;<span class="js__operator">void</span>&nbsp;ShowShanuControl()&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span><span class="js__statement">var</span>&nbsp;txtObject&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ShanuExcelADDIn();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;customPane&nbsp;=&nbsp;<span class="js__operator">this</span>.CustomTaskPanes.Add(txtObject,&nbsp;<span class="js__string">&quot;Enter&nbsp;Text&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;customPane.Width&nbsp;=&nbsp;txtObject.Width;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;customPane.Visible&nbsp;=&nbsp;true;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px">Step 5</strong></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
Run your program and now we can see our user control has been added in the Excel File as an Add-In.<br style="outline:0px">
<br style="outline:0px">
Next we will see how to create Add-Ins for Word Documents using a Ribbon Control.<br style="outline:0px">
<br style="outline:0px">
<strong style="outline:0px">Creating Word Add-Ins:<span class="Apple-converted-space">&nbsp;</span><br style="outline:0px">
</strong><br style="outline:0px">
In my example I have used Visual Studio 2010 and Office 2007.<br style="outline:0px">
<br style="outline:0px">
The following describes how to create our own Custom Control Add-Ins for Word.<br style="outline:0px">
<br style="outline:0px">
<strong style="outline:0px">Step 1</strong></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
Create a new project and select Office 2007 Word AddIn as in the following Image. Select your Project Folder and enter your Project Name.</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<img id="141295" src="141295-6.jpg" alt="" width="582" height="377"></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px">Step 2</strong></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
Add a new Ribbon Control to your project to create your own Word Control Add-In.<br style="outline:0px">
<br style="outline:0px">
Right-click your project then click Add New Item -&gt; Add Ribbon Control and name the control as you wish.<span class="Apple-converted-space">&nbsp;</span></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<img id="141296" src="141296-7.jpg" alt="" width="626" height="336"></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span style="font:14px/21px Roboto,sans-serif; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">Add all your controls
 and design your user control depending on your requirements. By default in our Ribbon Control we can see a &ldquo;</span><strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:Roboto,sans-serif; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">RibbonGroup</strong><span style="font:14px/21px Roboto,sans-serif; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">&rdquo;.
 We can add all our controls to the Ribbon Group. Here in my example I have changed the Group Label Text to &ldquo;SHANU Add-In&rdquo;. I have added three Ribbon Button Controls to the group. We can add an image to the Ribbon Button Controls and set the properties
 of the Button Control Size as &ldquo;</span><strong style="outline:0px; color:#333333; text-transform:none; line-height:21px; text-indent:0px; letter-spacing:normal; font-family:Roboto,sans-serif; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">RibbobControlSizeLarge</strong><span style="font:14px/21px Roboto,sans-serif; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">&rdquo;.<span class="Apple-converted-space">&nbsp;</span></span></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<img id="141297" src="141297-8.jpg" alt="" width="592" height="232"></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
Here I have added three Button Controls for export the Word as a PDF, add an image to Word and add a table to the Word file.<br style="outline:0px">
<br style="outline:0px">
<strong style="outline:0px">Step 3</strong></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
Export to PDF File Button Click.<br style="outline:0px">
<br style="outline:0px">
Using the &ldquo;<strong style="outline:0px">Globals.ThisAddIn.Application.ActiveDocument.ExportAsFixedFormat</strong>&rdquo; we can save the Word document to the PDF file. I have used the Save file dialog to save the PDF file into our selected path.</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;btnPDF_Click(object&nbsp;sender,&nbsp;RibbonControlEventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SaveFileDialog&nbsp;dlg&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SaveFileDialog();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dlg.FileName&nbsp;=&nbsp;<span class="js__string">&quot;*&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dlg.DefaultExt&nbsp;=&nbsp;<span class="js__string">&quot;pdf&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dlg.ValidateNames&nbsp;=&nbsp;true;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(dlg.ShowDialog()&nbsp;==&nbsp;System.Windows.Forms.DialogResult.OK)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Globals.ThisAddIn.Application.ActiveDocument.ExportAsFixedFormat(dlg.FileName,&nbsp;word.WdExportFormat.wdExportFormatPDF,&nbsp;OpenAfterExport:&nbsp;true);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px">Step 4</strong></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
Here we will add an image to Word. Using the Open File Dialog we can select our own image to be added to the Word file. Using the &ldquo;<strong style="outline:0px">Globals.ThisAddIn.Application.ActiveDocument.Shapes.AddPicture</strong>&rdquo; method we can
 add our selected image to the Word file.</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;btnImage_Click(object&nbsp;sender,&nbsp;RibbonControlEventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;OpenFileDialog&nbsp;dlg&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;OpenFileDialog();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dlg.FileName&nbsp;=&nbsp;<span class="js__string">&quot;*&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dlg.DefaultExt&nbsp;=&nbsp;<span class="js__string">&quot;bmp&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dlg.ValidateNames&nbsp;=&nbsp;true;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dlg.Filter&nbsp;=&nbsp;<span class="js__string">&quot;Bitmap&nbsp;Image&nbsp;(.bmp)|*.bmp|Gif&nbsp;Image&nbsp;(.gif)|*.gif|JPEG&nbsp;Image&nbsp;(.jpeg)|*.jpeg|Png&nbsp;Image&nbsp;(.png)|*.png&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(dlg.ShowDialog()&nbsp;==&nbsp;System.Windows.Forms.DialogResult.OK)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Globals.ThisAddIn.Application.ActiveDocument.Shapes.AddPicture(dlg.FileName);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px">Step 5</strong></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
Here we will add a table to Word. Using the &ldquo;<strong style="outline:0px">Globals.ThisAddIn.Application.ActiveDocument.Tables</strong>&rdquo; method we can add a table to the Word file. In my example I have created a table with 4 columns and 3 rows.</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;button1_Click(object&nbsp;sender,&nbsp;RibbonControlEventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Globals.ThisAddIn.Application.ActiveDocument.Tables.Add(Globals.ThisAddIn.Application.ActiveDocument.Range(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>),&nbsp;<span class="js__num">3</span>,&nbsp;<span class="js__num">4</span>);&nbsp;&nbsp;&nbsp;
.ThisAddIn.Application.ActiveDocument.Tables[<span class="js__num">1</span>].Range.Shading.BackgroundPatternColor&nbsp;=&nbsp;Microsoft.Office.Interop.Word.WdColor.wdColorSeaGreen;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Globals.ThisAddIn.Application.ActiveDocument.Tables[<span class="js__num">1</span>].Range.Font.Size&nbsp;=&nbsp;<span class="js__num">12</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Globals.ThisAddIn.Application.ActiveDocument.Tables[<span class="js__num">1</span>].Rows.Borders.Enable&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="outline:0px">Step 6</strong></div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
Run your program and now you will see your own Ribbon Control has been added to the Word file as an Add-In.</div>
<div style="font:14px/21px Roboto,sans-serif; outline:0px; color:#333333; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<img id="141298" src="141298-9.jpg" alt="" width="557" height="200">&nbsp;</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li>ShanuWordAddIns.zip<em><em></em></em> </li></ul>
<h1>More Information</h1>
<div><em>The Zip folder contains both Word and Excel Example.</em></div>
