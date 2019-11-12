using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Reflection;
using System.IO;
using System.Windows.Media.Imaging;



namespace StickyNotes
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>

    enum PropNames
    {
        BackgroundColor =0,
        ForegroundColor,
        Alarm,

    }
    public partial class Dialog : Window
    {
        public Dialog( DateTime NoteAlarm, string LoadedRepetition)
        {

            this.WindowStyle = WindowStyle.ToolWindow;
            this.Height = 350;
            this.Width = 600;
            this.Title = "Options";
            this.Background = Brushes.LemonChiffon;
            this.alarm = NoteAlarm;
            this.alarmRepetition = LoadedRepetition;

            StackPanel sp = new StackPanel();

            _tabControl = new TabControl();
            _tabControl.HorizontalContentAlignment = HorizontalAlignment.Left;
            _tabControl.Width = this.Width - 10 ;
            _tabControl.Height = this.Height -60;
            _tabControl.Background = Brushes.Transparent;
            sp.Children.Add(_tabControl);

            TabItem item1 = new TabItem();
            FirstTabColorSettings(item1);
            _tabControl.Items.Add(item1);

            TabItem item2 = new TabItem();
            SecondTabMailSettings(item2);
            _tabControl.Items.Add(item2);

            TabItem item3 = new TabItem();
            ThirdTabAlarmSettings(item3);
            _tabControl.Items.Add(item3);

            Button ok = new Button();
            ok.Content = "OK";
            ok.HorizontalAlignment = HorizontalAlignment.Right;
            ok.Click += new RoutedEventHandler(ok_Click);
            sp.Children.Add(ok);

            this.Content = sp;

            this.Show();

            this.SizeChanged += new SizeChangedEventHandler(Dialog_SizeChanged);

        }

        private void ThirdTabAlarmSettings(TabItem item)
        {
            item.Header = "Alarm Settings";
            StackPanel sp = new StackPanel();
            sp.Background = Brushes.Transparent;



            Grid g = new Grid();
            g.Background = Brushes.Transparent;
            RowDefinition rdef1 = new RowDefinition();
            RowDefinition rdef2 = new RowDefinition();
            RowDefinition rdef3 = new RowDefinition();
            g.RowDefinitions.Add(rdef1);
            g.RowDefinitions.Add(rdef2);
            g.RowDefinitions.Add(rdef3);

            ColumnDefinition cd1 = new ColumnDefinition();
            GridLength gdl = new GridLength(300);
            cd1.Width = gdl;
            ColumnDefinition cd2 = new ColumnDefinition();
            g.ColumnDefinitions.Add(cd1);
            g.ColumnDefinitions.Add(cd2);


            Label l1 = new Label();
            l1.Background = sp.Background;
            l1.Content = "Date (mm/dd/yyyy)";


            TextBox date = new TextBox();
            date.Text = "/2006";
            date.Name = "date";
            //if (Alarm.CompareTo(DateTime.Now) >= 0)
            //{
            //    date.Text = Alarm.Date.ToShortDateString();
            //}

            if (AlarmRepetition.Contains("null"))
            {
                if ((Alarm.CompareTo(DateTime.Now) >= 0) || (((DateTime.Now.TimeOfDay.Hours - Alarm.TimeOfDay.Hours) < 8) &&
                    ((DateTime.Now.TimeOfDay.Hours - Alarm.TimeOfDay.Hours) >= 0)))
                {
                    date.Text = Alarm.Date.ToShortDateString();
                }
            }
            else
            {
                date.Text = Alarm.Date.ToShortDateString();
            }


            Grid.SetRow(l1, 0);
            Grid.SetColumn(l1, 0);
            Grid.SetRow(date, 0);
            Grid.SetColumn(date, 1);


            Label l2 = new Label();
            l2.Background = sp.Background;
            l2.Content = "Time (hr:min:sec)";

            TextBox time = new TextBox();
            time.Text = "00:00:00";
            time.Name = "time";

            if (AlarmRepetition.Contains("null"))
            {
                if ((Alarm.CompareTo(DateTime.Now) >= 0) || (((DateTime.Now.TimeOfDay.Hours - Alarm.TimeOfDay.Hours) < 8) &&
                    ((DateTime.Now.TimeOfDay.Hours - Alarm.TimeOfDay.Hours) >= 0)))
                {
                    time.Text = Alarm.TimeOfDay.ToString();
                }
            }
            else
            {
                time.Text = Alarm.TimeOfDay.ToString();
            }



            Grid.SetRow(l2, 1);
            Grid.SetColumn(l2, 0);
            Grid.SetRow(time, 1);
            Grid.SetColumn(time, 1);




            g.Children.Add(l1);
            g.Children.Add(date);
            g.Children.Add(l2);
            g.Children.Add(time);

            Label l3 = new Label();
            l3.Background = sp.Background;
            l3.Content = "Repeat Every:";

            TextBox repeatNumber = new TextBox();
            repeatNumber.Text = "0";
            repeatNumber.Name = "repeat";
            repeatNumber.MaxLength = 3;
            repeatNumber.TextChanged += new TextChangedEventHandler(repeatNumber_TextChanged);
            if (alarmRepetition.Contains("null") == false)
            {
                repeatNumber.Text = alarmRepetition.Substring(1);
            }

            Label space = new Label();
            space.Background = sp.Background;
            space.Content = " ";

            CheckBox daysCheck = new CheckBox();
            daysCheck.IsChecked = false;
            daysCheck.VerticalAlignment = VerticalAlignment.Center;
            daysCheck.Name = "daysCheck";
            daysCheck.Checked += new RoutedEventHandler(daysCheck_Checked);
            

            Label l4 = new Label();
            l4.Background = sp.Background;
            l4.Content = "Day(s)";

            Label space1 = new Label();
            space.Background = sp.Background;
            space.Content = " ";

            CheckBox weeksCheck = new CheckBox();
            weeksCheck.IsChecked = false;
            weeksCheck.VerticalAlignment = VerticalAlignment.Center;
            weeksCheck.Name = "weeksCheck";
            weeksCheck.Checked += new RoutedEventHandler(weeksCheck_Checked);
            try
            {
                if (alarmRepetition.Contains("null") == false)
                {
                    char[] charr = alarmRepetition.ToCharArray(0, 1);
                    switch (charr[0])
                    {
                        case 'D':
                            daysCheck.IsChecked = true;
                            break;

                        case 'W':
                            weeksCheck.IsChecked = true;
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception) { }
            Label l5 = new Label();
            l5.Background = sp.Background;
            l5.Content = "Week(s)";

            WrapPanel wp = new WrapPanel();
            wp.Children.Add(l3);
            wp.Children.Add(repeatNumber);
            wp.Children.Add(space);
            wp.Children.Add(daysCheck);
            wp.Children.Add(l4);
            wp.Children.Add(space1);
            wp.Children.Add(weeksCheck);
            wp.Children.Add(l5);



            Label status = new Label();
            status.Background = sp.Background;
            status.Name = "statusThirdTab";

            sp.Children.Add(g);
            sp.Children.Add(wp);
            sp.Children.Add(status);

            item.Content = sp;
        }

        void repeatNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Label l = LogicalTreeHelper.FindLogicalNode(this, "statusThirdTab") as Label;
                l.Content = "";
                string str = (sender as TextBox).Text;
                char[] charArr = str.ToCharArray();
                bool val = true;
                for (int i = 0; i < charArr.Length; i++)
                {
                    if ((charArr[i] < '0') || (charArr[i] > '9'))
                    {
                        val = false;
                        break;
                    }
                }
                if (val == false)
                {
                    l.Content = "Input should consist of only numbers";
                    l.Foreground = Brushes.Red;
                }
            }
            catch (Exception) { }
        }

        void daysCheck_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox weeksCheck = LogicalTreeHelper.FindLogicalNode(this, "weeksCheck") as CheckBox;
            weeksCheck.IsChecked = false;
        }

        void weeksCheck_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox daysCheck = LogicalTreeHelper.FindLogicalNode(this, "daysCheck") as CheckBox;
            daysCheck.IsChecked = false;
        }

        private void SecondTabMailSettings(TabItem item)
        {
            item.Header = "Mail Settings";
            StackPanel item2Panel = new StackPanel();

            Label l1 = new Label();
            l1.Content = "SMTP Mail Server:";
            l1.Background = Brushes.Transparent;

            TextBox server = new TextBox();
            server.ToolTip = "smtp.gmail.com/smtp.mail.yahoo.com/smtp.aol.com/...";
            server.Name = "server";

            Label l2 = new Label();
            l2.Content = "Mail Account";
            l2.Background = Brushes.Transparent;

            TextBox account = new TextBox();
            account.ToolTip = "Something like: xyz@aaa.com";
            account.Name = "account";

            Label l3 = new Label();
            l3.Content = "Mail Account";
            l3.Background = Brushes.Transparent;

            TextBox port = new TextBox();
            port.ToolTip = "Port used: Usually 25";
            port.Text = "25";
            port.Name = "port";

            WrapPanel wp = new WrapPanel();
            Label l4 = new Label();
            l4.Content = "Use SSL";
            l4.ToolTip = "Check if SMTP server uses SSL. (gmail uses, Yahoo/aol dont)";
            l4.Background = Brushes.Transparent;

            CheckBox cb = new CheckBox();
            cb.ToolTip = "Check if SMTP server uses SSL. (gmail uses, Yahoo/aol dont)";
            cb.VerticalAlignment = VerticalAlignment.Center;
            cb.Name = "sslCheck";

            wp.Children.Add(l4);
            wp.Children.Add(cb);

            Label l5 = new Label();
            l5.Content = "";
            l5.Background = Brushes.Transparent;
            l5.Name = "status";

            item2Panel.Children.Add(l1);
            item2Panel.Children.Add(server);
            item2Panel.Children.Add(l2);
            item2Panel.Children.Add(account);
            item2Panel.Children.Add(l3);
            item2Panel.Children.Add(port);
            item2Panel.Children.Add(wp);
            item2Panel.Children.Add(l5);


            item.Content = item2Panel;
        }


        private void FirstTabColorSettings(TabItem item)
        {
            item.Header = "Color Settings";
            StackPanel item1Panel = new StackPanel();
            Label l1 = new Label();
            l1.Content = "Background Color:";
            l1.Background = Brushes.Transparent;

            ComboBox combo = new ComboBox();
            InitializeComboBox(combo);
            combo.SelectionChanged += new SelectionChangedEventHandler(combo_SelectionChanged);

            Label l2 = new Label();
            l2.Content = "Foreground Color:";
            l2.Background = Brushes.Transparent;

            ComboBox combo1 = new ComboBox();
            InitializeComboBox1(combo1);
            combo1.SelectionChanged += new SelectionChangedEventHandler(combo1_SelectionChanged);

            item1Panel.Children.Add(l1);
            item1Panel.Children.Add(combo);
            item1Panel.Children.Add(l2);
            item1Panel.Children.Add(combo1);
            item1Panel.Background = Brushes.Transparent;

            item.Content = item1Panel;
        }

        void combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            ComboBoxItem comboItem = cb.SelectedItem as ComboBoxItem;
            PropArray[(int)PropNames.ForegroundColor] = comboItem.Tag; 
        }

        void ok_Click(object sender, RoutedEventArgs e)
        {
            TextBox server = LogicalTreeHelper.FindLogicalNode(this, "server") as TextBox;
            TextBox account = LogicalTreeHelper.FindLogicalNode(this, "account")as TextBox;
            TextBox date = LogicalTreeHelper.FindLogicalNode(this, "date") as TextBox;
            TextBox time = LogicalTreeHelper.FindLogicalNode(this, "time") as TextBox;
            TextBox repeatNumber = LogicalTreeHelper.FindLogicalNode(this, "repeat") as TextBox;
            CheckBox daysCheck = LogicalTreeHelper.FindLogicalNode(this, "daysCheck") as CheckBox;
            CheckBox weeksCheck = LogicalTreeHelper.FindLogicalNode(this, "weeksCheck") as CheckBox;

            string str = (daysCheck.IsChecked == true) ? "D" : "";
            str += (weeksCheck.IsChecked == true) ? "W" : "";
            if (str != string.Empty)
            {
                str += repeatNumber.Text;
            }
            else
            {
                str = "null";
            }

            if ((date.Text != string.Empty)&&(date.Text!="/2006")&&(!(date.Text.Contains(Alarm.Date.ToShortDateString())) 
                || !(AlarmRepetition.Contains(str)) || !(Alarm.TimeOfDay.ToString().Contains(time.Text)) ))
            {
                string dateString = date.Text;
                int[] arr = new int[3];
                string timeString = time.Text;
                int[] arr1 = new int[3];

                int tail = 0;
                int head = dateString.IndexOf('/');
                head = (head >= 0) ? head : 0;

                try
                {
                    for (int i=0; i<3;i++)
                    {
                        head = (i == (arr.Length - 1)) ? (dateString.Length ) : head;
                        arr[i] = Int32.Parse(dateString.Substring(tail, head - tail));
                        if (head == dateString.Length)
                        {
                            break;
                        }
                        tail = head+1;
                        head = dateString.IndexOf('/',tail);
                    }
                    tail = 0;
                    head = timeString.IndexOf(':');
                    head = (head >= 0) ? head : 0;
                    for ( int i = 0; i < 3; i++)
                    {
                        head = (i == (arr1.Length - 1)) ? (timeString.Length) : head;
                        arr1[i] = Int32.Parse(timeString.Substring(tail, head - tail));
                        if (head == timeString.Length)
                        {
                            break;
                        }
                        tail = head + 1;
                        head = timeString.IndexOf(':', tail);
                    }

                    DateTime dt = new DateTime(arr[2], arr[0], arr[1],arr1[0],arr1[1],arr1[2]);
                    if (dt.CompareTo(DateTime.Now) >= 0)
                    {
                        this.alarm = dt;
                        PropArray[(int)PropNames.Alarm] = dt;
                        if(repeatNumber.Text != string.Empty)
                        {
                            alarmRepetition = (daysCheck.IsChecked == true) ? "D" : "";
                            alarmRepetition += (weeksCheck.IsChecked == true) ? "W" : "";
                            if (alarmRepetition != string.Empty)
                            {
                                alarmRepetition += repeatNumber.Text;
                            }
                            else
                            {
                                alarmRepetition = "null";
                            }
                        }
                        this.Tag = "OK";
                        this.Close();
                    }
                    else
                    {
                        this.Title = "AlarmSettings Error";
                        Label l = LogicalTreeHelper.FindLogicalNode(this, "statusThirdTab") as Label;
                        l.Content = "Alarm can be set if the event is after Current time";
                        l.Foreground = Brushes.Red;
                    }
                }
                catch (Exception e1)
                {
                    Label l = LogicalTreeHelper.FindLogicalNode(this, "statusThirdTab") as Label;
                    l.Content = e1.Message;
                    l.Foreground = Brushes.Red;
                    this.Title = "AlarmSettings Error";
                }
            }
            else
            {

                if (((server.Text == string.Empty) && (account.Text == string.Empty)) ||
                    ((server.Text != string.Empty) && (account.Text != string.Empty)))
                {
                    if (((server.Text != string.Empty) && (account.Text != string.Empty)))
                    {
                        TextBox port = LogicalTreeHelper.FindLogicalNode(this, "port") as TextBox;
                        CheckBox cb = LogicalTreeHelper.FindLogicalNode(this, "sslCheck") as CheckBox;


                        FileStream fs = new FileStream("MailServerInfo", FileMode.OpenOrCreate);
                        StreamWriter _writer = new StreamWriter(fs);
                        _writer.WriteLine(server.Text);
                        _writer.WriteLine(account.Text);
                        port.Text = (port.Text != string.Empty) ? port.Text : "25";
                        _writer.WriteLine(port.Text);
                        string check = (cb.IsChecked == true) ? "true" : "false";
                        _writer.WriteLine(check);

                        _writer.Close();
                        fs.Close();
                    }
                    this.Tag = "OK";
                    this.Close();
                }
                else
                {
                    this.Title = "Mail settings are incomplete";
                    server.Background = account.Background = Window2.ChangeBackgroundColor(Colors.Red);
                    Label status = LogicalTreeHelper.FindLogicalNode(this, "status") as Label;
                    status.Content = "Fill in highlighted fields";
                    status.Foreground = Brushes.Red;
                }
            }

        }

        private void InitializeComboBox1(ComboBox combo)
        {
            for (int i = 0; i < colorArrayForeground.Length; i++)
            {
                SolidColorBrush c = colorArrayForeground[i];
                ComboBoxItem comboItem = new ComboBoxItem();
                Label l = new Label();
                l.Foreground = c;
                l.MinHeight = 20;
                l.MinWidth = 20;
                comboItem.Background = l.Background = c;
                comboItem.Tag = i;
                comboItem.Content = l;
                combo.Items.Add(comboItem);
            }
        }

        private void InitializeComboBox(ComboBox combo)
        {
            for (int i = 0; i < colorArray.Length; i++)
            {
                Color c = colorArray[i];
                ComboBoxItem comboItem = new ComboBoxItem();
                Label l = new Label();
                l.Background = Window2.ChangeBackgroundColor(c);
                l.MinHeight = 20;
                l.MinWidth = 20;
                comboItem.Background = Window2.ChangeBackgroundColor(c);
                comboItem.Tag = i;
                comboItem.Content = l;
                combo.Items.Add(comboItem);
            }
        }

        void Dialog_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _tabControl.Width = this.ActualWidth;
            _tabControl.Height = (this.ActualHeight > 60) ? (this.ActualHeight - 60) : _tabControl.Height;
        }

        void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            ComboBoxItem comboItem = cb.SelectedItem as ComboBoxItem;
            PropArray[(int)PropNames.BackgroundColor] = comboItem.Tag; 
        }


        public object[] PropertyArray
        {
            get
            {
                return PropArray;
            }
        }

        public DateTime Alarm
        {
            get
            {
                return alarm;
            }
        }

        public string AlarmRepetition
        {
            get
            {
                return alarmRepetition;
            }
        }

        private TabControl _tabControl = null;
        public static Color[] colorArray = { Colors.Silver, Colors.Violet, Colors.SkyBlue, Colors.LawnGreen, Colors.Yellow , Colors.OrangeRed, Colors.Purple, Colors.Red };
        public static SolidColorBrush[] colorArrayForeground = { Brushes.Black, Brushes.Red, Brushes.Green, Brushes.Blue, Brushes.Brown, Brushes.DarkMagenta, Brushes.DarkSalmon, Brushes.Lime };
        private object[] PropArray = new object[10];
        private DateTime alarm ;
        private string alarmRepetition ="null";

    }
}