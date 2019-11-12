# Un Equivalente de strtok() Para .Net
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- .NET
- Class Library
- .NET Framework 4.0
- C# Language
- .NET Framwork
- Visual C Sharp .NET
- Visual Studio 2013
- .NET Development
- Windows Desktop App Development
- C# Unsafe Code
## Topics
- Performance
- Pointers
- String Methods
- String Operations
- String Algorithms
## Updated
- 01/30/2015
## Description

<h1>Introducci&oacute;n</h1>
<p>Si bien es cierto que .Net provee <strong><a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.String.Split.aspx" target="_blank" title="Auto generated link to System.String.Split">System.String.Split</a>()</strong> para extraer tokens de cadenas de texto, hay informaci&oacute;n que se pierde en el proceso:&nbsp; Los separadores y espec&iacute;ficamente, la posici&oacute;n y cantidad de dichos
 separadores.&nbsp; La gran parte del tiempo dicha informaci&oacute;n es irrelevante pues la gran mayor&iacute;a del tiempo lo que se necesita son los tokens y solamente los tokens.</p>
<p>Sin embargo me top&eacute; con una pregunta cuyo requerimiento era extraer la subcadena de texto sin alterar hasta un n&uacute;mero de palabra determinado.&nbsp; Ejemplo:&nbsp; Extraer la subcadena de texto que contenga hasta la segunda palabra.&nbsp; Mi
 primer pensamiento fue <strong>String.Split()</strong>, y conforme terminaba de responder la pregunta me di cuenta de algo:&nbsp; &iquest;Qu&eacute; separador o separadores deber&iacute;a usar para armar la respuesta?&nbsp; No lo sab&iacute;a porque
<strong>String.Split()</strong> no me dice nada al respecto.&nbsp; Inmediatamente extra&ntilde;&eacute; la simplicidad de
<strong>strtok()</strong> en C, lo que me me empuj&oacute; a crear esta funci&oacute;n que les muestro aqu&iacute;.</p>
<h1><span style="font-size:20px; font-weight:bold">Para Compilar el Ejemplo</span></h1>
<p><span style="font-size:20px; font-weight:bold"><span style="font-size:xx-small">El proyecto incluido aqu&iacute; tiene la configuraci&oacute;n correcta y deber&iacute;a compilar sin problema.&nbsp; El c&oacute;digo de la funci&oacute;n en el proyecto
<strong>AdvString </strong>es c&oacute;digo inseguro y por lo tanto debe marcarse la opci&oacute;n de permitir c&oacute;digo inseguro en las propiedades del proyecto.</span><br>
</span></p>
<h1><span style="font-size:20px; font-weight:bold">Descripci&oacute;n</span></h1>
<p>La funci&oacute;n <strong>AdvString.Tokenize.GetTokens() </strong>resuelve el problema funcionando de una forma similar a
<strong>strtok() </strong>en C:&nbsp; Usa punteros para recorrer la cadena de texto y extraer la informaci&oacute;n de posici&oacute;n y longitud de cada token.&nbsp; A diferencia de
<strong>strtok()</strong>, la funci&oacute;n no reemplaza los separadores por car&aacute;cteres nulos.&nbsp; La funci&oacute;n NO devuelve el token como tal pues no asume necesariamente que lo que se necesita es el token y simplemente se limita a identificar
 la posici&oacute;n y longitud de cada token &uacute;nicamente.</p>
<p>La funci&oacute;n en cuesti&oacute;n est&aacute; programada con c&oacute;digo inseguro en C#.&nbsp; Idealmente la funci&oacute;n debe compilarse en una bibliotecta (DLL) aparte con la opci&oacute;n de c&oacute;digo inseguro marcada en las propiedades del
 proyecto tal como se indica en las instrucciones de la secci&oacute;n anterior.</p>
<p>Aqu&iacute; se muestra la funci&oacute;n en cuesti&oacute;n.&nbsp; La funci&oacute;n determina los &iacute;ndices de posici&oacute;n de cada token sobre una copia de la cadena de texto, as&iacute; que pueden usarse directamente con
<strong>String.Substring()</strong> para obtener cualquier token en cualquier momento a partir de la cadena de texto original.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/es-ES/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;AdvString&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Tokenize&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;IEnumerable&lt;TokenInfo&gt;&nbsp;GetTokens(<span class="cs__keyword">string</span>&nbsp;text,&nbsp;<span class="cs__keyword">params</span>&nbsp;<span class="cs__keyword">char</span>[]&nbsp;separators)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;TokenInfo&gt;&nbsp;tokens&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;TokenInfo&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(String.IsNullOrWhiteSpace(text))&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ArgumentNullException(<span class="cs__string">&quot;text&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">unsafe</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">fixed</span>&nbsp;(<span class="cs__keyword">char</span>*&nbsp;startChar&nbsp;=&nbsp;text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">char</span>*&nbsp;curChar&nbsp;=&nbsp;startChar;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;start&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;textLength&nbsp;=&nbsp;text.Length;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;insideToken&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(curChar&nbsp;-&nbsp;startChar&nbsp;&lt;&nbsp;textLength&nbsp;-&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(separators.Contains(*curChar))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(insideToken)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//End&nbsp;of&nbsp;token.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;insideToken&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Yield&nbsp;a&nbsp;new&nbsp;TokenInfo&nbsp;object&nbsp;to&nbsp;the&nbsp;caller.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tokens.Add(<span class="cs__keyword">new</span>&nbsp;TokenInfo(start,&nbsp;(<span class="cs__keyword">int</span>)(curChar&nbsp;-&nbsp;startChar)&nbsp;-&nbsp;start));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(!insideToken)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;insideToken&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;start&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)(curChar&nbsp;-&nbsp;startChar);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&#43;curChar;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(insideToken)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Yield&nbsp;the&nbsp;last&nbsp;token.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tokens.Add(<span class="cs__keyword">new</span>&nbsp;TokenInfo(start,&nbsp;(<span class="cs__keyword">int</span>)(curChar&nbsp;-&nbsp;startChar)&nbsp;-&nbsp;start&nbsp;&#43;&nbsp;<span class="cs__number">1</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;tokens;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>Si se examina el c&oacute;digo con atenci&oacute;n, la funci&oacute;n no es cosa del otro mundo y probablemente evoque los tiempos inmemoriales en los que estudi&aacute;bamos y nos asignaban tareas con bucles y otras cosas b&aacute;sicas.&nbsp; El c&oacute;digo
 es sencillo y directo:&nbsp; Examinamos cada car&aacute;cter en la cadena de texto:&nbsp; Si es un separador o no es lo primero que se verifica; en cualquier caso hay que verificar una variable Booleana de control que nos dice si estamos sobre un token o no,
 pues dependiendo de si lo estamos o no as&iacute; es el comportamiento dentro del bucle.</p>
<p>Lo m&aacute;s &quot;sorprendente&quot; para programadores de .Net es tal vez los punteros.&nbsp; No puedo explicar el por qu&eacute; de lo que se ve ah&iacute; pues no es mi intenci&oacute;n familiarizar a nadie con punteros con este c&oacute;digo.&nbsp; Si no sabe
 de punteros y aritm&eacute;tica de punteros, le recomiendo entonces leer al respecto en un buen libro o un buen tutorial en l&iacute;nea.</p>
<h1><span>Archivos Fuente</span></h1>
<ul>
<li><em>AdvString.TokenInfo.cs:&nbsp; </em>Define la clase <strong>TokenInfo</strong>, una clase POCO de s&oacute;lo lectura que almacena la informaci&oacute;n de un &uacute;nico token.
</li><li><em><em>AdvString.Tokenize.cs:</em></em>&nbsp; Define la clase est&aacute;tica Tokenize que contiene la funci&oacute;n objeto de este art&iacute;culo:&nbsp;
<strong>GetTokens()</strong>. </li><li><em>Tester.Program.cs:</em>&nbsp; Define un programa de consola que demuestra el uso de la funci&oacute;n
<strong>GetTokens()</strong> tanto para obtener los tokens como lo har&iacute;a <strong>
String.Split()</strong> como para resolver el problema original descrito en la introducci&oacute;n.
</li></ul>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:0px; width:1px; height:1px; overflow:hidden">
</div>
