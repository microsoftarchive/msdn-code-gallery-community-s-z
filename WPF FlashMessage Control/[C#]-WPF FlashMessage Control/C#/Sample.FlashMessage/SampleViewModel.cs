using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using FlashMessage;

namespace Sample.FlashMessage
{
    public class SampleViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MessageType> messageTypes;
        private MessageType selectedMessageType;
        private string message;
        private string flashMessage;
        private bool fadesOutAutomatically;
        private RelayCommand showCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public SampleViewModel()
        {
            this.messageTypes =
                new ObservableCollection<MessageType>(
                new MessageType[] { MessageType.Error, MessageType.Notice, MessageType.Success });

            this.selectedMessageType = MessageType.Success;
        }

        public ObservableCollection<MessageType> MessageTypes
        {
            get { return this.messageTypes; }
            set
            {
                if (this.messageTypes == value)
                    return;

                this.messageTypes = value;
                this.OnPropertyChanged("MessageTypes");
            }
        }

        public MessageType SelectedMessageType
        {
            get { return this.selectedMessageType; }
            set
            {
                if (this.selectedMessageType == value)
                    return;

                this.selectedMessageType = value;
                this.OnPropertyChanged("SelectedMessageType");
            }
        }

        public string Message
        {
            get { return this.message; }
            set
            {
                if (this.message == value)
                    return;

                this.message = value;
                this.OnPropertyChanged("Message");
            }
        }

        public string FlashMessage
        {
            get { return this.flashMessage; }
            set
            {
                if (this.flashMessage == value)
                    return;

                this.flashMessage = value;
                this.OnPropertyChanged("FlashMessage");
            }
        }

        public bool FadesOutAutomatically
        {
            get { return this.fadesOutAutomatically; }
            set
            {
                if (this.fadesOutAutomatically == value)
                    return;

                this.fadesOutAutomatically = value;
                this.OnPropertyChanged("FadesOutAutomatically");
            }
        }

        public ICommand ShowCommand
        {
            get
            {
                if (this.showCommand == null)
                {
                    this.showCommand =
                        new RelayCommand(
                            param => this.Hit(),
                            param => this.CanHit);
                }
                return this.showCommand;
            }
        }

        private void Hit()
        {
            this.FlashMessage = this.Message;
        }

        private bool CanHit
        {
            get { return !string.IsNullOrEmpty(this.message); }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
