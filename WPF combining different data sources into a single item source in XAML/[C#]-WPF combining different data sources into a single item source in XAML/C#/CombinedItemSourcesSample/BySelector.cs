using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CombinedItemSourcesSample
{
    public class ByDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null)
            {
                var itemType = item.GetType();

                if (itemType == typeof(Book))
                {
                    return element.FindResource("AuthorTemplate") as DataTemplate;
                } else if(itemType == typeof(Movie))
                {
                    return element.FindResource("DirectorTemplate") as DataTemplate;
                } else if(itemType == typeof(Album))
                {                    
                    return element.FindResource("ArtistTemplate") as DataTemplate;
                }                
            }

            return null;
        }
    }
}
