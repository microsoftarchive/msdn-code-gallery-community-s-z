using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System.Diagnostics;
using UserInput;
using System.Windows;

namespace wpf_Notify_User
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string fadeMessage;
        public string FadeMessage
        {
            get { return fadeMessage; }
            set
            {
                fadeMessage = value;
                RaisePropertyChanged();
            }
        }
        private string flashMessage;
        public string FlashMessage
        {
            get { return flashMessage; }
            set
            {
                flashMessage = value;
                RaisePropertyChanged();
            }
        }
        private string rippleMessage;
        public string RippleMessage
        {
            get { return rippleMessage; }
            set
            {
                rippleMessage = value;
                RaisePropertyChanged();
            }
        }
        private string wipeMessage;

        public string WipeMessage
        {
            get { return wipeMessage; }
            set
            {
                wipeMessage = value;
                RaisePropertyChanged();
            }
        }
        private string marqueeMessage;

        public string MarqueeMessage
        {
            get { return marqueeMessage; }
            set
            {
                marqueeMessage = value;
                RaisePropertyChanged();
            }
        }
        private RelayCommand _flashCommand;
        public RelayCommand FlashCommand
        {
            get
            {
                return _flashCommand
                  ?? (_flashCommand = new RelayCommand(
                       () =>
                       {
                           FlashMessage = textBoxMsg;
                       }));
            }
        }
        private RelayCommand _fadeCommand;
        public RelayCommand FadeCommand
        {
            get
            {
                return _fadeCommand
                  ?? (_fadeCommand = new RelayCommand(
                       () =>
                       {
                           FadeMessage = textBoxMsg;
                       }));
            }
        }
        private RelayCommand _wipeCommand;
        public RelayCommand WipeCommand
        {
            get
            {
                return _wipeCommand
                  ?? (_wipeCommand = new RelayCommand(
                       () =>
                       {
                           WipeMessage = textBoxMsg;
                       }));
            }
        }
        private RelayCommand _rippleCommand;
        public RelayCommand RippleCommand
        {
            get
            {
                return _rippleCommand
                  ?? (_rippleCommand = new RelayCommand(
                       () =>
                       {
                           RippleMessage = textBoxMsg;
                       }));
            }
        }
        private RelayCommand  _toastCommand;
        public RelayCommand ToastCommand
        {
            get
            {
                return _toastCommand
                  ?? (_toastCommand = new RelayCommand(
                       ()=>
                    {
                        UserNotificationMessage msg = new UserNotificationMessage { Message = textBoxMsg, SecondsToShow = 5 };
                        Messenger.Default.Send<UserNotificationMessage>(msg);
                    }));
            }
        }
        private RelayCommand _marqueeCommand;
        public RelayCommand MarqueeCommand
        {
            get
            {
                return _marqueeCommand
                  ?? (_marqueeCommand = new RelayCommand(
                       () =>
                       {
                           MarqueeMessage = textBoxMsg;
                       }));
            }
        }

        private RelayCommand _confirmCommand;
        public RelayCommand ConfirmCommand
        {
            get
            {
                return _confirmCommand
                  ?? (_confirmCommand = new RelayCommand(
                       () =>
                       {
                           confirmer.Caption = "Please Confirm";
                           confirmer.Message = "Are you SURE you want to delete this record?";
                           confirmer.MsgBoxButton = MessageBoxButton.YesNo;
                           confirmer.MsgBoxImage = MessageBoxImage.Warning;
                           OkCommand = new RelayCommand(
                               () =>
                               {
                                   // You would do some actual deletion or something here
                                   UserNotificationMessage msg = new UserNotificationMessage { Message = "OK.\rDeleted it.\rYour data is consigned to oblivion.", SecondsToShow = 5 };
                                   Messenger.Default.Send<UserNotificationMessage>(msg);
                               });
                           RaisePropertyChanged("OkCommand");
                           showConfirmation = true;
                           RaisePropertyChanged("ShowConfirmation");
                       }));
            }
        }
        // The OK command fires when you choose yes or ok.
        // This isn't in ConfirmationRequestorVM because you might prefer to use some other icommand helper rather 
        // than mvvm light's relaycommand.
        public RelayCommand OkCommand { get; set; }

        private bool? showConfirmation;

        public bool? ShowConfirmation
        {
            get { return showConfirmation; }
            set 
            { 
                showConfirmation = value;
                RaisePropertyChanged();
            }
        }
        
        private string textBoxMsg = "I need to tell you something";

	    public string TextBoxMsg
	    {
		    get { return textBoxMsg;}
		    set 
               {
                    textBoxMsg = value;
                    RaisePropertyChanged();
               }
	    }
        // This vm just saves you defining 4 inpc properties of your own every time
        public ConfirmationRequestorVM confirmer { get; set; }
        public MainWindowViewModel()
        {
            confirmer = new ConfirmationRequestorVM();
        }

    }
}
