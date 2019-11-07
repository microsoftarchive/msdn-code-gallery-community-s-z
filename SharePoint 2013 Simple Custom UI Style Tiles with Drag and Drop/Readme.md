# SharePoint 2013: Simple Custom UI Style Tiles with Drag and Drop
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- SharePoint
- Javascript
- Sharepoint Online
- Visual Studio 2012
- SharePoint Server 2013
- SharePoint Foundation 2013
- apps for Office
- apps for SharePoint
- SharePoint  2013
- SharePoint 2013
- SharePoint Apps
- Client Object Model SharePoint 2013
## Topics
- SharePoint
- EcmaScript
- SharePoint client object model (CSOM)
- apps for Office
- apps for SharePoint
- SharePoint 2013
- SharePoint Apps
## Updated
- 03/24/2014
## Description

<h1>Introduction</h1>
<p>This&nbsp;simple App shows how we can use&nbsp; jQuery/Client Object Model&nbsp;supported by a Custom List to create a custom Tiles solution where is possible to manage and reorganize the position of the Tiles .</p>
<p>This solution is based on the SharePoint-hosted app template provided by Visual Studio 2012.</p>
<p>for more info about this simple app solution&nbsp;can view the following <a href="http://aaclage.blogspot.ch/2013/09/example-custom-ui-metro-style-tiles.html" target="_blank">
link&nbsp;</a></p>
<h1><span>Building the Sample</span></h1>
<p><em>&nbsp;</em></p>
<p>This sample requires the following:</p>
<ul>
<li>Visual Studio 2012 </li><li>Office Developer Tools for Visual Studio 2012 </li></ul>
<p>Either of the following:</p>
<ul>
<li>Access to an Office 365 Enterprise site that has been configured to host apps (recommended).
</li><li>SharePoint Server 2013 configured to host apps, and with a Developer Site Collection already created.
</li></ul>
<h2>Installation</h2>
<ul>
<li>Open AppTiles.sln with Visual Studio 2012 </li><li>Include SharePoint Site URL in CustomLinks Project. </li><li>Click F5 to Deploy the app&nbsp;in your SharePoint Site. </li><li>Access to your SharePoint 2013 Site or Office 365 SharePoint Site and click </li></ul>
<h2>Manage&nbsp;Tiles Page</h2>
<ul>
<li>Tiles are display </li><li>Tiles can be edit </li></ul>
<h2>Manage List Tiles</h2>
<ul>
<li>
<p>The Tiles List is able to add new, Edit and Delete Item.</p>
</li><li>
<p>The List is able to manage the number of columns&nbsp;where the Tiles are display&nbsp;in the option&nbsp;&quot;Tiles &gt; List Ribbon &gt; Manage Tiles Columns&quot;.&nbsp;</p>
</li></ul>
<h2><span style="font-size:20px; font-weight:bold">Description</span></h2>
<p>This solution creates a Custom Tiles Page View supported by a Custom List.</p>
<p><span style="font-size:x-small"><img id="95862" src="95862-png%3bbase641e062f8c4a652c01.png" alt="" width="436" height="270" style="margin-left:auto; display:block; margin-right:auto"></span></p>
<p>The following code shows the jquery methods used to create the efects &quot;Jquery-UI&quot;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">JavaScript</div>
</div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">function TileShadow() {
    $('.Tile-Description').parent().mouseenter(function () {
        $(this).children('.Tile-Description').css('top', '125px');
        $(this).children('.Tile-Description').animate({ top: '-=125' }, 500);
    }).mouseleave(function () {
        $(this).children('.Tile-Description').css('top', '0px');
        $(this).children('.Tile-Description').animate({ top: '&#43;=125' }, 500);
    });

    $(function () {
        $(&quot;.column&quot;).sortable({
            connectWith: &quot;.column&quot;,
            stop: function (event, ui) {
                
                $(function () {
                    var count = 1;
                    $('.tile').each(function (i, v) {
                        var $this = $(this);
                        var Order = count &#43; &quot;;#&quot; &#43; $(this).parent().attr('id');
                        SP.SOD.executeFunc('sp.js', 'SP.ClientContext', updateListItem($(this).attr('id'), Order));
                        count = count &#43; 1;
                        if ($(this).width() === 320)
                        {
                            $(this).parent().width(340);
                        }
                        $(this).children().css('top', '125px');
                    });
                })
                SP.SOD.executeFunc('sp.js', 'SP.ClientContext', function () { SP.UI.Notify.addNotification('The Tiles are updated!', false); });
                // alert(ui.item.attr('id'));
            }
        });
    });
}</pre>
<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;TileShadow()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'.Tile-Description'</span>).parent().mouseenter(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).children(<span class="js__string">'.Tile-Description'</span>).css(<span class="js__string">'top'</span>,&nbsp;<span class="js__string">'125px'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).children(<span class="js__string">'.Tile-Description'</span>).animate(<span class="js__brace">{</span>&nbsp;top:&nbsp;<span class="js__string">'-=125'</span>&nbsp;<span class="js__brace">}</span>,&nbsp;<span class="js__num">500</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>).mouseleave(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).children(<span class="js__string">'.Tile-Description'</span>).css(<span class="js__string">'top'</span>,&nbsp;<span class="js__string">'0px'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).children(<span class="js__string">'.Tile-Description'</span>).animate(<span class="js__brace">{</span>&nbsp;top:&nbsp;<span class="js__string">'&#43;=125'</span>&nbsp;<span class="js__brace">}</span>,&nbsp;<span class="js__num">500</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;.column&quot;</span>).sortable(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connectWith:&nbsp;<span class="js__string">&quot;.column&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stop:&nbsp;<span class="js__operator">function</span>&nbsp;(event,&nbsp;ui)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;count&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'.tile'</span>).each(<span class="js__operator">function</span>&nbsp;(i,&nbsp;v)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;$<span class="js__operator">this</span>&nbsp;=&nbsp;$(<span class="js__operator">this</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;Order&nbsp;=&nbsp;count&nbsp;&#43;&nbsp;<span class="js__string">&quot;;#&quot;</span>&nbsp;&#43;&nbsp;$(<span class="js__operator">this</span>).parent().attr(<span class="js__string">'id'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SP.SOD.executeFunc(<span class="js__string">'sp.js'</span>,&nbsp;<span class="js__string">'SP.ClientContext'</span>,&nbsp;updateListItem($(<span class="js__operator">this</span>).attr(<span class="js__string">'id'</span>),&nbsp;Order));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;count&nbsp;=&nbsp;count&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($(<span class="js__operator">this</span>).width()&nbsp;===&nbsp;<span class="js__num">320</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).parent().width(<span class="js__num">340</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).children().css(<span class="js__string">'top'</span>,&nbsp;<span class="js__string">'125px'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SP.SOD.executeFunc(<span class="js__string">'sp.js'</span>,&nbsp;<span class="js__string">'SP.ClientContext'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;SP.UI.Notify.addNotification(<span class="js__string">'The&nbsp;Tiles&nbsp;are&nbsp;updated!'</span>,&nbsp;false);&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;alert(ui.item.attr('id'));</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<h2 class="endscriptcode">&nbsp;Source Code files</h2>
<p><span style="font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; white-space:pre-wrap; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">Pages</span></p>
<ul style="margin-bottom:0pt; margin-top:0pt">
<li dir="ltr" style="list-style-type:disc; font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">
<div dir="ltr" style="margin-bottom:0pt; margin-top:0pt; line-height:1.15"><span style="font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; white-space:pre-wrap; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">Default.aspx</span></div>
</li><li dir="ltr" style="list-style-type:disc; font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">
<div dir="ltr" style="margin-bottom:0pt; margin-top:0pt; line-height:1.15"><span style="font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; white-space:pre-wrap; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">TilesColumns.aspx</span></div>
</li></ul>
<div dir="ltr" style="margin-bottom:0pt; margin-top:0pt; line-height:1.15"><span style="font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; white-space:pre-wrap; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">Content</span></div>
<ul style="margin-bottom:0pt; margin-top:0pt">
<li dir="ltr" style="list-style-type:disc; font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">
<div dir="ltr" style="margin-bottom:0pt; margin-top:0pt; line-height:1.15"><span style="font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; white-space:pre-wrap; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">App.css</span></div>
</li><li dir="ltr" style="list-style-type:disc; font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">
<div dir="ltr" style="margin-bottom:0pt; margin-top:0pt; line-height:1.15"><span style="font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; white-space:pre-wrap; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">jquery-ui.css</span></div>
</li></ul>
<div dir="ltr" style="margin-bottom:0pt; margin-top:0pt; line-height:1.15"><span style="font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; white-space:pre-wrap; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">Scripts</span></div>
<ul style="margin-bottom:0pt; margin-top:0pt">
<li dir="ltr" style="list-style-type:disc; font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">
<div dir="ltr" style="margin-bottom:0pt; margin-top:0pt; line-height:1.15"><span style="font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; white-space:pre-wrap; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">app.js</span></div>
</li><li dir="ltr" style="list-style-type:disc; font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">
<div dir="ltr" style="margin-bottom:0pt; margin-top:0pt; line-height:1.15"><span style="font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; white-space:pre-wrap; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">jquery-ui.js</span></div>
</li></ul>
<div dir="ltr" style="margin-bottom:0pt; margin-top:0pt; line-height:1.15"><span style="font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; white-space:pre-wrap; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">Images</span></div>
<ul style="margin-bottom:0pt; margin-top:0pt">
<li dir="ltr" style="list-style-type:disc; font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">
<div dir="ltr" style="margin-bottom:0pt; margin-top:0pt; line-height:1.15"><span style="font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; white-space:pre-wrap; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">*.png</span></div>
</li></ul>
<div dir="ltr" style="margin-bottom:0pt; margin-top:0pt; line-height:1.15"><span style="font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; white-space:pre-wrap; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">List
 Item Template</span></div>
<ul style="margin-bottom:0pt; margin-top:0pt">
<li dir="ltr" style="list-style-type:disc; font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">
<div dir="ltr" style="margin-bottom:0pt; margin-top:0pt; line-height:1.15"><span style="font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; white-space:pre-wrap; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">Tiles</span></div>
<ul style="margin-bottom:0pt; margin-top:0pt">
<li dir="ltr" style="list-style-type:circle; font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">
<div dir="ltr" style="margin-bottom:0pt; margin-top:0pt; line-height:1.15"><span style="font-size:15px; font-family:Arial; font-variant:normal; vertical-align:baseline; white-space:pre-wrap; font-weight:normal; color:black; font-style:normal; text-decoration:none; background-color:transparent">Ribbon
 &ldquo;TilesColumns&rdquo;</span></div>
</li></ul>
</li></ul>
<h2 class="endscriptcode">&nbsp;Updates</h2>
<ul>
<li>Performance to SP.Objects was improved </li><li>Removed extra files </li><li>New Color options </li><li>New Ribbon Tile&nbsp;option in Page </li><li>Rounded Tiles (Round Option) </li></ul>
<p><img id="110404" src="110404-tileribbon1.png" alt="" width="223" height="336"></p>
