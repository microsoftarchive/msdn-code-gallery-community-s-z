# WPFでデータをグルーピングして表示させる
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- WPF Basics
## Updated
- 06/01/2013
## Description

<h1>サンプルプログラムの概要</h1>
<p>このサンプルプログラムは、CollectionViewSourceクラスにあるデータのグループ化の機能をつかってデータをグループ化して表示する方法を示します。</p>
<p><img id="83106" src="83106-ws000009.jpg" alt="" width="513" height="330"></p>
<h1>サンプルプログラムの説明</h1>
<p>このサンプルプログラムでは、PersonクラスというNameプロパティとAgeプロパティを持ったクラスのコレクションをXAMLで定義したCollectionViewSourceのSourceプロパティに紐づけています。CollectionViewSourceでは、GroupDescriptionsプロパティにPropertyGroupDescriptionを使ってPersonクラスのAgeプロパティをもとにグループ化するように定義しています。このとき、年齢を10歳単位でグルーピングしたかったため、AgeToGenerationConverterというIValueConverterを実装したコンバータを使用して10歳単位でグルーピングされるように値の変換を行っています。</p>
<p>CollectionViewSourceの定義部分をいかに示します。</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- 年齢から1の位を省くコンバータ --&gt;
&lt;local:AgeToGenerationConverter x:Key=&quot;ageToGenerationConverter&quot; /&gt;
&lt;CollectionViewSource
    x:Key=&quot;source&quot;&gt;
    &lt;CollectionViewSource.GroupDescriptions&gt;
        &lt;!-- 年齢でグルーピングする。グルーピングに使用する値はコンバータで変換した結果 --&gt;
        &lt;PropertyGroupDescription
            PropertyName=&quot;Age&quot; 
            Converter=&quot;{StaticResource ageToGenerationConverter}&quot; /&gt;
    &lt;/CollectionViewSource.GroupDescriptions&gt;
&lt;/CollectionViewSource&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__comment">&lt;!--&nbsp;年齢から1の位を省くコンバータ&nbsp;--&gt;</span>&nbsp;
<span class="xaml__tag_start">&lt;local</span>:AgeToGenerationConverter&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;ageToGenerationConverter&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
<span class="xaml__tag_start">&lt;CollectionViewSource</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;source&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;CollectionViewSource</span>.GroupDescriptions<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--&nbsp;年齢でグルーピングする。グルーピングに使用する値はコンバータで変換した結果&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;PropertyGroupDescription</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">PropertyName</span>=<span class="xaml__attr_value">&quot;Age&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Converter</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;ageToGenerationConverter}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/CollectionViewSource.GroupDescriptions&gt;&nbsp;
<span class="xaml__tag_end">&lt;/CollectionViewSource&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;グルーピングされたデータの表示はListBoxで行っています。基本的に、ItemsControlの派生クラスでは同じような要領でデータのグルーピングができるので、DataGridなどでもここで使っているのと同じ方法でグルーピングが行えます。</div>
<div class="endscriptcode">グルーピングされたときのグループごとに表示するヘッダーは、GroupStyleのHeaderTemplateで指定可能です。HeaderTemplateにはCollectionViewGroupクラスのインスタンスがDataContextに設定されています。CollectionViewGroupクラスのNameプロパティにグルーピングに使用した値が入っているので、この値を利用してグループヘッダーを定義することが多いと思います。ここでは、**歳代という形でグループヘッダーを定義しています。</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;ListBox.GroupStyle&gt;
    &lt;GroupStyle&gt;
        &lt;!-- グループヘッダーの見た目を定義します。 --&gt;
        &lt;GroupStyle.HeaderTemplate&gt;
            &lt;DataTemplate&gt;
                &lt;TextBlock Text=&quot;{Binding Name, StringFormat={}{0}0歳代}&quot; /&gt;
            &lt;/DataTemplate&gt;
        &lt;/GroupStyle.HeaderTemplate&gt;
    &lt;/GroupStyle&gt;
&lt;/ListBox.GroupStyle&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;ListBox</span>.GroupStyle<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GroupStyle</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__comment">&lt;!--&nbsp;グループヘッダーの見た目を定義します。&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GroupStyle</span>.HeaderTemplate<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Name,&nbsp;StringFormat={}{0}0歳代}&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/GroupStyle.HeaderTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/GroupStyle&gt;</span>&nbsp;
&lt;/ListBox.GroupStyle&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;最後に、グルーピングとは関係ないですが、データが縦長に表示されるだけではつまらなかったので、ListBox横スクロールバーを無効化してListBoxのItemsPanelにWrapPanelを設定して、データを横並びで右端で折り返すようにしました。ちなみに、グループの並びをカスタマイズしたい場合は、GroupStyleのPanelプロパティにItemsPanelTemplateを設定することで変更が可能です。</div>
</div>
<p></p>
<p>&nbsp;</p>
<h1>参考情報</h1>
<p>このサンプルプログラム内で使用している主なクラスのMSDNへのリンクです。</p>
<ul>
<li>CollectionViewSourceクラス<br>
<a href="http://msdn.microsoft.com/ja-jp/library/system.windows.data.collectionviewsource(v=vs.100).aspx">http://msdn.microsoft.com/ja-jp/library/system.windows.data.collectionviewsource(v=vs.100).aspx</a>
</li><li>CollectionViewSource.GroupDescriptionsプロパティ<br>
<a href="http://msdn.microsoft.com/ja-jp/library/system.windows.data.collectionviewsource.groupdescriptions(v=vs.100).aspx">http://msdn.microsoft.com/ja-jp/library/system.windows.data.collectionviewsource.groupdescriptions(v=vs.100).aspx</a>
</li><li>CollectionViewGoupクラス<br>
<a href="http://msdn.microsoft.com/ja-jp/library/system.windows.data.collectionviewgroup(v=vs.100).aspx">http://msdn.microsoft.com/ja-jp/library/system.windows.data.collectionviewgroup(v=vs.100).aspx</a>
</li><li>GroupItemクラス<br>
<a href="http://msdn.microsoft.com/ja-jp/library/system.windows.controls.groupitem(v=vs.100).aspx">http://msdn.microsoft.com/ja-jp/library/system.windows.controls.groupitem(v=vs.100).aspx</a>
</li></ul>
<p>&nbsp;</p>
