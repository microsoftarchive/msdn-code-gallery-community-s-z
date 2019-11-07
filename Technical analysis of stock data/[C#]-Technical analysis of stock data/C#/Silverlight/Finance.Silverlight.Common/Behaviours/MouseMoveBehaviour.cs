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

namespace Finance.Silverlight.Common.Behaviours
{
	public static class MouseMoveBehaviour
	{
		/// <summary>
		/// Hooks up a weak event against the source Selectors MouseMove
		/// 
		/// </summary>
		private static void OnHandleMoveMoveCommandChanged(DependencyObject d,
			DependencyPropertyChangedEventArgs e)
		{
			FrameworkElement ele = d as FrameworkElement;
			if (ele != null)
			{
				ele.MouseMove -= OnMouseMove;
				if (e.NewValue != null)
				{
					ele.MouseMove += OnMouseMove;
				}
			}
		}

		/// <summary>
		/// TheCommandToRun : The actual ICommand to run
		/// </summary>
		public static readonly DependencyProperty MouseMoveCommandProperty =
			DependencyProperty.RegisterAttached("MouseMoveCommand",
				typeof(ICommand),
				typeof(MouseMoveBehaviour),
				new PropertyMetadata((ICommand)null,
					new PropertyChangedCallback(OnHandleMoveMoveCommandChanged)));

		/// <summary>
		/// Gets the TheCommandToRun property. �
		/// </summary>
		public static ICommand GetMouseMoveCommand(DependencyObject d)
		{
			return (ICommand)d.GetValue(MouseMoveCommandProperty);
		}

		/// <summary>
		/// Sets the TheCommandToRun property. �
		/// </summary>
		public static void SetMouseMoveCommand(DependencyObject d, ICommand value)
		{
			d.SetValue(MouseMoveCommandProperty, value);
		}

		#region Handle the event

		/// <summary>
		/// Invoke the command we tagged.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void OnMouseMove(object sender, MouseEventArgs e)
		{
			FrameworkElement ele = sender as FrameworkElement;

			DependencyObject originalSender = e.OriginalSource as DependencyObject;
			if (ele == null || originalSender == null)
				return;

			ICommand command = (ICommand)(sender as DependencyObject).GetValue(MouseMoveCommandProperty);

			if (command != null)
			{
				if (command.CanExecute(e))
					command.Execute(e);
			}
		}
		#endregion
	}
}
