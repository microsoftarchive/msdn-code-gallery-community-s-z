//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Microsoft.Workflow.Client.Security;
    using Microsoft.Workflow.Explorer.Controllers;
    using Microsoft.Workflow.Explorer.Properties;

    class OAuthS2SAuthenticationViewModel : AuthenticationViewModelBase
    {
        static readonly ImageSource OAuth2Image = new BitmapImage(new Uri("/Images/OAuth2_Logo.png", UriKind.Relative));

        string clientPrincipalId = Settings.Default.OAuthS2S_ClientPrincipalId;
        string certificatePath = Settings.Default.OAuthS2S_CertificatePath;
        string certificatePassword;
        bool useSTSCredentials = Settings.Default.OAuthS2S_UseSTSIssuedToken;
        string metadataUri = Settings.Default.OAuthS2S_MetadataUri;
        string issuerPrincipalId = Settings.Default.OAuthS2S_IssuerPrincipalId;

        public OAuthS2SAuthenticationViewModel(Uri serviceUri, Action<ServiceContext> onConnected)
            : base(serviceUri, onConnected)
        {
        }

        public override ImageSource Icon
        {
            get { return OAuth2Image; }
        }

        public override string Description
        {
            get { return "OAuth S2S Authentication"; }
        }

        public string ClientPrincipalId
        {
            get { return this.clientPrincipalId; }
            set
            {
                if (this.clientPrincipalId != value)
                {
                    this.clientPrincipalId = value;
                    Settings.Default.OAuthS2S_ClientPrincipalId = value;
                    this.RaisePropertyChanged("ClientPrincipalId");
                }
            }
        }

        public string CertificatePath
        {
            get { return this.certificatePath; }
            set
            {
                if (this.certificatePath != value)
                {
                    this.certificatePath = value;
                    Settings.Default.OAuthS2S_CertificatePath = value;
                    this.RaisePropertyChanged("CertificatePath");
                }
            }
        }

        // TODO: Find a way to bind to the SecureString property of the PasswordBox control
        public string Password
        {
            get { return this.certificatePassword; }
            set
            {
                if (this.certificatePassword != value)
                {
                    this.certificatePassword = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }

        public bool UseSTSCredentials
        {
            get { return this.useSTSCredentials; }
            set
            {
                if (this.useSTSCredentials != value)
                {
                    this.useSTSCredentials = value;
                    Settings.Default.OAuthS2S_UseSTSIssuedToken = value;
                    this.RaisePropertyChanged("UseSTSCredentials");
                    this.RaisePropertyChanged("UseSelfIssuedCredentials");
                }
            }
        }

        public string MetadataUri
        {
            get { return this.metadataUri; }
            set
            {
                if (this.metadataUri != value)
                {
                    this.metadataUri = value;
                    Settings.Default.OAuthS2S_MetadataUri = value;
                    this.RaisePropertyChanged("MetadataUri");
                }
            }
        }

        // this property is an inverse of UseSTSCredentials used strictly for data binding
        public bool UseSelfIssuedCredentials
        {
            get { return !this.UseSTSCredentials; }
            set { this.UseSTSCredentials = !value; }
        }

        public string IssuerPrincipalId
        {
            get { return this.issuerPrincipalId; }
            set
            {
                if (this.issuerPrincipalId != value)
                {
                    this.issuerPrincipalId = value;
                    Settings.Default.OAuthS2S_IssuerPrincipalId = value;
                    this.RaisePropertyChanged("IssuerPrincipalId");
                }
            }
        }

        protected override void OnSelected()
        {
            CredentialSelectionController.Default.NavigateToOAuthS2SPage(this);
        }

        protected override bool TryCreateCredentials(Uri serviceUri, out ICredentials clientCredentials)
        {
            clientCredentials = null;

            if (string.IsNullOrWhiteSpace(this.ClientPrincipalId))
            {
                this.ErrorMessage = "Please enter a client principal ID in the form 'id@realm'.";
            }
            else if (string.IsNullOrWhiteSpace(this.CertificatePath))
            {
                this.ErrorMessage = "Please enter the path to the OAuth signing certificate (*.pfx).";
            }
            else if (!File.Exists(this.CertificatePath))
            {
                this.ErrorMessage = "Could not find certificate file '" + this.CertificatePath + "'.";
            }
            else
            {
                X509Certificate2 signingCertificate = new X509Certificate2(this.CertificatePath.Trim(), this.Password);
                if (this.UseSTSCredentials)
                {
                    Uri metadataUri;
                    if (string.IsNullOrWhiteSpace(this.MetadataUri) || !Uri.TryCreate(this.MetadataUri, UriKind.Absolute, out metadataUri))
                    {
                        this.ErrorMessage = "Please enter a valid URI.";
                    }
                    else if (!string.Equals(metadataUri.Scheme, Uri.UriSchemeHttp) && !string.Equals(metadataUri.Scheme, Uri.UriSchemeHttps))
                    {
                        this.ErrorMessage = "The URI scheme must be HTTP or HTTPS.";
                    }
                    else
                    {
                        clientCredentials = new OAuthS2SDiscoveryCredential(this.ClientPrincipalId, metadataUri, signingCertificate);
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(this.IssuerPrincipalId))
                    {
                        clientCredentials = new OAuthS2SSelfIssuedCredential(this.ClientPrincipalId.Trim(), signingCertificate);
                    }
                    else
                    {
                        clientCredentials = new OAuthS2SSelfIssuedCredential(
                            this.ClientPrincipalId.Trim(),
                            null /* realm - this will be infered from the client principal ID */,
                            signingCertificate,
                            this.IssuerPrincipalId.Trim());
                    }
                }
            }

            return clientCredentials != null;
        }
    }
}
