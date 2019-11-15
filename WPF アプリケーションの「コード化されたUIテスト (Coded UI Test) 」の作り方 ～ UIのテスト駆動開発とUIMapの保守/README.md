# WPF アプリケーションの「コード化されたUIテスト (Coded UI Test) 」の作り方 ～ UIのテスト駆動開発とUIMapの保守
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- WPF
- Visual Studio
- test manager
- Code UI Test
## Topics
- ALM
- 単体テスト
- 自動テスト
- 継続的インテグレーション
- コード化されたUIテスト
- テストケース
## Updated
- 03/23/2015
## Description

<h1>概要</h1>
<p>単体テストと同様に「コード化されたUIテスト(Coded UI Test)」をどのように作成するか？決定する事はプロジェクトを進める上で非常に重要です。</p>
<p>単体テストがクラスライブラリのメソッドを検&#35388;するのに対し、コード化されたUIテストはユーザーインターフェイスの動作を検&#35388;します。UI がユーザーコントロールとして独立してテスト出来るようになっていれば、いわゆる「単体テスト」として位置づけることができますが、一般的には画面全体の動作を検&#35388;する、いわゆる「シナリオテスト」と位置づけられるでしょう。</p>
<p>一般的に「シナリオテスト」は開発の実装よりも前工程の「要件」と関連して、「要件をどれだけ網羅しているか？」という観点で準備されるべきものですが、Visual Studio のコード化されたUIテストは、UIの実装が完了しなければ作成することが出来ません。テストの設計を開発より先行して行うためには、コード化されたUIテストで何ができるのか？を理解する必要があります。また、テストの設計のみを先行して開始できても、いわゆる「テストファースト」「テスト駆動」で実装を進めることが出来ません。</p>
<p>この問題を解決するために、「UIMap を使用した、コード化されたUIテストの基本的な作り方」と「UIMap を使用しないテストの作成方法」をサンプルとしてまとめました。</p>
<p>サンプルには、画面遷移してアイテムをリストに追加する WPF アプリケーションが含まれています。</p>
<p>このサンプルを使うことで、どのように UIMap を使用してコード化されたUIテストを作成するか？手軽に確認することが出来るため、テストの設計を進める上でのイメージを持つことが出来ます。Visual Studio 2013 Premium/Ultimate を使ってすぐにコード化されたUIテストが動作するか？アニメーションを再生するように動作を確認することが出来ます。</p>
<p>また、このサンプルでは UIMap を使用しないテストの作成方法を紹介しています。この方法では、(XAML での x:Name があらかじめ決定している必要がありますが）、UIを実装する前にテストコードを実装することが出来ます。これによってテスト駆動開発で UI を開発することが出来ます。通常は F5 ボタンを押して WPF アプリをデバッグ起動して手動でテストしているところを、代わりに、何度でも同じテストケースでテストしながらUIを開発することが出来ます。</p>
<p>この方法は UIMap を作成しないので変更に強く、ある程度開発が進むまでは、UIMap を使わずにテスト駆動で UI を開発し、アプリが完成に近づき、「シナリオテスト」のテストケースが十分にそろった頃に、UIMap を使った完全なテストに切り替える（共存させる）事が出来ます。</p>
<h1>サンプルの使い方</h1>
<p>サンプルはテスト対象の WPF アプリ プロジェクト (SampleWpfApp) と、コード化されたUIテストのサンプルプロジェクト (SampleWpfApp.Test) の二つで構成されています。</p>
<p><img id="135257" src="135257-1.png" alt="" width="257" height="62" style="border:1px solid gray; height:auto; max-width:100%"></p>
<p>Visual Studio 2013 Premium/Ultimate でソリューションを開き、[ テスト(S) &gt; 実行(R) &gt; 全てのテスト(A) ] を実行してください。</p>
<p>（静かに実行される 単体テスト と違って）ここでサンプルアプリが起動してテストが実施されます。マウスやキーボードを操作せずに、デモアニメーションを見るかのように、テストが完了するのを待ちましょう。</p>
<p><a href="https://youtu.be/JDW1ytlJRzU" target="_blank"><img id="135336" src="https://i1.code.msdn.s-msft.com/wpf-ui-coded-ui-test-9ab5581d/image/file/135336/1/2.png" alt="" width="1919" height="1199" style="border:1px solid gray; height:auto; max-width:100%"></a></p>
<ul>
<li><a href="https://youtu.be/JDW1ytlJRzU" target="_blank">動画で確認</a> </li></ul>
<p><span lang="en-US">[ </span><span lang="ja">テスト</span><span lang="en-US">(S) &gt;
</span><span lang="ja">ウィンドウ</span><span lang="en-US">(W) &gt; </span><span lang="ja">テスト</span><span lang="en-US">
</span><span lang="ja">エクスプローラー</span><span lang="en-US">(T) ] </span><span lang="ja">にテスト結果が表示されます。全ての結果が成功（緑のチェックマークのアイコン）になれば動作成功です。（ただし一部のテストは</span><span lang="en-US"> SampleWpfApp
</span><span lang="ja">を手動で先に起動しておかないと失敗するようになっています）</span></p>
<p><span lang="ja"><img id="135260" src="135260-3.png" alt="" width="810" height="321" style="border:1px solid gray; height:auto; max-width:100%"></span></p>
<p><span lang="ja">テスト結果を選択して</span><span lang="en-US"> [</span><span lang="ja">出力</span><span lang="en-US">]
</span><span lang="ja">を押すと、標準出力に詳細な情報が出力されているのが確認できます。</span></p>
<p><span lang="ja"><br>
</span></p>
<p><span lang="ja"><img id="135261" src="135261-4.png" alt="" width="390" height="118" style="border:1px solid gray; height:auto; max-width:100%"></span></p>
<p><span lang="ja">このテストでは、ボタンのクリックやテキストの入力など、テストされた操作が全て表示されています。テキストの期待値と結果や、見つかった</span><span lang="en-US"> TextBlock
</span><span lang="ja">の個数などが全て表示されています。</span></p>
<p><span lang="ja"><img id="135262" src="135262-5.png" alt="" width="680" height="840" style="border:1px solid gray; height:auto; max-width:100%"><br>
</span></p>
<p><span lang="ja">一見冗長に感じるかもしれませんが、実際に、大量の「シナリオテスト」をコード化されたUIテストで実装し開発の度に保守を続けるためには、最低限これらの情報を出力しておかないと、</span>いざテストが失敗になった時になぜ失敗になったのか？すぐにはわかりません。</p>
<p><span lang="ja">この出力を簡単にするためのライブラリをサンプルでは使用しています。</span></p>
<h1><span lang="ja">サンプルの説明</span></h1>
<p><span lang="ja">ソリューションに含まれるサンプルの内容は次の通りです。</span></p>
<p><span lang="ja"><img id="135263" src="135263-6.png" alt="" width="241" height="401" style="border:1px solid gray; height:auto; max-width:100%"></span></p>
<h2><span lang="ja">SampleWpfApp</span></h2>
<p><span lang="ja">データバインドとフレーム・ページ遷移を使用した WPF アプリケーションです。</span></p>
<ul>
<li>HOME 画面にアイテムの一覧が表示されます。 </li><li>最初はアイテムがありません。 </li><li>Add ボタンを押して、EDIT 画面に遷移するとアイテムを追加出来ます。 </li><li>データを保存する機能は無いため、再起動するたびにアイテムは空になります。 </li></ul>
<h2>SampleWpfApp.Test CodedUITest1.cs</h2>
<p>UIMap を使用して作成した「コード化されたUIテスト」のサンプルです。</p>
<ul>
<li>「録画」機能によって実際にアプリを操作して作成しました。 </li><li>UIMap.uitest ファイルと関連して動作します。 </li><li>アプリを起動する機能がないため、SampleWpfApp を先に起動してからテストします。 </li><li>UIMap を使用し、高機能で小規模な変更に強いです。UIが完成してからテストを実装します。 </li></ul>
<p>&nbsp;</p>
<h2 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[TestMethod]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CodedUITestMethod1()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;To&nbsp;generate&nbsp;code&nbsp;for&nbsp;this&nbsp;test,&nbsp;select&nbsp;&quot;Generate&nbsp;Code&nbsp;for&nbsp;Coded&nbsp;UI&nbsp;Test&quot;&nbsp;from&nbsp;the&nbsp;shortcut&nbsp;menu&nbsp;and&nbsp;select&nbsp;one&nbsp;of&nbsp;the&nbsp;menu&nbsp;items.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.UIMap.AddNewItem1();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.UIMap.AssertListItemCount1();&nbsp;
}&nbsp;
</pre>
</div>
</div>
</h2>
<p>&nbsp;</p>
<h2>&nbsp;SampleWpfApp.Test UsingUIMapTest.cs</h2>
<p>UIMap を使用して作成し、カスタマイズした「コード化されたUIテスト」のサンプルです。</p>
<ul>
<li>CodedUITest1.cs の内容をカスタマイズしたものです。 </li><li>UIMap.uitest ファイルと関連して動作します。 </li><li>CodedUITestPlus, CodedUIQuery という NuGet ライブラリを使用します。 </li><li>UIMap.cs にカスタマイズされたテストコードが追加されてあり、それを使用します。 </li><li>SampleWpfApp アプリが自動的に起動されます。 </li><li>UIMap を使用し、高機能で小規模な変更に強いです。UIが完成してからテストを実装します。 </li></ul>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[TestMethod]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CodedUITestMethod1()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;app&nbsp;=&nbsp;App.LaunchSolutionProject(<span class="cs__keyword">this</span>,&nbsp;<span class="cs__string">&quot;SampleWpfApp&quot;</span>)&nbsp;)&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OperationAssert.TextIs(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;最初に&nbsp;0.5&nbsp;秒以内にホーム画面が表示されること&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;HOME&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.Element.Sleep(&nbsp;TimeSpan.FromSeconds(&nbsp;<span class="cs__number">0.5</span>&nbsp;)&nbsp;).Find(&nbsp;<span class="cs__string">&quot;(pageTitle)&quot;</span>&nbsp;)&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.UIMap.AddNewItem1();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.UIMap.AssertListItemCount1();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<span class="cs__com">//&nbsp;end&nbsp;using</span>&nbsp;
}&nbsp;<span class="cs__com">//&nbsp;end&nbsp;function</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h2>SampleWpfApp.Test UsingCodedUIQueryTest.cs</h2>
<p>UIMap を使用しないで作成した「コード化されたUIテスト」のサンプルです。</p>
<ul>
<li>CodedUITestPlus, CodedUIQuery という NuGet ライブラリを使用します。 </li><li>SampleWpfApp アプリが自動的に起動されます。 </li><li>UIMap を使用しないため、大規模な変更に強く、テスト駆動開発が可能です。UIMap や UITestControl にしかない強力な機能は使えないため注意が必要です。
</li></ul>
<h1 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[TestMethod()]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SampleApp_正常系_連続して<span class="cs__number">3</span>アイテム追加出来ること()&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;app&nbsp;=&nbsp;App.LaunchSolutionProject(&nbsp;<span class="cs__keyword">this</span>,&nbsp;<span class="cs__string">&quot;SampleWpfApp&quot;</span>&nbsp;))&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;counter&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Func&lt;<span class="cs__keyword">string</span>&gt;&nbsp;getCountText&nbsp;=&nbsp;()&nbsp;=&gt;&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;(counter&nbsp;&#43;=<span class="cs__number">1</span>).ToString();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Action&lt;<span class="cs__keyword">string</span>&gt;&nbsp;execute&nbsp;=&nbsp;(itemName)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OperationAssert.IsSingle(&nbsp;<span class="cs__string">&quot;追加ボタンを押す&quot;</span>,&nbsp;app.Element.WaitForFind(&nbsp;<span class="cs__string">&quot;(appBarAddButton)&quot;</span>,&nbsp;TimeSpan.FromSeconds(&nbsp;<span class="cs__number">0.5</span>&nbsp;)&nbsp;).MoveMouseTo().Click());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OperationAssert.TextIs(&nbsp;<span class="cs__string">&quot;name&nbsp;にテキストを入力&quot;</span>,&nbsp;itemName,&nbsp;app.Element.WaitForFind(&nbsp;<span class="cs__string">&quot;(name)&quot;</span>,&nbsp;TimeSpan.FromSeconds(&nbsp;<span class="cs__number">0.5</span>&nbsp;)&nbsp;).MoveMouseTo().SetText(&nbsp;<span class="cs__string">&quot;&quot;</span>&nbsp;).InputText(&nbsp;itemName&nbsp;)&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OperationAssert.TextIs(&nbsp;<span class="cs__string">&quot;Description&nbsp;にテキストを入力&quot;</span>,&nbsp;<span class="cs__string">&quot;Test&nbsp;Item&quot;</span>,&nbsp;app.Element.Find(&nbsp;<span class="cs__string">&quot;(Description)&quot;</span>&nbsp;).MoveMouseTo().SetText(&nbsp;<span class="cs__string">&quot;&quot;</span>&nbsp;).InputText(&nbsp;<span class="cs__string">&quot;Test&nbsp;Item&quot;</span>&nbsp;)&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OperationAssert.IsSingle(&nbsp;<span class="cs__string">&quot;OKボタンを押す&quot;</span>,&nbsp;app.Element.Find(&nbsp;<span class="cs__string">&quot;(OKButton)&quot;</span>&nbsp;).MoveMouseTo().Click()&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;execute(&nbsp;<span class="cs__string">&quot;TEST&nbsp;ITEM&quot;</span>&nbsp;&#43;&nbsp;getCountText()&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;execute(&nbsp;<span class="cs__string">&quot;TEST&nbsp;ITEM&quot;</span>&nbsp;&#43;&nbsp;getCountText()&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;execute(&nbsp;<span class="cs__string">&quot;TEST&nbsp;ITEM&quot;</span>&nbsp;&#43;&nbsp;getCountText()&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OperationAssert.CountIs(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;リストアイテムが3つ追加されて表示されていること&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">3</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.Element.Find(&nbsp;<span class="cs__string">&quot;(mainList)&quot;</span>&nbsp;).MoveMouseTo().Children(&nbsp;<span class="cs__string">&quot;{ListViewItem}&quot;</span>&nbsp;)&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;最後に目視のため&nbsp;0.5&nbsp;秒待ちます。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.Element.Sleep(&nbsp;TimeSpan.FromSeconds(&nbsp;<span class="cs__number">0.5</span>&nbsp;)&nbsp;).Count();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<span class="cs__com">//&nbsp;end&nbsp;using</span>&nbsp;
&nbsp;
&nbsp;
}&nbsp;<span class="cs__com">//&nbsp;end&nbsp;function</span></pre>
</div>
</div>
</h1>
<h1>UIMap を使ったテストの作り方</h1>
<p>コード化されたUIテストのプロジェクトを新規作成するとき、あるいはテストを追加するときに、録画機能を使用するか？確認するダイアログが表示されるため、これで録画機能を使用します。</p>
<p><img id="135265" src="135265-7.png" alt="" width="502" height="342" style="height:auto; max-width:100%"></p>
<p>録画用のツールウィンドウが起動したら、一番左の録画ボタンで「録画」を開始、一番右の「Generate Code」ボタンでその間の操作を UIMap.uitest ファイルへの保存すること出来ます。</p>
<p><img id="135266" src="135266-8.png" alt="" width="354" height="103" style="border:1px solid gray; height:auto; max-width:100%"></p>
<p>録画ボタンを押すより前に対象のアプリを起動し、録画ボタンを押してから、操作を行い、最後に「Generate Code」ボタンを押して保存します。その間の操作はおおよそ全て記録されてしまうので間違って操作しないために、テストシナリオを事前に用意して起きましょう（画面に表示するか印刷しておきます）。</p>
<p>検&#35388;を追加するには、真ん中の二重丸のボタンにカーソルを合わせて、検&#35388;したい TextBlock や Textbox の上までマウス左ボタンを押したままドラッグして、ボタンを放します。</p>
<p><img id="135267" src="135267-9.png" alt="" width="690" height="906" style="border:1px solid gray; height:auto; max-width:100%"></p>
<p>「Add Assertions 」ウィンドウの検&#35388;したい項目を選択して、右クリックメニューの「Add Assertions...」を押すと、検&#35388;方法を聞かれるので入力します。</p>
<p><img id="135268" src="135268-10.png" alt="" width="685" height="549" style="border:1px solid gray; height:auto; max-width:100%"></p>
<p>この例では リストに行が１つしかないことを確認しています。RowCount が AreEqual で 1 と同じ事を確認するように設定しています。</p>
<p><img id="135270" src="135270-11.png" alt="" width="364" height="300" style="border:1px solid gray; height:auto; max-width:100%"></p>
<p>検&#35388;の追加も最後に「Genelete Code」ボタンを押して UIMap.uitest ファイルに追加します。</p>
<h1>XAML x:Name 変更後の UIMap の修正方法</h1>
<p>SampleWpfApp の XAML を変更した場合、UIMap によるテストは動作しなくなります。</p>
<p>例えば、EditPage.xaml の Description を DescriptionBox に変更してビルドしてください。テストが成功しなくなります。</p>
<p>CodedUITestPlus を使用したテストは、x:Name を変更するだけで対応出来ます。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">OperationAssert.TextIs(&nbsp;<span class="cs__string">&quot;Description&nbsp;にテキストを入力&quot;</span>,&nbsp;<span class="cs__string">&quot;Test&nbsp;Item&quot;</span>,&nbsp;app.Element.Find(&nbsp;<span class="cs__string">&quot;(DescriptionBox)&quot;</span>&nbsp;).MoveMouseTo().SetText(&nbsp;<span class="cs__string">&quot;&quot;</span>&nbsp;).InputText(&nbsp;<span class="cs__string">&quot;Test&nbsp;Item&quot;</span>&nbsp;)&nbsp;);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">UIMap では、プロパティの Search Properties の AutomationId を変更します。（Friendly Name ではない点に注意）</div>
<p>&nbsp;</p>
<p><img id="135271" src="135271-12.png" alt="" width="946" height="904" style="border:1px solid gray; height:auto; max-width:100%"></p>
<p>簡単な変更の場合は UIMap での変更が全てのテストで使用されるので、修正は容易です。</p>
<p>XAML の構造が大幅に変更した場合は、もう一度録画ツールを使って、UIMap を作り直します。UIが完成するまでは CodedUITestPlus/CodesUIQuery でテストを作成し、テスト駆動開発し、完成後は UIMap で大規模なシナリオテストをするのが良いでしょう。</p>
<h1><span lang="en-US">UIMap </span><span lang="ja">でのテストのカスタマイズ方法</span></h1>
<p><span lang="en-US">UIMap </span><span lang="ja">の</span><span lang="en-US"> UI Actions
</span><span lang="ja">で操作を右クリックして表示される「</span><span lang="en-US">Move code to UIMap.cs</span><span lang="ja">」を実行すると、</span><span lang="en-US">UIMap.Designer.cs
</span><span lang="ja">にあったコードが最初は空だった</span><span lang="en-US">&nbsp; UIMap.cs </span>
<span lang="ja">に移動して、自由に編集可能になります。</span></p>
<p><img id="135272" src="135272-13.png" alt="" width="449" height="342" style="border:1px solid gray; height:auto; max-width:100%"></p>
<p><span lang="ja">検&#35388;（</span><span lang="en-US">Assersion</span><span lang="ja">）は</span><span lang="en-US"> UIMap.cs
</span><span lang="ja">に移動できません。</span><span lang="en-US">UI Control Map </span><span lang="ja">も変更出来ません。</span><span lang="en-US">C#
</span><span lang="ja">コードに変換してエディタと切り離せるのは</span><span lang="en-US"> UI Actions </span>
<span lang="ja">に表示されている「操作」だけです。</span></p>
<p><span lang="ja">一度移動すると UIMap には戻せません。サンプルでは一度移動してカスタマイズしたものと、移動する前のものを両方含めています。</span></p>
<h1>ステップアップのための練習課題</h1>
<ul>
<li>実際の開発をイメージして、テストが失敗するように SampleWpfApp を変更してみましょう。x:Name を変更する以外に、例えば編集画面のバリデーション（入力必須によるエラー表示）や、保存確認ページを追加してみましょう。
</li><li>CodedUITestPlus/CodetUIQuery を使ったテストで、アプリの変更に対応しましょう </li><li>UIMap を使ったテストで、アプリの変更に対応しましょう </li><li>「シナリオテスト」をイメージして、UIMapを使ったテストを量産してみましょう。 </li><li>CodedUITestPlus　には「メモ帳を起動する機能」と「クリップボードにテキストをコピーする機能」があります。SampleWpfApp に「内容をコピー」するボタンと機能を追加し、その内容を検&#35388;しましょう。また、メモ帳を起動して貼り付けるテストも追加してみましょう。
</li></ul>
