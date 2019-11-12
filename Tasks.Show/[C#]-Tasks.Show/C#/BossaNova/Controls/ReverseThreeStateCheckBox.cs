using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel;

namespace Tasks.Show.Controls
{
    // Thanks! http://dutchmarcel.wordpress.com/2009/10/21/the-three-state-checkbox/

    public class ReverseThreeStateCheckBox :CheckBox
    {
        protected override void OnToggle()
        {
            if (this.IsChecked == false)
            {
                this.IsChecked = this.IsThreeState ? null : ((bool?)true);
            }
            else
            {
                this.IsChecked = new bool?(!this.IsChecked.HasValue);
            }
        }
    }
}
