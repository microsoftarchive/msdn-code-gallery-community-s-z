//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: PizzaSizeCircle.xaml.cs
//
//--------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Controls;

namespace AcmePizza
{
    /// <summary>
    /// Interaction logic for PizzaSizeCircle.xaml
    /// </summary>
    public partial class PizzaSizeCircle : UserControl
    {

        public PizzaSizeCircle()
        {
            InitializeComponent();
        }

        public int PizzaSize
        {
            get
            {
                return (int)this.GetValue(PizzaSizeProperty);
            }
            set
            {
                this.SetValue(PizzaSizeProperty, value);
         
            }
        }

        static void PizzaSizeChangedCallBack(DependencyObject property, DependencyPropertyChangedEventArgs args)
        {
            var control = (PizzaSizeCircle)property;
            switch ((int)args.NewValue)
            {
                case 11:
                    control.circle.Width = 30;
                    control.circle.Height = 30;
                    control.layoutRoot.Width = 30;
                    control.layoutRoot.Height = 30;
                    control.label.Text = "11";
                    break;
                case 13:
                    control.circle.Width = 50;
                    control.circle.Height = 50;
                    control.layoutRoot.Width = 50;
                    control.layoutRoot.Height = 50;
                    control.label.Text = "13";
                    break;
                case 17:
                    control.circle.Width = 75;
                    control.circle.Height = 75;
                    control.layoutRoot.Width = 75;
                    control.layoutRoot.Height = 75;
                    control.label.Text = "17";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static readonly DependencyProperty PizzaSizeProperty =
            DependencyProperty.Register("PizzaSize", typeof(int), typeof(PizzaSizeCircle),
            new UIPropertyMetadata(17, new PropertyChangedCallback(PizzaSizeChangedCallBack)));
        
    }
}
