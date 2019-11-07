using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace SolidEdge.AddIn.EdgeBar
{
    /// <summary>
    /// Controller class for ISolidEdgeBarEx.
    /// </summary>
    public class EdgeBarController : SolidEdgeFramework.ISEAddInEdgeBarEvents, IDisposable
    {
        private bool _disposed = false;
        private MyAddIn _myAddIn;
        private SolidEdgeFramework.ISolidEdgeBarEx _edgeBar;
        private Dictionary<IConnectionPoint, int> _connectionPointDictionary = new Dictionary<IConnectionPoint, int>();
        private Dictionary<IntPtr, EdgeBarPage> _edgeBarPageDictionary = new Dictionary<IntPtr, EdgeBarPage>();

        public EdgeBarController(MyAddIn myAddIn)
        {
            _myAddIn = myAddIn;
            _edgeBar = (SolidEdgeFramework.ISolidEdgeBarEx)_myAddIn.AddIn;

            HookEvents(_myAddIn.AddIn, typeof(SolidEdgeFramework.ISEAddInEdgeBarEvents).GUID);
        }

        ~EdgeBarController()
        {
            Dispose(false);
        }

        #region SolidEdgeFramework.ISEAddInEdgeBarEvents

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEAddInEdgeBarEvents.AddPage event.
        /// </summary>
        public void AddPage(object theDocument)
        {
            AddPage(theDocument, new SelectSetEdgeBarControl());
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEAddInEdgeBarEvents.IsPageDisplayable event.
        /// </summary>
        public void IsPageDisplayable(object theDocument, string EnvironmentCatID, out bool vbIsPageDisplayable)
        {
            vbIsPageDisplayable = true;
        }

        /// <summary>
        /// Implementation of SolidEdgeFramework.ISEAddInEdgeBarEvents.RemovePage event.
        /// </summary>
        public void RemovePage(object theDocument)
        {
            // We use the IUnknown pointer of the document as the dictionary key.
            IntPtr pUnk = Marshal.GetIUnknownForObject(theDocument);
            Marshal.Release(pUnk);

            // If we have an EdgeBarPage for the document, remove it.
            if (_edgeBarPageDictionary.ContainsKey(pUnk))
            {
                RemovePage(_edgeBarPageDictionary[pUnk]);
            }
        }

        #endregion

        #region EdgeBarController methods

        private EdgeBarPage AddPage(object theDocument, EdgeBarControl edgeBarControl)
        {
            EdgeBarPage edgeBarPage = null;
            IntPtr hWndPage = IntPtr.Zero;

            // We use the IUnknown pointer of the document as the dictionary key.
            IntPtr pUnk = Marshal.GetIUnknownForObject(theDocument);
            Marshal.Release(pUnk);

            // Only add a new EdgeBarPage if one hasn't already been added.
            if (!_edgeBarPageDictionary.ContainsKey(pUnk))
            {
                if (_myAddIn.ResourceAssembly != null)
                {
                    System.Reflection.Assembly resourceAssembly = _myAddIn.ResourceAssembly;

                    // If ResourceAssembly is null, default to the currently executing assembly.
                    if (resourceAssembly == null)
                    {
                        resourceAssembly = Assembly.GetExecutingAssembly();
                    }

                    hWndPage = new IntPtr(_edgeBar.AddPageEx(theDocument, resourceAssembly.Location, edgeBarControl.BitmapID, edgeBarControl.ToolTip, 2));
                }

                // ISolidEdgeBarEx.AddPage() may return null.
                if (!hWndPage.Equals(IntPtr.Zero))
                {
                    edgeBarPage = new EdgeBarPage(hWndPage, theDocument, edgeBarControl);
                }

                _edgeBarPageDictionary.Add(pUnk, edgeBarPage);
            }
            else
            {
                edgeBarPage = _edgeBarPageDictionary[pUnk];
            }

            return edgeBarPage;
        }

        private void RemovePage(EdgeBarPage edgeBarPage)
        {
            IntPtr hWndEdgeBarPage = edgeBarPage.Handle;

            // We use the IUnknown pointer of the document as the dictionary key.
            IntPtr pUnk = Marshal.GetIUnknownForObject(edgeBarPage.Document);
            Marshal.Release(pUnk);

            if (_edgeBarPageDictionary.ContainsKey(pUnk))
            {
                _edgeBarPageDictionary.Remove(pUnk);
                edgeBarPage.Dispose();

                _edgeBar.RemovePage(edgeBarPage.Document, hWndEdgeBarPage.ToInt32(), 0);
            }
        }

        #endregion

        #region IConnectionPoint helpers

        private void HookEvents(object eventSource, Guid eventGuid)
        {
            IConnectionPointContainer container = null;
            IConnectionPoint connectionPoint = null;
            int cookie = 0;

            container = (IConnectionPointContainer)eventSource;
            container.FindConnectionPoint(eventGuid, out connectionPoint);

            if (connectionPoint != null)
            {
                connectionPoint.Advise(this, out cookie);
                _connectionPointDictionary.Add(connectionPoint, cookie);
            }
        }

        private void UnhookAllEvents()
        {
            Dictionary<IConnectionPoint, int>.Enumerator enumerator = _connectionPointDictionary.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Key.Unadvise(enumerator.Current.Value);
            }

            _connectionPointDictionary.Clear();
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Dictionary<IntPtr, EdgeBarPage>.Enumerator enumerator = _edgeBarPageDictionary.GetEnumerator();

                    while (enumerator.MoveNext())
                    {
                        RemovePage(enumerator.Current.Value);
                    }

                    _edgeBarPageDictionary.Clear();
                }

                _edgeBarPageDictionary = null;
                _edgeBar = null;
                _myAddIn = null;
                _disposed = true;
            }
        }

        #endregion
    }
}
