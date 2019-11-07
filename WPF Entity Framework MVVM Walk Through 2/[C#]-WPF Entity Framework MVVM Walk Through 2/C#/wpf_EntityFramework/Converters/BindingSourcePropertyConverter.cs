using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace wpf_EntityFramework
{
    public class BindingSourcePropertyConverter: IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            DataTransferEventArgs e = (DataTransferEventArgs)value;
            Type type = e.TargetObject.GetType();
            BindingExpression binding = ((FrameworkElement)e.TargetObject).GetBindingExpression(e.Property);
            return binding.ResolvedSourcePropertyName ?? "";
        }
    }
}
