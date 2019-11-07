# Upload Files Asynchronously Using AJAX into SQL Server Database
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- AJAX
- SQL Server
- ASP.NET
## Topics
- Multi file upload
- Async
## Updated
- 10/18/2012
## Description

<h1>Introduction</h1>
<p>This sample code uses AjaxFileUpload control to upload multiple files to the database asynchronously.&nbsp; The project supports drag-and-drop to save multiple files to the database by dragging them into the page. Also, you can select multiple files to upload
 by using the SHIFT key or CTRL key when selecting files on the file upload dialog.</p>
<p>To unleash the full power of the sample, your browser needs to supports the latest features in HTML5 (Microsoft Internet Explorer 10, Mozilla Firefox 9, or Google Chrome 17). If the browser does not support the HTML5 File API (Internet Explorer 9) then not
 all the possibilities are showed.</p>
<p>You can restrict the type of files which can be uploaded. For example, you can prevent any file except image from being uploaded into your database. You can also limit the number of files which can be uploaded. For example, you can prevent a user from uploading
 more than 10 files. Although, in this example no filter is specified on file type or number of files.</p>
<p>After browsing the page, you have to choose which files you will upload. Here you can select more than one file. Then by clicking on the upload button, the upload process begins. All the selected files are uploaded into the database including:</p>
<ul>
<li>The name of the file </li><li>The type of the file </li><li>The file </li></ul>
<p>Also the uploaded files are displayed on the page with the snapshot of the file, if it is an image file, or an blank file snapshot if the file type is other than an image.</p>
<h1><span>Building the Sample</span></h1>
<p>To build and run this sample, you must have Visual Studio 2010 installed. Unzip the AJAXFileUploadSQL.zip file into your Visual Studio Projects directory (My Documents\Visual Studio 2010\Projects) and open the AJAXFileUploadSQL.sln solution. Before running
 the application you have to create the database. Use Database.sql file to create the database for this project.</p>
<p><em>Screenshot of the Web Application:</em></p>
<p><em><img id="59609" src="59609-upload.png" alt=""><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Code Snipetts</span></p>
<p><em>Default.aspx</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">    &lt;div&gt;
        &lt;asp:Label runat=&quot;server&quot; ID=&quot;myThrobber&quot; Style=&quot;display: none;&quot;&gt;&lt;img align=&quot;absmiddle&quot; alt=&quot;&quot; src=&quot;uploading.gif&quot;/&gt;&lt;/asp:Label&gt;
        &lt;ajaxToolkit:AjaxFileUpload ID=&quot;AjaxFileUpload1&quot; runat=&quot;server&quot; padding-bottom=&quot;4&quot;
            padding-left=&quot;2&quot; padding-right=&quot;1&quot; padding-top=&quot;4&quot; ThrobberID=&quot;myThrobber&quot; OnClientUploadComplete=&quot;onClientUploadComplete&quot;
            OnUploadComplete=&quot;AjaxFileUpload1_OnUploadComplete&quot; /&gt;
        &lt;br /&gt;
        &lt;div id=&quot;testuploaded&quot; style=&quot;display: none; padding: 4px; border: gray 1px solid;&quot;&gt;
            &lt;h4&gt;
                Uploaded files:&lt;/h4&gt;
            &lt;hr /&gt;
            &lt;div id=&quot;fileList&quot;&gt;
            &lt;/div&gt;
        &lt;/div&gt;
    &lt;/div&gt;
</pre>
<div class="preview">
<pre class="html">&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;asp</span>:Label&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;myThrobber&quot;</span>&nbsp;<span class="html__attr_name">Style</span>=<span class="html__attr_value">&quot;display:&nbsp;none;&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;img</span>&nbsp;<span class="html__attr_name">align</span>=<span class="html__attr_value">&quot;absmiddle&quot;</span>&nbsp;<span class="html__attr_name">alt</span>=<span class="html__attr_value">&quot;&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;uploading.gif&quot;</span><span class="html__tag_start">/&gt;</span><span class="html__tag_end">&lt;/asp:Label&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;ajaxToolkit</span>:AjaxFileUpload&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;AjaxFileUpload1&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">padding-bottom</span>=<span class="html__attr_value">&quot;4&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">padding-left</span>=<span class="html__attr_value">&quot;2&quot;</span>&nbsp;<span class="html__attr_name">padding-right</span>=<span class="html__attr_value">&quot;1&quot;</span>&nbsp;<span class="html__attr_name">padding-top</span>=<span class="html__attr_value">&quot;4&quot;</span>&nbsp;<span class="html__attr_name">ThrobberID</span>=<span class="html__attr_value">&quot;myThrobber&quot;</span>&nbsp;<span class="html__attr_name">OnClientUploadComplete</span>=<span class="html__attr_value">&quot;onClientUploadComplete&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">OnUploadComplete</span>=<span class="html__attr_value">&quot;AjaxFileUpload1_OnUploadComplete&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;br</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;testuploaded&quot;</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;display:&nbsp;none;&nbsp;padding:&nbsp;4px;&nbsp;border:&nbsp;gray&nbsp;1px&nbsp;solid;&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;h4</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Uploaded&nbsp;files:<span class="html__tag_end">&lt;/h4&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;hr</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;fileList&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;</pre>
</div>
</div>
</div>
<p><em>Default.aspx.cs</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using AjaxControlToolkit;

namespace AJAXFileUploadSQL
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[&quot;preview&quot;] == &quot;1&quot; &amp;&amp; !string.IsNullOrEmpty(Request.QueryString[&quot;fileId&quot;]))
            {
                var fileId = Request.QueryString[&quot;fileId&quot;];
                var fileContentType = (string)Session[&quot;fileContentType_&quot; &#43; fileId];
                var fileName = (string)Session[&quot;fileName_&quot; &#43; fileId];
                byte[] imageBytes = File.ReadAllBytes(System.Web.HttpContext.Current.Server.MapPath(&quot;~&quot;) &#43; &quot;file.png&quot;);
                var fileContents = imageBytes;

                string ct = (string)Session[&quot;fileContentType_&quot; &#43; fileId];
                if (ct.Contains(&quot;jpg&quot;) || ct.Contains(&quot;gif&quot;) || ct.Contains(&quot;png&quot;) || ct.Contains(&quot;jpeg&quot;))
                    fileContents = (byte[])Session[&quot;fileContents_&quot; &#43; fileId];

                using (SqlConnection _con = new SqlConnection(&quot;Data Source=.;Initial Catalog=AJAXFileUploadSQL;Integrated Security=True&quot;))
                using (SqlCommand _cmd = new SqlCommand(&quot;UploadFile&quot;, _con))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.AddWithValue(&quot;@FileName&quot;, fileName);
                    _cmd.Parameters.AddWithValue(&quot;@FileType&quot;, fileContentType);
                    _cmd.Parameters.AddWithValue(&quot;@FileContent&quot;, (byte[])Session[&quot;fileContents_&quot; &#43; fileId]);

                    _con.Open();
                    _cmd.ExecuteNonQuery();
                    _con.Close();
                }

                Response.Clear();
                Response.ContentType = fileContentType;
                Response.BinaryWrite(fileContents);
                Response.End();
            }
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        protected void AjaxFileUpload1_OnUploadComplete(object sender, AjaxFileUploadEventArgs file)
        {
            Session[&quot;fileContentType_&quot; &#43; file.FileId] = file.ContentType;
            Session[&quot;fileContents_&quot; &#43; file.FileId] = file.GetContents();

            Session[&quot;fileName_&quot; &#43; file.FileId] = file.FileName.Split('\\').Last();

            file.PostedUrl = string.Format(&quot;?preview=1&amp;fileId={0}&quot;, file.FileId);
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.SqlClient;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;AjaxControlToolkit;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;AJAXFileUploadSQL&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;_Default&nbsp;:&nbsp;System.Web.UI.Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Page_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Request.QueryString[<span class="cs__string">&quot;preview&quot;</span>]&nbsp;==&nbsp;<span class="cs__string">&quot;1&quot;</span>&nbsp;&amp;&amp;&nbsp;!<span class="cs__keyword">string</span>.IsNullOrEmpty(Request.QueryString[<span class="cs__string">&quot;fileId&quot;</span>]))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;fileId&nbsp;=&nbsp;Request.QueryString[<span class="cs__string">&quot;fileId&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;fileContentType&nbsp;=&nbsp;(<span class="cs__keyword">string</span>)Session[<span class="cs__string">&quot;fileContentType_&quot;</span>&nbsp;&#43;&nbsp;fileId];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;fileName&nbsp;=&nbsp;(<span class="cs__keyword">string</span>)Session[<span class="cs__string">&quot;fileName_&quot;</span>&nbsp;&#43;&nbsp;fileId];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;imageBytes&nbsp;=&nbsp;File.ReadAllBytes(System.Web.HttpContext.Current.Server.MapPath(<span class="cs__string">&quot;~&quot;</span>)&nbsp;&#43;&nbsp;<span class="cs__string">&quot;file.png&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;fileContents&nbsp;=&nbsp;imageBytes;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;ct&nbsp;=&nbsp;(<span class="cs__keyword">string</span>)Session[<span class="cs__string">&quot;fileContentType_&quot;</span>&nbsp;&#43;&nbsp;fileId];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ct.Contains(<span class="cs__string">&quot;jpg&quot;</span>)&nbsp;||&nbsp;ct.Contains(<span class="cs__string">&quot;gif&quot;</span>)&nbsp;||&nbsp;ct.Contains(<span class="cs__string">&quot;png&quot;</span>)&nbsp;||&nbsp;ct.Contains(<span class="cs__string">&quot;jpeg&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fileContents&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>[])Session[<span class="cs__string">&quot;fileContents_&quot;</span>&nbsp;&#43;&nbsp;fileId];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SqlConnection&nbsp;_con&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlConnection(<span class="cs__string">&quot;Data&nbsp;Source=.;Initial&nbsp;Catalog=AJAXFileUploadSQL;Integrated&nbsp;Security=True&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(SqlCommand&nbsp;_cmd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SqlCommand(<span class="cs__string">&quot;UploadFile&quot;</span>,&nbsp;_con))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_cmd.CommandType&nbsp;=&nbsp;CommandType.StoredProcedure;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_cmd.Parameters.AddWithValue(<span class="cs__string">&quot;@FileName&quot;</span>,&nbsp;fileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_cmd.Parameters.AddWithValue(<span class="cs__string">&quot;@FileType&quot;</span>,&nbsp;fileContentType);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_cmd.Parameters.AddWithValue(<span class="cs__string">&quot;@FileContent&quot;</span>,&nbsp;(<span class="cs__keyword">byte</span>[])Session[<span class="cs__string">&quot;fileContents_&quot;</span>&nbsp;&#43;&nbsp;fileId]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_con.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_cmd.ExecuteNonQuery();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_con.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.Clear();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.ContentType&nbsp;=&nbsp;fileContentType;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.BinaryWrite(fileContents);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response.End();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;imageToByteArray(System.Drawing.Image&nbsp;imageIn)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MemoryStream&nbsp;ms&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imageIn.Save(ms,&nbsp;System.Drawing.Imaging.ImageFormat.Gif);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;ms.ToArray();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AjaxFileUpload1_OnUploadComplete(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;AjaxFileUploadEventArgs&nbsp;file)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Session[<span class="cs__string">&quot;fileContentType_&quot;</span>&nbsp;&#43;&nbsp;file.FileId]&nbsp;=&nbsp;file.ContentType;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Session[<span class="cs__string">&quot;fileContents_&quot;</span>&nbsp;&#43;&nbsp;file.FileId]&nbsp;=&nbsp;file.GetContents();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Session[<span class="cs__string">&quot;fileName_&quot;</span>&nbsp;&#43;&nbsp;file.FileId]&nbsp;=&nbsp;file.FileName.Split(<span class="cs__string">'\\'</span>).Last();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;file.PostedUrl&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;?preview=1&amp;fileId={0}&quot;</span>,&nbsp;file.FileId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
