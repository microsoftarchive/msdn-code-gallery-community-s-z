using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UserInput
{
    public class ConfirmationRequestor: Control, ICommandSource
    {
        public bool? ShowConfirmDialog
        {
            get 
            {
                return (bool?)GetValue(ShowConfirmDialogProperty);
            }
            set 
            {
                SetValue(ShowConfirmDialogProperty, value);
            }
        }
        public static readonly DependencyProperty ShowConfirmDialogProperty = 
            DependencyProperty.Register("ShowConfirmDialog", 
                        typeof(bool?), 
                        typeof(ConfirmationRequestor), 
                        new PropertyMetadata(null, new PropertyChangedCallback(ConfirmDialogChanged)));
        public MessageBoxButton MsgBoxButton
        {
            get { return (MessageBoxButton)GetValue(MsgBoxButtonProperty); }
            set { SetValue(MsgBoxButtonProperty, value); }
        }
        public static readonly DependencyProperty MsgBoxButtonProperty =
            DependencyProperty.Register("MsgBoxButton", 
                               typeof(MessageBoxButton), 
                               typeof(ConfirmationRequestor), 
                               new PropertyMetadata(MessageBoxButton.OK));
        public MessageBoxImage MsgBoxImage
        {
            get { return (MessageBoxImage)GetValue(MsgBoxImageProperty); }
            set { SetValue(MsgBoxImageProperty, value); }
        }
        public static readonly DependencyProperty MsgBoxImageProperty =
            DependencyProperty.Register("MsgBoxImage", 
                               typeof(MessageBoxImage), 
                               typeof(ConfirmationRequestor), 
                               new PropertyMetadata(MessageBoxImage.Warning));
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", 
            typeof(string), 
            typeof(ConfirmationRequestor), 
            new PropertyMetadata(string.Empty));
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", 
            typeof(string), 
            typeof(ConfirmationRequestor), 
            new PropertyMetadata(string.Empty));
     
        

        private static void ConfirmDialogChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool?)e.NewValue != true)
            {
                return;
            }
            ConfirmationRequestor cr = (ConfirmationRequestor)d;
            Window parent = Window.GetWindow(cr) as Window;
            MessageBoxResult result = MessageBox.Show(parent, cr.Message, cr.Caption, cr.MsgBoxButton, cr.MsgBoxImage);
            if (result == MessageBoxResult.OK || result == MessageBoxResult.Yes)
            {
                if (cr.Command != null)
                {
                    cr.Command.Execute(cr.CommandParameter);
                }
            }

            cr.SetValue(ShowConfirmDialogProperty, null);
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(ConfirmationRequestor), new UIPropertyMetadata(null));
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(ConfirmationRequestor), new UIPropertyMetadata(null));
        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(ConfirmationRequestor), new UIPropertyMetadata(null));

        public ConfirmationRequestor()
        {

        }

    }
}
