# Simple data binding and add/editing data on windows forms
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Data Binding
- ADO.NET
- Windows Forms
- VB.Net
## Topics
- Controls
- Data Binding
- User Interface
## Updated
- 09/04/2013
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">This article explains how to display data in common controls like TextBox and DataGridView controls where the data source comes from a DataTable. You can read through the following but I recommend looking at the code and run
 the solution first.</span></p>
<p><strong><span style="font-size:small">Special note</span></strong><span style="font-size:small"> there are lots of cool things going on in this solution, please take the time to study them and if there are questions ask about them.</span></p>
<p><span style="font-size:small">Although Visual Studio is capable of generating strong typed classes for your database tables there are times when these methods do not fit into your project so the alternate is to hand write retrieval of data along with add/edit/delete
 operations. This article goes part of the way in that I explain how to data bind a very simple DataTable to a DataGridView and TextBox controls keeping form code to a minimum. What is missing? reading and writing to a backend database. An important thing to
 know when reading the following information is that I first coded everything in the main form, no code in the child form at all then once everything worked properly split parts up into other projects. I mention this because when working on solutions at work
 I have pre-built code in libraries (generally class projects) that are for lack of better terms &quot;plug-and-play&quot;. For example, to access a database I have classes that follow a singleton pattern for all data providers I may encounter but when looking at code
 for SqlClient vs IBM-DB2 there is no visual difference (getting a tad of track here). So my point here is to always consider breaking up code that can be re-used along with the tendency to write code in a form which at a later date is not easily ported off
 Desktop style of solutions.</span></p>
<p><span style="font-size:small">Okay, the main concept here is not to touch any form control unless we need too but instead work with data objects. Example, to get a record in a DataGridView don't access the data via the cell property of a row but instead
 from the underlying data source which in this case is a DataTable which we track by assigning the DataTable to a BindingSource and the BindingSource becomes the data source of a DataGridView and two TextBox controls. Movement thru the rows/records is achieved
 by moving up/down rows in the DataGridView. I also tossed in a BindingNavigator for moving up/down rows of data.</span></p>
<p><span style="font-size:small">The data is loaded in the form load event which really needs no explanation other than (if you never manually bound fields to controls) how the data-binding is done on the last two lines of the load event. Note that in the event
 procedure I bind two TextBox controls the same way as in the form load event in the main form rather than make any effort to do &quot;hey how do I access the calling form's data&quot; as we are here and have access to both the data and the child edit form why not do
 the data binding here rather than go thru hoops which is uncalled for especially now since you have a working example.</span></p>
<p><span style="font-size:small">In EditCurrentRow() procedure which is responsible for editing the current record the base logic is as follows. On the child form there are two buttons with no code but instead I set DialogResult for both buttons which when
 pressing either one the form closes because we set DialogResult and control is return to the caller (main form) that checks what the DialogResult was. If the user presses the system close button our test sees this as a cancel, do not update the current record
 while pressing the button with a DialogResult of OK triggers an update to the data. The updates are all done in bsData.AcceptChanges() which is in the project LanguageExtensions shown below which in short tells the DataTable to accept changes for the current
 DataRow which we get to by knowing the Current property of the BindingSource is a DataRowView and a DataRowView has a Row property of type DataRow</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">&lt;System.Diagnostics.DebuggerStepThrough()&gt; _
&lt;System.Runtime.CompilerServices.Extension()&gt; _
Public Sub AcceptChanges(ByVal sender As Windows.Forms.BindingSource)
    CType(sender.Current, DataRowView).Row.AcceptChanges()
End Sub</pre>
<div class="preview">
<pre class="js">&lt;System.Diagnostics.DebuggerStepThrough()&gt;&nbsp;_&nbsp;
&lt;System.Runtime.CompilerServices.Extension()&gt;&nbsp;_&nbsp;
Public&nbsp;Sub&nbsp;AcceptChanges(ByVal&nbsp;sender&nbsp;As&nbsp;Windows.Forms.BindingSource)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CType(sender.Current,&nbsp;DataRowView).Row.AcceptChanges()&nbsp;
End&nbsp;Sub</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><span style="font-size:small">The exact same form is used for adding records, this is where we need one line of code to enable/disable a button to permit adding a row where first and last name has some kind of value. Since both forms are shared this code
 is wrapped in a logic if statement so it is not used in the edit mode.</span></p>
<p><span style="font-size:small">If you look at the add code (directly below this paragraph)&nbsp;in the main form not much is going on yet under the covers there is a decent amount happening. By taking time and studying what is going on I believe this will
 help you use similar code in your project with little effort.</span></p>
<div><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Private Sub AddNewRecord()
    Dim f As New frmEditForm

    Try
        f.Text = &quot;Add new&quot;
        f.cmdAccept.Enabled = False
        f.AddingNewRecord = True

        If f.ShowDialog = Windows.Forms.DialogResult.OK Then
            bsData.AddPerson(f.txtFirstName.Text, f.txtLastName.Text)
        End If
    Finally
        f.Dispose()
    End Try
End Sub</pre>
<div class="preview">
<pre class="js">Private&nbsp;Sub&nbsp;AddNewRecord()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;f&nbsp;As&nbsp;New&nbsp;frmEditForm&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.Text&nbsp;=&nbsp;<span class="js__string">&quot;Add&nbsp;new&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.cmdAccept.Enabled&nbsp;=&nbsp;False&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.AddingNewRecord&nbsp;=&nbsp;True&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;f.ShowDialog&nbsp;=&nbsp;Windows.Forms.DialogResult.OK&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bsData.AddPerson(f.txtFirstName.Text,&nbsp;f.txtLastName.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Finally&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Try&nbsp;
End&nbsp;Sub</pre>
</div>
</div>
</div>
</span></div>
<p><span style="font-size:small">If you have read some of my other articles you will see several of the extension methods that are similar. What I like about language extension methods is when named properly and used properly they make your code a) easy to
 read b) re-usable c) keep (lets call it ugly) ugly code down below as when working at a high level we need not see this code just know that it works and that we can if needed get to this code.</span></p>
<p>&nbsp;<span style="font-size:small">Lastly, remember in the beginning I mentioned there is no code to read or write to a backend database? Well I will be updating this article shortly by adding another windows form project that will work with a backend database
 to show how to integrate the current windows form project to work with a backend database. Keeping things separated makes it easier to learn how to work data binding then work with SQL in tangent with data binding.</span></p>
<p><span style="font-size:small"><img id="95324" src="95324-s1.jpg" alt="" width="600" height="412"></span></p>
<p>&nbsp;&nbsp;</p>
<div class="endscriptcode"><span style="font-size:small">Now here is the supporting code for the form code above</span></div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">&lt;System.Diagnostics.DebuggerStepThrough()&gt; _
&lt;System.Runtime.CompilerServices.Extension()&gt; _
Public Function DataTable(ByVal sender As Windows.Forms.BindingSource) As DataTable
    Return DirectCast(sender.DataSource, DataTable)
End Function
''' &lt;summary&gt;
''' Add a new person to the underlying DataTable and position
''' it properly to the current row of the BindingSource.
''' &lt;/summary&gt;
''' &lt;param name=&quot;sender&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;FirstName&quot;&gt;&lt;/param&gt;
''' &lt;param name=&quot;LastName&quot;&gt;&lt;/param&gt;
''' &lt;returns&gt;current row primary key&lt;/returns&gt;
''' &lt;remarks&gt;
''' Like many things we first code the entire operation in this case the 
''' form then once it works as we want remove it from the form.
''' 
''' On the use of ProperCase, 
'''   * We could work this w/o passing a culture code
'''   * We could also make ProperCase available outside this project
''' I did both different from the norm to get those looking at this code to
''' think about other possibilities i.e. perhaps we truly want to force ProperCase
''' to English etc.
''' 
''' &lt;/remarks&gt;
&lt;System.Diagnostics.DebuggerStepThrough()&gt; _
&lt;System.Runtime.CompilerServices.Extension()&gt; _
Public Function AddPerson(
    ByVal sender As Windows.Forms.BindingSource,
    ByVal FirstName As String,
    ByVal LastName As String) As Int32

    Dim dt As DataTable = sender.DataTable
    dt.Rows.Add(New Object() _
        {
            Nothing,
            FirstName.ProperCaseEnglish,
            LastName.ProperCaseEnglish
        }
    )

    Dim NewRowIdentifier As Int32 =
        CInt(dt.Rows.Item(dt.Rows.Count - 1) _
            .Field(Of Int32)(dt.Columns(&quot;Identifier&quot;)))

    sender.Position = sender.Find(&quot;Identifier&quot;, NewRowIdentifier)

    Return NewRowIdentifier

End Function
</pre>
<div class="preview">
<pre class="js">&lt;System.Diagnostics.DebuggerStepThrough()&gt;&nbsp;_&nbsp;
&lt;System.Runtime.CompilerServices.Extension()&gt;&nbsp;_&nbsp;
Public&nbsp;<span class="js__object">Function</span>&nbsp;DataTable(ByVal&nbsp;sender&nbsp;As&nbsp;Windows.Forms.BindingSource)&nbsp;As&nbsp;DataTable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;DirectCast(sender.DataSource,&nbsp;DataTable)&nbsp;
End&nbsp;<span class="js__object">Function</span>&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
<span class="js__string">''</span>'&nbsp;Add&nbsp;a&nbsp;<span class="js__operator">new</span>&nbsp;person&nbsp;to&nbsp;the&nbsp;underlying&nbsp;DataTable&nbsp;and&nbsp;position&nbsp;
<span class="js__string">''</span>'&nbsp;it&nbsp;properly&nbsp;to&nbsp;the&nbsp;current&nbsp;row&nbsp;of&nbsp;the&nbsp;BindingSource.&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;param&nbsp;name=<span class="js__string">&quot;sender&quot;</span>&gt;&lt;/param&gt;&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;param&nbsp;name=<span class="js__string">&quot;FirstName&quot;</span>&gt;&lt;/param&gt;&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;param&nbsp;name=<span class="js__string">&quot;LastName&quot;</span>&gt;&lt;/param&gt;&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;returns&gt;current&nbsp;row&nbsp;primary&nbsp;key&lt;/returns&gt;&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;remarks&gt;&nbsp;
<span class="js__string">''</span>'&nbsp;Like&nbsp;many&nbsp;things&nbsp;we&nbsp;first&nbsp;code&nbsp;the&nbsp;entire&nbsp;operation&nbsp;<span class="js__operator">in</span>&nbsp;<span class="js__operator">this</span>&nbsp;<span class="js__statement">case</span>&nbsp;the&nbsp;&nbsp;
<span class="js__string">''</span>'&nbsp;form&nbsp;then&nbsp;once&nbsp;it&nbsp;works&nbsp;as&nbsp;we&nbsp;want&nbsp;remove&nbsp;it&nbsp;from&nbsp;the&nbsp;form.&nbsp;
<span class="js__string">''</span>'&nbsp;&nbsp;
<span class="js__string">''</span>'&nbsp;On&nbsp;the&nbsp;use&nbsp;of&nbsp;ProperCase,&nbsp;&nbsp;
<span class="js__string">''</span>'&nbsp;&nbsp;&nbsp;*&nbsp;We&nbsp;could&nbsp;work&nbsp;<span class="js__operator">this</span>&nbsp;w/o&nbsp;passing&nbsp;a&nbsp;culture&nbsp;code&nbsp;
<span class="js__string">''</span>'&nbsp;&nbsp;&nbsp;*&nbsp;We&nbsp;could&nbsp;also&nbsp;make&nbsp;ProperCase&nbsp;available&nbsp;outside&nbsp;<span class="js__operator">this</span>&nbsp;project&nbsp;
<span class="js__string">''</span>'&nbsp;I&nbsp;did&nbsp;both&nbsp;different&nbsp;from&nbsp;the&nbsp;norm&nbsp;to&nbsp;get&nbsp;those&nbsp;looking&nbsp;at&nbsp;<span class="js__operator">this</span>&nbsp;code&nbsp;to&nbsp;
<span class="js__string">''</span>'&nbsp;think&nbsp;about&nbsp;other&nbsp;possibilities&nbsp;i.e.&nbsp;perhaps&nbsp;we&nbsp;truly&nbsp;want&nbsp;to&nbsp;force&nbsp;ProperCase&nbsp;
<span class="js__string">''</span>'&nbsp;to&nbsp;English&nbsp;etc.&nbsp;
<span class="js__string">''</span>'&nbsp;&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;/remarks&gt;&nbsp;
&lt;System.Diagnostics.DebuggerStepThrough()&gt;&nbsp;_&nbsp;
&lt;System.Runtime.CompilerServices.Extension()&gt;&nbsp;_&nbsp;
Public&nbsp;<span class="js__object">Function</span>&nbsp;AddPerson(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ByVal&nbsp;sender&nbsp;As&nbsp;Windows.Forms.BindingSource,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ByVal&nbsp;FirstName&nbsp;As&nbsp;<span class="js__object">String</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ByVal&nbsp;LastName&nbsp;As&nbsp;<span class="js__object">String</span>)&nbsp;As&nbsp;Int32&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;dt&nbsp;As&nbsp;DataTable&nbsp;=&nbsp;sender.DataTable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(New&nbsp;<span class="js__object">Object</span>()&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Nothing,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FirstName.ProperCaseEnglish,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LastName.ProperCaseEnglish&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;NewRowIdentifier&nbsp;As&nbsp;Int32&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CInt(dt.Rows.Item(dt.Rows.Count&nbsp;-&nbsp;<span class="js__num">1</span>)&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Field(Of&nbsp;Int32)(dt.Columns(<span class="js__string">&quot;Identifier&quot;</span>)))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sender.Position&nbsp;=&nbsp;sender.Find(<span class="js__string">&quot;Identifier&quot;</span>,&nbsp;NewRowIdentifier)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;NewRowIdentifier&nbsp;
&nbsp;
End&nbsp;<span class="js__object">Function</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode" style="text-align:left">&nbsp;</div>
</span></div>
