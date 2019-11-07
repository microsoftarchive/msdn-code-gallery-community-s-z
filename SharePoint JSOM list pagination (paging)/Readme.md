# SharePoint JSOM list pagination (paging)
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Javascript
- SharePoint Server 2013
- apps for SharePoint
- JSOM
## Topics
- EcmaScript
- SharePoint 2013
- JSOM
## Updated
- 07/20/2013
## Description

<h1>Introduction</h1>
<p>If you work with a list that contains a lot of items, then you need to access the list items in chunks (UI experts/developers called it
<em>paging</em> or <em>pagination</em>).</p>
<p>SharePoint list pagination requires two parameters, the<strong> <em>size of the items page</em></strong> and the
<em><strong>requested page info</strong>. </em>This code have some of samples to show you how to work with SharePoint List paging.</p>
<p>You can use this code with your JSOM custom application. Also all types of SharePoint Client Side Code have the same concepts, then you can convert the code to any SharePoint custom solution easily.</p>
<p><strong><br>
</strong></p>
<h1>Prerequisites</h1>
<p>The code packaged as <em>SharePoint 2013 App. </em>then you shall use Visual Studio 2012 and
<a href="http://msdn.microsoft.com/en-us/office/apps/fp123627.aspx">Microsoft Office Developer Tools for Visual Studio 2012</a>.</p>
<p>As I mentioned above, this code packaged as <em>SharePoint 2013 App. </em>but it's easy to add it to your custom code rather than it&rsquo;s an App or not (Web part, usercontrols, application pages ....), you will find all JavaScript files that you want
 inside the<strong> script folder.</strong></p>
<p>&nbsp;</p>
<h1>Code Samples</h1>
<p>&nbsp;</p>
<h3><span style="font-size:20px; font-weight:bold"><span style="font-size:large">Sample one (</span></span>Basic Paging<span style="font-size:20px; font-weight:bold"><span style="font-size:large">)</span><br>
</span></h3>
<p>This code sample request a list in chunks of 4 items, then the items are written on the page inside html table as the following image &amp; code:</p>
<p>&nbsp;</p>
<p><img id="92625" src="92625-sharepoint%20jsom%20list%20pagination%20(paging).png" alt="" width="313" height="228"></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">var context,
    web,
    spItems,
    position,
    nextPagingInfo,
    previousPagingInfo,
    listName = 'ContactsList',
    pageIndex = 1, // default page index value
    pageSize = 4, // default page size value
    list,
    camlQuery;

// This code runs when the DOM is ready and creates a context object which is needed to use the SharePoint object model 
$(document).ready(function () {
    context = SP.ClientContext.get_current();
    list = context.get_web().get_lists().getByTitle(listName);
    camlQuery = new SP.CamlQuery();

    $(&quot;#btnNext&quot;).click(function () {
        pageIndex = pageIndex &#43; 1;
        if (nextPagingInfo) {
            position = new SP.ListItemCollectionPosition();
            position.set_pagingInfo(nextPagingInfo);
        }
        else {
            position = null;
        }

        GetListItems();
    });

    $(&quot;#btnBack&quot;).click(function () {
        pageIndex = pageIndex - 1;
        position = new SP.ListItemCollectionPosition();
        position.set_pagingInfo(previousPagingInfo);
        GetListItems();
    });

    GetListItems();
});

function GetListItems() {
    //Set the next or back list items collection position
    //First time the position will be null
    camlQuery.set_listItemCollectionPosition(position);

    // Create a CAML view that retrieves all contacts items  with assigne RowLimit value to the query
    camlQuery.set_viewXml(&quot;&lt;View&gt;&quot; &#43;
                              &quot;&lt;ViewFields&gt;&quot; &#43;
                                     &quot;&lt;FieldRef Name='FirstName'/&gt;&quot; &#43;
                                     &quot;&lt;FieldRef Name='Title'/&gt;&quot; &#43;
                                     &quot;&lt;FieldRef Name='Company'/&gt;&quot; &#43;
                                &quot;&lt;/ViewFields&gt;&quot; &#43;
                             &quot;&lt;RowLimit&gt;&quot; &#43; pageSize &#43; &quot;&lt;/RowLimit&gt;&lt;/View&gt;&quot;);

    spItems = list.getItems(camlQuery);

    context.load(spItems);
    context.executeQueryAsync(
            Function.createDelegate(this, onSuccess),
            Function.createDelegate(this, onFail)
        );
}

// This function is executed if the above OM call is successful
// This function render the returns items to html table
function onSuccess() {

    var listEnumerator = spItems.getEnumerator();
    var items = [];
    var item;

    while (listEnumerator.moveNext()) {
        item = listEnumerator.get_current();
        items.push(&quot;&lt;td&gt;&quot; &#43; item.get_item('FirstName') &#43; &quot;&lt;/td&gt;&lt;td&gt;&quot; &#43; item.get_item('Title') &#43; &quot;&lt;/td&gt;&lt;td&gt;&quot; &#43; item.get_item('Company') &#43; &quot;&lt;/td&gt;&quot;);
    }

    var content = &quot;&lt;table&gt;&lt;tr&gt;&lt;th&gt;First Name&lt;/th&gt;&lt;th&gt;Last Name&lt;/th&gt;&lt;th&gt;Company&lt;/th&gt;&lt;/tr&gt;&lt;tr&gt;&quot;
                &#43; items.join(&quot;&lt;/tr&gt;&lt;tr&gt;&quot;) &#43; &quot;&lt;/tr&gt;&lt;/table&gt;&quot;;
    $('#content').html(content);

    managePagerControl();
}

function managePagerControl() {

    if (spItems.get_listItemCollectionPosition()) {
        nextPagingInfo = spItems.get_listItemCollectionPosition().get_pagingInfo();
    } else {
        nextPagingInfo = null;
    }

    //The following code line shall add page information between the next and back buttons
    $(&quot;#pageInfo&quot;).html((((pageIndex - 1) * pageSize) &#43; 1) &#43; &quot; - &quot; &#43; ((pageIndex * pageSize) - (pageSize - spItems.get_count())));

    previousPagingInfo = &quot;PagedPrev=TRUE&amp;Paged=TRUE&amp;p_ID=&quot; &#43; spItems.itemAt(0).get_item('ID');

    if (pageIndex &lt;= 1) {
        $(&quot;#btnBack&quot;).attr('disabled', 'disabled');
    }
    else {
        $(&quot;#btnBack&quot;).removeAttr('disabled');
    }

    if (nextPagingInfo) {
        $(&quot;#btnNext&quot;).removeAttr('disabled');
    }
    else {
        $(&quot;#btnNext&quot;).attr('disabled', 'disabled');
    }

}</pre>
<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;context,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;web,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;spItems,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;position,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;nextPagingInfo,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;previousPagingInfo,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;listName&nbsp;=&nbsp;<span class="js__string">'ContactsList'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pageIndex&nbsp;=&nbsp;<span class="js__num">1</span>,&nbsp;<span class="js__sl_comment">//&nbsp;default&nbsp;page&nbsp;index&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pageSize&nbsp;=&nbsp;<span class="js__num">4</span>,&nbsp;<span class="js__sl_comment">//&nbsp;default&nbsp;page&nbsp;size&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;list,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;camlQuery;&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;code&nbsp;runs&nbsp;when&nbsp;the&nbsp;DOM&nbsp;is&nbsp;ready&nbsp;and&nbsp;creates&nbsp;a&nbsp;context&nbsp;object&nbsp;which&nbsp;is&nbsp;needed&nbsp;to&nbsp;use&nbsp;the&nbsp;SharePoint&nbsp;object&nbsp;model&nbsp;</span>&nbsp;
$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;context&nbsp;=&nbsp;SP.ClientContext.get_current();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;list&nbsp;=&nbsp;context.get_web().get_lists().getByTitle(listName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;camlQuery&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SP.CamlQuery();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#btnNext&quot;</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pageIndex&nbsp;=&nbsp;pageIndex&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(nextPagingInfo)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;position&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SP.ListItemCollectionPosition();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;position.set_pagingInfo(nextPagingInfo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;position&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GetListItems();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#btnBack&quot;</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pageIndex&nbsp;=&nbsp;pageIndex&nbsp;-&nbsp;<span class="js__num">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;position&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SP.ListItemCollectionPosition();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;position.set_pagingInfo(previousPagingInfo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GetListItems();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;GetListItems();&nbsp;
<span class="js__brace">}</span>);&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;GetListItems()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Set&nbsp;the&nbsp;next&nbsp;or&nbsp;back&nbsp;list&nbsp;items&nbsp;collection&nbsp;position</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//First&nbsp;time&nbsp;the&nbsp;position&nbsp;will&nbsp;be&nbsp;null</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;camlQuery.set_listItemCollectionPosition(position);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;a&nbsp;CAML&nbsp;view&nbsp;that&nbsp;retrieves&nbsp;all&nbsp;contacts&nbsp;items&nbsp;&nbsp;with&nbsp;assigne&nbsp;RowLimit&nbsp;value&nbsp;to&nbsp;the&nbsp;query</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;camlQuery.set_viewXml(<span class="js__string">&quot;&lt;View&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;ViewFields&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;FieldRef&nbsp;Name='FirstName'/&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;FieldRef&nbsp;Name='Title'/&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;FieldRef&nbsp;Name='Company'/&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;/ViewFields&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;RowLimit&gt;&quot;</span>&nbsp;&#43;&nbsp;pageSize&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/RowLimit&gt;&lt;/View&gt;&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;spItems&nbsp;=&nbsp;list.getItems(camlQuery);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;context.load(spItems);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;context.executeQueryAsync(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">Function</span>.createDelegate(<span class="js__operator">this</span>,&nbsp;onSuccess),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">Function</span>.createDelegate(<span class="js__operator">this</span>,&nbsp;onFail)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;is&nbsp;executed&nbsp;if&nbsp;the&nbsp;above&nbsp;OM&nbsp;call&nbsp;is&nbsp;successful</span>&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;render&nbsp;the&nbsp;returns&nbsp;items&nbsp;to&nbsp;html&nbsp;table</span>&nbsp;
<span class="js__operator">function</span>&nbsp;onSuccess()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;listEnumerator&nbsp;=&nbsp;spItems.getEnumerator();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;items&nbsp;=&nbsp;[];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;item;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">while</span>&nbsp;(listEnumerator.moveNext())&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item&nbsp;=&nbsp;listEnumerator.get_current();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;items.push(<span class="js__string">&quot;&lt;td&gt;&quot;</span>&nbsp;&#43;&nbsp;item.get_item(<span class="js__string">'FirstName'</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/td&gt;&lt;td&gt;&quot;</span>&nbsp;&#43;&nbsp;item.get_item(<span class="js__string">'Title'</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/td&gt;&lt;td&gt;&quot;</span>&nbsp;&#43;&nbsp;item.get_item(<span class="js__string">'Company'</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/td&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;content&nbsp;=&nbsp;<span class="js__string">&quot;&lt;table&gt;&lt;tr&gt;&lt;th&gt;First&nbsp;Name&lt;/th&gt;&lt;th&gt;Last&nbsp;Name&lt;/th&gt;&lt;th&gt;Company&lt;/th&gt;&lt;/tr&gt;&lt;tr&gt;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;items.join(<span class="js__string">&quot;&lt;/tr&gt;&lt;tr&gt;&quot;</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/tr&gt;&lt;/table&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#content'</span>).html(content);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;managePagerControl();&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;managePagerControl()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(spItems.get_listItemCollectionPosition())&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nextPagingInfo&nbsp;=&nbsp;spItems.get_listItemCollectionPosition().get_pagingInfo();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nextPagingInfo&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//The&nbsp;following&nbsp;code&nbsp;line&nbsp;shall&nbsp;add&nbsp;page&nbsp;information&nbsp;between&nbsp;the&nbsp;next&nbsp;and&nbsp;back&nbsp;buttons</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#pageInfo&quot;</span>).html((((pageIndex&nbsp;-&nbsp;<span class="js__num">1</span>)&nbsp;*&nbsp;pageSize)&nbsp;&#43;&nbsp;<span class="js__num">1</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;((pageIndex&nbsp;*&nbsp;pageSize)&nbsp;-&nbsp;(pageSize&nbsp;-&nbsp;spItems.get_count())));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;previousPagingInfo&nbsp;=&nbsp;<span class="js__string">&quot;PagedPrev=TRUE&amp;Paged=TRUE&amp;p_ID=&quot;</span>&nbsp;&#43;&nbsp;spItems.itemAt(<span class="js__num">0</span>).get_item(<span class="js__string">'ID'</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(pageIndex&nbsp;&lt;=&nbsp;<span class="js__num">1</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#btnBack&quot;</span>).attr(<span class="js__string">'disabled'</span>,&nbsp;<span class="js__string">'disabled'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#btnBack&quot;</span>).removeAttr(<span class="js__string">'disabled'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(nextPagingInfo)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#btnNext&quot;</span>).removeAttr(<span class="js__string">'disabled'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#btnNext&quot;</span>).attr(<span class="js__string">'disabled'</span>,&nbsp;<span class="js__string">'disabled'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<h3><span style="font-size:20px; font-weight:bold"><span style="font-size:large">Sample two (</span></span>Paging with CAML Sorting<span style="font-size:20px; font-weight:bold"><span style="font-size:large">)</span></span></h3>
<p><span style="font-size:20px; font-weight:bold"><span style="font-size:large"><img id="92626" src="92626-sharepoint%20jsom%20list%20pagination%20(paging)%202%20.png" alt="" width="291" height="206"></span></span></p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold"><span style="font-size:large">&nbsp;</span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">var context,
    web,
    spItems,
    position,
    nextPagingInfo,
    previousPagingInfo,
    listName = 'ContactsList',
    pageIndex = 1, // default page index value
    pageSize = 4, // default page size value
    list,
    camlQuery,
    sortColumn = 'FirstName'; // this is sort column, you can add more than one column, but you should add it also to CAML Query &amp; managePagerControl function

// This code runs when the DOM is ready and creates a context object which is needed to use the SharePoint object model 
$(document).ready(function () {
    context = SP.ClientContext.get_current();
    list = context.get_web().get_lists().getByTitle(listName);
    camlQuery = new SP.CamlQuery();

    $(&quot;#btnNext&quot;).click(function () {
        pageIndex = pageIndex &#43; 1;
        if (nextPagingInfo) {
            position = new SP.ListItemCollectionPosition();
            position.set_pagingInfo(nextPagingInfo);
        }
        else {
            position = null;
        }

        GetListItems();
    });

    $(&quot;#btnBack&quot;).click(function () {
        pageIndex = pageIndex - 1;
        position = new SP.ListItemCollectionPosition();
        position.set_pagingInfo(previousPagingInfo);
        GetListItems();
    });

    GetListItems();
});

function GetListItems() {
    //Set the next or back list items collection position
    //First time the position will be null
    camlQuery.set_listItemCollectionPosition(position);

    // Create a CAML view that retrieves all contacts items  with assigne RowLimit value to the query
    camlQuery.set_viewXml(&quot;&lt;View&gt;&quot; &#43;
                                &quot;&lt;ViewFields&gt;&quot; &#43;
                                       &quot;&lt;FieldRef Name='FirstName'/&gt;&quot; &#43;
                                       &quot;&lt;FieldRef Name='Title'/&gt;&quot; &#43;
                                       &quot;&lt;FieldRef Name='Company'/&gt;&quot; &#43;
                                  &quot;&lt;/ViewFields&gt;&quot; &#43;
                               &quot;&lt;Query&gt;&quot; &#43;
                                    &quot;&lt;OrderBy&gt;&quot; &#43;
                                      &quot;&lt;FieldRef Name='&quot; &#43; sortColumn &#43; &quot;' Ascending='true' /&gt;&quot; &#43;
                                    &quot;&lt;/OrderBy&gt;&quot; &#43;
                               &quot;&lt;/Query&gt;&quot; &#43;
                               &quot;&lt;RowLimit&gt;&quot; &#43; pageSize &#43; &quot;&lt;/RowLimit&gt;&lt;/View&gt;&quot;);

    spItems = list.getItems(camlQuery);

    context.load(spItems);
    context.executeQueryAsync(
            Function.createDelegate(this, onSuccess),
            Function.createDelegate(this, onFail)
        );
}

// This function is executed if the above OM call is successful
// This function render the returns items to html table
function onSuccess() {

    var listEnumerator = spItems.getEnumerator();
    var items = [];
    var item;

    while (listEnumerator.moveNext()) {
        item = listEnumerator.get_current();
        items.push(&quot;&lt;td&gt;&quot; &#43; item.get_item('FirstName') &#43; &quot;&lt;/td&gt;&lt;td&gt;&quot; &#43; item.get_item('Title') &#43; &quot;&lt;/td&gt;&lt;td&gt;&quot; &#43; item.get_item('Company') &#43; &quot;&lt;/td&gt;&quot;);
    }

    var content = &quot;&lt;table&gt;&lt;tr&gt;&lt;th&gt;First Name&lt;/th&gt;&lt;th&gt;Last Name&lt;/th&gt;&lt;th&gt;Company&lt;/th&gt;&lt;/tr&gt;&lt;tr&gt;&quot;
                &#43; items.join(&quot;&lt;/tr&gt;&lt;tr&gt;&quot;) &#43; &quot;&lt;/tr&gt;&lt;/table&gt;&quot;;
    $('#content').html(content);

    managePagerControl();
}

function managePagerControl() {

    if (spItems.get_listItemCollectionPosition()) {
        nextPagingInfo = spItems.get_listItemCollectionPosition().get_pagingInfo();
    } else {
        nextPagingInfo = null;
    }

    $(&quot;#pageInfo&quot;).html((((pageIndex - 1) * pageSize) &#43; 1) &#43; &quot; - &quot; &#43; ((pageIndex * pageSize) - (pageSize - spItems.get_count())));

    previousPagingInfo = &quot;PagedPrev=TRUE&amp;Paged=TRUE&amp;p_ID=&quot; &#43; spItems.itemAt(0).get_item('ID') &#43; &quot;&amp;p_&quot; &#43; sortColumn &#43; &quot;=&quot; &#43; encodeURIComponent(spItems.itemAt(0).get_item(sortColumn));

    if (pageIndex &lt;= 1) {
        $(&quot;#btnBack&quot;).attr('disabled', 'disabled');
    }
    else {
        $(&quot;#btnBack&quot;).removeAttr('disabled');
    }

    if (nextPagingInfo) {
        $(&quot;#btnNext&quot;).removeAttr('disabled');
    }
    else {
        $(&quot;#btnNext&quot;).attr('disabled', 'disabled');
    }

}</pre>
<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;context,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;web,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;spItems,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;position,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;nextPagingInfo,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;previousPagingInfo,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;listName&nbsp;=&nbsp;<span class="js__string">'ContactsList'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pageIndex&nbsp;=&nbsp;<span class="js__num">1</span>,&nbsp;<span class="js__sl_comment">//&nbsp;default&nbsp;page&nbsp;index&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pageSize&nbsp;=&nbsp;<span class="js__num">4</span>,&nbsp;<span class="js__sl_comment">//&nbsp;default&nbsp;page&nbsp;size&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;list,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;camlQuery,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sortColumn&nbsp;=&nbsp;<span class="js__string">'FirstName'</span>;&nbsp;<span class="js__sl_comment">//&nbsp;this&nbsp;is&nbsp;sort&nbsp;column,&nbsp;you&nbsp;can&nbsp;add&nbsp;more&nbsp;than&nbsp;one&nbsp;column,&nbsp;but&nbsp;you&nbsp;should&nbsp;add&nbsp;it&nbsp;also&nbsp;to&nbsp;CAML&nbsp;Query&nbsp;&amp;&nbsp;managePagerControl&nbsp;function</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;code&nbsp;runs&nbsp;when&nbsp;the&nbsp;DOM&nbsp;is&nbsp;ready&nbsp;and&nbsp;creates&nbsp;a&nbsp;context&nbsp;object&nbsp;which&nbsp;is&nbsp;needed&nbsp;to&nbsp;use&nbsp;the&nbsp;SharePoint&nbsp;object&nbsp;model&nbsp;</span>&nbsp;
$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;context&nbsp;=&nbsp;SP.ClientContext.get_current();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;list&nbsp;=&nbsp;context.get_web().get_lists().getByTitle(listName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;camlQuery&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SP.CamlQuery();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#btnNext&quot;</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pageIndex&nbsp;=&nbsp;pageIndex&nbsp;&#43;&nbsp;<span class="js__num">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(nextPagingInfo)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;position&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SP.ListItemCollectionPosition();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;position.set_pagingInfo(nextPagingInfo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;position&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GetListItems();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#btnBack&quot;</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pageIndex&nbsp;=&nbsp;pageIndex&nbsp;-&nbsp;<span class="js__num">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;position&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SP.ListItemCollectionPosition();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;position.set_pagingInfo(previousPagingInfo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GetListItems();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;GetListItems();&nbsp;
<span class="js__brace">}</span>);&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;GetListItems()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Set&nbsp;the&nbsp;next&nbsp;or&nbsp;back&nbsp;list&nbsp;items&nbsp;collection&nbsp;position</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//First&nbsp;time&nbsp;the&nbsp;position&nbsp;will&nbsp;be&nbsp;null</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;camlQuery.set_listItemCollectionPosition(position);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;a&nbsp;CAML&nbsp;view&nbsp;that&nbsp;retrieves&nbsp;all&nbsp;contacts&nbsp;items&nbsp;&nbsp;with&nbsp;assigne&nbsp;RowLimit&nbsp;value&nbsp;to&nbsp;the&nbsp;query</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;camlQuery.set_viewXml(<span class="js__string">&quot;&lt;View&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;ViewFields&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;FieldRef&nbsp;Name='FirstName'/&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;FieldRef&nbsp;Name='Title'/&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;FieldRef&nbsp;Name='Company'/&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;/ViewFields&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;Query&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;OrderBy&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;FieldRef&nbsp;Name='&quot;</span>&nbsp;&#43;&nbsp;sortColumn&nbsp;&#43;&nbsp;<span class="js__string">&quot;'&nbsp;Ascending='true'&nbsp;/&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;/OrderBy&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;/Query&gt;&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;&lt;RowLimit&gt;&quot;</span>&nbsp;&#43;&nbsp;pageSize&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/RowLimit&gt;&lt;/View&gt;&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;spItems&nbsp;=&nbsp;list.getItems(camlQuery);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;context.load(spItems);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;context.executeQueryAsync(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">Function</span>.createDelegate(<span class="js__operator">this</span>,&nbsp;onSuccess),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">Function</span>.createDelegate(<span class="js__operator">this</span>,&nbsp;onFail)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;is&nbsp;executed&nbsp;if&nbsp;the&nbsp;above&nbsp;OM&nbsp;call&nbsp;is&nbsp;successful</span>&nbsp;
<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;render&nbsp;the&nbsp;returns&nbsp;items&nbsp;to&nbsp;html&nbsp;table</span>&nbsp;
<span class="js__operator">function</span>&nbsp;onSuccess()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;listEnumerator&nbsp;=&nbsp;spItems.getEnumerator();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;items&nbsp;=&nbsp;[];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;item;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">while</span>&nbsp;(listEnumerator.moveNext())&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item&nbsp;=&nbsp;listEnumerator.get_current();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;items.push(<span class="js__string">&quot;&lt;td&gt;&quot;</span>&nbsp;&#43;&nbsp;item.get_item(<span class="js__string">'FirstName'</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/td&gt;&lt;td&gt;&quot;</span>&nbsp;&#43;&nbsp;item.get_item(<span class="js__string">'Title'</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/td&gt;&lt;td&gt;&quot;</span>&nbsp;&#43;&nbsp;item.get_item(<span class="js__string">'Company'</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/td&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;content&nbsp;=&nbsp;<span class="js__string">&quot;&lt;table&gt;&lt;tr&gt;&lt;th&gt;First&nbsp;Name&lt;/th&gt;&lt;th&gt;Last&nbsp;Name&lt;/th&gt;&lt;th&gt;Company&lt;/th&gt;&lt;/tr&gt;&lt;tr&gt;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;items.join(<span class="js__string">&quot;&lt;/tr&gt;&lt;tr&gt;&quot;</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/tr&gt;&lt;/table&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#content'</span>).html(content);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;managePagerControl();&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;managePagerControl()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(spItems.get_listItemCollectionPosition())&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nextPagingInfo&nbsp;=&nbsp;spItems.get_listItemCollectionPosition().get_pagingInfo();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nextPagingInfo&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#pageInfo&quot;</span>).html((((pageIndex&nbsp;-&nbsp;<span class="js__num">1</span>)&nbsp;*&nbsp;pageSize)&nbsp;&#43;&nbsp;<span class="js__num">1</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;((pageIndex&nbsp;*&nbsp;pageSize)&nbsp;-&nbsp;(pageSize&nbsp;-&nbsp;spItems.get_count())));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;previousPagingInfo&nbsp;=&nbsp;<span class="js__string">&quot;PagedPrev=TRUE&amp;Paged=TRUE&amp;p_ID=&quot;</span>&nbsp;&#43;&nbsp;spItems.itemAt(<span class="js__num">0</span>).get_item(<span class="js__string">'ID'</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&amp;p_&quot;</span>&nbsp;&#43;&nbsp;sortColumn&nbsp;&#43;&nbsp;<span class="js__string">&quot;=&quot;</span>&nbsp;&#43;&nbsp;<span class="js__function">encodeURIComponent</span>(spItems.itemAt(<span class="js__num">0</span>).get_item(sortColumn));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(pageIndex&nbsp;&lt;=&nbsp;<span class="js__num">1</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#btnBack&quot;</span>).attr(<span class="js__string">'disabled'</span>,&nbsp;<span class="js__string">'disabled'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#btnBack&quot;</span>).removeAttr(<span class="js__string">'disabled'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(nextPagingInfo)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#btnNext&quot;</span>).removeAttr(<span class="js__string">'disabled'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#btnNext&quot;</span>).attr(<span class="js__string">'disabled'</span>,&nbsp;<span class="js__string">'disabled'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h1>More Information</h1>
<p>Jamil Haddadin write a good article for how to work with <a href="http://social.technet.microsoft.com/wiki/contents/articles/18606.paging-with-sharepoint-client-object-model.aspx">
SharePoint client side paging</a>.</p>
