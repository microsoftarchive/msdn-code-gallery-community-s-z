using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MySql;
using MySQLBlog.ViewModel;
using System.Collections.ObjectModel;
using MySQLBlog.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MySQLBlog
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void InsertTodoBtn_Click(object sender, RoutedEventArgs e)
        {
            // Try the the View Model insertion and check externally for result
            App.TODO_VIEW_MODEL.InsertNewTodo(NewTodoTxtBox.Text);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Todos.ItemsSource = App.TODO_VIEW_MODEL.GetTodos();
        }
    }
}
