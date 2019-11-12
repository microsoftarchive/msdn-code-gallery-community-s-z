# Unityで飛行体を操作したい
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Unity
## Topics
- Unity
## Updated
- 01/16/2015
## Description

<h1>サンプルプログラムの概要</h1>
<p>このサンプルプログラムは、Unityを使って飛行物体の3Dモデルをふわふわとした感じを出しながら操作をする方法を示したサンプルプログラムになります。</p>
<p>サンプルプログラムを実行すると、以下のように飛行物体が浮いている状態ではじまります。ふわふわとした感じのアニメーションをともなった状態で表示されます。</p>
<p><img id="132574" src="132574-%e7%84%a1%e9%a1%8c.png" alt="" width="228" height="177"></p>
<p>この飛行物体は以下の方法で操作することができます。</p>
<ul>
<li>左移動：Aキーか矢印左キー </li><li>右移動：Dキーか矢印右キー </li><li>上移動：Wキーか矢印上キー </li><li>下移動：Sキーか矢印下キー </li><li>前移動：マウスの左クリック </li><li>後移動：マウスの右クリック </li></ul>
<p>基本的に空中に浮遊している間はふわふわとしたアニメーションをしていて、地面に接地するとアニメーションは停止します。また、前後左右に移動するときは、微妙にそちらの方向に傾いて移動します。</p>
<h1>サンプルプログラムのポイント</h1>
<p>このサンプルプログラムのポイントとなる箇所を以下に示します。</p>
<h2>相対位置による飛行物体のアニメーション</h2>
<p>飛行物体のオブジェのアニメーションは、親に対する絶対座標になるため、空のオブジェクトを作り、その中に飛行物体を設置してからアニメーションを設定することで相対位置によるアニメーションにしています。アニメーションを確認するには、HierarchyのFlyingObjectのspaceShipを選択してからAnimationウィンドウを確認してください。</p>
<h2>CharacterControllerを使用しない地面との設置判定</h2>
<p>このサンプルはCharacterControllerを使用せずにrigidbodyを使用しています。rigidbodyを使った状態で接地しているかどうか判定するために、地面と飛行物体のOnCollisionEnterとOnCollisionExitを使用しています。飛行物体は、親のFlyingObjectにBoxColliderを設定して当たり判定が発生するように設定しています。</p>
<p>地面にはGroundというLayerを設定して、そのLayerとぶつかったかどうかで地面にいるかどうかを判定しています。該当箇所のコードはFlyngObject.csの以下のようなコードになります。</p>
<p></p>
<h2 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnCollisionEnter(Collision&nbsp;collision)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;g&nbsp;=&nbsp;(collider.gameObject.layer&nbsp;&amp;&nbsp;(<span class="cs__number">1</span>&nbsp;&lt;&lt;&nbsp;LayerMask.NameToLayer(<span class="cs__string">&quot;Ground&quot;</span>)))&nbsp;!=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.isGrounded&nbsp;=&nbsp;!g;&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnCollisionExit(Collision&nbsp;collision)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;g&nbsp;=&nbsp;(collider.gameObject.layer&nbsp;&amp;&nbsp;(<span class="cs__number">1</span>&nbsp;&lt;&lt;&nbsp;LayerMask.NameToLayer(<span class="cs__string">&quot;Ground&quot;</span>)))&nbsp;!=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.isGrounded&nbsp;=&nbsp;g;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</h2>
<p></p>
<h2>&nbsp;進行方向に少し傾ける</h2>
<p>進行方向に少しオブジェクトを傾ける処理もこの中では追加しています。押されたキーから、rigidbodyのvelocityを計算して、velocityの状態を見て物体のrotationを調整しています。コードはFlyngObject.csの以下のようなコードになります。</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">void</span>&nbsp;Update()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;velocity&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Vector3(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;velocity.x&nbsp;&#43;=&nbsp;Input.GetAxis(<span class="cs__string">&quot;Horizontal&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;velocity.y&nbsp;&#43;=&nbsp;Input.GetAxis(<span class="cs__string">&quot;Vertical&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Input.GetButton(<span class="cs__string">&quot;Fire1&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;velocity.z&nbsp;&#43;=&nbsp;<span class="cs__number">1</span>.0f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Input.GetButton(<span class="cs__string">&quot;Fire2&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;velocity.z&nbsp;&#43;=&nbsp;-<span class="cs__number">1</span>.0f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.rigidbody.velocity&nbsp;=&nbsp;velocity&nbsp;*&nbsp;<span class="cs__number">500</span>&nbsp;*&nbsp;Time.deltaTime;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;originalRotation&nbsp;=&nbsp;<span class="cs__keyword">this</span>.rigidbody.rotation;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;zEular&nbsp;=&nbsp;<span class="cs__number">0</span>.0f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.rigidbody.velocity.x&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;zEular&nbsp;=&nbsp;-<span class="cs__number">5</span>.0f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.rigidbody.velocity.x&nbsp;&lt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;zEular&nbsp;=&nbsp;<span class="cs__number">5</span>.0f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;xEular&nbsp;=&nbsp;<span class="cs__number">0</span>.0f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.rigidbody.velocity.z&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xEular&nbsp;=&nbsp;<span class="cs__number">5</span>.0f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.rigidbody.velocity.z&nbsp;&lt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xEular&nbsp;=&nbsp;-<span class="cs__number">5</span>.0f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;eular&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Vector3(xEular,&nbsp;<span class="cs__number">0</span>,&nbsp;zEular);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.rigidbody.rotation&nbsp;=&nbsp;Quaternion.Euler(eular);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.animator.SetBool(<span class="cs__string">&quot;Flying&quot;</span>,&nbsp;!<span class="cs__keyword">this</span>.isGrounded);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
