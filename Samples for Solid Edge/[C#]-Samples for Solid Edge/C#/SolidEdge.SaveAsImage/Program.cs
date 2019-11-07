using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.SaveAsImage
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgeFramework.SolidEdgeDocument document = null;
            SolidEdgeFramework.Window window = null;
            SolidEdgeDraft.SheetWindow sheetWindow = null;

            try
            {
                Console.WriteLine("Registering OleMessageFilter.");

                // Register with OLE to handle concurrency issues on the current thread.
                OleMessageFilter.Register();

                Console.WriteLine("Connecting to Solid Edge.");

                // Connect to or start Solid Edge.
                application = SolidEdgeUtils.Connect(true);

                // Make sure user can see the GUI.
                application.Visible = true;

                // Bring Solid Edge to the foreground.
                application.Activate();

                // Get a reference to the Documents collection.
                documents = application.Documents;

                // This check is necessary because application.ActiveDocument will throw an
                // exception if no documents are open...
                if (documents.Count > 0)
                {
                    // Attempt to connect to ActiveDocument.
                    document = (SolidEdgeFramework.SolidEdgeDocument)application.ActiveDocument;
                }

                // Make sure we have a document.
                if (document == null)
                {
                    throw new System.Exception("No active document.");
                }

                // 3D windows are of type SolidEdgeFramework.Window.
                window = application.ActiveWindow as SolidEdgeFramework.Window;

                // 2D windows are of type SolidEdgeDraft.SheetWindow.
                sheetWindow = application.ActiveWindow as SolidEdgeDraft.SheetWindow;

                if (window != null)
                {
                    SaveAsImage(window);
                }
                else if (sheetWindow != null)
                {
                    SaveAsImage(sheetWindow);
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debugger.Break();
#endif
                Console.WriteLine(ex.Message);
            }
        }

        static void SaveAsImage(SolidEdgeFramework.Window window)
        {
            string[] extensions = { ".jpg", ".bmp", ".tif" };
            SolidEdgeFramework.View view = null;
            Guid guid = Guid.NewGuid();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            double resolution = 1;  // DPI - Larger values have better quality but also lead to larger file.
            int colorDepth = 24;
            int width = window.UsableWidth;
            int height = window.UsableHeight;

            // Get a reference to the 3D view.
            view = window.View;

            // Save each extension.
            foreach (string extension in extensions)
            {
                // File saved to desktop.
                string filename = Path.ChangeExtension(guid.ToString(), extension);
                filename = Path.Combine(folder, filename);

                // You can specify .bmp (Windows Bitmap), .tif (TIFF), or .jpg (JPEG).
                view.SaveAsImage(
                    Filename: filename,
                    Width: width,
                    Height: height,
                    AltViewStyle: null,
                    Resolution: resolution,
                    ColorDepth: colorDepth,
                    ImageQuality: SolidEdgeFramework.SeImageQualityType.seImageQualityHigh,
                    Invert: false);

                Console.WriteLine("Saved '{0}'.", filename);
            }
        }

        static void SaveAsImage(SolidEdgeDraft.SheetWindow sheetWidow)
        {
            string[] extensions = { ".jpg", ".bmp", ".tif" };
            Guid guid = Guid.NewGuid();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            double resolution = 1;  // DPI - Larger values have better quality but also lead to larger file.
            int colorDepth = 24;
            int width = sheetWidow.UsableWidth;
            int height = sheetWidow.UsableHeight;
            
            // Save each extension.
            foreach (string extension in extensions)
            {
                // File saved to desktop.
                string filename = Path.ChangeExtension(guid.ToString(), extension);
                filename = Path.Combine(folder, filename);

                // You can specify .bmp (Windows Bitmap), .tif (TIFF), or .jpg (JPEG).
                sheetWidow.SaveAsImage(
                    FileName: filename,
                    Width: width,
                    Height: height,
                    Resolution: resolution,
                    ColorDepth: colorDepth,
                    ImageQuality: SolidEdgeFramework.SeImageQualityType.seImageQualityHigh,
                    Invert: false);

                Console.WriteLine("Saved '{0}'.", filename);
            }
        }
    }
}
