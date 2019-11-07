namespace ClientWorkflow.Model
{
    using System.Activities;

    public sealed class NotifyCountCompleted : NativeActivity
    {
        #region Methods

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.RequireExtension<ICountModel>();
        }

        protected override void Execute(NativeActivityContext context)
        {
            var countModel = context.GetExtension<CountModel>();
            if (countModel.CountCompleted != null)
            {
                countModel.CountCompleted();
            }
        }

        #endregion
    }
}