using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using System.Windows.Markup;
using System.Windows.Automation;


namespace StickyNotes
{

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e) 
        {

            windowArray = new object[100];

            TimerClock = new System.Windows.Threading.DispatcherTimer();
            TimerClock.Interval = new TimeSpan(0, 0, 4);
            TimerClock.IsEnabled = true;

            AlarmTimer = new System.Windows.Threading.DispatcherTimer();
            AlarmTimer.Interval = new TimeSpan(0, 30, 0 );
            AlarmTimer.IsEnabled = true;
            AlarmTimer.Tick += new EventHandler(AlarmTimer_Tick);

            LoadNotes();

            ContextMenuService.SetPlacement(MainWindow, System.Windows.Controls.Primitives.PlacementMode.Bottom);

            MainWindow.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(MainWindow_MouseLeftButtonUp);
            MainWindow.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
        }

        private void LoadNotes()
        {
            int count = 0;
            if(File.Exists("NotesFile"))
            {
                FileStream fs = new FileStream("NotesFile", FileMode.Open);
                if (fs != null)
                {
                    int contentIndicator;
                    double height;
                    double Width;
                    double x;
                    double y;
                    bool topmost;
                    int backgroundColorIndex;
                    int foregroundColorIndex;
                    DateTime alarmTime;
                    string loadRepeatNumber;

                    StreamReader reader = new StreamReader(fs);
                    string str = reader.ReadLine();
                    ExtractValues(out contentIndicator, str, out height, out Width, out x, out y, out topmost, out backgroundColorIndex, out foregroundColorIndex, out alarmTime, out loadRepeatNumber);
                    MainWindow.Height = height;
                    MainWindow.Width = Width;
                    MainWindow.Top = y;
                    MainWindow.Left = x;
                    MainWindow.Topmost = topmost;

                     count = contentIndicator;
                    for (int i = 0; i < count; i++)
                    {
                        string line = reader.ReadLine();

                        ExtractValues(out contentIndicator, line, out height, out Width, out x, out y, out topmost, out backgroundColorIndex, out foregroundColorIndex, out alarmTime, out loadRepeatNumber);

                        string filename = i.ToString();
                        filename = filename.Trim();

                        Window2 w2 = new Window2();
                        w2.Title = "Sticky Note";
                        w2.Tag = _arraySize;

                        w2.Height = height;
                        w2.Width = Width;
                        w2.Left = x;
                        w2.Top = y;
                        w2.ShowInTaskbar = false;
                        w2.Topmost = topmost;
                        w2.TopmostWindow = topmost;
                        if (w2.Topmost)
                        {
                            try
                            {
                                MenuItem m = LogicalTreeHelper.FindLogicalNode(w2, "AlwaysOnTop") as MenuItem;
                                m.IsChecked = true;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        if (backgroundColorIndex > -1)
                        {
                            w2.Background = Window2.ChangeBackgroundColor(Dialog.colorArray[backgroundColorIndex]);
                            w2.BackgroundColorIndex = backgroundColorIndex;
                        }
                        if (foregroundColorIndex > -1)
                        {
                            w2.Foreground = Dialog.colorArrayForeground[foregroundColorIndex];
                            w2.ForegroundColorIndex = foregroundColorIndex;
                        }
                        w2.Alarm = alarmTime;
                        if (loadRepeatNumber.Contains("null"))
                        {
                            w2.RepetitionNumber = "null";
                        }
                        else
                        {
                            w2.RepetitionNumber = loadRepeatNumber;
                        }


                        CheckIfAlarmFires(w2);

                        windowArray[_arraySize] = w2;
                        ArrayPos++;

                        FileStream noteFiles = new FileStream(filename, FileMode.Open);

                        RichTextBox rtb = ((RichTextBox)((StackPanel)(w2.Content)).Children[1]);
                        TextRange tr = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                        try
                        {
                            if (contentIndicator == 0)
                            {
                                tr.Load(noteFiles, DataFormats.XamlPackage);
                            }
                            else
                            {
                                tr.Load(noteFiles, DataFormats.Xaml);
                            }
                        }
                        catch (Exception) { }
                        noteFiles.Close();
                    }
                    fs.Close();
                }
            }
            for (int i = ++count; i < 100; i++)
            {
                if(File.Exists(i.ToString()))
                {
                    File.Delete(i.ToString());
                }
            }

           
        }

        private void ExtractValues(out int contentIndicator, string line, out double height, out double Width, out double x, out double y, out bool topmost, out int backgroundColorIndex, out int foregroundColorIndex, out DateTime alarmTime, out string loadRepeatNumber)
        {
            int index = line.IndexOf('|');
            string firstToken = line.Substring(0, index);
            contentIndicator = Int32.Parse(firstToken);

            int tail = index + 1;
            index = line.IndexOf('|', tail);
            y = GetStoredValues(line, index, tail);

            tail = index + 1;
            index = line.IndexOf('|', tail);
            x = GetStoredValues(line, index, tail);

            tail = index + 1;
            index = line.IndexOf('|', tail);
            height = GetStoredValues(line, index, tail);

            tail = index + 1;
            index = line.IndexOf('|', tail);
            Width = GetStoredValues(line, index, tail);

            tail = index + 1;
            index = line.IndexOf('|', tail);
            string token = line.Substring(tail, (index - tail));
            topmost = (token.Contains(bool.TrueString)) ? true : false;

            tail = index + 1;
            index = line.IndexOf('|', tail);
            token = line.Substring(tail, (index - tail));
            backgroundColorIndex = Int32.Parse(token);

            tail = index + 1;
            index = line.IndexOf('|', tail); //line.Length;
            token = line.Substring(tail, (index - tail));
            foregroundColorIndex = Int32.Parse(token);

            tail = index + 1;
            index = line.IndexOf(':', tail);
            token = line.Substring(tail, (index - tail));
            int Hours = Int32.Parse(token);

            tail = index + 1;
            index = line.IndexOf(':', tail);
            token = line.Substring(tail, (index - tail));
            int Minutes = Int32.Parse(token);

            tail = index + 1;
            index = line.IndexOf('|', tail);
            token = line.Substring(tail, (index - tail));
            int Seconds = (int)Double.Parse(token) ;

            tail = index + 1;
            index = line.IndexOf('/', tail);
            token = line.Substring(tail, (index - tail));
             int Month = Int32.Parse(token);

            tail = index + 1;
            index = line.IndexOf('/', tail);
            token = line.Substring(tail, (index - tail));
            int Day = Int32.Parse(token);

            tail = index + 1;
            index = line.IndexOf('|', tail);
            token = line.Substring(tail, (index - tail));
            int Year = Int32.Parse(token);


            alarmTime = new DateTime(Year, Month, Day, Hours, Minutes, Seconds);

            tail = index + 1;
            index = line.Length;
            loadRepeatNumber = line.Substring(tail, (index - tail));

            return ;
        }

        private double GetStoredValues(string line, int index, int tail)
        {
            string token = line.Substring(tail, (index - tail));
            return double.Parse(token);
        }


        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            string[] contentIndicator = new string[ArrayPos];

            int index = 0;

            for(int i=0;i<ArrayPos;i++)
            {
                
                if (windowArray[i] != null)
                {

                    Window2 w = ((Window2)(windowArray[i]));
                    RichTextBox rtb = ((RichTextBox)(((StackPanel)(w.Content)).Children[1]));
                    TextRange tr = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);

                    MemoryStream mstream = new MemoryStream();
                    XamlWriter.Save(rtb.Document, mstream);
                    mstream.Seek(0, SeekOrigin.Begin);
                    StreamReader stringReader = new StreamReader(mstream);
                    string str = stringReader.ReadToEnd();
                    stringReader.Close();

                    FileStream fs = new FileStream(index.ToString(), FileMode.Create);
                    double width = (w.ActualWidth > 50) ? (w.ActualWidth) : 200;
                    double height = (w.ActualHeight > 60) ? w.ActualHeight : 200;
                    if (str.Contains("payload"))
                    {
                        contentIndicator[index] = "0 |" + w.Top.ToString() + "|" + w.Left.ToString() + "|" + height.ToString() + "|" + width.ToString() + "|" + w.Topmost.ToString()+
                            "|" + w.BackgroundColorIndex.ToString() + "|" + w.ForegroundColorIndex.ToString() + "|" + w.Alarm.TimeOfDay.ToString() + "|" + w.Alarm.Date.ToShortDateString() +
                            "|"+ w.RepetitionNumber;
                        tr.Save(fs, DataFormats.XamlPackage);
                       
                    }
                    else
                    {
                        contentIndicator[index] = "1 |" + w.Top.ToString() + "|" + w.Left.ToString() + "|" + height.ToString() + "|" + width.ToString() + "|" + w.Topmost.ToString() +
                             "|" + w.BackgroundColorIndex.ToString() + "|" + w.ForegroundColorIndex.ToString() + "|" + w.Alarm.TimeOfDay.ToString() + "|" + w.Alarm.Date.ToShortDateString() +
                             "|" + w.RepetitionNumber;  
                        tr.Save(fs, DataFormats.Xaml);
                    }
                    index++;                    
                    fs.Close();
                    ((Window2)(windowArray[i])).Close();
                }
            }

            if (File.Exists("NotesFile"))
            {
                File.Delete("NotesFile");
            }
            FileStream MainDataFile = new FileStream("NotesFile", FileMode.OpenOrCreate);
            StreamWriter _writer = new StreamWriter(MainDataFile);
            _writer.WriteLine(index.ToString() + "|" + MainWindow.Top.ToString() + "|" + MainWindow.Left.ToString() + "|" + MainWindow.ActualHeight.ToString() + "|" + MainWindow.ActualWidth.ToString() + "|" +
                MainWindow.Topmost.ToString() + "|-1" + "|-1" + "|" + DateTime.Now.TimeOfDay.ToString() + "|" + DateTime.Now.Date.ToShortDateString() +"|null");
            for (int i = 0; i < index; i++)
            {
                _writer.WriteLine(contentIndicator[i]);
            }
            _writer.Close();
            MainDataFile.Close();
        }

        void AlarmTimer_Tick(object sender, EventArgs e)
        {
            int index = 0;
            windowContents = new string[ArrayPos]; 
            for (int i = 0; i < ArrayPos; i++)
            {
                if (windowArray[i] != null)
                {
                    Window2 w = ((Window2)(windowArray[i]));
                    StoreContents(index++);
                    CheckIfAlarmFires(w);
                }
            }

            WriteNotesFile(index);
        }

        private static void CheckIfAlarmFires(Window2 w)
        {
            DateTime current = DateTime.Now;
            MenuItem m = LogicalTreeHelper.FindLogicalNode(w, "AlwaysOnTop") as MenuItem;
            MenuItem m1 = LogicalTreeHelper.FindLogicalNode(w, "alarm") as MenuItem;
            MenuItem m3 = LogicalTreeHelper.FindLogicalNode(w, "DismissAlarm") as MenuItem;
            DateTime alarm = w.Alarm;

            System.Windows.Controls.Image m2 = LogicalTreeHelper.FindLogicalNode(w, "AlarmIndicator") as System.Windows.Controls.Image;
            m2.Visibility = (alarm.CompareTo(DateTime.Now) >= 0) ? (Visibility.Visible) : (Visibility.Hidden);

            if (w.RepetitionNumber.Contains("null") == false)
            {
                if ((alarm.CompareTo(current) < 0)&&
                    (!(((current.TimeOfDay.Hours - alarm.TimeOfDay.Hours) <8)&& ((current.TimeOfDay.Hours - alarm.TimeOfDay.Hours) >=0)) 
                                    || !(current.Date.ToShortDateString().Contains( alarm.Date.ToShortDateString()))))
                {
                    char[] chArr = w.RepetitionNumber.ToCharArray(0, 1);
                    string val = w.RepetitionNumber.Substring(1);
                    int repetitionValue = Int32.Parse(val);
                    switch (chArr[0])
                    {
                        case 'W':
                            while (w.Alarm.Date.CompareTo(current.Date) < 0)
                            {
                                w.Alarm = w.Alarm.AddDays(7 * repetitionValue);
                            }

                            break;

                        case 'D':
                            while (w.Alarm.Date.CompareTo(current.Date) < 0)
                            {
                                w.Alarm = w.Alarm.AddDays(repetitionValue);
                            }
                            break;

                        default:
                            break;
                    }
                    alarm = w.Alarm;
                }
            }

            if (alarm.Date == current.Date)
            {
                DateTime temp1 = alarm;
                DateTime temp2 = current;
                temp1 = temp1.AddMinutes(30);
                temp2 = temp2.AddMinutes(30);
                
                if ((temp2.CompareTo(alarm)>=0) && (temp1.CompareTo(current)>=0) &&(w.AlarmDismissed == false))
                {
                    w.Topmost = true;
                    m.IsChecked = true;
                    m1.IsEnabled = true;
                    m3.IsEnabled = true;
                    m2.Visibility = Visibility.Visible;

                    w.BorderBrush = System.Windows.Media.Brushes.Black;
                    w.BorderThickness = new Thickness(5);
                }
                else if(((current.TimeOfDay.Hours - alarm.TimeOfDay.Hours) <8)&&
                    ((current.TimeOfDay.Hours - alarm.TimeOfDay.Hours) >=0))
                {

                    w.Topmost = w.TopmostWindow;
                    m.IsChecked = w.Topmost;
                    m1.IsEnabled = (w.RepetitionNumber.Contains("null")) ? false : true;
                    m2.Visibility = (m1.IsEnabled==true)?(Visibility.Visible):(Visibility.Hidden);
                    m3.IsEnabled = false;
                    w.BorderBrush = System.Windows.Media.Brushes.Tomato;
                    w.BorderThickness = new Thickness(3);
                }
                else
                {
                    w.AlarmDismissed = false;
                    m3.IsEnabled = false;
                    m1.IsEnabled = (w.RepetitionNumber.Contains("null")) ? false : true;
                    m2.Visibility = (m1.IsEnabled == true) ? (Visibility.Visible) : (Visibility.Hidden);
                }

            }
            else
            {
                w.Topmost = w.TopmostWindow;
                m.IsChecked = w.Topmost;
                m1.IsEnabled = (w.RepetitionNumber.Contains("null")) ? false : true;
                m2.Visibility = (m1.IsEnabled == true) ? (Visibility.Visible) : (Visibility.Hidden);
                m3.IsEnabled = false;

                w.BorderBrush = System.Windows.Media.Brushes.Transparent;
                w.BorderThickness = new Thickness(0);
            }
        }

        void MainWindow_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.Title = "Sticky Note";
            w2.Tag = _arraySize;
            windowArray[_arraySize] = w2;
            ArrayPos++;

        }


        private void StoreContents(int index)
        {
            Window2 w = ((Window2)(windowArray[index]));
            RichTextBox rtb = ((RichTextBox)(((StackPanel)(w.Content)).Children[1]));
            TextRange tr = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);

            MemoryStream mstream = new MemoryStream();
            XamlWriter.Save(rtb.Document, mstream);
            mstream.Seek(0, SeekOrigin.Begin);
            StreamReader stringReader = new StreamReader(mstream);
            string str = stringReader.ReadToEnd();
            stringReader.Close();

            FileStream fs = new FileStream(index.ToString(), FileMode.Create);
                    double width = (w.ActualWidth > 50) ? (w.ActualWidth) : 200;
                    double height = (w.ActualHeight > 60) ? w.ActualHeight : 200;
                    if (str.Contains("payload"))
                    {
                        windowContents[index] = "0 |" + w.Top.ToString() + "|" + w.Left.ToString() + "|" + height.ToString() + "|" + width.ToString() + "|" + w.Topmost.ToString()+
                            "|" + w.BackgroundColorIndex.ToString() + "|" + w.ForegroundColorIndex.ToString() + "|" + w.Alarm.TimeOfDay.ToString() + "|" + w.Alarm.Date.ToShortDateString() +
                            "|"+ w.RepetitionNumber;
                        tr.Save(fs, DataFormats.XamlPackage);
                       
                    }
                    else
                    {
                        windowContents[index] = "1 |" + w.Top.ToString() + "|" + w.Left.ToString() + "|" + height.ToString() + "|" + width.ToString() + "|" + w.Topmost.ToString() +
                             "|" + w.BackgroundColorIndex.ToString() + "|" + w.ForegroundColorIndex.ToString() + "|" + w.Alarm.TimeOfDay.ToString() + "|" + w.Alarm.Date.ToShortDateString() +
                             "|" + w.RepetitionNumber;  
                        tr.Save(fs, DataFormats.Xaml);
                    }
            fs.Close();
        }

        private void WriteNotesFile(int index)
        {
            if (File.Exists("NotesFile"))
            {
                File.Delete("NotesFile");
            }
            FileStream MainDataFile = new FileStream("NotesFile", FileMode.Create);
            StreamWriter _writer = new StreamWriter(MainDataFile);
            _writer.WriteLine(index.ToString() + "|" + MainWindow.Top.ToString() + "|" + MainWindow.Left.ToString() + "|" + MainWindow.ActualHeight.ToString() + "|" + MainWindow.ActualWidth.ToString() + "|" +
                MainWindow.Topmost.ToString() + "|-1" + "|-1" + "|" + DateTime.Now.TimeOfDay.ToString() + "|" + DateTime.Now.Date.ToShortDateString() + "|null");
            for (int i = 0; i < index; i++)
            {
                _writer.WriteLine(windowContents[i]);
            }
            _writer.Close();
        }

        public int ArrayPos
        {
            get
            {
                return _arraySize;
            }
            
            set
            {
                _arraySize = value;
            }
        }


        public object[] WindowArray
        {
            get
            {
                return windowArray;
            }
        }


        // Sample event handler:  
        private void CloseButtonClick(object sender, RoutedEventArgs e) 
        {
            MainWindow.Close();
            
        }

        void cb_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            MainWindow.Topmost = (cb.IsChecked == true) ? true : false;
            MainWindow.Focus();
        }

        void l_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            cb.IsChecked = !cb.IsChecked;
            MainWindow.Topmost = (cb.IsChecked == true) ? true : false;
        }


        private System.Windows.Threading.DispatcherTimer TimerClock;
        private System.Windows.Threading.DispatcherTimer AlarmTimer;
        private object[] windowArray = null;
        private int _arraySize = 0;
        string[] windowContents;


    }
}