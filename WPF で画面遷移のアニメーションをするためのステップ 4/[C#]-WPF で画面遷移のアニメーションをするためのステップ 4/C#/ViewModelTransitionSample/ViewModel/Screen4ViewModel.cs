namespace ViewModelTransitionSample.ViewModel
{
    public class Screen4ViewModel : WorkspaceViewModel
    {
        public Screen4ViewModel()
        {
            Name = "Screen4";

            System.Diagnostics.Trace.WriteLine(Name + ": コンストラクタ");
        }
    }
}
