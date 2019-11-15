# Visualization & Modeling SDK - Circuit Diagrams. Extensive DSL customization.
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Visualization and Modeling SDK
- DSL Tools
- VMSDK
## Topics
- DSL definition and customization
## Updated
- 03/22/2011
## Description

<p>This is a sample of a domain-specific language defined by using <a href="http://msdn.microsoft.com/library/bb126259.aspx" target="_blank">
Visualization and Modeling SDK (DSL Tools)</a>. It demonstrates how to program: commands, drag and drop, cut and paste,&nbsp;events, shape alignment,&nbsp;composite elements, validation, and embedding a diagram in a Windows Form. The user can draw simple electronic
 circuit diagrams.</p>
<p><img src="18879-screenshot.png" alt="" width="749" height="334"></p>
<h3>Discussion</h3>
<p>Please post suggestions and questions on the <a href="http://social.msdn.microsoft.com/Forums/en-US/vsarch/threads/" target="_blank">
Visualization and Modeling SDK Forum</a>.</p>
<p>&nbsp;</p>
<h1>What it demonstrates</h1>
<p>This sample demonstrates how to customize several aspects of your domain-specific language (DSL):</p>
<ul>
<li><a href="http://msdn.microsoft.com/library/ff521398.aspx" target="_blank">Copy, cut and paste</a>,
<a href="http://msdn.microsoft.com/library/bb126573.aspx" target="_blank">preserving relative shape positions</a>
</li><li><a href="http://msdn.microsoft.com/library/ff793459.aspx" target="_blank">Drag and drop handler</a>
</li><li><a href="http://msdn.microsoft.com/library/gg593810.aspx" target="_blank">Embed diagram in a Windows Form
</a>in Visual Studio </li><li>Couple model to external form by using <a href="http://msdn.microsoft.com/library/bb126250.aspx" target="_blank">
Events</a> </li><li>Drop tool on element </li><li><a href="http://msdn.microsoft.com/library/gg593806.aspx" target="_blank">Text wrapping</a>
</li><li>Dynamic images using <a href="http://msdn.microsoft.com/library/gg593806.aspx" target="_blank">
custom image fields and decorators</a> </li><li><a href="http://msdn.microsoft.com/library/cc512845.aspx#diagrams" target="_blank">Shape alignment</a>&nbsp;
<a href="http://msdn.microsoft.com/library/dd820681.aspx" target="_blank">command</a>
</li><li>Composite elements
<ul>
<li>Transistor shapes have four elements: the main body, and the three terminals&nbsp;
</li><li>The Transistor <a href="http://msdn.microsoft.com/library/ff521397.aspx" target="_blank">
tool is customized </a>to create a group&nbsp;of four elements </li><li>The terminal shapes are fixed in position using <a href="http://msdn.microsoft.com/library/bb126326.aspx" target="_blank">
Bounds Rules</a> </li><li><a href="http://msdn.microsoft.com/library/dd820621.aspx" target="_blank">Selection is constrained
</a>to include the whole transistor, even if a terminal is clicked </li></ul>
</li><li><a href="http://msdn.microsoft.com/library/bb126413.aspx" target="_blank">Validation
</a>invoked by program code </li><li><a href="http://msdn.microsoft.com/library/dd820681.aspx" target="_blank">Menu commands</a> and
<a href="http://msdn.microsoft.com/library/bb126591.aspx" target="_blank">double-click</a>
</li></ul>
<p>Please note that the sample is not intended as a working application. It has not been thoroughly tested.</p>
<p>See also <a href="http://code.msdn.microsoft.com/DSLToolsLab/Release/ProjectReleases.aspx?ReleaseId=4207" target="_blank">
VMSDK Introductory Lab</a>.</p>
<h3>Embedding in a Windows Form&nbsp;</h3>
<p>The diagram is embedded in a Windows Form, which also contains a button and a list.</p>
<p>The form is defined in DslPackage\WrappingForm.cs. It provides a Panel in which the DSL diagram is inserted.</p>
<p>In CoupleFormToModel.cs, we override DocData.Window to place the form between the DSL view and its usual Visual Studio container:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;System.Windows.Forms.IWin32Window&nbsp;Window&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(container&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Put&nbsp;our&nbsp;own&nbsp;form&nbsp;inside&nbsp;the&nbsp;DSL&nbsp;window:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;container&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;WrappingForm(<span class="cs__keyword">this</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Forms.Control.aspx" target="_blank" title="Auto generated link to System.Windows.Forms.Control">System.Windows.Forms.Control</a>)<span class="cs__keyword">base</span>.Window);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;container;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;WrappingForm&nbsp;container;&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>The constructor we&rsquo;ve added to WrappingForm.cs inserts the DSL into the panel:</p>
<p>&nbsp;The constructor we&rsquo;ve added to WrappingForm.cs inserts the DSL into the panel:&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">internal</span>&nbsp;WrappingForm(CircuitsDocView&nbsp;docView,&nbsp;Control&nbsp;content)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<span class="cs__keyword">this</span>()&nbsp;
&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DiagramPanel.Controls.Add(content);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.docView&nbsp;=&nbsp;docView;&nbsp;
}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>Updating the Form by using Store Events</h2>
<p>Notice that the form contains a parts list, which is updated whenever items are added to or deleted from the diagram.</p>
<p><a href="http://msdn.microsoft.com/library/bb126250.aspx">Store events</a> are the standard method of keeping anything outside the store synchronized with changes inside the store. There are different kinds of store events &ndash; fired for example when
 a property changes, when an element or link is added, or removed.</p>
<p>To register a Store event, we need to update the Store&rsquo;s <a href="http://msdn.microsoft.com/library/microsoft.visualstudio.modeling.eventmanagerdirectory.aspx">
EventManagerDirectory</a>. We have to do this before any user changes happen, but after the model has been properly loaded. There are two methods we could override that are called at the right time:
<a href="http://msdn.microsoft.com/library/microsoft.visualstudio.modeling.shell.docdata.ondocumentloaded.aspx">
DocData.OnDocumentLoaded()</a> and <a href="http://msdn.microsoft.com/library/microsoft.visualstudio.modeling.shell.modelingdocview.loadview.aspx">
DocView.LoadView().</a> In this case, it is slightly more convenient to use the latter.</p>
<p>&nbsp;</p>
<h2>Composite Elements</h2>
<p>The electronic components are each composed of several elements &ndash; a main element and two or three elements that represent named terminals. These terminals appear as fixed ports on the shapes. The prototype components are stored in the toolbox as groups
 of elements.</p>
<p>&nbsp;<img src="http://i3.code.msdn.microsoft.com/visualization-modeling-sdk-763778e8/image/file/18881/1/composites.png" alt="" width="103" height="93"></p>
<p>(Compare this with the example in the component diagram solution template. In that DSL, a component is created with just the main element. Then you add a variable number of ports, which can be moved around on the component&rsquo;s surface.)</p>
<h4>Groups of elements in the toolbox</h4>
<p>Every element tool works by storing a serialized copy of the element that the tool should create. The prototype element is stored in an
<a href="http://msdn.microsoft.com/library/microsoft.visualstudio.modeling.elementgroupprototype.aspx">
ElementGroupPrototype</a> (EGP). The standard tools created by a DSL definition just contain one element, but in fact an EGP can hold any number of elements, with links in between them. (EGPs are also used to store elements in the
<a href="http://msdn.microsoft.com/library/ff793458.aspx">copy buffer</a>.)</p>
<p>When the user drags a tool onto the diagram, or onto an element on the diagram, a process called ElementMerge is performed. This first checks whether the prototype in the tool can be linked into the target element; if so, a copy of the prototype is created,
 given a new ID and name, and linked into the tree with an embedding relationship. The &ldquo;fixup&rdquo; rules then fire to create a shape for the new element. (The same process happens when you
<a href="http://msdn.microsoft.com/library/ff793458.aspx">paste</a> or <a href="http://msdn.microsoft.com/library/ff793459.aspx">
drag and drop</a> an element.)</p>
<p>In a basic DSL without custom code, each element tool is initialized with a single element. This is done in Dsl\ToolboxHelper.cs, by CreateElementToolPrototype().</p>
<p>In the Circuit Diagrams DSL, in Dsl\Custom\CompositeElement.cs, we override CreateElementToolPrototype(). Each component tool is initialized with a group of elements: the main
<strong>Component</strong> element; two or three <strong>ComponentTerminals</strong>; and
<strong>ComponentHasComponentTerminal</strong> relationships between them. (These are all types defined in this DSL.)</p>
<p><strong>Note</strong>: the toolbox contents are kept in a persistent cache. CreateElementPrototype() is therefore not called every time that Visual Studio starts. If you change the definition of the toolbox, or of this method, you need to refresh the cache.
 Reset the experimental instance of VS, and then rebuild the solution.</p>
<h4>Fixed placement of terminal shapes</h4>
<p>The ComponentTerminalShapes are the two or three small bumps on the edges of the components. They provide a fixed point on the perimeter of each component to which wires can be fixed.</p>
<p><a href="http://msdn.microsoft.com/library/bb126326.aspx">BoundsRules are used to constrain the size and location</a> of the terminal shapes. The BoundsRule is called when the shape is created, and on any attempt to move it. See ComponentTerminalBoundsRule
 in Dsl\Custom Code\CompositeElements.cs.</p>
<h4>Rotating shapes</h4>
<p>When you double-click a component, it rotates.</p>
<h4>Rotate, flip and polarity.</h4>
<p>Rotate a component by double-clicking. Notice that the terminals move with the rotation, and the wires remain connected to the correct terminal:</p>
<p><img src="http://i3.code.msdn.microsoft.com/visualization-modeling-sdk-763778e8/image/file/18882/1/rotations.png" alt="" width="530" height="208"></p>
<p>An integer domain property ComponentShape.rotate keeps the current state of rotation.</p>
<p>Rotation is done in ComponentShape.Rotate90 (in DynamicNodeImages.cs):</p>
<ul>
<li>&middot; Rotate90 resets the AbsoluteBounds of the shape, swapping the width and the height.
</li><li>&middot; It also increments the rotate domain property. </li><li>&middot; The terminal bounds rules depend on the value of the rotate property. You can see this for example in ResistorShape.GetTerminalLocation() (in DynamicNodeImages.cs).
</li><li>&middot; The image field also depends on the rotate property. </li></ul>
<h4>Inserting a variable image field</h4>
<p>In a DSL without code overrides, the image and text decorators that are specified in the DSL Definition are set up by InitializeShapeFields(), which you can see in the code for each shape in Dsl\Generated Code\Shapes.cs . For each image decorator, it adds
 an ImageField, which just displays the image.</p>
<p>For our own rotatable images, we would like to replace the ImageFields with instances of our own ImageField subclass. To do this, we must override InitializeShapeFields(), which can be done if we set
<strong>Generates Double Derived</strong> on the properties of each component shape class in the DSL Definition.</p>
<p><img src="http://i1.code.msdn.microsoft.com/visualization-modeling-sdk-763778e8/image/file/18883/1/doublederived.png" alt="" width="430" height="205"></p>
<p>In fact rotatable images are only required on TransisitorShape and CapacitorShape.</p>
<h2>Image visibility dependent on a domain property</h2>
<p>You can flip a component or reverse the polarity of a transistor by right-clicking:</p>
<p><img src="http://i4.code.msdn.microsoft.com/visualization-modeling-sdk-763778e8/image/file/18884/1/pnpn.png" alt="" width="93" height="62"></p>
<p>This is achieved by providing the TransistorShape with two decorators, both in the center of the shape. The visibility of each image is made dependent on the Boolean domain property Polarity, which is inherited from Component.</p>
<p>This is done in the DSL Definition, without additional code.</p>
<p>Click the shape mapping between Transistor and TransistorShape, open the <strong>
DSL Details</strong> window and click the <strong>Decorator Maps</strong> tab. Click on one of the image decorators, NPNImage or PNPImage. Notice that the Visibility Filter is set, with the Filter property set to Polarity. The Visibility Entries have opposite
 values for the two images.</p>
<p><strong>Note</strong>: There is one field instance for each decorated location on a class of shape. There is not an instance per shape element. If your DSL defines two classes each of which has two fields, then at run time, there will be just four instances
 of Field. Therefore, methods in a field that depend on a particular shape instance must take the shape as a parameter.</p>
<h2>Alignment</h2>
<p>To align nodes:</p>
<p>1. Select two or more nodes that are already roughly aligned either vertically or horizontally.</p>
<p>2. Right-click and choose <strong>Align</strong>.</p>
<p><img src="http://i4.code.msdn.microsoft.com/visualization-modeling-sdk-763778e8/image/file/18885/1/alignment.png" alt="" width="566" height="307"></p>
<p>The code is in Dsl\Custom Code\ShapeAlignment.cs. It assigns values to the AbsoluteBounds of each shape.</p>
<p>The code that sets up the menu command is in DslPackage\Custom\Commands.cs, and the position of menu items on the menus is determined by DslPackage\Commands.vsct. For more information, see
<a href="http://msdn.microsoft.com/library/dd820681.aspx">How to Define Menu Commands</a>.</p>
<h2>Copy or cut and paste preserving layout</h2>
<p>You can copy a selection of nodes, and paste them at a chosen mouse position, without losing their relative positions and connections:</p>
<p><img src="http://i2.code.msdn.microsoft.com/visualization-modeling-sdk-763778e8/image/file/18886/1/copygroup.png" alt="" width="141" height="296">&nbsp;Then paste:
<img src="http://i3.code.msdn.microsoft.com/visualization-modeling-sdk-763778e8/image/file/18887/1/pastegroup.png" alt="" width="101" height="215"></p>
<p>To place the group in a specific position, right-click where you want the top left to be, then click
<strong>Paste</strong>. (If you use ctrl-V, the group will appear adjacent to the current selection.)</p>
<p>The code is in DslPackage\Custom\Commands.cs, in OnMenuCut, OnMenuCopy, OnMenuPaste.</p>
<p>The OnMenuCopy creates an ElementGroup that contains the model elements. From this, an ElementGroupPrototype (EGP) is produced and serialized onto the global paste buffer. (EGPs were also discussed in the context of the toolbox, where each element tool keeps
 an EGP.)</p>
<p>An interesting property of ElementGroup is that when you add a model element, it automatically adds any relationship links between the new element and the elements that were already in the group. It is therefore not necessary to add the links explicitly.</p>
<p>We also add the shapes of the component methods. It is not strictly necessary to do this. If we do not provide the shapes, the paste method will automatically &ldquo;fix up&rdquo; the diagram by creating new shapes for the pasted model elements. However,
 by providing a shape, we allow the paste method to recreate the relative positions of the shapes, as well as their properties such as state of rotation. We don&rsquo;t bother with the component terminal shapes &ndash; new ones can be recreated by paste, and
 the bounds rules will fix their positions. We don&rsquo;t need to specify which component shapes go with each component element, because the PresentationViewsSubject links will automatically be added to the group.</p>
<p>OnMenuPaste merges the paste buffer contents into the model. It uses a utility method
<a href="http://msdn.microsoft.com/library/microsoft.visualstudio.modeling.diagrams.designsurfaceelementoperations.aspx">
DesignSurfaceElementOperations</a>.Merge(). This method takes the diagram (rather than the model) as one of its parameters, because it attempts to replicate the original layout of the shapes, relative to a point that we can specify. If the user calls paste
 by right-clicking, we use the mouse pointer; otherwise, we put the new shapes next to any selected shapes; or underneath existing shapes.</p>
<p>You can also copy by drag and CTRL&#43;drop.</p>
<h2>Wrapped Text Decorator</h2>
<p>If you type a long line into a Comment, the text wraps inside the comment shape, once you have finished typing:</p>
<p><img src="http://i3.code.msdn.microsoft.com/visualization-modeling-sdk-763778e8/image/file/18888/1/comment.png" alt="" width="182" height="97"></p>
<p>To do this, we set various properties of the text field. The code generated from your DSL Definition sets this in CommentBoxShape.InitializeDecorators(). By setting the Generates Double Derived property of CommentBoxShape, we can override this method. The
 code is in Dsl\CustomCode\WrappedCommentText.cs</p>
<p>The code lets the base method set up the fields, and then finds the text field and adjusts its settings. These demonstrate anchoring.</p>
<h2>Customizing how a new element is merged</h2>
<p>You can drag from the Comment tool onto any component on the diagram. This creates both a comment and a link from the new comment to the target component. This is done in the DSL Definition, without additional code.</p>
<p>In the DSL Explorer, look under Domain Classes\Component\Element Merge Directives. There is a directive that allows a Component to accept a Comment. Select that EMD and look in the DSL Details window:</p>
<p><img src="http://i2.code.msdn.microsoft.com/visualization-modeling-sdk-763778e8/image/file/18889/1/dsldetails.png" alt="" width="628" height="175"></p>
<p>This specifies that when a Comment is merged onto a Component, a link is created from the ComponentModel to the Comment; and that a link is also created from the Component to the Comment. For more information, see
<a href="http://msdn.microsoft.com/library/bb126479.aspx">Domain Path syntax</a>.</p>
<h1>Related Sample</h1>
<p><a href="http://code.msdn.microsoft.com/DSLToolsLab/Release/ProjectReleases.aspx?ReleaseId=4207" target="_blank">VMSDK Introductory Lab</a></p>
<p>&nbsp;</p>
<h1><strong>Change History</strong></h1>
<p><strong>2011-03-22: </strong>Avoid copying presentation elements such as labels, which have no model elements.<br>
&nbsp;&nbsp; Thanks to <a href="http://social.msdn.microsoft.com/Forums/en-US/dslvsarchx/thread/0b0b16d4-6014-4b35-9e5a-e27ea02e0ee3" target="_blank">
Joeul on VMSDK Forum</a>. <br>
2010-08-01: Published on VSMSDK Code Gallery.<br>
2007 : Used in <a href="http://www.domainspecificdevelopment.com/" target="_blank">
DSL Tools book</a>.</p>
