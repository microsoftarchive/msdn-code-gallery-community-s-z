using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPFGroupingSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        // ランダムな年齢用を生成するためのRandomクラスのインスタンス
        private readonly Random RandomObject = new Random();
        // 表示用のデータを格納するコレクション
        private ObservableCollection<Person> people = new ObservableCollection<Person>();

        public MainWindow()
        {
            InitializeComponent();
            // XAMLで定義したCollectionViewSourceにデータを格納したコレクションを紐づける
            var source = this.Resources["source"] as CollectionViewSource;
            if (source != null)
            {
                source.Source = people;
            }
        }

        private void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {
            // ランダムな年齢をもった100個のPersonクラスをコレクションに追加
            foreach (var _ in Enumerable.Range(1, 100))
            {
                this.people.Add(
                    new Person
                    {
                        Name = "No " + (this.people.Count + 1) + ". Dummy person",
                        Age = this.RandomObject.Next(100)
                    });
            }
        }
    }
}
