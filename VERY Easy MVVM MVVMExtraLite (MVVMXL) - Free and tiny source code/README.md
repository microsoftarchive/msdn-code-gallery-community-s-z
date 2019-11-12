# VERY Easy MVVM "MVVMExtraLite" (MVVMXL) - Free and tiny source code
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
## Topics
- ViewModel pattern (MVVM)
- MVVM
- Messaging
- Message Routing
- WPF Commanding
- Model View ViewModel
- Model Binding
- Attached Properties
- AttachedProperties
- Relay Commands
- Mediator
- The Mediator Pattern
- Command Pattern
- EventToCommand
- RoutedEvent
- WPF Toolkit
- MVVM Toolkit
## Updated
- 09/19/2012
## Description

<h1>Introduction</h1>
<div>This sample project contains all you need to develop MVVM applications. RelayCommand, Mediator, EventToCommand and an example of an AttachedProperty (CloseWindow from ViewModel).</div>
<div></div>
<div>Make the code your own and throw away&nbsp;those 3rd party DLLs :D</div>
<div>&nbsp;</div>
<h1><span>Building the Sample</span></h1>
<div>Just download, unzip, open and run! (please don't forget to rate this sample, thanks!)</div>
<div>&nbsp;</div>
<h1><span style="font-size:20px">Description</span></h1>
<div>As an experienced MVVM developer, I offer you this collection of classes, which cover almost all you need, to develop MVVM style applications. This project includes&nbsp;easy MVVM examples to show how it's done.</div>
<div>&nbsp;</div>
<div><strong>This project offers four of the most common solutions to MVVM development issues.
</strong></div>
<div>Just take what you need ;)</div>
<div>&nbsp;</div>
<h2><strong>1. Attached Property&nbsp;&#43; ViewModelBase = CloseWindow from ViewModel</strong></h2>
<div>One of the first question a developer asks when detaching from the code-behind is &quot;How do&nbsp;I invoke UI methods like Window.Close()&quot;</div>
<div></div>
<div>The answer is Attached Properties. This project includes an example Attached Property that invokes the Window's Close method, if the property changes. This acts like a trigger to close the window. It is bound to a property in the ViewModelBase, where we
 also have a method called CloseWindow that we can call from any ViewModel that inherits the ViewModelBase.</div>
<div>&nbsp;</div>
<h2><strong>2. RelayCommand</strong></h2>
<div>The RelayCommand is the simplest way to add commands to your ViewModels. It also has a CommandParameter and CanExecute delegate. This is simply copied from MSDN, but an essential class to have.</div>
<div>&nbsp;</div>
<div>The example shows using it to close the window in the previous example. The CanExecute is controlled by the IsChecked state of a CheckBox.</div>
<div>&nbsp;</div>
<h2><strong>3. Mediator</strong></h2>
<div>An essential class which helps shuttle messages around to any corner of your application.</div>
<div></div>
<div>In this example, it sends messages between two ViewModels.</div>
<div>&nbsp;</div>
<h2><strong>4. EventToCommand</strong></h2>
<div>Another missing link in MVVM is executing Commands from RoutedEvents.&nbsp;</div>
<div></div>
<div>Some 3rd party&nbsp;DLL options are <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Interactivity.aspx" target="_blank" title="Auto generated link to System.Windows.Interactivity">System.Windows.Interactivity</a> (Expression Blend) or MVVMLite.</div>
<div></div>
<div>If you prefer to keep your application light, here is a simple solution to add your own EventToCommands.</div>
<div></div>
<div>This method simply uses three Attached Properties.</div>
<div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;TextBlock&nbsp;Text=<span class="js__string">&quot;Click&nbsp;me,&nbsp;EventToCommand,&nbsp;pass&nbsp;param&quot;</span>&nbsp;FontSize=<span class="js__string">&quot;16&quot;</span>&nbsp;FontWeight=<span class="js__string">&quot;Bold&quot;</span>&nbsp;TextWrapping=<span class="js__string">&quot;Wrap&quot;</span>&nbsp;Width=<span class="js__string">&quot;150&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HorizontalAlignment=<span class="js__string">&quot;Center&quot;</span>&nbsp;VerticalAlignment=<span class="js__string">&quot;Center&quot;</span>&nbsp;Cursor=<span class="js__string">&quot;Hand&quot;</span>&nbsp;Background=<span class="js__string">&quot;AliceBlue&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>helper:EventToCommand.Event=<span class="js__string">&quot;UIElement.MouseLeftButtonDown&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;helper:EventToCommand.CommandParameter=<span class="js__string">&quot;{Binding&nbsp;Text,&nbsp;ElementName=textboxB}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;helper:EventToCommand.Command=<span class="js__string">&quot;{Binding&nbsp;EventedCommand1}&quot;</span>&nbsp;/&gt;</strong></pre>
</div>
</div>
</div>
<div class="endscriptcode">Event is the RoutedEvent to trigger on</div>
<div class="endscriptcode">Command is the ICommand to execute</div>
<div class="endscriptcode">CommandParameter is optional. If not included, the EventArgs will be passed.</div>
<div class="endscriptcode"></div>
<h2 class="endscriptcode"><strong>Solution Map</strong></h2>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"><img id="66306" src="66306-mvvmextralite.png" alt="" width="232" height="388"></div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<div>&nbsp;</div>
<div><span style="font-size:medium"><strong>Please help yourself to these essential MVVM tools.
</strong></span></div>
<div><span style="font-size:medium"><strong>I hope they give you as much help as they give me.</strong></span></div>
<div></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img src="-anithanks1.gif" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
