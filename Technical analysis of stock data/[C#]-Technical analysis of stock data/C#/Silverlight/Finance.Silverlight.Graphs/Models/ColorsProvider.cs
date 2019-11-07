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
	public class ColorsProvider : IColorProvider
	{
		private static Color[] colors;

		static ColorsProvider()
		{
			Array items = Enum.GetValues(typeof(ColorNames));

			colors = new Color[items.Length];

			for (Int32 q = 0, qMax = items.Length; q < qMax; q++)
			{
				UInt32 value = (UInt32)(ColorNames)items.GetValue(q);

				colors[q] = Color.FromArgb(
					(byte)(value >> 24),
					(byte)(value >> 16),
					(byte)(value >> 8),
					(byte)value
					);
			}
		}

		public Color GetColor(UInt32 id)
		{
			return colors[(Int32)(id % (UInt32)colors.Length)];						
		}
	}
}
