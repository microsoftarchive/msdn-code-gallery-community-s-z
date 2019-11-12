using System;
namespace ClientWorkflow.Model
{
    public interface ICountModel
    {
        // Notifications
        Action CountCanceled { get; set; }
        Action CountCompleted { get; set; }
        Action CountStarted { get; set; }
        Action<int> CountUpdated { get; set; }

        // Methods
        void StartCounting(int count = 100, int delay = 50);
        void CancelCounting();
        IAsyncResult BeginCancelCounting(AsyncCallback callback, object state);
        void EndCancelCounting(IAsyncResult result);
    }
}
