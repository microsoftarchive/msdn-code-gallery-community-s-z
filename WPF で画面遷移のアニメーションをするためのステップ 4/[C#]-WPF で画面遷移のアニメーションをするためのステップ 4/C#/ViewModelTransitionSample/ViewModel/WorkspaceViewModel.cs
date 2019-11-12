namespace ViewModelTransitionSample.ViewModel
{
    using System.Diagnostics;

    public abstract class WorkspaceViewModel : ViewModelBase
    {
        #region 共通プロパティ
        private string name;
        /// <summary>
        /// 名前
        /// </summary>
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value, "Name"); }
        }
        #endregion

        #region 共通メソッド
        /// <summary>
        /// 画面遷移後の開始処理
        /// </summary>
        public virtual void Loaded()
        {
            Trace.WriteLine(Name + ": Loaded()");
        }

        /// <summary>
        /// 画面遷移前の終了処理
        /// </summary>
        public virtual void UnLoaded()
        {
            Trace.WriteLine(Name + ": UnLoaded()");
        }
        #endregion
    }
}
