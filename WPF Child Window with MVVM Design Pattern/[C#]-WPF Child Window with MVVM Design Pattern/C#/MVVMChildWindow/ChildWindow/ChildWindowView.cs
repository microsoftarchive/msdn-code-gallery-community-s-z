using MVVMChildWindow.ChildWindow.View;
using MVVMChildWindow.ChildWindow.ViewModel;
using MVVMChildWindow.Common;
using System;

namespace MVVMChildWindow.ChildWindow
{
    public class ChildWindowView:BaseViewModel
    {
        public event Action<Person> Closed;
        public ChildWindowView()
        {

        } 

        public void Show(int personId)
        {
            AddUserViewModel vm = new AddUserViewModel(personId);
            vm.Closed += ChildWindow_Closed;
            ChildWindowManager.Instance.ShowChildWindow(new AddUserView() { DataContext = vm });
        }

        void ChildWindow_Closed(Person person)
        {
            if (Closed != null)
                Closed(person);
            ChildWindowManager.Instance.CloseChildWindow();
        }
    }
}
