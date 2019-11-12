# Semplice autenticazione ASP.NET MVC
## Requires
- Visual Studio 2015
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET MVC
- Razor
- FormsAuthentication
## Topics
- ASP.NET MVC Basics
- Administration Tool
- Sicurezza
## Updated
- 09/23/2016
## Description

<h1>Introduzione</h1>
<p><em>Questo codice di esempio dimostra come creare una semplice area protetta di un sito web ASP.NET MVC. Molto spesso capita che i gestori di siti web hanno la necessit&agrave; di gestire alcuni contenuti (ad esempio la fotogallery o altri contenuti) del
 loro sito web.</em></p>
<p><em>Ecco un semplice modo per proteggere un'area di un sito web MVC senza impiegare magari l'autenticazione Membership che risulterebbe eccessiva come soluzione. Alcune versioni del framework, specie quelle pi&ugrave; recenti, segnalano il metodo
<strong>Authenticate</strong> della classe <strong>FormsAuthentication</strong> <span style="text-decoration:underline">
obsoleta</span>; infatti chiunque accede al file web.config &egrave; in grado di recuperare le credenziali.Consiglio di utilizzare che questo codice di esempio solo per scenari di piccola entit&agrave;, in piccole applicazioni web.</em></p>
<p><em><br>
Questo esempio &egrave; utile quando serve una sola persona a gestire il sito web, in siti web dove non figurano diversi ruoli di utenti (amministratori, contabili, utenti, ecc..) &nbsp;&nbsp;</em></p>
<h1><span>Configurazione del web.config</span></h1>
<p><em>&nbsp;Modifichiamo quindi il tag autenticazione basata su form presente nel web.config del nostro sito web:</em></p>
<p><em>&nbsp;</em></p>
<div class="scriptcode"><em>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml">&nbsp;<span class="xml__tag_start">&lt;authentication</span>&nbsp;<span class="xml__attr_name">mode</span>=<span class="xml__attr_value">&quot;Forms&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;forms</span>&nbsp;<span class="xml__attr_name">loginUrl</span>=<span class="xml__attr_value">&quot;~/Account/login&quot;</span>&nbsp;<span class="xml__attr_name">timeout</span>=<span class="xml__attr_value">&quot;2880&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;credentials</span>&nbsp;<span class="xml__attr_name">passwordFormat</span>=<span class="xml__attr_value">&quot;Clear|SHA1|MD5&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;user</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;user&quot;</span>&nbsp;<span class="xml__attr_name">password</span>=<span class="xml__attr_value">&quot;admin&quot;</span><span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/credentials&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/forms&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/authentication&gt;</span></pre>
</div>
</div>
</em></div>
<p><em>&nbsp;</em></p>
<div class="endscriptcode"><em>&nbsp;</em></div>
<p><span style="font-size:20px; font-weight:bold">ActionResult Login</span></p>
<p><em>&nbsp;Usiamo di ActionResult chiamata Login, una GET e l'altra POST. La post ha il seguente codice:</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;POST:&nbsp;/Admin/Login</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[AllowAnonymous]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Login(LoginViewModel&nbsp;model,&nbsp;<span class="cs__keyword">string</span>&nbsp;returnUrl)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.ModelState.IsValid&nbsp;&amp;&amp;&nbsp;FormsAuthentication.Authenticate(model.UserName,&nbsp;model.Password))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FormsAuthentication.SetAuthCookie(model.UserName,&nbsp;model.RememberMe);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.Url.IsLocalUrl(returnUrl))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Redirect(returnUrl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>,&nbsp;<span class="cs__string">&quot;admin&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.ModelState.AddModelError(<span class="cs__string">&quot;&quot;</span>,&nbsp;<span class="cs__string">&quot;Credenziali&nbsp;non&nbsp;corrette.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View(model);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
