using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SKYPE4COMLib;
using SkypeIntegration.Model;

namespace SkypeIntegration.ViewModel
{
    public class SkypeViewModel : INotifyPropertyChanged
    {

        private List<Friend> friends;
        private Friend selectedFriend;
        private static SkypeViewModel _skypeViewModel;

        public List<Friend> Friends
        {
            get { return friends; }
            set
            {
                friends = value;
                OnPropertyChanged("Friends");
            }
        }

        public Friend SelectedFriend
        {
            get { return selectedFriend; }
            set
            {
                selectedFriend = value;
                OnPropertyChanged("SelectedFriend");
            }
        }

        public Skype Skype
        {
            get;
            set;
        }

        public RelayCommand ChatCommand
        {
            get;
            set;
        }

        public RelayCommand SyncCommand
        {
            get;
            set;
        }

        private SkypeViewModel()
        {
            Skype = new SKYPE4COMLib.Skype();
            Skype.Attach(7, false);
            this.ChatCommand = new RelayCommand(StartChat);
            this.SyncCommand = new RelayCommand(Sync);

            if (Skype.Client.IsRunning)
            {
                this.Friends = GetFriends();              
            }
            else
            {
                System.Windows.MessageBox.Show("Since Skype Client is not running the application will start the Skype Client. Please use SYNC Button to get all the contact once you logged in into skype client", "Application Requirement", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                Skype.Client.Start();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static SkypeViewModel SharedSkypeViewModel()
        {
            return _skypeViewModel ?? (_skypeViewModel = new SkypeViewModel());
        }

        public List<Friend> GetFriends()
        {
            var friends = new List<Friend>();
            var users = Skype.Friends.OfType<SKYPE4COMLib.User>();
            if (!Directory.Exists(@"C:\Skype\Images\"))
            {
                Directory.CreateDirectory(@"C:\Skype\Images\");
            }
            foreach (var user in users)
            {
                var avatarSavePath = @"C:\Skype\Images\" + user.Handle + ".jpg";
                SaveSkypeAvatarToDisk(user.Handle, avatarSavePath);
                friends.Add(new Friend { About = user.About, Aliases = user.Aliases, Birthday = user.Birthday, City = user.City, Country = user.Country, DisplayName = user.DisplayName, FullName = user.FullName, Handle = user.Handle, MoodText = user.MoodText, NumberOfAuthBuddies = user.NumberOfAuthBuddies, OnlineStatus = user.OnlineStatus, RichMoodText = user.RichMoodText, Sex = user.Sex, ProfilePicture = new ProfilePicture { UserName = user.Handle, ProfilePicturePath = avatarSavePath } });
            }
            return friends;
        }

        void SaveSkypeAvatarToDisk(string userHandle, string rootedPathFileName)
        {
            if (!System.IO.Path.IsPathRooted(rootedPathFileName))
                throw new ArgumentException("Filename does not contain full path!", "rootedPathFileName");

            if (!".jpg".Equals(System.IO.Path.GetExtension(rootedPathFileName)))
                throw new ArgumentException("Filename does not represent jpg file!", "rootedPathFileName");

            SKYPE4COMLib.Command command0 = new SKYPE4COMLib.Command();
            command0.Command = string.Format("GET USER {0} Avatar 1 {1}", userHandle, rootedPathFileName);
            Skype.SendCommand(command0);
        }

        public List<string> GetSkypeAvatarFromDisk(string userHandle, string rootedPathFileName)
        {
            var profilePictureFiles = System.IO.Directory.GetFiles(@"C:\Skype\Images").ToList();
            return profilePictureFiles;
        }

        public void StartChat(object parameter)
        {
            if (SelectedFriend != null)
            {
                if (Skype.Client.IsRunning) Skype.Client.OpenMessageDialog(SelectedFriend.Handle, "Hi");
            }
        }

        public void Sync(object parameter)
        {
            if (Skype.Client.IsRunning)
            {
                this.Friends = GetFriends();
            }

            else
            {
                System.Windows.MessageBox.Show("Skype Client not running", "Application Requirement", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
        }
    }
}
