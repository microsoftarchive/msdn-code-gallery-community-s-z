using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Tasks.Show.Controls
{
    public class IndexingStackPanel : StackPanel
    {
        #region Index (Attached Dependency Property)

        public static int GetIndex(DependencyObject obj)
        {
            return (int)obj.GetValue(IndexProperty);
        }

        public static void SetIndex(DependencyObject obj, int value)
        {
            obj.SetValue(IndexProperty, value);
        }

        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.RegisterAttached("Index", typeof(int), typeof(IndexingStackPanel), new UIPropertyMetadata(default(int)));

        #endregion

        #region SelectionLocation

        public static SelectionLocation GetSelectionLocation(DependencyObject obj)
        {
            return (SelectionLocation)obj.GetValue(SelectionLocationProperty);
        }

        public static void SetSelectionLocation(DependencyObject obj, SelectionLocation value)
        {
            obj.SetValue(SelectionLocationProperty, value);
        }

        public static readonly DependencyProperty SelectionLocationProperty =
            DependencyProperty.RegisterAttached("SelectionLocation", typeof(SelectionLocation), typeof(IndexingStackPanel), new UIPropertyMetadata(default(SelectionLocation)));

        #endregion

        #region StackLocation (Attached Dependency Property)

        public static StackLocation GetStackLocation(DependencyObject obj)
        {
            return (StackLocation)obj.GetValue(StackLocationProperty);
        }

        public static void SetStackLocation(DependencyObject obj, StackLocation value)
        {
            obj.SetValue(StackLocationProperty, value);
        }

        public static readonly DependencyProperty StackLocationProperty =
            DependencyProperty.RegisterAttached("StackLocation", typeof(StackLocation), typeof(IndexingStackPanel), new FrameworkPropertyMetadata(StackLocation.None, FrameworkPropertyMetadataOptions.Inherits));

        #endregion

        #region IndexOddEven (Attached DependencyProperty)

        public static IndexOddEven GetIndexOddEven(DependencyObject obj)
        {
            return (IndexOddEven)obj.GetValue(IndexOddEvenProperty);
        }

        public static void SetIndexOddEven(DependencyObject obj, IndexOddEven value)
        {
            obj.SetValue(IndexOddEvenProperty, value);
        }

        public static readonly DependencyProperty IndexOddEvenProperty =
            DependencyProperty.RegisterAttached("IndexOddEven", typeof(IndexOddEven), typeof(IndexingStackPanel), new UIPropertyMetadata(default(IndexOddEven)));


        #endregion

        #region IgnoreCollapsedElements (DependencyProperty)

        /// <summary>
        /// A description of the property.
        /// </summary>
        public bool IgnoreCollapsedElements
        {
            get { return (bool)GetValue(IgnoreCollapsedElementsProperty); }
            set { SetValue(IgnoreCollapsedElementsProperty, value); }
        }
        public static readonly DependencyProperty IgnoreCollapsedElementsProperty =
            DependencyProperty.Register("IgnoreCollapsedElements", typeof(bool), typeof(IndexingStackPanel),
              new PropertyMetadata(true));

        #endregion

        #region Overrides

        protected override Size MeasureOverride(Size constraint)
        {
            int index = 0;
            bool isEven = true;
            bool foundSelected = false;

            UIElement first = null;
            UIElement last = null;

            UIElement selectedElement = null;
            if (this.IsItemsHost)
            {
                var selectorParent = this.TemplatedParent as Selector;
                if (selectorParent != null)
                    selectedElement = (selectorParent.ItemContainerGenerator.ContainerFromItem(selectorParent.SelectedItem) as UIElement);
            }

            foreach (UIElement element in this.Children)
            {
                // SelectionLocation

                if (selectedElement != null)
                {
                    if (element == selectedElement)
                    {
                        element.SetValue(SelectionLocationProperty, SelectionLocation.Selected);
                        foundSelected = true;
                    }
                    else 
                        if (foundSelected)
                            element.SetValue(SelectionLocationProperty, SelectionLocation.After);
                        else
                            element.SetValue(SelectionLocationProperty, SelectionLocation.Before);
                }

                // IgnoreCollapsedElements

                if (IgnoreCollapsedElements && element.Visibility == Visibility.Collapsed)
                {
                    element.SetValue(StackLocationProperty, StackLocation.None);
                    element.SetValue(IndexOddEvenProperty, IndexOddEven.None);
                    element.SetValue(IndexProperty, -1);
                    continue;
                }

                // StackLocation
                if (first == null) 
                    first = element;
                last = element;
                element.SetValue(StackLocationProperty, StackLocation.Middle);

                // IndexOddEven
                if (isEven)
                    element.SetValue(IndexOddEvenProperty, IndexOddEven.Even);
                else
                    element.SetValue(IndexOddEvenProperty, IndexOddEven.Odd);

                isEven = !isEven;

                // Index
                element.SetValue(IndexProperty, index);
                index++;
            }

            if (first != null && last != null)
            {
                first.SetValue(StackLocationProperty, StackLocation.First);
                last.SetValue(StackLocationProperty, StackLocation.Last);
                if (first == last)
                    first.SetValue(StackLocationProperty, StackLocation.FirstAndLast);
            }

            return base.MeasureOverride(constraint);
        }

        #endregion
    }

    public enum StackLocation
    {
        None,
        First,
        Middle,
        Last,
        FirstAndLast
    }

    public enum SelectionLocation
    {
        Before,
        Selected,
        After
    }

    public enum IndexOddEven
    {
        None,
        Odd,
        Even
    }
}
