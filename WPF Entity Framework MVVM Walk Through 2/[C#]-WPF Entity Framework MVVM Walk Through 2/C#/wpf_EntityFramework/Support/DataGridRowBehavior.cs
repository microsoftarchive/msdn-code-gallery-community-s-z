using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;

namespace wpf_EntityFramework
{ 
   /// <summary>
   ///  Attached Behavior
   ///  Somewhat trickier than a regular behavior because it's to be attached via a style 
   /// </summary>
    class DataGridRowBehavior : Behavior<DataGridRow>
    {
        public static bool GetIsDataGridRowFocussedWhenSelected(DataGridRow dataGridRow)
        {
            return (bool)dataGridRow.GetValue(IsDataGridRowFocussedWhenSelectedProperty);
        }

        public static void SetIsDataGridRowFocussedWhenSelected(
          DataGridRow dataGridRow, bool value)
        {
            dataGridRow.SetValue(IsDataGridRowFocussedWhenSelectedProperty, value);
        }

        public static readonly DependencyProperty IsDataGridRowFocussedWhenSelectedProperty =
            DependencyProperty.RegisterAttached(
            "IsDataGridRowFocussedWhenSelected",
            typeof(bool),
            typeof(DataGridRowBehavior),
            new UIPropertyMetadata(false, OnIsDataGridRowFocussedWhenSelectedChanged));

        static void OnIsDataGridRowFocussedWhenSelectedChanged(
          DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            DataGridRow item = depObj as DataGridRow;
            if (item == null)
                return;

            if (e.NewValue is bool == false)
                return;

            if ((bool)e.NewValue)
                item.Selected += OndataGridRowSelected;
            else
                item.Selected -= OndataGridRowSelected;
        }
        static void OndataGridRowSelected(object sender, RoutedEventArgs e)
        {
            DataGridRow row = e.OriginalSource as DataGridRow;
            // If focus is already on a cell then don't focus back out of it
            if (!(Keyboard.FocusedElement is DataGridCell) && row != null)
            {
                row.Focusable = true;
                Keyboard.Focus(row);
            }
        }

    }
}



