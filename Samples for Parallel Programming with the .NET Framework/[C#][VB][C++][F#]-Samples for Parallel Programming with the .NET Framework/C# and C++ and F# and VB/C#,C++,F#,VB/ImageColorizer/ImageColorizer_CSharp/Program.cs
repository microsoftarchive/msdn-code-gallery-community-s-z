//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Program.cs
//
//--------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
{
    static class Program
    {
        /// <summary>The entry point for the application.</summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}