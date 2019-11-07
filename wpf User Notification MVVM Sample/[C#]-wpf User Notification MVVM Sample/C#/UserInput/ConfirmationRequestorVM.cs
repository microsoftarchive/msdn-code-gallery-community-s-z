using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UserInput
{
    public class ConfirmationRequestorVM : INotifyPropertyChanged
    {
        private string caption;
        public string Caption
        {
            get { return caption; }
            set 
            { 
                caption = value;
                NotifyPropertyChanged();
            }
        }
        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                NotifyPropertyChanged();
            }
        }

        private MessageBoxButton msgBoxButton;

        public MessageBoxButton MsgBoxButton
        {
            get { return msgBoxButton; }
            set 
            { 
                msgBoxButton = value;
                NotifyPropertyChanged();
            }
        }
        private MessageBoxImage msgBoxImage;

        public MessageBoxImage MsgBoxImage
        {
            get { return msgBoxImage; }
            set
            {
                msgBoxImage = value;
                NotifyPropertyChanged();
            }
        }     

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
