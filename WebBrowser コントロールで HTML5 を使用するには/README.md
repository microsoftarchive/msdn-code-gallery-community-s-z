# WebBrowser コントロールで HTML5 を使用するには
## License
- Apache License, Version 2.0
## Technologies
- Windows Phone
## Topics
- Windows Phone アプリケーション
- "How to" ラーニング コース
## Updated
- 02/20/2012
## Description

<p style="border:solid 1px #666; padding:10px; width:140px; background-color:#dedede">
サンプル | <a href="http://download.microsoft.com/download/A/1/0/A10EBC63-2398-483C-9F65-5DDA7122B45C/HTML5WebBrowser.zip">
Zip、87.7 KB</a></p>
<p>このサンプルは、手順に沿って、コードをコピーし、ソース コードへ貼り付けることでアプリケーションを作成できます。完成例は、サンプル ファイルの Finish フォルダーに&#26684;納されていますので参考にしてください。</p>
<hr>
<p>ここでは以下の手順で説明します。</p>
<ul>
<li>Video 要素を使用する </li><li>Silverlight と JavaScript の間でやり取りする </li><li>Canvas 要素を使用する </li></ul>
<h2 style="font-size:120%; margin:20px 0px; border-left:7px solid #666666; padding-left:12px">
Video 要素を使用する</h2>
<ol>
<li>Visual Studio で、&quot;Windows Phone アプリケーション&quot; プロジェクト テンプレートを使って &quot;HTML5BrowserFeatures&quot; という名前の新しいプロジェクトを作成します。
</li><li>MainPage.xaml で、browser という名前の WebBrowser コントロールを追加します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__tag_start">&lt;phone</span>:WebBrowser&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;browser&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>MainPage.xaml.cs のコンストラクターで、Loaded イベント ハンドラーを browser に追加します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">public</span>&nbsp;MainPage()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;browser.Loaded&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RoutedEventHandler(browser_Loaded);&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">void</span>&nbsp;browser_Loaded(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>このコンテンツのサポート ファイルの Asset フォルダーから &quot;IsoExtras.cs&quot; と &quot;main.html&quot; を既存のアイテムとして追加します。
</li><li>&quot;main.html&quot; の &quot;ビルド アクション&quot; が &quot;コンテンツ&quot; に設定されていることを確認します。 </li><li>Loaded イベント ハンドラーで、SaveFilesToIsoStore メソッドを呼び出し、&quot;main.html&quot; を渡します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">void</span>&nbsp;browser_Loaded(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IsoExtras.SaveFilesToIsoStore(<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;{&nbsp;<span class="cs__string">&quot;main.html&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;browser.Navigate(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;main.html&quot;</span>,&nbsp;UriKind.Relative));&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>browser を &quot;main.html&quot; に移動します。 </li><li>main.html の main div で、コメント アウトされている video 要素のコメントをはずし、wmv ビデオをソースに設定します。controls も設定してください。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre id="codePreview" class="html"><span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;main&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;the&nbsp;main&nbsp;content&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;video</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;http://media.ch9.ms/ch9/956d/685e3d3f-c2e2-4763-a668-9f020134956d/HAdoodlejump_ch9.wmv&quot;</span>&nbsp;controls&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>プロジェクトを実行します。 </li><li>ローカルの html が読み込まれます。<br>
<img src="49507-604_01.jpg" alt="" width="200" height="333" style="margin:10px 0">
</li><li>video 要素をタップするとビデオが全画面で再生されます。
<p>※Windows Phone Emulator では再生できませんので、Windows Phone デバイスでお試しください</p>
</li></ol>
<h2 style="font-size:120%; margin:20px 0px; border-left:7px solid #666666; padding-left:12px">
Silverlight と JavaScript の間でやり取りする</h2>
<ol>
<li>MainPage.xaml で、browser の IsScriptEnabled を &quot;true&quot; に設定し、ScriptNotify イベント ハンドラーを追加します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre id="codePreview" class="xaml"><span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ContentPanel&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;12,0,12,0&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;phone</span>:WebBrowser&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;browser&quot;</span>&nbsp;<span class="xaml__attr_name">IsScriptEnabled</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__attr_name">ScriptNotify</span>=<span class="xaml__attr_value">&quot;browser_ScriptNotify&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>MainPage.xaml.cs の ScriptNotify イベント ハンドラーで、渡される値を MessageBox で表示します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;browser_ScriptNotify(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;NotifyEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(e.Value);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>main.html で、script タグを追加し、JavaScript の window.external.notify 呼び出しを追加し、&quot;HTML Loaded&quot; (&quot;HTML が読み込まれました&quot; という意味の文字列) を渡します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre id="codePreview" class="html"><span class="html__tag_start">&lt;script</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;window.external.notify(&quot;HTML&nbsp;loaded&quot;);&nbsp;
<span class="html__tag_end">&lt;/script&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>プロジェクトを実行します。 </li><li>JavaScript から渡された文字列が Silverlight のメッセージ ボックスに表示されます。 </li><li>main.html で setBackground という関数を追加します。これは、パラメーターとして色を受け取り、それを背景色に設定します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre id="codePreview" class="html"><span class="html__tag_start">&lt;script</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;window.external.notify(&quot;HTML&nbsp;loaded&quot;);&nbsp;
function&nbsp;setBackground(c)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.body.style.backgroundColor&nbsp;=&nbsp;c;&nbsp;
}&nbsp;
<span class="html__tag_end">&lt;/script&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>MainPage.xaml.cs の ScriptNotify イベント ハンドラーで、渡された文字列が &quot;HTML Loaded&quot; に等しい場合にメッセージを表示するように修正します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;browser_ScriptNotify(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;NotifyEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.Value&nbsp;==&nbsp;<span class="cs__string">&quot;HTML&nbsp;loaded&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
MessageBox.Show(e.Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>Windows Phone のアクセント カラー PhoneAccentBrush の色を取得して、16 進数の文字列に変換します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;browser_ScriptNotify(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;NotifyEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.Value&nbsp;==&nbsp;<span class="cs__string">&quot;HTML&nbsp;loaded&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
MessageBox.Show(e.Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Color&nbsp;c&nbsp;=&nbsp;((SolidColorBrush)Application.Current.Resources[<span class="cs__string">&quot;PhoneAccentBrush&quot;</span>]).Color;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;hex&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;#{0:x2}{1:x2}{2:x2}&quot;</span>,&nbsp;c.R,&nbsp;c.G,&nbsp;c.B);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>InvokeScript 呼び出しで setBackground を呼び出し、16 進数値を渡します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;browser_ScriptNotify(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;NotifyEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.Value&nbsp;==&nbsp;<span class="cs__string">&quot;HTML&nbsp;loaded&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
MessageBox.Show(e.Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Color&nbsp;c&nbsp;=&nbsp;((SolidColorBrush)Application.Current.Resources[<span class="cs__string">&quot;PhoneAccentBrush&quot;</span>]).Color;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;hex&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;#{0:x2}{1:x2}{2:x2}&quot;</span>,&nbsp;c.R,&nbsp;c.G,&nbsp;c.B);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;browser.InvokeScript(<span class="cs__string">&quot;setBackground&quot;</span>,&nbsp;hex);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>プロジェクトを実行します。 </li><li>html 本文の背景色が、選択されている Windows Phone のアクセント カラーに変更されています。<br>
<img src="49508-604_02.gif" alt="" width="200" height="333" style="margin:10px 0">
</li></ol>
<h2 style="font-size:120%; margin:20px 0px; border-left:7px solid #666666; padding-left:12px">
Canvas 要素を使用する</h2>
<ol>
<li>main.html で、video 要素をコメント アウトします。 </li><li>theCanvas という名前の Canvas 要素を追加し、サイズを 300 x 300 に設定します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre id="codePreview" class="html"><span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;main&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;the&nbsp;main&nbsp;content&nbsp;
<span class="html__comment">&lt;!--&lt;video&nbsp;src=&quot;http://media.ch9.ms/ch9/956d/685e3d3f-c2e2-4763-a668-9f020134956d/HAdoodlejump_ch9.wmv&quot;&nbsp;controls&nbsp;/&gt;--&gt;</span>&nbsp;
<span class="html__tag_start">&lt;canvas</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;theCanvas&quot;</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">&quot;300&quot;</span>&nbsp;<span class="html__attr_name">height</span>=<span class="html__attr_value">&quot;300&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/canvas&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>drawSquare メソッドを追加して、Canvas の 2D 描画コンテキストへの参照を保存し、渡される色を fillStyle に設定します。さらに fillRect を呼び出して、50,50 の位置と 100 x 100 のサイズを設定します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre id="codePreview" class="html">&nbsp;<span class="html__tag_start">&lt;script</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;window.external.notify(&quot;HTML&nbsp;loaded&quot;);&nbsp;
&nbsp;
function&nbsp;drawSquare(c)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;canvas&nbsp;=&nbsp;document.getElementById('theCanvas');&nbsp;
var&nbsp;ctx&nbsp;=&nbsp;canvas.getContext('2d');&nbsp;
ctx.fillStyle&nbsp;=&nbsp;c;&nbsp;
ctx.fillRect(50,&nbsp;50,&nbsp;100,&nbsp;100);&nbsp;
}&nbsp;
&nbsp;
function&nbsp;setBackground(c)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.body.style.backgroundColor&nbsp;=&nbsp;c;&nbsp;
}&nbsp;
&nbsp;
<span class="html__tag_end">&lt;/script&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>MainPage.xaml.cs の ScriptNotify イベント ハンドラーで、InvokeScript を変更して drawSquare を呼び出します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre id="codePreview" class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;browser_ScriptNotify(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;NotifyEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.Value&nbsp;==&nbsp;<span class="cs__string">&quot;HTML&nbsp;loaded&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
MessageBox.Show(e.Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Color&nbsp;c&nbsp;=&nbsp;((SolidColorBrush)Application.Current.Resources[<span class="cs__string">&quot;PhoneAccentBrush&quot;</span>]).Color;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;hex&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;#{0:x2}{1:x2}{2:x2}&quot;</span>,&nbsp;c.R,&nbsp;c.G,&nbsp;c.B);&nbsp;
browser.InvokeScript(<span class="cs__string">&quot;drawSquare&quot;</span>,&nbsp;hex);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</li><li>プロジェクトを実行します。 </li><li>Canvas 領域に、Windows Phone のアクセント カラーを使って四角形が描画されます。<br>
<img src="49509-604_03.gif" alt="" width="200" height="333" style="margin:10px 0">
</li></ol>
<p>Windows Phone 上の IE9 が提供する強力なモバイル Web エクスペリエンスを紹介しました。WebBrowser コントロールを使用することで、Web エクスペリエンスを効果的に使用するアプリケーションの開発が可能になります。</p>
<h2 style="font-size:120%; margin:20px 0px; border-left:7px solid #666666; padding-left:12px">
関連ドキュメント</h2>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/microsoft.phone.controls.webbrowser(VS.92).aspx" target="_blank">WebBrowser クラス</a>
</li><li><a href="http://msdn.microsoft.com/ja-jp/library/system.windows.application.resources(VS.95).aspx" target="_blank">Application.Resources プロパティ</a>
</li></ul>
<h2 style="font-size:120%; margin:20px 0px; border-left:7px solid #666666; padding-left:12px">
参考ビデオ</h2>
<ul>
<li><a href="http://msdn.microsoft.com/en-us/hh369944" target="_blank">How Do I: Use HTML5 in the WebBrowser Control in Windows Phone 'Mango'?</a>
</li></ul>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://code.msdn.microsoft.com/ja-jp"><img src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/windowsphone" target="_blank"><img src="-ff950935.winphone_180x70(ja-jp,msdn.10).gif" border="0" alt="Windows Phone デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/windowsphone/hh744643" target="_blank">
Windows Phone アプリケーション開発 &quot;How to&quot; ラーニング コースへ</a> </li><li>もっと&nbsp;Windows Phone の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/windowsphone" target="_blank">
Windows Phone デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
