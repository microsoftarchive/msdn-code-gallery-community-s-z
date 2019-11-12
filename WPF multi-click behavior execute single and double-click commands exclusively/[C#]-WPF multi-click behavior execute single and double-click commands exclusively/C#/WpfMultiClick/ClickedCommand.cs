using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMultiClick
{
    public class ClickedCommand : ICommand
    {
        private Action<object> executeMethod;

        public ClickedCommand(Action<object> ExecuteMethod)
        {
            executeMethod = ExecuteMethod;
        }

        public void Execute(object parameter)
        {
            if (executeMethod != null)
            {
                executeMethod.Invoke(parameter);
            }
        }

        public bool CanExecute(object parameter)
        {
            return parameter != null;
        }
        public event EventHandler CanExecuteChanged;
    } 
}
