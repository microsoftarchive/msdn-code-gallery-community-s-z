/* 
   Copyright 2013 Christoph Gattnar 
 
   Licensed under the Apache License, Version 2.0 (the "License"); 
   you may not use this file except in compliance with the License. 
   You may obtain a copy of the License at 
 
       http://www.apache.org/licenses/LICENSE-2.0 
 
   Unless required by applicable law or agreed to in writing, software 
   distributed under the License is distributed on an "AS IS" BASIS, 
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
   See the License for the specific language governing permissions and 
   limitations under the License. 
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using SortingEvolution1.MVVMFramework;

namespace SortingEvolution1
{
    public class SortingViewModel
    {
        public SortingViewModel()
        {
            SortCommand = new RelayCommand(Sort);

            FirstResultData = new ObservableCollection<ResultData> { new ResultData { ResultNumber = 2, ResultOutput = "1.2" }, new ResultData { ResultNumber = 1, ResultOutput = "1.1" } };
        }

        private ObservableCollection<ResultData> _firstResultData;
        private CollectionViewSource _firstResultDataView;
        private string _sortColumn;
        private ListSortDirection _sortDirection;

        public ICommand SortCommand
        {
            get;
            private set;
        }

        public ObservableCollection<ResultData> FirstResultData
        {
            get
            {
                return _firstResultData;
            }
            set
            {
                _firstResultData = value;
                _firstResultDataView = new CollectionViewSource();
                _firstResultDataView.Source = _firstResultData;
            }
        }

        public ListCollectionView FirstResultDataView
        {
            get
            {
                return (ListCollectionView)_firstResultDataView.View;
            }
        }

        public void Sort(object parameter)
        {
            string column = parameter as string;
            if (_sortColumn == column)
            {
                // Toggle sorting direction
                _sortDirection = _sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
            }
            else
            {
                _sortColumn = column;
                _sortDirection = ListSortDirection.Ascending;
            }

            _firstResultDataView.SortDescriptions.Clear();
            _firstResultDataView.SortDescriptions.Add(new SortDescription(_sortColumn, _sortDirection));
        }
    }
}
