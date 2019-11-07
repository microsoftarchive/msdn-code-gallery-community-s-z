//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.Controls
{
    using System.Windows;

    public static class MetroButtonProperties
    {
        public static readonly DependencyProperty LabelProperty = DependencyProperty.RegisterAttached(
            "Label",
            typeof(string),
            typeof(MetroButtonProperties),
            new UIPropertyMetadata("Untitled"));

        public static readonly DependencyProperty ContentFontSizeProperty = DependencyProperty.RegisterAttached(
            "ContentFontSize",
            typeof(double),
            typeof(MetroButtonProperties),
            new UIPropertyMetadata(28.0));

        public static string GetLabel(DependencyObject obj)
        {
            return (string)obj.GetValue(LabelProperty);
        }

        public static void SetLabel(DependencyObject obj, string value)
        {
            obj.SetValue(LabelProperty, value);
        }

        public static double GetContentFontSize(DependencyObject obj)
        {
            return (double)obj.GetValue(ContentFontSizeProperty);
        }

        public static void SetContentFontSize(DependencyObject obj, double value)
        {
            obj.SetValue(ContentFontSizeProperty, value);
        }
    }
}
