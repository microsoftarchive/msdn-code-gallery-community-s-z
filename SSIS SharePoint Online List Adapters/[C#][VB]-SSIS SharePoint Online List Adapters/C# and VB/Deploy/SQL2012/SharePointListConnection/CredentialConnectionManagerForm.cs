using System;
using System.Windows.Forms;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Design;
using System.Globalization;

namespace Microsoft.Samples.SqlServer.SSIS.SharePointListConnectionManager
{
    internal enum ConnectionStringDisplayOption
    {
        NoPassword,
        IncludePassword
    }

    public partial class CredentialConnectionManagerForm : Form
    {
        #region private properties

        private IServiceProvider _serviceProvider;
        private ConnectionManager _connectionManager;
        private IErrorCollectionService _errorCollector;

        #endregion

        #region public properties

        public ConnectionManager ConnectionManager
        {
            get { return this._connectionManager; }
            set
            {
                this.txtName.Text = value.Name;
                this.txtDesc.Text = value.Description;
            }
        }

        public string ConnectionName
        {
            get { return this.txtName.Text.Trim(); }
            set { this.txtName.Text = value; }
        }

        public string ConnectionDescription
        {
            get { return this.txtDesc.Text.Trim(); }
            set { this.txtDesc.Text = value; }
        }

        public string UserName
        {
            get { return this.txtUserName.Text.Trim(); }
            set { this.txtUserName.Text = value; }
        }

        public string Password
        {
            get { return this.txtPwd.Text.Trim(); }
            set { this.txtPwd.Text = value; }
        }

        public bool CanUseDefaultCredentials
        {
            get 
            { 
                return this.rdoUseDefaultCredentials.Checked; 
            }
            set
            {
                this.rdoUseDefaultCredentials.Checked = value;
                this.rdoUseCustomCredentials.Checked = !value;
            }

        }

        #endregion

        #region Error Handling Methods

        protected void ClearErrors()
        {
            _errorCollector.ClearErrors();
        }

        protected string GetErrorMessage()
        {
            return _errorCollector.GetErrorMessage();
        }

        protected void ReportErrors(Exception ex)
        {
            if (_errorCollector.GetErrors().Count > 0)
            {
                MessageBox.Show(_errorCollector.GetErrorMessage(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, 0);
            }
            else
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);

            }
        }

        #endregion

        public CredentialConnectionManagerForm()
        {
            InitializeComponent();
        }

        public void Initialize(IServiceProvider serviceProvider, ConnectionManager connectionManager, IErrorCollectionService errorCollector)
        {
            this._serviceProvider = serviceProvider;
            this._connectionManager = connectionManager;
            this._errorCollector = errorCollector;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void CredentialConnectionManagerForm_Load(object sender, EventArgs e)
        {
            this.ConnectionName = this.ConnectionManager.Name;
            this.ConnectionDescription = this.ConnectionManager.Description;

            CredentialConnectionManager innerManager = (CredentialConnectionManager)this.ConnectionManager.InnerObject;

            if (innerManager.UserName.Length == 0)
            {
                this.rdoUseDefaultCredentials.Checked = true;
                this.UserName = string.Empty;
                this.Password = string.Empty;
            }
            else
            {
                this.rdoUseCustomCredentials.Checked = true;
                this.UserName = innerManager.UserName;
                this.Password = innerManager.GetPassword();
            }

        }

        private void rdoUseDefaultCredentials_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.Enabled = rdoUseCustomCredentials.Checked;
            txtPwd.Enabled = rdoUseCustomCredentials.Checked;
        }

        private void rdoUseCustomCredentials_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.Enabled = rdoUseCustomCredentials.Checked;
            txtPwd.Enabled = rdoUseCustomCredentials.Checked;
        }

    }
}
