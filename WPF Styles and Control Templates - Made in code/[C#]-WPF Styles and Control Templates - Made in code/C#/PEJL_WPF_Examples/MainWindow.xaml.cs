using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
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

            //Create and add DataGrid to the window
            CodedControlsGrid.Children.Add(MakeDataGrid());

            //Create and add Standatrd Button to the window
            NewButtonsStack.Children.Add(MakeStandardButton());

            //Create and add Enhanced Button to the window
            NewButtonsStack.Children.Add(MakeEnhancedButton());

            //Create default CheckBox
            var cb = MakeCheckbox("Microsoft.Windows.Themes.BulletChrome");
            cb.SetBinding(CheckBox.IsCheckedProperty, new Binding("IsChecked") { Source = MyIndicators });
            NewCheckBoxesStack.Children.Add(cb);

            //Create CheckBoxes with custom bullets (Images)
            NewCheckBoxesStack.Children.Add(MakeCheckbox("Media/ThumbsUp.png"));
            NewCheckBoxesStack.Children.Add(MakeCheckbox("Media/Tick.jpg"));

            // Create default label
            //NewCheckBoxesStack.Children.Add(MakeLabel());

            // Binding DataContext to itself
            DataContext = this;
        }

        private Label MakeLabel()
        {
            var label = LabelFactory.MakeLabel();
            label.Content = "This is a test";

            return label;
        }

        private CheckBox MakeCheckbox(string bulletType)
        {
            var factory = new CheckBoxFactory();
            var cb = factory.MakeCheckBox(MyIndicators, bulletType);
            cb.HorizontalAlignment = HorizontalAlignment.Center;
            cb.VerticalAlignment = VerticalAlignment.Center;
            cb.SetValue(Grid.ColumnProperty, 2);
            cb.Margin = new Thickness(10);
            cb.Content = "Click Me";

            cb.BorderBrush = Brushes.Red;

            return cb;
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
            dg.SetBinding(DataGrid.ItemsSourceProperty, new Binding { Source = MyList });

            dg.HorizontalAlignment = HorizontalAlignment.Center;
            dg.VerticalAlignment = VerticalAlignment.Center;
            dg.SetValue(Grid.RowProperty, 1);

            return dg;
        }

        Button MakeStandardButton()
        {
            var buttonFactory = new ButtonFactory();
            var butt = buttonFactory.Make_Button(MyIndicators, false);
            butt.SetValue(Grid.RowProperty, 2);
            butt.HorizontalAlignment = HorizontalAlignment.Center;
            butt.VerticalAlignment = VerticalAlignment.Center;
            butt.Width = 210;
            butt.Margin = new Thickness(10);
            butt.SetValue(Grid.ColumnProperty, 1);
            butt.Content = "Default Styles & Template from code";

            return butt;
        }

        Button MakeEnhancedButton()
        {
            var buttonFactory = new ButtonFactory();
            var butt = buttonFactory.Make_Button(MyIndicators, true);
            butt.SetValue(Grid.RowProperty, 2);
            butt.HorizontalAlignment = HorizontalAlignment.Center;
            butt.VerticalAlignment = VerticalAlignment.Center;
            butt.Width = 210;
            butt.Margin = new Thickness(10);
            butt.SetValue(Grid.ColumnProperty, 1);
            butt.Content = "Using flashy Template";

            return butt;
        }

    }

}
