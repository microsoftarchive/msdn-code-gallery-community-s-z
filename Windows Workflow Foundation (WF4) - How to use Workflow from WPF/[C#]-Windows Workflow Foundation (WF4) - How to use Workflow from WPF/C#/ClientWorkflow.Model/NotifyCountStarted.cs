namespace ClientWorkflow.Model
{
    using System.Activities;

public sealed class NotifyCountStarted : NativeActivity
{
    protected override void CacheMetadata(NativeActivityMetadata metadata)
    {
        metadata.RequireExtension<ICountModel>();
    }

    protected override void Execute(NativeActivityContext context)
    {
        var countModel = context.GetExtension<ICountModel>();

        if (countModel.CountStarted != null)
        {
            countModel.CountStarted();
        }
    }
}
}