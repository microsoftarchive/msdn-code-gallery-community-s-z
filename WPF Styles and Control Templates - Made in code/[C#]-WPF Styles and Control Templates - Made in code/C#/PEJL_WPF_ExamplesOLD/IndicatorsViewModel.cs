using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PEJL_WPF_Examples
{
    public class IndicatorsViewModel : INotifyPropertyChanged
    {
        bool _IsOverColumnHeader;
        public bool IsOverColumnHeader
        {
            get
            {
                return _IsOverColumnHeader;
            }
            set
            {
                if (_IsOverColumnHeader != value)
                {
                    _IsOverColumnHeader = value;
                    RaisePropertyChanged("IsOverColumnHeader");
                }
            }
        }

        string _OverColumnName;
        public string OverColumnName
        {
            get
            {
                return _OverColumnName;
            }
            set
            {
                if (_OverColumnName != value)
                {
                    _OverColumnName = value;
                    RaisePropertyChanged("OverColumnName");
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
