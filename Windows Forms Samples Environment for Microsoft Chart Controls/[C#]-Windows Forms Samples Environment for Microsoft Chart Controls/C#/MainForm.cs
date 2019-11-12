//==============================================================================
//  File:		MainForms.cs
//
//  Namespace:	WinFormsChartSamples
//
//	Classes:	ApplicationEntryPoint
//
//  Purpose:	The main entry point for the application.
//
//==============================================================================
// Copyright © Microsoft Corporation, all rights reserved
//==============================================================================

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace WinFormsChartSamples
{
	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	public class ApplicationEntryPoint
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			// Run main form
            Application.Run(new System.Windows.Forms.DataVisualization.Charting.Utilities.SampleMain.MainForm());
        }
	}
}
