using System.Windows;

namespace Zero.WPF.Core.MVVM
{
    /// <summary>
    /// 页面导航视图模型
    /// </summary>
    public class BrowserPageViewModel : ZeroViewModel
    {
        #region Private Property

        /// <summary>
        /// 目标页面
        /// </summary>
        private int targetPage = 1;
        /// <summary>
        /// 总记录数量
        /// </summary>
        private int _totalCnt = 0;
        /// <summary>
        /// 总页数
        /// </summary>
        private int _totalPageCnt = 0;
        /// <summary>
        /// 当前页数
        /// </summary>
        private int _currentPage = 0;
        /// <summary>
        /// 当前页面起始数据编号
        /// </summary>
        private int _startIndex = 0;
        /// <summary>
        /// 每月数据量
        /// </summary>
        private int _onePageCount = 100;

        #endregion Private Property

        #region Public Propery

        #region Command
        /// <summary>
        /// 首页
        /// </summary>
        public RelayCommand FirstPageCommand { get; set; }
        /// <summary>
        /// 上一页
        /// </summary>
        public RelayCommand PreviousPageCommand { get; set; }
        /// <summary>
        /// 下一页
        /// </summary>
        public RelayCommand NextPageCommand { get; set; }
        /// <summary>
        /// 最后一页
        /// </summary>
        public RelayCommand LastPageCommand { get; set; }
        /// <summary>
        /// 跳转页面
        /// </summary>
        public RelayCommand GotoPageCommand { get; set; }

        #endregion Command

        #region Page

        /// <summary>
        /// 目标页
        /// </summary>
        public int TargetPage
        {
            get => targetPage;
            set
            {
                targetPage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCnt
        {
            get => _totalCnt;
            set
            {
                _totalCnt = value;
                TotalPageCnt = value % OnePageCnt == 0 ? value / OnePageCnt : value / OnePageCnt + 1;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPageCnt
        {
            get => _totalPageCnt;
            set
            {
                _totalPageCnt = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 当前页面起始数据编号
        /// </summary>
        /// <remarks>与查询的的数据绑定，通常与数据ID所兼容，配合Limit属性查询</remarks>
        public int StartIndex
        {
            get => _startIndex;
            set
            {
                _startIndex = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 单页记录数量
        /// </summary>
        /// <remarks>默认值100</remarks>
        public int OnePageCnt
        {
            get => _onePageCount;
            set
            {
                _onePageCount = value;
                if (value <= 0)
                {
                    _onePageCount = 100;
                }
                OnPropertyChanged();
            }
        }

        #endregion Page

        #endregion Public Property

        /// <summary>
        /// 构造函数
        /// </summary>
        public BrowserPageViewModel()
        {
            FirstPageCommand = new RelayCommand(FirstPage);
            NextPageCommand = new RelayCommand(NextPage);
            PreviousPageCommand = new RelayCommand(PreviousPage);
            GotoPageCommand = new RelayCommand(GoToPage);
            LastPageCommand = new RelayCommand(LastPage);
        }

        #region Method

        #region Page

        /// <summary>
        /// 查询记录
        /// </summary>
        /// <remarks>需要根据查询到的记录更新StartIndex属性</remarks>
        protected virtual bool QueryPage()
        {
            throw new NotImplementedException("Please override the method \"QueryPage()\".");
        }
        

        /// <summary>
        /// 第一页
        /// </summary>
        public void FirstPage(object? sender)
        {
            GoToPage(1);
        }

        /// <summary>
        /// 下一页
        /// </summary>
        public void NextPage(object? sender)
        {
            GoToPage(CurrentPage + 1);
        }

        /// <summary>
        /// 上一页
        /// </summary>
        public void PreviousPage(object? sender)
        {
            GoToPage(CurrentPage - 1);
        }

        /// <summary>
        /// 导航到指定页面
        /// </summary>
        public void GoToPage(object? sender)
        {
            if (sender != null && int.TryParse(sender.ToString(), out int result))
            {
                TargetPage = result;
            }
            else
            {
                TargetPage = 1;
            }

            try
            {
                if (TargetPage > TotalPageCnt)
                {
                    ShowTargetPageTooLargeWarning();
                    TargetPage = CurrentPage;
                    return;
                }
                else if (TargetPage <= 0)
                {
                    ShowPageTooLessWarning();
                    TargetPage = CurrentPage;
                    return;
                }
                else if (TotalPageCnt > 0 && CurrentPage == 1 && TargetPage == 1)
                {
                    ShowFirstPageWarning();
                    return;
                }
                else if (TotalPageCnt > 0 && CurrentPage == TotalPageCnt && TargetPage == TotalPageCnt)
                {
                    ShowLastPageWarning();
                    return;
                }

                CurrentPage = TargetPage;
                QueryPage();        // 查询记录
            }
            catch (Exception ex)
            {
                ShowGoToPageError(ex);
                return;
            }

        }

        /// <summary>
        /// 最后一页
        /// </summary>
        public void LastPage(object? sender)
        {
            GoToPage(sender);
        }

        #endregion Page

        #region Error

        /// <summary>
        /// 切换页面失败
        /// </summary>
        protected virtual void ShowGoToPageError(Exception ex)
        {
            MessageBox.Show(ex.Message, "切换页面错误", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// 页数太大回调方法
        /// </summary>
        protected virtual void ShowTargetPageTooLargeWarning()
        {
            MessageBox.Show("页码不能大于总页数!", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// 页数太小方法
        /// </summary>
        protected virtual void ShowPageTooLessWarning()
        {
            MessageBox.Show("页码不能小于或等于0!", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// 已经是首页
        /// </summary>
        protected virtual void ShowFirstPageWarning()
        {
            MessageBox.Show("当前已经是首页!", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// 已经是首页
        /// </summary>
        protected virtual void ShowLastPageWarning()
        {
            MessageBox.Show("当前已经是尾页!", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        #endregion Error

        #endregion Method

    }
}
