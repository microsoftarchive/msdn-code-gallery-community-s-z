# VSTO - How to Customize Outlook's User Interface (Visual Studio 2012)
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- .NET Framework 4
- Outlook 2013
- Microsoft Office Outlook 2013
## Topics
- VSTO
- Microsoft Office Add-ins
- Outlook UI
- Microsoft Office Customizations
## Updated
- 09/07/2012
## Description

<h1>Introduction</h1>
<div>This sample runs in Microsoft Office Outlook 2013.<br>
<br>
This sample demonstrates how to customize the user interface (UI) of Microsoft Office Outlook 2013by implementing extensibility interfaces in an add-in. This sample uses extensibility interfaces to create a Ribbon customization, a custom task pane, and a custom
 form region.<br>
<br>
This sample also demonstrates one way to coordinate custom UI elements for a specific Inspector window. The code in this sample ensures that the Ribbon customization, custom task pane, and custom form region in an Inspector can correctly communicate with each
 other. They must communicate in a manner that is isolated from other instances of these custom UI elements that might be open in other Inspectors.<br>
<br>
For example, the user might have several Inspectors open, each of which has a custom Ribbon, task pane, and form region. When the user interacts with one of these elements&mdash;for example, by clicking a button on the Ribbon&mdash;it can cause a change in
 another element&mdash;for example, hiding the task pane. The code must ensure that only the elements in the one Inspector are affected, and not other instances of these custom UI elements in other Inspectors.<br>
<br>
This sample uses a set of classes that wrap Inspector and custom task pane objects to ensure that a new task pane is displayed with every task and e-mail message that the user opens. The sample also creates custom Ribbon buttons that can be used to hide or
 display the task pane in each task or e-mail message, and it displays a custom form region in each task. For more information about the structure of this sample, see Components of the UI Manager Sample.<br>
<br>
For information about how to install the sample project on your computer, see How to: Install and Use Sample Files Found in Help.</div>
<div></div>
<div><strong>Note:</strong><br>
<br>
Although this sample uses extensibility interfaces to create a Ribbon customization, a custom task pane, and a form region, Visual Studio Tools for Office provides classes and designers that you can use instead. These classes and designers simplify the process
 of working with these features. For more information, see Ribbon Designer, Custom Task Panes Overview, and Creating Outlook Form Regions.<br>
<br>
<strong>Security Note:</strong><br>
<br>
This sample code is intended to illustrate a concept, and it shows only the code that is relevant to that concept. It may not meet the security requirements for a specific environment, and it should not be used exactly as shown. We recommend that you add security
 and error-handling code to make your projects more secure and robust. Microsoft provides this sample code &quot;AS IS&quot; with no warranties.</div>
<h1>Requirements</h1>
<p>This sample requires the following applications:</p>
<ul>
<li>An edition of that includes the Microsoft Office developer tools. </li><li>Microsoft Office Outlook 2013. </li></ul>
<h1><span></span></h1>
<h1><span>Building the Sample</span></h1>
<div></div>
<ol>
<li>Right click on the UIManagerOutlookAddIn project in Solution Explorer and select Set as StartUp Project. Press F5.
</li><li>In Outlook, create a new task. </li><li>On the Ribbon of the task, click the Add-Ins tab. </li><li>In the UI Manager group, click the TaskPane button. </li><li>Verify that the SimpleControl task pane appears next to the task window. </li><li>In the Show group, click the UIM button. </li><li>Verify that the custom form region appears in the Reading Pane of the open task. The form region displays a list of coffee beans and a text box that contains the number of coffee orders that have been placed.
</li><li>Select one or more types of coffee beans in the form region. </li><li>Verify that each type of coffee bean you select is added to the SimpleControl task pane.
</li><li>On the Ribbon, in the Add-in Services group, click theSend button. </li><li>Verify that a new e-mail message is sent to the recipient <a href="mailto:someone@example.com">
someone@example.com</a>, and the e-mail message contains all of the types of coffee beans that you selected in the form region. Because the e-mail message represents a coffee order, the number of placed orders on the form region is incremented.
</li></ol>
<div></div>
<div><span style="font-size:20px; font-weight:bold">Description</span></div>
<div></div>
<div>This sample demonstrates the following concepts:</div>
<ul>
<li>Creating a Ribbon customization by implementing the Microsoft.Office.Core.IRibbonExtensibility interface in an add-in.
</li><li>Creating a custom task pane by implementing the Microsoft.Office.Core.ICustomTaskPaneConsumer interface in an add-in.
</li><li>Creating a custom form region by implementing the Microsoft.Office.Interop.Outlook.FormRegionStartup interface in an add-in.
</li><li>Managing and synchronizing the Ribbon customization, custom task pane, and form region in different e-mail messages and tasks in Outlook.
</li></ul>
<div></div>
<div>Components of the UI Manager Sample</div>
<div></div>
<div>
<p>The sample solution includes two projects:</p>
<ul>
<li>
<p>Microsoft.Samples.Vsto.UiManager is an add-in project for Outlook. This project contains the implementations of the extensibility interfaces, and other classes and files that support these implementations.</p>
</li><li>
<p>Microsoft.Samples.Vsto.AddinUtilities is a class library that includes UI management classes and interfaces that are used by the Outlook add-in project.</p>
</li></ul>
<p>These projects provide components that implement the custom task pane, Ribbon customization, and form region, and also components that help to synchronize and manage these features.</p>
<h1 class="subHeading">UI Management Components</h1>
<div class="subsection">
<p>The following table describes the project files that provide code for the Ribbon customization.</p>
<div class="tableSection">
<table cellspacing="2" cellpadding="5" width="50%" frame="lhs">
<tbody>
<tr>
<th>
<p>File</p>
</th>
<th>
<p>Description</p>
</th>
</tr>
<tr>
<td>
<p>ThisAddIn.cs/vb</p>
</td>
<td>
<p>Contains the override of the RequestService method and code that creates a new custom task pane for every Inspector window. For more information about this method, see Customizing UI Features By Using Extensibility Interfaces.</p>
</td>
</tr>
<tr>
<td>
<p>UserInterfaceContainer.cs/vb</p>
</td>
<td>
<p>Defines the <span class="code">UserInterfaceContainer</span> class. Each <span class="code">
UserInterfaceContainer</span> object manages the form region, task pane, and Ribbon customization for a single e-mail message or task.</p>
</td>
</tr>
<tr>
<td>
<p>UserInterfaceElements.cs/vb</p>
</td>
<td>
<p>Defines the <span class="code">UserInterfaceElements</span> class. This maintains the collection of<span class="code">UserInterfaceContainter</span> objects used by the add-in.</p>
</td>
</tr>
<tr>
<td>
<p>IFormRegionControls.cs/vb</p>
<p>IRibbonConnector.cs/vb</p>
</td>
<td>
<p>Defines interfaces that several classes in the Microsoft.Samples.Vsto.UiManager and Microsoft.Samples.Vsto.AddinUtilities projects use to communicate with each other.</p>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<h4 class="subHeading">Custom Task Pane Components</h4>
<div class="subsection">
<p>The following table describes the project files that provide code for the custom task pane.</p>
<div class="tableSection">
<table cellspacing="2" cellpadding="5" width="50%" frame="lhs">
<tbody>
<tr>
<th>
<p>File</p>
</th>
<th>
<p>Description</p>
</th>
</tr>
<tr>
<td>
<p>TaskPaneConnector.cs/vb</p>
</td>
<td>
<p>Defines the <span class="code">TaskPaneConnector</span> class. This class implements the<strong>
<a class="libraryLink" title="Auto generated link to Microsoft.Office.Core.ICustomTaskPaneConsumer" href="http://msdn.microsoft.com/en-US/library/Microsoft.Office.Core.ICustomTaskPaneConsumer.aspx" target="_blank">
Microsoft.Office.Core.ICustomTaskPaneConsumer</a></strong> interface.</p>
</td>
</tr>
<tr>
<td>
<p>SimpleControl.cs/vb</p>
</td>
<td>
<p>Defines the UserControl that provides the UI of the custom task pane. This control has attributes that expose the control to COM.</p>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<h3 class="subHeading">Ribbon Components</h3>
<div class="subsection">
<p>The following table describes the project files that provide code for the Ribbon customization.</p>
<div class="tableSection">
<table cellspacing="2" cellpadding="5" width="50%" frame="lhs">
<tbody>
<tr>
<th>
<p>File</p>
</th>
<th>
<p>Description</p>
</th>
</tr>
<tr>
<td>
<p>RibbonConnector.cs/vb</p>
</td>
<td>
<p>Defines the <span class="code">RibbonConnector</span> class. This class implements the<strong>
<a class="libraryLink" title="Auto generated link to Microsoft.Office.Core.IRibbonExtensibility" href="http://msdn.microsoft.com/en-US/library/Microsoft.Office.Core.IRibbonExtensibility.aspx" target="_blank">
Microsoft.Office.Core.IRibbonExtensibility</a></strong> interface.</p>
</td>
</tr>
<tr>
<td>
<p>SimpleRibbon.xml</p>
<p>TaskRibbon.xml</p>
</td>
<td>
<p>Contains the Ribbon XML strings that are returned by the <strong>GetCustomUI</strong> method of the<strong><a class="libraryLink" title="Auto generated link to Microsoft.Office.Core.IRibbonExtensibility" href="http://msdn.microsoft.com/en-US/library/Microsoft.Office.Core.IRibbonExtensibility.aspx" target="_blank">Microsoft.Office.Core.IRibbonExtensibility</a></strong>
 interface implementation.</p>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<h3 class="subHeading">Form Region Components</h3>
<p>The following table describes the project files that provide code for the custom form region that is displayed in task Inspectors.</p>
<table cellspacing="2" cellpadding="5" width="50%" frame="lhs">
<tbody>
<tr>
<th>
<p>File</p>
</th>
<th>
<p>Description</p>
</th>
</tr>
<tr>
<td>
<p>FormRegionConnector.cs/vb</p>
</td>
<td>
<p>Defines the <span class="code">FormRegionConnector</span> class. This class implements the<strong>
<a class="libraryLink" title="Auto generated link to Microsoft.Office.Interop.Outlook.FormRegionStartup" href="http://msdn.microsoft.com/en-US/library/Microsoft.Office.Interop.Outlook.FormRegionStartup.aspx" target="_blank">
Microsoft.Office.Interop.Outlook.FormRegionStartup</a></strong> interface.</p>
</td>
</tr>
<tr>
<td>
<p>FormRegionControls.cs/vb</p>
</td>
<td>
<p>Defines a class that manages the controls on each form region instance.</p>
</td>
</tr>
<tr>
<td>
<p>PictureConverter.cs/vb</p>
</td>
<td>
<p>Converts an Image to an <strong>IPictureDisp</strong> that can be used to display an icon on a form region.</p>
</td>
</tr>
<tr>
<td>
<p>SimpleFormRegion.ofs</p>
</td>
<td>
<p>Defines the UI of the form region.</p>
</td>
</tr>
<tr>
<td>
<p>SimpleFormRegion.xml</p>
</td>
<td>
<p>Contains the manifest for the form region.</p>
</td>
</tr>
<tr>
<td>
<p>SimpleFormRegion.reg</p>
</td>
<td>
<p>Creates the registry entries that are required to load the form region.</p>
</td>
</tr>
</tbody>
</table>
</div>
<div></div>
<h1><em><em></em></em></h1>
<h1>More Information</h1>
<div>For more information about Office developer tools in Visual Studio, see <a href="http://msdn.microsoft.com/en-us/vsto/default.aspx">
http://msdn.microsoft.com/en-us/vsto/default.aspx</a>.</div>
