//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Program.cs
//
//  Description: Application entry-point.
// 
//--------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
{
    /// <summary>Contains the entrypoint for the application.</summary>
    public static class Program
    {
        /// <summary>The main application form.</summary>
        private static MainForm _mainForm;

        /// <summary>Main entrypoint.</summary>
        [STAThread]
        public static void Main(string[] args)
        {
            // Setup visual styles. Do this first so that any error message boxes
            // displayed get the visual styles to match.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            // Create the main form and run the app
            _mainForm = new MainForm(); // purposely not using 'using' as, in the event of an exception, we want to access MainForm's state
            Application.Run(_mainForm);
            _mainForm.Dispose();
            _mainForm = null;
        }
    }
}