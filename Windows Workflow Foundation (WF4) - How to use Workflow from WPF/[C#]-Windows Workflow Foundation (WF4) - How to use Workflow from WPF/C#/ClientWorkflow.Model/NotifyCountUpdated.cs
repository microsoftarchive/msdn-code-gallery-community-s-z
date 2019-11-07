namespace ClientWorkflow.Model
{
    using System;
    using System.Activities;

    public sealed class NotifyCountUpdated : NativeActivity
    {
        #region Properties

        public InArgument<Int32> CurrentCount { get; set; }

        #endregion

        #region Methods

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.RequireExtension<ICountModel>();
            var currentCountArg = new RuntimeArgument(
                "CurrentCount", typeof(Int32), ArgumentDirection.In);
            metadata.AddArgument(currentCountArg);
            metadata.Bind(this.CurrentCount, currentCountArg);
        }

        protected override void Execute(NativeActivityContext context)
        {
            var countModel = context.GetExtension<ICountModel>();

            if (countModel.CountUpdated != null)
            {
                countModel.CountUpdated(
                    this.CurrentCount.Get(context));
            }
        }

        #endregion
    }
}