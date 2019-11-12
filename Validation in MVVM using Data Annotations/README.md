# Validation in MVVM using Data Annotations
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- XAML
## Topics
- Data Binding
- User Interface
- Data Access
- XAML
- MVVM
## Updated
- 02/02/2014
## Description

<p><span style="font-size:medium"><strong>Introduction</strong></span><br>
<span><br>
<span style="font-size:small">Validation is more important if are working on Data entry applications or any kind of form based application. But if the application also follows MVVM pattern there are a lot of ways to do validation in a more cleaner and effective
 way.</span><br>
<br>
<span style="font-size:small">Even though there are a lot of ways to do the Validation. Data Annotations seems to be more effective compared to another ways.&nbsp;</span><br>
</span><br>
<span><span style="font-size:small">A simple Example of Data Annotations</span><br>
</span></p>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[Required(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Email&nbsp;address&nbsp;is&nbsp;required&quot;</span>)]&nbsp;
[EmailAddress(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Email&nbsp;Address&nbsp;is&nbsp;Invalid&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Email&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;Email);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;Email,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
</div>
<div class="reCodeBlock"></div>
<p><br>
<span style="font-size:small">Through Data Annotations it&rsquo;s very simple to mention the validation rule and appropriate error message.&nbsp;</span><br>
<br>
<span style="font-size:small">We can even create custom validation attributes if the built in Validation attribute like EmailAddress, MaxLength, MinLength doesn&rsquo;t satisfy our needs. For Example if we want to validate the Name by not allowing special characters
 like *, #, @ there is no built-in attributes to do this. So we can define a custom attribute.</span><br>
<br>
<span style="font-size:small"><strong>Adding Data Annotations to the Model<br>
</strong></span><br>
<span style="font-size:small">1.) Add a reference to&nbsp;</span><strong><span style="font-size:small"><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a></span><br>
<br>
</strong></p>
<div class="reCodeBlock">
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[Required(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Email&nbsp;address&nbsp;is&nbsp;required&quot;</span>)]&nbsp;
[EmailAddress(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Email&nbsp;Address&nbsp;is&nbsp;Invalid&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Email&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;Email);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;Email,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
</div>
</div>
<p><br>
<span style="font-size:small">2.) Refer&nbsp;<strong><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a></strong>&nbsp;in your Model.</span><br>
<br>
</p>
<div class="reCodeBlock">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.ComponentModel.DataAnnotations.aspx" target="_blank" title="Auto generated link to System.ComponentModel.DataAnnotations">System.ComponentModel.DataAnnotations</a>;</pre>
</div>
</div>
</div>
</div>
<p><br>
<span style="font-size:small">3.) Annotate the properties of the Model with Validation Attributes</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[Unqiue(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Duplicate&nbsp;Id.&nbsp;Id&nbsp;already&nbsp;exists&quot;</span>)]&nbsp;
[Required(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Id&nbsp;is&nbsp;Required&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;Id);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;Id,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
}&nbsp;
&nbsp;&nbsp;
[Required(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Name&nbsp;is&nbsp;Required&quot;</span>)]&nbsp;
[MaxLength(<span class="cs__number">50</span>,&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Name&nbsp;exceeded&nbsp;50&nbsp;letters&quot;</span>)]&nbsp;
[ExcludeChar(<span class="cs__string">&quot;/.,!@#$%&quot;</span>,&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Name&nbsp;contains&nbsp;invalid&nbsp;letters&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;Name);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;Name,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
}&nbsp;
&nbsp;&nbsp;
[Range(<span class="cs__number">1</span>,&nbsp;<span class="cs__number">100</span>,&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Age&nbsp;should&nbsp;be&nbsp;between&nbsp;1&nbsp;to&nbsp;100&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Age&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;Age);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;Age,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
}&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">public</span>&nbsp;Gender&nbsp;Gender&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;Gender);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;Gender,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
}&nbsp;
&nbsp;&nbsp;
[Required(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Email&nbsp;address&nbsp;is&nbsp;required&quot;</span>)]&nbsp;
[EmailAddress(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Email&nbsp;Address&nbsp;is&nbsp;Invalid&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Email&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;Email);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;Email,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
}&nbsp;
&nbsp;&nbsp;
[Required(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Repeat&nbsp;Email&nbsp;address&nbsp;is&nbsp;required&quot;</span>)]&nbsp;
[Compare(<span class="cs__string">&quot;Email&quot;</span>,&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Email&nbsp;Address&nbsp;does&nbsp;not&nbsp;match&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;RepeatEmail&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;RepeatEmail);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;RepeatEmail,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><br>
<span style="font-size:small">4.) In the above code there are validation attributes named&nbsp;<strong>ExculdeChar</strong>, Unique which are Custom Validation Attributes. ExcludeChar is used to check whether the name has any special characters like @,*, #
 etc.&nbsp;<strong>Unique&nbsp;</strong>is used to check whether the Id is unique just like a primary key in table to prevent the duplicate entries.&nbsp;</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[Required(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Name&nbsp;is&nbsp;Required&quot;</span>)]&nbsp;
[MaxLength(<span class="cs__number">50</span>,&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Name&nbsp;exceeded&nbsp;50&nbsp;letters&quot;</span>)]&nbsp;
[ExcludeChar(<span class="cs__string">&quot;/.,!@#$%&quot;</span>,&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Name&nbsp;contains&nbsp;invalid&nbsp;letters&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;Name);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;Name,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
[Unqiue(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Duplicate&nbsp;Id.&nbsp;Id&nbsp;already&nbsp;exists&quot;</span>)]&nbsp;
[Required(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Id&nbsp;is&nbsp;Required&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;Id);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;Id,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><span style="font-size:small">5.) To create a Custom Validation attribute. Create a class named ExcludeChar with a parameterized constructor to accept the Invalid characters and derive it from ValidationAttribute class.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ExcludeChar&nbsp;:&nbsp;ValidationAttribute&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;_characters;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ExcludeChar(<span class="cs__keyword">string</span>&nbsp;characters)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_characters&nbsp;=&nbsp;characters;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><br>
<span style="font-size:small">6.) Override the&nbsp;<strong>IsValid&nbsp;</strong>method of the ValidationAttribute Class to implement your validation Logic</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ExcludeChar&nbsp;:&nbsp;ValidationAttribute&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;_characters;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ExcludeChar(<span class="cs__keyword">string</span>&nbsp;characters)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_characters&nbsp;=&nbsp;characters;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;ValidationResult&nbsp;IsValid(<span class="cs__keyword">object</span>&nbsp;<span class="cs__keyword">value</span>,&nbsp;System.ComponentModel.DataAnnotations.ValidationContext&nbsp;validationContext)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">value</span>&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;_characters.Length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;valueAsString&nbsp;=&nbsp;<span class="cs__keyword">value</span>.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(valueAsString.Contains(_characters[i]))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;errorMessage&nbsp;=&nbsp;FormatErrorMessage(validationContext.DisplayName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;ValidationResult(errorMessage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;ValidationResult.Success;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p><br>
7.)<span> </span>Similarly for Unique validation attribute.<br>
<br>
</p>
<div class="reCodeBlock">
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Unqiue&nbsp;:&nbsp;ValidationAttribute&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;ValidationResult&nbsp;IsValid(<span class="cs__keyword">object</span>&nbsp;<span class="cs__keyword">value</span>,&nbsp;ValidationContext&nbsp;validationContext)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;contains&nbsp;=&nbsp;CustomerViewModel.SharedViewModel().Customers.Select(x&nbsp;=&gt;&nbsp;x.Id).Contains(<span class="cs__keyword">int</span>.Parse(<span class="cs__keyword">value</span>.ToString()));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(contains)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;newValidationResult(FormatErrorMessage(validationContext.DisplayName));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;ValidationResult.Success;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
</div>
</div>
<p><br>
<span style="font-size:small">8.) The Whole Model Code with Data Annotations</span><br>
<br>
</p>
<div class="reCodeBlock">
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Customer&nbsp;:&nbsp;PropertyChangedNotification&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Unqiue(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Duplicate&nbsp;Id.&nbsp;Id&nbsp;already&nbsp;exists&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Id&nbsp;is&nbsp;Required&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;Id);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;Id,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Name&nbsp;is&nbsp;Required&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[MaxLength(<span class="cs__number">50</span>,&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Name&nbsp;exceeded&nbsp;50&nbsp;letters&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ExcludeChar(<span class="cs__string">&quot;/.,!@#$%&quot;</span>,&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Name&nbsp;contains&nbsp;invalid&nbsp;letters&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;Name);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;Name,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Range(<span class="cs__number">1</span>,&nbsp;<span class="cs__number">100</span>,&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Age&nbsp;should&nbsp;be&nbsp;between&nbsp;1&nbsp;to&nbsp;100&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Age&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;Age);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;Age,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Gender&nbsp;Gender&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;Gender);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;Gender,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Email&nbsp;address&nbsp;is&nbsp;required&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[EmailAddress(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Email&nbsp;Address&nbsp;is&nbsp;Invalid&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Email&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;Email);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;Email,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required(ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Repeat&nbsp;Email&nbsp;address&nbsp;is&nbsp;required&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Compare(<span class="cs__string">&quot;Email&quot;</span>,&nbsp;ErrorMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Email&nbsp;Address&nbsp;does&nbsp;not&nbsp;match&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;RepeatEmail&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;GetValue(()&nbsp;=&gt;&nbsp;RepeatEmail);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(()&nbsp;=&gt;&nbsp;RepeatEmail,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">enum</span>&nbsp;Gender&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Male,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Female&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">The rest of the article is found here</span></p>
<p><span style="font-size:small">http://social.technet.microsoft.com/wiki/contents/articles/22660.data-validation-in-mvvm.aspx</span></p>
<p>&nbsp;</p>
<p><strong><span style="font-size:small">Output</span></strong></p>
<p><img id="107599" src="107599-clear.png" alt="" width="495" height="464"></p>
