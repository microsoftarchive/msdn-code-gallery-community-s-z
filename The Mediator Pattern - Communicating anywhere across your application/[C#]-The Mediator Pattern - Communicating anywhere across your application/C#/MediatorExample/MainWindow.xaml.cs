using System.Windows;
using MediatorExample.Helpers;

namespace MediatorExample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Mediator.Register("Try1", MyMethod1);
            Mediator.Register("Try1", MyMethod1); // Does not get added

            Mediator.Register("Try1", MyMethod2); //Same key, different delegate

            Mediator.Register("Try1", MyMethod3);
            Mediator.Unregister("Try1", MyMethod3); //To test if unregister worked

            Mediator.Register("Try4", MyMethod4); // This key is never called
        }

        static void MyMethod1(object args)
        {
            MessageBox.Show("MyMethod1 - " + args.ToString());
        }

        static void MyMethod2(object args)
        {
            MessageBox.Show("MyMethod2 - " + args.ToString());
        }

        static void MyMethod3(object args)
        {
            MessageBox.Show("MyMethod3 - " + args.ToString());
        }

        static void MyMethod4(object args)
        {
            MessageBox.Show("MyMethod4 - " + args.ToString());
        }
    }
}
