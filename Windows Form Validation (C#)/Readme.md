# Windows Form Validation (C#)
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Validation
- Windows Forms
## Topics
- C#
- Windows Forms
- Form validation
- Windows controls
## Updated
- 12/03/2017
## Description

<h1>Description</h1>
<p><span style="font-size:small">This code sample provides code samples that will provide you with various choices to validate information entered by a user into Textbox and CombBox controls but the methods provided are not limited to these two controls, I
 wanted to keep things simple all around.</span></p>
<p><span style="font-size:small">From my time on various forums the average developer (thinking not with much experience) will do very little validation to confirm that information entered by the user is valid or no validation at all.</span></p>
<p><span style="font-size:small">Also these same developers believe that adding, editing data is best done in a DataGridView, perhaps from seeing this done within MS-Access. I can understand this yet with a little learning they can work adding and editing into
 a dialog form that displays over a form containing a DataGridView, add or edit and save back to the calling form.</span></p>
<p><span style="font-size:small">I&rsquo;ve done three examples, none of them load data from a file or database as I wanted to focus solely on validating data.</span></p>
<p><span style="font-size:small">In all three examples I validate that all TextBox controls are not empty and a ComboBox has a validate selection. Granted determining if all TextBox controls are populated can eat up many lines of code and really doesn&rsquo;t
 tell the user in most cases what is missing unless we add a Error Provider in which can be a ton of code if there are a lot of controls to validate as we must handle valid and invalid entries.</span></p>
<p><span style="font-size:small">In example one in project Sample1, this is all completely valid and would only do this type of validation on simple types (a few fields with simple validation). While example 2 I provide two alternatives. For the first we work
 with Validating event of the controls (same controls as in example 1), code must be written while the last method uses a component which was up on Code Project (see the read me file for details).</span></p>
<p><span style="font-size:small">Both code samples in Sample2 project are all valid and can see some developers leaning toward one or the other or heck, back to Sample1.</span></p>
<p><span style="font-size:small">Going with the last sample using a custom component, all you need to do is set it up e.g.</span></p>
<ol>
<li><span style="font-size:small">Drop it on the form.</span> </li><li><span style="font-size:small">Write two lines of code.</span> </li><li><span style="font-size:small">Setup each control via the property window.</span>
</li></ol>
<p><span style="font-size:small">Two lines of code</span></p>
<p><span style="font-size:x-small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">ValidationRule vr = new ValidationRule();
vr.CustomValidationMethod &#43;= vr_CustomValidationMethod;</pre>
<div class="preview">
<pre class="csharp">ValidationRule&nbsp;vr&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ValidationRule();&nbsp;
vr.CustomValidationMethod&nbsp;&#43;=&nbsp;vr_CustomValidationMethod;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p><span style="font-size:small">Setup in the property window.</span></p>
<p><span style="font-size:small"><img id="183067" src="183067-1.jpg" alt="" width="382" height="106"></span></p>
<p><span style="font-size:small; color:#ffffff">.</span></p>
<p><span style="font-size:small">Rules once selecting the above.</span></p>
<p><span style="font-size:small; color:#ffffff">.</span></p>
<p><span style="font-size:small"><img id="183068" src="183068-1c.jpg" alt="" width="537" height="521"><br>
</span></p>
<p><span style="font-size:small; color:#ffffff">.</span></p>
<p><span style="font-size:small">You can test a regular expression pattern e.g.</span></p>
<p><span style="font-size:small; color:#ffffff">.</span></p>
<p><span style="font-size:small"><img id="183069" src="183069-2.jpg" alt="" width="510" height="410"></span></p>
<p><span style="font-size:small; color:#ffffff">.</span></p>
<p><span style="font-size:small">Although the special validator mentioned above makes life very easy to do validation does not mean that is how you should do validation. As mentioned above, some will go with the more basic method to validate information while
 others will go with one of the others. There are some people (perhaps hobbyist) who are not fluent enough to go with a more sophisticated method to validate, don&rsquo;t see the need while others don&rsquo;t care to use third party components. It&rsquo;s all
 up to you, I&rsquo;ve simply provided alternate methods that should make it easy to provide a basic to advance level of validation.&nbsp;</span></p>
<p><span style="font-size:small"><img id="183071" src="183071-md1.jpg" alt="" width="300" height="672"><br>
</span></p>
<p><span style="font-size:small"><br>
</span></p>
