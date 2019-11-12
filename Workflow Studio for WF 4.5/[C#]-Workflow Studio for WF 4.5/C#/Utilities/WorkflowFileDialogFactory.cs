//-----------------------------------------------------------------------
// <copyright file="WorkflowFileDialogFactory.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//-----------------------------------------------------------------------
namespace Microsoft.Consulting.WorkflowStudio.Utilities
{
    using Microsoft.Win32;
    
    public class WorkflowFileDialogFactory
    {
        public static SaveFileDialog CreateSaveFileDialog(string defaultFilename)
        {
            var fileDialog = new SaveFileDialog();
            fileDialog.DefaultExt = "xaml";
            fileDialog.FileName = defaultFilename;
            fileDialog.Filter = "xaml files (*.xaml,*.xamlx)|*.xaml;*.xamlx;|All files (*.*)|*.*";
            return fileDialog;
        }

        public static OpenFileDialog CreateOpenFileDialog()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = "xaml";
            fileDialog.Filter = "xaml files (*.xaml,*.xamlx)|*.xaml;*.xamlx;|All files (*.*)|*.*";
            return fileDialog;
        }

        public static OpenFileDialog CreateAddReferenceDialog()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = "dll";
            fileDialog.Filter = "assembly files (*.dll)|*.dll;|All files (*.*)|*.*";
            return fileDialog;
        }
    }
}