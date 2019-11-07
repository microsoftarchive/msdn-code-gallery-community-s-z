using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowListSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowWindowButton_Click(object sender, RoutedEventArgs e)
        {
            // 新しいウィンドウを作成します。
            var w = new Window
            {
                Owner = this,
                Title = DateTime.Now.ToString()
            };
            w.Show();
        }

        private void ShowWindowListButton_Click(object sender, RoutedEventArgs e)
        {
            // 表示中のWindowのタイトルをメッセージボックスに表示します。
            var windowTitles = Application
                .Current
                .Windows
                .Cast<Window>()
                .Aggregate(
                    new StringBuilder(),
                    (sb, w) => sb.AppendLine(w.Title))
                .ToString();
            MessageBox.Show(windowTitles);
        }
    }
}
