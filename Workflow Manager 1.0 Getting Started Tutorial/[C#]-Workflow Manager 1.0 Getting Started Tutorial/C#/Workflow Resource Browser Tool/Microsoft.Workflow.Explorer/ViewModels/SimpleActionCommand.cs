//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.ViewModels
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Simple ICommand implementation which invokes a specified action delegate that takes a single object parameter.
    /// </summary>
    class SimpleActionCommand : ICommand
    {
        Action<object> action;

        public SimpleActionCommand(Action<object> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            this.action = action;
        }

#pragma warning disable 0067
        // this is required by the ICommand interface but is not used by this code
        public event EventHandler CanExecuteChanged;
#pragma warning restore 0067

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.action.Invoke(parameter);
        }
    }
}
