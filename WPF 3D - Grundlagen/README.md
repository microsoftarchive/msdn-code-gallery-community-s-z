# WPF 3D - Grundlagen
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
## Topics
- WPF
- viewport3D
- 3D
## Updated
- 03/03/2014
## Description

<p>WPF besitzt ein eigenes System zur Darstellung von 3D Objekten. Dabei handelt es sich um ein recht komplexes, aber auch interessantes Gebiet. Wenn man m&ouml;chte, kann man das ganze sp&auml;ter noch auf XNA oder DirectX erweitern, da WPF sehr &auml;hnlich
 zu diesen ist. (Aber nicht das gleiche!)</p>
<p>Hinweis: Im Beispielprojekt kann man die Objekte Teilweise bewegen. Dies ist nur ein vorl&auml;ufig funktionjierender Mechanismus. Wie er genau Funktioniert werde ich evbentuell in einem weiteren Tutorial erl&auml;utern.</p>
<h1>3D-Raum</h1>
<p><img src="http://code-13.net/Tutorials/WPF/Images/3d_ks.png" alt="3D Koordinatensystem" style="float:left"></p>
<p>Der Raum in dem die verschiedenen Objekte eingezeichnet werden ist in 8 Oktanten eingeteilt. In der Mitte ist das Zentrum. Die Oktanten werden durch die X-, Y- und die Z-Achse getrennt.</p>
<p>Der Raum hat eine H&ouml;he, Breite und L&auml;nge von 1. Entsprechend ist jeder Oktant 0,5 in jede Richtung gro&szlig;.</p>
<p>In die Richtung, in die die Pfeile zeigen, sind die jeweiligen Koordinaten positiv.</p>
<h1 style="clear:both">Figuren aufbauen</h1>
<p>Jede 3D-Fogur, die man aufbauen m&ouml;chte, muss komplett aus Dreiecken konstrukiert werden. Die einzelnen Fl&auml;chen k&ouml;nnen so aneinander gelegt werden, dass sie aussehen wie ein n-Eck.</p>
<h1>Erste Zeichenversuche</h1>
<p>Nun wollen wir unser erstes kleines Dreieck zeichnen. Dazu erstellen wir einen
<a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.controls.viewport3d.aspx" target="_blank">
ViewPort3D</a> im XAML-Code. Innerhalb von den dazugeh&ouml;hrigen Tags kann man nun eine Kamera, beleuchtungsquellen und die Objekte einbauen. Aufgrund der wiederverwendbarkeit erstellen wir aber nur eine Kamera im XAML-Code und den Rest im Codebehind.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Viewport3D&nbsp;x:Name=<span class="js__string">&quot;viewport&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Viewport3D.Camera&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;PerspectiveCamera&nbsp;x:Name=<span class="js__string">&quot;camera&quot;</span>&nbsp;LookDirection=<span class="js__string">&quot;0,0,-1&quot;</span>&nbsp;Position=<span class="js__string">&quot;0,0,5&quot;</span>&nbsp;FieldOfView=<span class="js__string">&quot;45&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Viewport3D.Camera&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ModelVisual3D&nbsp;x:Name=<span class="js__string">&quot;model&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ModelVisual3D&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Viewport3D&gt;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Wie Sie sehen wurden der Kamera einige Eigenschaften zugewiesen. Diese haben folgende Bedeutungen:</p>
<ul>
<li><strong>x:Name</strong><br>
Der Name der Kamera. &Uuml;ber diesen k&ouml;nnen wir sie auch im Codebehind steuern.
</li><li><strong>LookDirection</strong><br>
Bestimmt, in welche Richtung die Kamera zeigt. Die Koordinaten sind in der Reihenfolge x,y,z
</li><li><strong>Position</strong><br>
Bestimmt die Position der Kamera im Raum. 1 Entspricht auch hier der Normalgr&ouml;&szlig;e. Die Angaben haben ebenfalls das Format x,y,z.
</li><li><strong>FieldOfView</strong>
<table>
<tbody>
<tr>
<td style="border:0px none black; vertical-align:top">Hierbei handelt es sich um eine Gradangabe, wie Stark
<a href="http://de.wikipedia.org/wiki/Fotografische_Blende">die Blende</a> ge&ouml;ffnet ist.</td>
<td style="border:0px none black; vertical-align:top"><img src="http://code-13.net/Tutorials/WPF/Images/3d_camera_fieldofview.png" alt="Visualisierung"></td>
</tr>
</tbody>
</table>
</li></ul>
<p>N&auml;heres zu Kameras finden Sie <a href="http://code-13.net/Tutorials/WPF/3d_Basics.aspx#camera">
hier</a>.</p>
<p>Au&szlig;erdem habe ich ein <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.modelvisual3d.aspx" target="_blank">
ModelVisual3D</a> hinzugef&uuml;gt. In dieses zeichnen wir anschlie&szlig;end die Figur(en) hinein.<br>
Im <a href="http://msdn.microsoft.com/en-us/library/system.windows.frameworkelement.loaded.aspx" target="_blank">
Loaded-Event</a> des Fensters erstellen wir nun 3 Punkte und verkn&uuml;pfen diese zu einem Dreieck.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Model3DGroup&nbsp;group&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Model3DGroup();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MeshGeometry3D&nbsp;m&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MeshGeometry3D();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Positions.Add(<span class="cs__keyword">new</span>&nbsp;Point3D(<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Positions.Add(<span class="cs__keyword">new</span>&nbsp;Point3D(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Positions.Add(<span class="cs__keyword">new</span>&nbsp;Point3D(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TriangleIndices.Add(<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TriangleIndices.Add(<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TriangleIndices.Add(<span class="cs__number">2</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;group.Children.Add(<span class="cs__keyword">new</span>&nbsp;GeometryModel3D(m,&nbsp;<span class="cs__keyword">new</span>&nbsp;DiffuseMaterial(Brushes.Cyan)));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;group.Children.Add(<span class="cs__keyword">new</span>&nbsp;DirectionalLight(Colors.White,&nbsp;<span class="cs__keyword">new</span>&nbsp;Vector3D(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;-<span class="cs__number">1</span>)));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;model.Content&nbsp;=&nbsp;group;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Als erstes instanzieren wir eine <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.Model3DGroup.aspx" target="_blank">
Model3DGroup</a>. Diese beinhaltet sp&auml;ter alle Objekte. Das eigentliche Dreieck konstruieren wir in einem
<a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.MeshGeometry3D.aspx" target="_blank">
MeshGeometry3D</a>. Dort f&uuml;gen wir nun die 3 Eckpunkte zu der <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.MeshGeometry3D.positions.aspx">
Positions-Auflistung</a> hinzu. Anschlie&szlig;end verkn&uuml;pfen wir diese mithilfe der
<a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.MeshGeometry3D.TriangleIndices.aspx">
TriangleIndices-Auflistung</a>. Dort muss der jeweilige Index der einzelnen Punkte in der
<a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.MeshGeometry3D.positions.aspx">
Positions-Auflistung</a> angegeben werden.<br>
Aus dem <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.MeshGeometry3D.aspx" target="_blank">
MeshGeometry3D</a>-Objekt erstellen wir nun ein <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.GeometryModel3D.aspx" target="_blank">
GeometryModel3D</a>-Objekt, dem wir auch eine F&auml;rbung mitgeben. Der Einfachheit halber nutzen wir eine Einfache, Hellblaue Farbe. Sp&auml;ter werden wir auch kopliziertere F&auml;rbungen nutzen.<br>
Dieses <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.GeometryModel3D.aspx" target="_blank">
GeometryModel3D</a>-Objekt k&ouml;nnen wir nun der oben erstellten Auflistung hinzuf&uuml;gen.</p>
<p>Bei einem <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.DirectionalLight%20.aspx" target="_blank">
DirectionalLight</a> handelt es sich um ein einfaches Scheinwerferlicht. Der 1. Parameter des Konstruktors verlangt die Farbe und der 2. Parameter die Richtung des Strahls. Wir m&uuml;ssen mindestens eine Lichtquelle hinzuf&uuml;gen, damit wir das Objekt auch
 sehen k&ouml;nnen.</p>
<p>Die Erstellte Auflistung wei&szlig;en wir jetzt als Inhalt dem <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.modelvisual3d.aspx" target="_blank">
ModelVisual3D</a> aus dem ViewPort3D zu. Beim Ausf&uuml;hren erhalten wir nun folgendes Resultat:</p>
<p><img src="http://code-13.net/Tutorials/WPF/Images/3d_app_1.PNG" alt="Screenshot"></p>
<h1>Vielecke</h1>
<p>Nat&uuml;rlich ist es nicht immer sehr komfortable alles mit 3-Ecken zu Konstruieren. Besonders Vierecke werden auch h&auml;ufig gebraucht (werden wir sp&auml;ter f&uuml;r einen W&uuml;rfel nutzen). Ein Viereck l&auml;sst sich einfach in 2 Dreiecke unterteilen.
 Dabei spielt es keine Rollen, welche Art von Viereck wir vor uns haben (vorausgesetzt, wir haben ein
<a href="http://de.wikipedia.org/wiki/Konvexe_Menge" target="_blank">konvexes</a> Viereck).</p>
<p><img src="http://code-13.net/Tutorials/WPF/Images/3d_mesh.png" alt="Vierecke"></p>
<p>Wir erstellen nun also eine Methode, welches ein Viereck in einem <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.GeometryModel3D.aspx" target="_blank">
GeometryModel3D</a> erstellt und zur&uuml;ck gibt. Der Methode k&ouml;nnen wir die 4 Eckpunkte sowie ein Material &uuml;bergeben. In der Methode selbst werden die Punkte zur Positions-Auflistung hinzugef&uuml;gt und anschlie&szlig;end f&uuml;r 2 Dreiecke verwendet:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GeometryModel3D&nbsp;BuildQuadrilateral(Point3D&nbsp;p1,&nbsp;Point3D&nbsp;p2,&nbsp;Point3D&nbsp;p3,&nbsp;Point3D&nbsp;p4,&nbsp;Material&nbsp;material)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MeshGeometry3D&nbsp;m&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MeshGeometry3D();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Positions.Add(p1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Positions.Add(p2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Positions.Add(p3);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Positions.Add(p4);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TriangleIndices.Add(<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TriangleIndices.Add(<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TriangleIndices.Add(<span class="cs__number">2</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TriangleIndices.Add(<span class="cs__number">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TriangleIndices.Add(<span class="cs__number">3</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TriangleIndices.Add(<span class="cs__number">0</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;GeometryModel3D(m,&nbsp;material);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Als Test zeichnen wir 2 Rechtecke in das Koordinatensystem. Das 2. stellen wir etwas schr&auml;g, sodass wir auch den 3D-Effekt bemerken.
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Model3DGroup&nbsp;group&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Model3DGroup();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;group.Children.Add(BuildQuadrilateral(<span class="cs__keyword">new</span>&nbsp;Point3D(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>),&nbsp;<span class="cs__keyword">new</span>&nbsp;Point3D(<span class="cs__number">0.5</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>),&nbsp;<span class="cs__keyword">new</span>&nbsp;Point3D(<span class="cs__number">0.5</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>),&nbsp;<span class="cs__keyword">new</span>&nbsp;Point3D(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>),&nbsp;<span class="cs__keyword">new</span>&nbsp;DiffuseMaterial(Brushes.Cyan)));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;group.Children.Add(BuildQuadrilateral(<span class="cs__keyword">new</span>&nbsp;Point3D(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;-<span class="cs__number">1</span>),&nbsp;<span class="cs__keyword">new</span>&nbsp;Point3D(-<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;-<span class="cs__number">1</span>),&nbsp;<span class="cs__keyword">new</span>&nbsp;Point3D(-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>),&nbsp;<span class="cs__keyword">new</span>&nbsp;Point3D(<span class="cs__number">0</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>),&nbsp;<span class="cs__keyword">new</span>&nbsp;DiffuseMaterial(Brushes.Cyan)));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;group.Children.Add(<span class="cs__keyword">new</span>&nbsp;DirectionalLight(Colors.White,&nbsp;<span class="cs__keyword">new</span>&nbsp;Vector3D(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;-<span class="cs__number">1</span>)));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;model.Content&nbsp;=&nbsp;group;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<p><img src="http://code-13.net/Tutorials/WPF/Images/3d_app_2.PNG" alt="Screenshot"></p>
<p>Wie Sie sehen k&ouml;nnen, ist das 2. Rechteck etwas dunkler und sieht nicht rechteckig aus. Das liegt am 3D-Effekt. Wenn Sie die Kamera entsprechend drehen, wird das 2. Rechtek richtig, aber daf&uuml;r das 1. &quot;Falsch&quot; dargestellt.</p>
<h1 id="light">Lichtquellen</h1>
<p>Ohne Licht sieht man nichts. Darum braucht man auch in WPF mindestens eine entsprechende Lichtquelle, die die Objekte beleuchtet. Es gibt 4 verschiedene Arten von Lichtquellen:</p>
<ul>
<li>Direktes Licht (<a href="http://msdn.microsoft.com/de-de/library/system.windows.media.media3d.directionallight.aspx">DirectionalLight</a>)<br>
Dieses Licht wirkt wie von einem Scheinwerfer abgegeben. Man kann mithilfe der <a href="http://msdn.microsoft.com/de-de/library/system.windows.media.media3d.directionallight.direction.aspx">
Direction-Eigenschaft </a>die Richtung festlegen. </li><li>Gleichm&auml;&szlig;iges Licht (<a href="http://msdn.microsoft.com/de-de/library/system.windows.media.media3d.AmbientLight.aspx">AmbientLight</a>)<br>
Das Licht wird gleichm&auml;&szlig;ig auf alle Seiten des Objekts gestrahlt. Somit ist es &uuml;berall gleich hell.
</li><li>Lampe (<a href="http://msdn.microsoft.com/de-de/library/system.windows.media.media3d.PointLight.aspx">PointLight</a>)<br>
Das Licht wird von einem Punkt im Raum ausgestrahlt. Die Position des Punktes kann mit der
<a href="http://msdn.microsoft.com/de-de/library/system.windows.media.media3d.pointlightbase.position.aspx">
Position-Eigenschaft</a> bestimmt werden. </li><li>Kegellicht (<a href="http://msdn.microsoft.com/de-de/library/system.windows.media.media3d.SpotLight.aspx">SpotLight</a>)<br>
Das Licht wird in einem Kegel in eine bestimmte Richtung gestrahlt. Die Position des Ausgangspunktes kann mit der
<a href="http://msdn.microsoft.com/de-de/library/system.windows.media.media3d.pointlightbase.position.aspx">
Position-Eigenschaft</a> bestimmt werden. Die <a href="http://msdn.microsoft.com/de-de/library/system.windows.media.media3d.spotlight.direction.aspx">
Direction-Eigenschaft</a> bestimmt die Strahlrichtung. </li></ul>
<p><img src="http://code-13.net/Tutorials/WPF/Images/3d_app_3.PNG" alt="Screenshot"></p>
<p>Allen Lichtquellen kann man die <a href="http://msdn.microsoft.com/de-de/library/system.windows.media.media3d.light.color.aspx">
Color-Eigenschaft</a> f&uuml;r die Lichtfarbe zuweisen. So kann man bestimmte, farbliche Effekte hervorrufen.</p>
</div>
</div>
<p>Im oben stehenden Fenster sind die 4 Licht-Typen in Aktion zu sehen. Oben Links ist ein direktes Licht angewendet wurde, rechts daneben ein gleichm&auml;&szlig;iges Licht, unten Links eine Lampe und unten Rechts ein Kegellicht.</p>
<h1 id="material">Materialien</h1>
<p>Man kann den verschiedenen Objekten verschiedene Materialien zuweisen. In den oben gezeigten Beispielen habe ich immer ein DiffuseMaterial genutzt. Es gibt aber noch 2 weitere.</p>
<ul>
<li><a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.diffusematerial.aspx">DiffuseMaterial</a><br>
Das Objekt wird so aussehen, als ob es diffus beleuchtet wird. Es wird also keine Glanzeffekte aufweisen.
</li><li><a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.specularmaterial.aspx">SpecularMaterial</a><br>
Der Objekt wird gl&auml;nzend dargestellt. Mithilfe der <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.specularmaterial.specularpower.aspx">
SpecularPower-Eigenschaft</a> kann die St&auml;rke der Reflektioon angegeben werden.
</li><li><a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.emissivematerial.aspx">EmissiveMaterial</a><br>
Das Objekt scheint selbst Licht abzugeben, ohne zu leuchten. Dadurch wird sich da Objekt bei Schatten anders verhalten.
</li></ul>
<p>Nachfolgend wieder eine Anwendung mit verschiedenen Materialien:</p>
<p><img src="http://code-13.net/Tutorials/WPF/Images/3d_app_4.PNG" alt="Screenshot" width="560" height="329"></p>
<p>Links sind 2 Diffuse Materialien zu sehen. Das untere Objekt nutzt einen <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.lineargradientbrush.aspx">
linearen Farbverlauf</a>. In der Mitte sind 2 Objekte mit einem <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.specularmaterial.aspx">
SpecularMaterial</a> auf einem <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.diffusematerial.aspx">
DiffuseMaterial</a> abgebildet. Beide diffusen Materialien sind Cyan-Farben und werden vom
<a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.specularmaterial.aspx">
SpecularMaterial</a> farblich ver&auml;ndert. Beim oberen ist die Reflektionskraft auf 20 und beim unteren auf 80&nbsp; festgelegt. Ganz rechts sind 2 Objekte mit einem
<a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.emissivematerial.aspx">
EmissiveMaterial</a> auf einem <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.diffusematerial.aspx">
DiffuseMaterial</a>zu sehen. Der obere Cyan-Ton wird von Blau &uuml;berdeckt und der untere von einem Farbverlauf von Rot nach Gelb.
<br>
Alle Objekte werden mit einem Lichtstrahl von vorne beleuchtet.</p>
<p>Bis auf das <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.diffusematerial.aspx">
DiffuseMaterial</a> ben&ouml;tigen alle ein 2. Material, welches den &quot;Hintergrund&quot; angibt. Dieser wird in der Regel durch ein
<a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.diffusematerial.aspx">
DiffuseMaterial</a> repr&auml;sentiert. Um beide Materialien angeben zu k&ouml;nnen, muss man eine
<a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.MaterialGroup%20.aspx">
MaterialGroup</a> erstellen. </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaterialGroup&nbsp;mg&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MaterialGroup();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mg.Children.Add(mat1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mg.Children.Add(mat2);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">new</span>&nbsp;GeometryModel3D(m,&nbsp;mg);</pre>
</div>
</div>
</div>
<p></p>
<p>Die Materialien werden der Reihenfolge nach auf das Objekt &uuml;bertragen. Teilweise &uuml;berlagern diese sich somit.</p>
<h1>R&uuml;ckseite</h1>
<p>Wenn man die Kamera auf die R&uuml;ckseite einer Fl&auml;che richtet, dann wird diese nicht zu sehen sein. Die Zuweisung der
<a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.geometrymodel3d.Material.aspx">
Material-Eigenschaft</a> hat nur auf die Vorderseite eine Auswirkung. Um auch die R&uuml;ckseite einzuf&auml;rben, m&uuml;ssen wir die
<a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.geometrymodel3d.BackMaterial.aspx">
BackMaterial-Eigenschaft</a> ebenfalls festlegen.</p>
<h1>Brushes</h1>
<p id="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.SolidColorBrush%20.aspx">
In den obigen Beispielen habe ich immer einen <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.SolidColorBrush%20.aspx">
SolidColorBrush</a> oder einen <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.lineargradientbrush.aspx">
LinearGradientBrush</a> eingesetzt. MKan kann jedoch jeden von <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.brush.aspx">
Brush</a> abgeleiteten Typ nutzen:</p>
<ul>
<li><strong><a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.SolidColorBrush%20.aspx">SolidColorBrush</a></strong><br>
F&uuml;r einfarbige Fl&auml;chen. </li><li><strong><a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.lineargradientbrush.aspx">LinearGradientBrush</a></strong><br>
F&uuml;r lineare Farbverl&auml;ufe. </li><li><strong><a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.radialgradientbrush.aspx">RadialGradientBrush</a></strong><br>
F&uuml;r radiale, also im Kreis nach au&szlig;en verlaufende, Farbverl&auml;ufe. </li><li><strong><a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.imagebrush.aspx">ImageBrush</a></strong><br>
Um Bilder als Farbe zu nutzen. </li><li><strong><a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.drawingbrush.aspx">DrawingBrush</a></strong><br>
F&uuml;r Muster, welche ithilfe eines Drawings erstellt werden. </li><li><strong><a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.visualbrush.aspx">VisualBrush</a></strong><br>
Dieser kann angewendet werden, um visuelle Elemente wie Buttons als Farben zu nutzen.
</li></ul>
<p>Microsoft stellt eine gute &Uuml;bersicht &uuml;ber verf&uuml;gbare Brushes <a href="http://msdn.microsoft.com/de-de/library/aa970904.aspx">
hier in der MSDN</a> bereit.</p>
<p>Wenn man etwas mit den Brushes herum probiert, kann man beispielsweise problemlos einen RGB-W&uuml;rfel erstellen. Mehr dazu
<a href="http://code-13.net/Tutorials/WPF/3d_rgbcube.aspx" target="_blank">hier</a>.</p>
<h1>Zuschneiden/Berteich ausw&auml;hlen</h1>
<p>Wenn man ein einfarbiges Material erstellt, dann wird die Fl&auml;che einheitlich gef&auml;rbt. Bei allen anderen Farben muss jedoch der Bereich angegeben werden, welcher als F&uuml;llfarbe genutzt werden soll. Die Eckpunkte von diesem Ausschnitt kann man
 in die <a href="http://msdn.microsoft.com/de-de/library/system.windows.media.media3d.meshgeometry3d.texturecoordinates.aspx">
TextureCoordinates-Auslistung</a> eintragen. </p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Model3DGroup&nbsp;group&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Model3DGroup();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MeshGeometry3D&nbsp;m&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MeshGeometry3D();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Positions.Add(<span class="cs__keyword">new</span>&nbsp;Point3D(<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Positions.Add(<span class="cs__keyword">new</span>&nbsp;Point3D(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Positions.Add(<span class="cs__keyword">new</span>&nbsp;Point3D(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TriangleIndices.Add(<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TriangleIndices.Add(<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TriangleIndices.Add(<span class="cs__number">2</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TextureCoordinates.Add(<span class="cs__keyword">new</span>&nbsp;Point(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TextureCoordinates.Add(<span class="cs__keyword">new</span>&nbsp;Point(<span class="cs__number">1</span>,&nbsp;<span class="cs__number">0</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TextureCoordinates.Add(<span class="cs__keyword">new</span>&nbsp;Point(<span class="cs__number">1</span>,&nbsp;<span class="cs__number">1</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.TextureCoordinates.Add(<span class="cs__keyword">new</span>&nbsp;Point(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">1</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;group.Children.Add(<span class="cs__keyword">new</span>&nbsp;GeometryModel3D(m,&nbsp;<span class="cs__keyword">new</span>&nbsp;DiffuseMaterial(<span class="cs__keyword">new</span>&nbsp;RadialGradientBrush(Colors.Green,&nbsp;Colors.Yellow&nbsp;))));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;group.Children.Add(<span class="cs__keyword">new</span>&nbsp;DirectionalLight(Colors.White,&nbsp;<span class="cs__keyword">new</span>&nbsp;Vector3D(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;-<span class="cs__number">1</span>)));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;model.Content&nbsp;=&nbsp;group;</pre>
</div>
</div>
</div>
<p></p>
<p>Der Bereich muss hierf&uuml;r nicht zwingend ein Viereck sein. Es kann auch ein Dreieck oder ein n-Eck sein. F&uuml;r unsere einfachen Beispiele reicht solch eine quadratische Fl&auml;che jedoch aus.</p>
<h1 id="camera">Kameras</h1>
<p>Es gibt 2 Grundlegende Arten von Kameras. Einmal die <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.orthographiccamera.aspx">
orthografische</a> und die <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.perspectivecamera.aspx">
perspektivische</a>. Bei der perspektischen Kamera werden weiter hinten liegende Objekte kleiner aufgenommen. Das wirkt im Vergleich zu realen aufnahmen sehr realistisch. Bei der orthografischen Kamera dagegen werden alle Objekte in der angegebenen Gr&ouml;&szlig;e
 dargestellt. In nachfolgendem Screenshot sind auf jeder Seite je 2 Dreiecke der gleichen Gr&ouml;&szlig;e abgebildet. Links wird eine persperktivische und rechts eine ortografische Kamera angewendet.</p>
<p><img src="http://code-13.net/Tutorials/WPF/Images/3d_app_5.PNG" alt="Screenshot"></p>
<p>Bei beiden Kameras kann man mithilfe der <a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.projectioncamera.lookdirection.aspx">
LookDirection-Eigenschaft</a> die Richtung angeben, in die die Aufnahme gemacht wird. Die Position der Kamera wird von der
<a href="http://msdn.microsoft.com/de-de/library/vstudio/system.windows.media.media3d.projectioncamera.position.aspx">
Positions-Eigenschaft</a> bestimmt.</p>
