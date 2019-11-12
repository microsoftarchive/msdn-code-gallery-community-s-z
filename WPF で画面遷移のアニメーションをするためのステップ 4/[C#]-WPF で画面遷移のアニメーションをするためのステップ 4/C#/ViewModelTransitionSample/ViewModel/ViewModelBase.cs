namespace ViewModelTransitionSample.ViewModel
{
    using System.ComponentModel;

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged の実装
        /// <summary>
        /// プロパティ値変更イベントハンドラ
        /// </summary>
        private PropertyChangedEventHandler PropertyChangedHandler;

        /// <summary>
        /// プロパティ値変更イベント
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { PropertyChangedHandler += value; }
            remove { PropertyChangedHandler -= value; }
        }

        /// <summary>
        /// プロパティ値変更イベント発行
        /// </summary>
        /// <param name="name"></param>
        protected virtual void RaisePropertyChanged(string name)
        {
            var h = PropertyChangedHandler;
            if (h != null)
                h(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        /// <summary>
        /// プロパティ値変更ヘルパ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">プロパティ値を保持する変数</param>
        /// <param name="value">変更後の値</param>
        /// <param name="name">プロパティ名</param>
        /// <returns>false:変更なし/true:変更あり</returns>
        public virtual bool SetProperty<T>(ref T target, T value, string name)
        {
            if (target == null)
            {
                if (value == null)
                    return false;
            }
            else
            {
                if (target.Equals(value))
                    return false;
            }

            target = value;
            RaisePropertyChanged(name);
            return true;
        }
    }
}
