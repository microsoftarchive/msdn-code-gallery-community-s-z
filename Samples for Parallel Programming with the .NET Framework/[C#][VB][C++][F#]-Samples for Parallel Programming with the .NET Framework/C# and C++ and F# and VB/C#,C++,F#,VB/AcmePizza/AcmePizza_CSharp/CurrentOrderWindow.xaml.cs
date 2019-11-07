//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: CurrentOrderWindow.xaml.cs
//
//--------------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace AcmePizza
{
    /// <summary>
    /// Interaction logic for CurrentOrder.xaml
    /// </summary>
    public partial class CurrentOrderWindow : Window
    {
        private ObservableCollection<PizzaOrder> m_currentOrder;

        public CurrentOrderWindow(PizzaOrder order)
        {
            InitializeComponent();
            // show the current order by binding to a collection of one.
            m_currentOrder = new ObservableCollection<PizzaOrder>();
            this.DataContext = m_currentOrder;
            m_currentOrder.Add(order);
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

    }
}
