# WebGl/Three.JS with TypeScript
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- three js
- TypeScript
## Topics
- three.js
## Updated
- 11/23/2018
## Description

<h1>Introduction</h1>
<p>Base on this JS example <a href="https://github.com/mrdoob/three.js/blob/master/examples/webgl_shadowmap_pointlight.html">
https://github.com/mrdoob/three.js/blob/master/examples/webgl_shadowmap_pointlight.html</a></p>
<p><a href="https://threejs.org/examples/#webgl_shadowmap_pointlight">https://threejs.org/examples/#webgl_shadowmap_pointlight</a></p>
<p>was built <strong>TypeScript </strong>project which wrapped in Visual Studio 2017. (Please use Admin Mode for open this project) If you do not like it, just create
<strong>indext.html</strong> file and copy content from <strong>Default.aspx</strong> and use it, reuse same folder structure and files.</p>
<p>This project includes the full three.js library, OrbitControls.js library, and type definition &nbsp;<strong>three.d.ts</strong> (see folder).&nbsp; Inside file
<strong>three-core.d.ts</strong> was added manually interface type and class for <strong>
customDistanceMaterial.</strong></p>
<h1><img id="217955" src="https://i1.code.msdn.s-msft.com/windowsapps/webglthreejs-with-83fed8a5/image/file/217955/1/ezgif.com-resize.gif" alt="" width="612" height="382"></h1>
<h1><span>Building the Sample</span></h1>
<p><em>Run VS2017 in Admin mode, VS automatically&nbsp;downloads one NuGet package.</em></p>
<p><em>Go to properties and set web.application</em></p>
<p><img id="217953" src="217953-three.png" alt="" width="1269" height="409"></p>
<p><em>&nbsp;</em></p>
<p>Pay your attention to TypeScript properties. Name of the output file will be <strong>
main.js&nbsp;</strong></p>
<p>&nbsp;</p>
<p><img id="217954" src="217954-threeamd.png" alt="" width="1248" height="558"></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>How does this sample solve the problem?</em></p>
<p><em>You can include <em><strong>code snippets,&nbsp;</strong></em><strong>images</strong>,
<strong>videos</strong>. &nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;sl:&nbsp;smpl.ShadowMapPointlight;&nbsp;
&nbsp;
window.onload&nbsp;=&nbsp;()&nbsp;=&gt;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sl&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;smpl.ShadowMapPointlight();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sl.animate();&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
window.onresize&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sl.onWindowResize();&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<ul>
<li>More Information </li></ul>
<p>Three.js allows the creation of <a class="mw-redirect" title="Graphical Processing Unit" href="https://en.wikipedia.org/wiki/Graphical_Processing_Unit">
Graphical Processing Unit</a> (GPU)-accelerated 3D animations using the <a title="JavaScript" href="https://en.wikipedia.org/wiki/JavaScript">
JavaScript</a> language as part of a <a title="Website" href="https://en.wikipedia.org/wiki/Website">
website</a> without relying on proprietary <a class="mw-redirect" title="Browser plugin" href="https://en.wikipedia.org/wiki/Browser_plugin">
browser plugins</a>.<sup id="cite_ref-3" class="reference"><a href="https://en.wikipedia.org/wiki/Three.js#cite_note-3">[3]</a></sup><sup id="cite_ref-4" class="reference"><a href="https://en.wikipedia.org/wiki/Three.js#cite_note-4">[4]</a></sup> This
 is possible due to the advent of <a title="WebGL" href="https://en.wikipedia.org/wiki/WebGL">
WebGL</a>.<sup id="cite_ref-5" class="reference"><a href="https://en.wikipedia.org/wiki/Three.js#cite_note-5">[5]</a></sup></p>
<p>High-level libraries such as Three.js or <a title="GLGE (programming library)" href="https://en.wikipedia.org/wiki/GLGE_(programming_library)">
GLGE</a>, SceneJS, PhiloGL or a number of other libraries make it possible to author complex 3D computer animations that display in the browser without the effort required for a traditional standalone application or a plugin.<sup id="cite_ref-6" class="reference"><a href="https://en.wikipedia.org/wiki/Three.js#cite_note-6">[6]</a></sup></p>
