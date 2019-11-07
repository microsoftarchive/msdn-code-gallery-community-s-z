//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.ViewModels
{
    using System;
    using System.Activities;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
    using System.Xaml;
    using System.Xml.Linq;
    using Microsoft.Workflow.Client;
    using Microsoft.Workflow.Explorer.Controllers;

    public class ActivityViewModel : ViewModelBase
    {
        ActivityDescription description;
        Collection<MetadataViewModel> metadata;
        string xamlSizeLabel;
        string clrName;
        string rootActivityType;

        public ActivityViewModel(ActivityDescription description)
        {
            this.description = description;
            this.metadata = new MetadataCollection(description.Metadata);
            this.clrName = GetClrName(this.description.Xaml);
            this.xamlSizeLabel = GetXamlSizeString(this.description.Xaml);
            this.rootActivityType = GetRootActivityType(this.description.Xaml);
            this.ShowXamlCommand = new SimpleActionCommand(this.OnShowXaml);
            this.ShowMetadataCommand = new SimpleActionCommand(this.OnShowMetadata);
        }

        public string Name
        {
            get { return this.description.Name; }
        }

        public string Xaml
        {
            get { return this.description.Xaml != null ? this.description.Xaml.ToString() : null; }
        }

        public string XamlSizeLabel
        {
            get { return this.xamlSizeLabel; }
        }

        public int MetadataPairs
        {
            get { return this.metadata.Count; }
        }

        public DateTime LastModified
        {
            get { return this.description.LastModified.ToLocalTime(); }
        }

        public string IsCachingEnabled
        {
            get { return this.description.ShouldCache ? "Yes" : "No"; }
        }

        public string RootActivityType
        {
            get { return this.rootActivityType; }
        }

        public ICommand ShowXamlCommand
        {
            get;
            private set;
        }

        public ICommand ShowMetadataCommand
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return this.Name;
        }

        static string GetClrName(XElement xaml)
        {
            XAttribute xClassAttribute = null;
            if (xaml != null)
            {
                XName xClassName = XName.Get(XamlLanguage.Class.Name, XamlLanguage.Class.PreferredXamlNamespace);
                xClassAttribute = xaml.Attributes(xClassName).FirstOrDefault();
            }

            return xClassAttribute != null ? xClassAttribute.Value : null;
        }

        static string GetRootActivityType(XElement xaml)
        {
            if (xaml == null)
            {
                return "n/a";
            }

            if (string.Equals(xaml.Name.LocalName, typeof(Activity).Name, StringComparison.Ordinal))
            {
                return "Reusable";
            }
            else
            {
                return xaml.Name.LocalName;
            }
        }

        static string GetXamlSizeString(XElement xaml)
        {
            if (xaml == null)
            {
                return "n/a";
            }

            const int kilobyte = 1024;
            const int megabyte = kilobyte * 1024;

            // get the byte count with whitespace removed
            int byteCount = Encoding.UTF8.GetByteCount(xaml.ToString(SaveOptions.DisableFormatting));
            if (byteCount < kilobyte)
            {
                return string.Format(CultureInfo.CurrentUICulture, "{0:N0} Bytes", byteCount);
            }
            else if (byteCount < megabyte)
            {
                return string.Format(CultureInfo.CurrentUICulture, "{0:N0} KB", byteCount / kilobyte);
            }
            else
            {
                return string.Format(CultureInfo.CurrentUICulture, "{0:N0} MB", byteCount / megabyte);
            }
        }

        void OnShowXaml(object sender)
        {
            if (this.description.Xaml != null)
            {
                ScopeNavigationController.Default.NavigateToActivityXamlPage(this);
            }
        }

        void OnShowMetadata(object sender)
        {
            if (this.description.Metadata.Count > 0)
            {
                ScopeNavigationController.Default.NavigateToDictionaryPage((IDictionary)this.description.Metadata);
            }
        }

        class MetadataCollection : KeyedCollection<string, MetadataViewModel>
        {
            public MetadataCollection(IDictionary<string, string> source)
            {
                if (source != null)
                {
                    foreach (KeyValuePair<string, string> pair in source)
                    {
                        this.Add(new MetadataViewModel { Key = pair.Key, Value = pair.Value });
                    }
                }
            }

            protected override string GetKeyForItem(MetadataViewModel item)
            {
                return item.Key;
            }
        }
    }
}