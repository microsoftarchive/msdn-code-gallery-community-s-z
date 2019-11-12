# Using the HTML5 and jQuery UI Datepicker Popup Calendar with ASP.NET MVC
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET MVC
## Topics
- jQuery
- HTML5
## Updated
- 09/11/2011
## Description

<p>&nbsp;</p>
<h3>What You'll Build</h3>
<p class="auto">You'll start with the <a href="http://www.asp.net/mvc/tutorials/getting-started-with-mvc3-part1-cs" target="_blank">
MVC Movie application</a> and add display and editor templates. You will then hook up the jQuery
<a href="http://plugins.jquery.com/project/datepicker">UI Datepicker popup calendar</a>.</p>
<p>&nbsp;&nbsp;<img src="25788-p1_finisheddatepicker.png" alt="" width="518" height="818"><span class="Apple" style="widows:2; text-transform:none; text-indent:0px; letter-spacing:normal; border-collapse:separate; font:medium 'Times New Roman'; white-space:normal; orphans:2; color:#000000; word-spacing:0px">&#65279;<span class="Apple-style-span" style="widows:2; text-transform:none; text-indent:0px; letter-spacing:normal; border-collapse:separate; font:medium 'Times New Roman'; white-space:normal; orphans:2; color:#000000; word-spacing:0px">&nbsp;</span></span></p>
<h3>Skills You'll Learn</h3>
<ul>
<li><a href="http://www.asp.net/mvc/tutorials/using-the-html5-and-jquery-ui-datepicker-popup-calendar-with-aspnet-mvc-part-1">Introduction to the source code and how it works</a>.
</li><li><a href="http://www.asp.net/mvc/tutorials/using-the-html5-and-jquery-ui-datepicker-popup-calendar-with-aspnet-mvc-part-2">How to create edit and display templates to control the formating of data.
</a></li><li><a href="http://www.asp.net/mvc/tutorials/using-the-html5-and-jquery-ui-datepicker-popup-calendar-with-aspnet-mvc-part-3">Working with Complex Types</a>
</li><li><a href="http://www.asp.net/mvc/tutorials/using-the-html5-and-jquery-ui-datepicker-popup-calendar-with-aspnet-mvc-part-4">How to add the<span class="Apple-converted-space">&nbsp;</span>jQuery UI Datepicker<span class="Apple-converted-space">&nbsp;</span>to
 date fields.</a> </li></ul>
<h3>Specifying Model Display Format</h3>
<p>We have seen that you can specify the format for a model property with the following approaches:</p>
<ul>
<li>&nbsp;Applying DisplayFormat attribute on a property. The following code causes the date do be displayed without the time.
<pre class="prettyprint">        [DisplayFormat(DataFormatString = &quot;{0:d}&quot;)]
        public DateTime ReleaseDate { get; set; }</pre>
</li><li>Applying the <a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.datatype.aspx">
DataType</a> enumeration. The following code causes the date do be displayed without the time. If a
<em>date.cshtml</em> template is found in the <em>Views\Shared\DisplayTemplates</em> folder or the&nbsp;
<em>Views\Movies\DisplayTemplates</em> folder, it will be used to render the <code>
DateTime </code>property, otherwise the built in ASP.NET templating system will display the property as a date.
<pre class="prettyprint">        [DataType(DataType.Date)]
       public DateTime ReleaseDate { get; set; }</pre>
</li><li>Creating a display template with the name of the type in the&nbsp; <em>Views\Shared\DisplayTemplates</em> folder or the&nbsp;
<em>Views\Movies\DisplayTemplates</em> folder. For example, we showed that the <em>
Views\Shared\DisplayTemplates\DateTime.cshtml</em> was used to render <code>DateTime
</code>properties in a model, without adding an attribute to our model and without adding any markup to our views.
</li><li>Using the <a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.uihintattribute.uihint.aspx">
UIHint</a> attribute on the model to specify the template to display the model property.
</li><li>Explicitly adding the display template name to the&nbsp; @<a href="http://msdn.microsoft.com/en-us/library/ee407420.aspx">Html.DisplayFor</a> call in a view.
</li></ul>
<p>In the next section, we will hook up the jQuery DatePicker to our edit views</p>
<p>&nbsp;</p>
<h3>What You'll Build</h3>
<p>You'll add edit and display templates to the a simple movie-listing application that was created in the<span class="Apple">&nbsp;</span><a href="http://www.asp.net/mvc/tutorials/getting-started-with-mvc3-part1-cs">Getting Started With MVC3<span class="Apple">&nbsp;</span></a>tutorial.
 You will also add a<span class="Apple">&nbsp;</span><a href="http://jqueryui.com/demos/datepicker/">jQuery UI Datepicker</a><span class="Apple">&nbsp;</span>popup calendar to simplfy entering dates. Below is a screenshot of the modified application with
 the jQuery UI Datepicker popup calendar displayed.</p>
<p>&nbsp;</p>
<p>This tutorial will teach you the basics of working with editor templates, display templates and the jQuery datepicker in a ASP.NET MVC Web application. You can use Microsoft Visual Web Developer 2010 Express Service Pack 1, which is a free version of Microsoft
 Visual Studio to follow the tutorial. Before you start, make sure you've installed the prerequisites listed below. You can install all of them by clicking the following link:<span class="Apple">&nbsp;</span><a href="http://www.microsoft.com/web/gallery/install.aspx?appid=VWD2010SP1Pack">Web
 Platform Installer</a>. Alternatively, you can individually install the prerequisites using the following links:</p>
