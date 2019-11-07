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

namespace Finance.Silverlight.Graphs.Controls
{
	public class MvvmHyperlink : HyperlinkButton
	{
		public static readonly DependencyProperty CurrentStateProperty =
			DependencyProperty.Register("CurrentState", typeof(object),
			typeof(MvvmHyperlink),
			new PropertyMetadata(CurrentStatePropertyChanged));

		public object CurrentState
		{
			get { return (object)GetValue(CurrentStateProperty); }
			set { SetValue(CurrentStateProperty, value); }
		}

		private static void CurrentStatePropertyChanged(DependencyObject o, 
							DependencyPropertyChangedEventArgs e)
		{
			MvvmHyperlink hyp = o as MvvmHyperlink;
			if (hyp != null)
			{
				hyp.OnCurrentStatePropertyChanged((object)e.NewValue);
				VisualStateManager.GoToState(hyp,(string)e.NewValue, true);
			}
		}

		private void OnCurrentStatePropertyChanged(object newValue)
		{
			CurrentState = newValue;
		}
	}
}
