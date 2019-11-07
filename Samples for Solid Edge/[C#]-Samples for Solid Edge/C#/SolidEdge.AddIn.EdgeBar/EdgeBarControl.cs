using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace SolidEdge.AddIn.EdgeBar
{
    /// <summary>
    /// Base EdgeBar control. Provides core functionality.
    /// </summary>
    /// <remarks>
    /// Not intended to be directly created but rather inherited from.
    /// </remarks>
    public class EdgeBarControl : System.Windows.Forms.UserControl, SolidEdgeFramework.ISEDocumentEvents
    {
        private EdgeBarPage _edgeBarPage;
        private Dictionary<IConnectionPoint, int> _connectionPointDictionary = new Dictionary<IConnectionPoint, int>();
        private string _tooltip = String.Empty;
        private int _bitmapID;

        public EdgeBarControl()
            : base()
        {
            InitializeComponent();
        }

        ~EdgeBarControl()
        {
            Dispose(false);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (!DesignMode)
            {
                UnhookAllEvents();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // EdgeBarControl
            // 
            this.Name = "EdgeBarControl";
            this.Size = new System.Drawing.Size(256, 248);
            this.ResumeLayout(false);

        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            DoubleBuffered = true;
        }

        #region SolidEdgeFramework.ISEDocumentEvents

        /// <summary>
        /// Virtual implementation of SolidEdgeFramework.ISEDocumentEvents.AfterSave().
        /// </summary>
        /// <remarks>
        /// Override in implementing class if you want to handle this event.
        /// </remarks>
        public virtual void AfterSave()
        {
        }

        /// <summary>
        /// Virtual implementation of SolidEdgeFramework.ISEDocumentEvents.BeforeClose().
        /// </summary>
        /// <remarks>
        /// Override in implementing class if you want to handle this event.
        /// </remarks>
        public virtual void BeforeClose()
        {
            UnhookAllEvents();
        }

        /// <summary>
        /// Virtual implementation of SolidEdgeFramework.ISEDocumentEvents.BeforeSave().
        /// </summary>
        /// <remarks>
        /// Override in implementing class if you want to handle this event.
        /// </remarks>
        public virtual void BeforeSave()
        {
        }

        /// <summary>
        /// Virtual implementation of SolidEdgeFramework.ISEDocumentEvents.SelectSetChanged().
        /// </summary>
        /// <remarks>
        /// Override in implementing class if you want to handle this event.
        /// </remarks>
        public virtual void SelectSetChanged(object SelectSet)
        {
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

        #region Properties

        [Browsable(false)]
        public EdgeBarPage EdgeBarPage
        {
            get { return _edgeBarPage; }
            set
            {
                _edgeBarPage = value;

                if ((_edgeBarPage != null) && (_edgeBarPage.Document != null))
                {
                    if (_edgeBarPage.Document != null)
                    {
                        HookEvents(_edgeBarPage.Document.DocumentEvents, typeof(SolidEdgeFramework.ISEDocumentEvents).GUID);
                    }
                }
            }
        }

        [Browsable(false)]
        public SolidEdgeFramework.Application Application { get { return _edgeBarPage.Application; } }

        [Browsable(false)]
        public SolidEdgeFramework.SolidEdgeDocument Document { get { return _edgeBarPage.Document; } }

        /// <summary>
        /// The ID of the Bitmap to be used in the EdgeBarPage.
        /// </summary>
        /// <remarks>
        /// Win32 resources are located in the Resources.res file.
        /// </remarks>
        [Browsable(true)]
        public int BitmapID
        {
            get { return _bitmapID; }
            set { _bitmapID = value; }
        }

        /// <summary>
        /// The string to be used in the EdgeBarPage caption and tooltip.
        /// </summary>
        [Browsable(true)]
        public string ToolTip
        {
            get { return _tooltip; }
            set { _tooltip = value; }
        }

        #endregion
    }
}
