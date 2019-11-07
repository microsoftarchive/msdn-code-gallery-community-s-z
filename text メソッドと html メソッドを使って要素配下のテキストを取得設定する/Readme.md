# text メソッドと html メソッドを使って要素配下のテキストを取得/設定する
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- jQuery 1.4.4
## Topics
- 逆引きサンプル コード
- jQuery
## Updated
- 02/06/2011
## Description

<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#yamada" target="_blank">
有限会社 WINGS プロジェクト 山田 祥寛</a></p>
<p>動作確認環境: Visual Studio 2010、jQuery 1.4.4</p>
<hr>
<p>要素配下のテキストを取得/設定するためのメソッドとして、jQuery には text、html という 2 つのメソッドが用意されています。これらのメソッドは一見&#20284;ていますが、いくつかの違いがあります。以下では、具体的なサンプルを通じて、両メソッドの用法と共に、両者の挙動の違いを確認します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">HTML</div>
<div class="pluginEditHolderLink">Edit Script</div>
<span class="hidden">html</span>
<pre class="hidden">&lt;div id=&quot;article&quot;&gt;
  &lt;p&gt;&lt;a href=&quot;http://www.wings.msn.to/&quot;&gt;弊社サポートサイト&lt;/a&gt;です。&lt;/p&gt;
  &lt;p&gt;&lt;a href=&quot;http://www.web-deli.com/&quot;&gt;WebDeli&lt;/a&gt;もご覧ください。&lt;/p&gt;
&lt;/div&gt;

&lt;script src=&quot;../Scripts/jquery-1.4.4.min.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;
&lt;script type=&quot;text/javascript&quot;&gt;
 // id 属性が &quot;article&quot; である要素の配下にある &lt;p&gt; 要素のテキストを取得
window.alert('html メソッド：\r' &#43; $('#article p').html());
window.alert('text メソッド：\r' &#43; $('#article p').text());
&lt;/script&gt;</pre>
<pre id="codePreview" class="xml"><span class="xml__tag_start">&lt;div</span>&nbsp;<span class="xml__attr_name">id</span>=<span class="xml__attr_value">&quot;article&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;p</span><span class="xml__tag_start">&gt;</span><span class="xml__tag_start">&lt;a</span>&nbsp;<span class="xml__attr_name">href</span>=<span class="xml__attr_value">&quot;http://www.wings.msn.to/&quot;</span><span class="xml__tag_start">&gt;弊</span>社サポートサイト<span class="xml__tag_end">&lt;/a&gt;</span>です。<span class="xml__tag_end">&lt;/p&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;p</span><span class="xml__tag_start">&gt;</span><span class="xml__tag_start">&lt;a</span>&nbsp;<span class="xml__attr_name">href</span>=<span class="xml__attr_value">&quot;http://www.web-deli.com/&quot;</span><span class="xml__tag_start">&gt;</span>WebDeli<span class="xml__tag_end">&lt;/a&gt;</span>もご覧ください。<span class="xml__tag_end">&lt;/p&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
<span class="xml__tag_start">&lt;script</span>&nbsp;<span class="xml__attr_name">src</span>=<span class="xml__attr_value">&quot;../Scripts/jquery-1.4.4.min.js&quot;</span>&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;text/javascript&quot;</span><span class="xml__tag_start">&gt;</span><span class="xml__tag_end">&lt;/script&gt;</span>&nbsp;
<span class="xml__tag_start">&lt;script</span>&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;text/javascript&quot;</span><span class="xml__tag_start">&gt;</span>&nbsp;
&nbsp;<span class="js__sl_comment">//&nbsp;id&nbsp;属性が&nbsp;&quot;article&quot;&nbsp;である要素の配下にある&nbsp;&lt;p&gt;&nbsp;要素のテキストを取得</span>&nbsp;
window.alert(<span class="js__string">'html&nbsp;メソッド：\r'</span>&nbsp;&#43;&nbsp;$(<span class="js__string">'#article&nbsp;p'</span>).html());&nbsp;
window.alert(<span class="js__string">'text&nbsp;メソッド：\r'</span>&nbsp;&#43;&nbsp;$(<span class="js__string">'#article&nbsp;p'</span>).text());&nbsp;
<span class="xml__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
<p style="margin-left:20px"><img src="16291-arrow.gif" alt="図 3" width="35" height="42"></p>
<p><img src="16292-image001.gif" alt="図 1" width="585" height="446"></p>
<p><img src="16293-image002.gif" alt="図 2" width="585" height="446"></p>
<p style="margin-top:25px">上の結果を見ても分かるように、</p>
<ul style="margin-top:0">
<li>html メソッドでは複数の要素にマッチしても最初の 1 つしか返さないが、text メソッドはすべてのテキストを結合したものを返す </li><li>html メソッドは HTML 文字列を返すが、text メソッドはテキスト部分のみを取得する </li></ul>
<p>などの違いがあります (*)。</p>
<p>*) 本稿では扱っていませんが、その他、text メソッドは HTML/XML 文書を処理できるのに対して、html メソッドでは HTML (XHTML 文書を含む) しか処理できないという違いもあります。<br>
<br>
続いて、html/text メソッドでテキストを設定してみましょう。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">HTML</div>
<div class="pluginEditHolderLink">{#scriptcode_dlg.edit_script}</div>
<span class="hidden">html</span>
<pre class="hidden">&lt;div id=&quot;article&quot;&gt;
  &lt;p&gt;&lt;/p&gt;
  &lt;p&gt;&lt;/p&gt;
&lt;/div&gt;

&lt;script src=&quot;../Scripts/jquery-1.4.4.min.js&quot; type=&quot;text/javascript&quot;&gt;&lt;/script&gt;
&lt;script type=&quot;text/javascript&quot;&gt;
// &lt;p&gt; 要素に対して、それぞれ html、text メソッドで HTML 文字列を設定
$('#article p:first').html('&lt;a href=&quot;http://www.wings.msn.to/&quot;&gt;サポート&lt;/a&gt;');
$('#article p:last').text('&lt;a href=&quot;http://www.wings.msn.to/&quot;&gt;サポート&lt;/a&gt;');
&lt;/script&gt;</pre>
<pre id="codePreview" class="html"><span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;article&quot;</span><span class="html__tag_start">&gt;&nbsp;<br></span>&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/p&gt;</span>&nbsp;<br>&nbsp;&nbsp;<span class="html__tag_start">&lt;p</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/p&gt;</span>&nbsp;<br><span class="html__tag_end">&lt;/div&gt;</span>&nbsp;<br>&nbsp;<br><span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/jquery-1.4.4.min.js&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;<br><span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span><span class="html__tag_start">&gt;</span>&nbsp;<br><span class="js__sl_comment">//&nbsp;&lt;p&gt;&nbsp;要素に対して、それぞれ&nbsp;html、text&nbsp;メソッドで&nbsp;HTML&nbsp;文字列を設定</span>&nbsp;<br>$(<span class="js__string">'#article&nbsp;p:first'</span>).html(<span class="js__string">'&lt;a&nbsp;href=&quot;http://www.wings.msn.to/&quot;&gt;サポート&lt;/a&gt;'</span>);&nbsp;<br>$(<span class="js__string">'#article&nbsp;p:last'</span>).text(<span class="js__string">'&lt;a&nbsp;href=&quot;http://www.wings.msn.to/&quot;&gt;サポート&lt;/a&gt;'</span>);&nbsp;<br><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;<br>&nbsp;<br></pre>
</div>
</div>
<div class="endscriptcode"></div>
<p style="margin-left:20px"><img src="16294-arrow.gif" alt="" width="35" height="42"></p>
<p><img src="16295-image003.gif" alt="" width="336" height="236"></p>
<p>html メソッドが HTML 文字列をそのままセットしているのに対して、text メソッドでは HTML 文字列をエスケープ処理したものをセットしています (その結果、タグがそのまま表示されています)。<br>
<br>
なお、テキストの取得時には text/html メソッドですべての要素を取得するか、最初の要素のみを取得するかという違いがありましたが、設定時にはこうした違いはありません。いずれも合致するすべての要素に対してテキストを設定します。</p>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe"><img title="Code Recipe" src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/asp.net/"><img title="ASP.Net デベロッパーセンター" src="-ff950935.asp_net_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ff363212">逆引きサンプル コード一覧へ</a>
</li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe">
Code Recipe へ</a> </li><li>もっと ASP.Net の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/asp.net">
ASP.Net デベロッパーセンターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
