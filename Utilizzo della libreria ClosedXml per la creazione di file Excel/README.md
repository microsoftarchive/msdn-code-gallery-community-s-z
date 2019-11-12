# Utilizzo della libreria ClosedXml per la creazione di file Excel
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- Excel
- Windows Forms
- Visual Studio 2010
- Windows SDK
- .NET Framework 4
- .NET Framework
- Microsoft Office Excel 2007
- Visual Basic.NET
- VB.Net
- .NET Framework 4.0
- Excel 2007
- Open XML SDK 2.0
- Windows General
- C# Language
- WinForms
## Topics
- C#
- Excel
- Windows Forms
- Visual Basic .NET
- Visual basic
- VB.Net
- .NET 4
- ClosedXml
- OpenXml
## Updated
- 11/17/2012
## Description

<h1>Introduction</h1>
<p><em>Questo esempio dimostra come utilizzare la libreria ClosedXml.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Per poter provare questo esempio occorre avere VisualStudio 2010 , oltre che le libreria ClosedXml.dll e OpenXml di microsoft installato sul proprio pc.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>&nbsp;ClosedXml e un file con estensione .dll pensato per poter creare con estrema facilit&agrave; dei file Excel con pochi e semplici passaggi. Potete trovare tutta la documentazione e scaricare ClosedXml da Codeplex , il link e disponibile qui di seguito
<a href="http://closedxml.codeplex.com/">http://closedxml.codeplex.com/</a>&nbsp;.&nbsp;Con ClosedXml si&nbsp;possono creare file Excel 2007 e versione 2010 , tener conto che per poter utilizzare ClosedXml abbiamo anche bisogno di installare OpenXml di Microsoft
 disponibile per il Download qui di seguito <a href="http://www.microsoft.com/en-us/download/details.aspx?id=5124">
http://www.microsoft.com/en-us/download/details.aspx?id=5124</a>.In questo esempio vi &egrave; un DataBase creato per semplicit&agrave; con SqlCompact , dove e possibile inserire i dati in una tabella chiamata UserData in modo poi da poterli visualizzare in
 anteprima mediante un DataGrid e un form dedicato.Allafine sar&agrave; possibile salvare e visualizzare il risultato mediante un file excel visibile in figura successiva.Qui di seguito riporto anche il codice utilizzato.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__com">'FrmClodedXmlSample</span>&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;FrmClosedXmlSample&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I&nbsp;declare&nbsp;a&nbsp;variable&nbsp;of&nbsp;type&nbsp;bool,&nbsp;this&nbsp;variable&nbsp;is&nbsp;handled&nbsp;when&nbsp;the&nbsp;user&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'select&nbsp;a&nbsp;row&nbsp;in&nbsp;the&nbsp;DataGrid&nbsp;control&nbsp;to&nbsp;allow&nbsp;you&nbsp;to&nbsp;erase&nbsp;and&nbsp;edit&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;_checkifrowisselected&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'FrmClosedXmlSampleLoad&nbsp;event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;FrmClosedXmlSampleLoad(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'This&nbsp;method&nbsp;loads&nbsp;the&nbsp;data&nbsp;into&nbsp;the&nbsp;control&nbsp;using&nbsp;the&nbsp;TableAdapter's&nbsp;Fill&nbsp;method,&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'and&nbsp;then&nbsp;the&nbsp;DataGridView&nbsp;control&nbsp;is&nbsp;enhanced&nbsp;with&nbsp;the&nbsp;original&nbsp;data&nbsp;using&nbsp;the&nbsp;DataSource&nbsp;property</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoadDataGrid()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'LoadDataGrid&nbsp;Method</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;LoadDataGrid()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Load&nbsp;the&nbsp;data&nbsp;into&nbsp;the&nbsp;control&nbsp;TableAdapter</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;USERDATATableAdapter.Fill(UserDataSet.USERDATA)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Load&nbsp;data&nbsp;with&nbsp;the&nbsp;DataGrid&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvUserData.DataSource&nbsp;=&nbsp;USERDATABindingSource&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'BtnEsciClick&nbsp;event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;BtnEsciClick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnEsci.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Close&nbsp;application</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'BtnNewClick&nbsp;Event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;BtnNuovoClick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnNuovo.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Insert&nbsp;this&nbsp;method&nbsp;does&nbsp;nothing&nbsp;but&nbsp;make&nbsp;the&nbsp;exploitation&nbsp;of&nbsp;fields&nbsp;of&nbsp;DataTable&nbsp;after&nbsp;inserting&nbsp;a&nbsp;new&nbsp;record&nbsp;into&nbsp;the&nbsp;table&nbsp;UserData</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;USERDATATableAdapter.Insert(txtName.Text.ToUpper(),&nbsp;txtSurname.Text.ToUpper(),&nbsp;txtAddress.Text.ToUpper(),&nbsp;txtTelephoneNumber.Text.ToUpper(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtCity.Text.ToUpper(),&nbsp;txtNationality.Text.ToUpper())&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'This&nbsp;method&nbsp;loads&nbsp;the&nbsp;data&nbsp;into&nbsp;the&nbsp;control&nbsp;using&nbsp;the&nbsp;TableAdapter's&nbsp;Fill&nbsp;method,&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'and&nbsp;then&nbsp;the&nbsp;DataGridView&nbsp;control&nbsp;is&nbsp;enhanced&nbsp;with&nbsp;the&nbsp;original&nbsp;data&nbsp;using&nbsp;the&nbsp;DataSource&nbsp;property</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoadDataGrid()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'BtnDeleteClick&nbsp;Event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;BtnEliminaClick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnElimina.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;not&nbsp;_checkifrowisselected&nbsp;equals&nbsp;false</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;_checkifrowisselected.Equals(<span class="visualBasic__keyword">False</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'check&nbsp;if&nbsp;current&nbsp;row&nbsp;is&nbsp;not&nbsp;null</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;dgvUserData.CurrentRow&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Delete&nbsp;this&nbsp;method&nbsp;does&nbsp;is&nbsp;erase&nbsp;the&nbsp;fields&nbsp;in&nbsp;the&nbsp;UserData&nbsp;table,&nbsp;execute&nbsp;the&nbsp;passing&nbsp;as&nbsp;argument&nbsp;the&nbsp;number&nbsp;of&nbsp;records&nbsp;that&nbsp;we&nbsp;select&nbsp;using&nbsp;the&nbsp;DataGridView&nbsp;control,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'before&nbsp;removal&nbsp;of&nbsp;the&nbsp;record,&nbsp;it&nbsp;checks&nbsp;to&nbsp;see&nbsp;if&nbsp;the&nbsp;user&nbsp;has&nbsp;selected&nbsp;or&nbsp;least&nbsp;one&nbsp;row&nbsp;of&nbsp;the&nbsp;DataGridView&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;USERDATATableAdapter.Delete(<span class="visualBasic__keyword">Integer</span>.Parse(dgvUserData.CurrentRow.Cells(<span class="visualBasic__number">0</span>).Value.ToString()))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'This&nbsp;method&nbsp;loads&nbsp;the&nbsp;data&nbsp;into&nbsp;the&nbsp;control&nbsp;using&nbsp;the&nbsp;TableAdapter's&nbsp;Fill&nbsp;method,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'and&nbsp;then&nbsp;the&nbsp;DataGridView&nbsp;control&nbsp;is&nbsp;enhanced&nbsp;with&nbsp;the&nbsp;original&nbsp;data&nbsp;using&nbsp;the&nbsp;DataSource&nbsp;property</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoadDataGrid()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'set&nbsp;to&nbsp;false&nbsp;variable</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_checkifrowisselected&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Visualize&nbsp;message&nbsp;to&nbsp;user</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(My.Resources.FrmClosedXmlSample_BtnDeleteClick_Select_one_row)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'BtnUpdate&nbsp;Event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;BtnModificaClick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnModifica.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;not&nbsp;_checkifrowisselected&nbsp;equals&nbsp;false</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;_checkifrowisselected.Equals(<span class="visualBasic__keyword">False</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Check&nbsp;if&nbsp;currentrow&nbsp;of&nbsp;DataGric&nbsp;is&nbsp;not&nbsp;null</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;dgvUserData.CurrentRow&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;USERDATATableAdapter.Update(txtName.Text.ToUpper(),&nbsp;txtSurname.Text.ToUpper(),&nbsp;txtAddress.Text.ToUpper(),&nbsp;txtTelephoneNumber.Text.ToUpper(),&nbsp;txtCity.Text.ToUpper(),&nbsp;txtNationality.Text.ToUpper(),&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Integer</span>.Parse(dgvUserData.CurrentRow.Cells(<span class="visualBasic__number">0</span>).Value.ToString()))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'This&nbsp;method&nbsp;loads&nbsp;the&nbsp;data&nbsp;into&nbsp;the&nbsp;control&nbsp;using&nbsp;the&nbsp;TableAdapter's&nbsp;Fill&nbsp;method,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'and&nbsp;then&nbsp;the&nbsp;DataGridView&nbsp;control&nbsp;is&nbsp;enhanced&nbsp;with&nbsp;the&nbsp;original&nbsp;data&nbsp;using&nbsp;the&nbsp;DataSource&nbsp;property</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoadDataGrid()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'set&nbsp;to&nbsp;false&nbsp;variable</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_checkifrowisselected&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Visualize&nbsp;message&nbsp;to&nbsp;user</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(My.Resources.FrmClosedXmlSample_BtnDeleteClick_Select_one_row)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'BtnReportClick&nbsp;Event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;BtnReportClick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnReport.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I&nbsp;declare&nbsp;a&nbsp;new&nbsp;instance&nbsp;of&nbsp;the&nbsp;Form&nbsp;Frmeport</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;frm&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;FrmReport&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Pass&nbsp;data&nbsp;form&nbsp;dgvUserData&nbsp;to&nbsp;Datagrin&nbsp;in&nbsp;FrmReport</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;frm.FrmReport(dgvUserData)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I'm&nbsp;seeing&nbsp;the&nbsp;Forms&nbsp;user</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;frm.Show()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'BtnFindClick&nbsp;Event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;BtnFindClick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnFind.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I&nbsp;get&nbsp;the&nbsp;currently&nbsp;selected&nbsp;text&nbsp;to&nbsp;the&nbsp;ComboBox&nbsp;control*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;selecteditems&nbsp;=&nbsp;cbxFind.Text&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Executing&nbsp;the&nbsp;control&nbsp;of&nbsp;the&nbsp;variable&nbsp;SelectedItems&nbsp;with&nbsp;a&nbsp;Switch&nbsp;construct</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;selecteditems&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'if&nbsp;equals&nbsp;&quot;NAME&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;NAME&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I&nbsp;run&nbsp;a&nbsp;query&nbsp;LinqToDataSet&nbsp;with&nbsp;extension&nbsp;method&nbsp;and&nbsp;recover&nbsp;all&nbsp;data&nbsp;from&nbsp;the&nbsp;UserData&nbsp;table&nbsp;and&nbsp;visualize&nbsp;the&nbsp;DataGrid&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;queryname&nbsp;=&nbsp;UserDataSet.USERDATA.Where(<span class="visualBasic__keyword">Function</span>(f)&nbsp;f.NAME.StartsWith(txtName.Text.ToUpper)).<span class="visualBasic__keyword">Select</span>(<span class="visualBasic__keyword">Function</span>(f)&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{f.NAME&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;f.SURNAME,&nbsp;f.ADDRESS,&nbsp;f.TELEPHONE,&nbsp;f.CITY,&nbsp;f.NATIONALITI})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvUserData.DataSource&nbsp;=&nbsp;queryname.ToArray&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'if&nbsp;eqUals&nbsp;&quot;CITY&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;CITY&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I&nbsp;run&nbsp;a&nbsp;query&nbsp;LinqToDataSet&nbsp;with&nbsp;extension&nbsp;method&nbsp;and&nbsp;recover&nbsp;all&nbsp;data&nbsp;from&nbsp;the&nbsp;UserData&nbsp;table&nbsp;and&nbsp;visualize&nbsp;the&nbsp;DataGrid&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;querycity&nbsp;=&nbsp;UserDataSet.USERDATA.Where(<span class="visualBasic__keyword">Function</span>(f)&nbsp;f.NAME.StartsWith(txtCity.Text.ToUpper)).<span class="visualBasic__keyword">Select</span>(<span class="visualBasic__keyword">Function</span>(f)&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{f.NAME&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;f.SURNAME,&nbsp;f.ADDRESS,&nbsp;f.TELEPHONE,&nbsp;f.CITY,&nbsp;f.NATIONALITI})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvUserData.DataSource&nbsp;=&nbsp;querycity.ToArray&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'if&nbsp;eqUals&nbsp;&quot;NATIONALITY&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;NATIONALITY&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I&nbsp;run&nbsp;a&nbsp;query&nbsp;LinqToDataSet&nbsp;with&nbsp;extension&nbsp;method&nbsp;and&nbsp;recover&nbsp;all&nbsp;data&nbsp;from&nbsp;the&nbsp;UserData&nbsp;table&nbsp;and&nbsp;visualize&nbsp;the&nbsp;DataGrid&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;querynationality&nbsp;=&nbsp;UserDataSet.USERDATA.Where(<span class="visualBasic__keyword">Function</span>(f)&nbsp;f.NAME.StartsWith(txtNationality.Text.ToUpper)).<span class="visualBasic__keyword">Select</span>(<span class="visualBasic__keyword">Function</span>(f)&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{f.NAME&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&nbsp;f.SURNAME,&nbsp;f.ADDRESS,&nbsp;f.TELEPHONE,&nbsp;f.CITY,&nbsp;f.NATIONALITI})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvUserData.DataSource&nbsp;=&nbsp;querynationality.ToArray&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'CbxFindSelectedIndexChanged&nbsp;event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;CbxFindSelectedIndexChanged(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;cbxFind.SelectedIndexChanged&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I&nbsp;get&nbsp;the&nbsp;currently&nbsp;selected&nbsp;text&nbsp;to&nbsp;the&nbsp;ComboBox&nbsp;control*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;selecteditems&nbsp;=&nbsp;cbxFind.Text&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Using&nbsp;a&nbsp;query&nbsp;LinqToObjects&nbsp;reimposed&nbsp;the&nbsp;Enabled&nbsp;property&nbsp;to&nbsp;true&nbsp;for&nbsp;all&nbsp;the&nbsp;text&nbsp;boxes&nbsp;on&nbsp;the&nbsp;form</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;c&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;Controls.OfType(<span class="visualBasic__keyword">Of</span>&nbsp;TextBox)()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Executing&nbsp;the&nbsp;control&nbsp;of&nbsp;the&nbsp;variable&nbsp;SelectedItems&nbsp;with&nbsp;a&nbsp;Switch&nbsp;construct</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;selecteditems&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'if&nbsp;equals&nbsp;&quot;NAME&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;NAME&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I&nbsp;run&nbsp;a&nbsp;query&nbsp;linq&nbsp;to&nbsp;objects&nbsp;and&nbsp;imposed&nbsp;enable&nbsp;the&nbsp;property&nbsp;if&nbsp;different&nbsp;from&nbsp;the&nbsp;text&nbsp;box&nbsp;specified</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;c&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;From&nbsp;c1&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;Controls.OfType(<span class="visualBasic__keyword">Of</span>&nbsp;TextBox)()&nbsp;Where&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;c1.Name.Equals(txtName.Name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'if&nbsp;equals&nbsp;&quot;SURNAME&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;SURNAME&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I&nbsp;run&nbsp;a&nbsp;query&nbsp;linq&nbsp;to&nbsp;objects&nbsp;and&nbsp;imposed&nbsp;enable&nbsp;the&nbsp;property&nbsp;if&nbsp;different&nbsp;from&nbsp;the&nbsp;text&nbsp;box&nbsp;specified</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;c&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;From&nbsp;c1&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;Controls.OfType(<span class="visualBasic__keyword">Of</span>&nbsp;TextBox)()&nbsp;Where&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;c1.Name.Equals(txtSurname.Name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'if&nbsp;equals&nbsp;&quot;ADDRESS&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;ADDRESS&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I&nbsp;run&nbsp;a&nbsp;query&nbsp;linq&nbsp;to&nbsp;objects&nbsp;and&nbsp;imposed&nbsp;enable&nbsp;the&nbsp;property&nbsp;if&nbsp;different&nbsp;from&nbsp;the&nbsp;text&nbsp;box&nbsp;specified</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;c&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;From&nbsp;c1&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;Controls.OfType(<span class="visualBasic__keyword">Of</span>&nbsp;TextBox)()&nbsp;Where&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;c1.Name.Equals(txtAddress.Name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'if&nbsp;equals&nbsp;&quot;TELEPHONE&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;TELEPHONENUMBER&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I&nbsp;run&nbsp;a&nbsp;query&nbsp;linq&nbsp;to&nbsp;objects&nbsp;and&nbsp;imposed&nbsp;enable&nbsp;the&nbsp;property&nbsp;if&nbsp;different&nbsp;from&nbsp;the&nbsp;text&nbsp;box&nbsp;specified</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;c&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;From&nbsp;c1&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;Controls.OfType(<span class="visualBasic__keyword">Of</span>&nbsp;TextBox)()&nbsp;Where&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;c1.Name.Equals(txtTelephoneNumber.Name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'if&nbsp;eqUals&nbsp;&quot;CITY&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;CITY&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I&nbsp;run&nbsp;a&nbsp;query&nbsp;linq&nbsp;to&nbsp;objects&nbsp;and&nbsp;imposed&nbsp;enable&nbsp;the&nbsp;property&nbsp;if&nbsp;different&nbsp;from&nbsp;the&nbsp;text&nbsp;box&nbsp;specified</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;c&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;From&nbsp;c1&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;Controls.OfType(<span class="visualBasic__keyword">Of</span>&nbsp;TextBox)()&nbsp;Where&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;c1.Name.Equals(txtCity.Name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'if&nbsp;eqUals&nbsp;&quot;NATIONALITY&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;NATIONALITY&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I&nbsp;run&nbsp;a&nbsp;query&nbsp;linq&nbsp;to&nbsp;objects&nbsp;and&nbsp;imposed&nbsp;enable&nbsp;the&nbsp;property&nbsp;if&nbsp;different&nbsp;from&nbsp;the&nbsp;text&nbsp;box&nbsp;specified</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;c&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;From&nbsp;c1&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;Controls.OfType(<span class="visualBasic__keyword">Of</span>&nbsp;TextBox)()&nbsp;Where&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;c1.Name.Equals(txtNationality.Name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Enabled&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
<div class="scriptcode">Questa era la parte di codice per l'interazione con i dati , quindi solo L'insert , il Delete e Update, di seguito tutto il codice per creare un file excel.</div>
<div class="scriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__com">'dll&nbsp;netFramework</span>&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Globalization&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;ClosedXML.Excel&nbsp;
&nbsp;
<span class="visualBasic__com">'FrmReport&nbsp;Class</span>&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;FrmReport&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Sub&nbsp;FrmReport</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;FrmReport(<span class="visualBasic__keyword">ByVal</span>&nbsp;datareport&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataGridView)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Enhanced&nbsp;the&nbsp;value&nbsp;control&nbsp;DataGrid&nbsp;using&nbsp;the&nbsp;property&nbsp;DataReport</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvReport.DataSource&nbsp;=&nbsp;datareport.DataSource&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'BtnExitClick&nbsp;event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;BtnExitClick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnExit.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Close&nbsp;actual&nbsp;Form</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'BtnExportToExcelClick&nbsp;event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;BtnExportToExcelClick(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnExportToExcel.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;the&nbsp;DataGrid&nbsp;control&nbsp;does&nbsp;not&nbsp;contain&nbsp;any&nbsp;column</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;dgvReport.Columns.Count.Equals(<span class="visualBasic__number">0</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I&nbsp;get&nbsp;a&nbsp;message&nbsp;to&nbsp;the&nbsp;user</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(My.Resources.FrmReport_BtnSalvaInExcelClick_Nessuna_riga_da_salvare,&nbsp;Application.ProductName.ToString(CultureInfo.InvariantCulture))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Imposed&nbsp;on&nbsp;the&nbsp;size&nbsp;of&nbsp;the&nbsp;file&nbsp;to&nbsp;be&nbsp;saved&nbsp;for&nbsp;the&nbsp;SaveFileDialog&nbsp;component,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'the&nbsp;format&nbsp;and&nbsp;saved&nbsp;in&nbsp;the&nbsp;application's&nbsp;resources.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sfDialog.Filter&nbsp;=&nbsp;My.Resources.FileXlsx&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Given&nbsp;the&nbsp;name&nbsp;of&nbsp;the&nbsp;excel&nbsp;file&nbsp;that&nbsp;will&nbsp;be&nbsp;generated.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sfDialog.FileName&nbsp;=&nbsp;<span class="visualBasic__string">&quot;USER&nbsp;DATA&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Here,&nbsp;however,&nbsp;we&nbsp;create&nbsp;a&nbsp;new&nbsp;worksheet&nbsp;excel</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;workbook&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;XLWorkbook()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'On&nbsp;the&nbsp;worksheet,&nbsp;create&nbsp;the&nbsp;worksheet&nbsp;in&nbsp;another&nbsp;sheet&nbsp;named&nbsp;user&nbsp;reports,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'this&nbsp;leaflet&nbsp;will&nbsp;be&nbsp;included&nbsp;in&nbsp;the&nbsp;excel&nbsp;file&nbsp;which&nbsp;will&nbsp;then&nbsp;be&nbsp;generated.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;worksheet&nbsp;=&nbsp;workbook.Worksheets.Add(<span class="visualBasic__string">&quot;USER&nbsp;DATA&nbsp;REPORT&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'I&nbsp;create&nbsp;variables&nbsp;as&nbsp;there&nbsp;are&nbsp;columns&nbsp;of&nbsp;excel&nbsp;file&nbsp;to&nbsp;be&nbsp;created,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'in&nbsp;this&nbsp;case&nbsp;6&nbsp;and&nbsp;the&nbsp;imposed&nbsp;with&nbsp;a&nbsp;default&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cellA&nbsp;=&nbsp;<span class="visualBasic__string">&quot;A&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cellB&nbsp;=&nbsp;<span class="visualBasic__string">&quot;B&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cellC&nbsp;=&nbsp;<span class="visualBasic__string">&quot;C&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cellD&nbsp;=&nbsp;<span class="visualBasic__string">&quot;D&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cellE&nbsp;=&nbsp;<span class="visualBasic__string">&quot;E&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cellF&nbsp;=&nbsp;<span class="visualBasic__string">&quot;F&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'This&nbsp;variable&nbsp;is&nbsp;used&nbsp;for&nbsp;the&nbsp;process&nbsp;of&nbsp;writing&nbsp;the&nbsp;various&nbsp;sections&nbsp;of&nbsp;the&nbsp;paper,&nbsp;the&nbsp;header,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'the&nbsp;name&nbsp;of&nbsp;the&nbsp;columns&nbsp;to&nbsp;end&nbsp;up&nbsp;with&nbsp;the&nbsp;values&nbsp;​​of&nbsp;the&nbsp;DataGrid&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;indexcell&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'In&nbsp;this&nbsp;loop&nbsp;we&nbsp;perform&nbsp;the&nbsp;control&nbsp;of&nbsp;the&nbsp;variable&nbsp;index&nbsp;and&nbsp;it&nbsp;will&nbsp;create&nbsp;the&nbsp;header&nbsp;of&nbsp;the&nbsp;sheet,&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'a&nbsp;title&nbsp;and&nbsp;the&nbsp;formatting&nbsp;of&nbsp;cells&nbsp;on&nbsp;the&nbsp;alignment&nbsp;of&nbsp;the&nbsp;title&nbsp;text</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;riga&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;<span class="visualBasic__number">3</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'In&nbsp;this&nbsp;loop&nbsp;are&nbsp;enclosed&nbsp;in&nbsp;stages&nbsp;to&nbsp;the&nbsp;header&nbsp;in&nbsp;the&nbsp;title,&nbsp;the&nbsp;cell&nbsp;formatting&nbsp;and&nbsp;the&nbsp;column&nbsp;headings</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;indexcell&nbsp;&#43;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;index&nbsp;equals&nbsp;1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;indexcell.Equals(<span class="visualBasic__number">1</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Allowance&nbsp;for&nbsp;cells&nbsp;and&nbsp;and&nbsp;the&nbsp;numerical&nbsp;value&nbsp;given&nbsp;by&nbsp;the&nbsp;variable&nbsp;i&nbsp;and&nbsp;indexcell</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellA&nbsp;&#43;=&nbsp;indexcell.ToString(CultureInfo.InvariantCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellF&nbsp;&#43;=&nbsp;indexcell.ToString(CultureInfo.InvariantCulture)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'The&nbsp;Merge&nbsp;method&nbsp;allows&nbsp;to&nbsp;combine&nbsp;two&nbsp;or&nbsp;more&nbsp;cells,&nbsp;in&nbsp;this&nbsp;case&nbsp;we&nbsp;combine&nbsp;the&nbsp;cells&nbsp;from&nbsp;a&nbsp;to&nbsp;f</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Range(cellA&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;:&quot;</span>&nbsp;&#43;&nbsp;cellF).Merge()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Assign&nbsp;a&nbsp;value&nbsp;to&nbsp;the&nbsp;cell,&nbsp;so&nbsp;that&nbsp;it&nbsp;can&nbsp;fill&nbsp;the&nbsp;contents&nbsp;of&nbsp;the&nbsp;cells&nbsp;to&nbsp;f</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellA).Value&nbsp;=&nbsp;<span class="visualBasic__string">&quot;USER&nbsp;DATA&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Check&nbsp;by&nbsp;enumeration&nbsp;XLAlignmentHorizontalValues​​,&nbsp;the&nbsp;alignment&nbsp;of&nbsp;text&nbsp;within&nbsp;the&nbsp;cell&nbsp;to&nbsp;be&nbsp;shown&nbsp;at&nbsp;the&nbsp;center</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellA).Style.Alignment.Horizontal&nbsp;=&nbsp;XLAlignmentHorizontalValues.Center&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellA).Style.Fill.BackgroundColor&nbsp;=&nbsp;XLColor.CornflowerBlue&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'default&nbsp;value&nbsp;for&nbsp;cell&nbsp;a&nbsp;and&nbsp;f</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellA&nbsp;=&nbsp;<span class="visualBasic__string">&quot;A&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellF&nbsp;=&nbsp;<span class="visualBasic__string">&quot;F&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;index&nbsp;equals&nbsp;2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;indexcell.Equals(<span class="visualBasic__number">2</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Allowance&nbsp;for&nbsp;cells&nbsp;and&nbsp;and&nbsp;the&nbsp;numerical&nbsp;value&nbsp;given&nbsp;by&nbsp;the&nbsp;variable&nbsp;i&nbsp;and&nbsp;indexcell</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellA&nbsp;&#43;=&nbsp;indexcell.ToString(CultureInfo.InvariantCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellB&nbsp;&#43;=&nbsp;indexcell.ToString(CultureInfo.InvariantCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellC&nbsp;&#43;=&nbsp;indexcell.ToString(CultureInfo.InvariantCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellD&nbsp;&#43;=&nbsp;indexcell.ToString(CultureInfo.InvariantCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellE&nbsp;&#43;=&nbsp;indexcell.ToString(CultureInfo.InvariantCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellF&nbsp;&#43;=&nbsp;indexcell.ToString(CultureInfo.InvariantCulture)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Here,&nbsp;however,&nbsp;we&nbsp;assign&nbsp;the&nbsp;cell&nbsp;to&nbsp;the&nbsp;cell&nbsp;f&nbsp;the&nbsp;name&nbsp;of&nbsp;the&nbsp;columns&nbsp;of&nbsp;the&nbsp;DataGrid&nbsp;control&nbsp;by&nbsp;property&nbsp;Value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellA).Value&nbsp;=&nbsp;dgvReport.Columns(<span class="visualBasic__number">1</span>).Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellB).Value&nbsp;=&nbsp;dgvReport.Columns(<span class="visualBasic__number">2</span>).Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellC).Value&nbsp;=&nbsp;dgvReport.Columns(<span class="visualBasic__number">3</span>).Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellD).Value&nbsp;=&nbsp;dgvReport.Columns(<span class="visualBasic__number">4</span>).Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellE).Value&nbsp;=&nbsp;dgvReport.Columns(<span class="visualBasic__number">5</span>).Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellF).Value&nbsp;=&nbsp;dgvReport.Columns(<span class="visualBasic__number">6</span>).Name&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Check&nbsp;by&nbsp;enumeration&nbsp;XLAlignmentHorizontalValues​​,&nbsp;the&nbsp;alignment&nbsp;of&nbsp;text&nbsp;within&nbsp;the&nbsp;cell&nbsp;to&nbsp;be&nbsp;shown&nbsp;at&nbsp;the&nbsp;center</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellA).Style.Alignment.Horizontal&nbsp;=&nbsp;XLAlignmentHorizontalValues.Center&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellB).Style.Alignment.Horizontal&nbsp;=&nbsp;XLAlignmentHorizontalValues.Center&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellC).Style.Alignment.Horizontal&nbsp;=&nbsp;XLAlignmentHorizontalValues.Center&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellD).Style.Alignment.Horizontal&nbsp;=&nbsp;XLAlignmentHorizontalValues.Center&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellE).Style.Alignment.Horizontal&nbsp;=&nbsp;XLAlignmentHorizontalValues.Center&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellF).Style.Alignment.Horizontal&nbsp;=&nbsp;XLAlignmentHorizontalValues.Center&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'default&nbsp;value&nbsp;for&nbsp;cell&nbsp;from&nbsp;a&nbsp;to&nbsp;f</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellA&nbsp;=&nbsp;<span class="visualBasic__string">&quot;A&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellB&nbsp;=&nbsp;<span class="visualBasic__string">&quot;B&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellC&nbsp;=&nbsp;<span class="visualBasic__string">&quot;C&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellD&nbsp;=&nbsp;<span class="visualBasic__string">&quot;D&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellE&nbsp;=&nbsp;<span class="visualBasic__string">&quot;E&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellF&nbsp;=&nbsp;<span class="visualBasic__string">&quot;F&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'In&nbsp;this&nbsp;loop&nbsp;will&nbsp;perform&nbsp;the&nbsp;control&nbsp;of&nbsp;the&nbsp;variable&nbsp;index&nbsp;and&nbsp;prodceder&agrave;&nbsp;to&nbsp;the&nbsp;writing&nbsp;of&nbsp;the&nbsp;values&nbsp;​​contained&nbsp;in&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'the&nbsp;DataGrid&nbsp;on&nbsp;the&nbsp;variables&nbsp;from&nbsp;cell&nbsp;to&nbsp;celfl,&nbsp;so&nbsp;pore&nbsp;actually&nbsp;write&nbsp;on&nbsp;the&nbsp;cells&nbsp;of&nbsp;the&nbsp;sheet&nbsp;excel</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;riga&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;dgvReport.Rows.Count&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;index&nbsp;equals&nbsp;3</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;indexcell&nbsp;&gt;&nbsp;<span class="visualBasic__number">3</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Allowance&nbsp;for&nbsp;cells&nbsp;and&nbsp;and&nbsp;the&nbsp;numerical&nbsp;value&nbsp;given&nbsp;by&nbsp;the&nbsp;variable&nbsp;i&nbsp;and&nbsp;indexcell</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellA&nbsp;&#43;=&nbsp;indexcell.ToString(CultureInfo.InvariantCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellB&nbsp;&#43;=&nbsp;indexcell.ToString(CultureInfo.InvariantCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellC&nbsp;&#43;=&nbsp;indexcell.ToString(CultureInfo.InvariantCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellD&nbsp;&#43;=&nbsp;indexcell.ToString(CultureInfo.InvariantCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellE&nbsp;&#43;=&nbsp;indexcell.ToString(CultureInfo.InvariantCulture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellF&nbsp;&#43;=&nbsp;indexcell.ToString(CultureInfo.InvariantCulture)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Here&nbsp;instead&nbsp;we&nbsp;assign&nbsp;from&nbsp;cell&nbsp;to&nbsp;cell&nbsp;f&nbsp;the&nbsp;value&nbsp;of&nbsp;each&nbsp;row&nbsp;in&nbsp;the&nbsp;DataGrid&nbsp;control&nbsp;and&nbsp;always&nbsp;through&nbsp;their&nbsp;Value&nbsp;property</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellA).Value&nbsp;=&nbsp;dgvReport.Rows(riga).Cells(<span class="visualBasic__number">1</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellB).Value&nbsp;=&nbsp;dgvReport.Rows(riga).Cells(<span class="visualBasic__number">2</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellC).Value&nbsp;=&nbsp;dgvReport.Rows(riga).Cells(<span class="visualBasic__number">3</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellD).Value&nbsp;=&nbsp;dgvReport.Rows(riga).Cells(<span class="visualBasic__number">4</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellE).Value&nbsp;=&nbsp;dgvReport.Rows(riga).Cells(<span class="visualBasic__number">5</span>).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellF).Value&nbsp;=&nbsp;dgvReport.Rows(riga).Cells(<span class="visualBasic__number">6</span>).Value&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Check&nbsp;by&nbsp;enumeration&nbsp;XLAlignmentHorizontalValues​​,&nbsp;the&nbsp;alignment&nbsp;of&nbsp;text&nbsp;within&nbsp;the&nbsp;cell&nbsp;to&nbsp;be&nbsp;shown&nbsp;at&nbsp;the&nbsp;center</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellA).Style.Alignment.Horizontal&nbsp;=&nbsp;XLAlignmentHorizontalValues.Center&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellB).Style.Alignment.Horizontal&nbsp;=&nbsp;XLAlignmentHorizontalValues.Center&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellC).Style.Alignment.Horizontal&nbsp;=&nbsp;XLAlignmentHorizontalValues.Center&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellD).Style.Alignment.Horizontal&nbsp;=&nbsp;XLAlignmentHorizontalValues.Center&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellE).Style.Alignment.Horizontal&nbsp;=&nbsp;XLAlignmentHorizontalValues.Center&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Cell(cellF).Style.Alignment.Horizontal&nbsp;=&nbsp;XLAlignmentHorizontalValues.Center&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'This&nbsp;method&nbsp;allows&nbsp;to&nbsp;adapt&nbsp;the&nbsp;text&nbsp;within&nbsp;the&nbsp;cells&nbsp;so&nbsp;that&nbsp;it&nbsp;is&nbsp;well&nbsp;centered&nbsp;and&nbsp;adapted&nbsp;to&nbsp;their&nbsp;inner</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;worksheet.Columns().AdjustToContents()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'default&nbsp;value&nbsp;for&nbsp;cell&nbsp;from&nbsp;a&nbsp;to&nbsp;f</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellA&nbsp;=&nbsp;<span class="visualBasic__string">&quot;A&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellB&nbsp;=&nbsp;<span class="visualBasic__string">&quot;B&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellC&nbsp;=&nbsp;<span class="visualBasic__string">&quot;C&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellD&nbsp;=&nbsp;<span class="visualBasic__string">&quot;D&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellE&nbsp;=&nbsp;<span class="visualBasic__string">&quot;E&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cellF&nbsp;=&nbsp;<span class="visualBasic__string">&quot;F&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'increase&nbsp;the&nbsp;value&nbsp;of&nbsp;the&nbsp;variable&nbsp;indexcell</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;indexcell&nbsp;&#43;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Here&nbsp;we&nbsp;give&nbsp;the&nbsp;user&nbsp;the&nbsp;possibility&nbsp;scegiere&nbsp;where&nbsp;to&nbsp;save&nbsp;the&nbsp;file&nbsp;which&nbsp;will&nbsp;then&nbsp;be&nbsp;generated&nbsp;using&nbsp;the&nbsp;SaveFileDialog</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;sfDialog.ShowDialog().Equals(DialogResult.OK)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'This&nbsp;method&nbsp;will&nbsp;save&nbsp;the&nbsp;file&nbsp;in&nbsp;xlsx&nbsp;excel&nbsp;where&nbsp;the&nbsp;user&nbsp;decide&nbsp;this&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'by&nbsp;the&nbsp;argument&nbsp;required&nbsp;by&nbsp;that&nbsp;method&nbsp;where&nbsp;we&nbsp;spend&nbsp;the&nbsp;path&nbsp;of&nbsp;destination</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;workbook.SaveAs(sfDialog.FileName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
Per un risultato finale del nostro file excel cos&igrave; strutturato.</div>
<div class="scriptcode"><img id="70772" src="70772-immagineclosedxml.png" alt="" width="1600" height="900"></div>
<p><em><em>&nbsp;</em></em></p>
<p>&nbsp;</p>
<h1>More Information</h1>
<p><em>&nbsp;</em></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div><em>
<div>Questo articolo&nbsp;e stato creato&nbsp;dalla collaborazione da parte di Piero Sbressa e Carmelo La Monica.Potete contattarli ai seguenti riferimenti.</div>
<div></div>
<div>Piero Sbressa</div>
<div></div>
<div><a href="mailto:pierosbressa@crystalweb.it">pierosbressa@crystalweb.it</a></div>
<div></div>
<div><a href="http://www.crystalweb.it/"><span style="text-decoration:underline"><span style="font-size:x-small"><span>www.crystalweb.it</span></span></span></a>
<br>
<span style="font-size:x-small">&nbsp;</span></div>
<div><span style="font-size:x-small">&nbsp;</span></div>
<div><span style="font-size:x-small">Carmelo La Monica</span></div>
<div><span style="font-size:x-small">&nbsp;</span></div>
<div><span style="font-size:x-small"><a href="http://community.visual-basic.it/carmelolamonica/default.aspx">http://community.visual-basic.it/carmelolamonica/default.aspx</a></span></div>
</em></div>
