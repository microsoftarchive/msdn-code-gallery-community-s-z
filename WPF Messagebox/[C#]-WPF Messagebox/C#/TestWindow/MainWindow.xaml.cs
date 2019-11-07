using System;
using System.Windows;
using MessageBox = WPFMessageBox.MessageBox;

namespace TestWindow
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void ShowInfo_Click(object sender, RoutedEventArgs e)
    {
      MessageBox.ShowInformation("Hello World!");
    }

    private void ShowQuestion_Click(object sender, RoutedEventArgs e)
    {
      MessageBox.ShowQuestion("Hello World?", "Is it?");
    }

    private void ShowWarning_Click(object sender, RoutedEventArgs e)
    {
      MessageBox.ShowWarning("This is a very long message which you should not read through. It has nothing important to tell you, it's just here to test the message box's behavior with long texts.", showCancel: true);
    }

    private void ShowError_Click(object sender, RoutedEventArgs e)
    {
      MessageBox.ShowError("!World Hello");
    }

    private void ShowException_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        throw new Exception("FUUUUUUUUUUUU!!!!!!!");
      }
      catch (Exception ex)
      {
        MessageBox.ShowError(ex);
      }
    }
  }
}