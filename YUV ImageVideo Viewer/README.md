# YUV Image/Video Viewer
## Requires
- Visual Studio 2005
## License
- Apache License, Version 2.0
## Technologies
- Win32
## Topics
- Windows Forms
- Imaging
- UI Design
- Load Image
## Updated
- 05/23/2013
## Description

<p>YUV Image/Video Viewer</p>
<p><br>
Very less number of applications supports YUV Video/Still playing Options.</p>
<h1><span>Visual Studio 2005 or Newer<br>
</span></h1>
<p><em>no need of any other <br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>In this YUV Viewer you can view any YUV444,</em><em>YUV422,</em><em>YUV420
</em><em>Still/Video Files.It has the provision of calculating the total no of frames, Play ,Pause save as BMP options.</em></p>
<p><br>
<em>This application supports:</em></p>
<p><em>YUV 444 </em></p>
<p><em>YUV 422</em></p>
<p><em>YUV 420&nbsp; </em></p>
<p>&nbsp;</p>
<p><strong><span>YUV444 Data Format</span></strong></p>
<p><strong><span>&nbsp;</span></strong></p>
<p><span>The YUV444 data format transmits 24 bits per pixel. Each pixel is assigned unique Y, U and V values&mdash;1 byte for each value, making it the most straightforward format to understand.</span></p>
<p><span>&nbsp;</span></p>
<p><span>The bytes are ordered in the image in the following manner, where Y, U, V represent a single byte of color or brightness value, and<span>&nbsp;
</span>0, 1, 2&hellip; represent the pixel numbers associated with those values:</span></p>
<p><span>&nbsp;</span></p>
<blockquote dir="ltr" style="margin-right:0px">
<p><span>U0 Y0 V0 U1 Y1 V1 U2 Y2 V2&hellip;</span></p>
</blockquote>
<p><span>&nbsp;</span></p>
<p><span>This order results in the following data structure for each pixel:</span></p>
<p><span>&nbsp;</span></p>
<div align="center">
<table border="1" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td width="98" valign="top">
<p><strong><span><span style="font-family:Arial">Pixel Number</span></span></strong></p>
</td>
<td width="98" valign="top">
<p><strong><span><span style="font-family:Arial">Pixel </span></span></strong><strong><span><span style="font-family:Arial">Values</span></span></strong></p>
</td>
</tr>
<tr>
<td width="98" valign="top">
<p><span><span style="font-family:Arial">0</span></span></p>
</td>
<td width="98" valign="top">
<p><span><span style="font-family:Arial">U0Y0V0</span></span></p>
</td>
</tr>
<tr>
<td width="98" valign="top">
<p><span><span style="font-family:Arial">1</span></span></p>
</td>
<td width="98" valign="top">
<p><span><span style="font-family:Arial">U1Y1V1</span></span></p>
</td>
</tr>
<tr>
<td width="98" valign="top">
<p><span><span style="font-family:Arial">2</span></span></p>
</td>
<td width="98" valign="top">
<p><span><span style="font-family:Arial">U2Y2V2</span></span></p>
</td>
</tr>
<tr>
<td width="98" valign="top">
<p><strong><span><span style="font-family:Arial">&hellip;</span></span></strong></p>
</td>
<td width="98" valign="top">
<p><strong><span><span style="font-family:Arial">&hellip;</span></span></strong></p>
</td>
</tr>
</tbody>
</table>
</div>
<p><span>&nbsp;</span></p>
<p><strong><span>YUV422 Data Format</span></strong></p>
<p><span>&nbsp;</span></p>
<p><span>The YUV422 data format shares U and V values between two pixels. As a result, these values are transmitted to the PC image buffer only once for every two pixels, resulting in an average transmission rate of 16 bits per pixel.
</span></p>
<p><span>&nbsp;</span></p>
<p><span>The bytes are ordered in the image in the following manner:</span></p>
<p><span>&nbsp;</span></p>
<blockquote dir="ltr" style="margin-right:0px">
<p><span>U0 Y0 V0 Y1 U2 Y2 V2 Y3 U4 Y4 V4&hellip;</span></p>
</blockquote>
<p><span>&nbsp;</span></p>
<p><span>This order results in the following data structure for each pixel:</span></p>
<p><span>&nbsp;</span></p>
<table border="1" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td width="98" valign="top">
<p><a name="_WWID10000456"></a><strong><span><span style="font-family:Arial">Pixel Number</span></span></strong></p>
</td>
<td width="98" valign="top">
<p><a name="_WWID10000457"></a><strong><span><span style="font-family:Arial">Pixel
</span></span></strong><strong><span><span style="font-family:Arial">Values</span></span></strong></p>
</td>
</tr>
<tr>
<td width="98" valign="top">
<p><a name="_WWID10000459"></a><span><span style="font-family:Arial">0</span></span></p>
</td>
<td width="98" valign="top">
<p><a name="_WWID10000460"></a><span><span style="font-family:Arial">U0Y0V0</span></span></p>
</td>
</tr>
<tr>
<td width="98" valign="top">
<p><a name="_WWID10000462"></a><span><span style="font-family:Arial">1</span></span></p>
</td>
<td width="98" valign="top">
<p><a name="_WWID10000463"></a><span><span style="font-family:Arial">U0Y1V0</span></span></p>
</td>
</tr>
<tr>
<td width="98" valign="top">
<p><a name="_WWID10000465"></a><span><span style="font-family:Arial">2</span></span></p>
</td>
<td width="98" valign="top">
<p><a name="_WWID10000466"></a><span><span style="font-family:Arial">U2Y2V2</span></span></p>
</td>
</tr>
<tr>
<td width="98" valign="top">
<p><a name="_WWID10000468"></a><span><span style="font-family:Arial">3</span></span></p>
</td>
<td width="98" valign="top">
<p><a name="_WWID10000469"></a><span><span style="font-family:Arial">U2Y3V2</span></span></p>
</td>
</tr>
<tr>
<td width="98" valign="top">
<p><span><span style="font-family:Arial">4</span></span></p>
</td>
<td width="98" valign="top">
<p><span><span style="font-family:Arial">U4Y4V4</span></span></p>
</td>
</tr>
<tr>
<td width="98" valign="top">
<p><strong><span><span style="font-family:Arial">&hellip;</span></span></strong></p>
</td>
<td width="98" valign="top">
<p><strong><span><span style="font-family:Arial">&hellip;</span></span></strong></p>
</td>
</tr>
</tbody>
</table>
<p><img src="http://www.fourcc.org/images/yplane.gif" alt="" width="200" height="127">
<img src="http://www.fourcc.org/images/u2plane.gif" alt="" width="200" height="127">
<img src="http://www.fourcc.org/images/v2plane.gif" alt="" width="200" height="127"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus">Click&nbsp;here&nbsp;to&nbsp;add&nbsp;yo<span class="cpp__com">//&nbsp;YUV_Viewer&nbsp;Application.cpp&nbsp;:&nbsp;Defines&nbsp;the&nbsp;entry&nbsp;point&nbsp;for&nbsp;the&nbsp;application.</span>&nbsp;
<span class="cpp__com">//</span><span class="cpp__preproc">&nbsp;
&nbsp;
#include&nbsp;&quot;stdafx.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;Commdlg.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;windows.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;stdio.h&quot;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&quot;YUV_Viewer&nbsp;Application.h&quot;</span><span class="cpp__preproc">&nbsp;
&nbsp;
#define&nbsp;MAX_LOADSTRING&nbsp;100</span><span class="cpp__preproc">&nbsp;
&nbsp;
#define&nbsp;B(Col,Row)&nbsp;g_pRGB_Buffer[&nbsp;&nbsp;&nbsp;&nbsp;3*((Col)&nbsp;&#43;&nbsp;g_Width&nbsp;*&nbsp;(Row))]</span><span class="cpp__preproc">&nbsp;
#define&nbsp;G(Col,Row)&nbsp;g_pRGB_Buffer[1&nbsp;&#43;&nbsp;3*((Col)&nbsp;&#43;&nbsp;g_Width&nbsp;*&nbsp;(Row))]</span><span class="cpp__preproc">&nbsp;
#define&nbsp;R(Col,Row)&nbsp;g_pRGB_Buffer[2&nbsp;&#43;&nbsp;3*((Col)&nbsp;&#43;&nbsp;g_Width&nbsp;*&nbsp;(Row))]</span><span class="cpp__preproc">&nbsp;
&nbsp;
#define&nbsp;TB(Col,Row)&nbsp;g_pTRGB_Buffer[&nbsp;&nbsp;&nbsp;&nbsp;3*((Col)&nbsp;&#43;&nbsp;g_Width&nbsp;*&nbsp;(Row))]</span><span class="cpp__preproc">&nbsp;
#define&nbsp;TG(Col,Row)&nbsp;g_pTRGB_Buffer[1&nbsp;&#43;&nbsp;3*((Col)&nbsp;&#43;&nbsp;g_Width&nbsp;*&nbsp;(Row))]</span><span class="cpp__preproc">&nbsp;
#define&nbsp;TR(Col,Row)&nbsp;g_pTRGB_Buffer[2&nbsp;&#43;&nbsp;3*((Col)&nbsp;&#43;&nbsp;g_Width&nbsp;*&nbsp;(Row))]</span><span class="cpp__preproc">&nbsp;
&nbsp;
#define&nbsp;SB(Col,Row)&nbsp;BGR_Buffer[&nbsp;&nbsp;&nbsp;&nbsp;3*((Col)&nbsp;&#43;&nbsp;g_Width&nbsp;*&nbsp;(Row))]</span><span class="cpp__preproc">&nbsp;
#define&nbsp;SG(Col,Row)&nbsp;BGR_Buffer[1&nbsp;&#43;&nbsp;3*((Col)&nbsp;&#43;&nbsp;g_Width&nbsp;*&nbsp;(Row))]</span><span class="cpp__preproc">&nbsp;
#define&nbsp;SR(Col,Row)&nbsp;BGR_Buffer[2&nbsp;&#43;&nbsp;3*((Col)&nbsp;&#43;&nbsp;g_Width&nbsp;*&nbsp;(Row))]</span><span class="cpp__preproc">&nbsp;
&nbsp;
#define&nbsp;Y(Col,Row)&nbsp;YUV444_Buffer[&nbsp;&nbsp;&nbsp;&nbsp;3*((Col)&nbsp;&#43;&nbsp;g_Width&nbsp;*&nbsp;(Row))]</span><span class="cpp__preproc">&nbsp;
#define&nbsp;U(Col,Row)&nbsp;YUV444_Buffer[1&nbsp;&#43;&nbsp;3*((Col)&nbsp;&#43;&nbsp;g_Width&nbsp;*&nbsp;(Row))]</span><span class="cpp__preproc">&nbsp;
#define&nbsp;V(Col,Row)&nbsp;YUV444_Buffer[2&nbsp;&#43;&nbsp;3*((Col)&nbsp;&#43;&nbsp;g_Width&nbsp;*&nbsp;(Row))]</span>&nbsp;
&nbsp;
&nbsp;
<span class="cpp__datatype">BYTE</span>&nbsp;Clamp(<span class="cpp__datatype">int</span>&nbsp;n)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(n&nbsp;&gt;=&nbsp;<span class="cpp__number">255</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;n&nbsp;=&nbsp;<span class="cpp__number">255</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>(n&lt;=<span class="cpp__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;n=<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;n;&nbsp;
}&nbsp;
<span class="cpp__com">//&nbsp;Global&nbsp;Variables:</span>&nbsp;
<span class="cpp__datatype">HINSTANCE</span>&nbsp;hInst;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;current&nbsp;instance</span>&nbsp;
<span class="cpp__datatype">TCHAR</span>&nbsp;szTitle[MAX_LOADSTRING];&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;The&nbsp;title&nbsp;bar&nbsp;text</span>&nbsp;
<span class="cpp__datatype">TCHAR</span>&nbsp;szWindowClass[MAX_LOADSTRING];&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;the&nbsp;main&nbsp;window&nbsp;class&nbsp;name</span>&nbsp;
<span class="cpp__datatype">WCHAR</span>&nbsp;g_SrcFileName[<span class="cpp__number">260</span>];&nbsp;
<span class="cpp__datatype">DWORD</span>&nbsp;g_BytesRead=<span class="cpp__number">0</span>,g_BytesWritten=<span class="cpp__number">0</span>,g_Size=<span class="cpp__number">0</span>,g_CurrentFrame;&nbsp;
<span class="cpp__datatype">bool</span>&nbsp;g_flag=<span class="cpp__number">0</span>,g_Cflag=<span class="cpp__number">0</span>;&nbsp;
<span class="cpp__datatype">UINT</span>&nbsp;g_Width=<span class="cpp__number">0</span>,g_Height=<span class="cpp__number">0</span>,g_Frames=<span class="cpp__number">1</span>,g_HSPosition=<span class="cpp__number">0</span>,g_VTPosition=<span class="cpp__number">0</span>;&nbsp;
<span class="cpp__datatype">WCHAR</span>&nbsp;g_CoOrdinates[<span class="cpp__number">20</span>];&nbsp;
&nbsp;
<span class="cpp__datatype">BYTE</span>&nbsp;*g_pRGB_Buffer;&nbsp;
<span class="cpp__datatype">BYTE</span>&nbsp;*g_pTRGB_Buffer;&nbsp;
&nbsp;
BITMAPINFO&nbsp;Bitmapinfo;&nbsp;
BITMAPINFOHEADER&nbsp;bmpinfo;&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;Forward&nbsp;declarations&nbsp;of&nbsp;functions&nbsp;included&nbsp;in&nbsp;this&nbsp;code&nbsp;module:</span>&nbsp;
<span class="cpp__datatype">ATOM</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyRegisterClass(<span class="cpp__datatype">HINSTANCE</span>&nbsp;hInstance);&nbsp;
<span class="cpp__datatype">BOOL</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitInstance(<span class="cpp__datatype">HINSTANCE</span>,&nbsp;<span class="cpp__datatype">int</span>);&nbsp;
<span class="cpp__datatype">LRESULT</span>&nbsp;CALLBACK&nbsp;&nbsp;&nbsp;&nbsp;WndProc(<span class="cpp__datatype">HWND</span>,&nbsp;<span class="cpp__datatype">UINT</span>,&nbsp;<span class="cpp__datatype">WPARAM</span>,&nbsp;<span class="cpp__datatype">LPARAM</span>);&nbsp;
<span class="cpp__datatype">INT_PTR</span>&nbsp;CALLBACK&nbsp;&nbsp;&nbsp;&nbsp;About(<span class="cpp__datatype">HWND</span>,&nbsp;<span class="cpp__datatype">UINT</span>,&nbsp;<span class="cpp__datatype">WPARAM</span>,&nbsp;<span class="cpp__datatype">LPARAM</span>);&nbsp;
<span class="cpp__datatype">INT_PTR</span>&nbsp;CALLBACK&nbsp;&nbsp;&nbsp;&nbsp;YUVViewer(<span class="cpp__datatype">HWND</span>,&nbsp;<span class="cpp__datatype">UINT</span>,&nbsp;<span class="cpp__datatype">WPARAM</span>,&nbsp;<span class="cpp__datatype">LPARAM</span>);&nbsp;
<span class="cpp__datatype">INT_PTR</span>&nbsp;CALLBACK&nbsp;&nbsp;&nbsp;&nbsp;FullScreen(<span class="cpp__datatype">HWND</span>,&nbsp;<span class="cpp__datatype">UINT</span>,&nbsp;<span class="cpp__datatype">WPARAM</span>,<span class="cpp__datatype">LPARAM</span>);&nbsp;
<span class="cpp__datatype">INT_PTR</span>&nbsp;CALLBACK&nbsp;&nbsp;&nbsp;&nbsp;ActualSize(<span class="cpp__datatype">HWND</span>,&nbsp;<span class="cpp__datatype">UINT</span>,&nbsp;<span class="cpp__datatype">WPARAM</span>,<span class="cpp__datatype">LPARAM</span>);&nbsp;
&nbsp;
<span class="cpp__datatype">BYTE</span>*&nbsp;YUV444toRGB888(<span class="cpp__datatype">BYTE</span>&nbsp;*YUV444_Buffer,<span class="cpp__datatype">BYTE</span>&nbsp;*g_pRGB_Buffer,<span class="cpp__datatype">UINT</span>&nbsp;g_Width,<span class="cpp__datatype">UINT</span>&nbsp;g_Height);&nbsp;
<span class="cpp__datatype">BYTE</span>*&nbsp;YUV422toYUV444(<span class="cpp__datatype">BYTE</span>&nbsp;*YUV422_Buffer,<span class="cpp__datatype">UINT</span>&nbsp;g_Width,<span class="cpp__datatype">UINT</span>&nbsp;g_Height);&nbsp;
<span class="cpp__datatype">BYTE</span>*&nbsp;YUV420toYUV444(<span class="cpp__datatype">BYTE</span>&nbsp;*YUV420_Buffer,<span class="cpp__datatype">UINT</span>&nbsp;g_Width,<span class="cpp__datatype">UINT</span>&nbsp;g_Height);&nbsp;
<span class="cpp__datatype">bool</span>&nbsp;SaveBMP&nbsp;(&nbsp;<span class="cpp__datatype">BYTE</span>*&nbsp;Buffer,&nbsp;<span class="cpp__datatype">int</span>&nbsp;width,&nbsp;<span class="cpp__datatype">int</span>&nbsp;height,&nbsp;<span class="cpp__datatype">long</span>&nbsp;paddedsize,&nbsp;<span class="cpp__datatype">LPCTSTR</span>&nbsp;bmpfile&nbsp;);&nbsp;
<span class="cpp__datatype">BYTE</span>*&nbsp;ConvertRGBToBMPBuffer&nbsp;(&nbsp;<span class="cpp__datatype">BYTE</span>*&nbsp;Buffer,&nbsp;<span class="cpp__datatype">int</span>&nbsp;width,&nbsp;<span class="cpp__datatype">int</span>&nbsp;height);&nbsp;
<span class="cpp__keyword">void</span>&nbsp;OnPaint(<span class="cpp__datatype">HWND</span>&nbsp;hDlg);&nbsp;
<span class="cpp__keyword">void</span>&nbsp;ActualPaint(<span class="cpp__datatype">HWND</span>&nbsp;hDlg);&nbsp;
&nbsp;
<span class="cpp__datatype">int</span>&nbsp;APIENTRY&nbsp;_tWinMain(<span class="cpp__datatype">HINSTANCE</span>&nbsp;hInstance,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HINSTANCE</span>&nbsp;hPrevInstance,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">LPTSTR</span>&nbsp;&nbsp;&nbsp;&nbsp;lpCmdLine,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nCmdShow)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UNREFERENCED_PARAMETER(hPrevInstance);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UNREFERENCED_PARAMETER(lpCmdLine);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;TODO:&nbsp;Place&nbsp;code&nbsp;here.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MSG&nbsp;msg;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HACCEL</span>&nbsp;hAccelTable;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Initialize&nbsp;global&nbsp;strings</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;LoadString(hInstance,&nbsp;IDS_APP_TITLE,&nbsp;szTitle,&nbsp;MAX_LOADSTRING);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;LoadString(hInstance,&nbsp;IDC_YUV_VIEWERAPPLICATION,&nbsp;szWindowClass,&nbsp;MAX_LOADSTRING);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MyRegisterClass(hInstance);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Perform&nbsp;application&nbsp;initialization:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(!InitInstance&nbsp;(hInstance,&nbsp;nCmdShow))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hAccelTable&nbsp;=&nbsp;LoadAccelerators(hInstance,&nbsp;MAKEINTRESOURCE(IDC_YUV_VIEWERAPPLICATION));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Main&nbsp;message&nbsp;loop:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">while</span>&nbsp;(GetMessage(&amp;msg,&nbsp;NULL,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__number">0</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(!TranslateAccelerator(msg.hwnd,&nbsp;hAccelTable,&nbsp;&amp;msg))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TranslateMessage(&amp;msg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DispatchMessage(&amp;msg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(<span class="cpp__datatype">int</span>)&nbsp;msg.wParam;&nbsp;
}&nbsp;
&nbsp;
&nbsp;
&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;FUNCTION:&nbsp;MyRegisterClass()</span>&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;PURPOSE:&nbsp;Registers&nbsp;the&nbsp;window&nbsp;class.</span>&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;COMMENTS:</span>&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;&nbsp;&nbsp;This&nbsp;function&nbsp;and&nbsp;its&nbsp;usage&nbsp;are&nbsp;only&nbsp;necessary&nbsp;if&nbsp;you&nbsp;want&nbsp;this&nbsp;code</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;&nbsp;&nbsp;to&nbsp;be&nbsp;compatible&nbsp;with&nbsp;Win32&nbsp;systems&nbsp;prior&nbsp;to&nbsp;the&nbsp;'RegisterClassEx'</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;&nbsp;&nbsp;function&nbsp;that&nbsp;was&nbsp;added&nbsp;to&nbsp;Windows&nbsp;95.&nbsp;It&nbsp;is&nbsp;important&nbsp;to&nbsp;call&nbsp;this&nbsp;function</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;&nbsp;&nbsp;so&nbsp;that&nbsp;the&nbsp;application&nbsp;will&nbsp;get&nbsp;'well&nbsp;formed'&nbsp;small&nbsp;icons&nbsp;associated</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;&nbsp;&nbsp;with&nbsp;it.</span>&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__datatype">ATOM</span>&nbsp;MyRegisterClass(<span class="cpp__datatype">HINSTANCE</span>&nbsp;hInstance)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WNDCLASSEX&nbsp;wcex;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wcex.cbSize&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(WNDCLASSEX);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wcex.style&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;CS_HREDRAW&nbsp;|&nbsp;CS_VREDRAW;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wcex.lpfnWndProc&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;WndProc;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wcex.cbClsExtra&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wcex.cbWndExtra&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wcex.hInstance&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;hInstance;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wcex.hIcon&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;LoadIcon(hInstance,&nbsp;MAKEINTRESOURCE(IDI_YUV_VIEWERAPPLICATION));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wcex.hCursor&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;LoadCursor(NULL,&nbsp;IDC_ARROW);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wcex.hbrBackground&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;(<span class="cpp__datatype">HBRUSH</span>)(COLOR_WINDOW<span class="cpp__number">&#43;1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wcex.lpszMenuName&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;MAKEINTRESOURCE(IDC_YUV_VIEWERAPPLICATION);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wcex.lpszClassName&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;szWindowClass;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wcex.hIconSm&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;LoadIcon(wcex.hInstance,&nbsp;MAKEINTRESOURCE(IDI_SMALL));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;RegisterClassEx(&amp;wcex);&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;&nbsp;FUNCTION:&nbsp;InitInstance(HINSTANCE,&nbsp;int)</span>&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;&nbsp;PURPOSE:&nbsp;Saves&nbsp;instance&nbsp;handle&nbsp;and&nbsp;creates&nbsp;main&nbsp;window</span>&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;&nbsp;COMMENTS:</span>&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;In&nbsp;this&nbsp;function,&nbsp;we&nbsp;save&nbsp;the&nbsp;instance&nbsp;handle&nbsp;in&nbsp;a&nbsp;global&nbsp;variable&nbsp;and</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;create&nbsp;and&nbsp;display&nbsp;the&nbsp;main&nbsp;program&nbsp;window.</span>&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__datatype">BOOL</span>&nbsp;InitInstance(<span class="cpp__datatype">HINSTANCE</span>&nbsp;hInstance,&nbsp;<span class="cpp__datatype">int</span>&nbsp;nCmdShow)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HWND</span>&nbsp;hWnd;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;hInst&nbsp;=&nbsp;hInstance;&nbsp;<span class="cpp__com">//&nbsp;Store&nbsp;instance&nbsp;handle&nbsp;in&nbsp;our&nbsp;global&nbsp;variable</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;hWnd&nbsp;=&nbsp;CreateWindow(szWindowClass,&nbsp;szTitle,&nbsp;WS_OVERLAPPEDWINDOW,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CW_USEDEFAULT,&nbsp;<span class="cpp__number">0</span>,&nbsp;CW_USEDEFAULT,&nbsp;<span class="cpp__number">0</span>,&nbsp;NULL,&nbsp;NULL,&nbsp;hInstance,&nbsp;NULL);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(!hWnd)&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;FALSE;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;ShowWindow(hWnd,&nbsp;nCmdShow);&nbsp;
&nbsp;&nbsp;&nbsp;UpdateWindow(hWnd);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;TRUE;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;FUNCTION:&nbsp;WndProc(HWND,&nbsp;UINT,&nbsp;WPARAM,&nbsp;LPARAM)</span>&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;PURPOSE:&nbsp;&nbsp;Processes&nbsp;messages&nbsp;for&nbsp;the&nbsp;main&nbsp;window.</span>&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;WM_COMMAND&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;process&nbsp;the&nbsp;application&nbsp;menu</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;WM_PAINT&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;Paint&nbsp;the&nbsp;main&nbsp;window</span>&nbsp;
<span class="cpp__com">//&nbsp;&nbsp;WM_DESTROY&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;post&nbsp;a&nbsp;quit&nbsp;message&nbsp;and&nbsp;return</span>&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__com">//</span>&nbsp;
<span class="cpp__datatype">LRESULT</span>&nbsp;CALLBACK&nbsp;WndProc(<span class="cpp__datatype">HWND</span>&nbsp;hWnd,&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;message,&nbsp;<span class="cpp__datatype">WPARAM</span>&nbsp;wParam,&nbsp;<span class="cpp__datatype">LPARAM</span>&nbsp;lParam)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;wmId,&nbsp;wmEvent;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PAINTSTRUCT&nbsp;ps;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HDC</span>&nbsp;hdc;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>&nbsp;(message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_COMMAND:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wmId&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;LOWORD(wParam);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wmEvent&nbsp;=&nbsp;HIWORD(wParam);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Parse&nbsp;the&nbsp;menu&nbsp;selections:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>&nbsp;(wmId)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;ID_YUVVIEWER_OPENAPPLICATION:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DialogBox(hInst,&nbsp;MAKEINTRESOURCE(IDD_DIALOG),&nbsp;hWnd,&nbsp;YUVViewer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDM_ABOUT:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DialogBox(hInst,&nbsp;MAKEINTRESOURCE(IDD_ABOUTBOX),&nbsp;hWnd,&nbsp;About);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDM_EXIT:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DestroyWindow(hWnd);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">default</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;DefWindowProc(hWnd,&nbsp;message,&nbsp;wParam,&nbsp;lParam);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_PAINT:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hdc&nbsp;=&nbsp;BeginPaint(hWnd,&nbsp;&amp;ps);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;TODO:&nbsp;Add&nbsp;any&nbsp;drawing&nbsp;code&nbsp;here...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EndPaint(hWnd,&nbsp;&amp;ps);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_DESTROY:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PostQuitMessage(<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">default</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;DefWindowProc(hWnd,&nbsp;message,&nbsp;wParam,&nbsp;lParam);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;Message&nbsp;handler&nbsp;for&nbsp;about&nbsp;box.</span>&nbsp;
<span class="cpp__datatype">INT_PTR</span>&nbsp;CALLBACK&nbsp;About(<span class="cpp__datatype">HWND</span>&nbsp;hDlg,&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;message,&nbsp;<span class="cpp__datatype">WPARAM</span>&nbsp;wParam,&nbsp;<span class="cpp__datatype">LPARAM</span>&nbsp;lParam)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UNREFERENCED_PARAMETER(lParam);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>&nbsp;(message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_INITDIALOG:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(<span class="cpp__datatype">INT_PTR</span>)TRUE;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_COMMAND:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(LOWORD(wParam)&nbsp;==&nbsp;IDOK&nbsp;||&nbsp;LOWORD(wParam)&nbsp;==&nbsp;IDCANCEL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EndDialog(hDlg,&nbsp;LOWORD(wParam));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(<span class="cpp__datatype">INT_PTR</span>)TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(<span class="cpp__datatype">INT_PTR</span>)FALSE;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">INT_PTR</span>&nbsp;CALLBACK&nbsp;ActualSize(<span class="cpp__datatype">HWND</span>&nbsp;hDlg,&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;message,&nbsp;<span class="cpp__datatype">WPARAM</span>&nbsp;wParam,&nbsp;<span class="cpp__datatype">LPARAM</span>&nbsp;lParam)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UNREFERENCED_PARAMETER(lParam);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>&nbsp;(message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_INITDIALOG:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;Dx=<span class="cpp__number">5</span>,Dy=<span class="cpp__number">5</span>,DWidth=GetSystemMetrics(SM_CXSCREEN)-<span class="cpp__number">30</span>,DHeight=GetSystemMetrics(SM_CYSCREEN)-<span class="cpp__number">95</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetWindowPos(hDlg,HWND_BOTTOM,Dx,Dy,DWidth<span class="cpp__number">&#43;25</span>,DHeight<span class="cpp__number">&#43;46</span>,SWP_SHOWWINDOW);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SCROLLINFO&nbsp;HS_Info,VS_Info;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HS_Info.cbSize&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(HS_Info);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HS_Info.fMask&nbsp;&nbsp;=&nbsp;SIF_RANGE&nbsp;|&nbsp;SIF_PAGE&nbsp;|&nbsp;SIF_POS;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HS_Info.nMin&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HS_Info.nMax&nbsp;&nbsp;&nbsp;=&nbsp;g_Width-DWidth;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HS_Info.nPage&nbsp;&nbsp;=&nbsp;<span class="cpp__number">1</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HS_Info.nPos&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VS_Info.cbSize&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(VS_Info);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VS_Info.fMask&nbsp;&nbsp;=&nbsp;SIF_RANGE&nbsp;|&nbsp;SIF_PAGE&nbsp;|&nbsp;SIF_POS;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VS_Info.nMin&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VS_Info.nMax&nbsp;&nbsp;&nbsp;=&nbsp;g_Height-DHeight;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VS_Info.nPage&nbsp;&nbsp;=&nbsp;<span class="cpp__number">1</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VS_Info.nPos&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetScrollInfo(hDlg,&nbsp;SB_HORZ,&nbsp;&amp;HS_Info,&nbsp;TRUE);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetScrollInfo(hDlg,&nbsp;SB_VERT,&nbsp;&amp;VS_Info,&nbsp;TRUE);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetWindowText(hDlg,(<span class="cpp__datatype">LPCWSTR</span>)g_CoOrdinates);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(<span class="cpp__datatype">INT_PTR</span>)TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_PAINT:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PAINTSTRUCT&nbsp;ps;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HDC</span>&nbsp;hdc&nbsp;=&nbsp;BeginPaint(hDlg,&nbsp;&amp;ps);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ActualPaint(hDlg);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DeleteDC(hdc);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_VSCROLL:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_VTPosition&nbsp;=&nbsp;GetScrollPos(hDlg,&nbsp;SB_VERT);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>&nbsp;(LOWORD(wParam))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;SB_THUMBPOSITION:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_VTPosition&nbsp;=&nbsp;HIWORD(wParam);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetScrollPos(hDlg,SB_VERT,g_VTPosition,<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;swprintf(g_CoOrdinates,L<span class="cpp__string">&quot;%d,%d&quot;</span>,g_HSPosition,g_VTPosition);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetWindowText(hDlg,(<span class="cpp__datatype">LPCWSTR</span>)g_CoOrdinates);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ActualPaint(hDlg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;SB_THUMBTRACK:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_VTPosition&nbsp;=&nbsp;HIWORD(wParam);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;swprintf(g_CoOrdinates,L<span class="cpp__string">&quot;%d,%d&quot;</span>,g_HSPosition,g_VTPosition);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetWindowText(hDlg,(<span class="cpp__datatype">LPCWSTR</span>)g_CoOrdinates);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ActualPaint(hDlg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__keyword">break</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_MOUSEWHEEL:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;zDelta&nbsp;=&nbsp;(<span class="cpp__datatype">short</span>)&nbsp;HIWORD(wParam)&nbsp;/&nbsp;WHEEL_DELTA;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;VTPosition=g_VTPosition;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VTPosition&#43;=((-zDelta)*<span class="cpp__number">4</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(VTPosition&gt;=<span class="cpp__number">0</span>&amp;&amp;VTPosition&lt;=g_Height<span class="cpp__number">-480</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_VTPosition=VTPosition;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetScrollPos(hDlg,SB_VERT,g_VTPosition,<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;swprintf(g_CoOrdinates,L<span class="cpp__string">&quot;%d,%d&quot;</span>,g_HSPosition,g_VTPosition);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetWindowText(hDlg,(<span class="cpp__datatype">LPCWSTR</span>)g_CoOrdinates);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ActualPaint(hDlg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_HSCROLL:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_HSPosition&nbsp;=&nbsp;GetScrollPos(hDlg,&nbsp;SB_HORZ);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>&nbsp;(LOWORD(wParam))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;SB_THUMBPOSITION:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_HSPosition&nbsp;=&nbsp;HIWORD(wParam);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;swprintf(g_CoOrdinates,L<span class="cpp__string">&quot;%d,%d&quot;</span>,g_HSPosition,g_VTPosition);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetWindowText(hDlg,(<span class="cpp__datatype">LPCWSTR</span>)g_CoOrdinates);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetScrollPos(hDlg,SB_HORZ,g_HSPosition,<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ActualPaint(hDlg);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;SB_THUMBTRACK:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_HSPosition&nbsp;=&nbsp;HIWORD(wParam);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;swprintf(g_CoOrdinates,L<span class="cpp__string">&quot;%d,%d&quot;</span>,g_HSPosition,g_VTPosition);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetWindowText(hDlg,(<span class="cpp__datatype">LPCWSTR</span>)g_CoOrdinates);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ActualPaint(hDlg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_COMMAND:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(LOWORD(wParam)&nbsp;==&nbsp;IDCANCEL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EndDialog(hDlg,&nbsp;LOWORD(wParam));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(<span class="cpp__datatype">INT_PTR</span>)TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(<span class="cpp__datatype">INT_PTR</span>)FALSE;&nbsp;
}&nbsp;
<span class="cpp__keyword">void</span>&nbsp;DisableButtons(<span class="cpp__datatype">HWND</span>&nbsp;hDlg)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HWND</span>&nbsp;BPlay,BNext,BPrev,BStop,BPlayInf;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BPlay=GetDlgItem(hDlg,IDC_PLAY);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BNext=GetDlgItem(hDlg,IDC_NEXT);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BPrev=GetDlgItem(hDlg,IDC_PREVIOUS);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BStop=GetDlgItem(hDlg,IDC_STOP);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BPlayInf=GetDlgItem(hDlg,IDC_PLAYINF);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(BPlay,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(BNext,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(BPrev,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(BStop,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(BPlay,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(BPlayInf,<span class="cpp__number">0</span>);&nbsp;
}&nbsp;
<span class="cpp__keyword">void</span>&nbsp;EnableButtons(<span class="cpp__datatype">HWND</span>&nbsp;hDlg)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HWND</span>&nbsp;BPlay,BNext,BPrev,BStop,BPlayInf;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BPlay=GetDlgItem(hDlg,IDC_PLAY);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BNext=GetDlgItem(hDlg,IDC_NEXT);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BPrev=GetDlgItem(hDlg,IDC_PREVIOUS);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BStop=GetDlgItem(hDlg,IDC_STOP);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BPlayInf=GetDlgItem(hDlg,IDC_PLAYINF);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(BPlay,<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(BNext,<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(BPrev,<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(BStop,<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(BPlay,<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EnableWindow(BPlayInf,<span class="cpp__number">1</span>);&nbsp;
}&nbsp;
<span class="cpp__keyword">void</span>&nbsp;ActualPaint(<span class="cpp__datatype">HWND</span>&nbsp;hDlg)&nbsp;
{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;Dx=<span class="cpp__number">4</span>,Dy=<span class="cpp__number">25</span>,DWidth=GetSystemMetrics(SM_CXSCREEN)-<span class="cpp__number">30</span>,DHeight=GetSystemMetrics(SM_CYSCREEN)-<span class="cpp__number">95</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;offset=((g_CurrentFrame<span class="cpp__number">-1</span>)*g_Width*g_Height*<span class="cpp__number">3</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HDC</span>&nbsp;Bhdc=GetWindowDC(hDlg);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetBkMode(Bhdc,TRANSPARENT);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(g_Width&gt;=DWidth)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StretchDIBits(Bhdc,Dx,Dy&#43;DHeight,DWidth,-DHeight,g_HSPosition,g_VTPosition,DWidth,DHeight,g_pTRGB_Buffer&#43;offset,&amp;Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>((g_Width&gt;=<span class="cpp__number">1024</span>)&amp;&amp;(g_Width&lt;=DWidth))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StretchDIBits(Bhdc,Dx,Dy&#43;g_Height,g_Width,-g_Height,g_HSPosition,g_VTPosition,g_Width,g_Height,g_pTRGB_Buffer&#43;offset,&amp;Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>((g_Width&gt;=<span class="cpp__number">640</span>)&amp;&amp;(g_Width&lt;<span class="cpp__number">1024</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StretchDIBits(Bhdc,<span class="cpp__number">310</span>,g_Height<span class="cpp__number">&#43;160</span>,g_Width,-g_Height,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,g_Width,g_Height,g_pTRGB_Buffer&#43;offset,&amp;Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>((g_Width&gt;=<span class="cpp__number">320</span>)&amp;&amp;(g_Width&lt;<span class="cpp__number">640</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StretchDIBits(Bhdc,<span class="cpp__number">450</span>,g_Height<span class="cpp__number">&#43;250</span>,g_Width,-g_Height,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,g_Width,g_Height,g_pTRGB_Buffer&#43;offset,&amp;Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>((g_Width&gt;=<span class="cpp__number">176</span>)&amp;&amp;(g_Width&lt;<span class="cpp__number">320</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StretchDIBits(Bhdc,<span class="cpp__number">550</span>,g_Height<span class="cpp__number">&#43;300</span>,g_Width,-g_Height,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,g_Width,g_Height,g_pTRGB_Buffer&#43;offset,&amp;Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DeleteDC(Bhdc);&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">INT_PTR</span>&nbsp;CALLBACK&nbsp;FullScreen(<span class="cpp__datatype">HWND</span>&nbsp;hDlg,&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;message,&nbsp;<span class="cpp__datatype">WPARAM</span>&nbsp;wParam,&nbsp;<span class="cpp__datatype">LPARAM</span>&nbsp;lParam)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UNREFERENCED_PARAMETER(lParam);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>&nbsp;(message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_PAINT:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;Dx=<span class="cpp__number">550</span>,Dy=<span class="cpp__number">300</span>,DWidth=GetSystemMetrics(SM_CXSCREEN)-<span class="cpp__number">342</span>,DHeight=GetSystemMetrics(SM_CYSCREEN);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;offset=((g_CurrentFrame<span class="cpp__number">-1</span>)*g_Width*g_Height*<span class="cpp__number">3</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PAINTSTRUCT&nbsp;ps;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HDC</span>&nbsp;hdc&nbsp;=&nbsp;BeginPaint(hDlg,&nbsp;&amp;ps);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HDC</span>&nbsp;Bhdc=GetWindowDC(hDlg);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BitBlt(Bhdc,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,GetSystemMetrics(SM_CXSCREEN),GetSystemMetrics(SM_CYSCREEN),NULL,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,BLACKNESS);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(g_Width&gt;=DWidth)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetStretchBltMode(Bhdc,HALFTONE&nbsp;);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StretchDIBits(Bhdc,<span class="cpp__number">155</span>,<span class="cpp__number">768</span>,<span class="cpp__number">1024</span>,-<span class="cpp__number">768</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,g_Width,g_Height,g_pTRGB_Buffer&#43;offset,&amp;Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>((g_Width&gt;=<span class="cpp__number">640</span>)&amp;&amp;(g_Width&lt;=DWidth))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StretchDIBits(Bhdc,<span class="cpp__number">310</span>,g_Height<span class="cpp__number">&#43;160</span>,g_Width,-g_Height,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,g_Width,g_Height,g_pTRGB_Buffer&#43;offset,&amp;Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>((g_Width&gt;=<span class="cpp__number">320</span>)&amp;&amp;(g_Width&lt;=<span class="cpp__number">640</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StretchDIBits(Bhdc,<span class="cpp__number">450</span>,g_Height<span class="cpp__number">&#43;250</span>,g_Width,-g_Height,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,g_Width,g_Height,g_pTRGB_Buffer&#43;offset,&amp;Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>((g_Width&gt;=<span class="cpp__number">176</span>)&amp;&amp;(g_Width&lt;=<span class="cpp__number">320</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StretchDIBits(Bhdc,<span class="cpp__number">550</span>,g_Height<span class="cpp__number">&#43;300</span>,g_Width,-g_Height,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,g_Width,g_Height,g_pTRGB_Buffer&#43;offset,&amp;Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EndPaint(hDlg,&nbsp;&amp;ps);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DeleteDC(hdc);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DeleteDC(Bhdc);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_INITDIALOG:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetWindowPos(hDlg,HWND_BOTTOM,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,GetSystemMetrics(SM_CXSCREEN),GetSystemMetrics(SM_CYSCREEN),SWP_SHOWWINDOW);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(<span class="cpp__datatype">INT_PTR</span>)TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_RBUTTONDOWN:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EndDialog(hDlg,&nbsp;LOWORD(wParam));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(<span class="cpp__datatype">INT_PTR</span>)TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_COMMAND:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(LOWORD(wParam)&nbsp;==&nbsp;IDCANCEL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EndDialog(hDlg,&nbsp;LOWORD(wParam));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(<span class="cpp__datatype">INT_PTR</span>)TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(<span class="cpp__datatype">INT_PTR</span>)FALSE;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">INT_PTR</span>&nbsp;CALLBACK&nbsp;YUVViewer(<span class="cpp__datatype">HWND</span>&nbsp;hDlg,&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;message,&nbsp;<span class="cpp__datatype">WPARAM</span>&nbsp;wParam,&nbsp;<span class="cpp__datatype">LPARAM</span>&nbsp;lParam)&nbsp;
{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PAINTSTRUCT&nbsp;ps;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HDC</span>&nbsp;hdc;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;UNREFERENCED_PARAMETER(lParam);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;g_Frames=GetDlgItemInt(hDlg,IDC_FRAMES,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>&nbsp;(message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_INITDIALOG:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemText(hDlg,IDC_COMBO1,L<span class="cpp__string">&quot;Select&nbsp;YUV&nbsp;Type&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemText(hDlg,IDC_FRAMES,L<span class="cpp__string">&quot;1&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetWindowPos(hDlg,HWND_DESKTOP,<span class="cpp__number">200</span>,<span class="cpp__number">5</span>,<span class="cpp__number">900</span>,<span class="cpp__number">675</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendDlgItemMessage(hDlg,IDC_COMBO1,CB_ADDSTRING,<span class="cpp__number">0</span>,(<span class="cpp__datatype">LPARAM</span>)L<span class="cpp__string">&quot;YUV444&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendDlgItemMessage(hDlg,IDC_COMBO1,CB_ADDSTRING,<span class="cpp__number">0</span>,(<span class="cpp__datatype">LPARAM</span>)L<span class="cpp__string">&quot;YUV422&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SendDlgItemMessage(hDlg,IDC_COMBO1,CB_ADDSTRING,<span class="cpp__number">0</span>,(<span class="cpp__datatype">LPARAM</span>)L<span class="cpp__string">&quot;YUV420&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisableButtons(hDlg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(<span class="cpp__datatype">INT_PTR</span>)TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_PAINT:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hdc&nbsp;=&nbsp;BeginPaint(hDlg,&nbsp;&amp;ps);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnPaint(hDlg);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;TODO:&nbsp;Add&nbsp;any&nbsp;drawing&nbsp;code&nbsp;here...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EndPaint(hDlg,&nbsp;&amp;ps);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_TIMER:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>&nbsp;(wParam)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDT_300MILLISECONDS:&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*MessageBox(hDlg,L&quot;5&nbsp;Seconds&nbsp;Up&quot;,L&quot;Timer&nbsp;Function&quot;,0);*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;CurrentSelection=<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CurrentSelection=GetDlgItemInt(hDlg,IDC_CURFRAM,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(CurrentSelection==g_Frames)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemInt(hDlg,IDC_CURFRAM,<span class="cpp__number">1</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemInt(hDlg,IDC_CURFRAM,CurrentSelection<span class="cpp__number">&#43;1</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_CurrentFrame=GetDlgItemInt(hDlg,IDC_CURFRAM,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnPaint(hDlg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;WM_COMMAND:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>&nbsp;(wParam)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDC_ACTUALSIZE:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DialogBox(hInst,&nbsp;MAKEINTRESOURCE(IDD_ACTUAL),&nbsp;hDlg,&nbsp;ActualSize);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDC_FULLSCREEN:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DialogBox(hInst,&nbsp;MAKEINTRESOURCE(IDD_FULLSCREEN),&nbsp;hDlg,&nbsp;FullScreen);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDC_NEXT:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;CurrentSelection=<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CurrentSelection=GetDlgItemInt(hDlg,IDC_CURFRAM,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(CurrentSelection==g_Frames)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemInt(hDlg,IDC_CURFRAM,<span class="cpp__number">1</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemInt(hDlg,IDC_CURFRAM,CurrentSelection<span class="cpp__number">&#43;1</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_CurrentFrame=GetDlgItemInt(hDlg,IDC_CURFRAM,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnPaint(hDlg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDC_PLAYINF:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(IsDlgButtonChecked(hDlg,IDC_PLAYINF)==&nbsp;BST_CHECKED)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*MessageBox(hDlg,L&quot;Button&nbsp;Checked&quot;,L&quot;Check&nbsp;Button&quot;,0);*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetTimer(hDlg,IDT_300MILLISECONDS,<span class="cpp__number">200</span>,(TIMERPROC)&nbsp;NULL);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemInt(hDlg,IDC_CURFRAM,<span class="cpp__number">1</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_CurrentFrame=GetDlgItemInt(hDlg,IDC_CURFRAM,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(IsDlgButtonChecked(hDlg,IDC_PLAYINF)==&nbsp;BST_UNCHECKED)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;KillTimer(hDlg,IDT_300MILLISECONDS);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*MessageBox(hDlg,L&quot;Check&nbsp;Button&nbsp;Un-Checked&quot;,L&quot;Check&nbsp;Button&quot;,0);*/</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDC_PREVIOUS:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;CurrentSelection=<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CurrentSelection=GetDlgItemInt(hDlg,IDC_CURFRAM,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(CurrentSelection==<span class="cpp__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemInt(hDlg,IDC_CURFRAM,g_Frames,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemInt(hDlg,IDC_CURFRAM,CurrentSelection<span class="cpp__number">-1</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_CurrentFrame=GetDlgItemInt(hDlg,IDC_CURFRAM,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnPaint(hDlg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDC_PLAY:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetTimer(hDlg,IDT_300MILLISECONDS,<span class="cpp__number">300</span>,(TIMERPROC)&nbsp;NULL);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemInt(hDlg,IDC_CURFRAM,<span class="cpp__number">1</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_CurrentFrame=GetDlgItemInt(hDlg,IDC_CURFRAM,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDC_STOP:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;KillTimer(hDlg,IDT_300MILLISECONDS);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDC_SAVEAS:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OPENFILENAME&nbsp;ofn;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;common&nbsp;dialog&nbsp;box&nbsp;structure&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ZeroMemory(&amp;ofn,&nbsp;<span class="cpp__keyword">sizeof</span>(ofn));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.lStructSize&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(ofn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.hwndOwner&nbsp;=&nbsp;hDlg;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.lpstrFile&nbsp;=&nbsp;g_SrcFileName;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.lpstrFile[<span class="cpp__number">0</span>]&nbsp;=&nbsp;<span class="cpp__string">'\0'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.nMaxFile&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(g_SrcFileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.lpstrFilter&nbsp;=&nbsp;L<span class="cpp__string">&quot;Bitmap\0*.BMP\0&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.nFilterIndex&nbsp;=&nbsp;<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.lpstrFileTitle&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.nMaxFileTitle&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.lpstrInitialDir&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.lpstrDefExt&nbsp;=&nbsp;L<span class="cpp__string">&quot;BMP&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.Flags&nbsp;=&nbsp;OFN_PATHMUSTEXIST&nbsp;|&nbsp;OFN_FILEMUSTEXIST;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_Size=&nbsp;g_Width*g_Height*<span class="cpp__number">3</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(GetSaveFileName(&amp;ofn)==TRUE)&nbsp;<span class="cpp__com">//&nbsp;Display&nbsp;the&nbsp;Open&nbsp;dialog&nbsp;box.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*For&nbsp;any&nbsp;Operation&nbsp;on&nbsp;File&nbsp;Handle&nbsp;Use&nbsp;here.*/</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*BYTE&nbsp;*BMP_Buffer=ConvertRGBToBMPBuffer(g_pTRGB_Buffer,g_Width,g_Height);*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*SaveBMP(BMP_Buffer,g_Width,g_Height,g_Size,ofn.lpstrFile);*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SaveBMP(g_pTRGB_Buffer,g_Width,g_Height,g_Size,ofn.lpstrFile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*delete[]BMP_Buffer;*/</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*SetDlgItemText(hDlg,IDC_EDIT1,L&quot;&quot;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemInt(hDlg,IDC_WIDTH,0,0);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemInt(hDlg,IDC_HEIGHT,0,0);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemText(hDlg,IDC_COMBO1,L&quot;Select&nbsp;YUV&nbsp;Type&quot;);*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDC_DISPLAY:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InvalidateRect(hDlg,<span class="cpp__number">0</span>,<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisableButtons(hDlg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_Width=GetDlgItemInt(hDlg,IDC_WIDTH,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_Height=GetDlgItemInt(hDlg,IDC_HEIGHT,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemText(hDlg,IDC_CURFRAM,L<span class="cpp__string">&quot;1&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_CurrentFrame=GetDlgItemInt(hDlg,IDC_CURFRAM,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(g_Width==<span class="cpp__number">0</span>||g_Height==<span class="cpp__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hDlg,L<span class="cpp__string">&quot;Please&nbsp;Enter&nbsp;the&nbsp;Width&nbsp;&amp;&nbsp;Height&nbsp;of&nbsp;Image&quot;</span>,L<span class="cpp__string">&quot;Select&nbsp;Width&nbsp;&amp;&nbsp;Height&quot;</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HWND</span>&nbsp;Combo=GetDlgItem(hDlg,IDC_COMBO1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;index=SendMessage(Combo,CB_GETCURSEL,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">switch</span>(index)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;<span class="cpp__number">2</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*MessageBox(hDlg,L&quot;You&nbsp;have&nbsp;selected&nbsp;3rd&nbsp;Item&nbsp;-&nbsp;YUV444&quot;,L&quot;Item&nbsp;Selected&quot;,0);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ZeroMemory(&amp;Bitmapinfo,<span class="cpp__keyword">sizeof</span>(Bitmapinfo));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ZeroMemory(&amp;bmpinfo,<span class="cpp__keyword">sizeof</span>(bmpinfo));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biSize&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(BITMAPINFOHEADER);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biWidth&nbsp;=&nbsp;g_Width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biHeight&nbsp;=&nbsp;g_Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biPlanes&nbsp;=&nbsp;<span class="cpp__number">1</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;we&nbsp;only&nbsp;have&nbsp;one&nbsp;bitplane</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biBitCount&nbsp;=&nbsp;<span class="cpp__number">24</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;RGB&nbsp;mode&nbsp;is&nbsp;24&nbsp;bits</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biCompression&nbsp;=&nbsp;BI_RGB;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biSizeImage&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;can&nbsp;be&nbsp;0&nbsp;for&nbsp;24&nbsp;bit&nbsp;images</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biXPelsPerMeter&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;paint&nbsp;and&nbsp;PSP&nbsp;use&nbsp;this&nbsp;values</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biYPelsPerMeter&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biClrUsed&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;we&nbsp;are&nbsp;in&nbsp;RGB&nbsp;mode&nbsp;and&nbsp;have&nbsp;no&nbsp;palette</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biClrImportant&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;all&nbsp;colors&nbsp;are&nbsp;important</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HANDLE</span>&nbsp;File_Handle;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;file&nbsp;handle&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bitmapinfo.bmiHeader=bmpinfo;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;File_Handle=CreateFile(g_SrcFileName,GENERIC_READ,<span class="cpp__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(LPSECURITY_ATTRIBUTES)&nbsp;NULL,OPEN_EXISTING,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FILE_ATTRIBUTE_NORMAL,(<span class="cpp__datatype">HANDLE</span>)&nbsp;NULL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*MessageBox(hDlg,L&quot;File&nbsp;Opened&nbsp;Successfully&quot;,L&quot;Item&nbsp;Selected&quot;,0);*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;FileSize=GetFileSize(File_Handle,NULL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_Frames=((<span class="cpp__datatype">UINT</span>)FileSize/(g_Width*g_Height*<span class="cpp__number">3</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemInt(hDlg,IDC_FRAMES,g_Frames,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(g_Frames&gt;<span class="cpp__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnableButtons(hDlg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;g_Size;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_Size=g_Width*g_Height*g_Frames*<span class="cpp__number">3</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(g_Size&lt;FileSize)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*MessageBox(hDlg,L&quot;Check&nbsp;the&nbsp;Width&nbsp;&amp;&nbsp;Height&nbsp;of&nbsp;File&nbsp;&amp;&nbsp;File&nbsp;Size&nbsp;&quot;,0,0);*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;File_Handle&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BYTE</span>&nbsp;*YUV444_Buffer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;YUV444_Buffer=(<span class="cpp__datatype">BYTE</span>*)GlobalAlloc(<span class="cpp__number">0</span>,g_Size);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;YUV444_Buffer==NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hDlg,L<span class="cpp__string">&quot;Cannot&nbsp;Create&nbsp;Buffer&nbsp;to&nbsp;Hold&nbsp;Data&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;ReadFile&nbsp;(&nbsp;File_Handle,&nbsp;YUV444_Buffer,&nbsp;g_Size,&nbsp;&amp;g_BytesRead,&nbsp;NULL&nbsp;)&nbsp;==&nbsp;<span class="cpp__keyword">false</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hDlg,L<span class="cpp__string">&quot;File&nbsp;Cannot&nbsp;be&nbsp;Opened&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;File_Handle&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;File_Handle&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_pTRGB_Buffer=YUV444toRGB888(YUV444_Buffer,g_pTRGB_Buffer,g_Width,g_Height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;g_pTRGB_Buffer==NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hDlg,L<span class="cpp__string">&quot;Cannot&nbsp;Create&nbsp;g_pTRGB_Buffer&nbsp;Buffer&nbsp;to&nbsp;Hold&nbsp;Data&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_flag=<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnPaint(hDlg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GlobalFree(YUV444_Buffer);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;<span class="cpp__number">1</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*MessageBox(hDlg,L&quot;You&nbsp;have&nbsp;selected&nbsp;2nd&nbsp;Item&nbsp;-&nbsp;YUV422&quot;,L&quot;Item&nbsp;Selected&quot;,0);*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ZeroMemory(&amp;Bitmapinfo,<span class="cpp__keyword">sizeof</span>(Bitmapinfo));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ZeroMemory(&amp;bmpinfo,<span class="cpp__keyword">sizeof</span>(bmpinfo));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biSize&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(BITMAPINFOHEADER);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biWidth&nbsp;=&nbsp;g_Width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biHeight&nbsp;=&nbsp;g_Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biPlanes&nbsp;=&nbsp;<span class="cpp__number">1</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;we&nbsp;only&nbsp;have&nbsp;one&nbsp;bitplane</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biBitCount&nbsp;=&nbsp;<span class="cpp__number">24</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;RGB&nbsp;mode&nbsp;is&nbsp;24&nbsp;bits</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biCompression&nbsp;=&nbsp;BI_RGB;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biSizeImage&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;can&nbsp;be&nbsp;0&nbsp;for&nbsp;24&nbsp;bit&nbsp;images</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biXPelsPerMeter&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;paint&nbsp;and&nbsp;PSP&nbsp;use&nbsp;this&nbsp;values</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biYPelsPerMeter&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biClrUsed&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;we&nbsp;are&nbsp;in&nbsp;RGB&nbsp;mode&nbsp;and&nbsp;have&nbsp;no&nbsp;palette</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biClrImportant&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;all&nbsp;colors&nbsp;are&nbsp;important</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HANDLE</span>&nbsp;File_Handle;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;file&nbsp;handle&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bitmapinfo.bmiHeader=bmpinfo;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;File_Handle=CreateFile(g_SrcFileName,GENERIC_READ,<span class="cpp__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(LPSECURITY_ATTRIBUTES)&nbsp;NULL,OPEN_EXISTING,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FILE_ATTRIBUTE_NORMAL,(<span class="cpp__datatype">HANDLE</span>)&nbsp;NULL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*MessageBox(hDlg,L&quot;File&nbsp;Opened&nbsp;Successfully&quot;,L&quot;Item&nbsp;Selected&quot;,0);*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;FileSize=GetFileSize(File_Handle,NULL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_Frames=((<span class="cpp__datatype">UINT</span>)FileSize/(g_Width*g_Height*<span class="cpp__number">2</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemInt(hDlg,IDC_FRAMES,g_Frames,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(g_Frames&gt;<span class="cpp__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnableButtons(hDlg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_Size=g_Width*g_Height*g_Frames;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>((g_Size*<span class="cpp__number">2</span>)&lt;FileSize)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hDlg,L<span class="cpp__string">&quot;Check&nbsp;the&nbsp;Width&nbsp;&amp;&nbsp;Height&nbsp;of&nbsp;File&nbsp;&amp;&nbsp;File&nbsp;Size&nbsp;&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;File_Handle&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BYTE</span>*&nbsp;YUV422_Buffer=&nbsp;(<span class="cpp__datatype">BYTE</span>*)GlobalAlloc(<span class="cpp__number">0</span>,g_Size*<span class="cpp__number">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;YUV422_Buffer==NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hDlg,L<span class="cpp__string">&quot;Cannot&nbsp;Create&nbsp;YUV422_Buffer&nbsp;Buffer&nbsp;to&nbsp;Hold&nbsp;Data&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;ReadFile&nbsp;(&nbsp;File_Handle,&nbsp;YUV422_Buffer,&nbsp;g_Size*<span class="cpp__number">2</span>,&nbsp;&amp;g_BytesRead,&nbsp;NULL&nbsp;)&nbsp;==&nbsp;<span class="cpp__keyword">false</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hDlg,L<span class="cpp__string">&quot;File&nbsp;Cannot&nbsp;be&nbsp;Opened&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;File_Handle&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;File_Handle&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BYTE</span>*&nbsp;YUV444_Buffer=YUV422toYUV444(YUV422_Buffer,g_Width,g_Height);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;YUV444_Buffer==NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hDlg,L<span class="cpp__string">&quot;Cannot&nbsp;Create&nbsp;YUV444_Buffer&nbsp;Buffer&nbsp;to&nbsp;Hold&nbsp;Data&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_pTRGB_Buffer=YUV444toRGB888(YUV444_Buffer,g_pTRGB_Buffer,g_Width,g_Height);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;g_pTRGB_Buffer==NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hDlg,L<span class="cpp__string">&quot;422:Cannot&nbsp;Create&nbsp;g_pTRGB_Buffer&nbsp;Buffer&nbsp;to&nbsp;Hold&nbsp;Data&quot;</span>,<span class="cpp__number">0</span>,MB_OK);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_flag=<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnPaint(hDlg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GlobalFree(YUV444_Buffer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GlobalFree(YUV422_Buffer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;<span class="cpp__number">0</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*MessageBox(hDlg,L&quot;You&nbsp;have&nbsp;selected&nbsp;1&nbsp;st&nbsp;Item&nbsp;-&nbsp;YUV420&quot;,L&quot;Item&nbsp;Selected&quot;,0);*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ZeroMemory(&amp;Bitmapinfo,<span class="cpp__keyword">sizeof</span>(Bitmapinfo));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ZeroMemory(&amp;bmpinfo,<span class="cpp__keyword">sizeof</span>(bmpinfo));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biSize&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(BITMAPINFOHEADER);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biWidth&nbsp;=&nbsp;g_Width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biHeight&nbsp;=&nbsp;g_Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biPlanes&nbsp;=&nbsp;<span class="cpp__number">1</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;we&nbsp;only&nbsp;have&nbsp;one&nbsp;bitplane</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biBitCount&nbsp;=&nbsp;<span class="cpp__number">24</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;RGB&nbsp;mode&nbsp;is&nbsp;24&nbsp;bits</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biCompression&nbsp;=&nbsp;BI_RGB;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biSizeImage&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;can&nbsp;be&nbsp;0&nbsp;for&nbsp;24&nbsp;bit&nbsp;images</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biXPelsPerMeter&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;paint&nbsp;and&nbsp;PSP&nbsp;use&nbsp;this&nbsp;values</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biYPelsPerMeter&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biClrUsed&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;we&nbsp;are&nbsp;in&nbsp;RGB&nbsp;mode&nbsp;and&nbsp;have&nbsp;no&nbsp;palette</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmpinfo.biClrImportant&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;all&nbsp;colors&nbsp;are&nbsp;important</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HANDLE</span>&nbsp;File_Handle;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;file&nbsp;handle&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bitmapinfo.bmiHeader=bmpinfo;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;File_Handle=CreateFile(g_SrcFileName,GENERIC_READ,<span class="cpp__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(LPSECURITY_ATTRIBUTES)&nbsp;NULL,OPEN_EXISTING,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FILE_ATTRIBUTE_NORMAL,(<span class="cpp__datatype">HANDLE</span>)&nbsp;NULL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*MessageBox(hDlg,L&quot;File&nbsp;Opened&nbsp;Successfully&quot;,L&quot;Item&nbsp;Selected&quot;,0);*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;FileSize=GetFileSize(File_Handle,NULL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_Frames=((<span class="cpp__datatype">UINT</span>)FileSize/(g_Width*g_Height&#43;((g_Width*g_Height)/<span class="cpp__number">2</span>)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemInt(hDlg,IDC_FRAMES,g_Frames,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(g_Frames&gt;<span class="cpp__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EnableButtons(hDlg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_Size=g_Width*g_Height*g_Frames;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;ISize;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ISize=g_Frames*((g_Width*g_Height)&#43;((g_Width*g_Height)/<span class="cpp__number">2</span>));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BYTE</span>*&nbsp;YUV420_Buffer=&nbsp;(<span class="cpp__datatype">BYTE</span>*)GlobalAlloc(GPTR,ISize);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;YUV420_Buffer==NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hDlg,L<span class="cpp__string">&quot;Cannot&nbsp;Create&nbsp;YUV420_Buffer&nbsp;Buffer&nbsp;to&nbsp;Hold&nbsp;Data&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;ReadFile&nbsp;(&nbsp;File_Handle,&nbsp;YUV420_Buffer,&nbsp;ISize,&nbsp;&amp;g_BytesRead,&nbsp;NULL&nbsp;)&nbsp;==&nbsp;<span class="cpp__keyword">false</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hDlg,L<span class="cpp__string">&quot;File&nbsp;Cannot&nbsp;be&nbsp;Opened&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;File_Handle&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;File_Handle&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BYTE</span>*&nbsp;YUV444_Buffer=YUV420toYUV444(YUV420_Buffer,g_Width,g_Height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GlobalFree(YUV420_Buffer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;YUV444_Buffer==NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hDlg,L<span class="cpp__string">&quot;Cannot&nbsp;Create&nbsp;YUV444_Buffer&nbsp;Buffer&nbsp;to&nbsp;Hold&nbsp;Data&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_pTRGB_Buffer=YUV444toRGB888(YUV444_Buffer,g_pTRGB_Buffer,g_Width,g_Height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GlobalFree(YUV444_Buffer);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;g_pTRGB_Buffer==NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hDlg,L<span class="cpp__string">&quot;Cannot&nbsp;Create&nbsp;g_pTRGB_Buffer&nbsp;Buffer&nbsp;to&nbsp;Hold&nbsp;Data&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g_flag=<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnPaint(hDlg);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">default</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hDlg,L<span class="cpp__string">&quot;Please&nbsp;Select&nbsp;any&nbsp;YUV&nbsp;Type&quot;</span>,L<span class="cpp__string">&quot;Item&nbsp;Not-Selected&quot;</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDC_BROWSE:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OPENFILENAME&nbsp;ofn;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;common&nbsp;dialog&nbsp;box&nbsp;structure&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ZeroMemory(&amp;ofn,&nbsp;<span class="cpp__keyword">sizeof</span>(ofn));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.lStructSize&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(ofn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.hwndOwner&nbsp;=&nbsp;hDlg;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.lpstrFile&nbsp;=&nbsp;g_SrcFileName;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.lpstrFile[<span class="cpp__number">0</span>]&nbsp;=&nbsp;<span class="cpp__string">'\0'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.nMaxFile&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(g_SrcFileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.lpstrFilter&nbsp;=&nbsp;L<span class="cpp__string">&quot;YUV&nbsp;File\0*.YUV\0All&nbsp;Files\0*.*\0&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.nFilterIndex&nbsp;=&nbsp;<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.lpstrFileTitle&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.nMaxFileTitle&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.lpstrInitialDir&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofn.Flags&nbsp;=&nbsp;OFN_PATHMUSTEXIST&nbsp;|&nbsp;OFN_FILEMUSTEXIST;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(GetOpenFileName(&amp;ofn)==TRUE)&nbsp;<span class="cpp__com">//&nbsp;Display&nbsp;the&nbsp;Open&nbsp;dialog&nbsp;box.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__mlcom">/*For&nbsp;any&nbsp;Operation&nbsp;on&nbsp;File&nbsp;Handle&nbsp;Use&nbsp;here.*/</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wcscpy(g_SrcFileName,ofn.lpstrFile);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemText(hDlg,IDC_EDIT1,ofn.lpstrFile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(g_flag==<span class="cpp__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemText(hDlg,IDC_WIDTH,L<span class="cpp__string">&quot;0&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetDlgItemText(hDlg,IDC_HEIGHT,L<span class="cpp__string">&quot;0&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InvalidateRect(hDlg,<span class="cpp__number">0</span>,<span class="cpp__number">1</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDCANCEL:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">case</span>&nbsp;IDC_EXIT:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;KillTimer(hDlg,IDT_300MILLISECONDS);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EndDialog(hDlg,&nbsp;LOWORD(wParam));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GlobalFree(g_pTRGB_Buffer);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(<span class="cpp__datatype">INT_PTR</span>)TRUE;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;(<span class="cpp__datatype">INT_PTR</span>)FALSE;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">BYTE</span>*&nbsp;ConvertRGBToBMPBuffer&nbsp;(&nbsp;<span class="cpp__datatype">BYTE</span>*&nbsp;g_pRGB_Buffer,&nbsp;<span class="cpp__datatype">int</span>&nbsp;width,&nbsp;<span class="cpp__datatype">int</span>&nbsp;height)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">long</span>&nbsp;newsize;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;first&nbsp;make&nbsp;sure&nbsp;the&nbsp;parameters&nbsp;are&nbsp;valid</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;(&nbsp;NULL&nbsp;==&nbsp;g_pRGB_Buffer&nbsp;)&nbsp;||&nbsp;(&nbsp;width&nbsp;==&nbsp;<span class="cpp__number">0</span>&nbsp;)&nbsp;||&nbsp;(&nbsp;height&nbsp;==&nbsp;<span class="cpp__number">0</span>&nbsp;)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;now&nbsp;we&nbsp;have&nbsp;to&nbsp;find&nbsp;with&nbsp;how&nbsp;many&nbsp;bytes</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;we&nbsp;have&nbsp;to&nbsp;pad&nbsp;for&nbsp;the&nbsp;next&nbsp;DWORD&nbsp;boundary</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;padding&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;scanlinebytes&nbsp;=&nbsp;width&nbsp;*&nbsp;<span class="cpp__number">3</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">while</span>&nbsp;(&nbsp;(&nbsp;scanlinebytes&nbsp;&#43;&nbsp;padding&nbsp;)&nbsp;%&nbsp;<span class="cpp__number">4</span>&nbsp;!=&nbsp;<span class="cpp__number">0</span>&nbsp;)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;DWORD&nbsp;=&nbsp;4&nbsp;bytes</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;padding&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;get&nbsp;the&nbsp;padded&nbsp;scanline&nbsp;width</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;psw&nbsp;=&nbsp;scanlinebytes&nbsp;&#43;&nbsp;padding;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;we&nbsp;can&nbsp;already&nbsp;store&nbsp;the&nbsp;size&nbsp;of&nbsp;the&nbsp;new&nbsp;padded&nbsp;buffer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;newsize&nbsp;=&nbsp;height&nbsp;*&nbsp;psw;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;and&nbsp;create&nbsp;new&nbsp;buffer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BYTE</span>*&nbsp;newbuf&nbsp;=&nbsp;<span class="cpp__keyword">new</span>&nbsp;<span class="cpp__datatype">BYTE</span>[newsize];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;fill&nbsp;the&nbsp;buffer&nbsp;with&nbsp;zero&nbsp;bytes&nbsp;then&nbsp;we&nbsp;dont&nbsp;have&nbsp;to&nbsp;add</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;extra&nbsp;padding&nbsp;zero&nbsp;bytes&nbsp;later&nbsp;on</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;memset&nbsp;(&nbsp;newbuf,&nbsp;<span class="cpp__number">0</span>,&nbsp;newsize&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;now&nbsp;we&nbsp;loop&nbsp;trough&nbsp;all&nbsp;bytes&nbsp;of&nbsp;the&nbsp;original&nbsp;buffer,</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;swap&nbsp;the&nbsp;R&nbsp;and&nbsp;B&nbsp;bytes&nbsp;and&nbsp;the&nbsp;scanlines</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">long</span>&nbsp;bufpos&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">long</span>&nbsp;newpos&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(&nbsp;<span class="cpp__datatype">int</span>&nbsp;y&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;y&nbsp;&lt;&nbsp;height;&nbsp;y&#43;&#43;&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(&nbsp;<span class="cpp__datatype">int</span>&nbsp;x&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;x&nbsp;&lt;&nbsp;<span class="cpp__number">3</span>&nbsp;*&nbsp;width;&nbsp;x&#43;=<span class="cpp__number">3</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bufpos&nbsp;=&nbsp;y&nbsp;*&nbsp;<span class="cpp__number">3</span>&nbsp;*&nbsp;width&nbsp;&#43;&nbsp;x;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;position&nbsp;in&nbsp;original&nbsp;buffer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newpos&nbsp;=&nbsp;(&nbsp;height&nbsp;-&nbsp;y&nbsp;-&nbsp;<span class="cpp__number">1</span>&nbsp;)&nbsp;*&nbsp;psw&nbsp;&#43;&nbsp;x;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;position&nbsp;in&nbsp;padded&nbsp;buffer</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newbuf[newpos&#43;&nbsp;<span class="cpp__number">2</span>]&nbsp;=&nbsp;g_pRGB_Buffer[bufpos<span class="cpp__number">&#43;2</span>];&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;swap&nbsp;r&nbsp;and&nbsp;b</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newbuf[newpos&nbsp;&#43;&nbsp;<span class="cpp__number">1</span>]&nbsp;=&nbsp;g_pRGB_Buffer[bufpos&nbsp;&#43;&nbsp;<span class="cpp__number">1</span>];&nbsp;<span class="cpp__com">//&nbsp;g&nbsp;stays</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newbuf[newpos&nbsp;]&nbsp;=&nbsp;g_pRGB_Buffer[bufpos];&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;swap&nbsp;b&nbsp;and&nbsp;r</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;newbuf;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">BYTE</span>*&nbsp;YUV444toRGB888(<span class="cpp__datatype">BYTE</span>&nbsp;*YUV444_Buffer,<span class="cpp__datatype">BYTE</span>&nbsp;*g_pTRGB_Buffer,<span class="cpp__datatype">UINT</span>&nbsp;g_Width,<span class="cpp__datatype">UINT</span>&nbsp;g_Height)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;(&nbsp;NULL&nbsp;==&nbsp;YUV444_Buffer&nbsp;)&nbsp;||&nbsp;(&nbsp;g_Width&nbsp;==&nbsp;<span class="cpp__number">0</span>&nbsp;)&nbsp;||&nbsp;(&nbsp;g_Height&nbsp;==&nbsp;<span class="cpp__number">0</span>&nbsp;)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;g_Size=g_Width*g_Height*g_Frames*<span class="cpp__number">3</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;g_pTRGB_Buffer=&nbsp;(<span class="cpp__datatype">BYTE</span>*)GlobalAlloc(<span class="cpp__number">0</span>,g_Size);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;Row=<span class="cpp__number">0</span>,Col=<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(Row&nbsp;=<span class="cpp__number">0</span>&nbsp;;&nbsp;Row&nbsp;&lt;&nbsp;g_Height*g_Frames;&nbsp;Row&nbsp;&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(Col&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;Col&nbsp;&lt;&nbsp;g_Width;&nbsp;Col&nbsp;&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TB(Col,Row)&nbsp;=&nbsp;Clamp((&nbsp;<span class="cpp__number">298</span>&nbsp;*&nbsp;(Y(Col,Row)-<span class="cpp__number">16</span>)&nbsp;&#43;&nbsp;<span class="cpp__number">516</span>&nbsp;*&nbsp;(U(Col,Row)-<span class="cpp__number">128</span>)&nbsp;&#43;&nbsp;<span class="cpp__number">128</span>)&nbsp;&gt;&gt;&nbsp;<span class="cpp__number">8</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TG(Col,Row)&nbsp;=&nbsp;Clamp((&nbsp;<span class="cpp__number">298</span>&nbsp;*&nbsp;(Y(Col,Row)-<span class="cpp__number">16</span>)&nbsp;-&nbsp;<span class="cpp__number">100</span>&nbsp;*&nbsp;(U(Col,Row)-<span class="cpp__number">128</span>)&nbsp;-&nbsp;<span class="cpp__number">208</span>&nbsp;*&nbsp;(V(Col,Row)-<span class="cpp__number">128</span>)&nbsp;&#43;&nbsp;<span class="cpp__number">128</span>)&nbsp;&gt;&gt;&nbsp;<span class="cpp__number">8</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TR(Col,Row)&nbsp;=&nbsp;Clamp((&nbsp;<span class="cpp__number">298</span>&nbsp;*&nbsp;(Y(Col,Row)-<span class="cpp__number">16</span>)&nbsp;&#43;&nbsp;<span class="cpp__number">409</span>&nbsp;*&nbsp;(V(Col,Row)-<span class="cpp__number">128</span>)&nbsp;&#43;&nbsp;<span class="cpp__number">128</span>)&nbsp;&gt;&gt;&nbsp;<span class="cpp__number">8</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;g_pTRGB_Buffer;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">BYTE</span>*&nbsp;YUV420toYUV444(<span class="cpp__datatype">BYTE</span>&nbsp;*YUV420_Buffer,<span class="cpp__datatype">UINT</span>&nbsp;g_Width,<span class="cpp__datatype">UINT</span>&nbsp;g_Height)&nbsp;
{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;(&nbsp;NULL&nbsp;==&nbsp;YUV420_Buffer&nbsp;)&nbsp;||&nbsp;(&nbsp;g_Width&nbsp;==&nbsp;<span class="cpp__number">0</span>&nbsp;)&nbsp;||&nbsp;(&nbsp;g_Height&nbsp;==&nbsp;<span class="cpp__number">0</span>&nbsp;)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(<span class="cpp__number">0</span>,L<span class="cpp__string">&quot;YUV420_Buffer&nbsp;or&nbsp;Width&nbsp;or&nbsp;Height&nbsp;Value&nbsp;Not&nbsp;Received&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;g_Size=g_Width*g_Height*g_Frames;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;FrameSize=g_Width*g_Height;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BYTE</span>&nbsp;*YUV444_Buffer=&nbsp;<span class="cpp__keyword">new</span>&nbsp;<span class="cpp__datatype">BYTE</span>[g_Size*<span class="cpp__number">3</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;NULL&nbsp;==&nbsp;YUV444_Buffer)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(<span class="cpp__number">0</span>,L<span class="cpp__string">&quot;YUV444_Buffer&nbsp;&nbsp;Not&nbsp;Created&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ZeroMemory(YUV444_Buffer,<span class="cpp__keyword">sizeof</span>(YUV444_Buffer));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;i=<span class="cpp__number">0</span>,SYpos=<span class="cpp__number">0</span>,SUpos=<span class="cpp__number">0</span>,SVpos=<span class="cpp__number">0</span>,Row,&nbsp;Col;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;g_Frames;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SYpos=i*(FrameSize&#43;FrameSize/<span class="cpp__number">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(Row&nbsp;=&nbsp;i*g_Height;&nbsp;Row&nbsp;&lt;g_Height*(i<span class="cpp__number">&#43;1</span>);Row&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(Col&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;Col&nbsp;&lt;&nbsp;g_Width;&nbsp;Col&nbsp;&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Y(Col,Row)=YUV420_Buffer[SYpos];&nbsp;&nbsp;&nbsp;&nbsp;SYpos&#43;&#43;;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SUpos=FrameSize;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SVpos=FrameSize&#43;(FrameSize/<span class="cpp__number">4</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;g_Frames;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(Row&nbsp;=&nbsp;i*g_Height;&nbsp;Row&nbsp;&lt;g_Height*(i<span class="cpp__number">&#43;1</span>);&nbsp;Row&nbsp;&#43;=<span class="cpp__number">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(Col&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;Col&nbsp;&lt;&nbsp;g_Width;&nbsp;Col&nbsp;&#43;=<span class="cpp__number">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;V(Col,Row)=YUV420_Buffer[SUpos];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;V(Col<span class="cpp__number">&#43;1</span>,Row)=YUV420_Buffer[SUpos];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;V(Col,Row<span class="cpp__number">&#43;1</span>)=YUV420_Buffer[SUpos];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;V(Col<span class="cpp__number">&#43;1</span>,Row<span class="cpp__number">&#43;1</span>)=YUV420_Buffer[SUpos];SUpos&#43;&#43;;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;U(Col,Row)=YUV420_Buffer[SVpos];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;U(Col<span class="cpp__number">&#43;1</span>,Row)=YUV420_Buffer[SVpos];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;U(Col,Row<span class="cpp__number">&#43;1</span>)=YUV420_Buffer[SVpos];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;U(Col<span class="cpp__number">&#43;1</span>,Row<span class="cpp__number">&#43;1</span>)=YUV420_Buffer[SVpos];SVpos&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SUpos&#43;=((FrameSize&#43;FrameSize/<span class="cpp__number">4</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SVpos&#43;=((FrameSize&#43;FrameSize/<span class="cpp__number">4</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;YUV444_Buffer;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">BYTE</span>*&nbsp;YUV422toYUV444(<span class="cpp__datatype">BYTE</span>&nbsp;*YUV422_Buffer,<span class="cpp__datatype">UINT</span>&nbsp;g_Width,<span class="cpp__datatype">UINT</span>&nbsp;g_Height)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;(&nbsp;NULL&nbsp;==&nbsp;YUV422_Buffer&nbsp;)&nbsp;||&nbsp;(&nbsp;g_Width&nbsp;==&nbsp;<span class="cpp__number">0</span>&nbsp;)&nbsp;||&nbsp;(&nbsp;g_Height&nbsp;==&nbsp;<span class="cpp__number">0</span>&nbsp;)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(<span class="cpp__number">0</span>,L<span class="cpp__string">&quot;YUV422_Buffer&nbsp;or&nbsp;g_Width&nbsp;or&nbsp;g_Height&nbsp;Value&nbsp;Not&nbsp;Received&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;g_Size=g_Width*g_Height*g_Frames;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BYTE</span>&nbsp;*YUV444_Buffer=&nbsp;<span class="cpp__keyword">new</span>&nbsp;<span class="cpp__datatype">BYTE</span>[g_Size*<span class="cpp__number">3</span>];&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;(&nbsp;NULL&nbsp;==&nbsp;YUV444_Buffer&nbsp;)&nbsp;||&nbsp;(&nbsp;g_Width&nbsp;==&nbsp;<span class="cpp__number">0</span>&nbsp;)&nbsp;||&nbsp;(&nbsp;g_Height&nbsp;==&nbsp;<span class="cpp__number">0</span>&nbsp;)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(<span class="cpp__number">0</span>,L<span class="cpp__string">&quot;YUV444_Buffer&nbsp;or&nbsp;g_Width&nbsp;or&nbsp;g_Height&nbsp;Value&nbsp;Not&nbsp;Received&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ZeroMemory(YUV444_Buffer,<span class="cpp__keyword">sizeof</span>(YUV444_Buffer));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;i=<span class="cpp__number">0</span>,SYpos=<span class="cpp__number">1</span>,SUpos=<span class="cpp__number">0</span>,SVpos=<span class="cpp__number">2</span>,Row,&nbsp;Col;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;FrameSize=g_Width*g_Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;i&nbsp;&lt;g_Frames;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(Row&nbsp;=&nbsp;i*g_Height;&nbsp;Row&nbsp;&lt;g_Height*(i<span class="cpp__number">&#43;1</span>);Row&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(Col&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;Col&nbsp;&lt;&nbsp;g_Width;&nbsp;Col&nbsp;&#43;=<span class="cpp__number">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Y(Col,Row)=YUV422_Buffer[SYpos];&nbsp;&nbsp;&nbsp;&nbsp;SYpos&#43;=<span class="cpp__number">2</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;U(Col,Row)=YUV422_Buffer[SUpos];&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;V(Col,Row)=YUV422_Buffer[SVpos];&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Y(Col<span class="cpp__number">&#43;1</span>,Row)=YUV422_Buffer[SYpos];&nbsp;&nbsp;&nbsp;&nbsp;SYpos&#43;=<span class="cpp__number">2</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;U(Col<span class="cpp__number">&#43;1</span>,Row)=YUV422_Buffer[SUpos];&nbsp;&nbsp;&nbsp;&nbsp;SUpos&#43;=<span class="cpp__number">4</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;V(Col<span class="cpp__number">&#43;1</span>,Row)=YUV422_Buffer[SVpos];&nbsp;&nbsp;&nbsp;&nbsp;SVpos&#43;=<span class="cpp__number">4</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;YUV444_Buffer;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">BYTE</span>*&nbsp;ConvertBMPToRGBBuffer&nbsp;(&nbsp;<span class="cpp__datatype">BYTE</span>*&nbsp;Buffer,&nbsp;<span class="cpp__datatype">int</span>&nbsp;width,&nbsp;<span class="cpp__datatype">int</span>&nbsp;height&nbsp;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;first&nbsp;make&nbsp;sure&nbsp;the&nbsp;parameters&nbsp;are&nbsp;valid</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;(&nbsp;NULL&nbsp;==&nbsp;Buffer&nbsp;)&nbsp;||&nbsp;(&nbsp;width&nbsp;==&nbsp;<span class="cpp__number">0</span>&nbsp;)&nbsp;||&nbsp;(&nbsp;height&nbsp;==&nbsp;<span class="cpp__number">0</span>&nbsp;)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;find&nbsp;the&nbsp;number&nbsp;of&nbsp;padding&nbsp;bytes</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;padding&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;scanlinebytes&nbsp;=&nbsp;width&nbsp;*&nbsp;<span class="cpp__number">3</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">while</span>&nbsp;(&nbsp;(&nbsp;scanlinebytes&nbsp;&#43;&nbsp;padding&nbsp;)&nbsp;%&nbsp;<span class="cpp__number">4</span>&nbsp;!=&nbsp;<span class="cpp__number">0</span>&nbsp;)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;DWORD&nbsp;=&nbsp;4&nbsp;bytes</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;padding&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;get&nbsp;the&nbsp;padded&nbsp;scanline&nbsp;width</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;psw&nbsp;=&nbsp;scanlinebytes&nbsp;&#43;&nbsp;padding;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;create&nbsp;new&nbsp;buffer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BYTE</span>*&nbsp;newbuf&nbsp;=&nbsp;<span class="cpp__keyword">new</span>&nbsp;<span class="cpp__datatype">BYTE</span>[width*height*<span class="cpp__number">3</span>];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;now&nbsp;we&nbsp;loop&nbsp;trough&nbsp;all&nbsp;bytes&nbsp;of&nbsp;the&nbsp;original&nbsp;buffer,</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;swap&nbsp;the&nbsp;R&nbsp;and&nbsp;B&nbsp;bytes&nbsp;and&nbsp;the&nbsp;scanlines</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">long</span>&nbsp;bufpos&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">long</span>&nbsp;newpos&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(&nbsp;<span class="cpp__datatype">int</span>&nbsp;y&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;y&nbsp;&lt;&nbsp;height;&nbsp;y&#43;&#43;&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(&nbsp;<span class="cpp__datatype">int</span>&nbsp;x&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;x&nbsp;&lt;&nbsp;<span class="cpp__number">3</span>&nbsp;*&nbsp;width;&nbsp;x&#43;=<span class="cpp__number">3</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newpos&nbsp;=&nbsp;y&nbsp;*&nbsp;<span class="cpp__number">3</span>&nbsp;*&nbsp;width&nbsp;&#43;&nbsp;x;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bufpos&nbsp;=&nbsp;(&nbsp;height&nbsp;-&nbsp;y&nbsp;-&nbsp;<span class="cpp__number">1</span>&nbsp;)&nbsp;*&nbsp;psw&nbsp;&#43;&nbsp;x;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newbuf[newpos]&nbsp;=&nbsp;Buffer[bufpos&nbsp;&#43;&nbsp;<span class="cpp__number">2</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newbuf[newpos&nbsp;&#43;&nbsp;<span class="cpp__number">1</span>]&nbsp;=&nbsp;Buffer[bufpos<span class="cpp__number">&#43;1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newbuf[newpos&nbsp;&#43;&nbsp;<span class="cpp__number">2</span>]&nbsp;=&nbsp;Buffer[bufpos];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;newbuf;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">bool</span>&nbsp;SaveBMP&nbsp;(&nbsp;<span class="cpp__datatype">BYTE</span>*&nbsp;Buffer,&nbsp;<span class="cpp__datatype">int</span>&nbsp;width,&nbsp;<span class="cpp__datatype">int</span>&nbsp;height,&nbsp;<span class="cpp__datatype">long</span>&nbsp;paddedsize,&nbsp;<span class="cpp__datatype">LPCTSTR</span>&nbsp;bmpfile&nbsp;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;declare&nbsp;bmp&nbsp;structures</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BITMAPFILEHEADER&nbsp;bmfh;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BITMAPINFOHEADER&nbsp;info;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;andinitialize&nbsp;them&nbsp;to&nbsp;zero</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;memset&nbsp;(&nbsp;&amp;bmfh,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__keyword">sizeof</span>&nbsp;(BITMAPFILEHEADER&nbsp;)&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;memset&nbsp;(&nbsp;&amp;info,&nbsp;<span class="cpp__number">0</span>,&nbsp;<span class="cpp__keyword">sizeof</span>&nbsp;(BITMAPINFOHEADER&nbsp;)&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;fill&nbsp;the&nbsp;fileheader&nbsp;with&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bmfh.bfType&nbsp;=&nbsp;0x4d42;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;0x4d42&nbsp;=&nbsp;'BM'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bmfh.bfReserved1&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bmfh.bfReserved2&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bmfh.bfSize&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(BITMAPFILEHEADER)&nbsp;&#43;&nbsp;<span class="cpp__keyword">sizeof</span>(BITMAPINFOHEADER)&nbsp;&#43;&nbsp;paddedsize;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bmfh.bfOffBits&nbsp;=&nbsp;0x36;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;number&nbsp;of&nbsp;bytes&nbsp;to&nbsp;start&nbsp;of&nbsp;bitmap&nbsp;bits</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;fill&nbsp;the&nbsp;infoheader</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;info.biSize&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(BITMAPINFOHEADER);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;info.biWidth&nbsp;=&nbsp;width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;info.biHeight&nbsp;=&nbsp;-height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;info.biPlanes&nbsp;=&nbsp;<span class="cpp__number">1</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;we&nbsp;only&nbsp;have&nbsp;one&nbsp;bitplane</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;info.biBitCount&nbsp;=&nbsp;<span class="cpp__number">24</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;RGB&nbsp;mode&nbsp;is&nbsp;24&nbsp;bits</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;info.biCompression&nbsp;=&nbsp;BI_RGB;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;info.biSizeImage&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;can&nbsp;be&nbsp;0&nbsp;for&nbsp;24&nbsp;bit&nbsp;images</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;info.biXPelsPerMeter&nbsp;=&nbsp;0x0ec4;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;paint&nbsp;and&nbsp;PSP&nbsp;use&nbsp;this&nbsp;values</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;info.biYPelsPerMeter&nbsp;=&nbsp;0x0ec4;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;info.biClrUsed&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;we&nbsp;are&nbsp;in&nbsp;RGB&nbsp;mode&nbsp;and&nbsp;have&nbsp;no&nbsp;palette</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;info.biClrImportant&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;all&nbsp;colors&nbsp;are&nbsp;important</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;now&nbsp;we&nbsp;open&nbsp;the&nbsp;file&nbsp;to&nbsp;write&nbsp;to</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HANDLE</span>&nbsp;file&nbsp;=&nbsp;CreateFile&nbsp;(&nbsp;bmpfile&nbsp;,&nbsp;GENERIC_WRITE,&nbsp;FILE_SHARE_READ,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NULL,&nbsp;CREATE_ALWAYS,&nbsp;FILE_ATTRIBUTE_NORMAL,&nbsp;NULL&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;file&nbsp;==&nbsp;NULL&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;file&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;write&nbsp;file&nbsp;header</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;unsigned&nbsp;<span class="cpp__datatype">long</span>&nbsp;bwritten;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;WriteFile&nbsp;(&nbsp;file,&nbsp;&amp;bmfh,&nbsp;<span class="cpp__keyword">sizeof</span>&nbsp;(&nbsp;BITMAPFILEHEADER&nbsp;),&nbsp;&amp;bwritten,&nbsp;NULL&nbsp;)&nbsp;==&nbsp;<span class="cpp__keyword">false</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;file&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;write&nbsp;infoheader</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;WriteFile&nbsp;(&nbsp;file,&nbsp;&amp;info,&nbsp;<span class="cpp__keyword">sizeof</span>&nbsp;(&nbsp;BITMAPINFOHEADER&nbsp;),&nbsp;&amp;bwritten,&nbsp;NULL&nbsp;)&nbsp;==&nbsp;<span class="cpp__keyword">false</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;file&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;write&nbsp;image&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;WriteFile&nbsp;(&nbsp;file,&nbsp;Buffer,&nbsp;paddedsize,&nbsp;&amp;bwritten,&nbsp;NULL&nbsp;)&nbsp;==&nbsp;<span class="cpp__keyword">false</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;file&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;and&nbsp;close&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;file&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__keyword">true</span>;&nbsp;
}&nbsp;
&nbsp;
<span class="cpp__datatype">BYTE</span>*&nbsp;LoadBMP&nbsp;(&nbsp;<span class="cpp__datatype">int</span>*&nbsp;width,&nbsp;<span class="cpp__datatype">int</span>*&nbsp;height,&nbsp;<span class="cpp__datatype">long</span>*&nbsp;size,&nbsp;<span class="cpp__datatype">LPCTSTR</span>&nbsp;bmpfile&nbsp;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;declare&nbsp;bitmap&nbsp;structures</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BITMAPFILEHEADER&nbsp;bmpheader;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BITMAPINFOHEADER&nbsp;bmpinfo;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;value&nbsp;to&nbsp;be&nbsp;used&nbsp;in&nbsp;ReadFile&nbsp;funcs</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;bytesread;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;open&nbsp;file&nbsp;to&nbsp;read&nbsp;from</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HANDLE</span>&nbsp;file&nbsp;=&nbsp;CreateFile&nbsp;(&nbsp;bmpfile&nbsp;,&nbsp;GENERIC_READ,&nbsp;FILE_SHARE_READ,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NULL,&nbsp;OPEN_EXISTING,&nbsp;FILE_FLAG_SEQUENTIAL_SCAN,&nbsp;NULL&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;NULL&nbsp;==&nbsp;file&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;<span class="cpp__com">//&nbsp;coudn't&nbsp;open&nbsp;file</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;read&nbsp;file&nbsp;header</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;ReadFile&nbsp;(&nbsp;file,&nbsp;&amp;bmpheader,&nbsp;<span class="cpp__keyword">sizeof</span>&nbsp;(&nbsp;BITMAPFILEHEADER&nbsp;),&nbsp;&amp;bytesread,&nbsp;NULL&nbsp;)&nbsp;==&nbsp;<span class="cpp__keyword">false</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;file&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//read&nbsp;bitmap&nbsp;info</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;ReadFile&nbsp;(&nbsp;file,&nbsp;&amp;bmpinfo,&nbsp;<span class="cpp__keyword">sizeof</span>&nbsp;(&nbsp;BITMAPINFOHEADER&nbsp;),&nbsp;&amp;bytesread,&nbsp;NULL&nbsp;)&nbsp;==&nbsp;<span class="cpp__keyword">false</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;file&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;check&nbsp;if&nbsp;file&nbsp;is&nbsp;actually&nbsp;a&nbsp;bmp</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;bmpheader.bfType&nbsp;!=&nbsp;<span class="cpp__string">'MB'</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;file&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;get&nbsp;image&nbsp;measurements</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;*width&nbsp;&nbsp;&nbsp;=&nbsp;bmpinfo.biWidth;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;*height&nbsp;&nbsp;=&nbsp;abs&nbsp;(&nbsp;bmpinfo.biHeight&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;check&nbsp;if&nbsp;bmp&nbsp;is&nbsp;uncompressed</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;bmpinfo.biCompression&nbsp;!=&nbsp;BI_RGB&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;file&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;check&nbsp;if&nbsp;we&nbsp;have&nbsp;24&nbsp;bit&nbsp;bmp</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;bmpinfo.biBitCount&nbsp;!=&nbsp;<span class="cpp__number">24</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;file&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;create&nbsp;buffer&nbsp;to&nbsp;hold&nbsp;the&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;*size&nbsp;=&nbsp;bmpheader.bfSize&nbsp;-&nbsp;bmpheader.bfOffBits;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">BYTE</span>*&nbsp;Buffer&nbsp;=&nbsp;<span class="cpp__keyword">new</span>&nbsp;<span class="cpp__datatype">BYTE</span>[&nbsp;*size&nbsp;];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;move&nbsp;file&nbsp;pointer&nbsp;to&nbsp;start&nbsp;of&nbsp;bitmap&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SetFilePointer&nbsp;(&nbsp;file,&nbsp;bmpheader.bfOffBits,&nbsp;NULL,&nbsp;FILE_BEGIN&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;read&nbsp;bmp&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;ReadFile&nbsp;(&nbsp;file,&nbsp;Buffer,&nbsp;*size,&nbsp;&amp;bytesread,&nbsp;NULL&nbsp;)&nbsp;==&nbsp;<span class="cpp__keyword">false</span>&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">delete</span>&nbsp;[]&nbsp;Buffer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;file&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;everything&nbsp;successful&nbsp;here:&nbsp;close&nbsp;file&nbsp;and&nbsp;return&nbsp;buffer</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CloseHandle&nbsp;(&nbsp;file&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;Buffer;&nbsp;
}&nbsp;
<span class="cpp__keyword">void</span>&nbsp;OnPaint(<span class="cpp__datatype">HWND</span>&nbsp;hDlg)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(g_flag==<span class="cpp__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(g_pTRGB_Buffer==NULL)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox(hDlg,L<span class="cpp__string">&quot;RGB_Buffer&nbsp;Value&nbsp;Not&nbsp;Received&quot;</span>,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;Dx=<span class="cpp__number">10</span>,Dy=<span class="cpp__number">65</span>,DWidth=<span class="cpp__number">800</span>,DHeight=<span class="cpp__number">600</span>,Framecnt=<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">UINT</span>&nbsp;offset=((g_CurrentFrame<span class="cpp__number">-1</span>)*g_Width*g_Height*<span class="cpp__number">3</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HDC</span>&nbsp;Bhdc=GetWindowDC(hDlg);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>(g_Width&gt;=DWidth)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetStretchBltMode(Bhdc,HALFTONE&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StretchDIBits(Bhdc,<span class="cpp__number">10</span>,<span class="cpp__number">65</span>&#43;DHeight,DWidth,-DHeight,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,g_Width,g_Height,g_pTRGB_Buffer&#43;offset,&amp;Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>((g_Width&gt;=<span class="cpp__number">800</span>)&amp;&amp;(g_Width&lt;=DWidth))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StretchDIBits(Bhdc,<span class="cpp__number">10</span>,<span class="cpp__number">65</span>&#43;DHeight,DWidth,-DHeight,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,g_Width,g_Height,g_pTRGB_Buffer&#43;offset,&amp;Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>((g_Width&gt;=<span class="cpp__number">736</span>)&amp;&amp;(g_Width&lt;<span class="cpp__number">800</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetStretchBltMode(Bhdc,HALFTONE&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StretchDIBits(Bhdc,<span class="cpp__number">10</span>,<span class="cpp__number">65</span>&#43;DHeight,DWidth,-DHeight,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,g_Width,g_Height,g_pTRGB_Buffer&#43;offset,&amp;Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>((g_Width&gt;=<span class="cpp__number">640</span>)&amp;&amp;(g_Width&lt;<span class="cpp__number">736</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StretchDIBits(Bhdc,<span class="cpp__number">110</span>,g_Height<span class="cpp__number">&#43;110</span>,g_Width,-g_Height,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,g_Width,g_Height,g_pTRGB_Buffer&#43;offset,&amp;Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>((g_Width&gt;=<span class="cpp__number">320</span>)&amp;&amp;(g_Width&lt;<span class="cpp__number">640</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StretchDIBits(Bhdc,<span class="cpp__number">250</span>,g_Height<span class="cpp__number">&#43;250</span>,g_Width,-g_Height,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,g_Width,g_Height,g_pTRGB_Buffer&#43;offset,&amp;Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">else</span>&nbsp;<span class="cpp__keyword">if</span>((g_Width&gt;=<span class="cpp__number">176</span>)&amp;&amp;(g_Width&lt;<span class="cpp__number">320</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StretchDIBits(Bhdc,<span class="cpp__number">350</span>,g_Height<span class="cpp__number">&#43;300</span>,g_Width,-g_Height,<span class="cpp__number">0</span>,<span class="cpp__number">0</span>,g_Width,g_Height,g_pTRGB_Buffer&#43;offset,&amp;Bitmapinfo,DIB_RGB_COLORS,SRCCOPY);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DeleteDC(Bhdc);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}ur&nbsp;code&nbsp;snippet.</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
