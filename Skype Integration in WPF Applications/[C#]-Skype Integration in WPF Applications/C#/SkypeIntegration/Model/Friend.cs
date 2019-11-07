using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SKYPE4COMLib; 

namespace SkypeIntegration.Model
{
    public class Friend : INotifyPropertyChanged
    {
        private string about;
        private string aliases;
        private DateTime birthday;
        private string city;
        private string country;
        private string displayName;
        private string fullName;
        private string handle;
        private string moodText;
        private int numberOfAuthBuddies;
        private TOnlineStatus onlineStatus;
        private ProfilePicture profilePicture;
        private string richMoodText;
        private TUserSex sex;

        public string About
        {
            get
            {
                return about;
            }
            set
            {
                about = value;
                OnPropertyChanged("About");
            }
        }

        public string Aliases
        {
            get
            {
                return aliases;
            }
            set
            {
                aliases = value;
                OnPropertyChanged("Aliases");
            }
        }

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
                OnPropertyChanged("Birthday");
            }
        }


        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }


        public string DisplayName
        {
            get
            {
                return displayName;
            }
            set
            {
                displayName = value;
                OnPropertyChanged("DisplayName");
            }
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        public string Handle
        {
            get
            {
                return handle;
            }
            set
            {
                handle = value;
                OnPropertyChanged("Handle");
            }
        }

        public string MoodText
        {
            get
            {
                return moodText;
            }
            set
            {
                moodText = value;
                OnPropertyChanged("MoodText");
            }
        }

        public int NumberOfAuthBuddies
        {
            get
            {
                return numberOfAuthBuddies;
            }
            set
            {
                numberOfAuthBuddies = value;
                OnPropertyChanged("NumberOfAuthBuddies");
            }
        }

        public TOnlineStatus OnlineStatus
        {
            get
            {
                return onlineStatus;
            }
            set
            {
                onlineStatus = value;
                OnPropertyChanged("OnlineStatus");
            }
        }

        public ProfilePicture ProfilePicture
        {
            get
            {
                return profilePicture;
            }
            set
            {
                profilePicture = value;
                OnPropertyChanged("ProfilePicture");
            }
        }

        public string RichMoodText
        {
            get
            {
                return richMoodText;
            }
            set
            {
                richMoodText = value;
                OnPropertyChanged("RichMoodText");
            }
        }

        public TUserSex Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
                OnPropertyChanged("Sex");
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
    }
}
