namespace ViewModelTransitionSample.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System;

    public class MainFrameViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainFrameViewModel()
        {
        }

        /// <summary>
        /// 画面リスト生成
        /// </summary>
        /// <returns></returns>
        private List<ScreenListItemBase> CreateScreenList()
        {
            return new List<ScreenListItemBase>
            {
                new ScreenListItemBase { Name = "画面 1", Type = typeof(Screen1ViewModel) },
                new ScreenListItemBase { Name = "画面 2", Type = typeof(Screen2ViewModel) },
                new ScreenListItemBase { Name = "画面 3", Type = typeof(Screen3ViewModel) },
                new ScreenListItemBase { Name = "画面 4", Type = typeof(Screen4ViewModel) },
                new ScreenListItemBase { Name = "画面 5", Type = typeof(Screen5ViewModel) },
            };
        }

        #region 公開プロパティ
        private WorkspaceViewModel currentViewModel;
        /// <summary>
        /// 現在の ViewModel
        /// </summary>
        public WorkspaceViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                WorkspaceViewModel oldViewModel = CurrentViewModel;

                if (SetProperty(ref currentViewModel, value, "CurrentViewModel"))
                {
                    // ViewModel が入れ替わったときに処理をおこなう

                    // 画面遷移前の終了処理
                    if (oldViewModel != null)
                    {
                        oldViewModel.UnLoaded();
                    }

                    // 画面遷移後の開始処理
                    if (CurrentViewModel != null)
                    {
                        CurrentViewModel.Loaded();
                    }
                }
            }
        }

        private ReadOnlyCollection<ScreenListItemBase> screenList;
        /// <summary>
        /// 画面リスト
        /// </summary>
        public ReadOnlyCollection<ScreenListItemBase> ScreenList
        {
            get
            {
                if (screenList == null)
                {
                    var list = CreateScreenList();
                    screenList = new ReadOnlyCollection<ScreenListItemBase>(list);
                }
                return screenList;
            }
        }

        private ScreenListItemBase selectedScreen;
        /// <summary>
        /// 選択された画面
        /// </summary>
        public ScreenListItemBase SelectedScreen
        {
            get
            {
                if (selectedScreen == null)
                {
                    SelectedScreen = ScreenList[0];
                }
                return selectedScreen;
            }
            set
            {
                if (SetProperty(ref selectedScreen, value, "SelectedScreen"))
                {
                    // 画面遷移を実行
                    OnScreenChanged();
                }
            }
        }
        #endregion

        #region 画面遷移
        /// <summary>
        /// ViewModel のインスタンスを保持する辞書
        /// </summary>
        private Dictionary<string, WorkspaceViewModel> viewModelMap = new Dictionary<string, WorkspaceViewModel>();

        /// <summary>
        /// 画面遷移
        /// </summary>
        private void OnScreenChanged()
        {
            if (SelectedScreen == null)
                return;

            WorkspaceViewModel newViewModel = null;

            if (viewModelMap.ContainsKey(SelectedScreen.Name))
            {
                // 登録済みならそこからロード
                newViewModel = viewModelMap[SelectedScreen.Name];
            }
            else
            {
                // 未登録ならインスタンスを生成
                if (SelectedScreen.Type == null)
                    return;
                object obj = SelectedScreen.Type.InvokeMember(null, System.Reflection.BindingFlags.CreateInstance, null, null, null);
                newViewModel = obj as WorkspaceViewModel;
                if (newViewModel != null)
                    viewModelMap.Add(SelectedScreen.Name, newViewModel);
            }

            // ViewModel の切り替え
            CurrentViewModel = newViewModel;
        }
        #endregion
    }
}
