using MvvmExtraLite.Helpers;
using MvvmExtraLite.View;
namespace MvvmExtraLite.ViewModel
{
    class ViewModelMain : ViewModelBase
    {
        public RelayCommand CloseCommand { get; set; }

        public ViewModelMain()
        {
            CloseCommand = new RelayCommand(Close_Execute, Close_CanExecute);
        }

        bool Close_CanExecute(object parameter)
        {
            if (parameter == null) return false;
            return (bool)parameter;
        }

        void Close_Execute(object parameter)
        {
            var win2 = new MediatorWindow();
            win2.Show();
            
            //Close this window
            CloseWindow();
        }
    }
}
