# WindowsフォームにおけるIDataErrorInfoの実装サンプル
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- Windows Forms
## Topics
- C#
- Data Binding
- User Interface
- Windows Forms
- Windows フォーム
- User Experience
## Updated
- 04/15/2015
## Description

<h1>はじめに</h1>
<p>WindowsフォームにIDataErrorInfoを実装した例を示します。<br>
例えば、WindowsフォームにDataTableをバインドさせることが多いと思いますが、そもそもDataTableというのは非接続型のデータアクセスを実現するためにデザインされています。よって、必ずしも画面に直接バインドするオブジェクトとして適しているわけではありません。本来、非接続型でデータベースなどとデータのやり取りを行う部分のみに使うのが望ましいと思います。<br>
以上を理解していれば、DataTableを直接画面にバインドした際に不都合が出るのであれば、DataTableとは別に、画面にバインドする専用のオブジェクトを用意する発想に至るでしょう。<br>
ここでは、その例を示します。&nbsp;</p>
<p>&nbsp;</p>
<h1>本サンプルの環境</h1>
<p>本サンプルはVisual Studio 2013、C#、.NET Framework 4.5 で作成していますが、特殊なコードは書いていませんので、おそらく.NET Framework 3.0以降のC#で動作するでしょう。、</p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">説明</span></p>
<p>「はじめに」ではDataTableを例に出しましたが、ここでは簡単にするためにDataTableの代わりにModelクラスを用意します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;データモデルクラス</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Model&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;String&nbsp;A&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;B&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">decimal</span>&nbsp;C&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>このModelクラスのバインド用クラスとして、UIObjectクラスを用意します。Modelクラスのプロパティを内包しています。画面上からは一旦、どのような値でも受け取れるように、それらすべてのプロパティはstring型になっています。<br>
また、HasErrorプロパティを追加しています。このプロパティは全体でエラーがあるかどうかを表します。同時に、HasErrorプロパティに変化があった際に発生するイベントも定義しています。 これを利用し、画面側ではエラーがある限り保存ボタンがグレーアウト（不活性化）し、保存ボタンが押せないように制御しています。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;画面にバインドするクラス</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;UIObject&nbsp;:&nbsp;IDataErrorInfo&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//エラー情報を保持</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">string</span>&gt;&nbsp;_errors&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">string</span>&gt;();<span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#region</span>&nbsp;プロパティ&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;_A;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;A&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_A;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_A&nbsp;==&nbsp;<span class="cs__keyword">value</span>)&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_A&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ValidateA();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;_B;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;B&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_B;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_B&nbsp;==&nbsp;<span class="cs__keyword">value</span>)&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_B&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ValidateB();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;_C;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;C&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_C;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_C&nbsp;==&nbsp;<span class="cs__keyword">value</span>)&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_C&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ValidateC();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;エラーの有無&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;HasError&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_errors.Count&nbsp;!=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span><span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#region</span>&nbsp;イベント&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">event</span>&nbsp;Action&lt;<span class="cs__keyword">bool</span>&gt;&nbsp;HasErrorChanged;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnHasErrorChanged(<span class="cs__keyword">bool</span>&nbsp;hasError)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(HasErrorChanged&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HasErrorChanged(hasError);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;　　　・&nbsp;
&nbsp;&nbsp;&nbsp;　　　・&nbsp;
&nbsp;&nbsp;&nbsp;　　　・&nbsp;
&nbsp;&nbsp;&nbsp;　　（略）&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;続いて画面のコードを見ていきましょう。画面はForm1クラスになります。言い忘れましたが、本サンプルは、このForm1クラス、、既出のModelクラス、UIObjectクラスの３つから成っています。<br>
話を戻します。本サンプルでは、新規登録画面を想定しています。よって、以下に示すように全てのプロパティに空白をセットしています。この画面がもし変更画面であれば、空白の代わりに変更する前の値をセットすることになります。<br>
また、以下のようにIDataErrorInfoはErrorProviderと組み合わせると、エラーのある項目の横に自動的に赤マークを表示したり、エラー内容をToolTipで表示するようになります。ErrorProviderはツールボックスから画面にドラッグ＆どラップすることが多いと思いますが、以下のようにコードで設定することももちろんできます。その場合、ContainerControlプロパティとDataSourceプロパティを適切に設定する必要があります。</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ErrorProvider&nbsp;ep&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ErrorProvider();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BindingSource&nbsp;bs&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BindingSource();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Model&nbsp;model&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Model();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UIObject&nbsp;uiobj&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UIObject();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;コンストラクタ</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ep.ContainerControl&nbsp;=&nbsp;<span class="cs__keyword">this</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ep.DataSource&nbsp;=&nbsp;bs;&nbsp;
　　　　　・&nbsp;
　　　　　・&nbsp;
　　　　　（略）&nbsp;
　　　　　・&nbsp;
　　　　　・&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//初期値設定</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uiobj.A&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uiobj.B&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uiobj.C&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;次に、起動直後の画面を表示します。</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="136484" src="136484-%e5%88%9d%e6%9c%9f%e7%94%bb%e9%9d%a2.jpg" alt="" width="436" height="345"></div>
&nbsp;</div>
<p>&nbsp;</p>
<p>エラーがある場合は次のようになります。</p>
<p>&nbsp;</p>
<p><img id="136485" src="136485-%e3%82%a8%e3%83%a9%e3%83%bc%e5%8b%95%e4%bd%9c%e4%b8%ad.jpg" alt="" width="436" height="345"></p>
<p>&nbsp;</p>
<p>全てのテキストボックスはstring型にバインドしているおかげで、エラーがあっても各テキストボックスを自由に編集できます。もし、上のBがint型にバインドしている場合、エラーがある場合は既定ではBの入力から動けなくなります。FormのAutoValidateプロパティをEnableAllowFocusChangeにすればエラーがあってもその項目から離れることができるようになりますが、内部的にははじかれていますので、BプロパティのSetterのコードが実行されません。</p>
<p>本サンプルを動作させてみればわかりますが、入力する度にリアルタイムでエラーチェックが行われ、全てエラーが無くなるまで保存ボタンはEnableがfalseになり押せません。ただし、初期表示直後は押せるようになっています。初期表示には実際にはエラーでもエラー表示しておらず、これに同期させる必要があるからです。例えば、A項目は空白ではエラーですが、エラーになっていません。<br>
なお、リアルタイムでエラーチェックを行うために、バインドの引数を以下のように&nbsp;DataSourceUpdateMode.OnPropertyChanged にしています。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ErrorProvider&nbsp;ep&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ErrorProvider();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BindingSource&nbsp;bs&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BindingSource();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Model&nbsp;model&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Model();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UIObject&nbsp;uiobj&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UIObject();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;コンストラクタ</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bs.DataSource&nbsp;=&nbsp;uiobj;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.textBox1.DataBindings.Add(<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/ja-JP/library/System.Windows.Forms.Binding.aspx" target="_blank" title="Auto generated link to System.Windows.Forms.Binding">System.Windows.Forms.Binding</a>(<span class="cs__string">&quot;Text&quot;</span>,&nbsp;bs,&nbsp;<span class="cs__string">&quot;A&quot;</span>,&nbsp;<span class="cs__keyword">true</span>,&nbsp;DataSourceUpdateMode.OnPropertyChanged));</pre>
</div>
</div>
</div>
<div class="endscriptcode">エラーが全て無くなれば以下のように、UIObjectからModelに値を書き戻しています。データベースを扱うような場合は、DataTableに書き戻し、そこからデータベースに書き戻すようにします。この辺りはADO.NETの基本的な仕組みを使うことになります。</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;保存ボタンクリック</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;e&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;bttn_保存_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uiobj.ValidateAll();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ep.UpdateBinding();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(uiobj.HasError)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;以下のエラーのため、保存されませんでした。\r\n\r\n&quot;</span>&nbsp;&#43;&nbsp;uiobj.Error,&nbsp;<span class="cs__string">&quot;エラー有り&quot;</span>,&nbsp;MessageBoxButtons.OK,&nbsp;MessageBoxIcon.Error);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;model.A&nbsp;=&nbsp;uiobj.A;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;model.B&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(uiobj.B);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;model.C&nbsp;=&nbsp;<span class="cs__keyword">decimal</span>.Parse(uiobj.C);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;保存されました。&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<ul>
</ul>
<h1>ヒント</h1>
<p>本サンプルを変更画面として扱った場合、画面を閉じる際にUIObjectとModelを比較し、ユーザーがどこかの項目を変更した場合のみ、「このまま閉じると変更が失われますがよろしいですか？」等のメッセージを出すことができるようになります。実質、Modelが変更前、UIObjectが変更後の値を保持していることになります。これを利用すれば、項目単位で編集前にリセットすることも可能です。<br>
また、話が逸れてWPFの話になりますが、WPFの場合はUIObjectのバインド用プロパティを、全てstring型で定義する必要はなく、それぞれの本来の型で定義しても問題ありません。</p>
