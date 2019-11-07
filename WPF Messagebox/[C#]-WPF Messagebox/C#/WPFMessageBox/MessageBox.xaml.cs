using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace WPFMessageBox
{
  /// <summary>
  /// Interaction logic for MessageBox.xaml
  /// </summary>
  public partial class MessageBox : INotifyPropertyChanged
  {
    private bool _animationRan;

    public MessageBox(Window owner, string message, string details, MessageBoxButton button, MessageBoxImage icon,
                      MessageBoxResult defaultResult, MessageBoxOptions options)
    {
      _animationRan = false;

      InitializeComponent();

      Owner = owner ?? Application.Current.MainWindow;

      CreateButtons(button, defaultResult);

      CreateImage(icon);

      MessageText.Text = message;

      DetailsExpander.Visibility = string.IsNullOrEmpty(details) ? Visibility.Collapsed : Visibility.Visible;

      DetailsText.Text = details;

      ApplyOptions(options);
    }

    public MessageBoxResult MessageBoxResult { get; set; }

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

    #region Create Buttons

    /// <summary>
    /// Create the message box's button according to the user's demand
    /// </summary>
    /// <param name="button">The user's buttons selection</param>
    /// <param name="defaultResult">The default button</param>
    private void CreateButtons(MessageBoxButton button, MessageBoxResult defaultResult)
    {
      switch (button)
      {
        case MessageBoxButton.OK:
          ButtonsPanel.Children.Add(CreateOkButton(defaultResult));
          break;
        case MessageBoxButton.OKCancel:
          ButtonsPanel.Children.Add(CreateOkButton(defaultResult));
          ButtonsPanel.Children.Add(CreateCancelButton(defaultResult));
          break;
        case MessageBoxButton.YesNoCancel:
          ButtonsPanel.Children.Add(CreateYesButton(defaultResult));
          ButtonsPanel.Children.Add(CreateNoButton(defaultResult));
          ButtonsPanel.Children.Add(CreateCancelButton(defaultResult));
          break;
        case MessageBoxButton.YesNo:
          ButtonsPanel.Children.Add(CreateYesButton(defaultResult));
          ButtonsPanel.Children.Add(CreateNoButton(defaultResult));
          break;
        default:
          throw new ArgumentOutOfRangeException("button");
      }
    }

    /// <summary>
    /// Create the ok button on demand
    /// </summary>
    /// <param name="defaultResult"></param>
    /// <returns></returns>
    private Button CreateOkButton(MessageBoxResult defaultResult)
    {
      var okButton = new Button
                       {
                         Name = "okButton",
                         Content = "OK",
                         IsDefault = defaultResult == MessageBoxResult.OK,
                         Tag = MessageBoxResult.OK,
                       };

      okButton.Click += ButtonClick;

      return okButton;
    }

    /// <summary>
    /// Create the cancel button on demand
    /// </summary>
    /// <param name="defaultResult"></param>
    /// <returns></returns>
    private Button CreateCancelButton(MessageBoxResult defaultResult)
    {
      var cancelButton = new Button
                           {
                             Name = "cancelButton",
                             Content = "Cancel",
                             IsDefault = defaultResult == MessageBoxResult.Cancel,
                             IsCancel = true,
                             Tag = MessageBoxResult.Cancel,
                           };

      cancelButton.Click += ButtonClick;

      return cancelButton;
    }

    /// <summary>
    /// Create the yes button on demand
    /// </summary>
    /// <param name="defaultResult"></param>
    /// <returns></returns>
    private Button CreateYesButton(MessageBoxResult defaultResult)
    {
      var yesButton = new Button
                        {
                          Name = "yesButton",
                          Content = "Yes",
                          IsDefault = defaultResult == MessageBoxResult.Yes,
                          Tag = MessageBoxResult.Yes,
                        };

      yesButton.Click += ButtonClick;

      return yesButton;
    }

    /// <summary>
    /// Create the no button on demand
    /// </summary>
    /// <param name="defaultResult"></param>
    /// <returns></returns>
    private Button CreateNoButton(MessageBoxResult defaultResult)
    {
      var noButton = new Button
                       {
                         Name = "noButton",
                         Content = "No",
                         IsDefault = defaultResult == MessageBoxResult.No,
                         Tag = MessageBoxResult.No,
                       };

      noButton.Click += ButtonClick;

      return noButton;
    }

    /// <summary>
    /// The event the buttons trigger. 
    /// Each button hold it's result in the tag, so here it just sets them and close the message box.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonClick(object sender, RoutedEventArgs e)
    {
      MessageBoxResult = (MessageBoxResult) (sender as Button).Tag;

      Close();
    }

    #endregion

    private void ApplyOptions(MessageBoxOptions options)
    {
      if ((options & MessageBoxOptions.RightAlign) == MessageBoxOptions.RightAlign)
      {
        MessageText.TextAlignment = TextAlignment.Right;
        DetailsText.TextAlignment = TextAlignment.Right;
      }
      if ((options & MessageBoxOptions.RtlReading) == MessageBoxOptions.RtlReading)
      {
        FlowDirection = FlowDirection.RightToLeft;
      }
    }

    /// <summary>
    /// Create the image from the system's icons
    /// </summary>
    /// <param name="icon"></param>
    private void CreateImage(MessageBoxImage icon)
    {
      switch (icon)
      {
        case MessageBoxImage.None:
          ImagePlaceholder.Visibility = Visibility.Collapsed;
          break;
        case MessageBoxImage.Information:
          ImagePlaceholder.Source = SystemIcons.Information.ToImageSource();
          break;
        case MessageBoxImage.Question:
          ImagePlaceholder.Source = SystemIcons.Question.ToImageSource();
          break;
        case MessageBoxImage.Warning:
          ImagePlaceholder.Source = SystemIcons.Warning.ToImageSource();
          break;
        case MessageBoxImage.Error:
          ImagePlaceholder.Source = SystemIcons.Error.ToImageSource();
          break;
        default:
          throw new ArgumentOutOfRangeException("icon");
      }
    }

    public void OnPropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler temp = PropertyChanged;
      if (temp != null)
      {
        temp(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    /// <summary>
    /// Enable dragging
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
      DragMove();
    }

    /// <summary>
    /// Show the startup animation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      // This is set here to height after the width has been set 
      // so the details expander won't stretch the message box when it's opened
      SizeToContent = SizeToContent.Height;

      var animation = TryFindResource("LoadAnimation") as Storyboard;

      animation.Begin(this);
    }

    /// <summary>
    /// Show the closing animation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MessageBoxWindow_Closing(object sender, CancelEventArgs e)
    {
      if (!_animationRan)
      {
        // The animation won't run if the window is allowed to close, 
        // so here the animation starts, and the window's closing is canceled
        e.Cancel = true;

        var animation = TryFindResource("UnloadAnimation") as Storyboard;

        animation.Completed += AnimationCompleted;

        animation.Begin(this);
      }
    }

    /// <summary>
    /// Signals the closing animation ran, and close the window (for real this time)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AnimationCompleted(object sender, EventArgs e)
    {
      _animationRan = true;

      Close();
    }

    #region Show Information

    /// <summary>
    /// Display an information message
    /// </summary>
    /// <param name="message">The message text</param>
    /// <param name="details">The details part text</param>
    /// <param name="showCancel">Display the cancel</param>
    /// <param name="options">Misc options</param>
    /// <returns>The user's selected button</returns>
    public static MessageBoxResult ShowInformation(string message, string details = "", bool showCancel = false,
                                                   MessageBoxOptions options = MessageBoxOptions.None)
    {
      return ShowInformation(null, message, details, showCancel, options);
    }

    /// <summary>
    /// Display an information message
    /// </summary>
    /// <param name="owner">The message box's parent window</param>
    /// <param name="message">The message text</param>
    /// <param name="details">The details part text</param>
    /// <param name="showCancel">Display the cancel</param>
    /// <param name="options">Misc options</param>
    /// <returns>The user's selected button</returns>
    public static MessageBoxResult ShowInformation(Window owner, string message, string details = "",
                                                   bool showCancel = false,
                                                   MessageBoxOptions options = MessageBoxOptions.None)
    {
      return Show(owner, message, details, showCancel ? MessageBoxButton.OKCancel : MessageBoxButton.OK,
                  MessageBoxImage.Information, MessageBoxResult.OK, options);
    }

    #endregion

    #region Show Question

    /// <summary>
    /// Display a question
    /// </summary>
    /// <param name="message">The message text</param>
    /// <param name="details">The details part text</param>
    /// <param name="showCancel">Display the cancel</param>
    /// <param name="options">Misc options</param>
    /// <returns>The user's selected button</returns>
    public static MessageBoxResult ShowQuestion(string message, string details = "",
                                                bool showCancel = false,
                                                MessageBoxOptions options = MessageBoxOptions.None)
    {
      return ShowQuestion(null, message, details, showCancel, options);
    }

    /// <summary>
    /// Display a question
    /// </summary>
    /// <param name="owner">The message box's parent window</param>
    /// <param name="message">The message text</param>
    /// <param name="details">The details part text</param>
    /// <param name="showCancel">Display the cancel</param>
    /// <param name="options">Misc options</param>
    /// <returns>The user's selected button</returns>
    public static MessageBoxResult ShowQuestion(Window owner, string message, string details = "",
                                                bool showCancel = false,
                                                MessageBoxOptions options = MessageBoxOptions.None)
    {
      return Show(owner, message, details, showCancel ? MessageBoxButton.YesNoCancel : MessageBoxButton.YesNo,
                  MessageBoxImage.Question, MessageBoxResult.Yes, options);
    }

    #endregion

    #region Show Warning

    /// <summary>
    /// Display a warning
    /// </summary>
    /// <param name="message">The message text</param>
    /// <param name="details">The details part text</param>
    /// <param name="showCancel">Display the cancel</param>
    /// <param name="options">Misc options</param>
    /// <returns>The user's selected button</returns>
    public static MessageBoxResult ShowWarning(string message, string details = "",
                                               bool showCancel = false,
                                               MessageBoxOptions options = MessageBoxOptions.None)
    {
      return ShowWarning(null, message, details, showCancel, options);
    }

    /// <summary>
    /// Display a warning
    /// </summary>
    /// <param name="owner">The message box's parent window</param>
    /// <param name="message">The message text</param>
    /// <param name="details">The details part text</param>
    /// <param name="showCancel">Display the cancel</param>
    /// <param name="options">Misc options</param>
    /// <returns>The user's selected button</returns>
    public static MessageBoxResult ShowWarning(Window owner, string message, string details = "",
                                               bool showCancel = false,
                                               MessageBoxOptions options = MessageBoxOptions.None)
    {
      return Show(owner, message, details, showCancel ? MessageBoxButton.OKCancel : MessageBoxButton.OK,
                  MessageBoxImage.Warning, MessageBoxResult.OK, options);
    }

    #endregion

    #region Show Error

    /// <summary>
    /// Display an Error
    /// </summary>
    /// <param name="exception">Display the exception's details</param>
    /// <param name="message">The message text</param>
    /// <param name="options">Misc options</param>
    /// <returns>The user's selected button</returns>
    public static MessageBoxResult ShowError(Exception exception, string message = "",
                                             MessageBoxOptions options = MessageBoxOptions.None)
    {
      return ShowError(null, exception, message, options);
    }

    /// <summary>
    /// Display an Error
    /// </summary>
    /// <param name="message">The message text</param>
    /// <param name="details">The details part text</param>
    /// <param name="showCancel">Display the cancel</param>
    /// <param name="options">Misc options</param>
    /// <returns>The user's selected button</returns>
    public static MessageBoxResult ShowError(string message, string details = "",
                                             bool showCancel = false,
                                             MessageBoxOptions options = MessageBoxOptions.None)
    {
      return ShowError(null, message, details, showCancel, options);
    }

    /// <summary>
    /// Display an Error
    /// </summary>
    /// <param name="owner">The message box's parent window</param>
    /// <param name="exception">Display the exception's details</param>
    /// <param name="message">The message text</param>
    /// <param name="options">Misc options</param>
    /// <returns>The user's selected button</returns>
    public static MessageBoxResult ShowError(Window owner, Exception exception, string message = "",
                                             MessageBoxOptions options = MessageBoxOptions.None)
    {
      string details = string.Empty;

#if DEBUG
      details = exception.ToString();
#endif

      return Show(owner, String.IsNullOrEmpty(message) ? exception.Message : message, details, MessageBoxButton.OK,
                  MessageBoxImage.Error, MessageBoxResult.OK, options);
    }

    /// <summary>
    /// Display an Error
    /// </summary>
    /// <param name="owner">The message box's parent window</param>
    /// <param name="message">The message text</param>
    /// <param name="details">The details part text</param>
    /// <param name="showCancel">Display the cancel</param>
    /// <param name="options">Misc options</param>
    /// <returns>The user's selected button</returns>
    public static MessageBoxResult ShowError(Window owner, string message, string details = "",
                                             bool showCancel = false,
                                             MessageBoxOptions options = MessageBoxOptions.None)
    {
      return Show(owner, message, details, showCancel ? MessageBoxButton.OKCancel : MessageBoxButton.OK,
                  MessageBoxImage.Error, MessageBoxResult.OK, options);
    }

    #endregion

    #region Show

    /// <summary>
    /// Show the message box with the specified parameters
    /// </summary>
    /// <param name="message">The message text</param>
    /// <param name="details">The details part text</param>
    /// <param name="button">The buttons to be displayed</param>
    /// <param name="icon">The message's severity</param>
    /// <param name="defaultResult">The default button</param>
    /// <param name="options">Misc options</param>
    /// <returns>The user's selected button</returns>
    public static MessageBoxResult Show(string message, string details = "",
                                        MessageBoxButton button = MessageBoxButton.OK,
                                        MessageBoxImage icon = MessageBoxImage.None,
                                        MessageBoxResult defaultResult = MessageBoxResult.None,
                                        MessageBoxOptions options = MessageBoxOptions.None)
    {
      return Show(null, message, details, button, icon, defaultResult, options);
    }

    /// <summary>
    /// Show the message box with the specified parameters
    /// </summary>
    /// <param name="message">The message text</param>
    /// <param name="button">The buttons to be displayed</param>
    /// <param name="icon">The message's severity</param>
    /// <param name="defaultResult">The default button</param>
    /// <param name="options">Misc options</param>
    /// <returns>The user's selected button</returns>
    public static MessageBoxResult Show(string message,
                                        MessageBoxButton button = MessageBoxButton.OK,
                                        MessageBoxImage icon = MessageBoxImage.None,
                                        MessageBoxResult defaultResult = MessageBoxResult.None,
                                        MessageBoxOptions options = MessageBoxOptions.None)
    {
      return Show(message, string.Empty, button, icon, defaultResult, options);
    }

    /// <summary>
    /// Show the message box with the specified parameters
    /// </summary>
    /// <param name="owner">The message box's parent window</param>
    /// <param name="message">The message text</param>
    /// <param name="button">The buttons to be displayed</param>
    /// <param name="icon">The message's severity</param>
    /// <param name="defaultResult">The default button</param>
    /// <param name="options">Misc options</param>
    /// <returns>The user's selected button</returns>
    public static MessageBoxResult Show(Window owner, string message,
                                        MessageBoxButton button = MessageBoxButton.OK,
                                        MessageBoxImage icon = MessageBoxImage.None,
                                        MessageBoxResult defaultResult = MessageBoxResult.None,
                                        MessageBoxOptions options = MessageBoxOptions.None)
    {
      return Show(owner, message, string.Empty, button, icon, defaultResult, options);
    }

    /// <summary>
    /// Show the message box with the specified parameters
    /// </summary>
    /// <param name="owner">The message box's parent window</param>
    /// <param name="message">The message text</param>
    /// <param name="details">The details part text</param>
    /// <param name="button">The buttons to be displayed</param>
    /// <param name="icon">The message's severity</param>
    /// <param name="defaultResult">The default button</param>
    /// <param name="options">Misc options</param>
    /// <returns>The user's selected button</returns>
    public static MessageBoxResult Show(Window owner, string message, string details = "",
                                        MessageBoxButton button = MessageBoxButton.OK,
                                        MessageBoxImage icon = MessageBoxImage.None,
                                        MessageBoxResult defaultResult = MessageBoxResult.None,
                                        MessageBoxOptions options = MessageBoxOptions.None)
    {
      var result = Application.Current.Dispatcher.Invoke(new Func<MessageBoxResult>(() =>
      {
        var messageBox = new MessageBox(owner, message, details, button, icon, defaultResult, options);

        messageBox.ShowDialog();

        return messageBox.MessageBoxResult;
      }));

      return result is MessageBoxResult ? (MessageBoxResult)result : MessageBoxResult.None;
    }

    #endregion
  }
}