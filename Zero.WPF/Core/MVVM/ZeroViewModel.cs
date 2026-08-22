using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Input;

namespace Zero.WPF.Core.MVVM
{
    /// <summary>
    /// 视图模型基类 - 基于 CommunityToolkit.Mvvm
    /// </summary>
    public partial class ZeroViewModel : ObservableObject, IDisposable
    {
        #region Private Fields
        /// <summary>
        /// 释放资源标识
        /// </summary>
        private bool _isDisposed = false;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? _queryStartTime = DateTime.Today.AddDays(-6);
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? _queryEndTime = DateTime.Today.AddDays(1).AddMilliseconds(-1);

        #endregion Private Fields

        #region Observable Properties (使用源代码生成器)

        /// <summary>
        /// 标题
        /// </summary>
        [ObservableProperty]
        public partial string? ViewTitle { get; set; }

        /// <summary>
        /// 模块是否使能标识
        /// </summary>
        [ObservableProperty]
        public partial bool IsModelEnabled { get; set; } = true;

        /// <summary>
        /// 是否打开标识
        /// </summary>
        [ObservableProperty]
        public partial bool IsOn { get; set; }

        /// <summary>
        /// 是否编辑标识
        /// </summary>
        [ObservableProperty]
        public partial bool IsEdit { get; set; }

        /// <summary>
        /// 是否已加载
        /// </summary>
        [ObservableProperty]
        public partial bool IsViewLoaded { get; set; }

        /// <summary>
        /// 是否正在加载数据
        /// </summary>
        [ObservableProperty]
        public partial bool IsDataLoading { get; set; }

        /// <summary>
        /// 提示
        /// </summary>
        [ObservableProperty]
        public partial string? Prompt { get; set; } = string.Empty;

        /// <summary>
        /// 视图可视属性
        /// </summary>
        [ObservableProperty]
        public partial Visibility Visibility { get; set; } = Visibility.Visible;

        /// <summary>
        /// 是否繁忙（用于异步操作状态）
        /// </summary>
        [ObservableProperty]
        public partial bool IsBusy { get; set; }

        #region Query Condition
        /// <summary>
        /// 查询条件
        /// </summary>
        [ObservableProperty]
        public partial bool? QueryEnabled { get; set; }
        /// <summary>
        /// 查询用户ID
        /// </summary>
        [ObservableProperty]
        public partial int? QueryUserId { get; set; }
        /// <summary>
        /// 查询用户名
        /// </summary>
        [ObservableProperty]
        public partial string? QueryUserName { get; set; }
        /// <summary>
        /// 查询信息
        /// </summary>
        [ObservableProperty]
        public partial string? QueryInfo { get; set; }
        


        /// <summary>
        /// 查询开始时间
        /// </summary>
        public DateTime? QueryStartTime 
        { 
            get=> _queryStartTime;
            set
            {
                if (value.HasValue && QueryEndTime.HasValue)
                {
                    if (value.Value > QueryEndTime.Value)
                    {
                        value = QueryEndTime.Value;
                    }
                    value = value.Value.Date;
                }
                
                SetProperty(ref _queryEndTime, value);
            }
        }
        /// <summary>
        /// 查询结束时间
        /// </summary>
        public DateTime? QueryEndTime 
        { 
            get => _queryEndTime;
            set
            {
                if (value.HasValue && QueryStartTime.HasValue)
                {
                    if (value.Value < QueryStartTime.Value)
                    {
                        value = QueryStartTime.Value;
                    }
                    value = value.Value.Date.AddDays(1).AddMilliseconds(-1);
                }

                SetProperty(ref _queryEndTime, value);
            }
        }

        #endregion Query Condition

        #endregion Observable Properties

        #region Events

        /// <summary>
        /// 视图关闭事件
        /// </summary>
        public event Action? ViewCloseEvent;

        /// <summary>
        /// 视图关闭中事件
        /// </summary>
        /// <remarks>True: Close, False: Cancel</remarks>
        public event Action<bool>? ViewClosingEvent;

        /// <summary>
        /// 视图已关闭事件
        /// </summary>
        public event Action? ViewClosedEvent;

        /// <summary>
        /// 对话框关闭事件
        /// </summary>
        public event Action<bool?>? DialogCloseEvent;

        #endregion Events

        #region Commands (使用 RelayCommand 特性)

        /// <summary>
        /// 编辑命令
        /// </summary>
        [RelayCommand]
        private void Edit(object? sender)
        {
            OnEdit(sender);
        }

        /// <summary>
        /// 显示变化命令
        /// </summary>
        [RelayCommand]
        private void VisibleChanged(object? sender)
        {
            OnVisibleChanged(sender);
        }

        /// <summary>
        /// 视图加载命令
        /// </summary>
        [RelayCommand]
        private void ViewLoaded(object? sender)
        {
            OnViewLoaded(sender);
            IsViewLoaded = true;
        }

        /// <summary>
        /// 视图卸载命令
        /// </summary>
        [RelayCommand]
        private void ViewUnLoaded(object? sender)
        {
            OnViewUnLoaded(sender);
            IsViewLoaded = false;
        }

        /// <summary>
        /// 导入命令
        /// </summary>
        [RelayCommand]
        private void Import(object? sender)
        {
            OnImport(sender);
        }

        /// <summary>
        /// 导出命令
        /// </summary>
        [RelayCommand]
        private void Export(object? sender)
        {
            OnExport(sender);
        }

        /// <summary>
        /// 预览命令
        /// </summary>
        [RelayCommand]
        private void Preview(object? sender)
        {
            OnPreview(sender);
        }

        /// <summary>
        /// 打印命令
        /// </summary>
        [RelayCommand]
        private void Print(object? sender)
        {
            OnPrint(sender);
        }

        /// <summary>
        /// 保存命令
        /// </summary>
        [RelayCommand]
        private void Save(object? sender)
        {
            OnSave(sender);
        }

        /// <summary>
        /// 另存为命令
        /// </summary>
        [RelayCommand]
        private void SaveAs(object? sender)
        {
            OnSaveAs(sender);
        }

        /// <summary>
        /// 增加命令
        /// </summary>
        [RelayCommand]
        private void Add(object? sender)
        {
            OnAdd(sender);
        }

        /// <summary>
        /// 删除命令
        /// </summary>
        [RelayCommand]
        private void Delete(object? sender)
        {
            OnDelete(sender);
        }

        /// <summary>
        /// 修改命令
        /// </summary>
        [RelayCommand]
        private void Modify(object? sender)
        {
            OnModify(sender);
        }

        /// <summary>
        /// 恢复命令
        /// </summary>
        [RelayCommand]
        private void Revert(object? sender)
        {
            OnRevert(sender);
        }

        /// <summary>
        /// 查询命令
        /// </summary>
        [RelayCommand]
        private void Query(object? sender)
        {
            OnQuery(sender);
        }

        /// <summary>
        /// 刷新命令
        /// </summary>
        [RelayCommand]
        private void Refresh(object? sender)
        {
            OnRefresh(sender);
        }

        /// <summary>
        /// 取消命令
        /// </summary>
        [RelayCommand]
        private void Cancel(object? sender)
        {
            OnCancel(sender);
        }

        /// <summary>
        /// 确认命令
        /// </summary>
        [RelayCommand]
        private void Confirm(object? sender)
        {
            OnConfirm(sender);
        }

        /// <summary>
        /// 上传命令
        /// </summary>
        [RelayCommand]
        private void Upload(object? sender)
        {
            OnUpload(sender);
        }

        /// <summary>
        /// 下载命令
        /// </summary>
        [RelayCommand]
        private void Download(object? sender)
        {
            OnDownload(sender);
        }

        /// <summary>
        /// 关闭命令
        /// </summary>
        [RelayCommand]
        private void Close(object? sender)
        {
            OnClose(sender);
            ViewCloseEvent?.Invoke();
        }

        /// <summary>
        /// 关闭中命令
        /// </summary>
        [RelayCommand]
        private void Closing(object? sender)
        {
            bool result = OnClosing(sender);
            ViewClosingEvent?.Invoke(result);
        }

        /// <summary>
        /// 已关闭命令
        /// </summary>
        [RelayCommand]
        private void Closed(object? sender)
        {
            OnClosed(sender);
            ViewClosedEvent?.Invoke();
        }

        /// <summary>
        /// 对话框关闭命令
        /// </summary>
        [RelayCommand]
        private void DialogClose(object? sender)
        {
            bool? result = sender as bool?;
            OnDialogClose(sender);
            DialogCloseEvent?.Invoke(result);
        }

        /// <summary>
        /// 登录命令
        /// </summary>
        [RelayCommand]
        private void Login(object? sender)
        {
            OnLogin(sender);
        }

        /// <summary>
        /// 激活命令
        /// </summary>
        [RelayCommand]
        private void Activate(object? sender)
        {
            OnActivate(sender);
        }

        /// <summary>
        /// 启动命令
        /// </summary>
        [RelayCommand]
        private void Enable(object? sender)
        {
            OnEnable(sender);
        }

        #endregion Commands

        #region Async Commands (异步命令)

        /// <summary>
        /// 异步加载命令示例
        /// </summary>
        [RelayCommand]
        private async Task LoadDataAsync(object? sender)
        {
            if (IsBusy) return;

            IsBusy = true;
            IsDataLoading = true;

            try
            {
                await OnLoadDataAsync(sender);
            }
            finally
            {
                IsBusy = false;
                IsDataLoading = false;
            }
        }

        #endregion Async Commands

        /// <summary>
        /// 构造函数
        /// </summary>
        public ZeroViewModel()
        {

        }

        #region Event Invokers (事件触发器)

        /// <summary>
        /// 触发视图关闭事件
        /// </summary>
        public void RaiseViewCloseEvent()
        {
            ViewCloseEvent?.Invoke();
        }

        /// <summary>
        /// 触发窗体关闭中事件
        /// </summary>
        /// <param name="result"></param>
        public void RaiseViewClosingEvent(bool result)
        {
            ViewClosingEvent?.Invoke(result);
        }

        /// <summary>
        /// 触发窗体已关闭事件
        /// </summary>
        public void RaiseViewClosedEvent()
        {
            ViewClosedEvent?.Invoke();
        }

        /// <summary>
        /// 触发弹窗已关闭事件
        /// </summary>
        public void RaiseDialogCloseEvent(bool? result)
        {
            DialogCloseEvent?.Invoke(result);
        }

        #endregion Event Invokers

        #region Virtual Methods (可重写方法)

        /// <summary>
        /// 编辑
        /// </summary>
        protected virtual void OnEdit(object? sender)
        {
        }

        /// <summary>
        /// 视图加载
        /// </summary>
        protected virtual void OnViewLoaded(object? sender)
        {
        }

        /// <summary>
        /// 视图卸载
        /// </summary>
        protected virtual void OnViewUnLoaded(object? sender)
        {
        }

        /// <summary>
        /// 显示状态变更
        /// </summary>
        protected virtual void OnVisibleChanged(object? sender)
        {
        }

        /// <summary>
        /// 导入
        /// </summary>
        protected virtual void OnImport(object? sender)
        {
        }

        /// <summary>
        /// 打印
        /// </summary>
        protected virtual void OnPrint(object? sender)
        {
        }

        /// <summary>
        /// 预览
        /// </summary>
        protected virtual void OnPreview(object? sender)
        {
        }

        /// <summary>
        /// 导出
        /// </summary>
        protected virtual void OnExport(object? sender)
        {
        }

        /// <summary>
        /// 保存
        /// </summary>
        protected virtual void OnSave(object? sender)
        {
        }

        /// <summary>
        /// 另存为
        /// </summary>
        protected virtual void OnSaveAs(object? sender)
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        protected virtual void OnAdd(object? sender)
        {
        }

        /// <summary>
        /// 激活
        /// </summary>
        protected virtual void OnActivate(object? sender)
        {
        }

        /// <summary>
        /// 删除
        /// </summary>
        protected virtual void OnDelete(object? sender)
        {
        }

        /// <summary>
        /// 启用
        /// </summary>
        protected virtual void OnEnable(object? sender)
        {
        }

        /// <summary>
        /// 修改
        /// </summary>
        protected virtual void OnModify(object? sender)
        {
        }

        /// <summary>
        /// 恢复
        /// </summary>
        protected virtual void OnRevert(object? sender)
        {
        }

        /// <summary>
        /// 查询
        /// </summary>
        protected virtual void OnQuery(object? sender)
        {
        }

        /// <summary>
        /// 刷新
        /// </summary>
        protected virtual void OnRefresh(object? sender)
        {
        }

        /// <summary>
        /// 取消
        /// </summary>
        protected virtual void OnCancel(object? sender)
        {
        }

        /// <summary>
        /// 确认
        /// </summary>
        protected virtual void OnConfirm(object? sender)
        {
        }

        /// <summary>
        /// 上传
        /// </summary>
        protected virtual void OnUpload(object? sender)
        {
        }

        /// <summary>
        /// 下载
        /// </summary>
        protected virtual void OnDownload(object? sender)
        {
        }

        /// <summary>
        /// 关闭
        /// </summary>
        protected virtual void OnClose(object? sender)
        {
        }

        /// <summary>
        /// 关闭中
        /// </summary>
        protected virtual bool OnClosing(object? sender)
        {
            return true;
        }

        /// <summary>
        /// 已关闭
        /// </summary>
        protected virtual void OnClosed(object? sender)
        {
        }

        /// <summary>
        /// 对话框关闭
        /// </summary>
        protected virtual void OnDialogClose(object? sender)
        {
        }

        /// <summary>
        /// 登录
        /// </summary>
        protected virtual void OnLogin(object? sender)
        {
        }

        /// <summary>
        /// 异步加载数据（子类可重写）
        /// </summary>
        protected virtual Task OnLoadDataAsync(object? sender)
        {
            return Task.CompletedTask;
        }

        #endregion Virtual Methods

        #region IDisposable Implementation

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing)
            {
                // 清理托管资源
                ViewCloseEvent = null;
                ViewClosingEvent = null;
                ViewClosedEvent = null;
                DialogCloseEvent = null;
            }

            _isDisposed = true;
        }

        #endregion IDisposable Implementation
    }

    /// <summary>
    /// 支持泛型参数的 ViewModel 基类
    /// </summary>
    /// <typeparam name="TParameter">导航参数类型</typeparam>
    public partial class ZeroViewModel<TParameter> : ZeroViewModel
        where TParameter : class
    {
        /// <summary>
        /// 导航参数
        /// </summary>
        [ObservableProperty]
        public partial TParameter? Parameter { get; set; }

        /// <summary>
        /// 初始化方法，在参数设置后调用
        /// </summary>
        public virtual Task InitializeAsync(TParameter? parameter)
        {
            Parameter = parameter;
            return OnInitializedAsync();
        }

        /// <summary>
        /// 初始化完成后的回调
        /// </summary>
        protected virtual Task OnInitializedAsync()
        {
            return Task.CompletedTask;
        }
    }
}