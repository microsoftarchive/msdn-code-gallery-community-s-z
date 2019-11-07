//-----------------------------------------------------------------------
// <copyright file="WorkflowViewModel.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//-----------------------------------------------------------------------
namespace Microsoft.Consulting.WorkflowStudio.ViewModel
{
    using System;
    using System.Activities.Presentation;
    using System.Activities.Presentation.Services;
    using System.Activities.Presentation.Validation;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.IO;
    using System.ServiceModel.Activities;
    using System.Windows;
    using System.Windows.Controls;
    using Microsoft.Consulting.WorkflowStudio.Execution;
    using Microsoft.Consulting.WorkflowStudio.Properties;
    using Microsoft.Consulting.WorkflowStudio.Utilities;
    using Microsoft.Consulting.WorkflowStudio.Views;
    using Microsoft.Win32;

    public class WorkflowViewModel : ViewModelBase
    {
        private static int designerCount;
        private WorkflowDesigner workflowDesigner;
        private IList<ValidationErrorInfo> validationErrors;
        private ValidationErrorService validationErrorService;
        private ValidationErrorsUserControl validationErrorsView;
        private bool modelChanged;
        private TextWriter output;
        private TextBox outputTextBox;
        private IWorkflowRunner runner;
        private int id;
        private string fullFilePath;
        private bool disableDebugViewOutput;

        public WorkflowViewModel(bool disableDebugViewOutput)
        {
            this.workflowDesigner = new WorkflowDesigner();
            this.id = ++designerCount;
            this.validationErrors = new List<ValidationErrorInfo>();
            this.validationErrorService = new ValidationErrorService(this.validationErrors);
            this.workflowDesigner.Context.Services.Publish<IValidationErrorService>(this.validationErrorService);

            this.workflowDesigner.ModelChanged += delegate(object sender, EventArgs args)
            {
                this.modelChanged = true;
                this.OnPropertyChanged("DisplayNameWithModifiedIndicator");
            };

            this.validationErrorsView = new ValidationErrorsUserControl();

            this.outputTextBox = new TextBox();
            this.output = new TextBoxStreamWriter(this.outputTextBox, this.DisplayName);
            this.disableDebugViewOutput = disableDebugViewOutput;

            this.workflowDesigner.Context.Services.GetService<DesignerConfigurationService>().TargetFrameworkName = new System.Runtime.Versioning.FrameworkName(".NETFramework", new Version(4, 5));
            this.workflowDesigner.Context.Services.GetService<DesignerConfigurationService>().LoadingFromUntrustedSourceEnabled = bool.Parse(ConfigurationManager.AppSettings["LoadingFromUntrustedSourceEnabled"]);

            this.validationErrorService.ErrorsChangedEvent += delegate(object sender, EventArgs args)
            {
                DispatcherService.Dispatch(() =>
                {
                    this.validationErrorsView.ErrorsDataGrid.ItemsSource = this.validationErrors;
                    this.validationErrorsView.ErrorsDataGrid.Items.Refresh();
                });
            };
        }

        #region Presentation Properties

        public UIElement DebugView
        {
            get
            {
                IWorkflowDebugger debugger = this.runner as IWorkflowDebugger;
                if (debugger != null)
                {
                    return debugger.GetDebugView();
                }
                else
                {
                    return null;
                }
            }
        }

        public UIElement OutlineView
        {
            get
            {
                return this.workflowDesigner.OutlineView;
            }
        }

        public UIElement ValidationErrorsView
        {
            get
            {
                return this.validationErrorsView;
            }
        }

        public bool HasValidationErrors
        {
            get
            {
                return this.validationErrors.Count > 0;
            }
        }

        public UIElement OutputView
        {
            get
            {
                return this.outputTextBox;
            }
        }

        public TextWriter Output
        {
            get
            {
                return this.output;
            }
        }

        public WorkflowDesigner Designer
        {
            get
            {
                return this.workflowDesigner;
            }
        }

        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(this.FullFilePath))
                {
                    return string.Format(Resources.NewWorkflowTabTitle, this.id);
                }
                else
                {
                    return Path.GetFileName(this.FullFilePath);
                }
            }
        }

        public string DisplayNameWithModifiedIndicator
        {
            get
            {
                string modifiedIndicator = this.modelChanged ? "*" : string.Empty;
                if (string.IsNullOrEmpty(this.FullFilePath))
                {
                    return string.Format(Resources.NewWorkflowWithModifierTabTitle, this.id, modifiedIndicator);
                }
                else
                {
                    return string.Format("{0} {1}", Path.GetFileName(this.FullFilePath), modifiedIndicator);
                }
            }
        }

        public string FullFilePath
        {
            get
            {
                return this.fullFilePath;
            }

            set
            {
                this.fullFilePath = value;
                this.output = new TextBoxStreamWriter(this.outputTextBox, Path.GetFileNameWithoutExtension(this.fullFilePath));
            }
        }

        public bool IsRunning
        {
            get
            {
                return this.runner == null ? false : this.runner.IsRunning;
            }
        }

        public bool IsModified
        {
            get
            {
                return this.modelChanged;
            }
        }

        #endregion

        public void Abort()
        {
            if (this.runner != null)
            {
                this.runner.Abort();
            }
        }

        public void Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = false;

            if (this.IsRunning)
            {
                MessageBoxResult closingResult = MessageBox.Show(Resources.ConfirmCloseWhenRunningWorkflowDialogMessage, Resources.ConfirmCloseWhenRunningWorkflowDialogTitle, MessageBoxButton.YesNo);
                switch (closingResult)
                {
                    case MessageBoxResult.No:
                        e.Cancel = true;
                        break;
                    case MessageBoxResult.Yes:
                        e.Cancel = false;
                        this.Abort();
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }

            if (e.Cancel == false)
            {
                if (this.modelChanged)
                {
                    MessageBoxResult closingResult = MessageBox.Show(string.Format(Resources.SaveChangesDialogMessage, this.DisplayName), Resources.SaveChangesDialogTitle, MessageBoxButton.YesNoCancel);
                    switch (closingResult)
                    {
                        case MessageBoxResult.No:
                            e.Cancel = false;
                            break;
                        case MessageBoxResult.Yes:
                            e.Cancel = !this.SaveWorkflow();
                            break;
                        case MessageBoxResult.Cancel:
                            e.Cancel = true;
                            break;
                    }
                }
            }
        }

        public Type GetRootType()
        {
            ModelService modelService = this.workflowDesigner.Context.Services.GetService<ModelService>();
            if (modelService != null)
            {
                return modelService.Root.GetCurrentValue().GetType();
            }
            else
            {
                return null;
            }
        }

        public bool SaveWorkflow()
        {
            if (!string.IsNullOrEmpty(this.FullFilePath))
            {
                this.SaveWorkflow(this.FullFilePath);
                return true;
            }
            else
            {
                SaveFileDialog fileDialog = WorkflowFileDialogFactory.CreateSaveFileDialog(this.DisplayName);

                if (fileDialog.ShowDialog() == true)
                {
                    this.SaveWorkflow(fileDialog.FileName);
                    return true;
                }

                return false;
            }
        }

        public void SaveAsWorkflow()
        {
            SaveFileDialog fileDialog = WorkflowFileDialogFactory.CreateSaveFileDialog(this.DisplayName);

            if (fileDialog.ShowDialog() == true)
            {
                this.SaveWorkflow(fileDialog.FileName);
            }
        }

        public void RunWorkflow()
        {
            if (this.GetRootType() == typeof(WorkflowService))
            {
                this.runner = new WorkflowServiceHostRunner(this.output, this.DisplayName, this.workflowDesigner);
            }
            else
            {
                this.runner = new WorkflowRunner(this.output, this.DisplayName, this.workflowDesigner);
            }

            try
            {
                this.outputTextBox.Clear();
                this.runner.Run();
            } 
            catch (Exception e)
            {
                MessageBox.Show(string.Format(Resources.ErrorRunningDialogMessage, ExceptionHelper.FormatStackTrace(e)), Resources.ErrorRunningDialogTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        public void DebugWorkflow()
        {
            if (this.GetRootType() == typeof(WorkflowService))
            {
                this.runner = new WorkflowServiceHostDebugger(this.output, this.DisplayName, this.workflowDesigner, this.disableDebugViewOutput);
            }
            else
            {
                this.runner = new WorkflowDebugger(this.output, this.DisplayName, this.workflowDesigner, this.disableDebugViewOutput);
            }

            try
            {
                this.outputTextBox.Clear();
                this.runner.Run();
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(Resources.ErrorLoadingInDebugDialogMessage, ExceptionHelper.FormatStackTrace(e)), Resources.ErrorLoadingInDebugDialogTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveWorkflow(string fullFilePath)
        {
            StatusViewModel.SetStatusText(Resources.SavingStatus, this.DisplayName);

            this.FullFilePath = fullFilePath;
            this.workflowDesigner.Save(this.FullFilePath);
            this.modelChanged = false;
            this.OnPropertyChanged("DisplayName");
            this.OnPropertyChanged("DisplayNameWithModifiedIndicator");

            StatusViewModel.SetStatusText(Resources.SaveSuccessfulStatus, this.DisplayName);
        }
    }
}