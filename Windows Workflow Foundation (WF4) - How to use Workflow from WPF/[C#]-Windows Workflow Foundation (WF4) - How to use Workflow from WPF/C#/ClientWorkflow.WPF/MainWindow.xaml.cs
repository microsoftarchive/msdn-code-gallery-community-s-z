namespace ClientWorkflow.WPF
{
    /// <summary>
    ///   Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Constants and Fields

        private readonly CounterViewModel viewModel;

        #endregion

        #region Constructors and Destructors

        public MainWindow()
        {
            this.InitializeComponent();

            this.viewModel = new CounterViewModel();
            this.Closing += this.viewModel.ViewClosing;
            this.Closed += this.viewModel.ViewClosed;

            this.DataContext = this.viewModel;
        }

        #endregion
    }
}