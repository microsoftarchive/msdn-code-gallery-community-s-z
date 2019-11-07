using System.ComponentModel;

namespace PEJL_WPF_Examples
{
    public class MyClass : INotifyPropertyChanged
    {
        string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        int _Score;
        public int Score
        {
            get
            {
                return _Score;
            }
            set
            {
                if (_Score != value)
                {
                    _Score = value;
                    RaisePropertyChanged("Score");
                }
            }
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
