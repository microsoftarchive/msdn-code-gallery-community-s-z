using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows;
using System.Diagnostics;


namespace Tasks.Show.Controls
{
    public class DragSelector : Selector
    {
		#region Fields 

        Point? downPoint = null;

		#endregion Fields 

		#region Constructors 

        public DragSelector()
        {
            CommandBindings.Add(new CommandBinding(NextCommand, new ExecutedRoutedEventHandler(NextCommandExecuted), new CanExecuteRoutedEventHandler(NextCommandCanExecute)));
            InputBindings.Add(new InputBinding(NextCommand, new KeyGesture(Key.Down, ModifierKeys.None)));

            CommandBindings.Add(new CommandBinding(PreviousCommand, new ExecutedRoutedEventHandler(PreviousCommandExecuted), new CanExecuteRoutedEventHandler(PreviousCommandCanExecute)));
            InputBindings.Add(new InputBinding(PreviousCommand, new KeyGesture(Key.Up, ModifierKeys.None)));
        }

		#endregion Constructors 

		#region Public Methods 

        public void Next()
        {
            if (this.Items == null || this.Items.Count == 0 || this.Items.Count == 1) return;

            if (this.SelectedIndex < this.Items.Count - 1)
            {
                this.SelectedIndex++;
            }
            else
            {
                this.SelectedIndex = 0;
            }
        }

        public void Previous()
        {
            if (this.Items == null || this.Items.Count == 0 || this.Items.Count == 1) return;

            if (this.SelectedIndex > 0)
            {
                this.SelectedIndex--;
            }
            else
            {
                this.SelectedIndex = this.Items.Count - 1;
            }
        }

		#endregion Public Methods 

		#region Protected Methods 

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            if (this.Focusable)
            {
                this.Focus();
            }

            bool cap = Mouse.Capture(this, CaptureMode.SubTree);
            downPoint = e.GetPosition(this);
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (downPoint != null)
            {
                Point dragPoint = e.GetPosition(this);

                if (dragPoint.Y > downPoint.Value.Y)
                {
                    this.SetIsDraggingUp(true);
                    this.SetIsDraggingDown(false);
                }
                else
                {
                    this.SetIsDraggingUp(false);
                    this.SetIsDraggingDown(true);
                }

                if (dragPoint.Y - downPoint.Value.Y > this.DragThreshold)
                {
                    downPoint = dragPoint;
                    Next();

                }

                else if (dragPoint.Y - downPoint.Value.Y < (this.DragThreshold * -1))
                {
                    downPoint = dragPoint;
                    Previous();
                }
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            this.ReleaseMouseCapture();
            downPoint = null;

            base.OnMouseUp(e);
        }

		#endregion Protected Methods 

        #region NextCommand

        // Add this to the the class constructor

        static RoutedCommand _NextCommand = new RoutedCommand("NextCommand", typeof(DragSelector));
        public static RoutedCommand NextCommand
        {
            get { return _NextCommand; }
        }

        void NextCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Next(); 
        }

        void NextCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.Items != null && this.Items.Count > 1 && this.IsEnabled) e.CanExecute = true;
        }

        #endregion

        #region PreviousCommand

        // Add this to the the class constructor

        static RoutedCommand _PreviousCommand = new RoutedCommand("PreviousCommand", typeof(DragSelector));
        public static RoutedCommand PreviousCommand
        {
            get { return _PreviousCommand; }
        }

        void PreviousCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Previous();
        }

        void PreviousCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.Items != null && this.Items.Count > 1 && this.IsEnabled) e.CanExecute = true;
        }

        #endregion

        #region DragThreshold

        public static readonly DependencyProperty DragThresholdProperty =
            DependencyProperty.Register("DragThreshold", typeof(double), typeof(DragSelector),
                new FrameworkPropertyMetadata((double)40.0));

        public double DragThreshold
        {
            get { return (double)GetValue(DragThresholdProperty); }
            set { SetValue(DragThresholdProperty, value); }
        }

        #endregion

        #region IsDraggingUp

        private static readonly DependencyPropertyKey IsDraggingUpPropertyKey
            = DependencyProperty.RegisterReadOnly("IsDraggingUp", typeof(bool), typeof(DragSelector),
                new FrameworkPropertyMetadata((bool)false));

        public static readonly DependencyProperty IsDraggingUpProperty
            = IsDraggingUpPropertyKey.DependencyProperty;

        public bool IsDraggingUp
        {
            get { return (bool)GetValue(IsDraggingUpProperty); }
        }

        protected void SetIsDraggingUp(bool value)
        {
            SetValue(IsDraggingUpPropertyKey, value);
        }

        #endregion

        #region IsDraggingDown

        private static readonly DependencyPropertyKey IsDraggingDownPropertyKey
            = DependencyProperty.RegisterReadOnly("IsDraggingDown", typeof(bool), typeof(DragSelector),
                new FrameworkPropertyMetadata((bool)false));

        public static readonly DependencyProperty IsDraggingDownProperty
            = IsDraggingDownPropertyKey.DependencyProperty;

        public bool IsDraggingDown
        {
            get { return (bool)GetValue(IsDraggingDownProperty); }
        }

        protected void SetIsDraggingDown(bool value)
        {
            SetValue(IsDraggingDownPropertyKey, value);
        }

        #endregion
    }
}
