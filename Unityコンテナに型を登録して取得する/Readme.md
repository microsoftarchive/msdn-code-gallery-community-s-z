# Unityコンテナに型を登録して取得する
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
<h1>Unityの基本</h1>
<p>Unityは、DIコンテナの一種で、Enterprise Libraryでも使用されています。Unity 3.0になってコンテナへの型の登録の簡略化などかなり機能が追加され使いやすくなりました。UnityのコンテナはMicrosoft.Practices.Unity.UnityContainerクラスをインスタンス化して、そこに型を登録して使用します。一番基本的な方法は、RegisterTypeメソッドで型の登録を行い、Resolveメソッドでコンテナからインスタンスを取得して使用します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using (var container = new UnityContainer())
{
    // Component1の登録
    container.RegisterType&lt;Component1&gt;();

    var componentInstance = container.Resolve&lt;Component1&gt;();
    // コンテナから取得したインスタンスを使って処理を行う
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;(var&nbsp;container&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UnityContainer())&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Component1の登録</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;container.RegisterType&lt;Component1&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;componentInstance&nbsp;=&nbsp;container.Resolve&lt;Component1&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;コンテナから取得したインスタンスを使って処理を行う</span>&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>デフォルトでは、Resolveするたびに新しいインスタンスが返されます。しかし、コンテナへの型の登録時にコンテナにどのようにインスタンス管理を行うか指定することができます。RegisterTypeメソッドのLifetimeManagerを受け取るタイプのオーバーロードを使うとコンテナがどのようにインスタンスを管理するか指定できます。下記の例では、ContainerControlledLifetimeManagerを指定しています。ContainerControlledLifetimeManagerは、同じUnityContainerから取得したインスタンスは、同一のものになります。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using (var container = new UnityContainer())
{
    container.RegisterType&lt;Component1&gt;();
    var componentInstance = container.Resolve&lt;Component1&gt;();
    var componentInstance2 = container.Resolve&lt;Component1&gt;();
    Console.WriteLine(object.ReferenceEquals(componentInstance, componentInstance2)); // False
}

using (var container = new UnityContainer())
{
    container.RegisterType&lt;Component1&gt;(new ContainerControlledLifetimeManager());
    var componentInstance = container.Resolve&lt;Component1&gt;();
    var componentInstance2 = container.Resolve&lt;Component1&gt;();
    Console.WriteLine(object.ReferenceEquals(componentInstance, componentInstance2)); // True
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;(var&nbsp;container&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UnityContainer())&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;container.RegisterType&lt;Component1&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;componentInstance&nbsp;=&nbsp;container.Resolve&lt;Component1&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;componentInstance2&nbsp;=&nbsp;container.Resolve&lt;Component1&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__keyword">object</span>.ReferenceEquals(componentInstance,&nbsp;componentInstance2));&nbsp;<span class="cs__com">//&nbsp;False</span>&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;(var&nbsp;container&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UnityContainer())&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;container.RegisterType&lt;Component1&gt;(<span class="cs__keyword">new</span>&nbsp;ContainerControlledLifetimeManager());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;componentInstance&nbsp;=&nbsp;container.Resolve&lt;Component1&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;componentInstance2&nbsp;=&nbsp;container.Resolve&lt;Component1&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__keyword">object</span>.ReferenceEquals(componentInstance,&nbsp;componentInstance2));&nbsp;<span class="cs__com">//&nbsp;True</span>&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;LifetimeManagerには代表的なものとして、コンテナ内で同一の値を返すContainerControlledLifetimeManagerとデフォルトで使用されるPerResolveLifetimeManagerや、スレッド単位にインスタンスの管理を行うPerThreadLifetimeManagerがあります。またASP.NET MVCで使用するためのリクエスト単位でインスタンスの管理を行うLifetimeManagerも別のNuGetパッケージで提供されています。</div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode">まとめ</h1>
<div class="endscriptcode">ここでのまとめをいかに示します。</div>
<ul>
<li>
<div class="endscriptcode">UnityはDIコンテナ</div>
</li><li>
<div class="endscriptcode">RegisterTypeで型を登録</div>
</li><li>
<div class="endscriptcode">Resolveでインスタンスを取得</div>
</li><li>
<div class="endscriptcode">LifetimeManagerを使用してコンテナがインスタンスを管理する方法を指定できる</div>
</li></ul>
<p class="endscriptcode">&nbsp;</p>
