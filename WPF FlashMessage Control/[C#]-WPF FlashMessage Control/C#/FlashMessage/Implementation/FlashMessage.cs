using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace FlashMessage
{
    public class FlashMessage : Control
    {
        private DispatcherTimer fadeOutTimer;

        static FlashMessage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlashMessage), new FrameworkPropertyMetadata(typeof(FlashMessage)));
        }

        public FlashMessage()
        {
            this.fadeOutTimer = new DispatcherTimer();
            this.fadeOutTimer.Interval = this.FadeOutTime.TimeSpan;
            this.fadeOutTimer.Tick += this.FadeOutTimer_Tick;
            this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, CloseCommandHandler));
        }

        #region ContentDataTemplate
        public static DependencyProperty ContentDataTemplateProperty =
            DependencyProperty.Register("ContentDataTemplate", typeof(DataTemplate), typeof(FlashMessage));

        public DataTemplate ContentDataTemplate
        {
            get { return (DataTemplate)GetValue(ContentDataTemplateProperty); }
            set { SetValue(ContentDataTemplateProperty, value); }
        }
        #endregion

        #region FadesOutAutomatically
        public static DependencyProperty FadesOutAutomaticallyProperty =
            DependencyProperty.Register("FadesOutAutomatically", typeof(bool), typeof(FlashMessage), new PropertyMetadata(true));

        public bool FadesOutAutomatically
        {
            get { return (bool)GetValue(FadesOutAutomaticallyProperty); }
            set { SetValue(FadesOutAutomaticallyProperty, value); }
        }
        #endregion

        #region FadeOutTime
        public static DependencyProperty FadeOutTimeProperty =
            DependencyProperty.Register("FadeOutTime", typeof(Duration), typeof(FlashMessage),
            new PropertyMetadata(new Duration(TimeSpan.FromSeconds(10)), new PropertyChangedCallback(OnFadeOutTimeChanged)));

        public Duration FadeOutTime
        {
            get { return (Duration)GetValue(FadeOutTimeProperty); }
            set { SetValue(FadeOutTimeProperty, value); }
        }

        private static void OnFadeOutTimeChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ((FlashMessage)o).OnFadeOutTimeChanged();
        }

        private void OnFadeOutTimeChanged()
        {
            this.fadeOutTimer.Interval = this.FadeOutTime.TimeSpan;
            this.StopTimerIfRunning();
        }
        #endregion

        #region Message
        public static DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(FlashMessage), new PropertyMetadata(OnMessageChanged));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        private static void OnMessageChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ((FlashMessage)o).OnMessageChanged();
        }

        private void OnMessageChanged()
        {
            this.IsFlashMessageVisible = !string.IsNullOrEmpty(this.Message);
        }
        #endregion

        #region MessageType
        public static DependencyProperty MessageTypeProperty =
            DependencyProperty.Register("MessageType", typeof(MessageType), typeof(FlashMessage));

        public MessageType MessageType
        {
            get { return (MessageType)GetValue(MessageTypeProperty); }
            set { SetValue(MessageTypeProperty, value); }
        }
        #endregion

        #region Reset
        internal static DependencyProperty ResetProperty =
          DependencyProperty.Register("Reset", typeof(bool), typeof(FlashMessage), new PropertyMetadata(OnResetChanged));

        internal bool Reset
        {
            get { return (bool)GetValue(ResetProperty); }
            set { SetValue(ResetProperty, value); }
        }

        private static void OnResetChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ((FlashMessage)o).OnResetChanged();
        }

        private void OnResetChanged()
        {
            if (this.Reset)
            {
                this.Visibility = System.Windows.Visibility.Collapsed;
                this.Message = null;
            }
        }
        #endregion

        #region IsFlashMessageVisible
        internal static DependencyProperty IsFlashMessageVisibleProperty =
          DependencyProperty.Register("IsFlashMessageVisible", typeof(bool), typeof(FlashMessage), new PropertyMetadata(OnIsFlashMessageVisibleChanged));

        internal bool IsFlashMessageVisible
        {
            get { return (bool)GetValue(IsFlashMessageVisibleProperty); }
            set { SetValue(IsFlashMessageVisibleProperty, value); }
        }

        private static void OnIsFlashMessageVisibleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ((FlashMessage)o).OnIsFlashMessageVisibleChanged();
        }

        private void OnIsFlashMessageVisibleChanged()
        {
            if (this.IsFlashMessageVisible)
            {
                this.Visibility = System.Windows.Visibility.Visible;
                this.StartTimerIfAutomatically();
            }
            else
                this.StartFadeOutAnimation();
        }
        #endregion

        public void Hide()
        {
            this.StopTimerIfRunning();
            this.IsFlashMessageVisible = false;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this.ContentDataTemplate == null)
                this.ContentDataTemplate = (DataTemplate)this.FindResource("flashMessageTemplate");
        }

        private void FadeOutTimer_Tick(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Hide();
        }

        private void StopTimerIfRunning()
        {
            if (this.fadeOutTimer.IsEnabled)
                this.fadeOutTimer.Stop();
        }

        private void StartTimerIfAutomatically()
        {
            this.StopTimerIfRunning();
            if (this.FadesOutAutomatically)
                this.fadeOutTimer.Start();
        }

        private void StartFadeOutAnimation()
        {
            var storyBoard = (Storyboard)this.FindResource("fadeOutAnimation");
            if (storyBoard != null)
                storyBoard.Begin(this);
        }
    }
}
