using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Cinch;

namespace Finance.Silverlight.Graphs.Models
{
	public class NavItemInfo : ViewModelBase
	{
		public bool SeperatorVisible { get; set; }
		public string PageUri { get; set; }
		public string ButtonContent { get; set; }
		public string CurrentState { get; set; }

	}
}
