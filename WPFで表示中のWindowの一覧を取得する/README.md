# WPFで表示中のWindowの一覧を取得する
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- WPF Basics
## Updated
- 05/29/2013
## Description

<h1>サンプルプログラムの概要</h1>
<p>このサンプルプログラムでは、Windows Presentation FoundationのApplicationクラスにあるWindowsプロパティを使用して表示中のWindowを取得する方法を示しています。WPFでは、このように組み込みのクラスにWindowを管理する機能があるため、自分で表示中のWindowの管理機能を1からつくる必要がありません。</p>
<h1>サンプルプログラムの動作</h1>
<p>このサンプルプログラムは実行すると、以下のように2つのボタンをもったWindowが表示されます。</p>
<p><img id="82834" src="82834-ws000000.jpg" alt="" width="228" height="148"></p>
<p>画面上部のNew windowボタンをクリックすると、タイトルに現在時刻を表示したウィンドウが表示されます。</p>
<p><img id="82835" src="82835-ws000001.jpg" alt="" width="370" height="249"></p>
<p>いくつかのウィンドウを表示した状態で画面下部のShow window listボタンをクリックするとApplicationクラスのWindowsプロパティを使って表示中のWindowを列挙してタイトルのリストをメッセージボックスに表示します。</p>
<p><img id="82836" src="82836-ws000002.jpg" alt="" width="341" height="256"></p>
<h1>サンプルプログラムのポイント</h1>
<p>このサンプルプログラムのポイントは、MainWindow.xaml.csのShowWindowListButton_Clickメソッド内です。このメソッド内でApplicationクラスのWindowsプロパティを使用しています。該当箇所のコードを以下に抜粋して示します。</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;表示中のWindowのタイトルをメッセージボックスに表示します。</span>&nbsp;
var&nbsp;windowTitles&nbsp;=&nbsp;Application&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Current&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Windows&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Cast&lt;Window&gt;()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Aggregate(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(sb,&nbsp;w)&nbsp;=&gt;&nbsp;sb.AppendLine(w.Title))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.ToString();&nbsp;
MessageBox.Show(windowTitles);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Applicationクラスのインスタンスは、Currentプロパティを経由して取得できます。そしてWindowsプロパティを使用してWindowのコレクションを取得しています。今回のサンプルプログラムでは、Aggregateメソッドを使ってWindowのTitleプロパティを収集しているので、Castメソッドを使いLINQのメソッドチェーンにつなげています。</div>
<p></p>
<h1>参考情報</h1>
<p>このサンプルプログラム内で使用している代表的なメソッドやプロパティの詳細はMSDNの以下のページを参照してください。</p>
<ul>
<li>Application.Windowsプロパティ<br>
<a href="http://msdn.microsoft.com/ja-jp/library/vstudio/system.windows.application.windows.aspx">http://msdn.microsoft.com/ja-jp/library/vstudio/system.windows.application.windows.aspx</a>
</li><li>Enumerable.Aggregateメソッド<br>
<a href="http://msdn.microsoft.com/ja-jp/library/system.linq.enumerable.aggregate(v=vs.100).aspx">http://msdn.microsoft.com/ja-jp/library/system.linq.enumerable.aggregate(v=vs.100).aspx</a>
</li><li>Enumerable.Castメソッド<br>
<a href="http://msdn.microsoft.com/ja-jp/library/bb341406(v=vs.100).aspx">http://msdn.microsoft.com/ja-jp/library/bb341406(v=vs.100).aspx</a>
</li></ul>
