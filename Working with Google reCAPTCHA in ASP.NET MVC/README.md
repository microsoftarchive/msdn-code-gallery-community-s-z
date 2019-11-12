# Working with Google reCAPTCHA in ASP.NET MVC
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- ASP.NET MVC
## Topics
- Google reCAPTCHA
## Updated
- 02/01/2015
## Description

<p>In this tutorial, you learn how to working with google reCAPTCHA in ASP.NET MVC using Recaptcha for .NET nuget package with source code.</p>
<p><img id="133251" src="133251-recaptcha-demo.png" alt="" width="1297" height="491"></p>
<p>For full documantation refer this site:&nbsp;<a title="Working with Google reCAPTCHA in ASP.NET MVC" href="http://studyoverflow.com/asp-mvc/working-google-recaptcha-asp-net-mvc/" target="_blank">Working with Google reCAPTCHA in ASP.NET MVC</a></p>
<p>In this source, I have create a Contact page with captcha varification.</p>
<p>Here, we have also used Recaptcha for .NET nuget package. Recaptcha for .NET is a library that allows a developer to easily integrate Google&rsquo;s Recaptcha service (the most popular captcha control) in an ASP.NET Web Forms or ASP.NET MVC web application.</p>
<p><strong>web.config</strong></p>
<pre class="prettyprint prettyprinted"><span class="tag">&lt;appSettings&gt;</span><span class="pln">
    </span><span class="tag">&lt;add</span><span class="pln"> </span><span class="atn">name</span><span class="pun">=</span><span class="atv">&quot;recaptchaPublicKey&quot;</span><span class="pln"> </span><span class="atn">value</span><span class="pun">=</span><span class="atv">&quot;Your Public Key&quot;</span><span class="pln"> </span><span class="tag">/&gt;</span><span class="pln">
    </span><span class="tag">&lt;add</span><span class="pln"> </span><span class="atn">name</span><span class="pun">=</span><span class="atv">&quot;recaptchaPrivateKey&quot;</span><span class="pln"> </span><span class="atn">value</span><span class="pun">=</span><span class="atv">&quot;Your Private Key&quot;</span><span class="pln"> </span><span class="tag">/&gt;</span><span class="pln">
</span><span class="tag">&lt;/appSettings&gt;</span></pre>
<pre class="prettyprint prettyprinted"><br></pre>
<pre class="prettyprint prettyprinted"><strong>Contact.cs</strong></pre>
<pre class="prettyprint prettyprinted"><pre class="prettyprint prettyprinted"><span class="kwd">public</span><span class="pln"> </span><span class="kwd">class</span><span class="pln"> </span><span class="typ">Contact</span><span class="pln">
</span><span class="pun">{</span><span class="pln">
      </span><span class="kwd">public</span><span class="pln"> </span><span class="kwd">int</span><span class="pln"> </span><span class="typ">Id</span><span class="pln"> </span><span class="pun">{</span><span class="pln"> </span><span class="kwd">get</span><span class="pun">;</span><span class="pln"> </span><span class="kwd">set</span><span class="pun">;</span><span class="pln"> </span><span class="pun">}</span><span class="pln">
      </span><span class="kwd">public</span><span class="pln"> </span><span class="kwd">string</span><span class="pln"> </span><span class="typ">Name</span><span class="pln"> </span><span class="pun">{</span><span class="pln"> </span><span class="kwd">get</span><span class="pun">;</span><span class="pln"> </span><span class="kwd">set</span><span class="pun">;</span><span class="pln"> </span><span class="pun">}</span><span class="pln">

      </span><span class="pun">[</span><span class="typ">EmailAddress</span><span class="pun">]</span><span class="pln">
      </span><span class="kwd">public</span><span class="pln"> </span><span class="kwd">string</span><span class="pln"> </span><span class="typ">Email</span><span class="pln"> </span><span class="pun">{</span><span class="pln"> </span><span class="kwd">get</span><span class="pun">;</span><span class="pln"> </span><span class="kwd">set</span><span class="pun">;</span><span class="pln"> </span><span class="pun">}</span><span class="pln">

      </span><span class="kwd">public</span><span class="pln"> </span><span class="kwd">string</span><span class="pln"> </span><span class="typ">Comment</span><span class="pln"> </span><span class="pun">{</span><span class="pln"> </span><span class="kwd">get</span><span class="pun">;</span><span class="pln"> </span><span class="kwd">set</span><span class="pun">;</span><span class="pln"> </span><span class="pun">}</span><span class="pln">
</span><span class="pun">}</span></pre>
<br></pre>
<pre class="prettyprint prettyprinted"><p><strong>HomeController.cs</strong></p>
<pre class="prettyprint prettyprinted"><span class="kwd">public</span><span class="pln"> </span><span class="typ">ActionResult</span><span class="pln"> </span><span class="typ">Contact</span><span class="pun">()</span><span class="pln">
</span><span class="pun">{</span><span class="pln">
    </span><span class="kwd">return</span><span class="pln"> </span><span class="typ">View</span><span class="pun">();</span><span class="pln">
</span><span class="pun">}</span></pre>
<p><strong>Contact.cshtml</strong></p>
<pre class="prettyprint prettyprinted"><span class="lit">@using</span><span class="pln"> </span><span class="typ">Recaptcha</span><span class="pun">.</span><span class="typ">Web</span><span class="pun">.</span><span class="typ">Mvc</span><span class="pln">

</span><span class="lit">@model</span><span class="pln"> </span><span class="typ">MVCreCaptchaDemo</span><span class="pun">.</span><span class="typ">Models</span><span class="pun">.</span><span class="typ">Contact</span><span class="pln">
</span><span class="pun">@{</span><span class="pln">
    </span><span class="typ">ViewBag</span><span class="pun">.</span><span class="typ">Title</span><span class="pln"> </span><span class="pun">=</span><span class="pln"> </span><span class="str">&quot;Contact&quot;</span><span class="pun">;</span><span class="pln">
</span><span class="pun">}</span><span class="pln">

</span><span class="str">&lt;h2&gt;</span><span class="typ">Contact</span><span class="pun">&lt;/</span><span class="pln">h2</span><span class="pun">&gt;</span><span class="pln">

</span><span class="lit">@using</span><span class="pln"> </span><span class="pun">(</span><span class="typ">Html</span><span class="pun">.</span><span class="typ">BeginForm</span><span class="pun">())</span><span class="pln"> </span><span class="pun">{</span><span class="pln">
           </span><span class="lit">@Html</span><span class="pun">.</span><span class="typ">ValidationSummary</span><span class="pun">(</span><span class="kwd">true</span><span class="pun">)</span><span class="pln">

           </span><span class="str">&lt;fieldset&gt;</span><span class="pln">
               </span><span class="str">&lt;legend&gt;</span><span class="typ">Contact</span><span class="pln"> </span><span class="typ">Us</span><span class="pun">&lt;/</span><span class="pln">legend</span><span class="pun">&gt;</span><span class="pln">

               </span><span class="pun">&lt;</span><span class="pln">div </span><span class="kwd">class</span><span class="pun">=</span><span class="str">&quot;editor-label&quot;</span><span class="pun">&gt;</span><span class="pln">
                   </span><span class="lit">@Html</span><span class="pun">.</span><span class="typ">LabelFor</span><span class="pun">(</span><span class="pln">model </span><span class="pun">=&gt;</span><span class="pln"> model</span><span class="pun">.</span><span class="typ">Name</span><span class="pun">)</span><span class="pln">
               </span><span class="pun">&lt;/</span><span class="pln">div</span><span class="pun">&gt;</span><span class="pln">
               </span><span class="pun">&lt;</span><span class="pln">div </span><span class="kwd">class</span><span class="pun">=</span><span class="str">&quot;editor-field&quot;</span><span class="pun">&gt;</span><span class="pln">
                   </span><span class="lit">@Html</span><span class="pun">.</span><span class="typ">EditorFor</span><span class="pun">(</span><span class="pln">model </span><span class="pun">=&gt;</span><span class="pln"> model</span><span class="pun">.</span><span class="typ">Name</span><span class="pun">)</span><span class="pln">
                   </span><span class="lit">@Html</span><span class="pun">.</span><span class="typ">ValidationMessageFor</span><span class="pun">(</span><span class="pln">model </span><span class="pun">=&gt;</span><span class="pln"> model</span><span class="pun">.</span><span class="typ">Name</span><span class="pun">)</span><span class="pln">
               </span><span class="pun">&lt;/</span><span class="pln">div</span><span class="pun">&gt;</span><span class="pln">

               </span><span class="pun">&lt;</span><span class="pln">div </span><span class="kwd">class</span><span class="pun">=</span><span class="str">&quot;editor-label&quot;</span><span class="pun">&gt;</span><span class="pln">
                   </span><span class="lit">@Html</span><span class="pun">.</span><span class="typ">LabelFor</span><span class="pun">(</span><span class="pln">model </span><span class="pun">=&gt;</span><span class="pln"> model</span><span class="pun">.</span><span class="typ">Email</span><span class="pun">)</span><span class="pln">
               </span><span class="pun">&lt;/</span><span class="pln">div</span><span class="pun">&gt;</span><span class="pln">
               </span><span class="pun">&lt;</span><span class="pln">div </span><span class="kwd">class</span><span class="pun">=</span><span class="str">&quot;editor-field&quot;</span><span class="pun">&gt;</span><span class="pln">
                   </span><span class="lit">@Html</span><span class="pun">.</span><span class="typ">EditorFor</span><span class="pun">(</span><span class="pln">model </span><span class="pun">=&gt;</span><span class="pln"> model</span><span class="pun">.</span><span class="typ">Email</span><span class="pun">)</span><span class="pln">
                   </span><span class="lit">@Html</span><span class="pun">.</span><span class="typ">ValidationMessageFor</span><span class="pun">(</span><span class="pln">model </span><span class="pun">=&gt;</span><span class="pln"> model</span><span class="pun">.</span><span class="typ">Email</span><span class="pun">)</span><span class="pln">
               </span><span class="pun">&lt;/</span><span class="pln">div</span><span class="pun">&gt;</span><span class="pln">

               </span><span class="pun">&lt;</span><span class="pln">div </span><span class="kwd">class</span><span class="pun">=</span><span class="str">&quot;editor-label&quot;</span><span class="pun">&gt;</span><span class="pln">
                   </span><span class="lit">@Html</span><span class="pun">.</span><span class="typ">LabelFor</span><span class="pun">(</span><span class="pln">model </span><span class="pun">=&gt;</span><span class="pln"> model</span><span class="pun">.</span><span class="typ">Comment</span><span class="pun">)</span><span class="pln">
               </span><span class="pun">&lt;/</span><span class="pln">div</span><span class="pun">&gt;</span><span class="pln">
               </span><span class="pun">&lt;</span><span class="pln">div </span><span class="kwd">class</span><span class="pun">=</span><span class="str">&quot;editor-field&quot;</span><span class="pun">&gt;</span><span class="pln">
                   </span><span class="lit">@Html</span><span class="pun">.</span><span class="typ">EditorFor</span><span class="pun">(</span><span class="pln">model </span><span class="pun">=&gt;</span><span class="pln"> model</span><span class="pun">.</span><span class="typ">Comment</span><span class="pun">)</span><span class="pln">
                   </span><span class="lit">@Html</span><span class="pun">.</span><span class="typ">ValidationMessageFor</span><span class="pun">(</span><span class="pln">model </span><span class="pun">=&gt;</span><span class="pln"> model</span><span class="pun">.</span><span class="typ">Comment</span><span class="pun">)</span><span class="pln">
               </span><span class="pun">&lt;/</span><span class="pln">div</span><span class="pun">&gt;</span><span class="pln">
               </span><span class="pun">&lt;</span><span class="pln">div </span><span class="kwd">class</span><span class="pun">=</span><span class="str">&quot;editor-field&quot;</span><span class="pun">&gt;</span><span class="pln">
                   </span><span class="lit">@Html</span><span class="pun">.</span><span class="typ">Recaptcha</span><span class="pun">()</span><span class="pln">
               </span><span class="pun">&lt;/</span><span class="pln">div</span><span class="pun">&gt;</span><span class="pln">
               </span><span class="str">&lt;p&gt;</span><span class="pln">
                    </span><span class="pun">&lt;</span><span class="pln">input type</span><span class="pun">=</span><span class="str">&quot;submit&quot;</span><span class="pln"> value</span><span class="pun">=</span><span class="str">&quot;Create&quot;</span><span class="pln"> </span><span class="pun">/&gt;</span><span class="pln">
               </span><span class="pun">&lt;/</span><span class="pln">p</span><span class="pun">&gt;</span><span class="pln">
           </span><span class="pun">&lt;/</span><span class="pln">fieldset</span><span class="pun">&gt;</span><span class="pln">
</span><span class="pun">}</span><span class="pln">

</span><span class="lit">@section</span><span class="pln"> </span><span class="typ">Scripts</span><span class="pln"> </span><span class="pun">{</span><span class="pln">
    </span><span class="lit">@Scripts</span><span class="pun">.</span><span class="typ">Render</span><span class="pun">(</span><span class="str">&quot;~/bundles/jqueryval&quot;</span><span class="pun">)</span><span class="pln">
</span><span class="pun">}</span></pre>
<br></pre>
<p><strong>HomeController.cs</strong></p>
<pre class="prettyprint prettyprinted"><span class="pun">[</span><span class="typ">HttpPost</span><span class="pun">]</span><span class="pln">
</span><span class="kwd">public</span><span class="pln"> </span><span class="typ">ActionResult</span><span class="pln"> </span><span class="typ">Contact</span><span class="pun">(</span><span class="typ">Contact</span><span class="pln"> contact</span><span class="pun">)</span><span class="pln">
</span><span class="pun">{</span><span class="pln">
      </span><span class="typ">RecaptchaVerificationHelper</span><span class="pln"> recaptchaHelper </span><span class="pun">=</span><span class="pln"> </span><span class="kwd">this</span><span class="pun">.</span><span class="typ">GetRecaptchaVerificationHelper</span><span class="pun">();</span><span class="pln">

      </span><span class="kwd">if</span><span class="pln"> </span><span class="pun">(</span><span class="typ">String</span><span class="pun">.</span><span class="typ">IsNullOrEmpty</span><span class="pun">(</span><span class="pln">recaptchaHelper</span><span class="pun">.</span><span class="typ">Response</span><span class="pun">))</span><span class="pln">
      </span><span class="pun">{</span><span class="pln">
          </span><span class="typ">ModelState</span><span class="pun">.</span><span class="typ">AddModelError</span><span class="pun">(</span><span class="str">&quot;&quot;</span><span class="pun">,</span><span class="pln"> </span><span class="str">&quot;Captcha answer cannot be empty.&quot;</span><span class="pun">);</span><span class="pln">
          </span><span class="kwd">return</span><span class="pln"> </span><span class="typ">View</span><span class="pun">(</span><span class="pln">contact</span><span class="pun">);</span><span class="pln">
      </span><span class="pun">}</span><span class="pln">

      </span><span class="typ">RecaptchaVerificationResult</span><span class="pln"> recaptchaResult </span><span class="pun">=</span><span class="pln"> recaptchaHelper</span><span class="pun">.</span><span class="typ">VerifyRecaptchaResponse</span><span class="pun">();</span><span class="pln">

      </span><span class="kwd">if</span><span class="pln"> </span><span class="pun">(</span><span class="pln">recaptchaResult </span><span class="pun">!=</span><span class="pln"> </span><span class="typ">RecaptchaVerificationResult</span><span class="pun">.</span><span class="typ">Success</span><span class="pun">)</span><span class="pln">
      </span><span class="pun">{</span><span class="pln">
          </span><span class="typ">ModelState</span><span class="pun">.</span><span class="typ">AddModelError</span><span class="pun">(</span><span class="str">&quot;&quot;</span><span class="pun">,</span><span class="pln"> </span><span class="str">&quot;Incorrect captcha answer.&quot;</span><span class="pun">);</span><span class="pln">
      </span><span class="pun">}</span><span class="pln">
      </span><span class="com">//Insert code to insert into database...</span><span class="pln">
      </span><span class="kwd">return</span><span class="pln"> </span><span class="typ">View</span><span class="pun">(</span><span class="pln">contact</span><span class="pun">);</span><span class="pln">
</span><span class="pun">}</span></pre>
<pre class="prettyprint prettyprinted"><span class="pun"><br></span></pre>
