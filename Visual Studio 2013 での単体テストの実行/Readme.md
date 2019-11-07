# Visual Studio 2013 での単体テストの実行
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2013
## Topics
- Unit Testing
## Updated
- 11/25/2014
## Description

<h1><span style="font-size:medium">Introduction</span></h1>
<p><span style="font-size:small">ソフトウェアがビジネスや生活に多大な影響を与える昨今、ソフトウェアの品質はますます重要性が高まっています。ただし、人手による検&#35388;では限界があるため、ソフトウェアテストを自動化できるかが重要になります。</span></p>
<p><span style="font-size:small">今回の記事ではソフトウェアテストの自動化の方法をお伝えし、その方法をご理解いただきます。</span></p>
<p><span style="font-size:x-small"><br>
</span></p>
<h1><span style="font-size:medium">Building the Sample</span></h1>
<p><span style="font-size:small">この手順を実現するためには、Viual Studio 2013 の Professional 以上の Edition (Professional, Premier, Ultimate) が必要です。</span></p>
<p>&nbsp;</p>
<p><span style="font-size:medium; font-weight:bold">Description</span></p>
<p><span style="font-size:small">テスト実行自体の理解を深めるため、シンプルなコンソール アプリケーションに対してテストを行う手順を記載いたします。</span></p>
<ol>
<li><span style="font-size:small">Visual Studio 2013 を起動します。</span> </li><li><span style="font-size:small">[新しいプロジェクト...] をクリックします。<br>
<img id="130344" src="130344-%e5%9b%b31.png" alt="" width="500"><br>
<br>
</span></li><li><span style="font-size:small">[新しいプロジェクト] ウィンドウが表示されるので、左ペインで [インストール済み]-[テンプレート]-[Visual C#]-[Windows デスクトップ] を選択後、右ペインで [コンソール アプリケーション] を選択します。</span>
</li><li><span style="font-size:small">[名前] を &quot;TestApp&quot; と変更したうえで、[OK] ボタンをクリックします。<br>
<img id="130345" src="130345-%e5%9b%b32.png" alt="" width="500"><br>
<br>
</span></li><li><span style="font-size:small">&nbsp;コードを以下のように編集します。なお、このコードはテスト対象となります。<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;

namespace TestApp
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public int AddNumber(int x, int y)
        {
            return x &#43; y;
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;TestApp&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;AddNumber(<span class="cs__keyword">int</span>&nbsp;x,&nbsp;<span class="cs__keyword">int</span>&nbsp;y)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;x&nbsp;&#43;&nbsp;y;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
</span></li><li><span style="font-size:small">次に、テスト用のプログラムを作成していきます。</span> </li><li><span style="font-size:small">[ソリューションエクスプローラー] 上で [ソリューション 'TestApp'] を右クリックし、[追加]-[新しいプロジェクト...] を選択します。<br>
<img id="130346" src="130346-%e5%9b%b33.png" alt="" width="500"><br>
<br>
</span></li><li><span style="font-size:small">[新しいプロジェクト] ウィンドウが表示されるので、左ペインで [インストール済み]-[Visual C#]-[テスト] を選択します。右ペインで [単体テスト プロジェクト] を選択し、&quot;UnitTestProject1&quot; という名前を設定後、[OK] ボタンをクリックします。<br>
<img id="130347" src="130347-%e5%9b%b34.png" alt="" width="500"><br>
<br>
</span></li><li><span style="font-size:small">UnitTestProject1 から、TestApp を呼び出して利用できるようにするため、参照の追加を行います。[UnitTestProject1]-[参照設定] を右クリックし、[参照の追加] をクリックします。<br>
<img id="130348" src="130348-%e5%9b%b35.png" alt="" width="500"><br>
<br>
</span></li><li><span style="font-size:small">[参照マネージャー] ウィンドウが表示されるので、左ペインで [ソリューション]-[プロジェクト] を選択後、右ペインで &quot;TestApp&quot; にチェックを入れてし、[OK] ボタンをクリックします。<br>
<img id="130349" src="130349-%e5%9b%b36.png" alt="" width="500"><br>
</span></li><li><span style="font-size:small">[ソリューションエクスプローラー] から UniteTest1.cs ファイルをダブル クリックしてファイルを開きます。</span>
</li><li><span style="font-size:small">コードを以下のように編集します。<br>
&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program p = new Program();
            int x = 1;
            int y = 2;

            int expected = 3;
            //答えとして期待する値

            int actual = p.AddNumber(x, y);
            //実際の値

            Assert.AreEqual(expected, actual);
            //期待値と実際の値が同一であるかを検&#35388;します。同一である場合にはテストが成功し、そうでない場合には失敗を返します。
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.VisualStudio.TestTools.UnitTesting;&nbsp;
<span class="cs__keyword">using</span>&nbsp;TestApp;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;UnitTestProject1&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[TestClass]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;UnitTest1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TestMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;TestMethod1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Program&nbsp;p&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Program();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;x&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;y&nbsp;=&nbsp;<span class="cs__number">2</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;expected&nbsp;=&nbsp;<span class="cs__number">3</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//答えとして期待する値</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;actual&nbsp;=&nbsp;p.AddNumber(x,&nbsp;y);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//実際の値</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(expected,&nbsp;actual);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//期待値と実際の値が同一であるかを検&#35388;します。同一である場合にはテストが成功し、そうでない場合には失敗を返します。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
</span></li><li><span style="font-size:small">&quot;TestMethod1()&quot; を右クリックし、[テストの実行] をクリックします。<br>
<img id="130350" src="130350-%e5%9b%b37.png" alt="" width="500">&nbsp;<br>
&nbsp;</span> </li><li><span style="font-size:xx-small"><span style="font-size:small">[テスト エクスプローラー] ウィンドウが表示され、テストが成功した場合には緑色のチェックマークが表示されます。</span><br>
<img id="130351" src="130351-%e5%9b%b38.png" alt="" width="500"><br>
</span></li></ol>
<ul>
</ul>
<h1><span style="font-size:medium">More Information</span></h1>
<p><span style="font-size:small">単体テストについては以下の URL を参照してください。</span></p>
<p><span style="font-size:small">http://msdn.microsoft.com/ja-jp/library/hh598957.aspx</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">Asset メソッドの詳細は以下の URL を参照してください。</span></p>
<p><span style="font-size:small">http://msdn.microsoft.com/ja-jp/library/microsoft.visualstudio.testtools.unittesting.assert_methods.aspx</span></p>
