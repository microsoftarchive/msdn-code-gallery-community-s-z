namespace WpfImageChange
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Media.Imaging;

    public partial class MainWindow : Window
    {
        // 画像へのパス
        private string[] photos;

        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            LoadPhotos();
        }

        /// <summary>
        /// 画像フォルダからjpgファイルを探してphotosに設定します。
        /// </summary>
        private void LoadPhotos()
        {
            var picturePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
            this.photos = Directory.GetFiles(picturePath, "*.jpg", SearchOption.AllDirectories);
        }

        public void ChangePicture()
        {
            // ランダムに表示する画像を選択
            var path = this.photos[this.random.Next(photos.Length)];

            // BitmapImageに画像を読み込み、画面に表示させます。
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(path);
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();
            image1.Source = image;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.ChangePicture();
        }
    }
}
