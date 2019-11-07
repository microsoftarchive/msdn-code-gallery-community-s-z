using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinRTToolkitChartSample.Common
{
    static class CollectionExtensions
    {
        /// <summary>
        /// IEからObservableCollectionへの変換を行う
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> self)
        {
            return new ObservableCollection<T>(self);
        }
    }
}
