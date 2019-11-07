using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Data;
using PEJL_WPF_Examples.Factories;

namespace PEJL_WPF_Examples
{
    public partial class MainWindow : Window
    {
        public List<MyClass> MyList { get; set; }
        public IndicatorsViewModel MyIndicators { get; set; }

        public MainWindow()
        {
            this.InitializeComponent();

            MyList = PopulateMyList();
            MyIndicators = new IndicatorsViewModel();

            LayoutRoot.Children.Add(MakeDataGrid());

            var button = MakeButton();

            // Test breaking the property binding code here
            // Comment out lines from ButtonFactory.cs and test here.
            button.BorderBrush = Brushes.Red; // Works. Now comment out Buttonfactory.cs line 39 and try again

            LayoutRoot.Children.Add(button);

            DataContext = this;



        }

        private List<MyClass> PopulateMyList()
        {
            return new List<MyClass>()
            {
                new MyClass { Name="Pete", Score=123 },
                new MyClass { Name="Sally", Score=124 },
            };
        }

        DataGrid MakeDataGrid()
        {
            var dataGridFactory = new DataGridFactory();
            var dg = dataGridFactory.Make_ColumnHeaderAware_DataGrid(MyIndicators);

            //Do not use "dg.ItemsSource = MyList", because changing MyList will not be updated in the UI
            //Use binding instead:
            BindingOperations.SetBinding(dg, DataGrid.ItemsSourceProperty, new Binding { Source = MyList });

            dg.SetValue(Grid.RowProperty, 1);

            return dg;
        }

        Button MakeButton()
        {
            var buttonFactory = new ButtonFactory();
            var butt = buttonFactory.Make_Button(MyIndicators, "Hello");
            butt.SetValue(Grid.RowProperty, 2);

            return butt;
        }

    }

}
