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

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
	public interface ISeriesWithRangeAxis
	{
		IRangeAxis ActualIndependentRangeAxis
		{
			get;
		}

		Double ActualHeight
		{
			get;
		}

		GeneralTransform TransformToVisual(UIElement visual);

		void Measure(Size availableSize);
	}
}
