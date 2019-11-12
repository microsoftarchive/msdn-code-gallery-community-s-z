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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace TCD.Controls.Keyboard
{
    public class BoolToSolidBrushConverter : IValueConverter
    {
        /// <summary>
        /// Convert from source-type to target-type
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, string str)
        {
            if ((bool)value)
            {
                return new SolidColorBrush(Windows.UI.Color.FromArgb(128, 128, 128, 128));
            }
            else
            {
                return new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 128, 128));
            }
        }

        /// <summary>
        /// Convert-back from target to source.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, string str)
        {
            return null;
        }
    }
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string str)
        {
            switch (parameter as string)
            {
                case "VisibleIfTrue": return (bool)value == true ? Visibility.Visible : Visibility.Collapsed;
                case "CollapsedIfTrue": return (bool)value == true ? Visibility.Collapsed : Visibility.Visible;
                default: return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string str)
        {
            return null;
        }
    }
}
