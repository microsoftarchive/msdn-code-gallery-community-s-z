# YUV Image Viewer
## Requires
- Visual Studio 2005
## License
- Apache License, Version 2.0
## Technologies
- Win32
## Topics
- Graphics
- Images
- Image manipulation
- multimedia
- general
## Updated
- 12/20/2012
## Description

<h1>Introduction</h1>
<p><em>&nbsp;Most of the commerical Image Viewer does not support YUV image formate. In this application it is possible to view all the YUV images of different types.</em></p>
<p><br>
<strong style="color:#333333; font-family:verdana; font-size:11px; font-style:normal; font-variant:normal; letter-spacing:normal; line-height:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff"><span>YUV444
 Data Format</span></strong></p>
<p><strong style="color:#333333; font-family:verdana; font-size:11px; font-style:normal; font-variant:normal; letter-spacing:normal; line-height:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff"><span>YUV422
 Data Format</span></strong></p>
<p><strong style="color:#333333; font-family:verdana; font-size:11px; font-style:normal; font-variant:normal; letter-spacing:normal; line-height:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff"><span>YUV411
 Data Format</span></strong></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:x-small"><em>Just all you need is to download the sample YUV images of all the following formate.</em></span></p>
<p><br>
<strong style="color:#333333; font-family:verdana; font-size:11px; font-style:normal; font-variant:normal; letter-spacing:normal; line-height:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff"><span>YUV444
 Data Format</span></strong></p>
<p><strong style="color:#333333; font-family:verdana; font-size:11px; font-style:normal; font-variant:normal; letter-spacing:normal; line-height:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff"><span>YUV422
 Data Format</span></strong></p>
<p><strong style="color:#333333; font-family:verdana; font-size:11px; font-style:normal; font-variant:normal; letter-spacing:normal; line-height:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff"><span>YUV411
 Data Format</span></strong></p>
<p><strong>&nbsp;Both planar and progressive.</strong></p>
<p><strong>Use the following link to download these images.</strong></p>
<p><br>
<a href="http://www.sunrayimage.com/examples.html">http://www.sunrayimage.com/examples.html</a></p>
<p><strong><br>
</strong></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>&nbsp;</p>
<p style="color:#000000; font-family:Verdana; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
Whether you are going to use YUVPlayer, YUVConvertor, YUVAnalyser or YUVEditor, you need to load or save YUV files, and need to specify the right YUV format.</p>
<p style="color:#000000; font-family:Verdana; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
When you select a file to read or , a YUV format selection dialog will pop up, to help you to pick up a right YUV format.</p>
<p style="color:#000000; font-family:Verdana; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
On the other hand, to read a YUV file, you need to specify its data format: whether it is in 4:4:4, 4:2:2 or 4:2:0 sampling format, whether it has one single progressive frame or two interlaced fields, whether its pixel is packed or in planar format.</p>
<p style="color:#000000; font-family:Verdana; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
Whenever a format is selected, and click the RGB button to display it in RGB formate,&nbsp; picture will be displayed. Also you can find the option for save it as BMP formate in your hardisk.Click that option to save it as BMP file.</p>
<p style="color:#000000; font-family:Verdana; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
&nbsp;&nbsp; In addition to this feature you can view the Grayscale Image of the same YUV image.</p>
<p style="color:#000000; font-family:Verdana; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
For example, when a YUV file is&nbsp; loaded, the dialog display is shown as this:</p>
<p style="color:#000000; font-family:Verdana; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
<img id="68249" src="68249-sample%20screen%20shot.jpg" alt=""></p>
<p style="color:#000000; font-family:Verdana; font-size:12px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">int YUV422_Packed(HWND hDlg)
{
FILE *yuvfile;
int	Array_144x88[144][88],Array_144x88_u[144][88],Array_144x88_v[144][88];

int	Array_144x176[144][176],Array_144x176_u[144][176],Array_144x176_v[144][176];

long int Len_Y = 176 * 144 , Len_U=144 * 88 ,Len_V = 144 * 88 , Size;

int a,b,c,d,i,j,m,n,u_m=0,u_n=0,v_m=0,v_n=0;

int Height = 144, Width = 176;




err=fopen_s(&amp;yuvfile ,szFile1,&quot;rb&quot;);
	 if(err)
       {
	     MessageBox(NULL, L&quot;fopen Failed&quot;, L&quot;Error&quot;, MB_OK);
		 return 0;
       }
	  
fseek(yuvfile,0L,SEEK_END);
No_OF_FRAMES = ftell(yuvfile) / (Len_Y &#43; Len_U &#43; Len_V);
rewind(yuvfile);

//READ ALL THE Y VALUES

for ( m = 0; m &lt; 144; m&#43;&#43;)
for ( n = 0; n &lt; 176; n&#43;&#43;)
{
y[m][n] = fgetc(yuvfile);
if(!(n%2))
  {
  Array_144x88_u[u_m][u_n&#43;&#43;]=fgetc(yuvfile);
  if (u_n &gt; 87 ) 
  {
   u_n = 0;
   u_m&#43;&#43;;
   }
  }
 else
  {
  Array_144x88_v[v_m][v_n&#43;&#43;]=fgetc(yuvfile);
  if ( v_n &gt; 87 ) 
   {
   v_n = 0;
   v_m&#43;&#43;;
   }
   }
  }


//READ ALL THE U/V VALUES INTO 176 x 72

for ( Loop = 1 ; Loop &lt;= 2; Loop&#43;&#43;)
{



//STORE THE RESULT IN ANOTHER 2D ARRAY OF SIZE ( 176 x 144 )

for ( i = 0; i &lt; 144 ; i&#43;&#43;)
for ( j = 0; j &lt; 176 ; j&#43;&#43;) 
if ( ! ( j % 2 ) )
{
a = (j&gt;&gt;1)-2;
b = (j&gt;&gt;1)-1;
c = (j&gt;&gt;1);
d = (j&gt;&gt;1)&#43;1;

a = a &lt; 0 ? 0 : a;
b = b &lt; 0 ? 0 : b;
c = c &lt; 0 ? 0 : c;
d = d &lt; 0 ? 0 : d;

a = a &gt;= (Width&gt;&gt;1) ? (Width&gt;&gt;1)-1 : a;
b = b &gt;= (Width&gt;&gt;1) ? (Width&gt;&gt;1)-1 : b;
c = c &gt;= (Width&gt;&gt;1) ? (Width&gt;&gt;1)-1 : c;
d = d &gt;= (Width&gt;&gt;1) ? (Width&gt;&gt;1)-1 : d;


if(Loop==1)
Array_144x176_u[i][j] = ( - 3 * Array_144x88_u[i][a] &#43; 29 * Array_144x88_u[i][b] \
&#43; 111 * Array_144x88_u[i][c] - 9 * Array_144x88_u[i][d] &#43; 64 ) &gt;&gt; 7;
if(Loop==2)
Array_144x176_v[i][j] = ( - 3 * Array_144x88_v[i][a] &#43; 29 * Array_144x88_v[i][b] \
&#43; 111 * Array_144x88_v[i][c] - 9 * Array_144x88_v[i][d] &#43; 64 ) &gt;&gt; 7;
}
else
{
a = (j-3) &gt;&gt; 1;
b = (j-1) &gt;&gt; 1;
c = (j&#43;1) &gt;&gt; 1;
d = (j&#43;3) &gt;&gt; 1;

a = a &lt; 0 ? 0 : a;
b = b &lt; 0 ? 0 : b;
c = c &lt; 0 ? 0 : c;
d = d &lt; 0 ? 0 : d;

a = a &gt;= (Width&gt;&gt;1) ? (Width&gt;&gt;1)-1 : a;
b = b &gt;= (Width&gt;&gt;1) ? (Width&gt;&gt;1)-1 : b;
c = c &gt;= (Width&gt;&gt;1) ? (Width&gt;&gt;1)-1 : c;
d = d &gt;= (Width&gt;&gt;1) ? (Width&gt;&gt;1)-1 : d;
if(Loop==1)
Array_144x176_u[i][j] = ( - 3 * Array_144x88_u[i][a] &#43; 29 * Array_144x88_u[i][b] \
&#43; 111 * Array_144x88_u[i][c] - 9 * Array_144x88_u[i][d] &#43; 64 ) &gt;&gt; 7;
if(Loop==2)
Array_144x176_v[i][j] = ( - 3 * Array_144x88_v[i][a] &#43; 29 * Array_144x88_v[i][b] \
&#43; 111 * Array_144x88_v[i][c] - 9 * Array_144x88_v[i][d] &#43; 64 ) &gt;&gt; 7;


}


for ( i = 0; i &lt; 144 ; i&#43;&#43;)
for ( j = 0; j &lt; 176 ; j&#43;&#43; ) 
if(Loop==1)
u[i][j]=Array_144x176_u[i][j];
else
v[i][j]=Array_144x176_v[i][j];


   } // END OF FOR Loop 


flag=1;
Display(hDlg);
fclose(yuvfile);

}

</pre>
<div class="preview">
<pre class="cplusplus"><span class="cpp__datatype">int</span>&nbsp;YUV422_Packed(<span class="cpp__datatype">HWND</span>&nbsp;hDlg)&nbsp;
{&nbsp;
<span class="cpp__datatype">FILE</span>&nbsp;*yuvfile;&nbsp;
<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;Array_144x88[<span class="cpp__number">144</span>][<span class="cpp__number">88</span>],Array_144x88_u[<span class="cpp__number">144</span>][<span class="cpp__number">88</span>],Array_144x88_v[<span class="cpp__number">144</span>][<span class="cpp__number">88</span>];&nbsp;
&nbsp;
<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;Array_144x176[<span class="cpp__number">144</span>][<span class="cpp__number">176</span>],Array_144x176_u[<span class="cpp__number">144</span>][<span class="cpp__number">176</span>],Array_144x176_v[<span class="cpp__number">144</span>][<span class="cpp__number">176</span>];&nbsp;
&nbsp;
<span class="cpp__datatype">long</span>&nbsp;<span class="cpp__datatype">int</span>&nbsp;Len_Y&nbsp;=&nbsp;<span class="cpp__number">176</span>&nbsp;*&nbsp;<span class="cpp__number">144</span>&nbsp;,&nbsp;Len_U=<span class="cpp__number">144</span>&nbsp;*&nbsp;<span class="cpp__number">88</span>&nbsp;,Len_V&nbsp;=&nbsp;<span class="cpp__number">144</span>&nbsp;*&nbsp;<span class="cpp__number">88</span>&nbsp;,&nbsp;Size;&nbsp;
&nbsp;
<span class="cpp__datatype">int</span>&nbsp;a,b,c,d,i,j,m,n,u_m=<span class="cpp__number">0</span>,u_n=<span class="cpp__number">0</span>,v_m=<span class="cpp__number">0</span>,v_n=<span class="cpp__number">0</span>;&nbsp;
&nbsp;
<span class="cpp__datatype">int</span>&nbsp;Height&nbsp;=&nbsp;<span class="cpp__number">144</span>,&nbsp;Width&nbsp;=&nbsp;<span class="cpp__number">176</span>;&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;
err=fopen_s(&amp;yuvfile&nbsp;,szFile1,<span class="cpp__string">&quot;rb&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(err)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(NULL,&nbsp;L<span class="cpp__string">&quot;fopen&nbsp;Failed&quot;</span>,&nbsp;L<span class="cpp__string">&quot;Error&quot;</span>,&nbsp;MB_OK);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
fseek(yuvfile,0L,SEEK_END);&nbsp;
No_OF_FRAMES&nbsp;=&nbsp;ftell(yuvfile)&nbsp;/&nbsp;(Len_Y&nbsp;&#43;&nbsp;Len_U&nbsp;&#43;&nbsp;Len_V);&nbsp;
rewind(yuvfile);&nbsp;
&nbsp;
<span class="cpp__com">//READ&nbsp;ALL&nbsp;THE&nbsp;Y&nbsp;VALUES</span>&nbsp;
&nbsp;
<span class="cpp__keyword">for</span>&nbsp;(&nbsp;m&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;m&nbsp;&lt;&nbsp;<span class="cpp__number">144</span>;&nbsp;m&#43;&#43;)&nbsp;
<span class="cpp__keyword">for</span>&nbsp;(&nbsp;n&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;n&nbsp;&lt;&nbsp;<span class="cpp__number">176</span>;&nbsp;n&#43;&#43;)&nbsp;
{&nbsp;
y[m][n]&nbsp;=&nbsp;fgetc(yuvfile);&nbsp;
<span class="cpp__keyword">if</span>(!(n%<span class="cpp__number">2</span>))&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;Array_144x88_u[u_m][u_n&#43;&#43;]=fgetc(yuvfile);&nbsp;
&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(u_n&nbsp;&gt;&nbsp;<span class="cpp__number">87</span>&nbsp;)&nbsp;&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;u_n&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;u_m&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;}&nbsp;
&nbsp;<span class="cpp__keyword">else</span>&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;Array_144x88_v[v_m][v_n&#43;&#43;]=fgetc(yuvfile);&nbsp;
&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;v_n&nbsp;&gt;&nbsp;<span class="cpp__number">87</span>&nbsp;)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;v_n&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;v_m&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
<span class="cpp__com">//READ&nbsp;ALL&nbsp;THE&nbsp;U/V&nbsp;VALUES&nbsp;INTO&nbsp;176&nbsp;x&nbsp;72</span>&nbsp;
&nbsp;
<span class="cpp__keyword">for</span>&nbsp;(&nbsp;Loop&nbsp;=&nbsp;<span class="cpp__number">1</span>&nbsp;;&nbsp;Loop&nbsp;&lt;=&nbsp;<span class="cpp__number">2</span>;&nbsp;Loop&#43;&#43;)&nbsp;
{&nbsp;
&nbsp;
&nbsp;
&nbsp;
<span class="cpp__com">//STORE&nbsp;THE&nbsp;RESULT&nbsp;IN&nbsp;ANOTHER&nbsp;2D&nbsp;ARRAY&nbsp;OF&nbsp;SIZE&nbsp;(&nbsp;176&nbsp;x&nbsp;144&nbsp;)</span>&nbsp;
&nbsp;
<span class="cpp__keyword">for</span>&nbsp;(&nbsp;i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="cpp__number">144</span>&nbsp;;&nbsp;i&#43;&#43;)&nbsp;
<span class="cpp__keyword">for</span>&nbsp;(&nbsp;j&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;j&nbsp;&lt;&nbsp;<span class="cpp__number">176</span>&nbsp;;&nbsp;j&#43;&#43;)&nbsp;&nbsp;
<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!&nbsp;(&nbsp;j&nbsp;%&nbsp;<span class="cpp__number">2</span>&nbsp;)&nbsp;)&nbsp;
{&nbsp;
a&nbsp;=&nbsp;(j&gt;&gt;<span class="cpp__number">1</span>)-<span class="cpp__number">2</span>;&nbsp;
b&nbsp;=&nbsp;(j&gt;&gt;<span class="cpp__number">1</span>)-<span class="cpp__number">1</span>;&nbsp;
c&nbsp;=&nbsp;(j&gt;&gt;<span class="cpp__number">1</span>);&nbsp;
d&nbsp;=&nbsp;(j&gt;&gt;<span class="cpp__number">1</span>)&#43;<span class="cpp__number">1</span>;&nbsp;
&nbsp;
a&nbsp;=&nbsp;a&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>&nbsp;?&nbsp;<span class="cpp__number">0</span>&nbsp;:&nbsp;a;&nbsp;
b&nbsp;=&nbsp;b&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>&nbsp;?&nbsp;<span class="cpp__number">0</span>&nbsp;:&nbsp;b;&nbsp;
c&nbsp;=&nbsp;c&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>&nbsp;?&nbsp;<span class="cpp__number">0</span>&nbsp;:&nbsp;c;&nbsp;
d&nbsp;=&nbsp;d&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>&nbsp;?&nbsp;<span class="cpp__number">0</span>&nbsp;:&nbsp;d;&nbsp;
&nbsp;
a&nbsp;=&nbsp;a&nbsp;&gt;=&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)&nbsp;?&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)-<span class="cpp__number">1</span>&nbsp;:&nbsp;a;&nbsp;
b&nbsp;=&nbsp;b&nbsp;&gt;=&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)&nbsp;?&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)-<span class="cpp__number">1</span>&nbsp;:&nbsp;b;&nbsp;
c&nbsp;=&nbsp;c&nbsp;&gt;=&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)&nbsp;?&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)-<span class="cpp__number">1</span>&nbsp;:&nbsp;c;&nbsp;
d&nbsp;=&nbsp;d&nbsp;&gt;=&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)&nbsp;?&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)-<span class="cpp__number">1</span>&nbsp;:&nbsp;d;&nbsp;
&nbsp;
&nbsp;
<span class="cpp__keyword">if</span>(Loop==<span class="cpp__number">1</span>)&nbsp;
Array_144x176_u[i][j]&nbsp;=&nbsp;(&nbsp;-&nbsp;<span class="cpp__number">3</span>&nbsp;*&nbsp;Array_144x88_u[i][a]&nbsp;&#43;&nbsp;<span class="cpp__number">29</span>&nbsp;*&nbsp;Array_144x88_u[i][b]&nbsp;\&nbsp;
&#43;&nbsp;<span class="cpp__number">111</span>&nbsp;*&nbsp;Array_144x88_u[i][c]&nbsp;-&nbsp;<span class="cpp__number">9</span>&nbsp;*&nbsp;Array_144x88_u[i][d]&nbsp;&#43;&nbsp;<span class="cpp__number">64</span>&nbsp;)&nbsp;&gt;&gt;&nbsp;<span class="cpp__number">7</span>;&nbsp;
<span class="cpp__keyword">if</span>(Loop==<span class="cpp__number">2</span>)&nbsp;
Array_144x176_v[i][j]&nbsp;=&nbsp;(&nbsp;-&nbsp;<span class="cpp__number">3</span>&nbsp;*&nbsp;Array_144x88_v[i][a]&nbsp;&#43;&nbsp;<span class="cpp__number">29</span>&nbsp;*&nbsp;Array_144x88_v[i][b]&nbsp;\&nbsp;
&#43;&nbsp;<span class="cpp__number">111</span>&nbsp;*&nbsp;Array_144x88_v[i][c]&nbsp;-&nbsp;<span class="cpp__number">9</span>&nbsp;*&nbsp;Array_144x88_v[i][d]&nbsp;&#43;&nbsp;<span class="cpp__number">64</span>&nbsp;)&nbsp;&gt;&gt;&nbsp;<span class="cpp__number">7</span>;&nbsp;
}&nbsp;
<span class="cpp__keyword">else</span>&nbsp;
{&nbsp;
a&nbsp;=&nbsp;(j<span class="cpp__number">-3</span>)&nbsp;&gt;&gt;&nbsp;<span class="cpp__number">1</span>;&nbsp;
b&nbsp;=&nbsp;(j<span class="cpp__number">-1</span>)&nbsp;&gt;&gt;&nbsp;<span class="cpp__number">1</span>;&nbsp;
c&nbsp;=&nbsp;(j<span class="cpp__number">&#43;1</span>)&nbsp;&gt;&gt;&nbsp;<span class="cpp__number">1</span>;&nbsp;
d&nbsp;=&nbsp;(j<span class="cpp__number">&#43;3</span>)&nbsp;&gt;&gt;&nbsp;<span class="cpp__number">1</span>;&nbsp;
&nbsp;
a&nbsp;=&nbsp;a&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>&nbsp;?&nbsp;<span class="cpp__number">0</span>&nbsp;:&nbsp;a;&nbsp;
b&nbsp;=&nbsp;b&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>&nbsp;?&nbsp;<span class="cpp__number">0</span>&nbsp;:&nbsp;b;&nbsp;
c&nbsp;=&nbsp;c&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>&nbsp;?&nbsp;<span class="cpp__number">0</span>&nbsp;:&nbsp;c;&nbsp;
d&nbsp;=&nbsp;d&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>&nbsp;?&nbsp;<span class="cpp__number">0</span>&nbsp;:&nbsp;d;&nbsp;
&nbsp;
a&nbsp;=&nbsp;a&nbsp;&gt;=&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)&nbsp;?&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)-<span class="cpp__number">1</span>&nbsp;:&nbsp;a;&nbsp;
b&nbsp;=&nbsp;b&nbsp;&gt;=&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)&nbsp;?&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)-<span class="cpp__number">1</span>&nbsp;:&nbsp;b;&nbsp;
c&nbsp;=&nbsp;c&nbsp;&gt;=&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)&nbsp;?&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)-<span class="cpp__number">1</span>&nbsp;:&nbsp;c;&nbsp;
d&nbsp;=&nbsp;d&nbsp;&gt;=&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)&nbsp;?&nbsp;(Width&gt;&gt;<span class="cpp__number">1</span>)-<span class="cpp__number">1</span>&nbsp;:&nbsp;d;&nbsp;
<span class="cpp__keyword">if</span>(Loop==<span class="cpp__number">1</span>)&nbsp;
Array_144x176_u[i][j]&nbsp;=&nbsp;(&nbsp;-&nbsp;<span class="cpp__number">3</span>&nbsp;*&nbsp;Array_144x88_u[i][a]&nbsp;&#43;&nbsp;<span class="cpp__number">29</span>&nbsp;*&nbsp;Array_144x88_u[i][b]&nbsp;\&nbsp;
&#43;&nbsp;<span class="cpp__number">111</span>&nbsp;*&nbsp;Array_144x88_u[i][c]&nbsp;-&nbsp;<span class="cpp__number">9</span>&nbsp;*&nbsp;Array_144x88_u[i][d]&nbsp;&#43;&nbsp;<span class="cpp__number">64</span>&nbsp;)&nbsp;&gt;&gt;&nbsp;<span class="cpp__number">7</span>;&nbsp;
<span class="cpp__keyword">if</span>(Loop==<span class="cpp__number">2</span>)&nbsp;
Array_144x176_v[i][j]&nbsp;=&nbsp;(&nbsp;-&nbsp;<span class="cpp__number">3</span>&nbsp;*&nbsp;Array_144x88_v[i][a]&nbsp;&#43;&nbsp;<span class="cpp__number">29</span>&nbsp;*&nbsp;Array_144x88_v[i][b]&nbsp;\&nbsp;
&#43;&nbsp;<span class="cpp__number">111</span>&nbsp;*&nbsp;Array_144x88_v[i][c]&nbsp;-&nbsp;<span class="cpp__number">9</span>&nbsp;*&nbsp;Array_144x88_v[i][d]&nbsp;&#43;&nbsp;<span class="cpp__number">64</span>&nbsp;)&nbsp;&gt;&gt;&nbsp;<span class="cpp__number">7</span>;&nbsp;
&nbsp;
&nbsp;
}&nbsp;
&nbsp;
&nbsp;
<span class="cpp__keyword">for</span>&nbsp;(&nbsp;i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="cpp__number">144</span>&nbsp;;&nbsp;i&#43;&#43;)&nbsp;
<span class="cpp__keyword">for</span>&nbsp;(&nbsp;j&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;j&nbsp;&lt;&nbsp;<span class="cpp__number">176</span>&nbsp;;&nbsp;j&#43;&#43;&nbsp;)&nbsp;&nbsp;
<span class="cpp__keyword">if</span>(Loop==<span class="cpp__number">1</span>)&nbsp;
u[i][j]=Array_144x176_u[i][j];&nbsp;
<span class="cpp__keyword">else</span>&nbsp;
v[i][j]=Array_144x176_v[i][j];&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;<span class="cpp__com">//&nbsp;END&nbsp;OF&nbsp;FOR&nbsp;Loop&nbsp;</span>&nbsp;
&nbsp;
&nbsp;
flag=<span class="cpp__number">1</span>;&nbsp;
Display(hDlg);&nbsp;
fclose(yuvfile);&nbsp;
&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
