WIC Explorer sample
===================

WIC Explorer is a tool that uses the Windows Imaging Component API to enumerate and list all of the elements within an image file, including metadata, frames, and thumbnails. It is useful for exploring the contents of images, as well as understanding how the WIC API is interpreting a specific file.

IMPORTANT: Windows Template Library files are not included
----------------------------------------------------------

WIC Explorer requires the Windows Template Library version 9.0, which must be downloaded separately.

1. Download the Windows Template Library version 9.0 from [Sourceforge](http://sourceforge.net/projects/wtl/files/WTL%209.0/WTL%209.0.4140%20Final/WTL90_4140_Final.zip/download).
2. Unzip the package into a temporary directory.
3. Copy all of the files from the "Include" directory to the "wtl90" directory in this sample.
4. Open the solution in Visual Studio as normal.

For more information about WTL, see [its project website](http://wtl.sourceforge.net/).

How to use
----------

### Loading images

To load an image, go to File > Open... and select the file you wish to open.

To load an entire directory of images, go to File > Open Directory... and select the directory you wish to open.

WIC Explorer supports any file format that has a WIC codec installed. On Windows 10, the built-in codecs are:

- JPEG
- BMP
- PNG
- GIF
- ICO
- JPEG-XR
- TIFF
- DDS
- Camera Raw

### Exploring an image's elements

The left hand pane displays a hierarchical tree view of all of the WIC accessible elements in the image.

The lower left hand pane displays information about the WIC component (IWICComponentInfo) that was used to extract the currently highlighted node.

The right hand pane displays the contents of the currently highlighted node. This view changes depending on the type of node. For example, when selecting a frame (IWICBitmapFrameDecode), it displays attributes of the frame including DPI, resolution, and pixel format, as well as rendering the image data. When selecting a metadata reader (IWICMetadataReader), it displays all of the metadata items that are children of the node.

### Saving to another image format

WIC Explorer can save an image to any supported WIC encoder; you can also specify the desired pixel format in which to save. Note that not all of the listed pixel formats may be supported by the encoder; it will automatically perform pixel format conversion when necessary. It also will not preserve any metadata in the original image.