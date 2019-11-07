//-----------------------------------------------------------------------
// <copyright file="WorkflowDocumentContent.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// Third Party Code: This file is based on or incorporates material from the projects listed below (collectively, “Third Party Code”).
// Microsoft is not the original author of the Third Party Code. The original copyright notice, as well as the license under which 
// Microsoft received such Third Party Code, are set forth below. Such licenses and notices are provided for informational purposes only.
// Microsoft, not the third party, licenses the Third Party Code to you under the terms set forth in the EULA for AvalonDock.
// Unless applicable law gives you more rights, Microsoft reserves all other rights not expressly granted under this agreement,
// whether by implication, estoppel or otherwise.  
//
// AvalonDock project, available at http://avalondock.codeplex.com. Copyright (c) 2007-2009, Adolfo Marinucci. All rights reserved.
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
// IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; 
// OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT 
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// </copyright>
//-----------------------------------------------------------------------
namespace Microsoft.Consulting.WorkflowStudio
{
    using System;
    using System.Activities.Core.Presentation;
    using System.Activities.Presentation;
    using System.ComponentModel;
    using System.Configuration;
    using System.IO;
    using System.Windows;
    using AvalonDock;
    using Microsoft.Consulting.WorkflowStudio.Properties;
    using Microsoft.Consulting.WorkflowStudio.Utilities;
    using Microsoft.Consulting.WorkflowStudio.ViewModel;
    
    public class WorkflowDocumentContent : DocumentContent
    {
        private string defaultWorkflow = "..\\..\\defaultWorkflow.xaml";
        private string defaultWorkflowService = "..\\..\\defaultWorkflowService.xamlx";

        static WorkflowDocumentContent()
        {
           new DesignerMetadata().Register();
        }

        public WorkflowDocumentContent(WorkflowViewModel model)
            : this(model, WorkflowTypes.Activity)
        {
        }

        public WorkflowDocumentContent(WorkflowViewModel model, WorkflowTypes workflowType)
            : base()
        {
            this.DataContext = model;

            string defaultWorkflowValue = ConfigurationManager.AppSettings["DefaultWorkflow"];
            if (!string.IsNullOrEmpty(defaultWorkflowValue))
            {
                this.defaultWorkflow = defaultWorkflowValue;
            }

            string defaultWorkflowServiceValue = ConfigurationManager.AppSettings["DefaultWorkflowService"];
            if (!string.IsNullOrEmpty(defaultWorkflowServiceValue))
            {
                this.defaultWorkflowService = defaultWorkflowServiceValue;
            }

            WorkflowDesigner designer = model.Designer;

            try
            {
                if (string.IsNullOrEmpty(model.FullFilePath))
                {
                    if (workflowType == WorkflowTypes.Activity)
                    {
                        
                        designer.Load(Path.GetFullPath(this.defaultWorkflow));
                    }
                    else
                    {
                        designer.Load(Path.GetFullPath(this.defaultWorkflowService));
                    }
                }
                else
                {
                    designer.Load(model.FullFilePath);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(Properties.Resources.ErrorLoadingDialogMessage, ExceptionHelper.FormatStackTrace(e)), Properties.Resources.ErrorLoadingDialogTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
                
            this.Content = model.Designer.View;

            model.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.Model_PropertyChanged);
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "DisplayNameWithModifiedIndicator" || args.PropertyName == "DisplayName")
            {
                WorkflowViewModel model = this.DataContext as WorkflowViewModel;
                if (model != null)
                {
                    this.Title = model.DisplayNameWithModifiedIndicator;
                }
            }
        }
    }
}
