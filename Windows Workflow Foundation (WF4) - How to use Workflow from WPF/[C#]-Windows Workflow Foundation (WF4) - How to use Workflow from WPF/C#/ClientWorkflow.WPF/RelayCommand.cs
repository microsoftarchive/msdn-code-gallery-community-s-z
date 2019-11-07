namespace ClientWorkflow.WPF
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;

    /// <summary>
    ///   A command whose sole purpose is to 
    ///   relay its functionality to other
    ///   objects by invoking delegates. The
    ///   default return value for the CanExecute
    ///   method is 'true'.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Constants and Fields

        private readonly Predicate<object> canExecute;

        private readonly Action<object> execute;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Creates a new command that can always execute.
        /// </summary>
        /// <param name = "execute">The execution logic.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        ///   Creates a new command.
        /// </summary>
        /// <param name = "execute">The execution logic.</param>
        /// <param name = "canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        #endregion

        #region Implemented Interfaces

        #region ICommand

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            //if (CanExecuteChanged != null)
            //    CanExecuteChanged(this, new EventArgs());
            CommandManager.InvalidateRequerySuggested();
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        #endregion

        #endregion
    }
}