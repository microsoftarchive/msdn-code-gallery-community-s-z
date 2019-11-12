# VSTO - Create a custom tab for the Office Ribbon in Excel (Visual Studio 2012)
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- VSTO
- .NET Framework 4.0
- Excel 2010
## Topics
- Excel
- VSTO
- Office Ribbon
- Generate Excel Workbook
## Updated
- 09/07/2012
## Description

<h1>Introducci&oacute;n</h1>
<p>Este ejemplo se puede ejecutar en Microsoft Office Excel 2010.</p>
<p>En este ejemplo se muestra c&oacute;mo crear una pesta&ntilde;a personalizada que aparece en la cinta de opciones de una hoja de c&aacute;lculo de Microsoft Office Excel. Esta cinta personalizada muestra la mayor&iacute;a de los controles disponibles en
 el grupo <span class="ui">Controles de la cinta de opciones de Office</span> del
<span class="ui">Cuadro de herramientas</span> de Visual Studio. Para obtener m&aacute;s informaci&oacute;n sobre el uso de estos controles, vea Dise&ntilde;ador de la cinta de opciones.</p>
<h4>Nota sobre la seguridad:</h4>
<p>Este ejemplo de c&oacute;digo est&aacute; pensado para explicar un concepto y s&oacute;lo muestra el c&oacute;digo relevante para ese concepto. Es posible que no cumpla los requisitos de seguridad de un entorno espec&iacute;fico y no se debe usar exactamente
 como en el ejemplo. Se recomienda agregar c&oacute;digo de seguridad y de control de errores para que los proyectos sean m&aacute;s s&oacute;lidos y seguros. Microsoft proporciona este c&oacute;digo de ejemplo &quot;TAL CUAL&quot; sin ninguna garant&iacute;a.</p>
<p>Para obtener informaci&oacute;n acerca de c&oacute;mo instalar el proyecto de ejemplo en su equipo, vea C&oacute;mo: Instalar y usar los archivos de ejemplo que se encuentran en la Ayuda.</p>
<h1 class="heading"><span>Requisitos</span></h1>
<div class="section" id="requirementsTitleSection">
<p>Este ejemplo requiere las aplicaciones siguientes:</p>
<ul>
<li>
<p>Una edici&oacute;n de Visual Studio que incluye las herramientas de desarrollo de Microsoft Office.</p>
</li><li>
<p>Microsoft Office Excel 2010.</p>
</li></ul>
</div>
<h1><span>Compilar el ejemplo</span></h1>
<div class="subSection">
<ol>
<li>
<p>Presione F5.</p>
</li><li>
<p>Aparece una hoja de c&aacute;lculo de Excel. En la cinta de opciones de la hoja de c&aacute;lculo aparece una pesta&ntilde;a personalizada denominada
<span class="ui">Ribbon Control Sample</span>.</p>
<p>En la cinta no aparece ninguna otra pesta&ntilde;a porque la propiedad StartFromScratch de la cinta personalizada est&aacute; establecida en
<span class="keyword">true</span>.</p>
</li></ol>
</div>
<h1>Descripci&oacute;n</h1>
<p>En este ejemplo se muestran los conceptos siguientes:</p>
<ul>
<li>
<p>Personalizar una pesta&ntilde;a utilizando una plantilla de elemento <span class="ui">
Cinta (dise&ntilde;ador visual)</span>.</p>
</li><li>
<p>Ocultar todas las pesta&ntilde;as integradas y la mayor&iacute;a de los comandos del men&uacute; de Office y mostrar s&oacute;lo las personalizaciones definidas en este elemento de la cinta de opciones.</p>
</li><li>
<p>Agregar controles y grupos personalizados al dise&ntilde;ador de la cinta.</p>
</li><li>
<p>Controlar los eventos de los controles en la cinta de opciones.</p>
</li><li>
<p>Cambiar las propiedades de los controles en tiempo de ejecuci&oacute;n.</p>
</li><li>
<p>Agregar controles din&aacute;micamente a un men&uacute; en tiempo de ejecuci&oacute;n.</p>
</li><li>
<p>Agregar elementos din&aacute;micamente a una galer&iacute;a en tiempo de ejecuci&oacute;n.</p>
</li><li>
<p>Mostrar y ocultar controles del panel de acciones utilizando botones en la cinta de opciones.</p>
</li></ul>
<h1 class="heading"><span>Grupo Working with Sheets</span></h1>
<div class="section" id="sectionSection0">
<p>En la tabla siguiente se describen los controles que aparecen en el grupo <span class="ui">
Working with Sheets</span> de la cinta personalizada.</p>
<div class="tableSection">
<table cellspacing="2" cellpadding="5" width="50%" frame="lhs">
<tbody>
<tr>
<th>
<p>Control</p>
</th>
<th>
<p>Descripci&oacute;n</p>
</th>
<th>
<p>Acci&oacute;n/resultado</p>
</th>
</tr>
<tr>
<td>
<p><span class="ui">Show Actions Pane</span></p>
</td>
<td>
<p>Un bot&oacute;n de alternancia que aparece presionado o sin presionar.</p>
</td>
<td>
<p>Haga clic en <span class="ui">Show Actions Pane</span>.</p>
<p>Aparece un panel de acciones junto a la hoja de c&aacute;lculo.</p>
<p>Haga clic en <span class="ui">Show Actions Pane</span> por segunda vez para ocultar el panel de acciones.</p>
</td>
</tr>
<tr>
<td>
<p>Botones de cara</p>
</td>
<td>
<p>Tres botones incluidos en un grupo de botones. Estos botones se agregan al grupo de botones porque se relacionan entre s&iacute;. Los botones de un grupo de botones tienen una apariencia brillante.</p>
</td>
<td>
<p>Haga clic en un bot&oacute;n de cara.</p>
<p>La celda A1 muestra una imagen correspondiente.</p>
</td>
</tr>
<tr>
<td>
<p><span class="ui">Alineaci&oacute;n</span></p>
</td>
<td>
<p>Un bot&oacute;n de expansi&oacute;n. Un bot&oacute;n de expansi&oacute;n es un bot&oacute;n que tiene asociado men&uacute;. El bot&oacute;n de expansi&oacute;n
<span class="ui">Alignment</span> contiene tres botones. La propiedad OfficeImageId del bot&oacute;n de expansi&oacute;n
<span class="ui">Alignment</span> est&aacute; establecida en el identificador. de un control de alineaci&oacute;n de Office integrado.</p>
</td>
<td>
<p>Haga clic en <span class="ui">Right Align</span>, <span class="ui">Left Align</span> o
<span class="ui">Center Align</span> en el men&uacute; del bot&oacute;n de expansi&oacute;n
<span class="ui">Alignment</span>.</p>
<p>El texto que aparece en la celda A3 se justifica a la derecha, a la izquierda o se centra.</p>
</td>
</tr>
<tr>
<td>
<p><span class="ui">Color</span></p>
</td>
<td>
<p>Una galer&iacute;a que presenta una matriz de esferas coloreadas entre las que puede seleccionar.</p>
</td>
<td>
<p>Haga clic en <span class="ui">Color</span>y, a continuaci&oacute;n, seleccione un color de la galer&iacute;a.</p>
<p>Aparece una esfera con el color seleccionado en la celda A6.</p>
</td>
</tr>
<tr>
<td>
<p><span class="ui">FormatChart</span></p>
</td>
<td>
<p>Un control desplegable que contiene una lista de formatos de gr&aacute;fico. A diferencia de un cuadro combinado, no puede escribir una selecci&oacute;n en un control desplegable.</p>
</td>
<td>
<p>Haga clic en <span class="ui">Format Chart</span>y, a continuaci&oacute;n, seleccione un formato en la lista.</p>
<p>El formato del gr&aacute;fico que aparece en la hoja de c&aacute;lculo cambia para coincidir con el formato seleccionado.</p>
</td>
</tr>
<tr>
<td>
<p><span class="ui">MRU Find</span></p>
</td>
<td>
<p>Un cuadro combinado. Puede escribir una opci&oacute;n o seleccionarla.</p>
</td>
<td>
<p>Haga clic en el cuadro combinado <span class="ui">MRU Find</span> y, a continuaci&oacute;n, seleccione texto en la lista.</p>
<p>O bien</p>
<p>En el cuadro combinado <span class="ui">MRU Find</span>, escriba un texto cualquiera y, a continuaci&oacute;n, presione ENTRAR.</p>
<p>Aparece un cuadro de mensaje que identifica la ubicaci&oacute;n del texto en la hoja de c&aacute;lculo.</p>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<h1 class="heading"><span>Grupo Building Dynamic Menu</span></h1>
<p>En la tabla siguiente se describen los controles que aparecen en el grupo <span class="ui">
Building a Dynamic Menu</span> de la cinta personalizada.</p>
<table cellspacing="2" cellpadding="5" width="50%" frame="lhs">
<tbody>
<tr>
<th>
<p>Control</p>
</th>
<th>
<p>Descripci&oacute;n</p>
</th>
<th>
<p>Acci&oacute;n/resultado</p>
</th>
</tr>
<tr>
<td>
<p><span class="ui">Dynamic Menu</span></p>
</td>
<td>
<p>Un men&uacute;. Un men&uacute; es una lista desplegable que puede contener otros controles de la cinta de opciones.</p>
<p>La propiedad Dynamic de este men&uacute; est&aacute; establecida en <span class="keyword">
true</span>. Esto permite que el men&uacute; se actualice din&aacute;micamente en tiempo de ejecuci&oacute;n.</p>
</td>
<td>
<p>Haga clic en <span class="ui">Dynamic Menu</span> para mostrar un men&uacute; de controles.</p>
</td>
</tr>
<tr>
<td>
<p><span class="ui">CheckBox</span>, <span class="ui">DropDown</span>, <span class="ui">
SubMenu</span>, <span class="ui">Gallery</span>, <span class="ui">Button</span>,
<span class="ui">Separator</span></p>
</td>
<td>
<p>Conjunto de casillas. Puede activar o desactivar una casilla para activar o desactivar una opci&oacute;n.</p>
<p>Cada casilla representa un control de la cinta de opciones que puede agregar a
<span class="ui">Dynamic Menu</span>.</p>
</td>
<td>
<p>Haga clic en una casilla para agregar un control de la cinta de opciones a <span class="ui">
Dynamic Menu</span>.</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar</span>|<span class="pluginRemoveHolderLink">Quitar</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb">Visual&nbsp;Basic&nbsp;
&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;AP1&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;ActionsPaneControl1&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;&nbsp;Load&nbsp;event&nbsp;fires&nbsp;when&nbsp;the&nbsp;Ribbon&nbsp;loads&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;&nbsp;Actions&nbsp;Pane&nbsp;is&nbsp;added&nbsp;to&nbsp;the&nbsp;project&nbsp;but&nbsp;remains&nbsp;hidden&nbsp;until&nbsp;the&nbsp;user&nbsp;chooses&nbsp;to&nbsp;show&nbsp;it&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;RibbonControls_Load(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs">Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.Load&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Globals.ThisWorkbook.ActionsPane.Controls.Add(AP1)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AP1.Hide()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Globals.ThisWorkbook.Application.DisplayDocumentActionTaskPane&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;&nbsp;ToggleButton&nbsp;click&nbsp;event&nbsp;shows/hides&nbsp;the&nbsp;Actions&nbsp;Pane&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnActionsPane_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/es-ES/library/Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs">Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnActionsPane.Click&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Globals.ThisWorkbook.Application.DisplayDocumentActionTaskPane&nbsp;=&nbsp;btnActionsPane.Checked&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AP1.Visible&nbsp;=&nbsp;btnActionsPane.Checked&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;</pre>
</div>
</div>
</div>
<h1>M&aacute;s informaci&oacute;n</h1>
<p>Para obtener m&aacute;s informaci&oacute;n sobre Visual Studio Tools para Office (VSTO):
<a href="http://msdn.microsoft.com/es-es/office/hh133430">http://msdn.microsoft.com/es-es/office/hh133430</a>.</p>
