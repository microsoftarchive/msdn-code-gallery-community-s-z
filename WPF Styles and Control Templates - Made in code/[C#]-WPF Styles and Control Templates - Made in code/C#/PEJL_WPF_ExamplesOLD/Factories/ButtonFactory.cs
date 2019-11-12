using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using Microsoft.Windows.Themes;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;

namespace PEJL_WPF_Examples.Factories
{
    class ButtonFactory
    {
        IndicatorsViewModel indicatorsViewModel;

        public Button Make_Button(IndicatorsViewModel ivm, object content)
        {
            indicatorsViewModel = ivm;

            var butt = new Button
            {
                Content = content,
                Style = MakeButtonStyle1()
            };

            return butt;
        }

        Style MakeButtonStyle1()
        {
            ControlTemplate template = new ControlTemplate
            {
                TargetType = typeof(Button),
            };

            var butt = new FrameworkElementFactory(typeof(Microsoft.Windows.Themes.ButtonChrome), "Chrome"); // Name is used in template triggers
            butt.SetValue(Control.BorderBrushProperty, new TemplateBindingExtension(Control.BorderBrushProperty)); // Tested in MainWindow.xaml.cs
            butt.SetValue(Control.BackgroundProperty, new TemplateBindingExtension(Control.BackgroundProperty)); 
            butt.SetValue(Microsoft.Windows.Themes.ButtonChrome.RenderMouseOverProperty, new TemplateBindingExtension(UIElement.IsMouseOverProperty));
            butt.SetValue(Microsoft.Windows.Themes.ButtonChrome.RenderPressedProperty, new TemplateBindingExtension(ButtonBase.IsPressedProperty));
            butt.SetValue(Microsoft.Windows.Themes.ButtonChrome.RenderDefaultedProperty, new TemplateBindingExtension(Button.IsDefaultedProperty));
            butt.SetValue(UIElement.SnapsToDevicePixelsProperty, true);
            
            var contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.SetValue(FrameworkElement.HorizontalAlignmentProperty, new TemplateBindingExtension(Control.HorizontalContentAlignmentProperty));
            contentPresenter.SetValue(FrameworkElement.SnapsToDevicePixelsProperty, new TemplateBindingExtension(UIElement.SnapsToDevicePixelsProperty));
            contentPresenter.SetValue(FrameworkElement.VerticalAlignmentProperty, new TemplateBindingExtension(Control.VerticalContentAlignmentProperty));
            contentPresenter.SetValue(FrameworkElement.MarginProperty, new TemplateBindingExtension(Control.PaddingProperty));
            contentPresenter.SetValue(ContentPresenter.RecognizesAccessKeyProperty, true);

            butt.AppendChild(contentPresenter);
            template.VisualTree = butt;

            var t1 = new Trigger { Property = UIElement.IsKeyboardFocusedProperty, Value = true };
            t1.Setters.Add(new Setter(Microsoft.Windows.Themes.ButtonChrome.RenderDefaultedProperty, true, "Chrome")); //Note Button won't do here, this is only a property of Microsoft.Windows.Themes.ButtonChrome
            var t2 = new Trigger { Property = UIElement.IsKeyboardFocusedProperty, Value = true };
            t1.Setters.Add(new Setter(ToggleButton.IsCheckedProperty, true)); // An attached property
            var t3 = new Trigger { Property = UIElement.IsKeyboardFocusedProperty, Value = true };
            t1.Setters.Add(new Setter(UIElement.IsEnabledProperty, true, "Chrome")); //Note Control will do here, the lowest inherited class will do

            template.Triggers.Add(t1);
            template.Triggers.Add(t2);
            template.Triggers.Add(t3);

            var style = new Style();

            //style.Setters.Add(new Setter(Button.FocusVisualStyleProperty, new StaticResourceExtension(("ButtonFocusVisual"))));
            //{"'StaticResourceExtension' is not valid for Setter.Value. The only supported MarkupExtension types are DynamicResourceExtension and BindingBase or derived types."}
            style.Setters.Add(new Setter(FrameworkElement.FocusVisualStyleProperty, new DynamicResourceExtension("ButtonFocusVisual")));
            style.Setters.Add(new Setter(Control.BackgroundProperty, new DynamicResourceExtension("ButtonNormalBackground")));
            style.Setters.Add(new Setter(Control.BorderBrushProperty, new DynamicResourceExtension("ButtonNormalBorder")));
            style.Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(1)));
            style.Setters.Add(new Setter(Control.ForegroundProperty, new DynamicResourceExtension(SystemColors.ControlTextBrushKey)));
            style.Setters.Add(new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
            style.Setters.Add(new Setter(Control.VerticalContentAlignmentProperty, VerticalAlignment.Center));
            style.Setters.Add(new Setter(Control.PaddingProperty, new Thickness(1)));

            style.Setters.Add(new Setter(Control.TemplateProperty, template));

            AddResources(style);

            return style;
        }

        Style MakeButtonFocusVisualStyle()
        {
            ControlTemplate template = new ControlTemplate { }; //Notice no TargetType

            var rec = new FrameworkElementFactory(typeof(Rectangle));
            rec.SetValue(Shape.MarginProperty, new Thickness(2));
            rec.SetValue(Shape.StrokeProperty, new DynamicResourceExtension(SystemColors.ControlTextBrushKey));
            rec.SetValue(Shape.StrokeThicknessProperty, 1.0D);
            rec.SetValue(Shape.StrokeDashArrayProperty, new DoubleCollection{ 1.0D, 2.0D }); //Interesting property makes the focus visual dashes

            template.VisualTree = rec;

            var style = new Style();
            style.Setters.Add(new Setter(Control.TemplateProperty, template)); //attached?

            return style;
        }

        void AddResources(Style style)
        {
            var b1 = new LinearGradientBrush
            {
                EndPoint = new Point(0, 1),
                StartPoint = new Point(0, 0),
                GradientStops = new GradientStopCollection
                {
                    new GradientStop(Color.FromArgb(0xFF, 0xF3, 0xF3, 0xF3), 0.0D), // Notice Expression xaml (in App.Resources) drops the alpha channel, in its notation
                    new GradientStop(Color.FromArgb(0xFF, 0xEB, 0xEB, 0xEB), 0.5D),
                    new GradientStop(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD), 0.5D),
                    new GradientStop(Color.FromArgb(0xFF, 0xCD, 0xCD, 0xCD), 1.0D),
                }
            };
            style.Resources.Add("ButtonNormalBackground", b1);

            var b2 = new SolidColorBrush { Color = Color.FromArgb(0xFF, 0x70, 0x70, 0x70) }; // Blend does not drop alpha channel in its notation for this one (see App.resources)
            style.Resources.Add("ButtonNormalBorder", b2);

            style.Resources.Add("ButtonFocusVisual", MakeButtonFocusVisualStyle());
        }
    }
}
