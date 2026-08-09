using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Zero.WPF.Core.MVVM
{
    /// <summary>
    /// 试图模型基类
    /// </summary>
    [Serializable]
    public class ViewModelBase : NotifyPropertyChanged
    {
        #region Private Property

        /// <summary>
        /// 标题
        /// </summary>
        private string? _viewTitle = null;
        /// <summary>
        /// 模块是否使能标识
        /// </summary>
        private bool isModelEnabled = true;
        /// <summary>
        /// 是否打开标识
        /// </summary>
        protected bool isOn = false;
        /// <summary>
        /// 是否编辑标识
        /// </summary>
        private bool isEdit = false;
        /// <summary>
        /// 是否已加载
        /// </summary>
        private bool isViewLoaded = false;
        /// <summary>
        /// 是否正在加载数据
        /// </summary>
        private bool isDataLoading = false;
        /// <summary>
        /// 提示
        /// </summary>
        private string? _prompt = string.Empty;

        /// <summary>
        /// 试图可视属性
        /// </summary>
        private Visibility _visibility = Visibility.Visible;

        #endregion Private Property

        #region Event
        /// <summary>
        /// 视图关闭事件
        /// </summary>
        public Action? ViewCloseEvent { get; set; }
        /// <summary>
        /// 试图关闭中事件
        /// </summary>
        /// <remarks>True:Close, False:Cancle</remarks>
        public Action<bool>? ViewClosingEvent { get; set; }
        /// <summary>
        /// 试图已关闭事件
        /// </summary>
        /// <remarks>True:Close, False:Cancle</remarks>
        public Action? ViewClosedEvent { get; set; }
        /// <summary>
        /// 对话框关闭事件
        /// </summary>
        public Action<bool?>? DialogCloseEvent { get; set; }

        #endregion Event

        #region Command

        /// <summary>
        /// 编辑命令
        /// </summary>
        public RelayCommand? EditCommand { get; set; }

        /// <summary>
        /// 显示变化
        /// </summary>
        public RelayCommand? VisibleChangedCommand { get; set; }

        /// <summary>
        /// 视图加载命令
        /// </summary>
        public RelayCommand? ViewLoadedCommand { get; set; }

        /// <summary>
        /// 视图卸载命令
        /// </summary>
        public RelayCommand? ViewUnLoadedCommand { get; set; }

        /// <summary>
        /// 打开命令
        /// </summary>
        public RelayCommand? OpenCommand { get; set; }

        /// <summary>
        /// 导入命令
        /// </summary>
        public RelayCommand? ImportCommand { get; set; }
        /// <summary>
        /// 导出命令
        /// </summary>
        public RelayCommand? ExportCommand { get; set; }

        /// <summary>
        /// 预览
        /// </summary>
        public RelayCommand? PreviewCommand { get; set; }

        /// <summary>
        /// 打印命令
        /// </summary>
        public RelayCommand? PrintCommand { get; set; }

        /// <summary>
        /// 保存命令
        /// </summary>
        public RelayCommand? SaveCommand { get; set; }

        /// <summary>
        /// 另存为命令
        /// </summary>
        public RelayCommand? SaveAsCommand { get; set; }

        /// <summary>
        /// 增加命令
        /// </summary>
        public RelayCommand? AddCommand { get; set; }

        /// <summary>
        /// 删除命令
        /// </summary>
        public RelayCommand? DeleteCommand { get; set; }

        /// <summary>
        /// 修改
        /// </summary>
        public RelayCommand? ModifyCommand { get; set; }

        /// <summary>
        /// 恢复命令
        /// </summary>
        public RelayCommand? RevertCommand { get; set; }

        /// <summary>
        /// 查询命令
        /// </summary>
        public RelayCommand? QueryCommand { get; set; }

        /// <summary>
        /// 刷新
        /// </summary>
        public RelayCommand? RefreshCommand { get; set; }

        /// <summary>
        /// 取消命令
        /// </summary>
        public RelayCommand? CancelCommand { get; set; }

        /// <summary>
        /// 确认命令
        /// </summary>
        public RelayCommand? ConfirmCommand { get; set; }

        /// <summary>
        /// 上传命令
        /// </summary>
        public RelayCommand? UploadCommand { get; set; }

        /// <summary>
        /// 下载命令
        /// </summary>
        public RelayCommand? DownloadCommand { get; set; }
        /// <summary>
        /// 关闭命令
        /// </summary>
        public RelayCommand? CloseCommand { get; set; }
        /// <summary>
        /// 关闭中命令
        /// </summary>
        public RelayCommand? ClosingCommand { get; set; }
        /// <summary>
        /// 已关闭命令
        /// </summary>
        public RelayCommand? ClosedCommand { get; set; }
        /// <summary>
        /// 对话框关闭命令
        /// </summary>
        public RelayCommand? DialogCloseCommand { get; set; }
        /// <summary>
        /// 登录
        /// </summary>
        public RelayCommand? LoginCommand { get; set; }


        #endregion Command

        #region Public Property

        /// <summary>
        /// 模块是否使能
        /// </summary>
        public bool IsModelEnabled
        {
            get => isModelEnabled;
            set
            {
                isModelEnabled = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 是否启动
        /// </summary>
        public bool IsOn
        {
            get => isOn;
            set
            {
                isOn = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 是否已加载
        /// </summary>
        public bool IsViewLoaded
        {
            get => isViewLoaded;
            set
            {
                isViewLoaded = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 数据加载中
        /// </summary>
        public bool IsDataLoading
        {
            get => isDataLoading;
            set
            {
                isDataLoading = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 是否启动编辑
        /// </summary>
        public bool IsEdit
        {
            get => isEdit;
            set
            {
                isEdit = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string? ViewTitle
        {
            get => _viewTitle;
            set
            {
                _viewTitle = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 提示
        /// </summary>
        public string? Prompt
        {
            get => _prompt;
            set
            {
                _prompt = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 可见属性
        /// </summary>
        public Visibility Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }

        #endregion  Public Property

        /// <summary>
        /// 构造函数
        /// </summary>
        public ViewModelBase()
        {
            EditCommand = new RelayCommand()
            {
                DoExecute = new Action<object?>(Edit),
            };
            VisibleChangedCommand = new RelayCommand()
            {
                DoExecute = new Action<object?>(VisibleChanged),
            };
            ViewLoadedCommand = new RelayCommand()
            {
                DoExecute = new Action<object?>(ViewLoaded),
            };
            ViewUnLoadedCommand = new RelayCommand()
            {
                DoExecute = new Action<object?>(ViewUnLoaded),
            };
            ImportCommand = new RelayCommand(Import);
            PrintCommand = new RelayCommand(Print);
            PreviewCommand = new RelayCommand(Preview);
            ExportCommand = new RelayCommand()
            {
                DoExecute = new Action<object?>(Export),
            };
            SaveCommand = new RelayCommand()
            {
                DoExecute = new Action<object?>(Save),
            };
            SaveAsCommand = new RelayCommand(SaveAs);
            AddCommand = new RelayCommand()
            {
                DoExecute = new Action<object?>(Add),
            };
            DeleteCommand = new RelayCommand()
            {
                DoExecute = new Action<object?>(Delete),
            };
            ModifyCommand = new RelayCommand()
            {
                DoExecute = new Action<object?>(Modify),
            };
            RevertCommand = new RelayCommand()
            {
                DoExecute = new Action<object?>(Revert),
            };
            QueryCommand = new RelayCommand(Query);
            RefreshCommand = new RelayCommand(Refresh);
            CancelCommand = new RelayCommand(Cancel);
            ConfirmCommand = new RelayCommand(Confirm);
            UploadCommand = new RelayCommand(Upload);
            DownloadCommand = new RelayCommand(Download);
            CloseCommand = new RelayCommand(Close);
            ClosingCommand = new RelayCommand(Closing);
            ClosedCommand = new RelayCommand(Closed);
            DialogCloseCommand = new RelayCommand(DialogClose);
            LoginCommand = new RelayCommand(Login);
        }

        #region Method

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Edit(object? sender)
        {

        }

        /// <summary>
        /// Loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <remarks>默认调用后IsViewLoaded设置为true，重写时需要调用 base.ViewLoaded.</remarks>
        public virtual void ViewLoaded(object? sender)
        {
            IsViewLoaded = true;
        }

        /// <summary>
        /// View UnLoaded
        /// </summary>
        /// <param name="sender"></param>
        /// <remarks>默认调用后IsViewLoaded设置为true，重写时需要调用 base.ViewLoaded.</remarks>
        public virtual void ViewUnLoaded(object? sender)
        {
            IsViewLoaded = false;
        }

        /// <summary>
        /// 显示状态变更
        /// </summary>
        /// <param name="sender"></param>
        public virtual void VisibleChanged(object? sender)
        {

        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Import(object? sender)
        {

        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Print(object? sender)
        {

        }

        /// <summary>
        /// 预览
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Preview(object? sender)
        {

        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Export(object? sender)
        {

        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Save(object? sender)
        {

        }

        /// <summary>
        /// 另存为
        /// </summary>
        /// <param name="sender"></param>
        public virtual void SaveAs(object? sender)
        {

        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Add(object? sender)
        {

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Delete(object? sender)
        {

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Modify(object? sender)
        {

        }

        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Revert(object? sender)
        {

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Query(object? sender)
        {

        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Refresh(object? sender)
        {

        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Cancel(object? sender)
        {

        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Confirm(object? sender)
        {

        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Upload(object? sender)
        {

        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Download(object? sender)
        {

        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Close(object? sender)
        {
            ViewCloseEvent?.Invoke();
        }

        /// <summary>
        /// 关闭中
        /// </summary>
        /// <param name="sender"></param>
        /// <remarks>默认出发事件，发送关闭中指令，参数true</remarks>
        public virtual void Closing(object? sender)
        {
            ViewClosingEvent?.Invoke(true);
        }

        /// <summary>
        /// 已关闭
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Closed(object? sender)
        {
            ViewClosedEvent?.Invoke();
        }

        /// <summary>
        /// 对话框关闭
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DialogClose(object? sender)
        {
            bool? result = sender as bool?;
            DialogCloseEvent?.Invoke(result);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Login(object? sender)
        {

        }

        #endregion Method
    }
}
