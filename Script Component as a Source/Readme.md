# Script Component as a Source
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SSIS
- SQL Server Integration Services
- SSIS 2012
- SQL Server Integration Services 2012
## Topics
- SsisScriptComponentTransform
## Updated
- 04/03/2012
## Description

<h1>Introduction</h1>
<p><em>This basic demo shows how to use a Script Component as a source in an SSIS 2012 Data Flow.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Simply open the .sln file in Visual Studio 2010, or import the .dtsx file into an existing SSIS 2012 project.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>There are a variety of reasons why you may want to use a Script Component as a source in a data flow.&nbsp; A common scenario I have found is to generate your own data, perhaps for testing purposes.&nbsp; The included package file&nbsp;is setup to show&nbsp;how
 you configure a Script Component to generate&nbsp;sample CustomerID and CustomerName data elements, which can then be extended to fit your needs.</em></p>
<p>The following steps should be followed to be successful.</p>
<ol>
<li>Add a Script Component to an empty Data Flow design surface. </li><li>Double-click to edit the Script Component. </li><li>Click on the &quot;Inputs and Outputs&quot; tab. </li><li>Expand &quot;Output 0&quot; and then expand &quot;Output Columns.&quot; </li><li>Click on &quot;Output Columns&quot; to highlight it. </li><li>Click &quot;Add Column&quot; and title the new column CustomerID. </li><li>Click on &quot;Output Columns&quot; to highlight it again. </li><li>Click &quot;Add Column&quot; and title the new column CustomerName. </li><li>Set the data type for the CustomerName column to &quot;string [DT_STR]&quot; and set the length to 128.
</li><li>Click on the &quot;Script&quot; tab to go back to the screen from step #2. </li><li>Click on &quot;Edit Script...&quot; to bring up the code editor. </li><li>Include the code below then close the window.&nbsp; The CreateNewOutputRows() method is where we do the work.
</li><li>Click &quot;OK&quot; to close the Script Transformation Editor window. </li><li>Add a Data Conversion component and connect the Script Component to it so that the Data Conversion is after the Script Component.&nbsp; The Data Conversion component simply allows us to have a &quot;destination&quot; so that we can use a data viewer.
</li><li>Right-click on the data flow path between the two components and add a data viewer.
</li><li>Run the package and observe the new rows in the data viewer display window. </li></ol>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">#region Help:  Introduction to the Script Component
/* The Script Component allows you to perform virtually any operation that can be accomplished in
 * a .Net application within the context of an Integration Services data flow.
 *
 * Expand the other regions which have &quot;Help&quot; prefixes for examples of specific ways to use
 * Integration Services features within this script component. */
#endregion

#region Namespaces
using System;
using System.Data;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime.Wrapper;
#endregion

/// &lt;summary&gt;
/// This is the class to which to add your code.  Do not change the name, attributes, or parent
/// of this class.
/// &lt;/summary&gt;
[Microsoft.SqlServer.Dts.Pipeline.SSISScriptComponentEntryPointAttribute]
public class ScriptMain : UserComponent
{
    #region Help:  Using Integration Services variables and parameters
    /* To use a variable in this script, first ensure that the variable has been added to
     * either the list contained in the ReadOnlyVariables property or the list contained in
     * the ReadWriteVariables property of this script component, according to whether or not your
     * code needs to write into the variable.  To do so, save this script, close this instance of
     * Visual Studio, and update the ReadOnlyVariables and ReadWriteVariables properties in the
     * Script Transformation Editor window.
     * To use a parameter in this script, follow the same steps. Parameters are always read-only.
     *
     * Example of reading from a variable or parameter:
     *  DateTime startTime = Variables.MyStartTime;
     *
     * Example of writing to a variable:
     *  Variables.myStringVariable = &quot;new value&quot;;
     */
    #endregion

    #region Help:  Using Integration Services Connnection Managers
    /* Some types of connection managers can be used in this script component.  See the help topic
     * &quot;Working with Connection Managers Programatically&quot; for details.
     *
     * To use a connection manager in this script, first ensure that the connection manager has
     * been added to either the list of connection managers on the Connection Managers page of the
     * script component editor.  To add the connection manager, save this script, close this instance of
     * Visual Studio, and add the Connection Manager to the list.
     *
     * If the component needs to hold a connection open while processing rows, override the
     * AcquireConnections and ReleaseConnections methods.
     * 
     * Example of using an ADO.Net connection manager to acquire a SqlConnection:
     *  object rawConnection = Connections.SalesDB.AcquireConnection(transaction);
     *  SqlConnection salesDBConn = (SqlConnection)rawConnection;
     *
     * Example of using a File connection manager to acquire a file path:
     *  object rawConnection = Connections.Prices_zip.AcquireConnection(transaction);
     *  string filePath = (string)rawConnection;
     *
     * Example of releasing a connection manager:
     *  Connections.SalesDB.ReleaseConnection(rawConnection);
     */
    #endregion

    #region Help:  Firing Integration Services Events
    /* This script component can fire events.
     *
     * Example of firing an error event:
     *  ComponentMetaData.FireError(10, &quot;Process Values&quot;, &quot;Bad value&quot;, &quot;&quot;, 0, out cancel);
     *
     * Example of firing an information event:
     *  ComponentMetaData.FireInformation(10, &quot;Process Values&quot;, &quot;Processing has started&quot;, &quot;&quot;, 0, fireAgain);
     *
     * Example of firing a warning event:
     *  ComponentMetaData.FireWarning(10, &quot;Process Values&quot;, &quot;No rows were received&quot;, &quot;&quot;, 0);
     */
    #endregion

    public override void PreExecute()
    {
        base.PreExecute();
        /*
         * Add your code here to execute before rows are
         * generated and right after the component has started
         */
    }

    public override void PostExecute()
    {
        base.PostExecute();
        /*
         * Add your code here to execute after all rows 
         * have been generated and the component has finished
         */
    }

    public override void CreateNewOutputRows()
    {
        Output0Buffer.AddRow();
        Output0Buffer.CustomerID = 1;
        Output0Buffer.CustomerName = @&quot;Phil Brammer&quot;;

        Output0Buffer.AddRow();
        Output0Buffer.CustomerID = 2;
        Output0Buffer.CustomerName = @&quot;John Adams&quot;;

        /* etc... */
    }

}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__preproc">#region&nbsp;Help:&nbsp;&nbsp;Introduction&nbsp;to&nbsp;the&nbsp;Script&nbsp;Component</span>&nbsp;
<span class="cs__mlcom">/*&nbsp;The&nbsp;Script&nbsp;Component&nbsp;allows&nbsp;you&nbsp;to&nbsp;perform&nbsp;virtually&nbsp;any&nbsp;operation&nbsp;that&nbsp;can&nbsp;be&nbsp;accomplished&nbsp;in&nbsp;
&nbsp;*&nbsp;a&nbsp;.Net&nbsp;application&nbsp;within&nbsp;the&nbsp;context&nbsp;of&nbsp;an&nbsp;Integration&nbsp;Services&nbsp;data&nbsp;flow.&nbsp;
&nbsp;*&nbsp;
&nbsp;*&nbsp;Expand&nbsp;the&nbsp;other&nbsp;regions&nbsp;which&nbsp;have&nbsp;&quot;Help&quot;&nbsp;prefixes&nbsp;for&nbsp;examples&nbsp;of&nbsp;specific&nbsp;ways&nbsp;to&nbsp;use&nbsp;
&nbsp;*&nbsp;Integration&nbsp;Services&nbsp;features&nbsp;within&nbsp;this&nbsp;script&nbsp;component.&nbsp;*/</span><span class="cs__preproc">&nbsp;
#endregion</span><span class="cs__preproc">&nbsp;
&nbsp;
#region&nbsp;Namespaces</span>&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.SqlServer.Dts.Pipeline.Wrapper;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.SqlServer.Dts.Runtime.Wrapper;<span class="cs__preproc">&nbsp;
#endregion</span>&nbsp;
&nbsp;
<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;This&nbsp;is&nbsp;the&nbsp;class&nbsp;to&nbsp;which&nbsp;to&nbsp;add&nbsp;your&nbsp;code.&nbsp;&nbsp;Do&nbsp;not&nbsp;change&nbsp;the&nbsp;name,&nbsp;attributes,&nbsp;or&nbsp;parent</span>&nbsp;
<span class="cs__com">///&nbsp;of&nbsp;this&nbsp;class.</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
[Microsoft.SqlServer.Dts.Pipeline.SSISScriptComponentEntryPointAttribute]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ScriptMain&nbsp;:&nbsp;UserComponent&nbsp;
{<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Help:&nbsp;&nbsp;Using&nbsp;Integration&nbsp;Services&nbsp;variables&nbsp;and&nbsp;parameters</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*&nbsp;To&nbsp;use&nbsp;a&nbsp;variable&nbsp;in&nbsp;this&nbsp;script,&nbsp;first&nbsp;ensure&nbsp;that&nbsp;the&nbsp;variable&nbsp;has&nbsp;been&nbsp;added&nbsp;to&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;either&nbsp;the&nbsp;list&nbsp;contained&nbsp;in&nbsp;the&nbsp;ReadOnlyVariables&nbsp;property&nbsp;or&nbsp;the&nbsp;list&nbsp;contained&nbsp;in&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;the&nbsp;ReadWriteVariables&nbsp;property&nbsp;of&nbsp;this&nbsp;script&nbsp;component,&nbsp;according&nbsp;to&nbsp;whether&nbsp;or&nbsp;not&nbsp;your&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;code&nbsp;needs&nbsp;to&nbsp;write&nbsp;into&nbsp;the&nbsp;variable.&nbsp;&nbsp;To&nbsp;do&nbsp;so,&nbsp;save&nbsp;this&nbsp;script,&nbsp;close&nbsp;this&nbsp;instance&nbsp;of&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Visual&nbsp;Studio,&nbsp;and&nbsp;update&nbsp;the&nbsp;ReadOnlyVariables&nbsp;and&nbsp;ReadWriteVariables&nbsp;properties&nbsp;in&nbsp;the&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Script&nbsp;Transformation&nbsp;Editor&nbsp;window.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;To&nbsp;use&nbsp;a&nbsp;parameter&nbsp;in&nbsp;this&nbsp;script,&nbsp;follow&nbsp;the&nbsp;same&nbsp;steps.&nbsp;Parameters&nbsp;are&nbsp;always&nbsp;read-only.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Example&nbsp;of&nbsp;reading&nbsp;from&nbsp;a&nbsp;variable&nbsp;or&nbsp;parameter:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;&nbsp;DateTime&nbsp;startTime&nbsp;=&nbsp;Variables.MyStartTime;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Example&nbsp;of&nbsp;writing&nbsp;to&nbsp;a&nbsp;variable:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;&nbsp;Variables.myStringVariable&nbsp;=&nbsp;&quot;new&nbsp;value&quot;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span><span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span><span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Help:&nbsp;&nbsp;Using&nbsp;Integration&nbsp;Services&nbsp;Connnection&nbsp;Managers</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*&nbsp;Some&nbsp;types&nbsp;of&nbsp;connection&nbsp;managers&nbsp;can&nbsp;be&nbsp;used&nbsp;in&nbsp;this&nbsp;script&nbsp;component.&nbsp;&nbsp;See&nbsp;the&nbsp;help&nbsp;topic&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;&quot;Working&nbsp;with&nbsp;Connection&nbsp;Managers&nbsp;Programatically&quot;&nbsp;for&nbsp;details.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;To&nbsp;use&nbsp;a&nbsp;connection&nbsp;manager&nbsp;in&nbsp;this&nbsp;script,&nbsp;first&nbsp;ensure&nbsp;that&nbsp;the&nbsp;connection&nbsp;manager&nbsp;has&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;been&nbsp;added&nbsp;to&nbsp;either&nbsp;the&nbsp;list&nbsp;of&nbsp;connection&nbsp;managers&nbsp;on&nbsp;the&nbsp;Connection&nbsp;Managers&nbsp;page&nbsp;of&nbsp;the&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;script&nbsp;component&nbsp;editor.&nbsp;&nbsp;To&nbsp;add&nbsp;the&nbsp;connection&nbsp;manager,&nbsp;save&nbsp;this&nbsp;script,&nbsp;close&nbsp;this&nbsp;instance&nbsp;of&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Visual&nbsp;Studio,&nbsp;and&nbsp;add&nbsp;the&nbsp;Connection&nbsp;Manager&nbsp;to&nbsp;the&nbsp;list.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;If&nbsp;the&nbsp;component&nbsp;needs&nbsp;to&nbsp;hold&nbsp;a&nbsp;connection&nbsp;open&nbsp;while&nbsp;processing&nbsp;rows,&nbsp;override&nbsp;the&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;AcquireConnections&nbsp;and&nbsp;ReleaseConnections&nbsp;methods.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Example&nbsp;of&nbsp;using&nbsp;an&nbsp;ADO.Net&nbsp;connection&nbsp;manager&nbsp;to&nbsp;acquire&nbsp;a&nbsp;SqlConnection:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;&nbsp;object&nbsp;rawConnection&nbsp;=&nbsp;Connections.SalesDB.AcquireConnection(transaction);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;&nbsp;SqlConnection&nbsp;salesDBConn&nbsp;=&nbsp;(SqlConnection)rawConnection;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Example&nbsp;of&nbsp;using&nbsp;a&nbsp;File&nbsp;connection&nbsp;manager&nbsp;to&nbsp;acquire&nbsp;a&nbsp;file&nbsp;path:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;&nbsp;object&nbsp;rawConnection&nbsp;=&nbsp;Connections.Prices_zip.AcquireConnection(transaction);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;&nbsp;string&nbsp;filePath&nbsp;=&nbsp;(string)rawConnection;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Example&nbsp;of&nbsp;releasing&nbsp;a&nbsp;connection&nbsp;manager:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;&nbsp;Connections.SalesDB.ReleaseConnection(rawConnection);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span><span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span><span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Help:&nbsp;&nbsp;Firing&nbsp;Integration&nbsp;Services&nbsp;Events</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*&nbsp;This&nbsp;script&nbsp;component&nbsp;can&nbsp;fire&nbsp;events.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Example&nbsp;of&nbsp;firing&nbsp;an&nbsp;error&nbsp;event:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;&nbsp;ComponentMetaData.FireError(10,&nbsp;&quot;Process&nbsp;Values&quot;,&nbsp;&quot;Bad&nbsp;value&quot;,&nbsp;&quot;&quot;,&nbsp;0,&nbsp;out&nbsp;cancel);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Example&nbsp;of&nbsp;firing&nbsp;an&nbsp;information&nbsp;event:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;&nbsp;ComponentMetaData.FireInformation(10,&nbsp;&quot;Process&nbsp;Values&quot;,&nbsp;&quot;Processing&nbsp;has&nbsp;started&quot;,&nbsp;&quot;&quot;,&nbsp;0,&nbsp;fireAgain);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Example&nbsp;of&nbsp;firing&nbsp;a&nbsp;warning&nbsp;event:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;&nbsp;ComponentMetaData.FireWarning(10,&nbsp;&quot;Process&nbsp;Values&quot;,&nbsp;&quot;No&nbsp;rows&nbsp;were&nbsp;received&quot;,&nbsp;&quot;&quot;,&nbsp;0);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span><span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;PreExecute()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.PreExecute();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Add&nbsp;your&nbsp;code&nbsp;here&nbsp;to&nbsp;execute&nbsp;before&nbsp;rows&nbsp;are&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;generated&nbsp;and&nbsp;right&nbsp;after&nbsp;the&nbsp;component&nbsp;has&nbsp;started&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;PostExecute()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.PostExecute();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Add&nbsp;your&nbsp;code&nbsp;here&nbsp;to&nbsp;execute&nbsp;after&nbsp;all&nbsp;rows&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;have&nbsp;been&nbsp;generated&nbsp;and&nbsp;the&nbsp;component&nbsp;has&nbsp;finished&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CreateNewOutputRows()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Output0Buffer.AddRow();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Output0Buffer.CustomerID&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Output0Buffer.CustomerName&nbsp;=&nbsp;@<span class="cs__string">&quot;Phil&nbsp;Brammer&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Output0Buffer.AddRow();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Output0Buffer.CustomerID&nbsp;=&nbsp;<span class="cs__number">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Output0Buffer.CustomerName&nbsp;=&nbsp;@<span class="cs__string">&quot;John&nbsp;Adams&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*&nbsp;etc...&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>ScriptComponentAsSource.dtsx&nbsp;- The physical SSIS file used in this demo.&nbsp;
</em></li></ul>
<h1><em>&nbsp;</em></h1>
