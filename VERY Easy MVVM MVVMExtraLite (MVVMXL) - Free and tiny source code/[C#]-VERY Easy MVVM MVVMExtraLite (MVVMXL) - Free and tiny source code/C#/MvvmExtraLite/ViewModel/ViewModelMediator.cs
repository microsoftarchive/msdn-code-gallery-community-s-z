using MvvmExtraLite.Helpers;
using System.Windows;
using System;
using System.Windows.Input;

namespace MvvmExtraLite.ViewModel
{
    class ViewModelMediator
    {
        public ViewModelMediatorA ViewModelA { get; set; }
        public ViewModelMediatorB ViewModelB { get; set; }

        public RelayCommand EventedCommand1 { get; set; }
        public RelayCommand EventedCommand2 { get; set; }

        public ViewModelMediator()
        {
            ViewModelA = new ViewModelMediatorA();
            ViewModelB = new ViewModelMediatorB();

            ViewModelA.MyPropertyA = "type here";

            EventedCommand1 = new RelayCommand(DoStuff1);
            EventedCommand2 = new RelayCommand(DoStuff2);
        }

        void DoStuff1(object param)
        {
            var parameter = param as string;
            MessageBox.Show("Command executed. Text is: " + parameter);
        }

        void DoStuff2(object param)
        {
            var e = param as MouseButtonEventArgs;
            MessageBox.Show("Command executed. ButtonState: " + e.ButtonState);
        }

    }
}
