using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Media;
using Microsoft.Windows.Themes;

namespace PEJL_WPF_Examples.Factories
{
    class DataGridFactory
    {
        IndicatorsViewModel indicatorsViewModel;

        public DataGrid Make_ColumnHeaderAware_DataGrid(IndicatorsViewModel ivm)
        {
            indicatorsViewModel = ivm;

            var dg = new DataGrid();
            dg.ColumnHeaderStyle = MakeDataGridColumnHeaderStyle();

            return dg;
        }

        Style MakeDataGridColumnHeaderStyle()
        {
            ControlTemplate template = new ControlTemplate{ TargetType = typeof(DataGridColumnHeader) };

            //This is the actual contents of the header
            var grid = new FrameworkElementFactory(typeof(Grid));

            var border = new FrameworkElementFactory(typeof(DataGridHeaderBorder));
            border.SetValue(DataGridHeaderBorder.BorderBrushProperty, new TemplateBindingExtension(Control.BorderBrushProperty));
            border.SetValue(Border.BorderThicknessProperty, new TemplateBindingExtension(Control.BorderThicknessProperty));
            border.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(Control.BackgroundProperty));
            border.SetValue(DataGridHeaderBorder.IsClickableProperty, new TemplateBindingExtension(DataGridColumn.CanUserSortProperty));
            border.SetValue(DataGridHeaderBorder.IsPressedProperty, new TemplateBindingExtension(ButtonBase.IsPressedProperty));
            border.SetValue(DataGridHeaderBorder.IsHoveredProperty, new TemplateBindingExtension(UIElement.IsMouseOverProperty));
            border.SetValue(Border.PaddingProperty, new TemplateBindingExtension(Control.PaddingProperty));
            border.SetValue(DataGridHeaderBorder.SortDirectionProperty, new TemplateBindingExtension(DataGridColumn.SortDirectionProperty));
            border.SetValue(DataGridHeaderBorder.SeparatorBrushProperty, new TemplateBindingExtension(DataGridColumnHeader.SeparatorBrushProperty));
            border.SetValue(DataGridHeaderBorder.SeparatorVisibilityProperty, new TemplateBindingExtension(DataGridColumnHeader.SeparatorVisibilityProperty));

            var contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.SetValue(FrameworkElement.HorizontalAlignmentProperty, new TemplateBindingExtension(Control.HorizontalContentAlignmentProperty));
            contentPresenter.SetValue(FrameworkElement.VerticalAlignmentProperty, new TemplateBindingExtension(Control.VerticalContentAlignmentProperty));
            contentPresenter.SetValue(UIElement.SnapsToDevicePixelsProperty, new TemplateBindingExtension(Control.SnapsToDevicePixelsProperty));

            contentPresenter.AddHandler(UIElement.MouseEnterEvent, new MouseEventHandler(ColumnHeader_MouseEnter));
            contentPresenter.AddHandler(UIElement.MouseLeaveEvent, new MouseEventHandler(ColumnHeader_MouseLeave));

            border.AppendChild(contentPresenter);

            var thumb1 = new FrameworkElementFactory(typeof(Thumb));
            thumb1.SetValue(FrameworkElement.NameProperty, "PART_LeftHeaderGripper");
            thumb1.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            thumb1.SetValue(FrameworkElement.StyleProperty, MakeColumnHeaderGripperStyle());

            var thumb2 = new FrameworkElementFactory(typeof(Thumb));
            thumb2.SetValue(FrameworkElement.NameProperty, "PART_RightHeaderGripper");
            thumb2.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Right);
            thumb2.SetValue(FrameworkElement.StyleProperty, MakeColumnHeaderGripperStyle());

            grid.AppendChild(border);
            grid.AppendChild(thumb1);
            grid.AppendChild(thumb2);

            template.VisualTree = grid;

            var style = new Style() { TargetType = typeof(DataGridColumnHeader) };
            style.Setters.Add(new Setter(Control.TemplateProperty, template));
            style.Setters.Add(new Setter(Control.VerticalContentAlignmentProperty, VerticalAlignment.Center));

            return style;
        }

        Style MakeColumnHeaderGripperStyle()
        {
            ControlTemplate template = new ControlTemplate
            {
                TargetType = typeof(Thumb),
            };

            var border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(Control.BackgroundProperty, new TemplateBindingExtension(Control.BackgroundProperty));
            border.SetValue(Control.PaddingProperty, new TemplateBindingExtension(Control.PaddingProperty));

            var style = new Style() { TargetType = typeof(Thumb) };
            style.Setters.Add(new Setter(FrameworkElement.WidthProperty, 8.0D));
            style.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.Transparent));
            style.Setters.Add(new Setter(FrameworkElement.CursorProperty, Cursors.ScrollWE));
            style.Setters.Add(new Setter(Control.TemplateProperty, template));

            return style;
        }

        private void ColumnHeader_MouseEnter(object sender, MouseEventArgs e)
        {
            var contentPresenter = sender as ContentPresenter;

            indicatorsViewModel.OverColumnName = (string)contentPresenter.Content;
            indicatorsViewModel.IsOverColumnHeader = true;
        }

        private void ColumnHeader_MouseLeave(object sender, MouseEventArgs e)
        {
            indicatorsViewModel.IsOverColumnHeader = false;
        }
    }
}
