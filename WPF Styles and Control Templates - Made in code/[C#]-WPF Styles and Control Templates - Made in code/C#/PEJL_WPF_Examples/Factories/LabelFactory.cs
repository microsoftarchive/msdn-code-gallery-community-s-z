using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace PEJL_WPF_Examples.Factories
{
    class LabelFactory
    {
        public static Label MakeLabel()
        {
            var label = new Label
            {
                Style = MakeLabelStyle1()
            };

            return label;
        }

        private static System.Windows.Style MakeLabelStyle1()
        {
            ControlTemplate template = new ControlTemplate
            {
                TargetType = typeof(Label),
            };

            var border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(Control.BorderBrushProperty, new TemplateBindingExtension(Control.BorderBrushProperty));
            border.SetValue(Control.BorderThicknessProperty, new TemplateBindingExtension(Control.BorderThicknessProperty));
            border.SetValue(Control.BackgroundProperty, new TemplateBindingExtension(Control.BackgroundProperty));
            border.SetValue(Control.PaddingProperty, new TemplateBindingExtension(Control.PaddingProperty));
            border.SetValue(Control.SnapsToDevicePixelsProperty, new TemplateBindingExtension(Control.SnapsToDevicePixelsProperty));

            var contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.SetValue(FrameworkElement.HorizontalAlignmentProperty, new TemplateBindingExtension(Control.HorizontalContentAlignmentProperty));
            contentPresenter.SetValue(ContentPresenter.RecognizesAccessKeyProperty, true);
            contentPresenter.SetValue(UIElement.SnapsToDevicePixelsProperty, new TemplateBindingExtension(UIElement.SnapsToDevicePixelsProperty));
            contentPresenter.SetValue(FrameworkElement.VerticalAlignmentProperty, new TemplateBindingExtension(Control.VerticalContentAlignmentProperty));

            border.AppendChild(contentPresenter);
            template.VisualTree = border;

            var t1 = new Trigger { Property = UIElement.IsEnabledProperty, Value = false };
            t1.Setters.Add(new Setter(Label.ForegroundProperty, new DynamicResourceExtension(SystemColors.GrayTextBrushKey))); //Note Control will do here, the lowest inherited class will do

            template.Triggers.Add(t1);

            var style = new Style();

            style.Setters.Add(new Setter(Control.ForegroundProperty, new DynamicResourceExtension(SystemColors.ControlTextBrushKey)));
            style.Setters.Add(new Setter(FrameworkElement.FocusVisualStyleProperty, new DynamicResourceExtension("ButtonFocusVisual")));
            style.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.Transparent));
            style.Setters.Add(new Setter(Control.PaddingProperty, new Thickness(5)));
            style.Setters.Add(new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Left));
            style.Setters.Add(new Setter(Control.VerticalContentAlignmentProperty, VerticalAlignment.Top));

            style.Setters.Add(new Setter(Control.TemplateProperty, template));

            return style;
        }
    }
}
