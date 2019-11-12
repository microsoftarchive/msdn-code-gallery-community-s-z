using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Support;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace wpf_EntityFramework
{
    public class MainWindowViewModel : NotifyUIBase
    {
        public ObservableCollection<CommandVM> Commands {get;set;}
        public ObservableCollection<ViewVM> Views {get;set;}
        public string Message { get; set; }

        public MainWindowViewModel()
        {
            ObservableCollection<ViewVM> views = new ObservableCollection<ViewVM>
            {
                new ViewVM{ ViewDisplay="Customers", ViewType = typeof(CustomersView), ViewModelType = typeof(CustomersViewModel)},
                new ViewVM{ ViewDisplay="Products", ViewType = typeof(ProductsView), ViewModelType = typeof(ProductsViewModel)}
            };
            Views = views;
            RaisePropertyChanged("Views");
            views[0].NavigateExecute();

            ObservableCollection<CommandVM> commands = new ObservableCollection<CommandVM>
            {
                new CommandVM{ CommandDisplay="Insert", IconGeometry=Application.Current.Resources["InsertIcon"] as Geometry , Message=new CommandMessage{ Command =CommandType.Insert}},
                new CommandVM{ CommandDisplay="Edit", IconGeometry=Application.Current.Resources["EditIcon"] as Geometry , Message=new CommandMessage{ Command = CommandType.Edit}},
                new CommandVM{ CommandDisplay="Delete", IconGeometry=Application.Current.Resources["DeleteIcon"] as Geometry , Message=new CommandMessage{ Command = CommandType.Delete}},
               // new CommandVM{ CommandDisplay="Commit", IconGeometry=Application.Current.Resources["SaveIcon"] as Geometry , Message=new CommandMessage{ Command = CommandType.Commit}},
                new CommandVM{ CommandDisplay="Refresh", IconGeometry=Application.Current.Resources["RefreshIcon"] as Geometry , Message=new CommandMessage{ Command = CommandType.Refresh}}

            };
            Commands = commands;
            RaisePropertyChanged("Commands");
        }
    }
}
