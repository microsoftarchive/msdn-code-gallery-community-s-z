# WPF FlashMessage Control
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- Controls
- Animation
- WPF CustomControl
- Fading Effect
## Updated
- 04/19/2012
## Description

<h1>The Motivation</h1>
<p><em>&nbsp; &nbsp; &nbsp;Aren't you tired of all the MessageBoxes on your applications? Isn't there a better way to alert users whether an operation was successfully completed? For years I used MessageBox or a static label in WinForms applications, and they
 came with me when I started to migrate to WPF.</em></p>
<p><em>&nbsp; &nbsp; &nbsp;However,&nbsp;WPF is so much more powerfull than that, and I thought why not create something different? Because let's face it, using MessageBox is like using javascript alert function in a web page, don't you think?. So it is settle,
 we need something new, but what? Well, once I was a <a title="RubyOnRails" href="http://rubyonrails.org/" target="_blank">
Rails</a> developer and Rails has a interesting <a title="The Flash" href="http://guides.rubyonrails.org/action_controller_overview.html#the-flash" target="_blank">
flash message system</a>, so I thought of creating a control that acts slightly&nbsp;similar.</em></p>
<h1>How does it work?</h1>
<p><em>&nbsp; &nbsp; &nbsp;So, let's see how the control works. It has two mainly properties: MessageType and Message.</em></p>
<p><em>&nbsp; &nbsp; &nbsp;The first one is the type of the message, whether a <strong>
<span style="color:#eea2a2">Error</span></strong>, <strong><span style="color:#71f96c">Success</span></strong> or
<span style="color:#f0f17f"><strong>Notice</strong></span>. These influence which style the control uses. Also, you can change it at any time and the style will be updated accordingly; this is nice because you can use only one FlashMessage's instance to show
 different types of messages.</em></p>
<p><em>&nbsp; &nbsp; &nbsp;The second one it's the message itself. As soon as this property is changed, the FlashMessage fades in automatically, so you don't have to explicity call any method. Once the FlashMessage is shown you can click on the close button
 to fade it out or wait untill it fades out automatically. This behavior is configurable, as explained below.</em></p>
<p><em>&nbsp; &nbsp; &nbsp;Others properties affect the FlashMessage behavior, specifically how it fades out, here they are:</em></p>
<p><em>&nbsp; &nbsp; &nbsp;FadesOutAutomatically: besides clicking on the close button, you can configure whether it fades out automatically; the default is true.</em></p>
<p><em>&nbsp; &nbsp; &nbsp;FadeOutTime: it specifies how much time the FlashMessage waits to fades out after it fades in; this property only takes effect if FadesOutAutomatically is set to true; the default is 10 seconds.</em></p>
<h1>A Glimpse</h1>
<p><em>&nbsp; &nbsp; &nbsp;<img src="http://i1.code.msdn.s-msft.com/new-control-to-get-rid-of-377ffb5a/image/file/56088/2/sem%20t%c3%adtulo.png" alt="" width="520" height="181"></em></p>
<h1>The Sample</h1>
<p><em>&nbsp; &nbsp; &nbsp;The sample has two projects. One is a Control Library which contains the FlashMessage control, and the another one is a WPF Application that shows how to use it.</em></p>
<h1><span style="font-size:20px">The Code</span></h1>
<p><em>&nbsp; &nbsp; &nbsp;The code is divided in two parts, the implementation of the FlashMessage's behavior and its style.</em></p>
<p><em>&nbsp; &nbsp; &nbsp;If you open the Generic.xaml file, you'll notice VS designer will throw an error: &quot;Error<span>
</span>1<span> </span>Object 'null' cannot be used as an accessor parameter for a PropertyPath. An accessor parameter must be DependencyProperty, PropertyInfo, or PropertyDescriptor&quot;. This only happens on design mode and seems like a bug, as reported
<a title="connect.microsoft" href="http://connect.microsoft.com/VisualStudio/feedback/details/552131/designer-fails-when-data-binding-to-a-grandchild-property-through-an-explicit-interface-on-the-immediate-child" target="_blank">
here</a>.&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">xaml</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.aspx" target="_blank" title="Auto generated link to System.Windows">System.Windows</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Controls.aspx" target="_blank" title="Auto generated link to System.Windows.Controls">System.Windows.Controls</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Input.aspx" target="_blank" title="Auto generated link to System.Windows.Input">System.Windows.Input</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Media.Animation.aspx" target="_blank" title="Auto generated link to System.Windows.Media.Animation">System.Windows.Media.Animation</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Threading.aspx" target="_blank" title="Auto generated link to System.Windows.Threading">System.Windows.Threading</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;FlashMessage&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;FlashMessage&nbsp;:&nbsp;Control&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;DispatcherTimer&nbsp;fadeOutTimer;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;FlashMessage()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DefaultStyleKeyProperty.OverrideMetadata(<span class="cs__keyword">typeof</span>(FlashMessage),&nbsp;<span class="cs__keyword">new</span>&nbsp;FrameworkPropertyMetadata(<span class="cs__keyword">typeof</span>(FlashMessage)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;FlashMessage()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.fadeOutTimer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DispatcherTimer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.fadeOutTimer.Interval&nbsp;=&nbsp;<span class="cs__keyword">this</span>.FadeOutTime.TimeSpan;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.fadeOutTimer.Tick&nbsp;&#43;=&nbsp;<span class="cs__keyword">this</span>.FadeOutTimer_Tick;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.CommandBindings.Add(<span class="cs__keyword">new</span>&nbsp;CommandBinding(ApplicationCommands.Close,&nbsp;CloseCommandHandler));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;ContentDataTemplate</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;DependencyProperty&nbsp;ContentDataTemplateProperty&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.Register(<span class="cs__string">&quot;ContentDataTemplate&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(DataTemplate),&nbsp;<span class="cs__keyword">typeof</span>(FlashMessage));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DataTemplate&nbsp;ContentDataTemplate&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;(DataTemplate)GetValue(ContentDataTemplateProperty);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(ContentDataTemplateProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span><span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;FadesOutAutomatically</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;DependencyProperty&nbsp;FadesOutAutomaticallyProperty&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.Register(<span class="cs__string">&quot;FadesOutAutomatically&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">bool</span>),&nbsp;<span class="cs__keyword">typeof</span>(FlashMessage),&nbsp;<span class="cs__keyword">new</span>&nbsp;PropertyMetadata(<span class="cs__keyword">true</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;FadesOutAutomatically&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;(<span class="cs__keyword">bool</span>)GetValue(FadesOutAutomaticallyProperty);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(FadesOutAutomaticallyProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span><span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;FadeOutTime</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;DependencyProperty&nbsp;FadeOutTimeProperty&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.Register(<span class="cs__string">&quot;FadeOutTime&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(Duration),&nbsp;<span class="cs__keyword">typeof</span>(FlashMessage),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;PropertyMetadata(<span class="cs__keyword">new</span>&nbsp;Duration(TimeSpan.FromSeconds(<span class="cs__number">10</span>)),&nbsp;<span class="cs__keyword">new</span>&nbsp;PropertyChangedCallback(OnFadeOutTimeChanged)));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Duration&nbsp;FadeOutTime&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;(Duration)GetValue(FadeOutTimeProperty);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(FadeOutTimeProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnFadeOutTimeChanged(DependencyObject&nbsp;o,&nbsp;DependencyPropertyChangedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((FlashMessage)o).OnFadeOutTimeChanged();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnFadeOutTimeChanged()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.fadeOutTimer.Interval&nbsp;=&nbsp;<span class="cs__keyword">this</span>.FadeOutTime.TimeSpan;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.StopTimerIfRunning();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span><span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Message</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;DependencyProperty&nbsp;MessageProperty&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.Register(<span class="cs__string">&quot;Message&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">string</span>),&nbsp;<span class="cs__keyword">typeof</span>(FlashMessage),&nbsp;<span class="cs__keyword">new</span>&nbsp;PropertyMetadata(OnMessageChanged));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Message&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;(<span class="cs__keyword">string</span>)GetValue(MessageProperty);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(MessageProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnMessageChanged(DependencyObject&nbsp;o,&nbsp;DependencyPropertyChangedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((FlashMessage)o).OnMessageChanged();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnMessageChanged()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.IsFlashMessageVisible&nbsp;=&nbsp;!<span class="cs__keyword">string</span>.IsNullOrEmpty(<span class="cs__keyword">this</span>.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span><span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;MessageType</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;DependencyProperty&nbsp;MessageTypeProperty&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.Register(<span class="cs__string">&quot;MessageType&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(MessageType),&nbsp;<span class="cs__keyword">typeof</span>(FlashMessage));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MessageType&nbsp;MessageType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;(MessageType)GetValue(MessageTypeProperty);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(MessageTypeProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span><span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Reset</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;DependencyProperty&nbsp;ResetProperty&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.Register(<span class="cs__string">&quot;Reset&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">bool</span>),&nbsp;<span class="cs__keyword">typeof</span>(FlashMessage),&nbsp;<span class="cs__keyword">new</span>&nbsp;PropertyMetadata(OnResetChanged));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;Reset&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;(<span class="cs__keyword">bool</span>)GetValue(ResetProperty);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(ResetProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnResetChanged(DependencyObject&nbsp;o,&nbsp;DependencyPropertyChangedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((FlashMessage)o).OnResetChanged();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnResetChanged()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.Reset)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Visibility&nbsp;=&nbsp;System.Windows.Visibility.Collapsed;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Message&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span><span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;IsFlashMessageVisible</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;DependencyProperty&nbsp;IsFlashMessageVisibleProperty&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyProperty.Register(<span class="cs__string">&quot;IsFlashMessageVisible&quot;</span>,&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">bool</span>),&nbsp;<span class="cs__keyword">typeof</span>(FlashMessage),&nbsp;<span class="cs__keyword">new</span>&nbsp;PropertyMetadata(OnIsFlashMessageVisibleChanged));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsFlashMessageVisible&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;(<span class="cs__keyword">bool</span>)GetValue(IsFlashMessageVisibleProperty);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(IsFlashMessageVisibleProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnIsFlashMessageVisibleChanged(DependencyObject&nbsp;o,&nbsp;DependencyPropertyChangedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((FlashMessage)o).OnIsFlashMessageVisibleChanged();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnIsFlashMessageVisibleChanged()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.IsFlashMessageVisible)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Visibility&nbsp;=&nbsp;System.Windows.Visibility.Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.StartTimerIfAutomatically();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.StartFadeOutAnimation();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Hide()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.StopTimerIfRunning();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.IsFlashMessageVisible&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnApplyTemplate()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnApplyTemplate();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.ContentDataTemplate&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.ContentDataTemplate&nbsp;=&nbsp;(DataTemplate)<span class="cs__keyword">this</span>.FindResource(<span class="cs__string">&quot;flashMessageTemplate&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;FadeOutTimer_Tick(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Hide();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CloseCommandHandler(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;ExecutedRoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Hide();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;StopTimerIfRunning()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.fadeOutTimer.IsEnabled)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.fadeOutTimer.Stop();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;StartTimerIfAutomatically()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.StopTimerIfRunning();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.FadesOutAutomatically)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.fadeOutTimer.Start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;StartFadeOutAnimation()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;storyBoard&nbsp;=&nbsp;(Storyboard)<span class="cs__keyword">this</span>.FindResource(<span class="cs__string">&quot;fadeOutAnimation&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(storyBoard&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;storyBoard.Begin(<span class="cs__keyword">this</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1>More Information</h1>
<p><em>&nbsp; &nbsp; &nbsp;This project is also on <a href="https://github.com/JobaDiniz/FlashMessage" target="_blank">
GitHub</a>; feel free to fork it and help to improve the FlashMessage control.</em></p>
