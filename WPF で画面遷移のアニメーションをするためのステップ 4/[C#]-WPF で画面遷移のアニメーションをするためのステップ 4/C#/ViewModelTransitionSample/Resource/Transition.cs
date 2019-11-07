namespace ViewModelTransitionSample.Resource
{
    using System;
    using System.Windows;

    public class Transition : FrameworkElement
    {
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source",
            typeof(object),
            typeof(Transition),
            new PropertyMetadata(
                delegate(DependencyObject sender, DependencyPropertyChangedEventArgs e)
                {
                    (sender as Transition).Swap();
                }));
        public object Source
        {
            get { return GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty DisplayAProperty = DependencyProperty.Register(
            "DisplayA",
            typeof(object),
            typeof(Transition));
        public object DisplayA
        {
            get { return GetValue(DisplayAProperty); }
            set { SetValue(DisplayAProperty, value); }
        }

        public static readonly DependencyProperty DisplayBProperty = DependencyProperty.Register(
            "DisplayB",
            typeof(object),
            typeof(Transition));
        public object DisplayB
        {
            get { return GetValue(DisplayBProperty); }
            set { SetValue(DisplayBProperty, value); }
        }

        public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
            "State",
            typeof(TransitionState),
            typeof(Transition),
            new PropertyMetadata(TransitionState.A));
        public TransitionState State
        {
            get { return (TransitionState)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public enum TransitionState
        {
            A,
            B,
        }

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
