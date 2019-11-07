# Using Unit of Work pattern with classic ado.net
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- SQL Server
- ASP.NET
- Data Access
- Unit of Work
## Topics
- Architecture and Design
- Data Access
- Design Patterns
- Unit of Work
## Updated
- 05/18/2014
## Description
&nbsp;
<h1>Introdu&ccedil;&atilde;o</h1>
<p><span>Este &eacute; exemplo de como utilizar o padr&atilde;o &quot;Unit of Work&quot;, ou Unidade de Trabalho em portugu&ecirc;s, em sua aplica&ccedil;&atilde;o. O exemplo foi divido em 3 camadas, sendo: DAL (camada de acesso a dados), Model (camada com as entidades
 da aplica&ccedil;&atilde;o) e UI (camada de interface gr&aacute;fica, onde foi utilizado Asp Net Mvc). N&atilde;o foi utilizado frameworks ORM.&nbsp;</span></p>
<h1>Description</h1>
<p><img class="aligncenter size-full x_wp-image-141" src="-sdjxl.png?w=620" alt="sdjXl"></p>
<p><strong>Unit of Work para gerenciar sua persist&ecirc;ncia no banco de dados</strong></p>
<p>De acordo com Martin Fowler, o padr&atilde;o &ldquo;Unit Of Work&rdquo;&nbsp;mant&eacute;m uma lista de objetos afetados por uma transa&ccedil;&atilde;o, coordena a escrita de mudan&ccedil;as e trata poss&iacute;veis problemas de concorr&ecirc;ncia.&nbsp;</p>
<p>Com uma sintaxe simples de uso, o padr&atilde;o Unit of Work pode ser a solu&ccedil;&atilde;o para o terr&iacute;vel problema de concorr&ecirc;ncia nas transa&ccedil;&otilde;es.</p>
<p>Mesmo estando&nbsp;presente nos mais famosos ORMs .Net, como Entity Framework e NHibernate &ndash; atrav&eacute;s dos objetos DbContext e ITransaction, respectivamente &ndash; em muitas situa&ccedil;&otilde;es precisaremos&nbsp;de&nbsp;algo mais robusto,
 que nos permita gravar logs, promover a testabilidade e ter um gerenciamento personalizado&nbsp;das transa&ccedil;&otilde;es,&nbsp;tornando necess&aacute;rio a cria&ccedil;&atilde;o de uma unidade de trabalho</p>
<h1><span style="color:#000000">Exemplos de c&oacute;digo</span></h1>
<h2><span style="color:#ff0000">Interface</span></h2>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public interface IUnitOfWork : IDisposable
    {
        bool _hasConnection { get; set; }
        IDbTransaction _transaction { get; set; }
        IDbConnection _connection { get; set; }
        IDbCommand CreateCommand();
        void SaveChanges();
        void Dispose();
    }</pre>
<div class="preview">
<pre class="js">public&nbsp;interface&nbsp;IUnitOfWork&nbsp;:&nbsp;IDisposable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bool&nbsp;_hasConnection&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IDbTransaction&nbsp;_transaction&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IDbConnection&nbsp;_connection&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IDbCommand&nbsp;CreateCommand();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">void</span>&nbsp;SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">void</span>&nbsp;Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2><span style="color:#ff0000"><strong>Factory</strong></span></h2>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class UnitOfWorkFactory
    {
        public static IUnitOfWork Create()
        {
            string connString = ConfigurationManager.ConnectionStrings[&quot;ConnectionString&quot;].ConnectionString;

            var connection = new SqlConnection(connString);

            // Inicia a conex&atilde;o
            connection.Open();

            // Retorna uma nova unidade de trabalho
            return new DemoUoWUnitOfWork(connection, true);
        }
    }</pre>
<div class="preview">
<pre class="js">public&nbsp;class&nbsp;UnitOfWorkFactory&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;IUnitOfWork&nbsp;Create()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;connString&nbsp;=&nbsp;ConfigurationManager.ConnectionStrings[<span class="js__string">&quot;ConnectionString&quot;</span>].ConnectionString;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;connection&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SqlConnection(connString);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Inicia&nbsp;a&nbsp;conex&atilde;o</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Open();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Retorna&nbsp;uma&nbsp;nova&nbsp;unidade&nbsp;de&nbsp;trabalho</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__operator">new</span>&nbsp;DemoUoWUnitOfWork(connection,&nbsp;true);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
&nbsp;
<h2 class="endscriptcode"><span style="color:#ff0000">Reposit&oacute;rio</span></h2>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar Script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> public bool DeletePeople(long id)
        {
            // Inicia nosso objeto de comando.
            using (var cmd = _unitOfWork.CreateCommand())
            {
                cmd.CommandText = &quot;DELETE PEOPLE WHERE id = @Id&quot;;

                // Adiciona um par&acirc;metetro via IDbCommand, para evitar SqlInjection
                SqlParameter parameter = new SqlParameter() { Value = id, ParameterName = &quot;@Id&quot; };

                cmd.Parameters.Add(parameter);

                bool success = cmd.ExecuteNonQuery() &gt; 0;

                //Comita nossa transa&ccedil;&atilde;o.
                _unitOfWork.SaveChanges();

                return success;
            }
        }</pre>
<div class="preview">
<pre class="js">&nbsp;public&nbsp;bool&nbsp;DeletePeople(long&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Inicia&nbsp;nosso&nbsp;objeto&nbsp;de&nbsp;comando.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;cmd&nbsp;=&nbsp;_unitOfWork.CreateCommand())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.CommandText&nbsp;=&nbsp;<span class="js__string">&quot;DELETE&nbsp;PEOPLE&nbsp;WHERE&nbsp;id&nbsp;=&nbsp;@Id&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Adiciona&nbsp;um&nbsp;par&acirc;metetro&nbsp;via&nbsp;IDbCommand,&nbsp;para&nbsp;evitar&nbsp;SqlInjection</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SqlParameter&nbsp;parameter&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SqlParameter()&nbsp;<span class="js__brace">{</span>&nbsp;Value&nbsp;=&nbsp;id,&nbsp;ParameterName&nbsp;=&nbsp;<span class="js__string">&quot;@Id&quot;</span>&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.Add(parameter);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bool&nbsp;success&nbsp;=&nbsp;cmd.ExecuteNonQuery()&nbsp;&gt;&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Comita&nbsp;nossa&nbsp;transa&ccedil;&atilde;o.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_unitOfWork.SaveChanges();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;success;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong><span style="font-size:2em">Requesitos</span></strong></div>
</div>
<p>Visual Studio 2010 &#43;</p>
<p>.Net Framework 4.5</p>
