# Visual Studio でのコードのリファクタリング(関数の抽出）
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2013
## Topics
- Visual Studio
- Visual Studio 2013
## Updated
- 10/27/2014
## Description

<h3>Introduction</h3>
<p>特定の処理を再利用したり、ソースコードの可読性を上げるために関数化することはよくあります。この場合は、Visual Studio のリファクタリングの機能の一つ、メソッドの抽出機能を使うと簡単に関数化を行うことができます。</p>
<p>メソッドを抽出する場合メソッドとして抽出したいロジックの部分を単体で選択し、このリファクタリングの処理を行うと選択した部分だけを切りだして新しい関数として作成するだけでなく、処理が正しく行われるように呼び出し処理も自動的に追加されます。もしかんずうの外で定義されている変数を処理内で使っている場合は引数として定義されて正しく呼び出されるように自動的に処理がなされます。</p>
<p>子の関数の抽出つ昨日は、今回紹介するサンプルのように、UIに依存しない処理だけをビジネスロジックとして抽出することで、コードの再利用性や可読性を高めることができます。</p>
<p>リファクタリングの機能確認のためのサンプルですので、コードは必ずご自身の手で入力することをお勧めします。</p>
<h3>Building the Sample</h3>
<p>本手順を試すには、Visual Studio 2013 Update 3 以降が必要です</p>
<h3>Description</h3>
<p>手順 :</p>
<ol>
<li>Visual Studio を起動します。 </li><li>Visual Studio のメニューの [ファイル]を選択し、[新規作成]、[プロジェクト] の順に選択します。 </li><li>[新しいプロジェクト] ダイアログが表示されたら、左ペインの [Visual C#] とその下の [Windows ストアアプリ]さらにその下の[Windowsアプリ] を選択し、中央ペインの [からのアプリケーション(Windows)]を選び、[OK] ボタンをクリックします。
</li><li>アプリケーションのひな形が生成されたら、ソリューション エクスプローラー上の [ MainPage.xaml ] をダブルクリックし、画面を表示します。 </li><li>以下のコードを実装します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Grid Background=&quot;{ThemeResource ApplicationPageBackgroundThemeBrush}&quot;
    PointerReleased=&quot;Grid_PointerReleased&quot;&gt;
    &lt;TextBlock x:Name=&quot;txtResult&quot; HorizontalAlignment=&quot;Center&quot; TextWrapping=&quot;Wrap&quot; 
        VerticalAlignment=&quot;Bottom&quot; FontSize=&quot;100&quot;/&gt;
    &lt;TextBlock HorizontalAlignment=&quot;Center&quot; TextWrapping=&quot;Wrap&quot; VerticalAlignment=&quot;Top&quot; 
        FontSize=&quot;48&quot; Text=&quot;画面の中心をクリック/タッチしてください&quot;/&gt;
&lt;/Grid&gt;
</pre>
<div class="preview">
<pre class="js">&lt;Grid&nbsp;Background=<span class="js__string">&quot;{ThemeResource&nbsp;ApplicationPageBackgroundThemeBrush}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PointerReleased=<span class="js__string">&quot;Grid_PointerReleased&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock&nbsp;x:Name=<span class="js__string">&quot;txtResult&quot;</span>&nbsp;HorizontalAlignment=<span class="js__string">&quot;Center&quot;</span>&nbsp;TextWrapping=<span class="js__string">&quot;Wrap&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VerticalAlignment=<span class="js__string">&quot;Bottom&quot;</span>&nbsp;FontSize=<span class="js__string">&quot;100&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextBlock&nbsp;HorizontalAlignment=<span class="js__string">&quot;Center&quot;</span>&nbsp;TextWrapping=<span class="js__string">&quot;Wrap&quot;</span>&nbsp;VerticalAlignment=<span class="js__string">&quot;Top&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FontSize=<span class="js__string">&quot;48&quot;</span>&nbsp;Text=<span class="js__string">&quot;画面の中心をクリック/タッチしてください&quot;</span>/&gt;&nbsp;
&lt;/Grid&gt;&nbsp;</pre>
</div>
</div>
</div>
</li><li>[CTRL-S] を押して保存します。 </li><li>ソリューション エクスプローラー上の [ MainPage.xaml ] を右クリックし[コードの表示]で、MainPage.xaml.cs を表示します。
</li><li>以下のメソッドを追加します。
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void Grid_PointerReleased(object sender, PointerRoutedEventArgs e)
{
	//タッチ位置の取得
	Point pos = e.GetCurrentPoint(this).Position;
	pos.X -= this.ActualWidth / 2;
	pos.Y -= this.ActualHeight / 2;
	
	//距離計算とメッセージ作成
	//距離計算
	int length = (int)(Math.Sqrt(pos.X * pos.X &#43; pos.Y &#43; pos.Y));
	//判定とメッセージ
	String message = String.Format(&quot;あと {0} くらい&quot;, length);
	if (length &lt; 10)
	    message = &quot;Bingo !&quot;;
	
	//メッセージ表示
	txtResult.Text = message;
}</pre>
<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;Grid_PointerReleased(object&nbsp;sender,&nbsp;PointerRoutedEventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//タッチ位置の取得</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Point&nbsp;pos&nbsp;=&nbsp;e.GetCurrentPoint(<span class="js__operator">this</span>).Position;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pos.X&nbsp;-=&nbsp;<span class="js__operator">this</span>.ActualWidth&nbsp;/&nbsp;<span class="js__num">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pos.Y&nbsp;-=&nbsp;<span class="js__operator">this</span>.ActualHeight&nbsp;/&nbsp;<span class="js__num">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//距離計算とメッセージ作成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//距離計算</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;length&nbsp;=&nbsp;(int)(<span class="js__object">Math</span>.Sqrt(pos.X&nbsp;*&nbsp;pos.X&nbsp;&#43;&nbsp;pos.Y&nbsp;&#43;&nbsp;pos.Y));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//判定とメッセージ</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">String</span>&nbsp;message&nbsp;=&nbsp;<span class="js__object">String</span>.Format(<span class="js__string">&quot;あと&nbsp;{0}&nbsp;くらい&quot;</span>,&nbsp;length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(length&nbsp;&lt;&nbsp;<span class="js__num">10</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message&nbsp;=&nbsp;<span class="js__string">&quot;Bingo&nbsp;!&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//メッセージ表示</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;txtResult.Text&nbsp;=&nbsp;message;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
</li><li>//距離計算から6行分を選択して、右クリックでコンテキストメニューを開き、[リファクター] [メソッドの抽出] でこの部分を単体メソッドに切り離します。<br>
<img id="127668" src="127668-refactoring1.png" alt="" width="842" height="418">
</li><li>ダイアログが表示されたら[CalcLength]と関数名をつけてOKを押します。処理部分が関数化され、合わせて関数の呼び出し処理が追加されています。<br>
<img id="127667" src="127667-refactoring2.png" alt=""><br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void Grid_PointerReleased(object sender, PointerRoutedEventArgs e)
{
	//タッチ位置の取得
	Point pos = e.GetCurrentPoint(this).Position;
	pos.X -= this.ActualWidth / 2;
	pos.Y -= this.ActualHeight / 2;
	
	//距離計算とメッセージ作成
	String message = CalcLength(ref pos);
	
	//メッセージ表示
	txtResult.Text = message;
}
	
private static string CalcLength(ref Point pos)
{
	//距離計算
	int length = (int)(Math.Sqrt(pos.X * pos.X &#43; pos.Y &#43; pos.Y));
	//判定とメッセージ
	String message = String.Format(&quot;あと {0} くらい&quot;, length);
	if (length &lt; 10)
	    message = &quot;Bingo !&quot;;
	return message;
}</pre>
<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;Grid_PointerReleased(object&nbsp;sender,&nbsp;PointerRoutedEventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//タッチ位置の取得</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Point&nbsp;pos&nbsp;=&nbsp;e.GetCurrentPoint(<span class="js__operator">this</span>).Position;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pos.X&nbsp;-=&nbsp;<span class="js__operator">this</span>.ActualWidth&nbsp;/&nbsp;<span class="js__num">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pos.Y&nbsp;-=&nbsp;<span class="js__operator">this</span>.ActualHeight&nbsp;/&nbsp;<span class="js__num">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//距離計算とメッセージ作成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">String</span>&nbsp;message&nbsp;=&nbsp;CalcLength(ref&nbsp;pos);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//メッセージ表示</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;txtResult.Text&nbsp;=&nbsp;message;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
private&nbsp;static&nbsp;string&nbsp;CalcLength(ref&nbsp;Point&nbsp;pos)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//距離計算</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;length&nbsp;=&nbsp;(int)(<span class="js__object">Math</span>.Sqrt(pos.X&nbsp;*&nbsp;pos.X&nbsp;&#43;&nbsp;pos.Y&nbsp;&#43;&nbsp;pos.Y));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//判定とメッセージ</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">String</span>&nbsp;message&nbsp;=&nbsp;<span class="js__object">String</span>.Format(<span class="js__string">&quot;あと&nbsp;{0}&nbsp;くらい&quot;</span>,&nbsp;length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(length&nbsp;&lt;&nbsp;<span class="js__num">10</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message&nbsp;=&nbsp;<span class="js__string">&quot;Bingo&nbsp;!&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;message;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
</li><li>[F5]キーを押して実行します。中心を狙って画面をタップしてみてください。 </li></ol>
<h3>More Information</h3>
