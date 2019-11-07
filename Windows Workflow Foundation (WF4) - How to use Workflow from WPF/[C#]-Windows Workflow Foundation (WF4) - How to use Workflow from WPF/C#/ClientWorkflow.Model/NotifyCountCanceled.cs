namespace ClientWorkflow.Model
{
    using System.Activities;

    public sealed class NotifyCountCanceled : NativeActivity
    {
        #region Methods

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.RequireExtension<ICountModel>();
        }

        protected override void Execute(NativeActivityContext context)
        {
            var countModel = context.GetExtension<ICountModel>();

            if (countModel.CountCanceled != null)
            {
                countModel.CountCanceled();
            }
        }

        #endregion
    }
}