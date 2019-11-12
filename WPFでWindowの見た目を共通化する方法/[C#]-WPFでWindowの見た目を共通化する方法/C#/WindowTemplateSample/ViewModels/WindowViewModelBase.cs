namespace WindowTemplateSample.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Codeplex.Reactive;

    /// <summary>
    /// DefaultWindowStyleを適用したWindowのViewModelの基本クラス。
    /// </summary>
    public abstract class WindowViewModelBase
    {
        /// <summary>
        /// 左側のボタン
        /// </summary>
        public ButtonViewModel CommonAButton { get; set; }
        /// <summary>
        /// 右側のボタン
        /// </summary>
        public ButtonViewModel CommonBButton { get; set; }

        protected WindowViewModelBase(ButtonViewModel a = null, ButtonViewModel b = null)
        {
            this.CommonAButton = a ?? new ButtonViewModel();
            this.CommonBButton = b ?? new ButtonViewModel();
        }

    }

    /// <summary>
    /// 画面に表示するボタンを表す
    /// </summary>
    public class ButtonViewModel
    {
        /// <summary>
        /// ボタンに表示するテキスト
        /// </summary>
        public ReactiveProperty<string> Label { get; private set; }
        /// <summary>
        /// ボタンが押された時に実行するコマンド
        /// </summary>
        public ReactiveCommand Command { get; private set; }

        public ButtonViewModel(ReactiveProperty<string> label = null, ReactiveCommand command = null)
        {
            this.Label = label ?? new ReactiveProperty<string>();
            this.Command = command ?? new ReactiveCommand();
        }
    }
}
