# Test database connection via C#
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- SQL Server
- .NET Framework
## Topics
- Controls
- C#
- ASP.NET
- Windows Forms
- Data Access
- Code Sample
- C# Language Features
## Updated
- 09/13/2015
## Description

<h1>Introduction</h1>
<p><em>You want to validate the database connection, but withou using the database management studio. Is it possible? With this program, you can do it with a SQL connection, just typing the essential data to it. Above it described some steps of this project.</em></p>
<p><em>Just for information, to execute this program is necessary the framework .net 4.5.</em></p>
<p>---------------------------------------</p>
<p>Voc&ecirc; quer validar a conex&atilde;o com o banco de dados, mas sem usar o seu gerenciador de banco. &Eacute; poss&iacute;vel? Com esse programa voc&ecirc; valida uma conex&atilde;o com o SQL, apenas digitando os dados b&aacute;sicos para isso. Abaixo
 est&aacute; descrito alguns passos do projeto.</p>
<p>Apenas como informa&ccedil;&atilde;o, para executar esse programa &eacute; necess&aacute;rio o framework .net 4.5 instalado no computador.</p>
<h1>Description</h1>
<p><em>To develop this program it is necessary to use just the framework .net components, not any another library. So first of all, use the&nbsp;SqlConnection class to create a new instance, using the essential data as the parameters. Then, verify if the connection
 will open and, if so, it was valid. If not, the program will show an error message, with the SQL specific details.</em></p>
<p><em>The erros that is possible to be shown is that the user &quot;A&quot; doesn't exist, the database &quot;X&quot; doesn't exist, the server was not found and other types.</em></p>
<p>---------------------------------------</p>
<p>Para desenvolver esse programa, &eacute; necess&aacute;rio utilizar apenas os componentes do framework .net, sem nenhuma outra biblioteca. Primeiro, utilize a classe&nbsp;<em>SqlConnection para criar uma nova inst&acirc;ncia, usando apenas os dados essenciais
 como par&acirc;metro. Depois, verifique se a conex&atilde;o foi aberta e, em caso positivo, a conex&atilde;o &eacute; v&aacute;lida. Em caso negativo, o programa ir&aacute; exibir uma mensagem de erro, com os detalhes espec&iacute;ficos do SQL.</em></p>
<p><em>Os erros poss&iacute;veis s&atilde;o por causa do usu&aacute;rio &quot;A&quot; n&atilde;o existir, o banco &quot;X&quot; n&atilde;o existir, o servidor n&atilde;o foi encontrado, entre outros tipos.</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">try</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//----------------PT-BR----------------//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Tenta&nbsp;abrir&nbsp;a&nbsp;conex&atilde;o&nbsp;com&nbsp;o&nbsp;banco&nbsp;de&nbsp;dados.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//----------------EN-US----------------//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Try&nbsp;to&nbsp;open&nbsp;the&nbsp;connection&nbsp;with&nbsp;the&nbsp;database.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Open();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//----------------PT-BR----------------//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Se&nbsp;a&nbsp;conex&atilde;o&nbsp;estiver&nbsp;aberta,&nbsp;&eacute;&nbsp;executado&nbsp;o&nbsp;bloco&nbsp;abaixo.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//----------------EN-US----------------//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;If&nbsp;the&nbsp;connection&nbsp;is&nbsp;open,&nbsp;the&nbsp;code&nbsp;below&nbsp;is&nbsp;executed.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(connection.State&nbsp;==&nbsp;ConnectionState.Open)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//----------------PT-BR----------------//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Fecha&nbsp;a&nbsp;conex&atilde;o,&nbsp;pois&nbsp;j&aacute;&nbsp;entrou&nbsp;na&nbsp;condi&ccedil;&atilde;o.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//----------------EN-US----------------//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Close&nbsp;the&nbsp;connection,&nbsp;because&nbsp;it's&nbsp;inside&nbsp;this&nbsp;condition.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Close();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;A&nbsp;conex&atilde;o&nbsp;est&aacute;&nbsp;v&aacute;lida!&quot;</span>,&nbsp;<span class="cs__string">&quot;Sucesso&quot;</span>,&nbsp;MessageBoxButtons.OK,&nbsp;MessageBoxIcon.Information);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<p><span>In the class below is located the code that execute all these rules.</span></p>
<ul>
<li><em>Form1.cs</em> </li></ul>
<p>---------------------------------------</p>
<p>Na classe abaixo est&aacute; localizado o c&oacute;digo que executa todas essas regras.</p>
<ul>
<li><em>Form1.cs</em> </li></ul>
<p><span style="font-size:2em">More Information</span></p>
<p><em>This program was developed using the Visual Studio 2012 and the framework .net 4.5.</em></p>
<p>---------------------------------------</p>
<p>Esse programa foi desenvolvido utilizando o Visual Studio 2012 e o framework .net 4.5</p>
<p><em><br>
</em></p>
