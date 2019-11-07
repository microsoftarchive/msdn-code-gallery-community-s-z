using System.Windows;

namespace MVVMChildWindow.Common
{
    public class ChildWindowManager : BaseViewModel
    {
        public ChildWindowManager()
        {
            WindowVisibility = Visibility.Collapsed;
            XmlContent = null;
        }

        //Singleton pattern implementation
        private static ChildWindowManager instance;
        public static ChildWindowManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChildWindowManager();
                }
                return instance;
            }
        }

        #region Public Properties

        private Visibility windowVisibility;
        public Visibility WindowVisibility
        {
            get { return windowVisibility; }
            set 
            { 
                windowVisibility = value;
                RaisePropertyChanged("WindowVisibility");
            }
        }

        private FrameworkElement xmlContent;
        public FrameworkElement XmlContent
        {
            get { return xmlContent; }
            set 
            { 
                xmlContent = value;
                RaisePropertyChanged("XmlContent");
            }
        }
        
        #endregion

        #region Public Methods

        public void ShowChildWindow(FrameworkElement content)
        {
            XmlContent = content;
            RaisePropertyChanged("XmlContent");
            WindowVisibility = Visibility.Visible;
            RaisePropertyChanged("WindowVisibility");
        }

        public void CloseChildWindow()
        {
            WindowVisibility = Visibility.Collapsed;
            RaisePropertyChanged("WindowVisibility");
            XmlContent = null;
            RaisePropertyChanged("XmlContent");
        } 

        #endregion
    }
}
