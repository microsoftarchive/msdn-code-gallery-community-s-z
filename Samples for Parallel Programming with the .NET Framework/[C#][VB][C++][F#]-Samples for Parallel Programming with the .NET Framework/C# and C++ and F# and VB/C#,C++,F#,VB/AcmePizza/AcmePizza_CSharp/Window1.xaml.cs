//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Window1.xaml.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AcmePizza
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private IProducerConsumerCollection<PizzaOrder> m_orders;
        private static Random m_rand = new ThreadSafeRandom();

        public Window1()
        {
            InitializeComponent();

            // intialize the bindable collection and set it as the data context
            var orders = new ObservableConcurrentCollection<PizzaOrder>();
            // store the observable collection as an explicity producer consumer 
            // collection that has tryadd and tryremove operations
            m_orders = orders;
            // set the AcmePizza as the defaut
            this.DataContext = orders;
        }

        private void Window_Loaded(object sender, EventArgs e)
        {
            // launch four threads that mimic various sources
            Task.Factory.StartNew(() => { OrdererThread(OrderSource.Fax); }, TaskCreationOptions.AttachedToParent);
            Task.Factory.StartNew(() => { OrdererThread(OrderSource.Internet); }, TaskCreationOptions.AttachedToParent);
            Task.Factory.StartNew(() => { OrdererThread(OrderSource.Phone); }, TaskCreationOptions.AttachedToParent);
            Task.Factory.StartNew(() => { OrdererThread(OrderSource.WalkIn); }, TaskCreationOptions.AttachedToParent);
        }

        private void OrdererThread(OrderSource source)
        {
            for ( int i = 0; i < 10; ++i )
            {
                // submit random order
                m_orders.TryAdd( GenerateRandomOrder(source));
                // sleep for a random period
                Thread.Sleep(m_rand.Next(1000, 4001));
            }
        }

        private static PizzaOrder GenerateRandomOrder(OrderSource source)
        {
            // source
            var order = new PizzaOrder { Source = source };
            // delivery
            order.IsDelivery = m_rand.Next(0, 2) == 0 ? true : false;
            // phone number
            var areaCode = m_rand.Next(0, 2) == 0 ? 425 : 206;
            var firstThreeDigits = m_rand.Next(100, 1000);
            var lastFourDigits = m_rand.Next(0, 10000);
            order.PhoneNumber = String.Format("({0}) {1}-{2}", areaCode, firstThreeDigits, lastFourDigits.ToString("D4"));
            // size
            switch (m_rand.Next(0, 3))
            {
                case 0: order.Size = 11; break;
                case 1: order.Size = 13; break;
                case 2: order.Size = 17; break;
            }
            // toppings
            var availToppings = new List<PizzaToppings>(Enum.GetValues(typeof(PizzaToppings)).Cast<PizzaToppings>());
            order.Toppings = new PizzaToppings[m_rand.Next(1, 5)];
            for (int j = 0; j < order.Toppings.Length; ++j)
            {
                var toppingIndex = m_rand.Next(0, availToppings.Count);
                order.Toppings[j] = availToppings[toppingIndex];
                availToppings.RemoveAt(toppingIndex);
            }
            return order;
        }

        private void processNextOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // attempt to get an order from the queue
            PizzaOrder nextOrder;
            if ( !m_orders.TryTake( out nextOrder ) )
            {
                MessageBox.Show( "No orders available.  Please try again later.");
                return;
            }
            // if successful launch an order window
            var currentOrderWindow = new CurrentOrderWindow(nextOrder);
            currentOrderWindow.Show();
        }
    }
}