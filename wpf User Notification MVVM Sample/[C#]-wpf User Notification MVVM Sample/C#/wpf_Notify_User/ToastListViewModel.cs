using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Media.Animation;
using System.Diagnostics;

namespace wpf_Notify_User
{
    public class ToastListViewModel : ViewModelBase
    {
        public ObservableCollection<Message4ListBox> Messages { get; set; }
        public ToastListViewModel()
        {
            Messages = new ObservableCollection<Message4ListBox>();
            Messenger.Default.Register<UserNotificationMessage>(this, (action)=>AddMessage(action));
        }
        private async void AddMessage(UserNotificationMessage msg)
        {
            Message4ListBox message4ListBox = new Message4ListBox { Msg = msg.Message, IsGoing = false };
            Messages.Insert(0, message4ListBox);
            await Task.Delay(new TimeSpan(0, 0, msg.SecondsToShow));
            // You can't animate on removal event since there's nothing there to animate.
            // Therefore, a datatrigger is used to drive the removal animation.
            message4ListBox.IsGoing = true;
            await Task.Delay(new TimeSpan(0,0,0,1,300));
            Messages.Remove(message4ListBox);
        }
    }
    public class Message4ListBox : ViewModelBase
    {
        public String Msg { get; set; }
        private bool isGoing;

        public bool IsGoing
        {
            get { return isGoing; }
            set 
            { 
                isGoing = value;
                RaisePropertyChanged();
            }
        }
    }
}
