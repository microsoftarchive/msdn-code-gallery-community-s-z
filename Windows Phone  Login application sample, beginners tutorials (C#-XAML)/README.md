# Windows Phone : Login application sample, beginners tutorials (C#-XAML)
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Windows Phone 8
- Windows Phone Development
- WinddowsPhone 7
## Topics
- Login Application in windowsphone
- Validation for user registration in windowsphone
- signout application in windowsphone C#
## Updated
- 03/06/2015
## Description

<p><strong><span style="font-family:Verdana,sans-serif; font-size:small">Introduction:</span></strong></p>
<p><span style="font-family:Verdana,sans-serif; font-size:small">Recently i recieved one question from one of our blog visitor and&nbsp;now-days&nbsp;login page is&nbsp;very important step for most of application.And it is very helpful for allowing only authenticated
 user's can use our app.</span></p>
<p><span style="font-size:small"><span style="font-family:Verdana,sans-serif"><br>
</span><span style="font-family:Verdana,sans-serif">For example the process is like,</span></span></p>
<p><span style="font-family:Verdana,sans-serif; font-size:small">1. First user need to fill registration form.</span></p>
<p><span style="font-family:Verdana,sans-serif; font-size:small">2. Login with registered username &amp; password</span></p>
<p><span style="font-family:Verdana,sans-serif; font-size:small">3. After login&nbsp;successfully&nbsp;,app need to show the related login user details until SignOut</span></p>
<p><span style="font-family:Verdana,sans-serif; font-size:small">4. SignOut from the application,so that it will redirect to login page for another login.</span></p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small"><a href="http://3.bp.blogspot.com/-kyS9H0LXbdU/VPVSeiq6BlI/AAAAAAAABvI/r2gzG-L9Tyg/s1600/WindowsSeries.png"><img src="https://images-blogger-opensocial.googleusercontent.com/gadgets/proxy?url=http%3A%2F%2F3.bp.blogspot.com%2F-kyS9H0LXbdU%2FVPVSeiq6BlI%2FAAAAAAAABvI%2Fr2gzG-L9Tyg%2Fs1600%2FWindowsSeries.png&container=blogger&gadget=a&rewriteMime=image%2F*" border="0" alt=""></a></span></p>
<p class="separator">&nbsp;</p>
<p><span style="font-family:Verdana,sans-serif; font-size:small">Requirements:</span></p>
<ul>
<li>
<p><span style="font-family:Verdana,sans-serif; font-size:small">This sample is targeted on windowsphone 7.1 OS</span></p>
</li></ul>
<p><span style="font-family:Verdana,sans-serif; font-size:small">Description:</span></p>
<p>&nbsp;</p>
<div>
<p><span style="font-size:small"><strong>Step 1:</strong></span></p>
</div>
<div></div>
<p><span style="font-size:small"><span style="font-family:Verdana,sans-serif">&nbsp;</span></span></p>
<ul>
<li><span style="font-family:Verdana,sans-serif">Open Visual Studio</span><span style="font-family:Verdana,sans-serif">&nbsp;and create new project name (Ex: &quot;LoginApp&quot;)</span>
</li></ul>
<p><span style="font-family:Verdana,sans-serif">&nbsp;</span></p>
<p class="separator"><a href="http://2.bp.blogspot.com/-qYpzkSWtxNo/VPVbKLQojYI/AAAAAAAABvY/RJzYoTWFEQ0/s1600/NewProject.PNG"><img src="https://images-blogger-opensocial.googleusercontent.com/gadgets/proxy?url=http%3A%2F%2F2.bp.blogspot.com%2F-qYpzkSWtxNo%2FVPVbKLQojYI%2FAAAAAAAABvY%2FRJzYoTWFEQ0%2Fs1600%2FNewProject.PNG&container=blogger&gadget=a&rewriteMime=image%2F*" border="0" alt="" width="640" height="390"></a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-family:Verdana,sans-serif; font-size:small"><strong>Step 2 : Creating Login Form</strong></span></p>
<p><span style="font-family:Verdana,sans-serif; font-size:small">For simplicity, I divided this sample into MVVM design pattern. So in&nbsp;<strong>Model&nbsp;</strong>folder i placed related classes, In&nbsp;<strong>Views&nbsp;</strong>folder i placed xaml
 pages. And this sample&nbsp;hierarchy&nbsp;is&nbsp;like this:</span></p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small"><a href="http://2.bp.blogspot.com/-p0uz5wW2wcM/VPVkCsW7B2I/AAAAAAAABvo/UFWc6hJf-oc/s1600/Structure.PNG"><img src="https://images-blogger-opensocial.googleusercontent.com/gadgets/proxy?url=http%3A%2F%2F2.bp.blogspot.com%2F-p0uz5wW2wcM%2FVPVkCsW7B2I%2FAAAAAAAABvo%2FUFWc6hJf-oc%2Fs1600%2FStructure.PNG&container=blogger&gadget=a&rewriteMime=image%2F*" border="0" alt="" width="288" height="400"></a></span></p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small">Now create LoginPage on Views folder,and in designing part create login form with following xaml code.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__comment">&lt;!--LayoutRoot&nbsp;is&nbsp;the&nbsp;root&nbsp;grid&nbsp;where&nbsp;all&nbsp;page&nbsp;content&nbsp;is&nbsp;placed--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;LayoutRoot&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;White&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;*&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;12,17,0,28&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--Title--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Login&nbsp;Page&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;40&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--UserName--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;UserID&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;30&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBox</span>&nbsp;&nbsp;<span class="xaml__attr_name">BorderBrush</span>=<span class="xaml__attr_value">&quot;LightGray&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;UserName&quot;</span>&nbsp;<span class="xaml__attr_name">GotFocus</span>=<span class="xaml__attr_value">&quot;UserName_GotFocus&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--Password--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Password&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;9,-7,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;30&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;PasswordBox</span>&nbsp;<span class="xaml__attr_name">BorderBrush</span>=<span class="xaml__attr_value">&quot;LightGray&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;PassWord&quot;</span>&nbsp;<span class="xaml__attr_name">GotFocus</span>=<span class="xaml__attr_value">&quot;UserName_GotFocus&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--Login&nbsp;Button--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Login&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;#FF30DABB&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;Login&quot;</span>&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;Login_Click&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--&nbsp;&nbsp;Registration&nbsp;Button--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Registration&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;#FF30DABB&quot;</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;SignUp&quot;</span>&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;SignUp_Click&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;so your phone looks like:</div>
<p>&nbsp;</p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small"><a href="http://4.bp.blogspot.com/-MzmJKWwLaaE/VPVk3S4GlnI/AAAAAAAABvw/H2alwdF8pcI/s1600/Login.PNG"><img src="https://images-blogger-opensocial.googleusercontent.com/gadgets/proxy?url=http%3A%2F%2F4.bp.blogspot.com%2F-MzmJKWwLaaE%2FVPVk3S4GlnI%2FAAAAAAAABvw%2FH2alwdF8pcI%2Fs1600%2FLogin.PNG&container=blogger&gadget=a&rewriteMime=image%2F*" border="0" alt="" width="221" height="400"></a></span></p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small">In LoginPage.xaml.cs, write following code</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Login_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Will&nbsp;explain&nbsp;it&nbsp;later&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SignUp_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NavigationService.Navigate(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;/Views/SignUpPage.xaml&quot;</span>,&nbsp;UriKind.Relative));&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-family:Verdana,sans-serif">For new user registration, click on 'Registration' button will redirect to&nbsp;</span><span style="font-family:Verdana,sans-serif">registration form</span><span style="font-family:Verdana,sans-serif">.</span></div>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>Step 3 : Creating Registration Form</strong></span></p>
<p><span style="font-family:Verdana,sans-serif; font-size:small">Now create 'SignUpPage' on Views folder,and in designing part create registration form with following xaml code.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__comment">&lt;!--LayoutRoot&nbsp;is&nbsp;the&nbsp;root&nbsp;grid&nbsp;where&nbsp;all&nbsp;page&nbsp;content&nbsp;is&nbsp;placed--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;LayoutRoot&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;White&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5,0,0,0&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--Title--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;User&nbsp;Registration&nbsp;:&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;40&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--UserName--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;UserName&nbsp;:&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,25,0,0&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBox</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;TxtUserName&quot;</span>&nbsp;<span class="xaml__attr_name">BorderBrush</span>=<span class="xaml__attr_value">&quot;LightGray&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;100,0,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">GotFocus</span>=<span class="xaml__attr_value">&quot;Txt_GotFocus&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--Password--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Password:&nbsp;&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;2&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,25,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;PasswordBox</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;TxtPwd&quot;</span>&nbsp;<span class="xaml__attr_name">BorderBrush</span>=<span class="xaml__attr_value">&quot;LightGray&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;2&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;100,0,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">GotFocus</span>=<span class="xaml__attr_value">&quot;pwd_GotFocus&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--Address--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Address:&nbsp;&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;3&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,25,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBox</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;TxtAddr&quot;</span>&nbsp;<span class="xaml__attr_name">BorderBrush</span>=<span class="xaml__attr_value">&quot;LightGray&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;3&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;100,0,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">GotFocus</span>=<span class="xaml__attr_value">&quot;Txt_GotFocus&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--Gender--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Gender:&nbsp;&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;4&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,25,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RadioButton</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;GenMale&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;LightGray&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Male&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;4&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;100,0,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RadioButton</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;GenFeMale&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;LightGray&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Female&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;4&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;200,0,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--Phone&nbsp;Number--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Phone&nbsp;No:&nbsp;&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;5&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,25,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBox</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;TxtPhNo&quot;</span>&nbsp;<span class="xaml__attr_name">BorderBrush</span>=<span class="xaml__attr_value">&quot;LightGray&quot;</span>&nbsp;<span class="xaml__attr_name">MaxLength</span>=<span class="xaml__attr_value">&quot;10&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">InputScope</span>=<span class="xaml__attr_value">&quot;digits&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;5&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;100,0,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">GotFocus</span>=<span class="xaml__attr_value">&quot;Txt_GotFocus&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--Email--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;EmaiID:&nbsp;&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;6&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,25,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBox</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;TxtEmail&quot;</span>&nbsp;<span class="xaml__attr_name">BorderBrush</span>=<span class="xaml__attr_value">&quot;LightGray&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;6&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;100,0,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">GotFocus</span>=<span class="xaml__attr_value">&quot;Txt_GotFocus&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--Submit&nbsp;Button--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">BorderBrush</span>=<span class="xaml__attr_value">&quot;Transparent&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;#FF30DABB&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Submit&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;BtnSubmit&quot;</span>&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;Submit_Click&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;7&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;So your phone looks like:</div>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small"><a href="http://1.bp.blogspot.com/-AfTwJKVttT8/VPV_P2z2UYI/AAAAAAAABwA/V2yXp0r88I0/s1600/Registration.PNG"><img src="https://images-blogger-opensocial.googleusercontent.com/gadgets/proxy?url=http%3A%2F%2F1.bp.blogspot.com%2F-AfTwJKVttT8%2FVPV_P2z2UYI%2FAAAAAAAABwA%2FV2yXp0r88I0%2Fs1600%2FRegistration.PNG&container=blogger&gadget=a&rewriteMime=image%2F*" border="0" alt="" width="221" height="400"></a></span></p>
&nbsp;
<p><span style="font-size:small">In&nbsp;SignUpPage<span style="font-family:Verdana,sans-serif">.xaml.cs, write following code and it is for validating user details to&nbsp;successful&nbsp;registration.
</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">IsolatedStorageFile&nbsp;ISOFile&nbsp;=&nbsp;IsolatedStorageFile.GetUserStoreForApplication();&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Submit_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//UserName&nbsp;Validation&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!Regex.IsMatch(TxtUserName.Text.Trim(),&nbsp;@<span class="cs__string">&quot;^[A-Za-z_][a-zA-Z0-9_\s]*$&quot;</span>))&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Invalid&nbsp;UserName&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Password&nbsp;length&nbsp;Validation&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(TxtPwd.Password.Length&nbsp;&lt;&nbsp;<span class="cs__number">6</span>)&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Password&nbsp;length&nbsp;should&nbsp;be&nbsp;minimum&nbsp;of&nbsp;6&nbsp;characters!&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Address&nbsp;Text&nbsp;Empty&nbsp;Validation&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(TxtAddr.Text&nbsp;==&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Please&nbsp;enter&nbsp;your&nbsp;address!&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Gender&nbsp;Selection&nbsp;Empty&nbsp;Validation&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(gender&nbsp;==&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Please&nbsp;select&nbsp;gender!&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Phone&nbsp;Number&nbsp;Length&nbsp;Validation&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(TxtPhNo.Text.Length&nbsp;!=&nbsp;<span class="cs__number">10</span>)&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Invalid&nbsp;PhonNo&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//EmailID&nbsp;validation&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(!Regex.IsMatch(TxtEmail.Text.Trim(),&nbsp;@<span class="cs__string">&quot;^([a-zA-Z_])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]&#43;)\.)&#43;))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$&quot;</span>))&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Invalid&nbsp;EmailId&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//After&nbsp;validation&nbsp;success&nbsp;,store&nbsp;user&nbsp;detials&nbsp;in&nbsp;isolated&nbsp;storage&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(TxtUserName.Text&nbsp;!=&nbsp;<span class="cs__string">&quot;&quot;</span>&nbsp;&amp;&amp;&nbsp;TxtPwd.Password&nbsp;!=&nbsp;<span class="cs__string">&quot;&quot;</span>&nbsp;&amp;&amp;&nbsp;TxtAddr.Text&nbsp;!=&nbsp;<span class="cs__string">&quot;&quot;</span>&nbsp;&amp;&amp;&nbsp;TxtEmail.Text&nbsp;!=&nbsp;<span class="cs__string">&quot;&quot;</span>&nbsp;&amp;&amp;&nbsp;gender&nbsp;!=&nbsp;<span class="cs__string">&quot;&quot;</span>&nbsp;&amp;&amp;&nbsp;TxtPhNo.Text&nbsp;!=&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UserData&nbsp;ObjUserData&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UserData();&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjUserData.UserName&nbsp;=&nbsp;TxtUserName.Text;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjUserData.Password&nbsp;=&nbsp;TxtPwd.Password;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjUserData.Address&nbsp;=&nbsp;TxtAddr.Text;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjUserData.Email&nbsp;=&nbsp;TxtEmail.Text;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjUserData.Gender&nbsp;=&nbsp;gender;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjUserData.PhoneNo&nbsp;=&nbsp;TxtPhNo.Text;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;Temp&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;UserLogin&nbsp;<span class="cs__keyword">in</span>&nbsp;ObjUserDataList)&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ObjUserData.UserName&nbsp;==&nbsp;UserLogin.UserName)&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Temp&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Checking&nbsp;existing&nbsp;user&nbsp;names&nbsp;in&nbsp;local&nbsp;DB&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Temp&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjUserDataList.Add(ObjUserData);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ISOFile.FileExists(<span class="cs__string">&quot;RegistrationDetails&quot;</span>))&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ISOFile.DeleteFile(<span class="cs__string">&quot;RegistrationDetails&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(IsolatedStorageFileStream&nbsp;fileStream&nbsp;=&nbsp;ISOFile.OpenFile(<span class="cs__string">&quot;RegistrationDetails&quot;</span>,&nbsp;FileMode.Create))&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataContractSerializer&nbsp;serializer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataContractSerializer(<span class="cs__keyword">typeof</span>(List&lt;UserData&gt;));&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serializer.WriteObject(fileStream,&nbsp;ObjUserDataList);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Congrats!&nbsp;your&nbsp;have&nbsp;successfully&nbsp;Registered.&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NavigationService.Navigate(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;/Views/LoginPage.xaml&quot;</span>,&nbsp;UriKind.Relative));&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Sorry!&nbsp;user&nbsp;name&nbsp;is&nbsp;already&nbsp;existed.&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Please&nbsp;enter&nbsp;all&nbsp;details&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p class="separator"><span style="font-size:small"><a href="http://1.bp.blogspot.com/-o8NolmnPG34/VPlWbTtm-MI/AAAAAAAABwU/QLinsINe9lA/s1600/Validation.PNG"><img src="https://images-blogger-opensocial.googleusercontent.com/gadgets/proxy?url=http%3A%2F%2F1.bp.blogspot.com%2F-o8NolmnPG34%2FVPlWbTtm-MI%2FAAAAAAAABwU%2FQLinsINe9lA%2Fs1600%2FValidation.PNG&container=blogger&gadget=a&rewriteMime=image%2F*" border="0" alt="" width="221" height="400"></a></span></p>
<p><span style="font-family:Verdana,sans-serif; font-size:small">After&nbsp;successfully user registration, i saved user details in IsolatedStorageFile name is '<strong>RegistrationDetails</strong>'. So that every user details list can be stored in this file.</span></p>
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small"><a href="http://3.bp.blogspot.com/-F-KzUkCWb8w/VPlY_MCC-VI/AAAAAAAABwo/ER8b9tNsFjo/s1600/SucessRegistration.PNG"><img src="https://images-blogger-opensocial.googleusercontent.com/gadgets/proxy?url=http%3A%2F%2F3.bp.blogspot.com%2F-F-KzUkCWb8w%2FVPlY_MCC-VI%2FAAAAAAAABwo%2FER8b9tNsFjo%2Fs1600%2FSucessRegistration.PNG&container=blogger&gadget=a&rewriteMime=image%2F*" border="0" alt="" width="221" height="400"></a></span></p>
&nbsp;
<p class="separator"><span style="font-family:Verdana,sans-serif; font-size:small"><br>
</span></p>
<p><span style="font-size:small"><strong>Step 4 : How to get login user details</strong></span></p>
<p><span style="font-size:small"><span style="font-family:Verdana,sans-serif"><strong><br>
</strong></span><span style="font-family:Verdana,sans-serif">So&nbsp;</span>'<strong>RegistrationDetails</strong><span style="font-family:Verdana,sans-serif">'&nbsp;isolated storage file having list of users registration details. When user entering his username,
 password and pressing the login button from LoginPage. we need to check&nbsp;authentication process like this:</span>
</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong><br>
</strong></span></p>
<p><span style="font-size:small"><strong>On LoginPage Loaded :&nbsp;</strong>Read all existing user details list
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;LoginPage_Loaded(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;Settings&nbsp;=&nbsp;IsolatedStorageSettings.ApplicationSettings;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Check&nbsp;if&nbsp;user&nbsp;already&nbsp;login,so&nbsp;we&nbsp;need&nbsp;to&nbsp;direclty&nbsp;navigate&nbsp;to&nbsp;details&nbsp;page&nbsp;instead&nbsp;of&nbsp;showing&nbsp;login&nbsp;page&nbsp;when&nbsp;user&nbsp;launch&nbsp;the&nbsp;app.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Settings.Contains(<span class="cs__string">&quot;CheckLogin&quot;</span>))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NavigationService.Navigate(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;/Views/UserDetails.xaml&quot;</span>,&nbsp;UriKind.Relative));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ISOFile.FileExists(<span class="cs__string">&quot;RegistrationDetails&quot;</span>))<span class="cs__com">//loaded&nbsp;previous&nbsp;items&nbsp;into&nbsp;list&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(IsolatedStorageFileStream&nbsp;fileStream&nbsp;=&nbsp;ISOFile.OpenFile(<span class="cs__string">&quot;RegistrationDetails&quot;</span>,&nbsp;FileMode.Open))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataContractSerializer&nbsp;serializer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataContractSerializer(<span class="cs__keyword">typeof</span>(List&lt;UserData&gt;));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjUserDataList&nbsp;=&nbsp;(List&lt;UserData&gt;)serializer.ReadObject(fileStream);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="font-family:Verdana,sans-serif">On Login button Click:
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span><span class="cs__keyword">void</span>&nbsp;Login_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(UserName.Text&nbsp;!=&nbsp;<span class="cs__string">&quot;&quot;</span>&nbsp;&amp;&amp;&nbsp;PassWord.Password&nbsp;!=&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;Temp&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;UserLogin&nbsp;<span class="cs__keyword">in</span>&nbsp;ObjUserDataList)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(UserName.Text&nbsp;==&nbsp;UserLogin.UserName&nbsp;&amp;&amp;&nbsp;PassWord.Password&nbsp;==&nbsp;UserLogin.Password)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Temp&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;Settings&nbsp;=&nbsp;IsolatedStorageSettings.ApplicationSettings;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Settings[<span class="cs__string">&quot;CheckLogin&quot;</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;Login&nbsp;sucess&quot;</span>;<span class="cs__com">//write&nbsp;iso&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="cs__keyword">if</span>&nbsp;(ISOFile.FileExists(<span class="cs__string">&quot;CurrentLoginUserDetails&quot;</span>))&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ISOFile.DeleteFile(<span class="cs__string">&quot;CurrentLoginUserDetails&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(IsolatedStorageFileStream&nbsp;fileStream&nbsp;=&nbsp;ISOFile.OpenFile(<span class="cs__string">&quot;CurrentLoginUserDetails&quot;</span>,&nbsp;FileMode.Create))&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataContractSerializer&nbsp;serializer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataContractSerializer(<span class="cs__keyword">typeof</span>(UserData));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serializer.WriteObject(fileStream,&nbsp;UserLogin);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NavigationService.Navigate(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;/Views/UserDetails.xaml&quot;</span>,&nbsp;UriKind.Relative));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Temp&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Invalid&nbsp;UserID/Password&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Enter&nbsp;UserID/Password&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
</strong><strong style="font-family:Verdana,sans-serif">
<div class="endscriptcode">Here after successful login, I am storing the current login user details in Isolated Storage file name is 'CurrentLoginUserDetails'. So that i can able to read current login user details from this file to show the details in 'UserDetails'
 page like this:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;UserDetailsPage_Loaded(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ISOFile.FileExists(<span class="cs__string">&quot;CurrentLoginUserDetails&quot;</span>))<span class="cs__com">//read&nbsp;current&nbsp;user&nbsp;login&nbsp;details&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(IsolatedStorageFileStream&nbsp;fileStream&nbsp;=&nbsp;ISOFile.OpenFile(<span class="cs__string">&quot;CurrentLoginUserDetails&quot;</span>,&nbsp;FileMode.Open))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataContractSerializer&nbsp;serializer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataContractSerializer(<span class="cs__keyword">typeof</span>(UserData));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjUserData&nbsp;=&nbsp;(UserData)serializer.ReadObject(fileStream);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StckUserDetailsUI.DataContext&nbsp;=&nbsp;ObjUserData;<span class="cs__com">//Bind&nbsp;current&nbsp;login&nbsp;user&nbsp;details&nbsp;to&nbsp;UI&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<a href="http://2.bp.blogspot.com/--2-ZhyqC-Gg/VPlwzThrhRI/AAAAAAAABw4/0lJMwT4L7PE/s1600/Userdetails.PNG" style="font-family:Verdana,Arial,Helvetica,sans-serif"><img src="https://images-blogger-opensocial.googleusercontent.com/gadgets/proxy?url=http%3A%2F%2F2.bp.blogspot.com%2F--2-ZhyqC-Gg%2FVPlwzThrhRI%2FAAAAAAAABw4%2F0lJMwT4L7PE%2Fs1600%2FUserdetails.PNG&container=blogger&gadget=a&rewriteMime=image%2F*" border="0" alt="" width="221" height="400"></a></div>
</div>
</strong></div>
<p>&nbsp;</p>
<p><span style="font-family:Verdana,sans-serif; font-size:small">And xaml code in UserDetails.xaml page like this:
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__comment">&lt;!--LayoutRoot&nbsp;is&nbsp;the&nbsp;root&nbsp;grid&nbsp;where&nbsp;all&nbsp;page&nbsp;content&nbsp;is&nbsp;placed--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;LayoutRoot&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;LightGray&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;White&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;User&nbsp;details:&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,10,0,20&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Center&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;30&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Image</span>&nbsp;<span class="xaml__attr_name">Stretch</span>=<span class="xaml__attr_value">&quot;None&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Right&quot;</span>&nbsp;<span class="xaml__attr_name">Source</span>=<span class="xaml__attr_value">&quot;/Images/SignOut.jpg&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;51&quot;</span>&nbsp;<span class="xaml__attr_name">Tap</span>=<span class="xaml__attr_value">&quot;ImgSignOut_Tap&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--ContentPanel&nbsp;-&nbsp;place&nbsp;additional&nbsp;content&nbsp;here--&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ContentPanel&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;2&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;StckUserDetailsUI&quot;</span>&nbsp;&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;12,17,0,28&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;TxtUserName&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;UserName}&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;TxtAddress&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Address}&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;TxtGender&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Gender}&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;TxtPhoneNo&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;PhoneNo}&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;TxtEmaiID&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Email}&quot;</span>&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="font-family:Verdana,Arial,Helvetica,sans-serif">Step 5 : Logout from the application&nbsp;</strong></div>
<p>&nbsp;</p>
<p><span style="font-family:Verdana,sans-serif; font-size:small">Normally in login applications, when user already login with our app and on next app launch we need to directly showing the user&nbsp;details&nbsp;page instead of showing login&nbsp;page until
 signout from the application.</span></p>
<p><span style="font-size:small">And it is very simple to implement this functionality. Just take one isolated variable(i.e CheckLogin) and store some&nbsp;temporary&nbsp;value when user successfully login with&nbsp;his details, so on next app launch we need
 to check 'CheckLogin' variable value. If it is having value means user already logined. So our app&nbsp;directly&nbsp;need to show user details instead of loginpage until logout . And when&nbsp;user pressing on 'Logout/Signout' button we need to remove isolated
 variable value(i.e CheckLogin) so on next app launch this variable value will be empty and our app need to show LoginPage.</span></p>
<p><span style="font-family:Verdana,sans-serif; font-size:small"><br>
</span></p>
<p><span style="font-family:Verdana,sans-serif; font-size:small"><strong>On SignOut tap event :&nbsp;</strong>remove 'CheckLogin' isolated variable value
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ImgSignOut_Tap(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;System.Windows.Input.GestureEventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SignOut();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SignOut()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;Result&nbsp;=&nbsp;MessageBox.Show(<span class="cs__string">&quot;Are&nbsp;you&nbsp;sure&nbsp;you&nbsp;want&nbsp;to&nbsp;signout&nbsp;from&nbsp;this&nbsp;page?&quot;</span>,&nbsp;<span class="cs__string">&quot;&quot;</span>,&nbsp;MessageBoxButton.OKCancel);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Result&nbsp;==&nbsp;MessageBoxResult.OK)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;Settings&nbsp;=&nbsp;IsolatedStorageSettings.ApplicationSettings;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Settings.Remove(<span class="cs__string">&quot;CheckLogin&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NavigationService.Navigate(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;/Views/LoginPage.xaml&quot;</span>,&nbsp;UriKind.Relative));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>On next app launch :</strong></div>
<p>&nbsp;</p>
<p><span style="font-family:Verdana,sans-serif; font-size:small"><strong>&nbsp;</strong></span></p>
<p><strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;LoginPage_Loaded(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;Settings&nbsp;=&nbsp;IsolatedStorageSettings.ApplicationSettings;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Check&nbsp;if&nbsp;user&nbsp;already&nbsp;login,so&nbsp;we&nbsp;need&nbsp;to&nbsp;direclty&nbsp;navigate&nbsp;to&nbsp;details&nbsp;page&nbsp;instead&nbsp;of&nbsp;showing&nbsp;login&nbsp;page&nbsp;when&nbsp;user&nbsp;launch&nbsp;the&nbsp;app.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Settings.Contains(<span class="cs__string">&quot;CheckLogin&quot;</span>))&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NavigationService.Navigate(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;/Views/UserDetails.xaml&quot;</span>,&nbsp;UriKind.Relative));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NavigationService.Navigate(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;/ViewsLoginPage.xaml&quot;</span>,&nbsp;UriKind.Relative));&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;This article is also available at my original <a title="MyBlogReference" href="http://bsubramanyamraju.blogspot.com/2015/03/windows-phone-login-application-sample.html" target="_blank">
blog.</a></div>
</strong>
<p></p>
<p>&nbsp;</p>
<div></div>
<pre class="csharp"><p><span style="font-size:small"><strong>Help me with feedback:</strong></span></p><p><span style="font-size:small">Thank you for reading my article. Drop all your questions/comments in QA tab give me your feedback with&nbsp;<img id="67168" src="http://i1.code.msdn.s-msft.com/oops-principles-solid-7a4e69bf/image/file/67168/1/ratings.png" alt="" width="74" height="15">&nbsp;star rating (1 Star - Very Poor, 5&nbsp;Star -&nbsp;Very Nice). &nbsp;</span></p></pre>
