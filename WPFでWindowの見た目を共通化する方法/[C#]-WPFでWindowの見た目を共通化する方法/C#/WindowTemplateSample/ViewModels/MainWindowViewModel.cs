namespace WindowTemplateSample.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Codeplex.Reactive;

    /// <summary>
    /// MainWindow.xamlに対応するViewModel
    /// </summary>
    public class MainWindowViewModel : WindowViewModelBase
    {
        /// <summary>
        /// 画面内に表示するテキスト。ヘッダーの左側のボタンが押された時に変更される
        /// </summary>
        public ReactiveProperty<string> AText { get; private set; }
        /// <summary>
        /// 画面内に表示するテキスト。ヘッダーの右側のボタンが押された時に変更される
        /// </summary>
        public ReactiveProperty<string> BText { get; private set; }

        public MainWindowViewModel()
            : base()
        {
            // プロパティの初期化
            this.AText = new ReactiveProperty<string>("A count : 0");
            this.BText = new ReactiveProperty<string>("B count : 0");

            // 共通部分にあるボタンのテキストを指定する
            this.CommonAButton.Label.Value = "Main A";
            this.CommonBButton.Label.Value = "Main B";

            // 共通部分にあるボタンを押したときの処理を定義
            int aCount = 0;
            this.CommonAButton.Command.Subscribe(_ =>
                this.AText.Value = "A count : " + ++aCount);
            int bCount = 0;
            this.CommonBButton.Command.Subscribe(_ =>
                this.BText.Value = "B count : " + ++bCount);
        }
    }
}
