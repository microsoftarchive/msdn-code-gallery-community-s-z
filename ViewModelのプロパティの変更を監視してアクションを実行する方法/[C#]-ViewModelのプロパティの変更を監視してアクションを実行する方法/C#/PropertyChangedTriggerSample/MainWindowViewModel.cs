using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PropertyChangedTriggerSample.Commons;

namespace PropertyChangedTriggerSample
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool isError;

        public bool IsError
        {
            get
            {
                return this.isError;
            }

            set
            {
                this.isError = value;
                this.RaisePropertyChanged("IsError");
            }
        }
    }
}
