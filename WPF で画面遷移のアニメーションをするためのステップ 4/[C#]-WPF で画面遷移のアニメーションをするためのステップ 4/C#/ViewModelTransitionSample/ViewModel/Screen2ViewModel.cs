namespace ViewModelTransitionSample.ViewModel
{
    public class Screen2ViewModel : WorkspaceViewModel
    {
        public Screen2ViewModel()
        {
            Name = "Screen2";

            System.Diagnostics.Trace.WriteLine(Name + ": コンストラクタ");
        }
    }
}
