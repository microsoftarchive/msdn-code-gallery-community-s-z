# Unityでコンテナ登録時とコンテナからのオブジェクト取り出し時に値を設定する
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Unity
## Topics
- Unity入門
## Updated
- 06/04/2013
## Description

<h1>Unity入門の概要</h1>
<p>ここでは、Unity 3.0の基本的な使い方を説明します。Unity 3.0の詳細についてはCodePlexのUnityのサイトを参照してください。</p>
<ul>
<li>patterns &amp; practice - Unity<br>
<a href="http://unity.codeplex.com/">http://unity.codeplex.com/</a> </li></ul>
<p>このサンプルプログラムは、NuGetを使ってUnityとUnity.Interceptionを追加した状態で作成しています。.NET Frameworkのバージョンは4.5を使用しています。</p>
<h1>このサンプルプログラムの概要</h1>
<p>UnityContainerの基本的な利用方法は、RegisterTypeメソッドで型を登録しResolveメソッドで値を取り出す方法です。Unityでは、ほかのDIコンテナではあまり見ない機能として、コンテナへの型の登録時と取得時に、メソッドの引数としてコンテナで管理するオブジェクト間の依存関係や、定数などを指定する方法について説明します。</p>
<h1>登録時に設定できるもの</h1>
<p>コンテナへの型の登録時（RegisterTypeメソッドの呼び出し時）に型同士の依存関係や指定する値を指定できるのは、InjectionMember型を継承しているものです。InjectionMemberクラスを継承しているクラスは、以下のページで確認できます。</p>
<ul>
<li>InjectionMember Class<br>
<a href="http://msdn.microsoft.com/query/dev11.query?appId=Dev11IDEF1&l=JA-JP&k=k(Microsoft.Practices.Unity.InjectionMember);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5);k(DevLang-csharp)&rd=true">http://msdn.microsoft.com/query/dev11.query?appId=Dev11IDEF1&amp;l=JA-JP&amp;k=k(Microsoft.Practices.Unity.InjectionMember);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5);k(DevLang-csharp)&amp;rd=true</a>
</li></ul>
<p>このサンプルでは、プロパティへ設定する値を指定するInjectionPropertyと、コンストラクタへ設定する値を指定するInjectionConstructorを使用しています。このサンプルプログラムでUnityContainerに登録するクラスをいかにしめします。</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Messageプロパティを持つだけのシンプルなクラス
public class MessageProvider
{
    public string Message { get; set; }
}

// コンストラクタでMessageProviderクラスを受け取るクラス
public class Greeter
{
    private MessageProvider MessageProvider { get; set; }
    // デフォルト
    public Greeter()
    {
        this.MessageProvider = new MessageProvider { Message = &quot;Hello defualtt message.&quot; };
    }
    // コンストラクタでMessageProviderを指定することでメッセージを指定可能
    public Greeter(MessageProvider messageProvider)
    {
        this.MessageProvider = messageProvider;
    }

    // MessageProviderクラスのMessageプロパティの値を表示する
    public void Greet()
    {
        Console.WriteLine(this.MessageProvider.Message);
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Messageプロパティを持つだけのシンプルなクラス</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MessageProvider&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Message&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;コンストラクタでMessageProviderクラスを受け取るクラス</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Greeter&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;MessageProvider&nbsp;MessageProvider&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;デフォルト</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Greeter()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.MessageProvider&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MessageProvider&nbsp;{&nbsp;Message&nbsp;=&nbsp;<span class="cs__string">&quot;Hello&nbsp;defualtt&nbsp;message.&quot;</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;コンストラクタでMessageProviderを指定することでメッセージを指定可能</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Greeter(MessageProvider&nbsp;messageProvider)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.MessageProvider&nbsp;=&nbsp;messageProvider;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;MessageProviderクラスのMessageプロパティの値を表示する</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Greet()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__keyword">this</span>.MessageProvider.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
単純な文字列を保持するだけのMessageProviderクラスと、それを使ってメッセージを標準出力に表示するGreeterクラスです。Greeterクラスにはコンストラクタが2つあって、デフォルトコンストラクタでは、Hello default message.という文字列を出力するGreeterクラスとして初期化されます。MessageProviderを受け取るコンストラクタでは、出力するメッセージをカスタマイズできます。
<p></p>
<p>Unityで、Greeterクラスのインスタンスを作成するときにMessageProviderを使用するようにRegisterメソッドでInjectionConstructorを使用します。下記にコードを示します。</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using (var container = new UnityContainer())
{
    // 型の登録時に、プロパティの値を設定できる
    container.RegisterType&lt;MessageProvider&gt;(
        new InjectionProperty(&quot;Message&quot;, &quot;Hello world&quot;));
    // コンストラクタの値も設定できる。
    container.RegisterType&lt;Greeter&gt;(
        new InjectionConstructor(new ResolvedParameter&lt;MessageProvider&gt;()));
    // 普通にResolveした場合
    {
        // コンテナに登録した値を取得
        var greeter = container.Resolve&lt;Greeter&gt;();
        greeter.Greet(); // -&gt; Helo world
    }

    // Resolve時に値を注入
    {
        // コンテナから値を取得するタイミングでデフォルトの値を上書き可能
        var provider = container.Resolve&lt;MessageProvider&gt;(
            new PropertyOverride(&quot;Message&quot;, &quot;こんにちは世界&quot;));
        // コンストラクタの値も変更可能
        var greeter = container.Resolve&lt;Greeter&gt;(
            new ParameterOverride(&quot;messageProvider&quot;, provider));
        greeter.Greet(); // -&gt; こんにちは世界 
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;(var&nbsp;container&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UnityContainer())&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;型の登録時に、プロパティの値を設定できる</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;container.RegisterType&lt;MessageProvider&gt;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;InjectionProperty(<span class="cs__string">&quot;Message&quot;</span>,&nbsp;<span class="cs__string">&quot;Hello&nbsp;world&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;コンストラクタの値も設定できる。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;container.RegisterType&lt;Greeter&gt;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;InjectionConstructor(<span class="cs__keyword">new</span>&nbsp;ResolvedParameter&lt;MessageProvider&gt;()));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;普通にResolveした場合</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;コンテナに登録した値を取得</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;greeter&nbsp;=&nbsp;container.Resolve&lt;Greeter&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;greeter.Greet();&nbsp;<span class="cs__com">//&nbsp;-&gt;&nbsp;Helo&nbsp;world</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Resolve時に値を注入</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;コンテナから値を取得するタイミングでデフォルトの値を上書き可能</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;provider&nbsp;=&nbsp;container.Resolve&lt;MessageProvider&gt;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;PropertyOverride(<span class="cs__string">&quot;Message&quot;</span>,&nbsp;<span class="cs__string">&quot;こんにちは世界&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;コンストラクタの値も変更可能</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;greeter&nbsp;=&nbsp;container.Resolve&lt;Greeter&gt;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;ParameterOverride(<span class="cs__string">&quot;messageProvider&quot;</span>,&nbsp;provider));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;greeter.Greet();&nbsp;<span class="cs__com">//&nbsp;-&gt;&nbsp;こんにちは世界&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p></p>
<p>InjectionConstructorの引数にResolveParameterというクラスを指定して、コンテナからどのようなものを取得して渡すのか設定しています。MessageProviderクラスの登録では、InjectionPropertyを使ってMessageプロパティにHello worldという文字列を設定するようにしています。</p>
<p>コードの後半部では、RegisterTypeメソッドで指定した設定をResolve時に上書きしています。MessageProviderをコンテナから取得するときにPropertyOverrideクラスを指定することでMessageプロパティの価を変更しています。同じように、Greeterクラスの取得時にもParameterOverrideクラスを使ってコンストラクタ引数の値を強制的に指定しています。</p>
<p>この****Override系のクラスは、ResolverOverrideクラスを継承しているクラスです。ResolverOverrideクラスを継承しているクラスは、下記のページで確認できます。</p>
<ul>
<li>ResolverOverride Class<br>
<a href="http://msdn.microsoft.com/query/dev11.query?appId=Dev11IDEF1&l=JA-JP&k=k(Microsoft.Practices.Unity.ResolverOverride);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5);k(DevLang-csharp)&rd=true">http://msdn.microsoft.com/query/dev11.query?appId=Dev11IDEF1&amp;l=JA-JP&amp;k=k(Microsoft.Practices.Unity.ResolverOverride);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5);k(DevLang-csharp)&amp;rd=true</a>
</li></ul>
<h1>まとめ</h1>
<p>ここでは、RegisterTypeとResolveメソッドで自由に値を設定する方法と、設定した値を上書きしてコンテナからインスタンスを取得する方法を示しました。この方法は、DIコンテナとしては、イレギュラーな使い方だと個人的には思っていますが、知っているとどうしようもないときの最後の逃げの一手として役立つと思うので頭の片隅に置いておくと良いと思います。</p>
<p>&nbsp;</p>
