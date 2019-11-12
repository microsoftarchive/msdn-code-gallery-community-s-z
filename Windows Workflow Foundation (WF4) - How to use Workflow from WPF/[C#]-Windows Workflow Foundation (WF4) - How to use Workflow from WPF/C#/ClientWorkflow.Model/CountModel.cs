namespace ClientWorkflow.Model
{
    using System;
    using System.Activities;

    internal class CountModel : ICountModel
    {
        #region Constants and Fields

        private readonly object extension;

        private int countDelay;

        private int countTo;

        private WorkflowApplication workflow;

        #endregion

        #region Constructors and Destructors

        public CountModel(object extension)
        {
            this.extension = extension;
        }

        #endregion

        #region Properties

        public Action CountCanceled { get; set; }

        public Action CountCompleted { get; set; }

        public Action CountStarted { get; set; }

        public Action<int> CountUpdated { get; set; }

        #endregion

        #region Implemented Interfaces

        #region ICountModel

        public IAsyncResult BeginCancelCounting(
            AsyncCallback callback, object state)
        {
            return this.workflow != null
                       ? this.workflow.BeginCancel(callback, state)
                       : null;
        }

        public void CancelCounting()
        {
            this.workflow.Cancel();
        }

        public void EndCancelCounting(IAsyncResult result)
        {
            if (this.workflow != null && result != null)
            {
                this.workflow.EndCancel(result);
            }
        }

public void StartCounting(int count = 100, int delay = 50)
{
    this.countTo = count;
    this.countDelay = delay;

    this.workflow = new WorkflowApplication(
        new WorkflowCount
            {
                CountTo = this.countTo,
                CountDelay = this.countDelay
            }) { Aborted = this.OnAborted };

    this.workflow.Extensions.Add(this);
    if (this.extension != null)
    {
        this.workflow.Extensions.Add(this.extension);
    }
    this.workflow.Run();
}

        #endregion

        #endregion

        #region Methods

        private void OnAborted(WorkflowApplicationAbortedEventArgs args)
        {
            throw new InvalidOperationException("Workflow aborted", args.Reason);
        }

        #endregion
    }
}