using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Finance.Silverlight.Graphs.ChildWindows
{
	public partial class ErrorWindow : ChildWindow
	{
		public ErrorWindow(Exception e)
		{
			InitializeComponent();
			if (e != null)
			{
				ErrorTextBox.Text = e.Message + Environment.NewLine + Environment.NewLine + e.StackTrace;
			}
		}

		public ErrorWindow(Uri uri)
		{
			InitializeComponent();
			if (uri != null)
			{
				ErrorTextBox.Text = "Page not found: \"" + uri.ToString() + "\"";
			}
		}

		public ErrorWindow(string message, string details)
		{
			InitializeComponent();
			ErrorTextBox.Text = message + Environment.NewLine + Environment.NewLine + details;
		}

		private void OKButton_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}
	}
}

