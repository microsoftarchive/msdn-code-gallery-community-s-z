# WICExplorer (Windows Imaging Component Explorer)
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- Windows Imaging Component (WIC)
## Topics
- Imaging
- metadata
## Updated
- 12/10/2015
## Description

<h1>Introduction</h1>
<p>WIC Explorer is a tool that uses the Windows Imaging Component API to enumerate and list all of the elements within an image, including metadata, frames, and thumbnails. Use it to explore the contents of images, as well as understanding how the WIC API is
 interpreting a file.</p>
<p>WIC Explorer originally was released as part of the WIC Tools package for Windows Vista and Windows 7. This version has been updated with bug fixes and compatibility with Visual Studio 2013.</p>
<h1><span>IMPORTANT: Windows Template Library files are not included</span></h1>
<p>WIC Explorer requires the Windows Template Library version 9.0, which must be downloaded separately.</p>
<ol>
<li>Download the Windows Template Library version 9.0 from&nbsp;<a href="http://sourceforge.net/projects/wtl/files/WTL%209.0/WTL%209.0.4140%20Final/WTL90_4140_Final.zip/download">Sourceforge</a>.
</li><li>Unzip the package into a temporary directory. </li><li>Copy all of the files from the &quot;Include&quot; directory to the &quot;wtl90&quot; directory in this sample.
</li><li>Open the solution in Visual Studio as normal. </li></ol>
<p>For more information about WTL, see <a href="http://wtl.sourceforge.net/">its project website</a>.</p>
<h1><span style="font-size:20px; font-weight:bold">How to use</span></h1>
<h2>Loading images</h2>
<p>To load an image, go to File &gt; Open... and select the file you wish to open.</p>
<p>To load an entire directory of images, go to File &gt; Open Directory... and select the directory you wish to open.</p>
<p>WIC Explorer supports any file format that has a WIC codec installed. On Windows 10, the built-in codecs are:</p>
<ul>
<li>JPEG </li><li>BMP </li><li>PNG </li><li>GIF </li><li>ICO </li><li>JPEG-XR </li><li>TIFF </li><li>DDS </li><li>Camera Raw </li></ul>
<h2>Exploring an image's elements</h2>
<p>The left hand pane displays a hierarchical tree view of all of the WIC accessible elements in the image.</p>
<p>The lower left hand pane displays information about the WIC component (IWICComponentInfo) that was used to extract the currently highlighted node.</p>
<p>The right hand pane displays the contents of the currently highlighted node. This view changes depending on the type of node. For example, when selecting a frame (IWICBitmapFrameDecode), it displays attributes of the frame including DPI, resolution, and
 pixel format, as well as rendering the image data. When selecting a metadata reader (IWICMetadataReader), it displays all of the metadata items that are children of the node.</p>
<h2><span>Saving to another image format</span></h2>
<p>WIC Explorer can save an image to any supported WIC encoder; you can also specify the desired pixel format in which to save. Note that not all of the listed pixel formats may be supported by the encoder; it will automatically perform pixel format conversion
 when necessary. It also will not preserve any metadata in the original image.</p>
