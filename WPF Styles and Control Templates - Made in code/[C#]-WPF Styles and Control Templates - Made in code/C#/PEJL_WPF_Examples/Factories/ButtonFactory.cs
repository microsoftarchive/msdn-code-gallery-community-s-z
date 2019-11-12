using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media.Animation;

namespace PEJL_WPF_Examples.Factories
{
    class ButtonFactory
    {
        IndicatorsViewModel indicatorsViewModel;

        public Button Make_Button(IndicatorsViewModel ivm, bool isFlashy)
        {
            indicatorsViewModel = ivm;

            var butt = new Button
            {
                Style = MakeButtonStyle1()
            };

            if (isFlashy)
            {
                AddFlashyTemplate(butt);
                // Add the Attached Property Binding to the button
                butt.SetBinding(AttachedProperties.IsHighlightedProperty, new Binding { Source=ivm, Path=new PropertyPath("IsConfirmed") });
            }

            return butt;
        }

        Style MakeButtonStyle1()
        {
            ControlTemplate template = new ControlTemplate
            {
                TargetType = typeof(Button),
            };

            template.VisualTree = MakeButtonChrome();

            var t1 = new Trigger { Property = UIElement.IsKeyboardFocusedProperty, Value = true };
            t1.Setters.Add(new Setter(Microsoft.Windows.Themes.ButtonChrome.RenderDefaultedProperty, true, "Chrome")); //Note Button won't do here, this is only a property of Microsoft.Windows.Themes.ButtonChrome
            var t2 = new Trigger { Property = UIElement.IsKeyboardFocusedProperty, Value = true };
            t2.Setters.Add(new Setter(ToggleButton.IsCheckedProperty, true)); // An attached property
            var t3 = new Trigger { Property = UIElement.IsKeyboardFocusedProperty, Value = true };
            t3.Setters.Add(new Setter(UIElement.IsEnabledProperty, true, "Chrome")); //Note Control will do here, the lowest inherited class will do

            template.Triggers.Add(t1);
            template.Triggers.Add(t2);
            template.Triggers.Add(t3);

            var style = new Style();

            style.Setters.Add(new Setter(FrameworkElement.FocusVisualStyleProperty, new DynamicResourceExtension("ButtonFocusVisual")));
            style.Setters.Add(new Setter(Control.BackgroundProperty, new DynamicResourceExtension("ButtonNormalBackground")));
            style.Setters.Add(new Setter(Control.BorderBrushProperty, new DynamicResourceExtension("ButtonNormalBorder")));
            style.Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(1)));
            style.Setters.Add(new Setter(Control.ForegroundProperty, new DynamicResourceExtension(SystemColors.ControlTextBrushKey)));
            style.Setters.Add(new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
            style.Setters.Add(new Setter(Control.VerticalContentAlignmentProperty, VerticalAlignment.Center));
            style.Setters.Add(new Setter(Control.PaddingProperty, new Thickness(1)));

            style.Setters.Add(new Setter(Control.TemplateProperty, template));

            AddResources(style); //This is not needed as the resources are already in as default, just showing how they can be attached to the local style. 

            return style;
        }

        private void AddFlashyTemplate(Button butt)
        {
            //Rebuild root control from Grid.
            var grid = new FrameworkElementFactory(typeof(Grid));

            //The fkashy border
            var border = new FrameworkElementFactory(typeof(Border));               //Border doesn't work very well if window reduced in size.
            border.SetValue(Control.BackgroundProperty, Brushes.Transparent);
            border.SetValue(FrameworkElement.MarginProperty, new Thickness(-5.0D));
            border.SetValue(Border.CornerRadiusProperty, new CornerRadius(5));

            var bStyle = new Style { TargetType = typeof(Border) };

            MakeDataTrigger(bStyle);
            border.SetValue(FrameworkElement.StyleProperty, bStyle);

            grid.AppendChild(border);
            grid.AppendChild(MakeButtonChrome()); // Can reuse as not an element, only blueprint

            //Replace old Visual Tree with new Grid because Template now in use and can't be modified
            //template.VisualTree = grid;

            ControlTemplate newTemplate = new ControlTemplate { TargetType = typeof(Button), VisualTree = grid };

            foreach (var trigger in butt.Template.Triggers) // Reuse the triggers
                newTemplate.Triggers.Add(trigger);

            butt.Template = newTemplate;

        }

        private void MakeDataTrigger(Style style)
        {
            // Introducing System.Data.Binding, used below to make AttachedProperty Binding
            var apBinding = new Binding("(local:AttachedProperties.IsHighlighted)") { RelativeSource = RelativeSource.TemplatedParent };

            var apDataTrigger = new DataTrigger { Binding = apBinding, Value = true };
            apDataTrigger.Setters.Add(new Setter(FrameworkElement.VisibilityProperty, Visibility.Visible));

            // Introducing Windows.Media.Animation
            var sb = new Storyboard();
            var colAnim = new ColorAnimation(Colors.Transparent, Colors.Red, TimeSpan.FromMilliseconds(250));
            colAnim.AutoReverse = true;
            colAnim.RepeatBehavior = RepeatBehavior.Forever;
            Storyboard.SetTargetProperty(colAnim, new PropertyPath("(Background).(SolidColorBrush.Color)"));
            colAnim.EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut };

            sb.Children.Add(colAnim);

            var bsb = new BeginStoryboard { Name = "HighlightedAnimation", Storyboard = sb };

            apDataTrigger.EnterActions.Add(bsb);
            apDataTrigger.ExitActions.Add(new StopStoryboard { BeginStoryboardName = "HighlightedAnimation" });

            style.Triggers.Add(apDataTrigger);
            // Next line needed, or causes exception: 'HighlightedAnimation' name cannot be found in the name scope of 'System.Windows.Style'.
            style.RegisterName("HighlightedAnimation", bsb);
        }

        private static FrameworkElementFactory MakeButtonChrome()
        {
            var butt = new FrameworkElementFactory(typeof(Microsoft.Windows.Themes.ButtonChrome), "Chrome"); // Name is used in template triggers
            butt.SetValue(Control.BorderBrushProperty, new TemplateBindingExtension(Control.BorderBrushProperty)); // Tested in MainWindow.xaml.cs
            butt.SetValue(Control.BackgroundProperty, new TemplateBindingExtension(Control.BackgroundProperty));
            butt.SetValue(Microsoft.Windows.Themes.ButtonChrome.RenderMouseOverProperty, new TemplateBindingExtension(UIElement.IsMouseOverProperty));
            butt.SetValue(Microsoft.Windows.Themes.ButtonChrome.RenderPressedProperty, new TemplateBindingExtension(ButtonBase.IsPressedProperty));
            butt.SetValue(Microsoft.Windows.Themes.ButtonChrome.RenderDefaultedProperty, new TemplateBindingExtension(Button.IsDefaultedProperty));
            butt.SetValue(UIElement.SnapsToDevicePixelsProperty, true);

            var contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.SetValue(FrameworkElement.HorizontalAlignmentProperty, new TemplateBindingExtension(Control.HorizontalContentAlignmentProperty));
            contentPresenter.SetValue(FrameworkElement.VerticalAlignmentProperty, new TemplateBindingExtension(Control.VerticalContentAlignmentProperty));
            contentPresenter.SetValue(UIElement.SnapsToDevicePixelsProperty, new TemplateBindingExtension(UIElement.SnapsToDevicePixelsProperty));
            contentPresenter.SetValue(FrameworkElement.MarginProperty, new TemplateBindingExtension(Control.PaddingProperty));
            contentPresenter.SetValue(ContentPresenter.RecognizesAccessKeyProperty, true);

            butt.AppendChild(contentPresenter);
            return butt;
        }

        void AddResources(Style style)
        {
            // I coded these resources and show how to add them to the button style itself, but they are already defined by default. 
            // Although Expression Blend output them, this is only to show what the control uses and allows you to change these shared resources.
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

        Style MakeButtonFocusVisualStyle()
        {
            ControlTemplate template = new ControlTemplate(); //Notice no TargetType

            var rec = new FrameworkElementFactory(typeof(Rectangle));
            rec.SetValue(FrameworkElement.MarginProperty, new Thickness(2));
            rec.SetValue(Shape.StrokeProperty, new DynamicResourceExtension(SystemColors.ControlTextBrushKey));
            rec.SetValue(Shape.StrokeThicknessProperty, 1.0D);
            rec.SetValue(Shape.StrokeDashArrayProperty, new DoubleCollection { 1.0D, 2.0D }); //this  makes the focus visual dashes

            template.VisualTree = rec;

            var style = new Style();
            style.Setters.Add(new Setter(Control.TemplateProperty, template));

            return style;
        }

    }
}
