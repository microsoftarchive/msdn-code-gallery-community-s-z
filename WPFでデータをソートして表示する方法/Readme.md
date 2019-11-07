# WPFでデータをソートして表示する方法
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- WPF Basics
## Updated
- 05/30/2013
## Description

<h1>サンプルプログラムの概要</h1>
<p>このサンプルプログラムは、Windows Presentation FoudationのCollectionViewSourceを使用してデータをソートして表示するプログラムです。CollectionViewSourceのソート機能を使うことで、バックグラウンドで持つデータはソートしないまま、表示のソートを行うことが可能です。</p>
<p>サンプルプログラムでは、画面の左右にあるListBoxに1つのコレクションを異なるソート条件で表示しています。</p>
<p><img id="82899" src="82899-ws000007.jpg" alt="" width="525" height="350"></p>
<h1>サンプルプログラムの解説</h1>
<p>このサンプルプログラムでは、画面に表示するデータを表すために以下のようなPersonクラスを定義しています。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace WPFSortSample
{
    /// &lt;summary&gt;
    /// 画面に表示するためのダミーオブジェクト
    /// &lt;/summary&gt;
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            // 画面に表示するための文字列を作成
            return string.Format(&quot;{0} {1}才&quot;, this.Name, this.Age);
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;WPFSortSample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;画面に表示するためのダミーオブジェクト</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Person&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Age&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;画面に表示するための文字列を作成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;{0}&nbsp;{1}才&quot;</span>,&nbsp;<span class="cs__keyword">this</span>.Name,&nbsp;<span class="cs__keyword">this</span>.Age);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;上記PersonクラスのAgeプロパティをキーにしてソートします。</div>
<div class="endscriptcode">WPFでのソートは、CollectionViewSourceクラスのSortDescriptionsプロパティを使用すると簡単にできます。SortDescriptionsプロパティには複数のSortDescription構造体を設定できます。SortDescription構造体はCollectionViewSourceクラスのSourceプロパティに設定されたコレクション内のオブジェクトのプロパティをキーにして昇順でソートするか降順でソートするか指定可能です。</div>
<div class="endscriptcode">サンプルプログラムでは、MainWindow.xamlのResourcesにAgeプロパティを昇順・降順でソートする2種類のCollectionViewSourceを定義しています。</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;CollectionViewSource x:Key=&quot;source1&quot;&gt;
    &lt;CollectionViewSource.SortDescriptions&gt;
        &lt;ComponentModel:SortDescription
            Direction=&quot;Ascending&quot;
            PropertyName=&quot;Age&quot; /&gt;
    &lt;/CollectionViewSource.SortDescriptions&gt;
&lt;/CollectionViewSource&gt;
&lt;CollectionViewSource x:Key=&quot;source2&quot;&gt;
    &lt;CollectionViewSource.SortDescriptions&gt;
        &lt;ComponentModel:SortDescription
            Direction=&quot;Descending&quot;
            PropertyName=&quot;Age&quot; /&gt;
    &lt;/CollectionViewSource.SortDescriptions&gt;
&lt;/CollectionViewSource&gt;
&lt;/Window.Resources&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;CollectionViewSource</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;source1&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;CollectionViewSource</span>.SortDescriptions<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ComponentModel</span>:SortDescription&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Direction</span>=<span class="xaml__attr_value">&quot;Ascending&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">PropertyName</span>=<span class="xaml__attr_value">&quot;Age&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/CollectionViewSource.SortDescriptions&gt;&nbsp;
<span class="xaml__tag_end">&lt;/CollectionViewSource&gt;</span>&nbsp;
<span class="xaml__tag_start">&lt;CollectionViewSource</span>&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;source2&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;CollectionViewSource</span>.SortDescriptions<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ComponentModel</span>:SortDescription&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Direction</span>=<span class="xaml__attr_value">&quot;Descending&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">PropertyName</span>=<span class="xaml__attr_value">&quot;Age&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/CollectionViewSource.SortDescriptions&gt;&nbsp;
<span class="xaml__tag_end">&lt;/CollectionViewSource&gt;</span>&nbsp;
&lt;/Window.Resources&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;このCollectionViewSourceを画面のListBoxのItemsSourceプロパティにBindingしています。</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;ListBox Grid.Row=&quot;1&quot; ItemsSource=&quot;{Binding Source={StaticResource source1}}&quot; /&gt;
&lt;ListBox Grid.Row=&quot;1&quot; Grid.Column=&quot;1&quot; ItemsSource=&quot;{Binding Source={StaticResource source2}}&quot; /&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;ListBox</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Source={StaticResource&nbsp;source1}}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
<span class="xaml__tag_start">&lt;ListBox</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Column</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">ItemsSource</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Source={StaticResource&nbsp;source2}}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
コードビハインドのMainWindow.xaml.csのコンストラクタで、XAMLに定義したCollectionViewSourceのSourceプロパティにデータを&#26684;納しているObservableCollectionのインスタンスを設定しています。</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public MainWindow()
{
    InitializeComponent();

    // XAMLで定義したCollectionViewSourceのSourceにコレクションを設定
    var source1 = this.Resources[&quot;source1&quot;] as CollectionViewSource;
    if (source1 != null)
    {
        source1.Source = people;
    }

    var source2 = this.Resources[&quot;source2&quot;] as CollectionViewSource;
    if (source2 != null)
    {
        source2.Source = people;
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;MainWindow()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;XAMLで定義したCollectionViewSourceのSourceにコレクションを設定</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;source1&nbsp;=&nbsp;<span class="cs__keyword">this</span>.Resources[<span class="cs__string">&quot;source1&quot;</span>]&nbsp;<span class="cs__keyword">as</span>&nbsp;CollectionViewSource;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(source1&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;source1.Source&nbsp;=&nbsp;people;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;source2&nbsp;=&nbsp;<span class="cs__keyword">this</span>.Resources[<span class="cs__string">&quot;source2&quot;</span>]&nbsp;<span class="cs__keyword">as</span>&nbsp;CollectionViewSource;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(source2&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;source2.Source&nbsp;=&nbsp;people;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;画面上部にあるボタンのクリックイベントでは、年齢に乱数を設定したPersonクラスのインスタンスを作成してコレクションに追加しています。ポイントは、people変数の中では、何もソートをしていないという点です。</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private void AddPersonButton_Click(object sender, RoutedEventArgs e)
{
    // ランダムな年齢のPersonクラスのオブジェクトを追加する
    var p = new Person
    {
        Name = &quot;No.&quot; &#43; (this.people.Count &#43; 1) &#43; &quot;: Dummy person&quot;,
        Age = this.RandomObject.Next(100)
    };
    this.people.Add(p);
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddPersonButton_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;ランダムな年齢のPersonクラスのオブジェクトを追加する</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;p&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Person&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;No.&quot;</span>&nbsp;&#43;&nbsp;(<span class="cs__keyword">this</span>.people.Count&nbsp;&#43;&nbsp;<span class="cs__number">1</span>)&nbsp;&#43;&nbsp;<span class="cs__string">&quot;:&nbsp;Dummy&nbsp;person&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Age&nbsp;=&nbsp;<span class="cs__keyword">this</span>.RandomObject.Next(<span class="cs__number">100</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.people.Add(p);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
プログラムを実行してボタンを何回かクリックすると、CollectionViewSourceに設定したソートの条件でListBoxにデータが表示されていることが確認できます。</div>
<div class="endscriptcode"><img id="82900" src="82900-ws000008.jpg" alt="" width="525" height="351"></div>
</div>
</div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode">参考情報</h1>
<div class="endscriptcode">このサンプルで使用している代表的なクラスのMSDNへのリンクです。</div>
<ul>
<li>
<div class="endscriptcode">CollectionViewSourceクラス<br>
<a href="http://msdn.microsoft.com/ja-jp/library/system.windows.data.collectionviewsource(v=vs.100).aspx">http://msdn.microsoft.com/ja-jp/library/system.windows.data.collectionviewsource(v=vs.100).aspx</a></div>
</li><li>
<div class="endscriptcode">SortDescription構造体<br>
<a href="http://msdn.microsoft.com/ja-jp/library/system.componentmodel.sortdescription(v=vs.100).aspx">http://msdn.microsoft.com/ja-jp/library/system.componentmodel.sortdescription(v=vs.100).aspx</a></div>
</li></ul>
