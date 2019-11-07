# WPF Upload Image Using ADO.NET Entity Framework
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- SQL Server
- ADO.NET Entity Framework
- WPF
- VB.Net
## Topics
- ADO.NET Entity Framework
- WPF
## Updated
- 09/18/2013
## Description

<h1>Introduction</h1>
<div><span style="font-size:small"><em>This is a WPF&nbsp;sample to show how to choose an image and upload it to database using ADO.NET Entity Framework.</em></span><span>
<div>&nbsp;</div>
<img id="96408" src="96408-2013-09-18_135534.jpg" alt="" width="525" height="350"></span></div>
<h1><span>Building the Sample</span></h1>
<div>&nbsp;</div>
<div><span style="font-size:small">
<div>
<div><em>
<div>After downloading this project, you should create a database&nbsp;called <strong>
dbtest</strong>&nbsp;first.</div>
<div>&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">USE [dbtest]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[imageinfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ImgData] [image] NULL,
 CONSTRAINT [PK_imageinfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO</pre>
<div class="preview">
<pre class="js">USE&nbsp;[dbtest]&nbsp;
GO&nbsp;
&nbsp;
SET&nbsp;ANSI_NULLS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
SET&nbsp;QUOTED_IDENTIFIER&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
CREATE&nbsp;TABLE&nbsp;[dbo].[imageinfo](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ID]&nbsp;[int]&nbsp;IDENTITY(<span class="js__num">1</span>,<span class="js__num">1</span>)&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Name]&nbsp;[nvarchar](<span class="js__num">50</span>)&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ImgData]&nbsp;[image]&nbsp;NULL,&nbsp;
&nbsp;CONSTRAINT&nbsp;[PK_imageinfo]&nbsp;PRIMARY&nbsp;KEY&nbsp;CLUSTERED&nbsp;&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ID]&nbsp;ASC&nbsp;
)WITH&nbsp;(PAD_INDEX&nbsp;=&nbsp;OFF,&nbsp;STATISTICS_NORECOMPUTE&nbsp;=&nbsp;OFF,&nbsp;IGNORE_DUP_KEY&nbsp;=&nbsp;OFF,&nbsp;ALLOW_ROW_LOCKS&nbsp;=&nbsp;ON,&nbsp;ALLOW_PAGE_LOCKS&nbsp;=&nbsp;ON)&nbsp;ON&nbsp;[PRIMARY]&nbsp;
)&nbsp;ON&nbsp;[PRIMARY]&nbsp;TEXTIMAGE_ON&nbsp;[PRIMARY]&nbsp;
&nbsp;
GO</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div>And&nbsp;you should also update the Entity Framework Model.</div>
<div>&nbsp;</div>
</em>
<div></div>
</div>
</div>
</span></div>
<h1>Description</h1>
<div><span style="font-size:small"><em>&nbsp;</em></span>&nbsp;</div>
<div><span style="font-size:small"><em>In the Click&nbsp;event of Browse button, I used&nbsp;System.Windows.Forms.OpenFileDialog control to browse images, display the image's&nbsp;name in TextBox.</em><em>&nbsp;</em></span></div>
<div>&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">private void Button_Click(object sender, RoutedEventArgs e)
{
            OpenFileDialog FileDialog = new System.Windows.Forms.OpenFileDialog();
            FileDialog.Title = &quot;Select A File&quot;;
            FileDialog.InitialDirectory = &quot;&quot;;
            FileDialog.Filter = &quot;Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.png&quot;;
            FileDialog.FilterIndex = 1;

            if (FileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextBox1.Text = FileDialog.FileName;
                Label1.Content = GetFileNameNoExt(TextBox1.Text.Trim());
                BitmapImage bmp = new BitmapImage(new Uri(TextBox1.Text.Trim()));
                image1.Source = bmp;
            }
            else
            {
                Label1.Content = &quot;You didn't select any image file....&quot;;
            }
}

public string GetFileNameNoExt(string FilePathFileName)
{
            return System.IO.Path.GetFileNameWithoutExtension(FilePathFileName);
}</pre>
<pre class="hidden">Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim FileDialog As New System.Windows.Forms.OpenFileDialog
        FileDialog.Title = &quot;Select A File&quot;
        FileDialog.InitialDirectory = &quot;&quot;
        FileDialog.Filter = &quot;Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.png&quot;
        FileDialog.FilterIndex = 1

        If FileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TextBox1.Text = FileDialog.FileName()
            Label1.Content = GetFileNameNoExt(TextBox1.Text.Trim)
            Dim bmp As New BitmapImage(New Uri(TextBox1.Text.Trim))
            image1.Source = bmp
        Else
            Label1.Content = &quot;You didn't select any image file....&quot;
        End If
    End Sub

    Public Function GetFileNameNoExt(FilePathFileName As String) As String
        On Error Resume Next
        Dim i As Integer, J As Integer, k As Integer
        i = Len(FilePathFileName)
        J = InStrRev(FilePathFileName, &quot;\&quot;)
        k = InStrRev(FilePathFileName, &quot;.&quot;)
        If k = 0 Then
            GetFileNameNoExt = Mid$(FilePathFileName, J &#43; 1, i - J)
        Else
            GetFileNameNoExt = Mid$(FilePathFileName, J &#43; 1, k - J - 1)
        End If

    End Function</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Button_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OpenFileDialog&nbsp;FileDialog&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.Windows.Forms.OpenFileDialog();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileDialog.Title&nbsp;=&nbsp;<span class="cs__string">&quot;Select&nbsp;A&nbsp;File&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileDialog.InitialDirectory&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileDialog.Filter&nbsp;=&nbsp;<span class="cs__string">&quot;Image&nbsp;Files&nbsp;(*.gif,*.jpg,*.jpeg,*.bmp,*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.png&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileDialog.FilterIndex&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(FileDialog.ShowDialog()&nbsp;==&nbsp;System.Windows.Forms.DialogResult.OK)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;FileDialog.FileName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label1.Content&nbsp;=&nbsp;GetFileNameNoExt(TextBox1.Text.Trim());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BitmapImage&nbsp;bmp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BitmapImage(<span class="cs__keyword">new</span>&nbsp;Uri(TextBox1.Text.Trim()));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;image1.Source&nbsp;=&nbsp;bmp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label1.Content&nbsp;=&nbsp;<span class="cs__string">&quot;You&nbsp;didn't&nbsp;select&nbsp;any&nbsp;image&nbsp;file....&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GetFileNameNoExt(<span class="cs__keyword">string</span>&nbsp;FilePathFileName)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;System.IO.Path.GetFileNameWithoutExtension(FilePathFileName);&nbsp;
}</pre>
</div>
</div>
</div>
<div><em><span style="font-size:small">In the Click event of Upload button, note that&nbsp;the process of Entity Framework:
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">private void SaveImage_Click(object sender, RoutedEventArgs e)
{
            FileStream Stream = new FileStream(TextBox1.Text, FileMode.Open, FileAccess.Read);
            StreamReader Reader = new StreamReader(Stream);
            Byte[] ImgData = new Byte[Stream.Length - 1];
            Stream.Read(ImgData, 0, (int)Stream.Length - 1);
            using (dbtestEntities db = new dbtestEntities())
            {
                imageinfo o = db.imageinfoes.Create();
                o.Name = GetFileNameNoExt(TextBox1.Text);
                o.ImgData = ImgData;
                db.imageinfoes.Add(o);
                db.SaveChanges();
            }

            Label1.Content = GetFileNameNoExt(TextBox1.Text.Trim()) &#43; &quot; Stored Successfully....&quot;;
}</pre>
<pre class="hidden">Private Sub SaveImage_Click(sender As Object, e As RoutedEventArgs) Handles SaveImage.Click
        Dim Stream As FileStream
        Dim Reader As StreamReader
        Stream = New FileStream(TextBox1.Text, FileMode.Open, FileAccess.Read)
        Reader = New StreamReader(Stream)
        Dim ImgData(Stream.Length - 1) As Byte
        Stream.Read(ImgData, 0, Stream.Length - 1)
        
        Using db As New dbtestEntities()
            Dim o As imageinfo = db.imageinfoes.Create()
            o.Name = GetFileNameNoExt(TextBox1.Text)
            o.ImgData = ImgData
            db.imageinfoes.Add(o)
            db.SaveChanges()
        End Using

        Label1.Content = GetFileNameNoExt(TextBox1.Text.Trim) &amp; &quot; Stored Successfully....&quot;
    End Sub</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SaveImage_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileStream&nbsp;Stream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FileStream(TextBox1.Text,&nbsp;FileMode.Open,&nbsp;FileAccess.Read);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StreamReader&nbsp;Reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamReader(Stream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Byte[]&nbsp;ImgData&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Byte[Stream.Length&nbsp;-&nbsp;<span class="cs__number">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Stream.Read(ImgData,&nbsp;<span class="cs__number">0</span>,&nbsp;(<span class="cs__keyword">int</span>)Stream.Length&nbsp;-&nbsp;<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(dbtestEntities&nbsp;db&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;dbtestEntities())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imageinfo&nbsp;o&nbsp;=&nbsp;db.imageinfoes.Create();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o.Name&nbsp;=&nbsp;GetFileNameNoExt(TextBox1.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o.ImgData&nbsp;=&nbsp;ImgData;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.imageinfoes.Add(o);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label1.Content&nbsp;=&nbsp;GetFileNameNoExt(TextBox1.Text.Trim())&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;Stored&nbsp;Successfully....&quot;</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</span></em></div>
<div><span>
<div>
<div>
<div>
<div><strong><span style="font-size:small">Entity states and SaveChanges:</span></strong></div>
<div></div>
<div><span style="font-size:small">An entity can be in one of five states as defined by the EntityState enumeration. These states are:</span></div>
<div></div>
<ul>
<li><em><span style="font-size:small">Added: the entity is being tracked by the context but does not yet exist in the database</span>
</em></li><li><em><span style="font-size:small">&nbsp;</span><span style="font-size:small">Unchanged: the entity is being tracked by the context and exists in the database, and its property values have not changed from the values in the database</span>
</em></li><li><em><span style="font-size:small">&nbsp;</span><span style="font-size:small">Modified: the entity is being tracked by the context and exists in the database, and some or all of its property values have been modified</span>
</em></li><li><em><span style="font-size:small">&nbsp;</span><span style="font-size:small">Deleted: the entity is being tracked by the context and exists in the database, but has been marked for deletion from the database the next time SaveChanges is called</span>
</em></li><li><em><span style="font-size:small">&nbsp;</span><span style="font-size:small">Detached: the entity is not being tracked by the context</span>
</em></li></ul>
<div></div>
<div><strong><span style="font-size:small">SaveChanges does different things for entities in different states:</span></strong></div>
<div></div>
<ul>
<li><em><span style="font-size:small">Unchanged entities are not touched by SaveChanges. Updates are not sent to the database for entities in the Unchanged state.</span>
</em></li><li><em><span style="font-size:small">&nbsp;</span><span style="font-size:small">Added entities are inserted into the database and then become Unchanged when SaveChanges returns.</span>
</em></li><li><em><span style="font-size:small">&nbsp;</span><span style="font-size:small">Modified entities are updated in the database and then become Unchanged when SaveChanges returns.</span>
</em></li><li><em><span style="font-size:small">&nbsp;</span><span style="font-size:small">Deleted entities are deleted from the database and are then detached from the context.</span></em>
</li></ul>
<div></div>
<div></div>
<h1>Source Code Files</h1>
<ul>
<li><em>MainWindow.xaml&nbsp; - MainWindow XAML </em></li><li><em>MainWindow.xaml.cs/vb&nbsp; -&nbsp; MainWindow Code Behind </em></li><li><em>Model1.edmx&nbsp; - Entity Framework Model </em></li><li><em>ReadMe.txt&nbsp; - Design database </em></li></ul>
</div>
</div>
</div>
</span></div>
