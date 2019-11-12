using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;

namespace StickyNotes
{
    public class Window2 : Window
    {

        public Window2()
        {

            this.Name = "Window2";
            
            LinearGradientBrush lgb = ChangeBackgroundColor(System.Windows.Media.Colors.Yellow);
            this.Background = lgb;

            this.WindowStyle = WindowStyle.ToolWindow;
            this.Height = this.Width = 200;

            this.Content = InitializeStickyNote();

            this.Closing += new System.ComponentModel.CancelEventHandler(Window2_Closing);
            this.SizeChanged += new SizeChangedEventHandler(Window2_SizeChanged);
            this.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(Window2_PreviewMouseLeftButtonUp);
            this.ShowInTaskbar = false;
            this.Show();
            rtb.Focus();
        }


        public static LinearGradientBrush ChangeBackgroundColor( System.Windows.Media.Color c)
        {
            GradientStop gs1 = new GradientStop(System.Windows.Media.Colors.White, 0);
            GradientStop gs2 = new GradientStop(c, 1);
            GradientStopCollection gsc = new GradientStopCollection();
            gsc.Add(gs1);
            gsc.Add(gs2);
            LinearGradientBrush lgb = new LinearGradientBrush();
            lgb.StartPoint = new System.Windows.Point(0, 0);
            lgb.EndPoint = new System.Windows.Point(0, 1);
            lgb.GradientStops = gsc;
            return lgb;
        }

        void Window2_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.WindowStyle.ToString() == WindowStyle.None.ToString())
            {
                this.WindowStyle = WindowStyle.ToolWindow;
                this.Height = _windowHeight;
                this.Width = _windowWidth;
                this.ResizeMode = ResizeMode.CanResize;
                this.Background = backGround;
                this.Foreground = foreGround;
                this.Cursor = System.Windows.Input.Cursors.Arrow;
                this.BorderThickness = new Thickness(0);
                this.ShowInTaskbar = false;
            }
        }


        void Window2_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            rtb.Width = ((this.ActualWidth - 10) > 0) ? (this.ActualWidth - 10) : rtb.Width;
            rtb.Height = ((this.ActualHeight - 50) > 0) ? (this.ActualHeight - 50) : rtb.Height; 
        }

        private StackPanel InitializeStickyNote()
        {
            StackPanel sp = new StackPanel();
            Menu menu = new Menu();
            menu.Background = System.Windows.Media.Brushes.Transparent;

            menu.Width = 20;
            menu.Height = 15;
            menu.HorizontalAlignment = HorizontalAlignment.Left;


            MenuItem m0 = new MenuItem();
            m0.Padding = new Thickness(0);
            m0.Margin = new Thickness(0);
            Button menuButton = new Button();
            menuButton.Width = 18;
            menuButton.Height = 13;
            menuButton.Background = System.Windows.Media.Brushes.Red;
            menuButton.Click += new RoutedEventHandler(menuButton_Click);
            m0.Header = menuButton;
            m0.BorderThickness = new Thickness(1);
            

                MenuItem m1 = new MenuItem();
                m1.Background = System.Windows.Media.Brushes.BlanchedAlmond;
                m1.Header = "Minimize";
                m1.Click += new RoutedEventHandler(m1_Click);

                MenuItem m2 = new MenuItem();
                m2.Background = System.Windows.Media.Brushes.BlanchedAlmond;
                m2.Header = "Preferences";
                m2.Click += new RoutedEventHandler(m2_Click);



                MenuItem m3 = new MenuItem();
                m3.Background = System.Windows.Media.Brushes.BlanchedAlmond;
                m3.Header = "Close";
                m3.Click += new RoutedEventHandler(m3_Click);

                MenuItem m4 = new MenuItem();
                m4.Background = System.Windows.Media.Brushes.BlanchedAlmond;
                m4.Header = "AlwaysOnTop";
                m4.Click += new RoutedEventHandler(m4_Click);
                m4.Name = "AlwaysOnTop";

                MenuItem m5 = new MenuItem();
                m5.Background = System.Windows.Media.Brushes.BlanchedAlmond;
                m5.Header = "Email Note To:";
                m5.Click += new RoutedEventHandler(m5_Click);
                m5.Name = "email";

                MenuItem m6 = new MenuItem();
                m6.Background = System.Windows.Media.Brushes.BlanchedAlmond;
                m6.Header = "Remove Alarm";
                m6.Click += new RoutedEventHandler(m6_Click);
                m6.Name = "alarm";
                m6.IsEnabled = false;

                MenuItem m7 = new MenuItem();
                m7.Background = System.Windows.Media.Brushes.BlanchedAlmond;
                m7.Header = "Dismiss Alarm";
                m7.Click += new RoutedEventHandler(m7_Click);
                m7.Name = "DismissAlarm";
                m7.IsEnabled = false;


            m0.Items.Add(m1);
            m0.Items.Add(m2);
            m0.Items.Add(m4);
            m0.Items.Add(m5);
            m0.Items.Add(m6);
            m0.Items.Add(m7);
            m0.Items.Add(m3);

            menu.Items.Add(m0);

            WrapPanel wp = new WrapPanel();
            wp.Children.Add(menu);

            System.Windows.Controls.Image simpleImage = new System.Windows.Controls.Image();
            simpleImage.Margin = new Thickness(0);

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("alarm3.PNG", UriKind.Relative);
            bi.EndInit();
            //Set image source
            simpleImage.Source = bi;
            simpleImage.HorizontalAlignment = HorizontalAlignment.Center;
            simpleImage.Visibility = Visibility.Hidden;
            simpleImage.Name = "AlarmIndicator";
            simpleImage.Width = 13;
            wp.Children.Add(simpleImage);

            sp.Children.Add(wp);

            rtb = new RichTextBox();
            rtb.Name ="NoteBox";
            rtb.Background = System.Windows.Media.Brushes.Transparent;
            rtb.BorderThickness = new Thickness(0,1,0,0);
            rtb.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            rtb.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            rtb.Height = this.Height -50;
            rtb.Width = this.Width - 10;
            sp.Children.Add(rtb);

            return sp;
        }

        void m7_Click(object sender, RoutedEventArgs e)
        {
            Menu m = ((Menu)(((MenuItem)(((MenuItem)(sender as MenuItem)).Parent as MenuItem)).Parent as Menu));
            (sender as MenuItem).IsEnabled = false;

            Window2 w = ((Window2)(((StackPanel)((WrapPanel)(m.Parent as WrapPanel)).Parent as StackPanel).Parent as Window));
            MenuItem m1 = sender as MenuItem;
            m1.IsEnabled = false;
            MenuItem m2 = LogicalTreeHelper.FindLogicalNode(w, "AlwaysOnTop") as MenuItem;
            w.Topmost = w.TopmostWindow;
            m2.IsChecked = w.Topmost;

            MenuItem menuItemRemoveAlarm = LogicalTreeHelper.FindLogicalNode(w, "alarm") as MenuItem;
            System.Windows.Controls.Image im = LogicalTreeHelper.FindLogicalNode(w, "AlarmIndicator") as System.Windows.Controls.Image;
            if (w.repetitionNumber.Contains("null"))
            {
                im.Visibility = Visibility.Hidden;
                menuItemRemoveAlarm.IsEnabled = false;
            }
            else
            {
                im.Visibility = Visibility.Visible;
                menuItemRemoveAlarm.IsEnabled = true;
            }

            w.BorderThickness = new Thickness(3);
            w.BorderBrush = System.Windows.Media.Brushes.Red;
            alarmDismissed = true;
        }

        void m6_Click(object sender, RoutedEventArgs e)
        {
            Menu m = ((Menu)(((MenuItem)(((MenuItem)(sender as MenuItem)).Parent as MenuItem)).Parent as Menu));
            Window2 w = ((Window2)(((StackPanel)((WrapPanel)(m.Parent as WrapPanel)).Parent as StackPanel).Parent as Window));
            w.Alarm = new DateTime();
            MenuItem m1 = sender as MenuItem;
            m1.IsEnabled = false;
            MenuItem m2 = LogicalTreeHelper.FindLogicalNode(w, "AlwaysOnTop") as MenuItem;
            w.Topmost = w.TopmostWindow;
            m2.IsChecked = w.Topmost;

            MenuItem menuItemDismissAlarm = LogicalTreeHelper.FindLogicalNode(w, "DismissAlarm") as MenuItem;
            menuItemDismissAlarm.IsEnabled = false;

            System.Windows.Controls.Image im = LogicalTreeHelper.FindLogicalNode(w, "AlarmIndicator") as System.Windows.Controls.Image;
            im.Visibility = Visibility.Hidden;
            w.repetitionNumber = "null";

            w.BorderThickness = new Thickness(0);
            w.BorderBrush = System.Windows.Media.Brushes.Transparent;
        }

        void m5_Click(object sender, RoutedEventArgs e)
        {
            TextRange tr = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            EmailDialog emailDialog = new EmailDialog(tr.Text);
        }

        void m2_Click(object sender, RoutedEventArgs e)
        {
            dialog = new Dialog(Alarm, RepetitionNumber);
            dialog.Closed += new EventHandler(dialog_Closed);
        }

        void dialog_Closed(object sender, EventArgs e)
        {
            Dialog dia = sender as Dialog;
            if (dia.Tag != null)
            {
                dia.Tag = null;
                object[] arr = dia.PropertyArray;
                if (arr[0] != null)
                {
                    _windowBackground = (int)(arr[0]);
                    if (this.WindowStyle.ToString() == WindowStyle.None.ToString())
                    {
                        backGround = ChangeBackgroundColor(Dialog.colorArray[_windowBackground]);
                    }
                    else
                    {
                        this.Background = ChangeBackgroundColor(Dialog.colorArray[_windowBackground]);
                        backGround = this.Background;
                    }
                }
                else
                {
                    _windowBackground = (_windowBackground != -1) ? _windowBackground : -1;
                }
                if (arr[1] != null)
                {
                    _windowForeground = (int)(arr[1]);
                    RichTextBox rtb = LogicalTreeHelper.FindLogicalNode(this, "NoteBox") as RichTextBox;
                    rtb.SelectAll();
                    rtb.Selection.ApplyPropertyValue(RichTextBox.ForegroundProperty, Dialog.colorArrayForeground[_windowForeground]);
                    rtb.Selection.Select(rtb.Document.ContentStart, rtb.Document.ContentStart);
                    foreGround = this.Foreground;
                }
                else
                {
                    _windowForeground = (_windowForeground != -1) ? _windowForeground : -1;
                }
                if (arr[2] != null)
                {
                    NoteAlarm = dia.Alarm;


                    Window2 w = this;
                    MenuItem m = LogicalTreeHelper.FindLogicalNode(w, "AlwaysOnTop") as MenuItem;
                    MenuItem m1 = LogicalTreeHelper.FindLogicalNode(w, "alarm") as MenuItem;
                    MenuItem m3 = LogicalTreeHelper.FindLogicalNode(w, "DismissAlarm") as MenuItem;
                    System.Windows.Controls.Image m2 = LogicalTreeHelper.FindLogicalNode(w, "AlarmIndicator") as System.Windows.Controls.Image;
                    DateTime alarm = w.Alarm;
                    DateTime current = DateTime.Now;
                    m2.Visibility = (alarm.CompareTo(DateTime.Now) >= 0) ? (Visibility.Visible) : (Visibility.Hidden);

                    if (alarm.Date == current.Date)
                    {
                        DateTime temp1 = alarm;
                        DateTime temp2 = current;
                        temp1 = temp1.AddMinutes(30);
                        temp2 = temp2.AddMinutes(30);

                        if ((temp2.CompareTo(alarm) >= 0) && (temp1.CompareTo(current) >= 0))
                        {
                            w.Topmost = true;
                            m.IsChecked = true;
                            m1.IsEnabled = true;
                            w.BorderBrush = System.Windows.Media.Brushes.Black;
                            w.BorderThickness = new Thickness(5);
                            m3.IsEnabled = true;
                        }
                    }
                    else
                    {
                        w.Topmost = w.TopmostWindow;
                        m.IsChecked = w.Topmost;
                        m1.IsEnabled = (alarm.CompareTo(DateTime.Now) >= 0) ? true : false;
                        m3.IsEnabled = false;

                        w.BorderBrush = System.Windows.Media.Brushes.Transparent;
                        w.BorderThickness = new Thickness(0);
                    }
                    
                }
                repetitionNumber = dia.AlarmRepetition;
            }


        }

        void m4_Click(object sender, RoutedEventArgs e)
        {
            Menu m = ((Menu)(((MenuItem)(((MenuItem)(sender as MenuItem)).Parent as MenuItem)).Parent as Menu));
            Window2 w = ((Window2)(((StackPanel)((WrapPanel)(m.Parent as WrapPanel)).Parent as StackPanel).Parent as Window));
            if (w.Topmost == false)
            {
                w.Topmost = true;
                TopmostWindow = true;
                ((MenuItem)(sender)).IsChecked = true;
                w.UpdateLayout();
                w.BringIntoView();
            }
            else
            {
                TopmostWindow = w.Topmost = false;
                ((MenuItem)(sender)).IsChecked = false;
            }

        }

        void m1_Click(object sender, RoutedEventArgs e)
        {
            Menu m = ((Menu)(((MenuItem)(((MenuItem)(sender as MenuItem)).Parent as MenuItem)).Parent as Menu));
            Window2 w = ((Window2)(((StackPanel)((WrapPanel)  (m.Parent as WrapPanel)).Parent as StackPanel).Parent as Window));
            _windowHeight = w.ActualHeight;
            _windowWidth = w.ActualWidth;
            w.Height = 20;
            w.Width = 20;

            foreGround = w.Foreground;
            backGround = w.Background;

            w.Cursor = System.Windows.Input.Cursors.Hand;
            w.BorderThickness = new Thickness(2);
            w.WindowStyle = WindowStyle.None;
            w.ResizeMode = ResizeMode.NoResize;
            w.Background = System.Windows.Media.Brushes.GreenYellow;
        }

        void m3_Click(object sender, RoutedEventArgs e)
        {
            Menu m = ((Menu)(((MenuItem)(((MenuItem)(sender as MenuItem)).Parent as MenuItem)).Parent as Menu));
            ((Window2)(((StackPanel)((WrapPanel)(m.Parent as WrapPanel)).Parent as StackPanel).Parent as Window)).Close();
        }

        void menuButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            MenuItem menuItem = b.Parent as MenuItem;
            menuItem.Focus();
            menuItem.IsSubmenuOpen = true;
        }

        void Window2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window2 w2 = sender as Window2;
            Window1 w1 = Application.Current.MainWindow as Window1;
            object[] arr = w1.WindowArray;
            int index =((int) (w2.Tag));
            arr[index] = null;
            if (dialog!=null)
            {
                dialog.Close();
            }
        }

        public int BackgroundColorIndex
        {
            get
            {
                return _windowBackground;
            }
            set
            {
                _windowBackground = value;
            }
        }

        public int ForegroundColorIndex
        {
            get
            {
                return _windowForeground;
            }
            set
            {
                _windowForeground = value;
            }
        }

        public DateTime Alarm
        {
            get
            {
                return NoteAlarm;
            }
            set
            {
                NoteAlarm = value;
            }
        }

        public bool TopmostWindow
        {
            get
            {
                return OnTop;
            }
            set
            {
                OnTop = value;
            }
        }

        public bool AlarmDismissed
        {
            get
            {
                return alarmDismissed;
            }
            set
            {
                alarmDismissed = value;
            }
        }

        public string RepetitionNumber
        {
            get
            {
                return repetitionNumber;
            }
            set
            {
                repetitionNumber = value;
            }
        }

        private RichTextBox rtb = null;
        private double _windowHeight = 0;
        private double _windowWidth= 0;
        private int _windowBackground = -1;
        private int _windowForeground = -1;
        private Dialog dialog = null;
        private DateTime NoteAlarm;
        private bool OnTop = false;
        private bool alarmDismissed = false;
        private string repetitionNumber = "null";
        private System.Windows.Media.Brush backGround = null;
        private System.Windows.Media.Brush foreGround = null;
    }
}