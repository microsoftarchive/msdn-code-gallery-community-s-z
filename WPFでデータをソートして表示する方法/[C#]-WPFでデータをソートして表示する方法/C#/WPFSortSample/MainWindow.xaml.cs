namespace WPFSortSample
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        // ランダムな年齢を生成するためのRandomクラスのインスタンス
        private readonly Random RandomObject = new Random();
        // 画面に表示するオブジェクトのコレクション
        private ObservableCollection<Person> people = new ObservableCollection<Person>();

        public MainWindow()
        {
            InitializeComponent();

            // XAMLで定義したCollectionViewSourceのSourceにコレクションを設定
            var source1 = this.Resources["source1"] as CollectionViewSource;
            if (source1 != null)
            {
                source1.Source = people;
            }

            var source2 = this.Resources["source2"] as CollectionViewSource;
            if (source2 != null)
            {
                source2.Source = people;
            }
        }

        private void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {
            // ランダムな年齢のPersonクラスのオブジェクトを追加する
            var p = new Person
            {
                Name = "No." + (this.people.Count + 1) + ": Dummy person",
                Age = this.RandomObject.Next(100)
            };
            this.people.Add(p);
        }
    }
}
