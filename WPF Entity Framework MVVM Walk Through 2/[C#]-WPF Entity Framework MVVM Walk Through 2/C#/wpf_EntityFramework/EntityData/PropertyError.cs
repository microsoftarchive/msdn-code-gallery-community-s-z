using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Support;

namespace wpf_EntityFramework
{
    public class PropertyError : NotifyUIBase
    {
        private string propertyName;
        public string PropertyName
        {
            get
            {
                return propertyName;
            }
            set
            {
                propertyName = value;
                RaisePropertyChanged();
            }
        }
        private string error;
        public string Error
        {
            get
            {
                return error;
            }
            set
            {
                error = value;
                RaisePropertyChanged();
            }
        }
        private bool added;
        public bool Added
        {
            get
            {
                return added;
            }
            set
            {
                added = value;
                RaisePropertyChanged();
            }
        }
        
        
        
    }
}
