using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SolidEdge.AddIn.EdgeBar
{
    /// <summary>
    /// Wrapper class for hWnd returned from ISolidEdgeBarEx.AddPageEx().
    /// </summary>
    public class EdgeBarPage : NativeWindow, IDisposable
    {
        private bool _disposed = false;
        private SolidEdgeFramework.SolidEdgeDocument _document;
        private EdgeBarControl _edgeBarControl;

        public EdgeBarPage(IntPtr hWnd, object theDocument, EdgeBarControl edgeBarControl)
            : this(hWnd, (SolidEdgeFramework.SolidEdgeDocument)theDocument, edgeBarControl)
        {
        }

        public EdgeBarPage(IntPtr hWnd, SolidEdgeFramework.SolidEdgeDocument document, EdgeBarControl edgeBarControl)
        {
            _document = document;
            _edgeBarControl = edgeBarControl;

            _edgeBarControl.EdgeBarPage = this;

            // Assign the hWnd to this class.
            AssignHandle(hWnd);

            // Reparent child control to this hWnd.
            NativeMethods.SetParent(_edgeBarControl.Handle, Handle);

            // Show the child control.
            NativeMethods.ShowWindow(_edgeBarControl.Handle, ShowWindowCommands.Maximize);
        }

        ~EdgeBarPage()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);      
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if ((_edgeBarControl != null) && (!_edgeBarControl.IsDisposed))
                    {
                        try
                        {
                            _edgeBarControl.Dispose();
                        }
                        catch
                        {
                        }
                    }
                }

                try
                {
                    ReleaseHandle();
                }
                catch
                {
                }

                _edgeBarControl = null;
                _disposed = true;
            }
        }

        public SolidEdgeFramework.Application Application { get { return _document.Application; } }
        public SolidEdgeFramework.SolidEdgeDocument Document { get { return _document; } }
        public EdgeBarControl EdgeBarControl { get { return _edgeBarControl; } }
    }
}
