# VB: Windows フォーム向けユーザー コントロールの作成
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- .NET Framework 2.0
- Windows 7 Ultimate 64 bit
## Topics
- Windows フォーム
- 逆引きサンプル コード
## Updated
- 02/22/2011
## Description

<p>執筆者: <a href="http://msdn.microsoft.com/ja-jp/gg585574#ikehara" target="_blank">
インフラジスティックス・ジャパン株式会社　池原 大然</a></p>
<p>動作確認環境: Visual Studio 2010、.NET Framework 2.0、Windows 7 Ultimate 64 bit</p>
<hr>
<p>アプリケーションの開発規模や画面数によっては複数のコントロールを 1 つにまとめたものを再利用し開発効率を上げることができます。Windows フォームでは標準で提供されているコントロールのほか、<a href="http://msdn.microsoft.com/ja-jp/library/97855yck" target="_blank">System.Windows.Forms.UserControl</a> コントロールを用いて複数のコントロールをまとめることが可能になっています。</p>
<ol>
<li>Windows フォーム アプリケーション コントロール ライブラリ プロジェクトを作成し名前を &quot;CodeRecipe_ControlLibrary_VB&quot;、ソリューション名を &quot;CodeRecipe_UserControl_VB&quot; と設定します。
<p><img src="18617-image001.jpg" alt="図 1" width="570" height="363"></p>
</li><li>プロジェクトには既定で UserControl1 が追加されており、デザイン画面にはコントロール領域にツール ボックスからコントロールを追加することが可能です。
<p><img src="18618-image002.jpg" alt="図 2" width="570" height="338"></p>
</li><li>このユーザー コントロールには DateTimePicker コントロール、Button コントロールを追加します。
<p><img src="18613-image003.jpg" alt="図 3" width="300" height="171"></p>
</li><li>
<p>コード ビハインドでこの UserControl 独自のプロパティである、DateTime 型の BirthDate プロパティを実装します。その際に <a href="http://msdn.microsoft.com/ja-jp/library/system.componentmodel.defaultvalueattribute" target="_blank">
DefaultValueAttribute</a> を設定し、既定値を設定することが可能です。また、計算ボタンクリック時に BirthDate と DateTimePicker で選択した日付の経過日数を表示させるロジックを記述します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>
<pre class="hidden">Public Class UserControl1

    Sub New()

        InitializeComponent()
        ' プロパティの初期値を設定
        Me._birthDate = New DateTime(2000, 1, 1)

    End Sub

    ' BirthDate プロパティを設定
    Private _birthDate As DateTime
    &lt;System.ComponentModel.DefaultValue(GetType(DateTime), &quot;2000/01/01&quot;)&gt;
    Public Property BirthDate() As DateTime
        Get
            Return _birthDate
        End Get
        Set(ByVal value As DateTime)
            _birthDate = value
        End Set
    End Property

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' 差分を表示
        MessageBox.Show( _
            String.Format(&quot;誕生日から {0} 日経過しています。&quot;, _
           (Me.DateTimePicker1.Value - BirthDate).Days))
    End Sub
End Class</pre>
<div class="preview">
<pre id="codePreview" class="csharp">Public&nbsp;Class&nbsp;UserControl1&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Sub&nbsp;New()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;プロパティの初期値を設定&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Me._birthDate&nbsp;=&nbsp;New&nbsp;DateTime(<span class="cs__number">2000</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;BirthDate&nbsp;プロパティを設定&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;_birthDate&nbsp;As&nbsp;DateTime&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;System.ComponentModel.DefaultValue(GetType(DateTime),&nbsp;<span class="cs__string">&quot;2000/01/01&quot;</span>)&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;Property&nbsp;BirthDate()&nbsp;As&nbsp;DateTime&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;_birthDate&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Set(ByVal&nbsp;<span class="cs__keyword">value</span>&nbsp;As&nbsp;DateTime)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_birthDate&nbsp;=&nbsp;<span class="cs__keyword">value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Set&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Property&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Sub&nbsp;Button1_Click(ByVal&nbsp;sender&nbsp;As&nbsp;System.Object,&nbsp;ByVal&nbsp;e&nbsp;As&nbsp;System.EventArgs)&nbsp;Handles&nbsp;Button1.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;差分を表示&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String.Format(<span class="cs__string">&quot;誕生日から&nbsp;{0}&nbsp;日経過しています。&quot;</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Me.DateTimePicker1.Value&nbsp;-&nbsp;BirthDate).Days))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
End&nbsp;Class&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
</li><li>
<p>次にこのコントロールをホストする Windows フォーム アプリケーションプロジェクトを &quot;CodeRecipe_UserControl_VB&quot; と名前を付けて作成します。なお、Windows フォーム アプリケーションの作成方法については
<a href="http://code.msdn.microsoft.com/VB-Windows-1a3cf40b">[VB] Windows フォームによるクライアント アプリケーション開発</a>を参照してください。</p>
<p><img src="18619-image004.jpg" alt="図 4" width="570" height="363"></p>
</li><li>Form1 のデザイナー画面を開き、Label, DateTimePicker, そして先ほど作成した UserControl1 コントロールを追加します。
<p><img src="18620-image005.jpg" alt="図 5" width="570" height="338"></p>
</li><li>
<p>Form1 の [設定] ボタンのクリック ハンドラーでは UserControl1.BirthDate プロパティに値を設定します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">vb</span>
<pre class="hidden">Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Me.UserControl11.BirthDate = Me.DateTimePicker1.Value
End Sub</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Button1_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button1.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.UserControl11.BirthDate&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.DateTimePicker1.Value&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>CodeRecipe_UserControl_VB をスタートアップ プロジェクトに設定したのちの実行結果は下記の通りです。</p>
<p><img src="18616-image006.jpg" alt="図 6" width="400" height="339"></p>
<p>上下の DatePicker で設定した日付の差分が表示されます。このフォームの下半分がパーツ化されたことになります。</p>
</li></ol>
<h3>関連リンク</h3>
<ul>
<li><a href="http://msdn.microsoft.com/ja-jp/library/97855yck" target="_blank">UserControl クラス</a>
</li><li><a href="http://msdn.microsoft.com/ja-jp/library/ms171724" target="_blank">Windows フォーム コントロールの属性</a>
</li><li><a href="http://beta.code.msdn.microsoft.com/10-Windows-VB-82ac27a0">10 行でズバリ!! Windows フォーム向けユーザー コントロールの作成 (VB)
</a></li></ul>
<hr style="clear:both; margin-bottom:8px; margin-top:20px">
<table>
<tbody>
<tr>
<td><a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe"><img src="-ff950935.coderecipe_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Code Recipe" width="180" height="70" style="margin-top:3px"></a></td>
<td><a href="http://msdn.microsoft.com/ja-jp/windows/" target="_blank"><img src="-ff950935.windows_180x70%28ja-jp,msdn.10%29.jpg" border="0" alt="Windows デベロッパー センター" width="180" height="70" style="margin-top:3px"></a></td>
<td>
<ul>
<li>もっと他のコンテンツを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/ff363212" target="_blank">
逆引きサンプル コード一覧へ</a> </li><li>もっと他のレシピを見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/samplecode.recipe">
Code Recipe へ</a> </li><li>もっと Windows の情報を見る &gt;&gt; <a href="http://msdn.microsoft.com/ja-jp/windows/" target="_blank">
Windows デベロッパー センターへ</a> </li></ul>
</td>
</tr>
</tbody>
</table>
<p style="margin-top:20px"><a href="#top"><img src="-top.gif" border="0" alt="">ページのトップへ</a></p>
