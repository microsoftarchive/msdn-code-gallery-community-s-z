# Social Media Network Example in ASP.NET
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SQL Server
- ASP.NET
- Social Network
## Topics
- social network api
## Updated
- 01/24/2013
## Description

<h1>Introduction</h1>
<p><em>This solution is one answer for this question:&nbsp;http://code.msdn.microsoft.com/site/requests/Social-Network-141af909/</em></p>
<p>The Social Network is the actual phenomena. In Brazil the most popular example is Orkut, and now Facebook, but we know have more than one thousand social networks on the world, to see one list, see:&nbsp;<a href="http://pt.wikipedia.org/wiki/Lista_de_redes_sociais"><span>http://pt.wikipedia.org/wiki/Lista_de_redes_sociais</span></a></p>
<p><span>In this article i show the ASP .NET aplication to social interaction network.</span></p>
<p><span>I know is simple, and don't have all functions of other social networks on the market, but is the basic to you work, find and make friends, and share informations, the rest is with you.</span></p>
<p><span><br>
</span></p>
<p><span style="font-family:'Trebuchet MS'">As redes sociais s&atilde;o um fen&ocirc;meno atual. Embora o&nbsp;<strong>ORKUT</strong>&nbsp;seja o exemplo mais p</span><span style="font-family:'Trebuchet MS'">opular (<em>no Brasil</em>) deste fen&ocirc;meno,
 existem centenas de redes sociais. Para ver uma rela&ccedil;&atilde;o de redes sociais acesse o link:&nbsp;</span><a href="http://pt.wikipedia.org/wiki/Lista_de_redes_sociais"><span style="font-family:'Trebuchet MS'">http://pt.wikipedia.org/wiki/Lista_de_redes_sociais</span></a></p>
<table border="0" width="1001">
<tbody>
<tr>
<td width="995" bgcolor="#FFFFC6"><span style="font-family:'Trebuchet MS'; font-size:x-small"><img src="-1_lampada.gif" border="0" alt="" width="15" height="15">O Orkut &eacute; uma rede social filiada ao Google, criada em 24 de Janeiro
 de 2004 com o objetivo de ajudar seus membros a conhecer pessoas e manter relacionamentos. Seu nome &eacute; originado no projetista chefe,<span style="color:#0000ff">&nbsp;Orkut B&uuml;y&uuml;kkokten</span>, engenheiro turco do&nbsp;<span style="color:#0000ff">Google</span>.<br>
O alvo inicial do orkut era os Estados Unidos, mas a maioria dos usu&aacute;rios s&atilde;o do Brasil e da &Iacute;ndia. No Brasil &eacute; a rede social com maior participa&ccedil;&atilde;o de brasileiros, com mais de 23 milh&otilde;es de usu&aacute;rios em
 janeiro de 2008. Na &Iacute;ndia &eacute; o segundo mais visitado.<br>
A Sede do orkut era na Calif&oacute;rnia at&eacute; agosto de 2008, quando o Google anunciou que o orkut ser&aacute; operado no Brasil pelo Google Brasil devido a grande quantidade de usu&aacute;rios brasileiros e o crescimento dos assuntos legais.</span></td>
</tr>
</tbody>
</table>
<p><span style="font-family:'Trebuchet MS'">Neste artigo eu apresento uma aplica&ccedil;&atilde;o ASP .NET que tem como objetivo permitir o relacionamento entre pessoas para troca de informa&ccedil;&otilde;es.</span></p>
<table border="0" width="996">
<tbody>
<tr>
<td width="990" bgcolor="#FFFFC6"><span style="font-family:'Trebuchet MS'; font-size:x-small"><img src="-1_lampada.gif" border="0" alt="" width="15" height="15">&nbsp;Rede Social &eacute; uma das formas de representa&ccedil;&atilde;o
 dos relacionamentos afetivos ou profissionais dos seres entre si ou entre seus agrupamentos de interesses m&uacute;tuos. A rede &eacute; respons&aacute;vel pelo compartilhamento de id&eacute;ias entre pessoas que possuem interesses e objetivo em comum e tamb&eacute;m
 valores a serem compartilhados. Assim, um grupo de discuss&atilde;o &eacute; composto por indiv&iacute;duos que possuem identidades semelhantes.&nbsp;<br>
Essas redes sociais est&atilde;o hoje instaladas principalmente na Internet devido ao fato desta possibilitar uma acelera&ccedil;&atilde;o e ampla maneira das id&eacute;ias serem divulgadas e da absor&ccedil;&atilde;o de novos elementos em busca de algo em
 comum.(</span><a href="http://pt.wikipedia.org/wiki/Rede_social"><span style="font-family:'Trebuchet MS'; font-size:x-small">http://pt.wikipedia.org/wiki/Rede_social</span></a><span style="font-family:'Trebuchet MS'; font-size:x-small">)</span></td>
</tr>
</tbody>
</table>
<p><span style="font-family:'Trebuchet MS'">Embora n&atilde;o tenha todas as funcionalidades do&nbsp;<strong>ORKUT</strong>&nbsp;essa pequena aplica&ccedil;&atilde;o permite que o usu&aacute;rio acesse a rede, localize e fa&ccedil;a amigos e compartilhe informa&ccedil;&otilde;es
 que s&atilde;o na ess&ecirc;ncia o principal objetivo de uma rede social.</span></p>
<p><span style="font-family:'Trebuchet MS'"><strong>Obs: Existe um programa gratuito chamado Dolphin 7 que permite que voc&ecirc; crie e configure a sua comunidade para saber mais visite a url:&nbsp;</strong></span><a href="http://www.boonex.com/dolphin/"><span style="font-family:'Trebuchet MS'"><strong>http://www.boonex.com/dolphin/</strong></span></a></p>
<p><span style="font-family:'Trebuchet MS'">Feita esta pequena introdu&ccedil;&atilde;o vamos ao que interessa que &eacute; a apresenta&ccedil;&atilde;o da aplica&ccedil;&atilde;o ASP .NET.</span></p>
<p><span style="font-family:'Trebuchet MS'">Ela n&atilde;o &eacute; de minha autoria eu apenas traduzi os textos para o portugu&ecirc;s e fiz pequenos ajustes para que ela funcionasse no&nbsp;<span style="color:#0000ff">Visual Web Developer 2008 Express Edition.</span></span></p>
<p><em>&nbsp;</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Visual Studio 2008</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>here you can see the share information controller (scrap in orkut):</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&lt;%@&nbsp;Control&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;AutoEventWireup=<span class="cs__string">&quot;true&quot;</span>&nbsp;CodeFile=<span class="cs__string">&quot;GetUserScraps.ascx.cs&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Inherits=<span class="cs__string">&quot;Controls_GetUserScraps&quot;</span>&nbsp;%&gt;&nbsp;
&lt;table&nbsp;cellpadding=<span class="cs__string">&quot;0&quot;</span>&nbsp;cellspacing=<span class="cs__string">&quot;1&quot;</span>&nbsp;border=<span class="cs__string">&quot;0&quot;</span>&nbsp;width=<span class="cs__string">&quot;100%&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;colspan=<span class="cs__string">&quot;3&quot;</span>&nbsp;align=<span class="cs__string">&quot;left&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:GridView&nbsp;ID=<span class="cs__string">&quot;GridViewUserScraps&quot;</span>&nbsp;ItemStyle-VerticalAlign=<span class="cs__string">&quot;Top&quot;</span>&nbsp;AutoGenerateColumns=<span class="cs__string">&quot;False&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GridLines=<span class="cs__string">&quot;None&quot;</span>&nbsp;Width=<span class="cs__string">&quot;100%&quot;</span>&nbsp;ShowHeader=<span class="cs__string">&quot;False&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;AlternatingRowStyle-BackColor=<span class="cs__string">&quot;#A5A5A5&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CellPadding=<span class="cs__string">&quot;4&quot;</span>&nbsp;ForeColor=<span class="cs__string">&quot;#333333&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Columns&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TemplateField&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;table&nbsp;align=<span class="cs__string">&quot;left&quot;</span>&nbsp;cellpadding=<span class="cs__string">&quot;1&quot;</span>&nbsp;cellspacing=<span class="cs__string">&quot;2&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;a&nbsp;href=<span class="cs__string">'&lt;%#getUserHREF(Container.DataItem)%&gt;'</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;img&nbsp;align=<span class="cs__string">&quot;middle&quot;</span>&nbsp;src=<span class="cs__string">'&lt;%#getSRC(Container.DataItem)%&gt;'</span>&nbsp;border=<span class="cs__string">&quot;0&quot;</span>&nbsp;width=<span class="cs__string">&quot;50px&quot;</span>&nbsp;/&gt;&lt;/a&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/table&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;align=<span class="cs__string">&quot;justify&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;%#DataBinder.Eval(Container.DataItem,&nbsp;<span class="cs__string">&quot;Message&quot;</span>)%&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;br&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;br&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;<span class="cs__keyword">class</span>=<span class="cs__string">&quot;SmallBlackText&quot;</span>&gt;Postado&nbsp;em:&nbsp;&amp;nbsp;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Label&nbsp;ID=<span class="cs__string">&quot;lblSendDate&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;Text=<span class="cs__string">'&lt;%#DataBinder.Eval(Container.DataItem,&quot;SendDate&quot;)%&gt;'</span>&gt;&lt;/asp:Label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:TemplateField&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Columns&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowStyle&nbsp;BackColor=<span class="cs__string">&quot;#EFF3FB&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;FooterStyle&nbsp;BackColor=<span class="cs__string">&quot;#507CD1&quot;</span>&nbsp;Font-Bold=<span class="cs__string">&quot;True&quot;</span>&nbsp;ForeColor=<span class="cs__string">&quot;White&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;PagerStyle&nbsp;BackColor=<span class="cs__string">&quot;#2461BF&quot;</span>&nbsp;ForeColor=<span class="cs__string">&quot;White&quot;</span>&nbsp;HorizontalAlign=<span class="cs__string">&quot;Center&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SelectedRowStyle&nbsp;BackColor=<span class="cs__string">&quot;#D1DDF1&quot;</span>&nbsp;Font-Bold=<span class="cs__string">&quot;True&quot;</span>&nbsp;ForeColor=<span class="cs__string">&quot;#333333&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;HeaderStyle&nbsp;BackColor=<span class="cs__string">&quot;#507CD1&quot;</span>&nbsp;Font-Bold=<span class="cs__string">&quot;True&quot;</span>&nbsp;ForeColor=<span class="cs__string">&quot;White&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;EditRowStyle&nbsp;BackColor=<span class="cs__string">&quot;#2461BF&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;AlternatingRowStyle&nbsp;BackColor=<span class="cs__string">&quot;White&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:GridView&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&lt;/table&gt;&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>After download remember delete de .sln and open like a webpage, after apply build to do a functional solution of social network example</em>
</li><li><em>please, after download the source delete the solution and the folder of the same name of the solution, after open your visual studio and rebuild one solution to social network works fine.</em>
</li></ul>
<h1>More Information</h1>
<p><em>for more information, ask me...</em></p>
