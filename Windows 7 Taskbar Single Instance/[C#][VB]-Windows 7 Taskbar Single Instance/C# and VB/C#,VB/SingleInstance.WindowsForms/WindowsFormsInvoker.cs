using System;
using System.Windows.Forms;

namespace WindowsRecipes.TaskbarSingleInstance.WindowsForms
{
    /// <summary>
    /// A custom <see cref="IArgumentsHandlerInvoker"/> for Windows Forms applications, which invokes argument handlers on the Control's UI thread.
    /// </summary>
    public class WindowsFormsInvoker : IArgumentsHandlerInvoker
    {
        private readonly Control control;

        /// <summary>
        /// Constructs a new instance of the <see cref="WindowsFormsInvoker"/> which always invokes requests on the active form's thread.
        /// </summary>
        public WindowsFormsInvoker()
            : this(null)
        {
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="WindowsFormsInvoker"/> which always invokes requests on the given form's thread.
        /// </summary>
        /// <param name="control">The control on which thread to invoke incoming requests. This would usually be the main application form.</param>
        public WindowsFormsInvoker(Control control)
        {
            this.control = control;
        }

        #region IArgumentsHandlerInvoker Members

        /// <summary>
        /// Invokes the given handler on the Windows Forms control UI thread.
        /// </summary>
        /// <param name="handlerToInvoke">The handler to invoke.</param>
        /// <param name="args">The command line arguments to deliver.</param>
        public void Invoke(Action<string[]> handlerToInvoke, string[] args)
        {
            Control controlToInvoke = control ?? Form.ActiveForm;
            if (controlToInvoke != null)
                controlToInvoke.BeginInvoke(handlerToInvoke, new object[] { args });  // Required in order to get the array as a single param
        }

        #endregion
    }
}
