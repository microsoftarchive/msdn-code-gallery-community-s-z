using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using PEJL_WPF_Examples.Helpers;

namespace PEJL_WPF_Examples.Factories
{
    class CheckBoxFactory
    {
        public CheckBox MakeCheckBox(IndicatorsViewModel ivm, string bulletType)
        {
            var checkbox = new CheckBox
            {
                Style = MakeCheckBoxStyle(ivm, bulletType)
            };

            return checkbox;
        }

        private System.Windows.Style MakeCheckBoxStyle(IndicatorsViewModel ivm, string bulletType)
        {
            var template = new ControlTemplate { TargetType = typeof(CheckBox) };

            var bChrome = new FrameworkElementFactory(typeof(Microsoft.Windows.Themes.BulletChrome));
            bChrome.SetValue(Control.BorderBrushProperty, new TemplateBindingExtension(Control.BorderBrushProperty)); // Tested in MainWindow.xaml.cs
            bChrome.SetValue(Control.BackgroundProperty, new TemplateBindingExtension(Control.BackgroundProperty));
            bChrome.SetValue(Microsoft.Windows.Themes.BulletChrome.RenderMouseOverProperty, new TemplateBindingExtension(UIElement.IsMouseOverProperty));
            bChrome.SetValue(Microsoft.Windows.Themes.BulletChrome.RenderPressedProperty, new TemplateBindingExtension(ButtonBase.IsPressedProperty));
            bChrome.SetValue(ToggleButton.IsCheckedProperty, new TemplateBindingExtension(ToggleButton.IsCheckedProperty));

            var contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.SetValue(FrameworkElement.HorizontalAlignmentProperty, new TemplateBindingExtension(Control.HorizontalContentAlignmentProperty));
            contentPresenter.SetValue(FrameworkElement.MarginProperty, new TemplateBindingExtension(Control.PaddingProperty));
            contentPresenter.SetValue(ContentPresenter.RecognizesAccessKeyProperty, true);
            contentPresenter.SetValue(UIElement.SnapsToDevicePixelsProperty, new TemplateBindingExtension(UIElement.SnapsToDevicePixelsProperty));
            contentPresenter.SetValue(FrameworkElement.VerticalAlignmentProperty, new TemplateBindingExtension(Control.VerticalContentAlignmentProperty));

            var t1 = new Trigger { Property= ContentControl.HasContentProperty, Value=true };
            t1.Setters.Add(new Setter(FrameworkElement.FocusVisualStyleProperty, new DynamicResourceExtension("CheckRadioFocusVisual")));
            //This is related to Content, if this setter is wrong, you won't know till you use Content property
            t1.Setters.Add(new Setter(Control.PaddingProperty, new Thickness(4,0,0,0)));

            var t2 = new Trigger { Property= ContentControl.IsEnabledProperty, Value=false };
            t2.Setters.Add(new Setter(Control.ForegroundProperty, new DynamicResourceExtension(SystemColors.GrayTextBrushKey))); // Not DynamicResource as in xaml

            template.Triggers.Add(t1);
            template.Triggers.Add(t2);

            var bDecorator = new FrameworkElementFactory(typeof(BulletDecoratorByCode));
            bDecorator.SetValue(Control.BackgroundProperty, Brushes.Transparent);
            bDecorator.SetValue(UIElement.SnapsToDevicePixelsProperty, true);

            // Bullet Issue
            // http://msdn.microsoft.com/en-us/library/system.windows.frameworkelementfactory.aspx
            // not all of the template functionality is available when you create a template using this class. The recommended way to programmatically create a template is to load XAML from a string or a memory stream using the Load method of the XamlReader class.

            //bDecorator.SetValue(BulletDecorator.BulletProperty, cChrome);  // Bullet property is CLI, not DependancyProperty
            //
            bDecorator.SetValue(BulletDecoratorByCode.ActualBulletProperty, bulletType); 

            //bDecorator.AppendChild(bChrome);
            bDecorator.AppendChild(contentPresenter);
            template.VisualTree = bDecorator;

            var style = new Style { TargetType = typeof(CheckBox) };
            style.Setters.Add(new Setter(Control.ForegroundProperty, new DynamicResourceExtension(SystemColors.ControlTextBrushKey)));
            style.Setters.Add(new Setter(Control.BackgroundProperty, new DynamicResourceExtension("ButtonNormalBackground")));
            style.Setters.Add(new Setter(Control.BorderBrushProperty, new DynamicResourceExtension("ButtonNormalBorder")));
            style.Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(1)));
            style.Setters.Add(new Setter(FrameworkElement.FocusVisualStyleProperty, new DynamicResourceExtension("EmptyCheckBoxFocusVisual")));    
            style.Setters.Add(new Setter(Control.TemplateProperty, template));

            return style;
        }


        void AddResources(Style style)
        {
            var b1 = new SolidColorBrush { Color = Color.FromArgb(0xFF, 0xF4, 0xF4, 0xF4) }; // Blend does not drop alpha channel in its notation for this one (see App.resources)
            style.Resources.Add("CheckBoxFillNormal", b1);

            var b2 = new SolidColorBrush { Color = Color.FromArgb(0xFF, 0x8E, 0x8F, 0x8F) }; // Blend does not drop alpha channel in its notation for this one (see App.resources)
            style.Resources.Add("CheckBoxStroke", b2);

            style.Resources.Add("EmptyCheckBoxFocusVisual", MakeCheckBoxFocusVisual(true)); // Margin is only difference
            style.Resources.Add("CheckRadioFocusVisual", MakeCheckBoxFocusVisual(false));
        }

        private object MakeCheckBoxFocusVisual(bool isEmpty)
        {
            ControlTemplate template = new ControlTemplate { }; //Notice no TargetType

            var rec = new FrameworkElementFactory(typeof(Rectangle));
            rec.SetValue(Shape.MarginProperty, 
                isEmpty ? new Thickness(1)      // If empty
                : new Thickness(14,0,0,0));     // If not empty
            rec.SetValue(UIElement.SnapsToDevicePixelsProperty, true);
            rec.SetValue(Shape.StrokeProperty, new DynamicResourceExtension(SystemColors.ControlTextBrushKey));
            rec.SetValue(Shape.StrokeThicknessProperty, 1.0D);
            rec.SetValue(Shape.StrokeDashArrayProperty, new DoubleCollection { 1.0D, 2.0D }); //this  makes the focus visual dashes

            template.VisualTree = rec;

            var style = new Style();
            style.Setters.Add(new Setter(Control.TemplateProperty, template)); //attached?

            return style;
        }

        private object MakeCheckRadioFocusVisual()
        {
            throw new NotImplementedException();
        }


    }
}
