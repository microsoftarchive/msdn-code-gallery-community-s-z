using System;
using System.Reactive.Concurrency;
using System.Windows.Forms;

namespace WindowsFormsRxSampleApp
{
    public static class WindowsFormUIDispatcher
    {
        private static Lazy<IScheduler> defaultValue = new Lazy<IScheduler>(
            () => new SynchronizationContextScheduler(WindowsFormsSynchronizationContext.Current));

        public static IScheduler Default
        {
            get { return defaultValue.Value; }
        }
    }
}
