using System;
using System.Collections.Generic;
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
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Media.Animation;

namespace wpf_EntityFramework
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            // Apply default form level font style
            Style = (Style)FindResource(typeof(Window));
            Messenger.Default.Register<NavigateMessage>(this, (action) => ShowUserControl(action));
            Messenger.Default.Register<UserMessage>(this, (action) => ReceiveUserMessage(action));
            Messenger.Default.Register<InEdit>(this, (action) => ReceiveInEditMessage(action));
            this.DataContext = new MainWindowViewModel();
        }

        private void ReceiveInEditMessage(InEdit inEdit)
        {
            this.CommandTab.IsEnabled = !inEdit.Mode;
        }

        private void ReceiveUserMessage(UserMessage msg)
        {
            UIMessage.Opacity = 1;
            UIMessage.Text = msg.Message;
            Storyboard sb = (Storyboard)this.FindResource("FadeUIMessage");
            sb.Begin();
        }
        private void ShowUserControl(NavigateMessage nm)
        {
            CommandTab.SelectedItem = EditTabItem;
            Holder.Content = nm.View;
        }
    }
}
