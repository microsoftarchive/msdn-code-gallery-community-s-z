using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows;

namespace DataTemplateSelectorApp
{
    public class Window1ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ISystemUser> _Users;
        public ObservableCollection<ISystemUser> Users { get { return _Users; } set { _Users = value; OnPropertyChanged("Users"); } }

        public Window1ViewModel()
        {
            this.Users = new ObservableCollection<ISystemUser>();

            Enterprise e1 = new Enterprise();
            e1.Name = "Macrozoft";
            e1.Partners.Add("William Mates");
            e1.Partners.Add("Stephen Ballger");
            e1.Phone ="+001 888 777-7777";
            e1.TalkTo = "Lara Surface";

            Enterprise e2 = new Enterprise();
            e2.Name = "Attle";
            e2.Partners.Add("Steven Mobs");
            e2.Partners.Add("Paul Vozmiak");
            e2.Phone = " +1 888 666-6666";
            e2.TalkTo = "MyPad Nano";

            Person p1 = new Person();
            p1.Name = "Renato Ucha";
            p1.Phone = "11 6699-6699";

            Person p2 = new Person();
            p2.Name = "Albert Mybrain";
            p2.Phone = "+31 777 444-4444";

            Person p3 = new Person();
            p3.Name = "Marak Borama";
            p3.Phone = "Restricted";

            this.Users.Add(p1);
            this.Users.Add(e1);
            this.Users.Add(e2);
            this.Users.Add(p2);
            this.Users.Add(p3);
        }

        #region INotifyPropertyChanged Members

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public class Class2IconConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is Enterprise)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"pack://application:,,,/Icons/company.png"));
                return bitmap;
            }

            if (value != null && value is Person)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(@"pack://application:,,,/Icons/person.png"));
                return bitmap;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class SystemUserTemplateSelection : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            DataTemplate dt = null;

            if (item is Person)
                dt = App.Current.MainWindow.FindResource("templatePerson") as DataTemplate;

            if (item is Enterprise)
                dt = App.Current.MainWindow.FindResource("templateCompany") as DataTemplate;

            return dt;
        }
    }

}
