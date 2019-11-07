# Using SqlServer Compact Edition with the Entity Framework
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- ADO.NET Entity Framework
- ASP.NET and ADO.NET Entity Framework
- ASP.NET MVC
- Entity Framework
- Console
- C# Language
- Code First
- ASP.NET MVC 4
- SQL Server Compact
- Entity Framework Code First
- EF code first
## Topics
- ADO.NET Entity Framework
- Entity Framework
- ADO.NET Entity Framework Code First
## Updated
- 02/08/2013
## Description

<h1>Introduction</h1>
<p><em>&Agrave;s vezes me perguntam como utilizar&nbsp;<strong>Entity Framework</strong>, em especial com&nbsp;<strong>Code First</strong>, com o&nbsp;<a href="http://dev.mayogax.me/%E2%80%9Dhttp://www.microsoft.com/en-us/sqlserver/editions/2012-editions/compact.aspx%E2%80%9D" target="”_blank”">Sql
 Server Compact Edition</a>.</em></p>
<p><em>Voc&ecirc; pode ler meu&nbsp;<a href="http://dev.mayogax.me/using-sqlserver-compact-edition-4-with-the-entity-framework">blog post</a>&nbsp;para saber mais.</em></p>
<h1><em>The Sql Compact Edition</em></h1>
<p>Essa &eacute; a vers&atilde;o &eacute; a menor e mais simples vers&atilde;o do Sql Server, onde seus dados s&atilde;o salvos emum arquivo&nbsp;<strong>.sdf</strong>, diferente do arquivo .mdf que precisa ter o Sql Server instalado na m&aacute;quina.</p>
<p>&Eacute; uma vers&atilde;o recomendada para aplica&ccedil;&otilde;es do antigo Windows Mobile ou outra pequena aplica&ccedil;&atilde;o que n&atilde;o precise de todos os recursos do Sql Server. &Eacute; uma vers&atilde;o ent&atilde;o embedded, ou seja: voc&ecirc;
 s&oacute; precisa adicionar o arquivo.</p>
<h1>Usando o Entity Framework com SQL CE</h1>
<p>O EF desde sua vers&atilde;o 4 suporta trabalhar com SQL CE tanto no model first, database first e code first. Os passos para model e database first s&atilde;o simples:</p>
<ul>
<li>Adicione o edmx no seu projeto </li><li>Selecione a conex&atilde;o com a base de dados. Possivelmente aqui voc&ecirc; n&atilde;o vai encontrar o conector para a vers&atilde;o 4.0, ent&atilde;o escolha a 3.5
</li><li>Depois de terminado sua modelagem/pegar o modelo do sql v&aacute; no seu web.config
</li><li>Na string de conec&ccedil;&atilde;o do seu emdx troque a propriedade&nbsp;<strong>ProviderManifestToken</strong>de 3.5 para 4.0<em>&nbsp;&nbsp;</em>
</li></ul>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Database.DefaultConnectionFactory = new SqlCeConnectionFactory(&quot;System.Data.SqlServerCe.4.0&quot;);</pre>
<div class="preview">
<pre class="csharp">Database.DefaultConnectionFactory&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCeConnectionFactory(<span class="cs__string">&quot;System.Data.SqlServerCe.4.0&quot;</span>);</pre>
</div>
</div>
</div>
<h1><span>Os projetos</span></h1>
<ul>
<li><em>MsSqlCe.Web&nbsp;- Is the project in asp.net mvc. The ConnectionFactory is in the ApplicationStrat() in the Global.asax</em>
</li><li><em>MsSqlCe.Console - Is the project in console application. The ConnectionFactory is before the begging of the context</em>
</li></ul>
<h1>Obrigada</h1>
<p><em><em>Obrigada por ler. Se voc&ecirc; tiver criticas, sugest&otilde;es ou qualquer coisa do genero fale comigo no&nbsp;<a href="https://twitter.com/MayogaX">twitter&nbsp;</a>&nbsp;ou no meu&nbsp;<a href="http://dev.mayogax.me/">dev blog</a></em></em></p>
