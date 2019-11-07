# Send an email using asp.net c# code
## Requires
- 
## License
- MIT
## Technologies
- C#
- ASP.NET
- ASP.NET MVC 4
- Visual Studio 2013
## Topics
- Send Email
- ASP.NET MVC
## Updated
- 10/30/2015
## Description

<h1>Introduction</h1>
<p><em><span>Most of the times we have seen suggestion/complaint form in the footer of many websites but what if you want the same thing in your project?</span></em></p>
<p><span>Then i am here to guide you. As far as i know there are two methods to implement this:</span></p>
<ol>
<li>Make a database and save the form details in that so when the site admin logins, he/she can see them.
</li><li>Generate an email from the code so you can get an email and can retrieve that on the go.
</li></ol>
<p><span>I will explain the second method here. This method will simply guide you how to send an email and then you can use this in any way you like.</span></p>
<h1><span>Building the Sample</span></h1>
<p><span>First of all i created a form in html view of a mvc project which looks like this:</span></p>
<p><span><img id="144175" src="144175-form.jpg" alt="Sample Form" width="1269" height="510" style="vertical-align:middle"><br>
</span></p>
<p>&nbsp;</p>
<p><span>HTML for this form is:</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">@using (Html.BeginForm(&quot;email&quot;, &quot;Home&quot;, FormMethod.Post))
                            {
        &lt;div class=&quot;row&quot;&gt;
            &lt;div class=&quot;col-lg-12&quot;&gt;
                &lt;form name=&quot;sentMessage&quot; id=&quot;contactForm&quot; novalidate&gt;
                    &lt;div class=&quot;row&quot;&gt;
                        &lt;div class=&quot;col-md-6&quot;&gt;
                            &lt;div class=&quot;form-group&quot;&gt;
                                &lt;input type=&quot;text&quot; name=&quot;sname&quot; class=&quot;form-control&quot; placeholder=&quot;Your Name *&quot; id=&quot;name&quot; required data-validation-required-message=&quot;Please enter your name.&quot;&gt;
                                &lt;p class=&quot;help-block text-danger&quot;&gt;&lt;/p&gt;
                            &lt;/div&gt;
                            &lt;div class=&quot;form-group&quot;&gt;
                                &lt;input type=&quot;email&quot; name=&quot;semail&quot;class=&quot;form-control&quot; placeholder=&quot;Your Email *&quot; id=&quot;email&quot; required data-validation-required-message=&quot;Please enter your email address.&quot;&gt;
                                &lt;p class=&quot;help-block text-danger&quot;&gt;&lt;/p&gt;
                            &lt;/div&gt;
                            &lt;div class=&quot;form-group&quot;&gt;
                                &lt;input type=&quot;tel&quot; name=&quot;sphone&quot;class=&quot;form-control&quot; placeholder=&quot;Your Phone *&quot; id=&quot;phone&quot; required data-validation-required-message=&quot;Please enter your phone number.&quot;&gt;
                                &lt;p class=&quot;help-block text-danger&quot;&gt;&lt;/p&gt;
                            &lt;/div&gt;
                        &lt;/div&gt;
                        &lt;div class=&quot;col-md-6&quot;&gt;
                            &lt;div class=&quot;form-group&quot;&gt;
                                &lt;textarea class=&quot;form-control&quot; name=&quot;smessage&quot; placeholder=&quot;Your Message *&quot; id=&quot;message&quot; required data-validation-required-message=&quot;Please enter a message.&quot;&gt;&lt;/textarea&gt;
                                &lt;p class=&quot;help-block text-danger&quot;&gt;&lt;/p&gt;
                            &lt;/div&gt;
                        &lt;/div&gt;
                        &lt;div class=&quot;clearfix&quot;&gt;&lt;/div&gt;
                        &lt;div class=&quot;col-lg-12 text-center&quot;&gt;
                            &lt;div id=&quot;success&quot;&gt;&lt;/div&gt;
                           
                            &lt;button type=&quot;submit&quot; class=&quot;btn btn-xl&quot; onclick=&quot;this.form.submit();&quot;&gt;Send Message&lt;/button&gt;
                            
                        &lt;/div&gt;
                    &lt;/div&gt;
                &lt;/form&gt;
            &lt;/div&gt;
        &lt;/div&gt;
}</pre>
<div class="preview">
<pre class="html">@using&nbsp;(Html.BeginForm(&quot;email&quot;,&nbsp;&quot;Home&quot;,&nbsp;FormMethod.Post))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;row&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-lg-12&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;form</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;sentMessage&quot;</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;contactForm&quot;</span>&nbsp;novalidate<span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;row&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-md-6&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;sname&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span>&nbsp;<span class="html__attr_name">placeholder</span>=<span class="html__attr_value">&quot;Your&nbsp;Name&nbsp;*&quot;</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;name&quot;</span>&nbsp;required&nbsp;<span class="html__attr_name">data-validation-required-message</span>=<span class="html__attr_value">&quot;Please&nbsp;enter&nbsp;your&nbsp;name.&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;help-block&nbsp;text-danger&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;email&quot;</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;semail&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span>&nbsp;<span class="html__attr_name">placeholder</span>=<span class="html__attr_value">&quot;Your&nbsp;Email&nbsp;*&quot;</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;email&quot;</span>&nbsp;required&nbsp;<span class="html__attr_name">data-validation-required-message</span>=<span class="html__attr_value">&quot;Please&nbsp;enter&nbsp;your&nbsp;email&nbsp;address.&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;help-block&nbsp;text-danger&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;tel&quot;</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;sphone&quot;</span><span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span>&nbsp;<span class="html__attr_name">placeholder</span>=<span class="html__attr_value">&quot;Your&nbsp;Phone&nbsp;*&quot;</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;phone&quot;</span>&nbsp;required&nbsp;<span class="html__attr_name">data-validation-required-message</span>=<span class="html__attr_value">&quot;Please&nbsp;enter&nbsp;your&nbsp;phone&nbsp;number.&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;help-block&nbsp;text-danger&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-md-6&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-group&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;textarea</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;form-control&quot;</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;smessage&quot;</span>&nbsp;<span class="html__attr_name">placeholder</span>=<span class="html__attr_value">&quot;Your&nbsp;Message&nbsp;*&quot;</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;message&quot;</span>&nbsp;required&nbsp;<span class="html__attr_name">data-validation-required-message</span>=<span class="html__attr_value">&quot;Please&nbsp;enter&nbsp;a&nbsp;message.&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/textarea&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;help-block&nbsp;text-danger&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;clearfix&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;col-lg-12&nbsp;text-center&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;success&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;button</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;submit&quot;</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;btn&nbsp;btn-xl&quot;</span>&nbsp;<span class="html__attr_name">onclick</span>=<span class="html__attr_value">&quot;this.form.submit();&quot;</span><span class="html__tag_start">&gt;</span>Send&nbsp;Message<span class="html__tag_end">&lt;/button&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/form&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
}</pre>
</div>
</div>
</div>
<p><span><span>If you copy and paste this html it wont work as desired due to the css. So dont get confused with the code this is just to guide you a bit, you can make any kind of form you like.</span><br>
<span>If you observe the start of HTML I have used</span></span></p>
<p><span><span>&nbsp;</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">@using (Html.BeginForm(&quot;email&quot;, &quot;Home&quot;, FormMethod.Post))</pre>
<div class="preview">
<pre class="csharp">@<span class="cs__keyword">using</span>&nbsp;(Html.BeginForm(<span class="cs__string">&quot;email&quot;</span>,&nbsp;<span class="cs__string">&quot;Home&quot;</span>,&nbsp;FormMethod.Post))</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>this is used to call the controller actionresult method when the user submits this form. &quot;email&quot; is the name of actionresult method and &quot;Home&quot; is the controller. That is the main thing where the whole stuff happens.</span><br>
<br>
<span>In controller there is a method and an actionmethod that calls that method.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> public async Task&lt;ActionResult&gt; email(FormCollection form)
        {
            var name = form[&quot;sname&quot;];
            var email = form[&quot;semail&quot;];
            var messages = form[&quot;smessage&quot;];
            var phone = form[&quot;sphone&quot;];
            var x = await SendEmail(name,email,messages,phone);
            if (x == &quot;sent&quot;)
                ViewData[&quot;esent&quot;]= &quot;Your Message Has Been Sent&quot;;
            return RedirectToAction(&quot;Index&quot;);
        }
        private async Task&lt;string&gt; SendEmail(string name, string email, string messages, string phone)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(&quot;abc@xyz.com&quot;));  // replace with receiver's email id 
            message.From = new MailAddress(&quot;xyz@abc.com&quot;);  // replace with sender's email id
            message.Subject = &quot;Message From&quot; &#43; email;
            message.Body = &quot;Name: &quot; &#43; name &#43; &quot;\nFrom: &quot; &#43; email &#43; &quot;\nPhone: &quot; &#43; phone &#43; &quot;\n&quot; &#43; messages;
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = &quot;xyz@abc.com&quot;,  // replace with sender's email id
                    Password = &quot;*****&quot;  // replace with password
                };
                smtp.Credentials = credential;
                smtp.Host = &quot;smtp-mail.outlook.com&quot;;
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return &quot;sent&quot;;
            }
        }</pre>
<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;ActionResult&gt;&nbsp;email(FormCollection&nbsp;form)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;name&nbsp;=&nbsp;form[<span class="cs__string">&quot;sname&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;email&nbsp;=&nbsp;form[<span class="cs__string">&quot;semail&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;messages&nbsp;=&nbsp;form[<span class="cs__string">&quot;smessage&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;phone&nbsp;=&nbsp;form[<span class="cs__string">&quot;sphone&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;x&nbsp;=&nbsp;await&nbsp;SendEmail(name,email,messages,phone);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(x&nbsp;==&nbsp;<span class="cs__string">&quot;sent&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewData[<span class="cs__string">&quot;esent&quot;</span>]=&nbsp;<span class="cs__string">&quot;Your&nbsp;Message&nbsp;Has&nbsp;Been&nbsp;Sent&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;RedirectToAction(<span class="cs__string">&quot;Index&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;async&nbsp;Task&lt;<span class="cs__keyword">string</span>&gt;&nbsp;SendEmail(<span class="cs__keyword">string</span>&nbsp;name,&nbsp;<span class="cs__keyword">string</span>&nbsp;email,&nbsp;<span class="cs__keyword">string</span>&nbsp;messages,&nbsp;<span class="cs__keyword">string</span>&nbsp;phone)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;message&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MailMessage();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message.To.Add(<span class="cs__keyword">new</span>&nbsp;MailAddress(<span class="cs__string">&quot;abc@xyz.com&quot;</span>));&nbsp;&nbsp;<span class="cs__com">//&nbsp;replace&nbsp;with&nbsp;receiver's&nbsp;email&nbsp;id&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message.From&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MailAddress(<span class="cs__string">&quot;xyz@abc.com&quot;</span>);&nbsp;&nbsp;<span class="cs__com">//&nbsp;replace&nbsp;with&nbsp;sender's&nbsp;email&nbsp;id</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message.Subject&nbsp;=&nbsp;<span class="cs__string">&quot;Message&nbsp;From&quot;</span>&nbsp;&#43;&nbsp;email;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message.Body&nbsp;=&nbsp;<span class="cs__string">&quot;Name:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;name&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\nFrom:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;email&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\nPhone:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;phone&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\n&quot;</span>&nbsp;&#43;&nbsp;messages;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message.IsBodyHtml&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;smtp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SmtpClient())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;credential&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;NetworkCredential&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UserName&nbsp;=&nbsp;<span class="cs__string">&quot;xyz@abc.com&quot;</span>,&nbsp;&nbsp;<span class="cs__com">//&nbsp;replace&nbsp;with&nbsp;sender's&nbsp;email&nbsp;id</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Password&nbsp;=&nbsp;<span class="cs__string">&quot;*****&quot;</span>&nbsp;&nbsp;<span class="cs__com">//&nbsp;replace&nbsp;with&nbsp;password</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;smtp.Credentials&nbsp;=&nbsp;credential;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;smtp.Host&nbsp;=&nbsp;<span class="cs__string">&quot;smtp-mail.outlook.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;smtp.Port&nbsp;=&nbsp;<span class="cs__number">587</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;smtp.EnableSsl&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;smtp.SendMailAsync(message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;sent&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
</div>
<div class="endscriptcode"><span>So whats happening here is that i have created an async task of actionresult type which is called when user clicks the submit button and values from the form are passed into it.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public async Task&lt;ActionResult&gt; email(FormCollection form)
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;ActionResult&gt;&nbsp;email(FormCollection&nbsp;form)&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>Async is used when you have to wait for an action to complete before moving ahead. as this process requires some time so we need to use async type and this allows us to use await keyword in it.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private async Task&lt;string&gt; SendEmail(string name, string email, string messages, string phone)</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;async&nbsp;Task&lt;<span class="cs__keyword">string</span>&gt;&nbsp;SendEmail(<span class="cs__keyword">string</span>&nbsp;name,&nbsp;<span class="cs__keyword">string</span>&nbsp;email,&nbsp;<span class="cs__keyword">string</span>&nbsp;messages,&nbsp;<span class="cs__keyword">string</span>&nbsp;phone)</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>This is a method which returns a string to tell the status. I have passed all the form values which i need in my email.</span></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> message.To.Add(new MailAddress(&quot;abc@xyz.com&quot;));  // replace with receiver's email id</pre>
<div class="preview">
<pre class="csharp">&nbsp;message.To.Add(<span class="cs__keyword">new</span>&nbsp;MailAddress(<span class="cs__string">&quot;abc@xyz.com&quot;</span>));&nbsp;&nbsp;<span class="cs__com">//&nbsp;replace&nbsp;with&nbsp;receiver's&nbsp;email&nbsp;id</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>here we have to write the email id on which we want to recieve the email</span></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">message.From = new MailAddress(&quot;xyz@abc.com&quot;);  // replace with sender's email id</pre>
<div class="preview">
<pre class="csharp">message.From&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MailAddress(<span class="cs__string">&quot;xyz@abc.com&quot;</span>);&nbsp;&nbsp;<span class="cs__com">//&nbsp;replace&nbsp;with&nbsp;sender's&nbsp;email&nbsp;id</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>here goes the senders email id, i have used my id in both so i am sending an email from my one id to another which contains the users query/suggestion, contact, name and email so i can respond he later if i want to</span></div>
<br>
</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">message.Subject = &quot;Message From&quot; &#43; email;</pre>
<div class="preview">
<pre class="csharp">message.Subject&nbsp;=&nbsp;<span class="cs__string">&quot;Message&nbsp;From&quot;</span>&nbsp;&#43;&nbsp;email;&nbsp;</pre>
</div>
</div>
</div>
<span>here goes the subject, i have write the user's email in the subject, you can write anything you like</span><br>
</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">message.Body = &quot;Name: &quot; &#43; name &#43; &quot;\nFrom: &quot; &#43; email &#43; &quot;\nPhone: &quot; &#43; phone &#43; &quot;\n&quot; &#43; messages;</pre>
<div class="preview">
<pre class="js">message.Body&nbsp;=&nbsp;<span class="js__string">&quot;Name:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;name&nbsp;&#43;&nbsp;<span class="js__string">&quot;\nFrom:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;email&nbsp;&#43;&nbsp;<span class="js__string">&quot;\nPhone:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;phone&nbsp;&#43;&nbsp;<span class="js__string">&quot;\n&quot;</span>&nbsp;&#43;&nbsp;messages;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>here goes the body, i have write users name, email, phone and message in the body. You can get the desired things according to your requirements and form fields.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> var credential = new NetworkCredential
                {
                    UserName = &quot;xyz@abc.com&quot;,  // replace with sender's email id
                    Password = &quot;*****&quot;  // replace with password
                };</pre>
<div class="preview">
<pre class="js">&nbsp;<span class="js__statement">var</span>&nbsp;credential&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;NetworkCredential&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UserName&nbsp;=&nbsp;<span class="js__string">&quot;xyz@abc.com&quot;</span>,&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;replace&nbsp;with&nbsp;sender's&nbsp;email&nbsp;id</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Password&nbsp;=&nbsp;<span class="js__string">&quot;*****&quot;</span>&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;replace&nbsp;with&nbsp;password</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>here you have to give your email id and password of that id which you are using to send email. so our code can login using these credentials.</span></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">  smtp.Credentials = credential;
                smtp.Host = &quot;smtp-mail.outlook.com&quot;;
                smtp.Port = 587;
                smtp.EnableSsl = true;</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;smtp.Credentials&nbsp;=&nbsp;credential;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;smtp.Host&nbsp;=&nbsp;<span class="js__string">&quot;smtp-mail.outlook.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;smtp.Port&nbsp;=&nbsp;<span class="js__num">587</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;smtp.EnableSsl&nbsp;=&nbsp;true;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>these are the setting of hotmail/outlook. I was using my hotmail id as a sender so these work for that. If you are using live/outlook/hotmail you can use these ones but for other clients you can search Host and Port
 and replace these with those and it will work like a charm.</span></div>
</span></div>
</span></div>
</span></div>
</span></div>
</span></div>
<ul>
</ul>
<h1>More Information</h1>
<p><span>That's all folks, this is very easy to implement and i have tried my best to explain you step by step.</span></p>
<p><span>For more info, queries or to contact me kindly visit my blog:<br>
http://csdebugger.blogspot.com/&nbsp;</span></p>
