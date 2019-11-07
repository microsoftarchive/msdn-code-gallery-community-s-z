/**
    Copyright(c) Microsoft Open Technologies, Inc.All rights reserved.
    Modified by Michael Osthege (2016)
   The MIT License(MIT)
    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files(the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions :
    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
**/

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TCD.Controls.Keyboard
{
    public partial class OnScreenKeyBoard : UserControl
    {
        #region Properties
        public object Host { get; set; }
        
        public KeyboardLayouts InitialLayout
        {
            get { return (this.DataContext as KeyboardViewModel).Layout; }
            set { (this.DataContext as KeyboardViewModel).Layout = value; }
        }
        public static readonly DependencyProperty InitialLayoutProperty = DependencyProperty.Register("InitialLayout", typeof(KeyboardLayouts), typeof(OnScreenKeyBoard), new PropertyMetadata(KeyboardLayouts.English));
        #endregion

        public OnScreenKeyBoard()
        {
            DataContext = new KeyboardViewModel(this);
            InitializeComponent();
        }

        public void RegisterTarget(TextBox control)
        {
            RegisterBox(control);
        }
        public void RegisterTarget(PasswordBox control)
        {
            RegisterBox(control);
        }
        private void RegisterBox(Control control)
        {
            control.GotFocus += delegate { (DataContext as KeyboardViewModel).TargetBox = control; System.Diagnostics.Debug.WriteLine("focused"); };
            control.LostFocus += delegate { (DataContext as KeyboardViewModel).TargetBox = null; };
        }
        
    }
}

