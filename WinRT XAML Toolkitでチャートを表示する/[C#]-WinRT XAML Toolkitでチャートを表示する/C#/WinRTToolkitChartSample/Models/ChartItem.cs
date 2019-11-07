using System;
using System.Collections.Generic;
using System.Linq;

namespace WinRTToolkitChartSample.Models
{
    /// <summary>
    /// グラフに表示するためのデータ
    /// </summary>
    public class ChartItem
    {
        /// <summary>
        /// グラフの値
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// グラフのラベル
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ランダムなデータを10件返す。
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ChartItem> GetChartItems()
        {
            var r = new Random();
            return Enumerable.Range(0, 10)
                .Select(i => new ChartItem 
                { 
                    Name = "項目" + i, 
                    Value = r.Next(100) 
                });
        }
    }
}
