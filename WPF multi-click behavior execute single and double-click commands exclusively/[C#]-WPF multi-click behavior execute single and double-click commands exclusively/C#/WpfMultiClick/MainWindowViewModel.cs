using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using winForms = System.Windows.Forms;

namespace WpfMultiClick
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            this.DoubleClickTime = winForms.SystemInformation.DoubleClickTime;
            this.ClickLog = new ObservableCollection<string>();

            this.SingleClick = new ClickedCommand((parameter) => {                
                this.ClickLog.Insert(0, parameter + " single-click");
            });

            this.DoubleClick = new ClickedCommand((parameter) =>
            {
                this.ClickLog.Insert(0, parameter + " double-click");
            });
        }        

        public int DoubleClickTime { get; set; }

        public ICommand SingleClick { get; set; }

        public ICommand DoubleClick { get; set; }

        public ObservableCollection<string> ClickLog { get; set; }
    }
}
