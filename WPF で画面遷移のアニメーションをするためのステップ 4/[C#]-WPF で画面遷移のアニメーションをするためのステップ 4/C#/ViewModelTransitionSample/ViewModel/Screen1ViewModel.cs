namespace ViewModelTransitionSample.ViewModel
{
    public class Screen1ViewModel : WorkspaceViewModel
    {
        public Screen1ViewModel()
        {
            Name = "Screen1";

            System.Diagnostics.Trace.WriteLine(Name + ": コンストラクタ");
        }
    }
}
