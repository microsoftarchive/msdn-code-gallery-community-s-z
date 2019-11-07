using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Tasks.Show.Controls
{
    public class EditableTextBlock : TextBox
    {
        private string m_mouseDownText;
        private bool m_isMouseDown;

        #region Constructors

        static EditableTextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EditableTextBlock), new FrameworkPropertyMetadata(typeof(EditableTextBlock)));
            IsReadOnlyProperty.OverrideMetadata(typeof(EditableTextBlock), new FrameworkPropertyMetadata(true));
            CursorProperty.OverrideMetadata(typeof(EditableTextBlock), new FrameworkPropertyMetadata(Cursors.Hand));
            TextProperty.OverrideMetadata(typeof(EditableTextBlock), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTextChanged)));
            //FocusableProperty.OverrideMetadata(typeof(EditableTextBlock), new FrameworkPropertyMetadata(false));
        }

        #endregion Constructors

        #region InfoText

        /// <summary>
        /// InfoText Dependency Property
        /// </summary>
        public static readonly DependencyProperty InfoTextProperty =
            DependencyProperty.Register("InfoText", typeof(string), typeof(EditableTextBlock),
                new FrameworkPropertyMetadata((string)"Click to edit"));

        /// <summary>
        /// Gets or sets the InfoText property.  This dependency property 
        /// indicates text that is displayed when the value of the Text 
        /// property is null or empty.
        /// </summary>
        public string InfoText
        {
            get { return (string)GetValue(InfoTextProperty); }
            set { SetValue(InfoTextProperty, value); }
        }

        #endregion

        #region IsInfoTextVisible

        /// <summary>
        /// IsInfoTextVisible Read-Only Dependency Property
        /// </summary>
        private static readonly DependencyPropertyKey IsInfoTextVisiblePropertyKey
            = DependencyProperty.RegisterReadOnly("IsInfoTextVisible", typeof(bool), typeof(EditableTextBlock),
                new FrameworkPropertyMetadata((bool)true));

        public static readonly DependencyProperty IsInfoTextVisibleProperty
            = IsInfoTextVisiblePropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the IsInfoTextVisible property.  This dependency property 
        /// indicates whether the InfoText is currently visible.
        /// </summary>
        public bool IsInfoTextVisible
        {
            get { return (bool)GetValue(IsInfoTextVisibleProperty); }
        }

        /// <summary>
        /// Provides a secure method for setting the IsInfoTextVisible property.  
        /// This dependency property indicates whether the InfoText is currently visible.
        /// </summary>
        /// <param name="value">The new value for the property.</param>
        protected void SetIsInfoTextVisible(bool value)
        {
            SetValue(IsInfoTextVisiblePropertyKey, value);
        }

        #endregion

        #region MouseOverBackground

        /// <summary>
        /// MouseOverBackground Dependency Property
        /// </summary>
        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(EditableTextBlock),
                new FrameworkPropertyMetadata((Brush)Brushes.Yellow));

        /// <summary>
        /// Gets or sets the MouseOverBackground property.  This dependency property 
        /// indicates the color used to highlight the background on MouseOver.
        /// </summary>
        public Brush MouseOverBackground
        {
            get { return (Brush)GetValue(MouseOverBackgroundProperty); }
            set { SetValue(MouseOverBackgroundProperty, value); }
        }

        #endregion

        #region Text (Change Callback)

        /// <summary>
        /// Handles changes to the Text property.
        /// </summary>
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((EditableTextBlock)d).OnTextChanged(e);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the Text property.
        /// </summary>
        protected virtual void OnTextChanged(DependencyPropertyChangedEventArgs e)
        {
            string s = e.NewValue as string;
            if (String.IsNullOrEmpty(s))
            {
                this.SetIsInfoTextVisible(true);
            }
            else
            {
                this.SetIsInfoTextVisible(false);
            }
        }

        #endregion

        #region Overrides

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            m_isMouseDown = true;
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            m_isMouseDown = false;
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            if (m_isMouseDown && this.IsReadOnly)
            {
                m_mouseDownText = this.Text;
                m_isMouseDown = false;

                Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate(object arg)
                {
                    this.Focusable = true;
                    this.IsEnabled = true;
                    this.IsReadOnly = false;
                    this.Cursor = Cursors.IBeam;
                    this.SelectAll();
                    return null;
                }, null);
            }

            base.OnMouseUp(e);
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape && this.IsFocused)
            {
                this.Text = m_mouseDownText;

                this.SelectionLength = 0;
                this.IsReadOnly = true;
                this.Cursor = Cursors.Hand;
                this.IsEnabled = false;

            }
            else if (e.Key == Key.Enter && this.IsFocused)
            {
                this.SelectionLength = 0;
                this.IsReadOnly = true;
                this.Cursor = Cursors.Hand;
                this.IsEnabled = false;
            }

            this.IsEnabled = true;
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);

            this.IsReadOnly = true;
            this.Cursor = Cursors.Hand;
        }

        #endregion
    }
}
