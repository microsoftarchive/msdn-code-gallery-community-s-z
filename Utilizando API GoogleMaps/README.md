# Utilizando API GoogleMaps
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- Visual Studio 2010
- .NET Framework
- Javascript
- C# Language
## Topics
- Maps
## Updated
- 03/26/2013
## Description

<h4 class="title"><span style="font-size:large">Entendendo um pouco a API Google Maps</span></h4>
<div class="entry-content x_apiki-wp-content">
<p><span style="font-size:medium">O Google dispensa coment&aacute;rios com todas as inova&ccedil;&otilde;es que ele faz. Hoje falaremos um pouco sobre a API do Google Maps. API (Application Programming Interface ou Interface de Programa&ccedil;&atilde;o de
 Aplicativos) &eacute; a forma que temos de nos comunicar com as fun&ccedil;&otilde;es pr&eacute;-programadas definidas pelo fornecedor, no caso, Google. Esta API permite a cria&ccedil;&atilde;o de mapas com locais definidos, controle de zoom, tipos de mapa,
 gera&ccedil;&atilde;o de rotas, pesquisa por estabelecimentos, e muitas coisas mais.</span></p>
<p><strong><span style="font-size:medium">Como come&ccedil;ar</span></strong></p>
<p><span style="font-size:medium">A primeira coisa que devemos fazer &eacute; acessar o link da p&aacute;gina inicial da API(<span style="text-decoration:underline; color:#3366ff">https://developers.google.com/maps/signup?hl=pt-BR</span>), ler e aceitar o contrato,
 digitar a url do site que deseja usar a API e clicar no bot&atilde;o &ldquo;Gerar chave da API&rdquo;</span></p>
<p><span style="font-size:medium"><span>Ap&oacute;s isso, caso ainda n&atilde;o esteja logado com a sua &ldquo;Google Account&rdquo;, o Google pedir&aacute; para efetuar o login, nesse passo voc&ecirc; obter&aacute; a chave para usar a API somente na url que
 digitou o site. Caso queira usar a API em outro site, dever&aacute; repetir esse processo para cada site que quiser.&nbsp;</span><br>
</span></p>
<p><span style="font-size:medium"><span>Agora que j&aacute; temos a chave, podemos usar a API no site. O Google disponibiliza alguns exemplos, para trabalhar com JavaScript, Flash, Servi&ccedil;o, etc..&nbsp;</span><br>
<span>Neste artigo abordaremos o uso da API para JavaScript&nbsp;</span><br>
</span></p>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/pt-BR/library/System.Web.aspx" target="_blank" title="Auto generated link to System.Web">System.Web</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/pt-BR/library/System.Web.UI.aspx" target="_blank" title="Auto generated link to System.Web.UI">System.Web.UI</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/pt-BR/library/System.Web.UI.WebControls.aspx" target="_blank" title="Auto generated link to System.Web.UI.WebControls">System.Web.UI.WebControls</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/pt-BR/library/System.Data.aspx" target="_blank" title="Auto generated link to System.Data">System.Data</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;GoogleMaps&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Default&nbsp;:&nbsp;System.Web.UI.Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Page_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">this</span>.IsPostBack)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataTable&nbsp;dt&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataTable(<span class="cs__string">&quot;Tabela&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(<span class="cs__string">&quot;Name&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">string</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(<span class="cs__string">&quot;Latitude&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">string</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(<span class="cs__string">&quot;Longitude&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">string</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(<span class="cs__string">&quot;Description&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">string</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(<span class="cs__string">&quot;S&atilde;o&nbsp;Paulo&quot;</span>,&nbsp;<span class="cs__string">&quot;-23.59872&quot;</span>,&nbsp;<span class="cs__string">&quot;-46.67651&quot;</span>,&nbsp;<span class="cs__string">&quot;Faculdade&nbsp;Insper&nbsp;&lt;br&nbsp;/&gt;&lt;br&nbsp;/&gt;&nbsp;R.&nbsp;Quat&aacute;,&nbsp;300&nbsp;-&nbsp;Itaim&nbsp;Bibi&nbsp;&lt;br&nbsp;/&gt;&nbsp;S&atilde;o&nbsp;Paulo&nbsp;-&nbsp;SP&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rptMarkers.DataSource&nbsp;=&nbsp;dt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rptMarkers.DataBind();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">window.onload&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;mapOptions&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;center:&nbsp;<span class="js__operator">new</span>&nbsp;google.maps.LatLng(markers[<span class="js__num">0</span>].lat,&nbsp;markers[<span class="js__num">0</span>].lng),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;zoom:&nbsp;<span class="js__num">18</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mapTypeId:&nbsp;google.maps.MapTypeId.ROADMAP&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;infoWindow&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;google.maps.InfoWindow();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;map&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;google.maps.Map(document.getElementById(<span class="js__string">&quot;dvMap&quot;</span>),&nbsp;mapOptions);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;markers.length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;data&nbsp;=&nbsp;markers[i]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;myLatlng&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;google.maps.LatLng(data.lat,&nbsp;data.lng);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;marker&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;google.maps.Marker(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;position:&nbsp;myLatlng,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;map:&nbsp;map,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;title:&nbsp;data.title&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__operator">function</span>&nbsp;(marker,&nbsp;data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;google.maps.event.addListener(marker,&nbsp;<span class="js__string">&quot;click&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;infoWindow.setContent(data.description);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;infoWindow.open(map,&nbsp;marker);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)(marker,&nbsp;data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;%@&nbsp;Page</span>&nbsp;<span class="html__attr_name">Language</span>=<span class="html__attr_value">&quot;C#&quot;</span>&nbsp;<span class="html__attr_name">AutoEventWireup</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">CodeBehind</span>=<span class="html__attr_value">&quot;Default.aspx.cs&quot;</span>&nbsp;<span class="html__attr_name">Inherits</span>=<span class="html__attr_value">&quot;GoogleMaps.Default&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;
&nbsp;
<span class="html__doctype">&lt;!DOCTYPE&nbsp;html&nbsp;PUBLIC&nbsp;&quot;-//W3C//DTD&nbsp;XHTML&nbsp;1.0&nbsp;Transitional//EN&quot;&nbsp;&quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd&quot;&gt;</span>&nbsp;
&nbsp;
<span class="html__tag_start">&lt;html</span>&nbsp;<span class="html__attr_name">xmlns</span>=<span class="html__attr_value">&quot;http://www.w3.org/1999/xhtml&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;head</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;Head1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;title</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/title&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">language</span>=<span class="html__attr_value">&quot;javascript&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;http://maps.googleapis.com/maps/api/js?sensor=false&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">language</span>=<span class="html__attr_value">&quot;javascript&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span><span class="html__tag_start">&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;markers&nbsp;=&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Repeater&nbsp;ID=<span class="js__string">&quot;rptMarkers&quot;</span>&nbsp;runat=<span class="js__string">&quot;server&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;title&quot;</span>:&nbsp;<span class="js__string">'&lt;%#&nbsp;Eval(&quot;Name&quot;)&nbsp;%&gt;'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;lat&quot;</span>:&nbsp;<span class="js__string">'&lt;%#&nbsp;Eval(&quot;Latitude&quot;)&nbsp;%&gt;'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;lng&quot;</span>:&nbsp;<span class="js__string">'&lt;%#&nbsp;Eval(&quot;Longitude&quot;)&nbsp;%&gt;'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;description&quot;</span>:&nbsp;<span class="js__string">'&lt;%#&nbsp;Eval(&quot;Description&quot;)&nbsp;%&gt;'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SeparatorTemplate&gt;,&lt;/SeparatorTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:Repeater&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">language</span>=<span class="html__attr_value">&quot;javascript&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;Scripts/googleMaps.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;
<span class="html__tag_end">&lt;/head&gt;</span>&nbsp;
<span class="html__tag_start">&lt;body</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;form1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;dvMap&quot;</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;width:&nbsp;1330px;&nbsp;height:&nbsp;700px&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/form&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/body&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/html&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<img id="79041" src="79041-mapa.jpg" alt="" width="760" height="516"></h1>
<ul>
</ul>
<h1></h1>
<p>https://developers.google.com/maps/?hl=pt-br</p>
<p>http://maps.google.com/?vector=1</p>
<p>https://developers.google.com/maps/documentation/javascript/tutorial?hl=pt-BR#api_key</p>
