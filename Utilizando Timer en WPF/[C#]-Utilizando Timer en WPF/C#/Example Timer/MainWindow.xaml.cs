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
using System.Windows.Threading;

namespace Example_Timer
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<string> listaGuids = new ObservableCollection<string>();
            this.DataContext = listaGuids;
            DispatcherTimer dispathcer = new DispatcherTimer();

            //EL INTERVALO DE TIMER ES DE 1 SEGUNDO
            dispathcer.Interval = new TimeSpan(0, 0, 1);
            dispathcer.Tick += (s, a) =>
            {
                //AQUI VA LO QUE QUIERES QUE HAGA CADA 1 SEGUNDO
                listaGuids.Add(Guid.NewGuid().ToString());

            };
            dispathcer.Start();
        }
    }
}
