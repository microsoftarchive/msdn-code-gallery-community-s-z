# WPFでボタンの見た目をコントロールテンプレートを使ってカスタマイズする
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- WPF Styling
## Updated
- 05/29/2013
## Description

<h1>サンプルプログラムの概要</h1>
<p>このサンプルプログラムは、Windows Presentation Foundationのテンプレート機能を使ってボタンの見た目をカスタマイズする方法を示しています。このボタンを作成する際にはXAMLは直接いじらずにBlend for Visual Studio 2012を使用して、ボタンを作成しました。</p>
<p>コントロールの見た目の変更の参考にしてください。このサンプルプログラムを実行した様子を下図に示します。</p>
<p><img id="82840" src="82840-ws000003.jpg" alt="" width="417" height="173"></p>
<p>左右のボタンには、サンプロプログラム内で定義した同じスタイルを適用しています。左のボタンが通常のボタンで、右側のボタンがIsEnabledプロパティをFalseにした状態のボタンです。また、マウスオーバー時のボタンの色の変更にも対応しています。</p>
<p><img id="82841" src="82841-ws000004.jpg" alt="" width="231" height="171"></p>
<p>スクリーンショットではわかりづらいですが、ボタンをクリックすると押し込んだ感じを出すためにボタンの位置が若干右下に移動するような動作も設定しています。</p>
<p><img id="82842" src="82842-ws000005.jpg" alt="" width="218" height="172"></p>
<h1>サンプルプログラムの作成過程</h1>
<h2>構成要素の配置</h2>
<p>Windows Presentation Foundationでコントロールを自作する場合には、見た目を作成してコントロール化する方法が簡単に行えて便利です。Blend for Visual Studio 2012でWPFアプリケーションを作成したら、まず画面にこのような見た目のコントロールを作りたいと感じるままに図形などを配置します。</p>
<p>今回のサンプルではEllipseを3つ重ねています。1つ目のEllipseは、ベースとなる青い楕円で、2つ目のEllipseは、楕円が光っているように見せるためのてかりを表しています。円形の白色のグラデーションで外側にいくほど透明度をあげるようにして、Opacityプロパティで光の部分の楕円事態の透明度を薄くすることで光っている感じを出すことができます。3つ目のEllipseは、未選択状態のときに表示する楕円で、普段は非表示にしています。表示されたときにグレーの半透明の色の楕円が覆いかぶさるように配置します。</p>
<p>XAMLでは、以下のようになっています。</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Ellipse</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ellipse&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;192&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Stroke</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;113&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Fill</span>=<span class="xaml__attr_value">&quot;#FF9494FF&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
<span class="xaml__tag_start">&lt;Ellipse</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;116&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Opacity</span>=<span class="xaml__attr_value">&quot;0.445&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;49,10,0,0&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;34&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Ellipse</span>.Fill<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RadialGradientBrush</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GradientStop</span>&nbsp;<span class="xaml__attr_name">Color</span>=<span class="xaml__attr_value">&quot;White&quot;</span>&nbsp;<span class="xaml__attr_name">Offset</span>=<span class="xaml__attr_value">&quot;0&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;GradientStop</span>&nbsp;<span class="xaml__attr_name">Color</span>=<span class="xaml__attr_value">&quot;#7EFFFFFF&quot;</span>&nbsp;<span class="xaml__attr_name">Offset</span>=<span class="xaml__attr_value">&quot;1&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/RadialGradientBrush&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Ellipse.Fill&gt;&nbsp;
<span class="xaml__tag_end">&lt;/Ellipse&gt;</span>&nbsp;
<span class="xaml__tag_start">&lt;ContentPresenter</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;{TemplateBinding&nbsp;HorizontalContentAlignment}&quot;</span>&nbsp;<span class="xaml__attr_name">RecognizesAccessKey</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__attr_name">SnapsToDevicePixels</span>=<span class="xaml__attr_value">&quot;{TemplateBinding&nbsp;SnapsToDevicePixels}&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;{TemplateBinding&nbsp;VerticalContentAlignment}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
<span class="xaml__tag_start">&lt;Ellipse</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ellipse1&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;113&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Top&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;192&quot;</span>&nbsp;<span class="xaml__attr_name">Fill</span>=<span class="xaml__attr_value">&quot;#9F9B9B9B&quot;</span>&nbsp;<span class="xaml__attr_name">Visibility</span>=<span class="xaml__attr_value">&quot;Hidden&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;通常は、手書きではなくBlend for Visual Studio 2012を使用してこのような要素の配置や色を作成することになると思います。これらのEllipseをGridでまとめたあとに右クリックメニューからコントロールの作成を行いButtonに変換します。ボタンに変換するとContentPresenterが自動的に挿入されるので、必要に応じて位置調整などを行います。</div>
<div class="endscriptcode"></div>
<h2 class="endscriptcode">状態に応じた表示の定義</h2>
<div class="endscriptcode">Blend for Visual Studio 2012の状態ウィンドウでは、コントロールのステータスの応じて見た目を変えることが簡単にできるようになっています。コントロールで定義されている状態を選択してデザイナやプロパティウィンドウでプロパティの値を変更するだけで設定は完了します。ボタンコントロールでは以下のような状態が定義されています。</div>
<div class="endscriptcode"><img id="82843" src="82843-ws000006.jpg" alt="" width="282" height="409"></div>
<div class="endscriptcode">今回のサンプルではMouseOver時に色を変更するという設定と、Pressed時に少し左下に移動させるという設定と、Disabled時に普段は非表示にしている半透明グレーの楕円を表示するように設定しました。</div>
<div class="endscriptcode">ぜひ、サンプルをダウンロードしてBlend for Visual Studio 2012で触ってみてください。</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<p></p>
<p>&nbsp;</p>
