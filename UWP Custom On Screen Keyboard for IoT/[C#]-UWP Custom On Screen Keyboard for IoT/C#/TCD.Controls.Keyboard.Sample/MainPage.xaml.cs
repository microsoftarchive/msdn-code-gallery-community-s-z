using Windows.UI.Xaml.Controls;

namespace TCD.Controls.Keyboard.Sample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            keyboard.RegisterTarget(textBox);
            keyboard.RegisterTarget(passwordBox);
        }
    }
}
