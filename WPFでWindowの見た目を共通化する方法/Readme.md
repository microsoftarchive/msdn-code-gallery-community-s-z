# WPFでWindowの見た目を共通化する方法
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- WPF アプリケーション
## Updated
- 12/03/2011
## Description

<h1>概要</h1>
<p>Windows Formsで提供されていた基本フォーム（フォームを継承することで、基本的な共通機能などを派生先のフォームで再実装しなくて済むようにする手法）と同等のことをWPFでやる例を示します。ここでは基本フォームを下記の目的で使用しているという前提で説明を行います。</p>
<ul>
<li>ヘッダーなど共通の見た目を定義する </li><li>共通の見た目の中に共通のボタンを定義する
<ul>
<li>このヘッダーに定義されたボタンの動作はウィンドウ毎にカスタマイズできる </li></ul>
</li></ul>
<p>なお、基本フォーム自体のやり方については、下記の記事を参照してください。</p>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/bx1155fz(v=vs.80).aspx">MSDN : Windows フォームのビジュアルの継承</a>
</li><li><a href="http://www.atmarkit.co.jp/fdotnet/dotnettips/324winbaseform/winbaseform.html">＠IT : 各フォームの共通要素を基本フォームにまとめるには？</a>
</li></ul>
<h1>見た目のカスタマイズと共通化</h1>
<p>WPFでは、見た目をカスタマイズして複数の要素で共有する機能としてStyleが提供されています。見た目のカスタマイズはこれを使用して行います。Styleの中で、Templateプロパティを設定することで、Windowの見た目自体をカスタマイズが可能です。ここでは、下記のように画面上部にアプリケーション名と２つのボタンを持ったWindowを定義するStyleのXAMLを示します。</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- Windowの共通の見た目のカスタマイズ --&gt;
&lt;Style x:Key=&quot;DefaultWindowStyle&quot; TargetType=&quot;Window&quot;&gt;
    &lt;!-- Templateを差し替えて見た目をごっそり差し替える --&gt;
    &lt;Setter Property=&quot;Template&quot;&gt;
        &lt;Setter.Value&gt;
            &lt;ControlTemplate TargetType=&quot;Window&quot;&gt;
                &lt;Grid Margin=&quot;5&quot;&gt;
                    &lt;Grid.RowDefinitions&gt;
                        &lt;RowDefinition Height=&quot;Auto&quot;/&gt;
                        &lt;RowDefinition Height=&quot;*&quot;/&gt;
                    &lt;/Grid.RowDefinitions&gt;
                    &lt;!-- ヘッダー部 --&gt;
                    &lt;Grid Grid.Row=&quot;0&quot;&gt;
                        &lt;Grid.Background&gt;
                            &lt;LinearGradientBrush EndPoint=&quot;1,0.5&quot; StartPoint=&quot;0,0.5&quot;&gt;
                                &lt;GradientStop Color=&quot;#FF896CFF&quot; Offset=&quot;0&quot; /&gt;
                                &lt;GradientStop Color=&quot;#FF210096&quot; Offset=&quot;1&quot; /&gt;
                            &lt;/LinearGradientBrush&gt;
                        &lt;/Grid.Background&gt;
                        &lt;!-- アプリケーションのタイトルと --&gt;
                        &lt;TextBlock 
                            Text=&quot;Sample Application&quot; 
                            Foreground=&quot;White&quot; 
                            FontWeight=&quot;Bold&quot; 
                            FontSize=&quot;24&quot; 
                            Margin=&quot;5&quot;/&gt;
                        &lt;!-- 共通で使用するボタンを置く --&gt;
                        &lt;StackPanel Orientation=&quot;Horizontal&quot; HorizontalAlignment=&quot;Right&quot; VerticalAlignment=&quot;Bottom&quot;&gt;
                            &lt;Button MinWidth=&quot;50&quot; Content=&quot;Sample1&quot; Margin=&quot;2.5&quot;/&gt;
                            &lt;Button MinWidth=&quot;50&quot; Content=&quot;Sample&quot; Margin=&quot;2.5&quot;/&gt;
                        &lt;/StackPanel&gt;
                    &lt;/Grid&gt;
                    &lt;!-- コンテンツ部分 --&gt;
                    &lt;Border Grid.Row=&quot;1&quot; Background=&quot;{TemplateBinding Background}&quot;&gt;
                        &lt;ContentPresenter /&gt;
                    &lt;/Border&gt;
                &lt;/Grid&gt;
            &lt;/ControlTemplate&gt;
        &lt;/Setter.Value&gt;
    &lt;/Setter&gt;
&lt;/Style&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__comment">&lt;!--&nbsp;Windowの共通の見た目のカスタマイズ&nbsp;--&gt;</span>&nbsp;
<span class="xaml__tag_start">&lt;Style</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;DefaultWindowStyle&quot;</span>&nbsp;<span class="xaml__attr_name">TargetType</span>=<span class="xaml__attr_value">&quot;Window&quot;</span><span class="xaml__tag_start">&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;!--&nbsp;<span class="css__element">Template</span>を差し替えて見た目をごっそり差し替える&nbsp;--&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Setter</span>&nbsp;<span class="css__element">Property</span>=&quot;<span class="css__element">Template</span>&quot;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Setter</span><span class="css__class">.Value</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">ControlTemplate</span>&nbsp;<span class="css__element">TargetType</span>=&quot;<span class="css__element">Window</span>&quot;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Grid</span>&nbsp;<span class="css__element">Margin</span>=&quot;<span class="css__element">5</span>&quot;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Grid</span><span class="css__class">.RowDefinitions</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">RowDefinition</span>&nbsp;<span class="css__element">Height</span>=&quot;<span class="css__element">Auto</span>&quot;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">RowDefinition</span>&nbsp;<span class="css__element">Height</span>=&quot;*&quot;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/<span class="css__element">Grid</span><span class="css__class">.RowDefinitions</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;!--&nbsp;ヘッダー部&nbsp;--&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Grid</span>&nbsp;<span class="css__element">Grid</span><span class="css__class">.Row</span>=&quot;<span class="css__element">0</span>&quot;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Grid</span><span class="css__class">.Background</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">LinearGradientBrush</span>&nbsp;<span class="css__element">EndPoint</span>=&quot;<span class="css__element">1</span>,<span class="css__element">0</span><span class="css__class">.5</span>&quot;&nbsp;<span class="css__element">StartPoint</span>=&quot;<span class="css__element">0</span>,<span class="css__element">0</span><span class="css__class">.5</span>&quot;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">GradientStop</span>&nbsp;<span class="css__element">Color</span>=&quot;<span class="css__id">#FF896CFF</span>&quot;&nbsp;<span class="css__element">Offset</span>=&quot;<span class="css__element">0</span>&quot;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">GradientStop</span>&nbsp;<span class="css__element">Color</span>=&quot;<span class="css__id">#FF210096</span>&quot;&nbsp;<span class="css__element">Offset</span>=&quot;<span class="css__element">1</span>&quot;&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/<span class="css__element">LinearGradientBrush</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/<span class="css__element">Grid</span><span class="css__class">.Background</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;!--&nbsp;アプリケーションのタイトルと&nbsp;--&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">TextBlock</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__element">Text</span>=&quot;<span class="css__element">Sample</span>&nbsp;<span class="css__element">Application</span>&quot;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__element">Foreground</span>=&quot;<span class="css__element">White</span>&quot;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__element">FontWeight</span>=&quot;<span class="css__element">Bold</span>&quot;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__element">FontSize</span>=&quot;<span class="css__element">24</span>&quot;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__element">Margin</span>=&quot;<span class="css__element">5</span>&quot;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;!--&nbsp;共通で使用するボタンを置く&nbsp;--&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">StackPanel</span>&nbsp;<span class="css__element">Orientation</span>=&quot;<span class="css__element">Horizontal</span>&quot;&nbsp;<span class="css__element">HorizontalAlignment</span>=&quot;<span class="css__element">Right</span>&quot;&nbsp;<span class="css__element">VerticalAlignment</span>=&quot;<span class="css__element">Bottom</span>&quot;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Button</span>&nbsp;<span class="css__element">MinWidth</span>=&quot;<span class="css__element">50</span>&quot;&nbsp;<span class="css__element">Content</span>=&quot;<span class="css__element">Sample1</span>&quot;&nbsp;<span class="css__element">Margin</span>=&quot;<span class="css__element">2</span><span class="css__class">.5</span>&quot;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Button</span>&nbsp;<span class="css__element">MinWidth</span>=&quot;<span class="css__element">50</span>&quot;&nbsp;<span class="css__element">Content</span>=&quot;<span class="css__element">Sample</span>&quot;&nbsp;<span class="css__element">Margin</span>=&quot;<span class="css__element">2</span><span class="css__class">.5</span>&quot;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/<span class="css__element">StackPanel</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/<span class="css__element">Grid</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;!--&nbsp;コンテンツ部分&nbsp;--&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">Border</span>&nbsp;<span class="css__element">Grid</span><span class="css__class">.Row</span>=&quot;<span class="css__element">1</span>&quot;&nbsp;<span class="css__element">Background</span>=&quot;{TemplateBinding&nbsp;Background}&quot;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;<span class="css__element">ContentPresenter</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/<span class="css__element">Border</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/<span class="css__element">Grid</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/<span class="css__element">ControlTemplate</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/<span class="css__element">Setter</span><span class="css__class">.Value</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/<span class="css__element">Setter</span>&gt;&nbsp;
<span class="xaml__tag_end">&lt;/Style&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;このStyleをWindowに適用します。MainWindow.xamlのWindowタグに下記のようなStyle属性を追加します。</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">Style=&quot;{Binding Source={StaticResource DefaultWindowStyle}}&quot;</pre>
<div class="preview">
<pre class="js">Style=<span class="js__string">&quot;{Binding&nbsp;Source={StaticResource&nbsp;DefaultWindowStyle}}&quot;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;この状態で実行すると、下記のようなヘッダーを持ったWindowが表示されます。このStyleをWindowに設定することで共通の見た目をWindowに定義出来ます。</div>
<div class="endscriptcode"><img src="46977-ws000018.jpg" alt="" width="522" height="91"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">これで、Windowに見た目の共通化が出来ました。</div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode">共通のStyleで定義したボタンの動作のカスタマイズ</h1>
<p>次に、先ほど作成したStyle内で定義している2つのボタンを押したときの挙動をカスタマイズする方法について説明します。基本的にStyle内で定義されたボタンなどのイベントハンドラは、Styleを適用した画面では取得することが困難です。そのため、MVVMパターンを使用してWindowに対してViewModelを定義し、そのViewModelからStyle内で定義したButtonにBindingで紐づけを行います。</p>
<p>まず、Buttonを表すViewModelを定義します。また、このサンプルではReactivePropertyを使用してViewModelを作成しています。ReactivePropertyについては下記のサイトを参照してください。</p>
<ul>
<li><a href="http://reactiveproperty.codeplex.com/">ReactiveProperty - MVVM Extensions for Rx</a>
</li></ul>
&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// 画面に表示するボタンを表す
/// &lt;/summary&gt;
public class ButtonViewModel
{
    /// &lt;summary&gt;
    /// ボタンに表示するテキスト
    /// &lt;/summary&gt;
    public ReactiveProperty&lt;string&gt; Label { get; private set; }
    /// &lt;summary&gt;
    /// ボタンが押された時に実行するコマンド
    /// &lt;/summary&gt;
    public ReactiveCommand Command { get; private set; }

    public ButtonViewModel(ReactiveProperty&lt;string&gt; label = null, ReactiveCommand command = null)
    {
        this.Label = label ?? new ReactiveProperty&lt;string&gt;();
        this.Command = command ?? new ReactiveCommand();
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;画面に表示するボタンを表す</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ButtonViewModel&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;ボタンに表示するテキスト</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ReactiveProperty&lt;<span class="cs__keyword">string</span>&gt;&nbsp;Label&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;ボタンが押された時に実行するコマンド</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ReactiveCommand&nbsp;Command&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ButtonViewModel(ReactiveProperty&lt;<span class="cs__keyword">string</span>&gt;&nbsp;label&nbsp;=&nbsp;<span class="cs__keyword">null</span>,&nbsp;ReactiveCommand&nbsp;command&nbsp;=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Label&nbsp;=&nbsp;label&nbsp;??&nbsp;<span class="cs__keyword">new</span>&nbsp;ReactiveProperty&lt;<span class="cs__keyword">string</span>&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Command&nbsp;=&nbsp;command&nbsp;??&nbsp;<span class="cs__keyword">new</span>&nbsp;ReactiveCommand();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">コメント内にあるように、ButtonのテキストとButtonが押された時の処理を対応するCommandを定義しています。次に、このButtonViewModelを2つもつWindowViewModelBaseクラスを作成します。このクラスで、Style内で定義したButtonに対して公開するButtonViewModelを定義しておきます。</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// DefaultWindowStyleを適用したWindowのViewModelの基本クラス。
/// &lt;/summary&gt;
public abstract class WindowViewModelBase
{
    /// &lt;summary&gt;
    /// 左側のボタン
    /// &lt;/summary&gt;
    public ButtonViewModel CommonAButton { get; set; }
    /// &lt;summary&gt;
    /// 右側のボタン
    /// &lt;/summary&gt;
    public ButtonViewModel CommonBButton { get; set; }

    protected WindowViewModelBase(ButtonViewModel a = null, ButtonViewModel b = null)
    {
        this.CommonAButton = a ?? new ButtonViewModel();
        this.CommonBButton = b ?? new ButtonViewModel();
    }

}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;DefaultWindowStyleを適用したWindowのViewModelの基本クラス。</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">abstract</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;WindowViewModelBase&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;左側のボタン</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ButtonViewModel&nbsp;CommonAButton&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;右側のボタン</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ButtonViewModel&nbsp;CommonBButton&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;WindowViewModelBase(ButtonViewModel&nbsp;a&nbsp;=&nbsp;<span class="cs__keyword">null</span>,&nbsp;ButtonViewModel&nbsp;b&nbsp;=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.CommonAButton&nbsp;=&nbsp;a&nbsp;??&nbsp;<span class="cs__keyword">new</span>&nbsp;ButtonViewModel();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.CommonBButton&nbsp;=&nbsp;b&nbsp;??&nbsp;<span class="cs__keyword">new</span>&nbsp;ButtonViewModel();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">次に、このWindowViewModelBaseの定義にあうようにStyle内のButtonに対してBindingを設定します。Buttonの部分だけ抜粋したXAMLを下記に示します。</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Button MinWidth=&quot;50&quot; Content=&quot;{Binding CommonAButton.Label.Value}&quot; Command=&quot;{Binding CommonAButton.Command}&quot; Margin=&quot;2.5&quot;/&gt;
&lt;Button MinWidth=&quot;50&quot; Content=&quot;{Binding CommonBButton.Label.Value}&quot; Command=&quot;{Binding CommonBButton.Command}&quot; Margin=&quot;2.5&quot;/&gt;
</pre>
<div class="preview">
<pre class="js">&lt;Button&nbsp;MinWidth=<span class="js__string">&quot;50&quot;</span>&nbsp;Content=<span class="js__string">&quot;{Binding&nbsp;CommonAButton.Label.Value}&quot;</span>&nbsp;Command=<span class="js__string">&quot;{Binding&nbsp;CommonAButton.Command}&quot;</span>&nbsp;Margin=<span class="js__string">&quot;2.5&quot;</span>/&gt;&nbsp;
&lt;Button&nbsp;MinWidth=<span class="js__string">&quot;50&quot;</span>&nbsp;Content=<span class="js__string">&quot;{Binding&nbsp;CommonBButton.Label.Value}&quot;</span>&nbsp;Command=<span class="js__string">&quot;{Binding&nbsp;CommonBButton.Command}&quot;</span>&nbsp;Margin=<span class="js__string">&quot;2.5&quot;</span>/&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">そして、個々の画面に対応するViewModelでは、上記のWindowViewModelBaseを継承して作りこみを行います。コード例を下記に示します。</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// MainWindow.xamlに対応するViewModel
/// &lt;/summary&gt;
public class MainWindowViewModel : WindowViewModelBase
{
    /// &lt;summary&gt;
    /// 画面内に表示するテキスト。ヘッダーの左側のボタンが押された時に変更される
    /// &lt;/summary&gt;
    public ReactiveProperty&lt;string&gt; AText { get; private set; }
    /// &lt;summary&gt;
    /// 画面内に表示するテキスト。ヘッダーの右側のボタンが押された時に変更される
    /// &lt;/summary&gt;
    public ReactiveProperty&lt;string&gt; BText { get; private set; }

    public MainWindowViewModel()
        : base()
    {
        // プロパティの初期化
        this.AText = new ReactiveProperty&lt;string&gt;(&quot;A count : 0&quot;);
        this.BText = new ReactiveProperty&lt;string&gt;(&quot;B count : 0&quot;);

        // 共通部分にあるボタンのテキストを指定する
        this.CommonAButton.Label.Value = &quot;Main A&quot;;
        this.CommonBButton.Label.Value = &quot;Main B&quot;;

        // 共通部分にあるボタンを押したときの処理を定義
        int aCount = 0;
        this.CommonAButton.Command.Subscribe(_ =&gt;
            this.AText.Value = &quot;A count : &quot; &#43; &#43;&#43;aCount);
        int bCount = 0;
        this.CommonBButton.Command.Subscribe(_ =&gt;
            this.BText.Value = &quot;B count : &quot; &#43; &#43;&#43;bCount);
    }
}
</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;MainWindow.xamlに対応するViewModel</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
public&nbsp;class&nbsp;MainWindowViewModel&nbsp;:&nbsp;WindowViewModelBase&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;画面内に表示するテキスト。ヘッダーの左側のボタンが押された時に変更される</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ReactiveProperty&lt;string&gt;&nbsp;AText&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;private&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;画面内に表示するテキスト。ヘッダーの右側のボタンが押された時に変更される</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ReactiveProperty&lt;string&gt;&nbsp;BText&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;private&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;MainWindowViewModel()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;base()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;プロパティの初期化</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.AText&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ReactiveProperty&lt;string&gt;(<span class="js__string">&quot;A&nbsp;count&nbsp;:&nbsp;0&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.BText&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ReactiveProperty&lt;string&gt;(<span class="js__string">&quot;B&nbsp;count&nbsp;:&nbsp;0&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;共通部分にあるボタンのテキストを指定する</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.CommonAButton.Label.Value&nbsp;=&nbsp;<span class="js__string">&quot;Main&nbsp;A&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.CommonBButton.Label.Value&nbsp;=&nbsp;<span class="js__string">&quot;Main&nbsp;B&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;共通部分にあるボタンを押したときの処理を定義</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;aCount&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.CommonAButton.Command.Subscribe(_&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.AText.Value&nbsp;=&nbsp;<span class="js__string">&quot;A&nbsp;count&nbsp;:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;&#43;&#43;aCount);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;bCount&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.CommonBButton.Command.Subscribe(_&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.BText.Value&nbsp;=&nbsp;<span class="js__string">&quot;B&nbsp;count&nbsp;:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;&#43;&#43;bCount);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">このような形でViewModelを定義することで、DefaultWindowStyleを適用したWindowに対して効率よく動作をカスタマイズすることができます。下図は、DefaultWindowStyleを適用した2つのWindowの実行例です。どちらにも、WindowViewModelBaseを継承したViewModelをDataContextに指定しています。</div>
<div class="endscriptcode"><img src="46979-ws000019.jpg" alt="" width="682" height="429"></div>
</div>
</div>
</div>
<p></p>
<h1>まとめ</h1>
<p>このようにWPFでは、Windowの継承を行わずに見た目をカスタマイズすることが出来ます。そもそもWPFにおいて見た目のカスタマイズを行うという要件に対して継承で対処するというのは一般的ではありません。このようにTemplateを差し替えるか、ContentTemplate, ItemTemplateなどの各種テンプレートを使用するのが一般的です。</p>
<p># 他にいいやり方がある場合は教えてください</p>
