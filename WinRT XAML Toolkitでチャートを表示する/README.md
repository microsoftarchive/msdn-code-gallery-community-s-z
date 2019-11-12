# WinRT XAML Toolkitでチャートを表示する
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Windows Store app
## Topics
- WinRT XAML Toolkit
## Updated
- 07/25/2013
## Description

<h1>サンプルプログラムの概要</h1>
<p>このサンプルプログラムは、WinRT XAML Toolkitの中の、Chartを使って以下のようなチャートをWinows ストア アプリで実現します。WinRT XAML Toolkitは、Chart系のコントロール以外にも、Windows Runtimeの標準機能では不足しているコントロールや、便利機能がたくさん詰まったライブラリです。このChartのサンプルで興味を持たれた方は、この記事の最後の参考情報からWinRT XAML Toolkitのプロジェクトページを参照してみてください。</p>
<p><img id="92843" src="92843-screenshot_07252013_222433.png" alt="" width="500" height="300"></p>
<h1>サンプルプログラムの内容</h1>
<p>このサンプルプログラムはPrism for Windows Runtimeのプロジェクトテンプレートを使用して作成しています。プログラムが起動すると、App.xaml.cs内でMainPage.xamlへ遷移して、Prismの機能を使ってMainPageのDataContextにMainPageViewModelを設定しています。</p>
<p>このMainPageViewModelクラスのプロパティをChartにバインディングして、グラフを表示しています。</p>
<h2>チャートに表示するデータ</h2>
<p>このサンプルプログラムでは、アプリケーションを起動するたびにランダムなデータを作成して、チャートに表示しています。Chartコントロールに表示するためには、最低でもチャートのラベルに使用するプロパティと、チャートのデータ（数値）のプロパティが必要です。このサンプルプログラムでは、Models名前空間にChartItemというクラスを定義して使用しています。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;WinRTToolkitChartSample.Models&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;グラフに表示するためのデータ</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ChartItem&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;グラフの値</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Value&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;グラフのラベル</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;ランダムなデータを10件返す。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;IEnumerable&lt;ChartItem&gt;&nbsp;GetChartItems()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;r&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Random();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Enumerable.Range(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">10</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Select(i&nbsp;=&gt;&nbsp;<span class="cs__keyword">new</span>&nbsp;ChartItem&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;項目&quot;</span>&nbsp;&#43;&nbsp;i,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value&nbsp;=&nbsp;r.Next(<span class="cs__number">100</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p class="endscriptcode">GetChartItemsメソッドでランダムなエータを10個作成して返しています。</p>
<h2 class="endscriptcode">MainPageViewModelクラス</h2>
<p>画面に表示するデータを保持するMainPageViewModelクラスでは、上記のChartItemのコレクション型のプロパティを2つ定義しています。この2つのプロパティをChartにバインドしてグラフとして画面に表示しています。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;Microsoft.Practices.Prism.StoreApps;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/ja-JP/library/System.Collections.ObjectModel.aspx" target="_blank" title="Auto generated link to System.Collections.ObjectModel">System.Collections.ObjectModel</a>;&nbsp;
using&nbsp;Windows.UI.Xaml.Navigation;&nbsp;
using&nbsp;WinRTToolkitChartSample.Common;&nbsp;
using&nbsp;WinRTToolkitChartSample.Models;&nbsp;
&nbsp;
namespace&nbsp;WinRTToolkitChartSample.ViewModels&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;MainPageViewModel&nbsp;:&nbsp;ViewModel&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;ObservableCollection&lt;ChartItem&gt;&nbsp;chartItems1;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;グラフに表示するためのデータのコレクションその１</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ObservableCollection&lt;ChartItem&gt;&nbsp;ChartItems1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__operator">this</span>.chartItems1;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__operator">this</span>.SetProperty(ref&nbsp;<span class="js__operator">this</span>.chartItems1,&nbsp;value);&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;ObservableCollection&lt;ChartItem&gt;&nbsp;chartItems2;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;グラフに表示するためのデータのコレクションその２</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ObservableCollection&lt;ChartItem&gt;&nbsp;ChartItems2&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__operator">this</span>.chartItems2;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__operator">this</span>.SetProperty(ref&nbsp;<span class="js__operator">this</span>.chartItems2,&nbsp;value);&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;override&nbsp;<span class="js__operator">void</span>&nbsp;OnNavigatedTo(object&nbsp;navigationParameter,&nbsp;NavigationMode&nbsp;navigationMode,&nbsp;Dictionary&lt;string,&nbsp;object&gt;&nbsp;viewModelState)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base.OnNavigatedTo(navigationParameter,&nbsp;navigationMode,&nbsp;viewModelState);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;画面にナビゲーションしてきたタイミングでデータの初期化を行う</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.ChartItems1&nbsp;=&nbsp;ChartItem.GetChartItems().ToObservableCollection();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.ChartItems2&nbsp;=&nbsp;ChartItem.GetChartItems().ToObservableCollection();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>OnNavigateｄToメソッドで先ほどのChartItemクラスに定義したデータの作成処理を呼び出してプロパティへ&#26684;納しています。</p>
<h2>Chartコントロール</h2>
<p>Chartコントロールは、WinRTXamlToolkit.Controls.DataVisualization.Charting名前空間に定義されています。そのためXAMLで名前空間の定義をして使用します。サンプルプログラムではChartingという名前空間に紐づけています。</p>
<p>Chartコントロールの基本的な使い方はChartコントロールを置いて、そこのSeriesプロパティに****Seriesクラス(****の部分にグラフの種類が入る）を設定して使います。Seriesプロパティには複数の****Seriesを指定できてグラフを重ね合わせたり、同じ種類のグラフの場合はマージして表示します。</p>
<p>****Seriesクラスには、以下のようなプロパティが定義されています。</p>
<ul>
<li>Titleプロパティ<br>
グラフのタイトル（棒グラフなどでは凡例の部分に表示されたりします） </li><li>ItemsSourceプロパティ<br>
グラフに表示するデータのコレクションを設定します。 </li><li>IndependentValueBindingプロパティ<br>
グラフのデータの塊を表すデータ（縦の棒グラフでは 横軸の下のラベル、円グラフでは円の中のデータの塊の名前）のプロパティをバインドします </li><li>DependentValueBindingプロパティ<br>
グラフのデータを表すプロパティをバインドします。 （縦の棒グラフでは棒の長さ、円グラフでは円の中を占める面積の広さ） </li><li>IsSelectionEnabledプロパティ<br>
Trueにすると、マウスなどでグラフを選択したときにデータを表示したりすることが出来ます。 </li></ul>
<p>このサンプルプログラムでは、画面左にColumnSeriesという縦の棒グラフを2つ並べたものと、画面右に円グラフとエリアグラフを重ね合わせたものを作成しています。</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="csharp">&lt;!--&nbsp;画面左部分のチャート&nbsp;--&gt;&nbsp;
&lt;Charting:Chart&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;!--&nbsp;縦の棒グラフを<span class="cs__number">2</span>つ表示&nbsp;--&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Charting:ColumnSeries&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Title=<span class="cs__string">&quot;Item1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ItemsSource=<span class="cs__string">&quot;{Binding&nbsp;ChartItems1}&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IndependentValueBinding=<span class="cs__string">&quot;{Binding&nbsp;Name}&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependentValueBinding=<span class="cs__string">&quot;{Binding&nbsp;Value}&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsSelectionEnabled=<span class="cs__string">&quot;True&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Charting:ColumnSeries&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Title=<span class="cs__string">&quot;Item2&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ItemsSource=<span class="cs__string">&quot;{Binding&nbsp;ChartItems2}&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IndependentValueBinding=<span class="cs__string">&quot;{Binding&nbsp;Name}&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependentValueBinding=<span class="cs__string">&quot;{Binding&nbsp;Value}&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsSelectionEnabled=<span class="cs__string">&quot;True&quot;</span>&nbsp;/&gt;&nbsp;
&lt;/Charting:Chart&gt;&nbsp;
&lt;!--&nbsp;画面右部分のチャート&nbsp;--&gt;&nbsp;
&lt;!--&nbsp;異なる種類のグラフを複数指定してみる&nbsp;--&gt;&nbsp;
&lt;Charting:Chart&nbsp;Grid.Column=<span class="cs__string">&quot;1&quot;</span>&nbsp;Grid.Row=<span class="cs__string">&quot;1&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;!--&nbsp;円グラフ&nbsp;--&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Charting:PieSeries&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ItemsSource=<span class="cs__string">&quot;{Binding&nbsp;ChartItems1}&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IndependentValueBinding=<span class="cs__string">&quot;{Binding&nbsp;Name}&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependentValueBinding=<span class="cs__string">&quot;{Binding&nbsp;Value}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsSelectionEnabled=<span class="cs__string">&quot;True&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;!--&nbsp;領域グラフ？&nbsp;--&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Charting:AreaSeries&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ItemsSource=<span class="cs__string">&quot;{Binding&nbsp;ChartItems1}&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IndependentValueBinding=<span class="cs__string">&quot;{Binding&nbsp;Name}&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependentValueBinding=<span class="cs__string">&quot;{Binding&nbsp;Value}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsSelectionEnabled=<span class="cs__string">&quot;True&quot;</span>/&gt;&nbsp;
&lt;/Charting:Chart&gt;&nbsp;
</pre>
</div>
</div>
</div>
</h1>
<h1>まとめ</h1>
<p>WinRT XAML ToolkitのChartコントロールを使うと、少量のコードでチャートを表示することができます。Windows ストア アプリは、データの可視化をする領域での使用に向いてると思います。そのため、扱うコンテンツによってはチャート形式でデータを表示するのが最適なこともあり得ます。その時の一つの検討の候補としてWinRT XAML Toolkitを評価してみるのもありなのではないかと思います。</p>
<h1>参考情報</h1>
<ol>
<li><a href="http://winrtxamltoolkit.codeplex.com/">WinRT XAML Toolkit</a> </li><li><a href="http://prismwindowsruntime.codeplex.com/">Prism for Windows Runtime</a>
</li><li><a href="http://code.msdn.microsoft.com/site/search?f%5B0%5D.Type=Topic&f%5B0%5D.Value=Prism%20for%20Windows%20Runtime&f%5B0%5D.Text=Prism%20for%20Windows%20Runtime">コードレシピ内のPrism for Windows Runtimeのサンプルコード</a>
</li></ol>
