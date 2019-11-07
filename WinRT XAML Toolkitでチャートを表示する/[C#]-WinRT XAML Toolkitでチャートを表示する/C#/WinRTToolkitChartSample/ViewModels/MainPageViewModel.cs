using Microsoft.Practices.Prism.StoreApps;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Navigation;
using WinRTToolkitChartSample.Common;
using WinRTToolkitChartSample.Models;

namespace WinRTToolkitChartSample.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private ObservableCollection<ChartItem> chartItems1;

        /// <summary>
        /// グラフに表示するためのデータのコレクションその１
        /// </summary>
        public ObservableCollection<ChartItem> ChartItems1
        {
            get { return this.chartItems1; }
            set { this.SetProperty(ref this.chartItems1, value); }
        }

        private ObservableCollection<ChartItem> chartItems2;

        /// <summary>
        /// グラフに表示するためのデータのコレクションその２
        /// </summary>
        public ObservableCollection<ChartItem> ChartItems2
        {
            get { return this.chartItems2; }
            set { this.SetProperty(ref this.chartItems2, value); }
        }

        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);
            // 画面にナビゲーションしてきたタイミングでデータの初期化を行う
            this.ChartItems1 = ChartItem.GetChartItems().ToObservableCollection();
            this.ChartItems2 = ChartItem.GetChartItems().ToObservableCollection();
        }
    }
}
