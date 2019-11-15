# WPF - C# Realization of Image Similarity Algorithm - FaceDetection
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- WPF
## Topics
- C#
- WPF
- Face detection
## Updated
- 08/14/2017
## Description

<h1>C # Realization of Image Similarity Algorithm</h1>
<p><br>
<span style="color:#8d8d8d; font-family:SimSun">I think this article of content you may find it from google every where, I'd just like to organize those let it looks easy to be read.</span></p>
<p><span style="color:#8d8d8d; font-family:SimSun"><br>
</span></p>
<p><span style="color:#8d8d8d; font-family:SimSun">This example you need to download
<span style="color:#ff0000">Emgu</span>, then add reference to your pjoject on VisualStudio：</span></p>
<p><span style="color:#8d8d8d; font-family:SimSun"><span style="background-color:#ffffff; color:#0000ff"><a title="https://sourceforge.net/projects/emgucv/" href="https://sourceforge.net/projects/emgucv/">https://sourceforge.net/projects/emgucv/</a></span></span></p>
<p><span style="color:#8d8d8d; font-family:SimSun"><span style="background-color:#ffffff; color:#0000ff"><br>
</span></span></p>
<h2><a name="Introduction_to_basic_knowledge"></a><span style="color:#0000ff">－Introduction to basic knowledge－</span></h2>
<p>&nbsp;</p>
<h3><a name="Color_bar_chart"></a>Color bar chart</h3>
<p><span style="color:#8d8d8d">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:#8d8d8d; font-family:SimSun">Color bar graphs are widely used in many image retrieval systems. They describe the proportions of different colors in the whole
 image, and do not care about the spatial position of each color, It is impossible to describe an object or an object in the image. The color bar chart is particularly useful for describing images that are difficult to segment automatically.<br>
<br>
</span></p>
<h3><a name="Gray_scale_bar_graph"></a>Gray scale bar graph</h3>
<p><span style="color:#8d8d8d; font-family:SimSun">&nbsp; The grayscale bar graph is a function of the gray scale, which represents the number of primitives in the image that have each gray level, reflecting the frequency of each grayscale in the image. The
 abscissa of the gray scale bar graph is the gray level, and the ordinate is the frequency of the gray level, which is the most basic statistical feature of the image.<br>
<br>
</span></p>
<p><span style="color:#8d8d8d; font-family:SimSun">&nbsp; In this paper, the use of gray bars to calculate the image similarity, on the algorithm that is not a word, after all, graphic graphics, just want to achieve a basic algorithm, and then from the most
 intuitive point of view Look at the effectiveness of this algorithm, that's it.</span><span style="color:#8d8d8d">&nbsp;<br>
<br>
</span></p>
<h3><a name="Algorithm_implementation"></a>Algorithm implementation</h3>
<p><span style="color:#8d8d8d; font-family:SimSun">The general steps are as follows:</span></p>
<p><span style="color:#8d8d8d; font-family:SimSun">1, the image is converted to the same size, in order to facilitate the calculation of similar to the long bar chart.</span></p>
<p><span style="color:#8d8d8d; font-family:SimSun">2, calculate the converted gray scale bar graph.</span></p>
<p><span style="color:#8d8d8d; font-family:SimSun">3, using XX formula, get the bar graph similarity quantitative measurement.</span></p>
<p><span style="color:#8d8d8d; font-family:SimSun">4, the output of these do not know useful useless similarity results data.<br>
<br>
</span></p>
<h3><a name="Program_implementation"></a>Program implementation</h3>
<p><span style="color:#8d8d8d; font-family:SimSun">Step 1, the image is converted to the same size, we temporarily converted into 256 X 256 it.</span><span style="color:#8d8d8d">&nbsp;</span></p>
<div class="reCodeBlock">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">Public&nbsp;BitmapResize(<span class="cs__keyword">string</span>&nbsp;imageFile,<span class="cs__keyword">string</span>&nbsp;newImageFile)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;img&nbsp;=Image.FromFile(imageFile);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BitmapimgOutput&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Bitmap(img,&nbsp;<span class="cs__number">256</span>,&nbsp;<span class="cs__number">256</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;imgOutput.Save(newImageFile,&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.Imaging.ImageFormat.Jpeg.aspx" target="_blank" title="Auto generated link to System.Drawing.Imaging.ImageFormat.Jpeg">System.Drawing.Imaging.ImageFormat.Jpeg</a>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;imgOutput.Dispose();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;(Bitmap)Image.FromFile(newImageFile);&nbsp;
&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</div>
<p><span style="color:#808080; font-family:NSimSun; font-size:10px">This part of the code is very easy to understand, imageFile for the original image of the full path, newImageFile for the size of the 256x256 after the strong transfer of the path, in order
 to see you after the conversion of the picture long how, so I saved it to Local, so that there are slightly ugly above the code.</span></p>
<p><span style="color:#8d8d8d; font-family:NSimSun"><span style="color:#808080">Step 2, calculate the image of the bar chart:</span><br>
</span></p>
<div class="reCodeBlock">
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>[]&nbsp;GetHisogram(Bitmap&nbsp;img,String&nbsp;name)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BitmapData&nbsp;data&nbsp;=&nbsp;img.LockBits(<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.Rectangle.aspx" target="_blank" title="Auto generated link to System.Drawing.Rectangle">System.Drawing.Rectangle</a>(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;img.Width,&nbsp;img.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageLockMode.ReadWrite,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PixelFormat.Format24bppRgb);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>[]&nbsp;histogram&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">int</span>[<span class="cs__number">256</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">unsafe</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>*&nbsp;ptr&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>*)data.Scan0;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;remain&nbsp;=&nbsp;data.Stride&nbsp;-&nbsp;data.Width&nbsp;*&nbsp;<span class="cs__number">3</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;histogram.Length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;histogram[i]&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;data.Height;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;j&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;j&nbsp;&lt;&nbsp;data.Width;&nbsp;j&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;mean&nbsp;=&nbsp;ptr[<span class="cs__number">0</span>]&nbsp;&#43;&nbsp;ptr[<span class="cs__number">1</span>]&nbsp;&#43;&nbsp;ptr[<span class="cs__number">2</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mean&nbsp;/=&nbsp;<span class="cs__number">3</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;histogram[mean]&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ptr&nbsp;&#43;=&nbsp;<span class="cs__number">3</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ptr&nbsp;&#43;=&nbsp;remain;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;img.UnlockBits(data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;img.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;File.Delete(name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;histogram;&nbsp;
}</pre>
</div>
</div>
</div>
</div>
</div>
<p><span style="color:#808080; font-family:SimSun">This is the shaking of the ghosts of the gray scale bar graph calculation method.</span></p>
<p><span style="color:#808080"><span style="font-family:SimSun">Step 3, calculate the bar graph similarity measure</span><span style="font-family:新細明體,serif">：</span></span></p>
<p><span style="color:#808080; font-family:SimSun">The formula for this step:</span></p>
<p><span style="color:#808080"><span style="font-family:SimSun">Sim(G,S)=<a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/4760._1657CF50D46B0D5C6C510F5F_.jpg"><img src="https://social.technet.microsoft.com/wiki/resized-image.ashx/__size/157x63/__key/communityserver-wikis-components-files/00-00-00-00-05/4760._1657CF50D46B0D5C6C510F5F_.jpg" alt=""></a></span></span></p>
<p><span style="color:#808080"><span style="font-family:SimSun"><a href="http://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-wikis-components-files/00-00-00-00-05/4760._1657CF50D46B0D5C6C510F5F_.jpg"></a></span><span style="font-family:SimSun">Where
 G, S is the long bar graph, and N is the number of color space samples.</span></span></p>
<p><span style="color:#808080"><span style="font-family:SimSun">The implementation code is as follows:</span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Calculate&nbsp;the&nbsp;absolute&nbsp;value&nbsp;after&nbsp;subtraction</span>&nbsp;
Private&nbsp;<span class="cs__keyword">float</span>&nbsp;GetAbs(<span class="cs__keyword">int</span>&nbsp;firstNum,<span class="cs__keyword">int</span>&nbsp;secondNum)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;Float&nbsp;abs&nbsp;=&nbsp;Math.Abs((<span class="cs__keyword">float</span>)firstNum&nbsp;-&nbsp;(<span class="cs__keyword">float</span>)secondNum);&nbsp;
&nbsp;&nbsp;&nbsp;Float&nbsp;result&nbsp;=&nbsp;Math.Max(firstNum,&nbsp;secondNum);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(result&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;abs&nbsp;/&nbsp;result;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="color:#808080">Final calculation results：</span></div>
<div class="endscriptcode"><span style="color:#808080"><br>
</span></div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Final&nbsp;calculation&nbsp;results</span>&nbsp;
Public&nbsp;floatGetResult(<span class="cs__keyword">int</span>[]&nbsp;firstNum,<span class="cs__keyword">int</span>[]&nbsp;scondNum)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(firstNum.Length&nbsp;!=&nbsp;scondNum.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Float&nbsp;result&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Int&nbsp;j&nbsp;=&nbsp;firstNum.Length;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;j;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;&#43;=&nbsp;<span class="cs__number">1</span>&nbsp;-&nbsp;GetAbs(firstNum[i],&nbsp;scondNum[i]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(i&nbsp;&#43;<span class="cs__string">&quot;----&quot;</span>&#43;&nbsp;result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;result&nbsp;/&nbsp;j;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<p><span style="color:#808080">It should be noted that this example is placed in the components and image access, you can according to their own preferences to store：</span></p>
<p><span style="color:#808080"><img id="176964" src="https://i1.code.msdn.s-msft.com/c-realization-of-image-a253ad06/image/file/176964/1/example1.jpg" alt="" width="638" height="321"><br>
</span></p>
