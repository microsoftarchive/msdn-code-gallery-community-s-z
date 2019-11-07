# Trabajando archivos XML con C Sharp
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- LINQ
- Windows Forms
- XML
## Topics
- LINQ
- XML
## Updated
- 06/10/2011
## Description

<div class="endscriptcode">En los foros siempre veo preguntas referentes al manejo de XML&nbsp;con C#,&nbsp;manejo que va desde su creaci&oacute;n, consulta y edici&oacute;n, es por esto que me decid&iacute;&nbsp;a crear este documento en el que relato como
 trabajar&nbsp;XML con C#.</div>
<p>Si tienes dudas de lo que es XML, te recomiendo que consultes esto antes de empezar.</p>
<p>Para el manejo de xml, desde el Framework&nbsp;3.5 se tiene un Namespace&nbsp;muy &uacute;til, el XML.Linq, este sera el que nos permitir&aacute;&nbsp;trabajar libremente con nuestros xml. Para empezar usaremos su clase &quot;Principal&quot; (seg&uacute;n&nbsp;yo)
 la XDocument, esta nos permite, crear, leer modificar (entre otras cosas) nuestros archivos. En fin si deseas mas documentaci&oacute;n&nbsp;en la web puedes encontrar toda la que necesites para iniciar, por ahora empecemos a programar.</p>
<p>Para este ejemplo creare una peque&ntilde;a estructura de datos que contendr&aacute;&nbsp;informaci&oacute;n&nbsp;de los empleados de una compa&ntilde;&iacute;a, la aplicaci&oacute;n&nbsp;es de tipo WinForms y esta hecha en lo mejor, C#.</p>
<p>Al proyecto de WinForm&nbsp;le agregamos un bot&oacute;n&nbsp;(bt_crear_XML) y llamara a nuestro m&eacute;todo crear_XML, as&iacute;:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void bt_crear_XML_Click(object sender, EventArgs e)
{
            crear_XML();
}

private void crear_XML()
{
            XDocument miXML = new XDocument(new XDeclaration(&quot;1.0&quot;, &quot;utf-8&quot;, &quot;yes&quot;),
                new XElement(&quot;Empleados&quot;,

                new XElement(&quot;Empleado&quot;,
                new XAttribute(&quot;Id_Empleado&quot;, &quot;321654&quot;),
                new XElement(&quot;Nombre&quot;, &quot;Miguel Suarez&quot;),
                new XElement(&quot;Edad&quot;, &quot;30&quot;)),

                new XElement(&quot;Empleado&quot;,
                new XAttribute(&quot;Id_Empleado&quot;, &quot;123456&quot;),
                new XElement(&quot;Nombre&quot;, &quot;Maria Martinez&quot;),
                new XElement(&quot;Edad&quot;, &quot;27&quot;)),

                new XElement(&quot;Empleado&quot;,
                new XAttribute(&quot;Id_Empleado&quot;, &quot;987654&quot;),
                new XElement(&quot;Nombre&quot;, &quot;Juan Gonzales&quot;),
                new XElement(&quot;Edad&quot;, &quot;25&quot;))
                ));
            miXML.Save(@&quot;C:\Prueba\MiDoc.xml&quot;&quot;); //Debes tener permisos sobre la carpeta
            MessageBox.Show(&quot;Se ha creado un XML&quot;);
}</pre>
<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;bt_crear_XML_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;crear_XML();&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
private&nbsp;<span class="js__operator">void</span>&nbsp;crear_XML()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XDocument&nbsp;miXML&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;XDocument(<span class="js__operator">new</span>&nbsp;XDeclaration(<span class="js__string">&quot;1.0&quot;</span>,&nbsp;<span class="js__string">&quot;utf-8&quot;</span>,&nbsp;<span class="js__string">&quot;yes&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;XElement(<span class="js__string">&quot;Empleados&quot;</span>,&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;XElement(<span class="js__string">&quot;Empleado&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;XAttribute(<span class="js__string">&quot;Id_Empleado&quot;</span>,&nbsp;<span class="js__string">&quot;321654&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;XElement(<span class="js__string">&quot;Nombre&quot;</span>,&nbsp;<span class="js__string">&quot;Miguel&nbsp;Suarez&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;XElement(<span class="js__string">&quot;Edad&quot;</span>,&nbsp;<span class="js__string">&quot;30&quot;</span>)),&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;XElement(<span class="js__string">&quot;Empleado&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;XAttribute(<span class="js__string">&quot;Id_Empleado&quot;</span>,&nbsp;<span class="js__string">&quot;123456&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;XElement(<span class="js__string">&quot;Nombre&quot;</span>,&nbsp;<span class="js__string">&quot;Maria&nbsp;Martinez&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;XElement(<span class="js__string">&quot;Edad&quot;</span>,&nbsp;<span class="js__string">&quot;27&quot;</span>)),&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;XElement(<span class="js__string">&quot;Empleado&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;XAttribute(<span class="js__string">&quot;Id_Empleado&quot;</span>,&nbsp;<span class="js__string">&quot;987654&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;XElement(<span class="js__string">&quot;Nombre&quot;</span>,&nbsp;<span class="js__string">&quot;Juan&nbsp;Gonzales&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;XElement(<span class="js__string">&quot;Edad&quot;</span>,&nbsp;<span class="js__string">&quot;25&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;miXML.Save(@<span class="js__string">&quot;C:\Prueba\MiDoc.xml&quot;</span>&quot;);&nbsp;<span class="js__sl_comment">//Debes&nbsp;tener&nbsp;permisos&nbsp;sobre&nbsp;la&nbsp;carpeta</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="js__string">&quot;Se&nbsp;ha&nbsp;creado&nbsp;un&nbsp;XML&quot;</span>);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<p>NOTA: No olvides&nbsp;agregar&nbsp;el namespace&nbsp;Xml.Linq (<em>using&nbsp;System.Xml.Linq;</em>)&nbsp;</p>
<p>Si ejecutas y pulsas el bot&oacute;n,&nbsp;vuala, abras creado un XML. . . como ves es bastante f&aacute;cil, haciendo uso de las clases que nos proporciona este namespace. . . perooo, &iquest;y ya? hasta aqu&iacute;&nbsp;este post&nbsp;ser&iacute;a muy
 corto, as&iacute; que me adelantare&nbsp;y expondr&eacute; un poco de <a title="Linq to xml" href="http://msdn.microsoft.com/es-es/library/bb387098.aspx" target="_blank">
Linq&nbsp;to Xml</a>.</p>
<p><strong>Consultar un Dato especifico</strong>&nbsp;&nbsp;&nbsp;</p>
<p>Para consultar un dato especifico, creare la funci&oacute;n &quot;<em>buscarEnXml</em>&quot; que esperara&nbsp;un par&aacute;metro&nbsp;del tipo string&nbsp;(el Id_Empleado), la funci&oacute;n queda as&iacute;:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void buscarEnXML(string idempleado)
{
            XDocument miXML = XDocument.Load(@&quot;C:\Prueba\MiDoc.xml&quot;); //Cargar el documento

            var nombreusu = from nombre in miXML.Elements(&quot;Empleados&quot;).Elements(&quot;Empleado&quot;)
                            where nombre.Attribute(&quot;Id_Empleado&quot;).Value == idempleado //Consultamos por el atributo
                            select nombre.Element(&quot;Nombre&quot;).Value; //Seleccionamos el nombre

            foreach (string minom in nombreusu)
            {
                MessageBox.Show(minom); //Mostramos un mensaje con el nombre del empleado que corresponde
            }
}

</pre>
<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;buscarEnXML(string&nbsp;idempleado)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XDocument&nbsp;miXML&nbsp;=&nbsp;XDocument.Load(@<span class="js__string">&quot;C:\Prueba\MiDoc.xml&quot;</span>);&nbsp;<span class="js__sl_comment">//Cargar&nbsp;el&nbsp;documento</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;nombreusu&nbsp;=&nbsp;from&nbsp;nombre&nbsp;<span class="js__operator">in</span>&nbsp;miXML.Elements(<span class="js__string">&quot;Empleados&quot;</span>).Elements(<span class="js__string">&quot;Empleado&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;nombre.Attribute(<span class="js__string">&quot;Id_Empleado&quot;</span>).Value&nbsp;==&nbsp;idempleado&nbsp;//Consultamos&nbsp;por&nbsp;el&nbsp;atributo&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;nombre.Element(<span class="js__string">&quot;Nombre&quot;</span>).Value;&nbsp;<span class="js__sl_comment">//Seleccionamos&nbsp;el&nbsp;nombre</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(string&nbsp;minom&nbsp;<span class="js__operator">in</span>&nbsp;nombreusu)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(minom);&nbsp;<span class="js__sl_comment">//Mostramos&nbsp;un&nbsp;mensaje&nbsp;con&nbsp;el&nbsp;nombre&nbsp;del&nbsp;empleado&nbsp;que&nbsp;corresponde</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<p>NOTA: para poder realizar consultas Linq, debes importar el namespace&nbsp;Linq (<em>using&nbsp;System.Linq</em>)</p>
<p><strong>Como agregar un nuevo nodo.</strong></p>
<p>Para agregar un nuevo nodo se usa la propiedad Root&nbsp;del XDocument, esta propiedad&nbsp;obtiene&nbsp;la raiz&nbsp;del documento, d&aacute;ndonos&nbsp;la posibilidad de agregar&nbsp;los elementos y atributos de manera muy f&aacute;cil, para esto he creado
 un m&eacute;todo&nbsp;addNode, que espera los par&aacute;metros&nbsp;id_Empleado, nombre y edad todos del tipo string, el c&oacute;digo queda as&iacute;:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void dropNode(string idEmpleado)
{
            XDocument miXML = XDocument.Load(@&quot;C:\Prueba\MiDoc.xml&quot;); //Cargar el archivo           

            var consul = from persona in miXML.Elements(&quot;Empleados&quot;).Elements(&quot;Empleado&quot;)
                         where persona.Attribute(&quot;Id_Empleado&quot;).Value == idEmpleado
                         select persona;
            consul.ToList().ForEach(x =&gt; x.Remove()); //Remover elemento a elemento.
            miXML.Save(@&quot;C:\Prueba\MiDoc.xml&quot;);            
}

</pre>
<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;dropNode(string&nbsp;idEmpleado)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XDocument&nbsp;miXML&nbsp;=&nbsp;XDocument.Load(@<span class="js__string">&quot;C:\Prueba\MiDoc.xml&quot;</span>);&nbsp;<span class="js__sl_comment">//Cargar&nbsp;el&nbsp;archivo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;consul&nbsp;=&nbsp;from&nbsp;persona&nbsp;<span class="js__operator">in</span>&nbsp;miXML.Elements(<span class="js__string">&quot;Empleados&quot;</span>).Elements(<span class="js__string">&quot;Empleado&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;persona.Attribute(<span class="js__string">&quot;Id_Empleado&quot;</span>).Value&nbsp;==&nbsp;idEmpleado&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;persona;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;consul.ToList().ForEach(x&nbsp;=&gt;&nbsp;x.Remove());&nbsp;<span class="js__sl_comment">//Remover&nbsp;elemento&nbsp;a&nbsp;elemento.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;miXML.Save(@<span class="js__string">&quot;C:\Prueba\MiDoc.xml&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
Con este ultimo m&eacute;todo&nbsp;hemos acabado con las operaciones b&aacute;sicas&nbsp;de acceso a datos, espero les halla sido de utilidad, hasta una pr&oacute;xima&nbsp;ocasi&oacute;n. Agradezco los comentarios.</div>
</div>
