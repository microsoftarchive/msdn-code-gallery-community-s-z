// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <summary>
//   A command whose sole purpose is to
//   relay its functionality to other
//   objects by invoking delegates. The
//   default return value for the CanExecute
//   method is 'true'.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DesignerWorkbench
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;

    /// <summary>
    /// A command whose sole purpose is to 
    ///   relay its functionality to other
    ///   objects by invoking delegates. The
    ///   default return value for the CanExecute
    ///   method is 'true'.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Constants and Fields

        /// <summary>
        /// Predicate that determines if an object can execute
        /// </summary>
        private readonly Predicate<object> canExecute;

        /// <summary>
        /// The action to execute when the command is invoked
        /// </summary>
        private readonly Action<object> execute;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class. 
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">
        /// The execution logic.
        /// </param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class. 
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">
        /// The execution logic.
        /// </param>
        /// <param name="canExecute">
        /// The execution status logic.
        /// </param>
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

        /// <summary>
        /// The can execute changed.
        /// </summary>
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

        /// <summary>
        /// Determines if the command cacn execute
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// true if the command can execute, false if not
        /// </returns>
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        #endregion

        #endregion
    }
}