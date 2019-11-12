using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxDrive.Model
{
   
    public class MenuMain : INotifyPropertyChanged
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _img_url;
        public string img_url
        {
            get { return _img_url; }
            set
            {
                if(_img_url!=value)
                {
                    _img_url = value;
                    OnPropertyChanged("img_url");
                }
            }
        }

        private string _link;
        public string link
        {
            get { return _link; }
            set
            {
                if(_link!=value)
                {
                    _link = value;
                    OnPropertyChanged("link");
                }
            }
        }
      
        
        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
