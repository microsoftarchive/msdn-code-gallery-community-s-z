using System;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Runtime.Design;
using Microsoft.SqlServer.Dts.Design;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.DataTransformationServices.Design;

namespace Microsoft.Samples.SqlServer.SSIS.SharePointListConnectionManager
{
    public sealed class CredentialConnectionManagerUI : IDtsConnectionManagerUI
    {
        #region private members

        private ConnectionManager _connectionManager;
        private IServiceProvider _serviceProvider = null;
        private IErrorCollectionService _errorCollectionService = null;
        private IDesignerHost _designerHost = null;

        #endregion

        
        #region public properties

        public ConnectionManager ConnectionManager
        {
            get { return _connectionManager; }
        }

        public IServiceProvider ServiceProvider
        {
            get { return _serviceProvider; }
        }

        public IErrorCollectionService ErrorCollectionService
        {
            get
            {
                if (this._errorCollectionService == null)
                {
                    this._errorCollectionService = ServiceProvider.GetService(typeof(IErrorCollectionService)) as IErrorCollectionService;
                }

                return _errorCollectionService;
            }
        }

        public IDesignerHost DesignerHost
        {
            get
            {
                if (this._designerHost == null)
                {
                    this._designerHost = ServiceProvider.GetService(typeof(IDesignerHost)) as IDesignerHost;
                }

                return _designerHost;
            }
        }
        
        #endregion

        #region IDtsConnectionManagerUI Members

        void IDtsConnectionManagerUI.Delete(IWin32Window parentWindow)
        {
            //nothing to do
        }

        bool IDtsConnectionManagerUI.Edit(IWin32Window parentWindow, Connections connections, ConnectionManagerUIArgs connectionUIArg)
        {
            return EditSharePointCredentialConnection(parentWindow, connections);
        }

        void IDtsConnectionManagerUI.Initialize(ConnectionManager connectionManager, IServiceProvider serviceProvider)
        {
            Debug.Assert((connectionManager != null) && (serviceProvider != null));

            this._serviceProvider = serviceProvider;
            this._connectionManager = connectionManager;
        }

        bool IDtsConnectionManagerUI.New(IWin32Window parentWindow, Connections connections, ConnectionManagerUIArgs connectionUIArg)
        {
            // If the user is pasting a new connection manager into this window, we can just return true.
            // We don't need to bring up the edit dialog ourselves
            IDtsClipboardService clipboardService = _serviceProvider.GetService(typeof(IDtsClipboardService)) as IDtsClipboardService;

            if ((clipboardService != null) && (clipboardService.IsPasteActive))
            {
                return true;
            }

            return EditSharePointCredentialConnection(parentWindow, connections);
        }

        #endregion

        private bool EditSharePointCredentialConnection(IWin32Window parentWindow, Connections connections)
        {
            using (CredentialConnectionManagerForm form = new CredentialConnectionManagerForm())
            {
                form.Initialize(this._serviceProvider, this.ConnectionManager, this.ErrorCollectionService);

                if (DesignUtils.ShowDialog(form, parentWindow, this._serviceProvider) == DialogResult.OK)
                {
                    if (!this.ConnectionManager.Name.Equals(form.ConnectionName, StringComparison.OrdinalIgnoreCase))
                    {
                        this.ConnectionManager.Name =
                            ConnectionManagerUtils.GetConnectionName(connections, form.ConnectionName);
                    }

                    ConnectionManager.Description = form.ConnectionDescription;

                    CredentialConnectionManager innerManager = (CredentialConnectionManager)ConnectionManager.InnerObject;

                    if (form.CanUseDefaultCredentials)
                    {
                        innerManager.UserName = string.Empty;
                        innerManager.Password = string.Empty;
                    }
                    else
                    {
                        innerManager.UserName = form.UserName;
                        innerManager.Password = form.Password;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
