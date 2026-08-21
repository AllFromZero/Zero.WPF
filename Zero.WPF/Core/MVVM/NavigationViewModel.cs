using System;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Zero.WPF.Core.MVVM
{
    /// <summary>
    /// 页导航视图模型（基于 CommunityToolkit.Mvvm）
    /// </summary>
    public partial class NavigationViewModel : ZeroViewModel
    {
        #region Observable Properties（自动生成属性）

        /// <summary>
        /// 目标页（UI 输入绑定）
        /// </summary>
        [ObservableProperty]
        private int _targetPage = 1;

        /// <summary>
        /// 总页数
        /// </summary>
        [ObservableProperty]
        private int _totalPageCnt = 1;

        /// <summary>
        /// 当前页
        /// </summary>
        [ObservableProperty]
        private int _currentPage = 1;

        /// <summary>
        /// 当前页面起始数据编号
        /// </summary>
        [ObservableProperty]
        private int _startIndex = 0;

        #endregion

        #region 自定义属性（带业务逻辑）
        /// <summary>
        /// 总记录数（设置时自动计算总页数）
        /// </summary>
        private int _totalDataCnt;
        /// <summary>
        /// 单页记录数量（默认100，最小值1）
        /// </summary>
        private int _onePageCount = 100;

        /// <summary>
        /// 总记录数（设置时自动计算总页数）
        /// </summary>
        public int TotalDataCnt
        {
            get => _totalDataCnt;
            set
            {
                if (SetProperty(ref _totalDataCnt, value))
                {
                    // 更新总页数
                    if (_totalDataCnt <= 0)
                    {
                        TotalPageCnt = 1;
                        CurrentPage = 1;
                        TargetPage = 1;
                    }
                    else
                    {
                        TotalPageCnt = CalculatePageCount(value, OnePageCnt);
                    }
                }
            }
        }

        /// <summary>
        /// 单页记录数量（默认100，最小值1）
        /// </summary>
        public int OnePageCnt
        {
            get => _onePageCount;
            set
            {
                var validValue = value <= 0 ? 100 : value;
                if (SetProperty(ref _onePageCount, validValue))
                {
                    // 重新计算总页数
                    if (_totalDataCnt > 0)
                    {
                        TotalPageCnt = CalculatePageCount(_totalDataCnt, validValue);
                    }
                }
            }
        }

        /// <summary>
        /// 辅助计算总页数
        /// </summary>
        /// <param name="total">总记录数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        private static int CalculatePageCount(int total, int pageSize)
        {
            return total == 0 ? 0 : (total - 1) / pageSize + 1;
        }

        #endregion

        #region 命令（自动生成）
        /// <summary>
        /// 首页
        /// </summary>
        [RelayCommand]
        private void FirstPage() => OnGoToPage(1);

        /// <summary>
        /// 下一页
        /// </summary>
        [RelayCommand]
        private void NextPage() => OnGoToPage(CurrentPage + 1);
        /// <summary>
        /// 上一页
        /// </summary>
        [RelayCommand]
        private void PreviousPage() => OnGoToPage(CurrentPage - 1);
        /// <summary>
        /// 最后一页
        /// </summary>
        [RelayCommand]
        private void LastPage() => OnGoToPage(TotalPageCnt);
        /// <summary>
        /// 跳转到指定页（参数可为 int 或 string，可自动解析）
        /// </summary>
        /// <param name="parameter"></param>
        [RelayCommand]
        private void GoToPage(object? parameter)
        {
            int target = parameter is string str && int.TryParse(str, out int parsed) ? parsed
                        : parameter is int i ? i
                        : 1;
            OnGoToPage(target);
        }

        #endregion

        #region 可重写的核心逻辑

        /// <summary>
        /// 执行页面跳转（子类可重写以扩展验证或行为）
        /// </summary>
        protected virtual void OnGoToPage(int target)
        {
            TargetPage = target; // 同步 UI 输入框

            // 无数据时提示
            if (TotalDataCnt == 0)
            {
                ShowNoDataWarning();
                TargetPage = CurrentPage;
                return;
            }

            // 边界检查
            if (target > TotalPageCnt)
            {
                ShowTargetPageTooLargeWarning();
                TargetPage = CurrentPage;
                return;
            }
            if (target <= 0)
            {
                ShowPageTooLessWarning();
                TargetPage = CurrentPage;
                return;
            }

            // 与当前页相同时提示
            if (CurrentPage == 1 && target == 1)
            {
                ShowFirstPageWarning();
                TargetPage = CurrentPage;
                return;
            }
            if (CurrentPage == TotalPageCnt && target == TotalPageCnt)
            {
                ShowLastPageWarning();
                TargetPage = CurrentPage;
                return;
            }

            // 更新当前页并查询
            try
            {
                QueryPage();
                CurrentPage = target;
            }
            catch (Exception ex)
            {
                ShowGoToPageError(ex);
                TargetPage = CurrentPage; // 回滚
            }
        }

        /// <summary>
        /// 查询记录（子类必须重写）
        /// </summary>
        /// <remarks>需要更新 StartIndex 等属性</remarks>
        protected virtual bool QueryPage()
        {
            throw new NotImplementedException("请重写 QueryPage() 方法");
        }

        #endregion

        #region 提示对话框（可重写）
        /// <summary>
        /// 显示无数据提示
        /// </summary>
        protected virtual void ShowNoDataWarning()
        {
            MessageBox.Show("没有数据可显示!", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// 显示切换页面错误提示
        /// </summary>
        /// <param name="ex"></param>
        protected virtual void ShowGoToPageError(Exception ex)
        {
            MessageBox.Show(ex.Message, "切换页面错误", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// 显示目标页大于总页数的提示
        /// </summary>
        protected virtual void ShowTargetPageTooLargeWarning()
        {
            MessageBox.Show("页码不能大于总页数!", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// 显示目标页小于等于0的提示
        /// </summary>
        protected virtual void ShowPageTooLessWarning()
        {
            MessageBox.Show("页码不能小于或等于0!", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// 显示当前已经是首页的提示
        /// </summary>
        protected virtual void ShowFirstPageWarning()
        {
            MessageBox.Show("当前已经是首页!", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// 显示当前已经是尾页的提示
        /// </summary>
        protected virtual void ShowLastPageWarning()
        {
            MessageBox.Show("当前已经是尾页!", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        #endregion
    }
}