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
using Finance.Silverlight.Common;

namespace Finance.Silverlight.Graphs.Models
{
	public class VersatileFactory
	{
		public static readonly VersatileFactory Instance = new VersatileFactory();

		public IColorProvider CreateColorProvider()
		{
			return new ColorsProvider();
		}
	}
}
