namespace TransitionTest
{
    using System.Windows;

    /// <summary>
    /// 画面遷移用オブジェクト保持クラス
    /// </summary>
    public class Transition : FrameworkElement
    {
        public enum TransitionState
        {
            A,
            B,
        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source",
            typeof(object),
            typeof(Transition),
            new PropertyMetadata(
                delegate(DependencyObject obj, DependencyPropertyChangedEventArgs e)
                {
                    (obj as Transition).Swap();
                }));
        /// <summary>
        /// 新規画面
        /// </summary>
        public object Source
        {
            get { return GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty DisplayAProperty = DependencyProperty.Register(
            "DisplayA",
            typeof(object),
            typeof(Transition));
        /// <summary>
        /// 画面 A
        /// </summary>
        public object DisplayA
        {
            get { return GetValue(DisplayAProperty); }
            set { SetValue(DisplayAProperty, value); }
        }

        public static readonly DependencyProperty DisplayBProperty = DependencyProperty.Register(
            "DisplayB",
            typeof(object),
            typeof(Transition));
        /// <summary>
        /// 画面 B
        /// </summary>
        public object DisplayB
        {
            get { return GetValue(DisplayBProperty); }
            set { SetValue(DisplayBProperty, value); }
        }

        public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
            "State",
            typeof(TransitionState),
            typeof(Transition));
        /// <summary>
        /// 画面の遷移状態
        /// </summary>
        public TransitionState State
        {
            get { return (TransitionState)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        /// <summary>
        /// 状態を入れ替える
        /// </summary>
        private void Swap()
        {
            if (State == TransitionState.A)
            {
                DisplayB = Source;
                State = TransitionState.B;
            }
            else
            {
                DisplayA = Source;
                State = TransitionState.A;
            }
        }


    }
}
