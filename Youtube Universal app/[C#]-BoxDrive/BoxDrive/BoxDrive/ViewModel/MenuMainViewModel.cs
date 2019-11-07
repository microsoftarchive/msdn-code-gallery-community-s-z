using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoxDrive.Model;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace BoxDrive.ViewModel
{
    public class MenuMainViewModel
    {
        List<MenuMain> _list = new List<MenuMain>();

        public List<MenuMain> TheResults { get; set; }
        

        public List<MenuMain> SetResults()
        {
           
            //_list.Clear();
            _list.Add(new MenuMain { Name = "Youtube", img_url = "/Assets/YouTube Play-64.png" });
           
            return _list;
        }
        public MenuMainViewModel()
        {
            this.TheResults= SetResults();
        }
    }
}
