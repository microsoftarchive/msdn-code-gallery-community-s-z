namespace ViewModelTransitionSample.ViewModel
{
    public class Screen5ViewModel : WorkspaceViewModel
    {
        public Screen5ViewModel()
        {
            Name = "Screen5";

            System.Diagnostics.Trace.WriteLine(Name + ": コンストラクタ");
        }
    }
}
