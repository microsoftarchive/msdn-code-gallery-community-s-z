using Mm.CustomControls;
using System.Windows;

namespace Mm.Wpf.PInvoke
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : CustomWindow
  {
    public MainWindow() {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        base.DisableMinimizeButton();
    }

    private void Button_Click2(object sender, RoutedEventArgs e)
    {
        base.EnableMinimizeButton();
    }

    private void Button_Click3(object sender, RoutedEventArgs e)
    {
        base.DisableMaximizeButton();
    }

    private void Button_Click4(object sender, RoutedEventArgs e)
    {
        base.EnableMaximizeButton();
    }

    private void Button_Click5(object sender, RoutedEventArgs e)
    {
        base.DisableCloseButton();
    }

    private void Button_Click6(object sender, RoutedEventArgs e)
    {
        base.EnableCloseButton();
    }

    private void Button_Click7(object sender, RoutedEventArgs e)
    {
        base.HideMinimizeAndMaximizeButtons();
    }

    private void Button_Click8(object sender, RoutedEventArgs e)
    {
        base.ShowMinimizeAndMaximizeButtons();
    }

    private void Button_Click9(object sender, RoutedEventArgs e)
    {
        base.HideAllButtons();
    }

    private void Button_Click10(object sender, RoutedEventArgs e)
    {
        base.ShowAllButtons();
    }
  }
}
