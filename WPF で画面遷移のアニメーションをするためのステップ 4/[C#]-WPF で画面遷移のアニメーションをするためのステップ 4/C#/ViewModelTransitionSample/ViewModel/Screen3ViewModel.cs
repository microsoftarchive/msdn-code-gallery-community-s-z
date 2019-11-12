namespace ViewModelTransitionSample.ViewModel
{
    public class Screen3ViewModel : WorkspaceViewModel
    {
        public Screen3ViewModel()
        {
            Name = "Screen3";

            System.Diagnostics.Trace.WriteLine(Name + ": コンストラクタ");
        }
    }
}
