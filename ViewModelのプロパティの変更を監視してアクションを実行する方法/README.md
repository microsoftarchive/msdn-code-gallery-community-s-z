# ViewModelのプロパティの変更を監視してアクションを実行する方法
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ViewModel pattern (MVVM)
## Topics
- ViewModel pattern (MVVM)
## Updated
- 05/06/2011
## Description

<h1>Introduction</h1>
<p>Model View ViewModelパターンで、ViewModelのプロパティの変更を監視してView側でアクションを実行する方法をExpression Blend SDKのBehaviorを使用して記述する例を示します。</p>
<h1>Building the Sample</h1>
<p>解凍したソリューションを開いてビルドして実行できます。Expressの場合はVisual C# 2010 Expressを使用してください。</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:x-small">サンプルプログラムの作成手順を示します。ここでは、ViewModelのIsErrorプロパティを監視して、Trueの場合には、Rectangleの背景色を赤に、Falseの場合には、背景色を青にするプログラムを作成します。</span></p>
<h2><span style="font-size:20px">下準備</span></h2>
<p>ViewModelの基本クラスとして以下のコードを準備します。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;PropertyChangedTriggerSample.Commons&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.ComponentModel.aspx" target="_blank" title="Auto generated link to System.ComponentModel">System.ComponentModel</a>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;ViewModelの基本クラス</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ViewModelBase&nbsp;:&nbsp;INotifyPropertyChanged&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">event</span>&nbsp;PropertyChangedEventHandler&nbsp;PropertyChanged;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">virtual</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;RaisePropertyChanged(<span class="cs__keyword">string</span>&nbsp;propertyName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;h&nbsp;=&nbsp;<span class="cs__keyword">this</span>.PropertyChanged;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(h&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;h(<span class="cs__keyword">this</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;PropertyChangedEventArgs(propertyName));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<div class="endscriptcode">&nbsp;そして、ViewModelBaseを継承して、MainWindowのViewModelを作成します。このクラスには、Viewから監視するためのプロパティとしてIsErrorプロパティを定義しています。</div>
<p>&nbsp;</p>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;PropertyChangedTriggerSample.Commons;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;PropertyChangedTriggerSample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MainWindowViewModel&nbsp;:&nbsp;ViewModelBase&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;isError;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsError&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.isError;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.isError&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.RaisePropertyChanged(<span class="cs__string">&quot;IsError&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">MainWindow.xamlのDataContextに上述のMainWindowViewModelを追加します。</div>
<div class="endscriptcode">
<h2 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__comment">&lt;!--&nbsp;Windowタグに名前空間の定義&nbsp;--&gt;</span>&nbsp;
xmlns:l=&quot;clr-namespace:PropertyChangedTriggerSample&quot;&nbsp;
&nbsp;
<span class="xaml__comment">&lt;!--&nbsp;DataContextにViewModelを設定する&nbsp;--&gt;</span>&nbsp;
<span class="xaml__tag_start">&lt;Window</span>.DataContext<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;l</span>:MainWindowViewModel&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&lt;/Window.DataContext&gt;&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</h2>
</div>
</div>
<p>&nbsp;</p>
<div class="endscriptcode">
<p class="endscriptcode"><span style="font-size:xx-small">次に画面のレイアウトを定義します。画面はViewModelのIsErrorプロパティとバインドするためのCheckBoxと、ViewModelのプロパティの変更に応じて背景色を変える(この操作をBehaviorで記述します）Rectangleを配置します。</span></p>
<p class="endscriptcode"><span style="font-size:xx-small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">XAML</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;Window&nbsp;x:Class=<span class="js__string">&quot;PropertyChangedTriggerSample.MainWindow&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns=<span class="js__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns:x=<span class="js__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns:l=<span class="js__string">&quot;clr-namespace:PropertyChangedTriggerSample&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Title=<span class="js__string">&quot;PropertyChangedTrigger&nbsp;Sample&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Height=<span class="js__string">&quot;150&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Width=<span class="js__string">&quot;250&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Window.DataContext&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;l:MainWindowViewModel&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Window.DataContext&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition&nbsp;Height=<span class="js__string">&quot;Auto&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowDefinition&nbsp;Height=<span class="js__string">&quot;277*&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;CheckBox&nbsp;Content=<span class="js__string">&quot;IsError&quot;</span>&nbsp;IsChecked=<span class="js__string">&quot;{Binding&nbsp;Path=IsError}&quot;</span>&nbsp;Margin=<span class="js__string">&quot;5&quot;</span>&nbsp;HorizontalAlignment=<span class="js__string">&quot;Left&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Rectangle&nbsp;Name=<span class="js__string">&quot;rectangle&quot;</span>&nbsp;Stroke=<span class="js__string">&quot;Black&quot;</span>&nbsp;Fill=<span class="js__string">&quot;Blue&quot;</span>&nbsp;Grid.Row=<span class="js__string">&quot;1&quot;</span>&nbsp;Margin=<span class="js__string">&quot;5&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&lt;/Window&gt;&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
以上で、下準備は完了です。ここからViewModelのプロパティの変更を監視してアクションを実行するXAMLを記述します。
<p>&nbsp;</p>
</div>
<p>&nbsp;</p>
<div class="endscriptcode">
<h2 class="endscriptcode">PropertyChangedTriggerの適用</h2>
<div class="endscriptcode">ViewModel（ViewModelに限らず適用は可能）のプロパティの変更を監視して、アクションを実行するにはPropertyChangedTriggerを使います。これはExpressionBlend SDKに入っています。入っているアセンブリは、System.Windows.InteractivityではなくMicrosoft.Expression.Interactionsのほうなので、プロジェクトには両方のアセンブリを追加します。
<div class="endscriptcode" style="display:inline!important">
<div class="endscriptcode" style="display:inline!important">まず、PropertyChangedTriggerを使えるようにするため、以下の名前空間をWindowタグに追加します。</div>
<div class="endscriptcode" style="display:inline!important"></div>
<div class="endscriptcode" style="display:inline!important">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">XAML</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">xmlns:i=<span class="js__string">&quot;http://schemas.microsoft.com/expression/2010/interactivity&quot;</span>&nbsp;&nbsp;
xmlns:ei=<span class="js__string">&quot;http://schemas.microsoft.com/expression/2010/interactions&quot;</span>&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode" style="display:inline!important">名前空間を定義したので、PropertyChangedTriggerをGridに指定します。</div>
<div class="endscriptcode" style="display:inline!important"></div>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">XAML</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;i</span>:Interaction.Triggers<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span>:PropertyChangedTrigger&nbsp;<span class="xaml__attr_name">Binding</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=IsError}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span>:ChangePropertyAction&nbsp;<span class="xaml__attr_name">TargetObject</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ElementName=rectangle}&quot;</span>&nbsp;<span class="xaml__attr_name">PropertyName</span>=<span class="xaml__attr_value">&quot;Fill&quot;</span>&nbsp;<span class="xaml__attr_name">Value</span>=<span class="xaml__attr_value">&quot;Red&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ei:PropertyChangedTrigger&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/i:Interaction.Triggers&gt;</span>&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>PropertyChangedTriggerのBindingプロパティで、どのプロパティの値の変更を監視するか指定します。そして、値に変更があったときに実行するアクションをPropertyChangedTriggerの下に指定します。この例ではrectangleオブジェクトのFillプロパティをRedに指定しています。この状態では、プロパティに変更があったら、必ずRectangleが赤色に指定してしまうのでTrueの場合という条件を指定します。条件の指定は、PropertyChangedTriggerのプロパティではなく、ConditionBehaviorというビヘイビアをPropertyChangedTriggerに指定して行います。</p>
<p>ConditionBehaviorはTriggerの実行可否を判定するためのビヘイビアです。ConditionBehaviorの中には、条件式を表すComparisonConditionを指定します。IsErrorプロパティがTrueの場合にActionを実行するようにXAMLを記述します。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">XAML</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;ei</span>:PropertyChangedTrigger&nbsp;<span class="xaml__attr_name">Binding</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=IsError}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;i</span>:Interaction.Behaviors<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span><span class="xaml__tag_start">:ConditionBehavior&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span><span class="xaml__tag_start">:ConditionalExpression&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span>:ComparisonCondition&nbsp;<span class="xaml__attr_name">LeftOperand</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=IsError}&quot;</span>&nbsp;<span class="xaml__attr_name">RightOperand</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ei:ConditionalExpression&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ei:ConditionBehavior&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/i:Interaction.Behaviors&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span>:ChangePropertyAction&nbsp;<span class="xaml__attr_name">TargetObject</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ElementName=rectangle}&quot;</span>&nbsp;<span class="xaml__attr_name">PropertyName</span>=<span class="xaml__attr_value">&quot;Fill&quot;</span>&nbsp;<span class="xaml__attr_name">Value</span>=<span class="xaml__attr_value">&quot;Red&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/ei:PropertyChangedTrigger&gt;</span>&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;PropertyChangedTriggerにInteraction.Behaviorsを使用してConditionBehaviorを設定して、ComparisonCondigionで左辺値をIsErrorプロパティの値、RightOperandをTrueに指定します。これでIsErrorがTrueの時にPropertyChangedTriggerの配下のActionが実行されます。同様にFalseの時にはBlueにするPropertyChangedTriggerも追加します。</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">XAML</div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;ei:PropertyChangedTrigger&nbsp;Binding=<span class="js__string">&quot;{Binding&nbsp;Path=IsError}&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;i:Interaction.Behaviors&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ei:ConditionBehavior&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ei:ConditionalExpression&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ei:ComparisonCondition&nbsp;LeftOperand=<span class="js__string">&quot;{Binding&nbsp;Path=IsError}&quot;</span>&nbsp;RightOperand=<span class="js__string">&quot;False&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ei:ConditionalExpression&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ei:ConditionBehavior&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/i:Interaction.Behaviors&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;ei:ChangePropertyAction&nbsp;TargetObject=<span class="js__string">&quot;{Binding&nbsp;ElementName=rectangle}&quot;</span>&nbsp;PropertyName=<span class="js__string">&quot;Fill&quot;</span>&nbsp;Value=<span class="js__string">&quot;Blue&quot;</span>&nbsp;/&gt;&nbsp;
&lt;/ei:PropertyChangedTrigger&gt;&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode">以上で完成です。MainWindow.xaml全体を以下に示します。</div>
<div class="endscriptcode">
<h2 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Window</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;PropertyChangedTriggerSample.MainWindow&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">l</span>=<span class="xaml__attr_value">&quot;clr-namespace:PropertyChangedTriggerSample&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">i</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/expression/2010/interactivity&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">ei</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/expression/2010/interactions&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Title</span>=<span class="xaml__attr_value">&quot;PropertyChangedTrigger&nbsp;Sample&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;150&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;250&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Window</span>.DataContext<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;l</span>:MainWindowViewModel&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Window.DataContext&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;277*&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;i</span>:Interaction.Triggers<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span>:PropertyChangedTrigger&nbsp;<span class="xaml__attr_name">Binding</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=IsError}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;i</span>:Interaction.Behaviors<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span><span class="xaml__tag_start">:ConditionBehavior&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span><span class="xaml__tag_start">:ConditionalExpression&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span>:ComparisonCondition&nbsp;<span class="xaml__attr_name">LeftOperand</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=IsError}&quot;</span>&nbsp;<span class="xaml__attr_name">RightOperand</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ei:ConditionalExpression&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ei:ConditionBehavior&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/i:Interaction.Behaviors&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span>:ChangePropertyAction&nbsp;<span class="xaml__attr_name">TargetObject</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ElementName=rectangle}&quot;</span>&nbsp;<span class="xaml__attr_name">PropertyName</span>=<span class="xaml__attr_value">&quot;Fill&quot;</span>&nbsp;<span class="xaml__attr_name">Value</span>=<span class="xaml__attr_value">&quot;Red&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ei:PropertyChangedTrigger&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span>:PropertyChangedTrigger&nbsp;<span class="xaml__attr_name">Binding</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=IsError}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;i</span>:Interaction.Behaviors<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span><span class="xaml__tag_start">:ConditionBehavior&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span><span class="xaml__tag_start">:ConditionalExpression&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span>:ComparisonCondition&nbsp;<span class="xaml__attr_name">LeftOperand</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=IsError}&quot;</span>&nbsp;<span class="xaml__attr_name">RightOperand</span>=<span class="xaml__attr_value">&quot;False&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ei:ConditionalExpression&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ei:ConditionBehavior&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/i:Interaction.Behaviors&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ei</span>:ChangePropertyAction&nbsp;<span class="xaml__attr_name">TargetObject</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ElementName=rectangle}&quot;</span>&nbsp;<span class="xaml__attr_name">PropertyName</span>=<span class="xaml__attr_value">&quot;Fill&quot;</span>&nbsp;<span class="xaml__attr_name">Value</span>=<span class="xaml__attr_value">&quot;Blue&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ei:PropertyChangedTrigger&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/i:Interaction.Triggers&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;CheckBox</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;IsError&quot;</span>&nbsp;<span class="xaml__attr_name">IsChecked</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Path=IsError}&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Rectangle</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;rectangle&quot;</span>&nbsp;<span class="xaml__attr_name">Stroke</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__attr_name">Fill</span>=<span class="xaml__attr_value">&quot;Blue&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Window&gt;</span>&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</h2>
</div>
<h2 class="endscriptcode">動作確認</h2>
<div class="endscriptcode">プロジェクトを実行すると以下のようになります。CheckBoxにチェックを入れる(ViewModelのIsErrorプロパティをTrueにする）とRectangleが青から赤色になります。</div>
<div class="endscriptcode"><img src="22149-ws000035.jpg" alt="" width="248" height="149"></div>
<div class="endscriptcode">CheckBoxのチェックを外すと青色に戻ります。</div>
<div class="endscriptcode"></div>
<p><img src="22150-ws000036.jpg" alt="" width="247" height="148"></p>
