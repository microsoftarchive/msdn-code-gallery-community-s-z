# Windows 7 UI Automation Client API C# sample (e-mail reader) Version 1.0
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows 7 UI Automation
## Topics
- UI Automation
## Updated
- 03/10/2012
## Description

<p>In preparation for a demo of the native-code Windows UI Automation (UIA) API last year, I built a sample app which introduces most of the commonly used features of UIA. This included the following topics; properties, events, patterns, cache requests and
 conditions. The original C&#43;&#43; sample is up at <a href="http://code.msdn.microsoft.com/Windows-7-UI-Automation-9131f729">
http://code.msdn.microsoft.com/Windows-7-UI-Automation-9131f729</a>, and a version I ported to C# is at
<a href="http://code.msdn.microsoft.com/Windows-7-UI-Automation-0625f55e">http://code.msdn.microsoft.com/Windows-7-UI-Automation-0625f55e</a>.</p>
<p>Probably the most interesting functionality that&rsquo;s not mentioned in that sample relates to the Text Pattern. If a UIA provider supports the Text Pattern, then a client can perform a number of operations to move through the text shown in the provider
 and to access that text. For example, the client can move through the text, examining the text character-by-character, word-by-word, line-by-line or paragraph-by-paragraph. Details of the Text Pattern are up at
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ee815688(v=vs.85).aspx">
http://msdn.microsoft.com/en-us/library/windows/desktop/ee815688(v=vs.85).aspx</a>.</p>
<p>So I thought it would be interesting to build a new sample that uses the Text Pattern. As I considered this, I wondered whether I could build a very simple app which hardly does anything, but could still be a useful assistive technology (AT) tool in practice.
 While UIA is great for enabling UI automated tests, the API is also designed to support people building AT, and so I&rsquo;m always very excited to build tools which relate to a real-world AT scenarios. (For example, building the tool to speak the text shown
 on the OSK prediction keys, <a href="http://code.msdn.microsoft.com/Windows-7-UI-Automation-433a961f">
http://code.msdn.microsoft.com/Windows-7-UI-Automation-433a961f</a>.)</p>
<p>With this in mind, I decided that a future sample would demo some of the more powerful aspects of the Text Pattern, but my next sample would do the absolute minimum required to have the Text Pattern support a useful tool. What I settled on was an app to
 read e-mail text. Some people find it easier to comprehend an e-mail message if the text is spoken to them as they read it. And sometimes when important e-mail is being composed, if it&rsquo;s spoken prior to being sent, that can help to detect issues with
 the text which aren&rsquo;t caught by running a spell checker alone. So the new sample app should read both received e-mail and e-mail being composed.</p>
<p>I decided to build the app in C# and my first step was to copy one of my existing C# samples,
<a href="http://code.msdn.microsoft.com/Windows-7-UI-Automation-6390614a">http://code.msdn.microsoft.com/Windows-7-UI-Automation-6390614a</a>. I then removed a few existing things which weren&rsquo;t relevant to the new app, (for example the UIA event handler,
 and use of the Magnification API.) One handy aspect about my new app was that I didn&rsquo;t have to account for the UIA threading rules. That is, if an app uses UIA to access its own UI, or it has UIA event handlers, then certain things must be done on background
 threads, (as described in my other samples). But since the new app doesn&rsquo;t do any of that, it keeps things really simple.</p>
<p>I then updated the .cs file for the main app WinForm UI. There&rsquo;s little work done here other than to use a SpeechSynthesizer to speak the text using the current default voice on the computer, and also to change the visuals for a button to start or
 stop the speaking of the text.</p>
<p>The more interesting .cs file is the one that actually uses UIA. It initializes and uninitializes an IUIAutomation object, (as any UIA client app does), and then has a single function to access the e-mail text.&nbsp;That function looks like this:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Try to find a Windows Live Mail window for composing and reading e-mails.
// Using the Spy tool, the class of the main window can be found. This test
// app assumes there's only one Windows Live Mail window of interest.
IntPtr hwnd = Win32.FindWindow(&quot;ATH_Note&quot;, null);
if (hwnd != IntPtr.Zero)
{
    // We found a window, so get the UIA element associated with the window.
    IUIAutomationElement elementMailAppWindow = _automation.ElementFromHandle(
                                                    hwnd);

    // Find an element somewhere beneath the main window element in the UIA 
    // tree which represents the main area where the e-mail content is shown. 
    // Using the Inspect SDK tool, we can see that the main e-mail content 
    // is contained within an element whose accessible name is &quot;NoteWindow&quot;. 
    // So create a condition such that the FindFirst() call below will only 
    // return an element if its name is &quot;NoteWindow&quot;.
    IUIAutomationCondition conditionNote = _automation.CreatePropertyCondition(
                                                _propertyIdName, &quot;NoteWindow&quot;);

    IUIAutomationElement elementNoteWindow = elementMailAppWindow.FindFirst(
                                                TreeScope.TreeScope_Descendants, 
                                                conditionNote);

    // As it happens, the actual element that supports the Text Pattern is 
    // somewhere beneath the &quot;NoteWindow&quot; element in the UIA tree. Using 
    // Inspect we can see that there is an element that supports the 
    // Text Pattern. Once we have that element, we can avoid a cross-process 
    // call to access the Text Pattern object by using cache request.
    IUIAutomationCacheRequest cacheRequest = _automation.CreateCacheRequest();
    cacheRequest.AddPattern(_patternIdTextPattern);

    // Now find the element that supports the Text Pattern. This test app assumes
    // there&rsquo;s only one element that can be returned which supports the Text Pattern.
    bool fTextPatternSupported = true;
    IUIAutomationCondition conditionTextPattern = _automation.CreatePropertyCondition(
                                                    _propertyIdIsTextPatternAvailable, 
                                                    fTextPatternSupported);

    IUIAutomationElement elementMailContent = elementMailAppWindow.FindFirstBuildCache(
                                                    TreeScope.TreeScope_Descendants, 
                                                    conditionTextPattern, 
                                                    cacheRequest);

    // Because the Text Pattern object is cached, we don't have to make a cross-process 
    // call here to get object. Later calls which actually use methods and properties 
    // on the Text Pattern object will incur cross-proc calls.
    IUIAutomationTextPattern textPattern = (IUIAutomationTextPattern)
                                                elementMailContent.GetCachedPattern(
                                                    _patternIdTextPattern);

    // This test app is only interested in getting all the e-mail text, so we get that through 
    // the DocumentRange property. A more fully featured app might be interested in getting a
    // a collection of Text Ranges from the e-mail. Each range might relate to an individual
    // word or paragraph. Given that a provider which supports the Text Pattern allows a 
    // client to find the bounding rectangles of these ranges, the client could choose to use 
    // its own method of highlighting the text as the text is being spoken.
    IUIAutomationTextRange rangeDocument = textPattern.DocumentRange;

    // Pass -1 here because we're not interested in limiting the amount of text here.
    strMailContent = rangeDocument.GetText(-1); 
}

</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Try&nbsp;to&nbsp;find&nbsp;a&nbsp;Windows&nbsp;Live&nbsp;Mail&nbsp;window&nbsp;for&nbsp;composing&nbsp;and&nbsp;reading&nbsp;e-mails.</span>&nbsp;
<span class="cs__com">//&nbsp;Using&nbsp;the&nbsp;Spy&nbsp;tool,&nbsp;the&nbsp;class&nbsp;of&nbsp;the&nbsp;main&nbsp;window&nbsp;can&nbsp;be&nbsp;found.&nbsp;This&nbsp;test</span>&nbsp;
<span class="cs__com">//&nbsp;app&nbsp;assumes&nbsp;there's&nbsp;only&nbsp;one&nbsp;Windows&nbsp;Live&nbsp;Mail&nbsp;window&nbsp;of&nbsp;interest.</span>&nbsp;
IntPtr&nbsp;hwnd&nbsp;=&nbsp;Win32.FindWindow(<span class="cs__string">&quot;ATH_Note&quot;</span>,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
<span class="cs__keyword">if</span>&nbsp;(hwnd&nbsp;!=&nbsp;IntPtr.Zero)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;We&nbsp;found&nbsp;a&nbsp;window,&nbsp;so&nbsp;get&nbsp;the&nbsp;UIA&nbsp;element&nbsp;associated&nbsp;with&nbsp;the&nbsp;window.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IUIAutomationElement&nbsp;elementMailAppWindow&nbsp;=&nbsp;_automation.ElementFromHandle(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hwnd);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Find&nbsp;an&nbsp;element&nbsp;somewhere&nbsp;beneath&nbsp;the&nbsp;main&nbsp;window&nbsp;element&nbsp;in&nbsp;the&nbsp;UIA&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;tree&nbsp;which&nbsp;represents&nbsp;the&nbsp;main&nbsp;area&nbsp;where&nbsp;the&nbsp;e-mail&nbsp;content&nbsp;is&nbsp;shown.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Using&nbsp;the&nbsp;Inspect&nbsp;SDK&nbsp;tool,&nbsp;we&nbsp;can&nbsp;see&nbsp;that&nbsp;the&nbsp;main&nbsp;e-mail&nbsp;content&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;is&nbsp;contained&nbsp;within&nbsp;an&nbsp;element&nbsp;whose&nbsp;accessible&nbsp;name&nbsp;is&nbsp;&quot;NoteWindow&quot;.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;So&nbsp;create&nbsp;a&nbsp;condition&nbsp;such&nbsp;that&nbsp;the&nbsp;FindFirst()&nbsp;call&nbsp;below&nbsp;will&nbsp;only&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;return&nbsp;an&nbsp;element&nbsp;if&nbsp;its&nbsp;name&nbsp;is&nbsp;&quot;NoteWindow&quot;.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IUIAutomationCondition&nbsp;conditionNote&nbsp;=&nbsp;_automation.CreatePropertyCondition(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_propertyIdName,&nbsp;<span class="cs__string">&quot;NoteWindow&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IUIAutomationElement&nbsp;elementNoteWindow&nbsp;=&nbsp;elementMailAppWindow.FindFirst(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TreeScope.TreeScope_Descendants,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conditionNote);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;As&nbsp;it&nbsp;happens,&nbsp;the&nbsp;actual&nbsp;element&nbsp;that&nbsp;supports&nbsp;the&nbsp;Text&nbsp;Pattern&nbsp;is&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;somewhere&nbsp;beneath&nbsp;the&nbsp;&quot;NoteWindow&quot;&nbsp;element&nbsp;in&nbsp;the&nbsp;UIA&nbsp;tree.&nbsp;Using&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Inspect&nbsp;we&nbsp;can&nbsp;see&nbsp;that&nbsp;there&nbsp;is&nbsp;an&nbsp;element&nbsp;that&nbsp;supports&nbsp;the&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Text&nbsp;Pattern.&nbsp;Once&nbsp;we&nbsp;have&nbsp;that&nbsp;element,&nbsp;we&nbsp;can&nbsp;avoid&nbsp;a&nbsp;cross-process&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;call&nbsp;to&nbsp;access&nbsp;the&nbsp;Text&nbsp;Pattern&nbsp;object&nbsp;by&nbsp;using&nbsp;cache&nbsp;request.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IUIAutomationCacheRequest&nbsp;cacheRequest&nbsp;=&nbsp;_automation.CreateCacheRequest();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cacheRequest.AddPattern(_patternIdTextPattern);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Now&nbsp;find&nbsp;the&nbsp;element&nbsp;that&nbsp;supports&nbsp;the&nbsp;Text&nbsp;Pattern.&nbsp;This&nbsp;test&nbsp;app&nbsp;assumes</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;there&rsquo;s&nbsp;only&nbsp;one&nbsp;element&nbsp;that&nbsp;can&nbsp;be&nbsp;returned&nbsp;which&nbsp;supports&nbsp;the&nbsp;Text&nbsp;Pattern.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;fTextPatternSupported&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IUIAutomationCondition&nbsp;conditionTextPattern&nbsp;=&nbsp;_automation.CreatePropertyCondition(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_propertyIdIsTextPatternAvailable,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fTextPatternSupported);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IUIAutomationElement&nbsp;elementMailContent&nbsp;=&nbsp;elementMailAppWindow.FindFirstBuildCache(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TreeScope.TreeScope_Descendants,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conditionTextPattern,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cacheRequest);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Because&nbsp;the&nbsp;Text&nbsp;Pattern&nbsp;object&nbsp;is&nbsp;cached,&nbsp;we&nbsp;don't&nbsp;have&nbsp;to&nbsp;make&nbsp;a&nbsp;cross-process&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;call&nbsp;here&nbsp;to&nbsp;get&nbsp;object.&nbsp;Later&nbsp;calls&nbsp;which&nbsp;actually&nbsp;use&nbsp;methods&nbsp;and&nbsp;properties&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;on&nbsp;the&nbsp;Text&nbsp;Pattern&nbsp;object&nbsp;will&nbsp;incur&nbsp;cross-proc&nbsp;calls.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IUIAutomationTextPattern&nbsp;textPattern&nbsp;=&nbsp;(IUIAutomationTextPattern)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elementMailContent.GetCachedPattern(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_patternIdTextPattern);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;This&nbsp;test&nbsp;app&nbsp;is&nbsp;only&nbsp;interested&nbsp;in&nbsp;getting&nbsp;all&nbsp;the&nbsp;e-mail&nbsp;text,&nbsp;so&nbsp;we&nbsp;get&nbsp;that&nbsp;through&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;the&nbsp;DocumentRange&nbsp;property.&nbsp;A&nbsp;more&nbsp;fully&nbsp;featured&nbsp;app&nbsp;might&nbsp;be&nbsp;interested&nbsp;in&nbsp;getting&nbsp;a</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;a&nbsp;collection&nbsp;of&nbsp;Text&nbsp;Ranges&nbsp;from&nbsp;the&nbsp;e-mail.&nbsp;Each&nbsp;range&nbsp;might&nbsp;relate&nbsp;to&nbsp;an&nbsp;individual</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;word&nbsp;or&nbsp;paragraph.&nbsp;Given&nbsp;that&nbsp;a&nbsp;provider&nbsp;which&nbsp;supports&nbsp;the&nbsp;Text&nbsp;Pattern&nbsp;allows&nbsp;a&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;client&nbsp;to&nbsp;find&nbsp;the&nbsp;bounding&nbsp;rectangles&nbsp;of&nbsp;these&nbsp;ranges,&nbsp;the&nbsp;client&nbsp;could&nbsp;choose&nbsp;to&nbsp;use&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;its&nbsp;own&nbsp;method&nbsp;of&nbsp;highlighting&nbsp;the&nbsp;text&nbsp;as&nbsp;the&nbsp;text&nbsp;is&nbsp;being&nbsp;spoken.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IUIAutomationTextRange&nbsp;rangeDocument&nbsp;=&nbsp;textPattern.DocumentRange;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Pass&nbsp;-1&nbsp;here&nbsp;because&nbsp;we're&nbsp;not&nbsp;interested&nbsp;in&nbsp;limiting&nbsp;the&nbsp;amount&nbsp;of&nbsp;text&nbsp;here.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;strMailContent&nbsp;=&nbsp;rangeDocument.GetText(-<span class="cs__number">1</span>);&nbsp;&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>This app specifically only works with Windows Live Mail, but with a small adjustment the code above could target other window-based e-mail apps.</p>
<p>As Text Pattern samples go, this isn&rsquo;t very interesting as all it does is access the text for the entire document as a single string, (through the DocumentRange property.) But I did find this an exciting experiment. In around an hour and a half I built
 a UIA app which contains very little code, but which could still be a useful AT tool for some people. My next step is to figure out which other parts of the Text Pattern and Text Range interfaces would help most in practice for an e-mail related AT like this,
 and to update the sample accordingly. For example, the AT tool might get call IUIAutomationTextRange::Move() to access each line in turn, and call GetBoundingRectangles() and render its own highlighting for the line being spoken. The app could also call IUIAutomationTextPattern::GetVisibleRanges()
 to make sure it only gathers text that&rsquo;s shown on the screen when working with e-mail clients that handle hidden text.</p>
<p>&nbsp;</p>
