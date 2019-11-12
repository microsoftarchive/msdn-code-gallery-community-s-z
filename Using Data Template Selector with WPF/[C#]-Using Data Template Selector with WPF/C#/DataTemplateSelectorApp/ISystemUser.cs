using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DataTemplateSelectorApp
{
    public interface ISystemUser
    {
        String Name { get; set; }
        void Update();
        void Retrieve(int id);
    }

    public class Person : INotifyPropertyChanged, ISystemUser
    {
        private String _Name;
        public String Name { get { return _Name; } set { _Name = value; OnPropertyChanged("Name"); } }

        private String _Phone;
        public String Phone { get { return _Phone; } set { _Phone = value; OnPropertyChanged("Phone"); } }

        #region INotifyPropertyChanged Members

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region ISystemUser Members

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class Enterprise : INotifyPropertyChanged, ISystemUser
    {
        private String _Name;
        public String Name { get { return _Name; } set { _Name = value; OnPropertyChanged("Name"); } }

        private ObservableCollection<String> _Partners;
        public ObservableCollection<String> Partners { get { return _Partners; } set { _Partners = value; OnPropertyChanged("Partners"); } }

        private String _Phone;
        public String Phone { get { return _Phone; } set { _Phone = value; OnPropertyChanged("Phone"); } }

        private String _TalkTo;
        public String TalkTo { get { return _TalkTo; } set { _TalkTo = value; OnPropertyChanged("TalkTo"); } }


        public Enterprise()
        {
            this.Partners = new ObservableCollection<string>();
        }

        #region INotifyPropertyChanged Members

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region ISystemUser Members

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
