using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.IO;


namespace StickyNotes
{
    /// <summary>
    /// Interaction logic for EmailDialog.xaml
    /// </summary>

    public partial class EmailDialog : Window
    {
        public EmailDialog(string message)
        {
            this.WindowStyle = WindowStyle.ToolWindow;
            this.Height = this.Width = 600;
            this.Title = "Email";
            this.Background = Window2.ChangeBackgroundColor(Colors.BlanchedAlmond);

            

            if (File.Exists("MailServerInfo"))
            {
                CreateMailUI(message);
                this.ShowDialog();
            }
            else
            {
                MailSettingsDialog msd = new MailSettingsDialog();
                msd.Show();
            }

            

        }

        private void CreateMailUI(string message)
        {
            StackPanel sp = new StackPanel();
            sp.Background = Brushes.Transparent;

            Grid g = new Grid();
            g.Background = Brushes.Transparent;
            RowDefinition rdef1 = new RowDefinition();
            RowDefinition rdef2 = new RowDefinition();
            RowDefinition rdef3 = new RowDefinition();
            RowDefinition rdef4 = new RowDefinition();
            RowDefinition rdef5 = new RowDefinition();
            g.RowDefinitions.Add(rdef1);
            g.RowDefinitions.Add(rdef2);
            g.RowDefinitions.Add(rdef3);
            g.RowDefinitions.Add(rdef4);
            g.RowDefinitions.Add(rdef5);

            ColumnDefinition cd1 = new ColumnDefinition();
            GridLength gdl = new GridLength(80);
            cd1.Width = gdl;
            ColumnDefinition cd2 = new ColumnDefinition();
            g.ColumnDefinitions.Add(cd1);
            g.ColumnDefinitions.Add(cd2);

            Label l00 = new Label();
            l00.Background = Brushes.Transparent;
            l00.Content = "Login:";
            TextBox login = new TextBox();
            string email = GetEmail();
            int index = email.IndexOf('@');
            if (index < 0)
            {
                login.Text = "Pls correct incorrect email in Mail settings";
            }
            else
            {
                string loginText = email.Substring(0, index);
                login.Text = loginText;
            }

            Grid.SetRow(l00, 0);
            Grid.SetColumn(l00, 0);
            Grid.SetRow(login, 0);
            Grid.SetColumn(login, 1);

            Label l0 = new Label();
            l0.Background = Brushes.Transparent;
            l0.Content = "Password:";
            password = new PasswordBox();
            password.PasswordChar = '*';


            Grid.SetRow(l0, 1);
            Grid.SetColumn(l0, 0);
            Grid.SetRow(password, 1);
            Grid.SetColumn(password, 1);

            Label l1 = new Label();
            l1.Background = Brushes.Transparent;
            l1.Content = "To:";
            to = new TextBox();

            Grid.SetRow(l1, 2);
            Grid.SetColumn(l1, 0);
            Grid.SetRow(to, 2);
            Grid.SetColumn(to, 1);

            Label l2 = new Label();
            l2.Background = Brushes.Transparent;
            l2.Content = "From:";
            from = new TextBox();
            from.Text = email;

            Grid.SetRow(l2, 3);
            Grid.SetColumn(l2, 0);
            Grid.SetRow(from, 3);
            Grid.SetColumn(from, 1);

            Label l5 = new Label();
            l5.Background = Brushes.Transparent;
            l5.Content = "Subj:";
            subj = new TextBox();

            Grid.SetRow(l5, 4);
            Grid.SetColumn(l5, 0);
            Grid.SetRow(subj, 4);
            Grid.SetColumn(subj, 1);

            g.Children.Add(l00);
            g.Children.Add(login);
            g.Children.Add(l0);
            g.Children.Add(password);
            g.Children.Add(l1);
            g.Children.Add(to);
            g.Children.Add(l2);
            g.Children.Add(from);
            g.Children.Add(l5);
            g.Children.Add(subj);

            body = new TextBox();
            body.Text = message;
            body.AcceptsReturn = true;
            body.TextWrapping = TextWrapping.Wrap;
            body.Height = 250;
            body.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            Button ok = new Button();
            ok.Content = "Ok";
            ok.HorizontalAlignment = HorizontalAlignment.Right;
            ok.Click += new RoutedEventHandler(ok_Click);

            sp.Children.Add(g);
            sp.Children.Add(body);
            sp.Children.Add(ok);

            this.Height = 500;
            this.Content = sp;
        }

        void ok_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("MailServerInfo",FileMode.Open);
            StreamReader reader = new StreamReader(fs);
            string server = reader.ReadLine();
            string account = reader.ReadLine();
            int index = account.IndexOf('@');
            index = (index < 0) ? 0 : index;
            account = account.Substring(0, index);
            string portString = reader.ReadLine();
            int port = (portString != string.Empty)? Int32.Parse(portString):25;

            bool sslCheck = reader.ReadLine().Contains("true") ? true : false;

            string toEmail = to.Text;
            string fromEmail = from.Text;
            string Password = password.Password;
            string subject = subj.Text;
            string bodyMessage = body.Text;

            reader.Close();
            fs.Close();

            Email email = new Email(server, account, port, sslCheck, toEmail, fromEmail, Password, bodyMessage, this, subject);

        }

        private string GetEmail()
        {
            FileStream fs = new FileStream("MailServerInfo", FileMode.Open);
            StreamReader reader = new StreamReader(fs);
            reader.ReadLine();
            string str = reader.ReadLine();
            reader.Close();
            fs.Close();
            return str;
        }

        private TextBox to = null;
        private TextBox from = null;
        private TextBox body = null;
        private PasswordBox password = null;
        private TextBox subj = null;

    }
}