using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkypeIntegration.Model
{
    public class ProfilePicture : INotifyPropertyChanged
    {
        private string userName;
        private string profilePicturePath;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string ProfilePicturePath
        {
            get { return profilePicturePath; }
            set
            {
                profilePicturePath = value;
                OnPropertyChanged("ProfilePicturePath");
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
