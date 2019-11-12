using Microsoft.Practices.Prism.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace BusyIndicatorExample
{
    public class BusyIndicatorManager : NotificationObject
    {
        #region Membervariables

        private Dictionary<int, string> busyParameters;

        #endregion

        #region Constructor

        private BusyIndicatorManager()
        {
            isBusy = false;
            message = string.Empty;
            busyParameters = new Dictionary<int, string>();
        }

        #endregion

        #region Singleton Implementation

        private static BusyIndicatorManager instance;
        private static object syncRoot = new object();

        public static BusyIndicatorManager Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new BusyIndicatorManager();
                    }
                    return instance;
                }
            }
        }

        #endregion

        #region Public Properties

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            private set
            {
                isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        private string message;
        public string Message
        {
            get { return message; }
            private set
            {
                message = value;
                RaisePropertyChanged("Message");
            }
        }

        #endregion

        #region Public Methods

        public void ShowBusy(int id, string busyMessage)
        {
            if (!busyParameters.ContainsKey(id))
            {
                busyParameters.Add(id, busyMessage);
                IsBusy = true;
                Message = busyMessage;
            }
            else
            {
                busyParameters[id] = busyMessage;
                IsBusy = true;
                Message = busyMessage;
            }
        }

        public void CloseBusy(int id)
        {
            if (busyParameters.ContainsKey(id))
                busyParameters.Remove(id);

            if (busyParameters.Count == 0)
            {
                IsBusy = false;
                Message = string.Empty;
            }
            else
            {
                IsBusy = true;
                Message = busyParameters.Last().Value;
            }
        }

        #endregion
    }
}
