# ViewModelBase

试图模型基类。
预设常用的命令和基本属性。

## 属性

| 属性名                | 参数          | 说明           |
| --------------------- | ------------- | -------------- |
| EditCommand           | RelayCommand? | 编辑命令       |
| VisibleChangedCommand | RelayCommand? | 显示变化       |
| ViewLoadedCommand     | RelayCommand? | 视图加载命令   |
| ViewUnLoadedCommand   | RelayCommand? | 视图卸载命令   |
| OpenCommand           | RelayCommand? | 打开命令       |
| ImportCommand         | RelayCommand? | 导入命令       |
| ExportCommand         | RelayCommand? | 导出命令       |
| PreviewCommand        | RelayCommand? | 预览           |
| PrintCommand          | RelayCommand? | 打印命令       |
| SaveCommand           | RelayCommand? | 保存命令       |
| SaveAsCommand         | RelayCommand? | 另存为命令     |
| AddCommand            | RelayCommand? | 增加命令       |
| DeleteCommand         | RelayCommand? | 删除命令       |
| ModifyCommand         | RelayCommand? | 修改           |
| RevertCommand         | RelayCommand? | 恢复命令       |
| QueryCommand          | RelayCommand? | 查询命令       |
| RefreshCommand        | RelayCommand? | 刷新           |
| CancelCommand         | RelayCommand? | 取消命令       |
| ConfirmCommand        | RelayCommand? | 确认命令       |
| UploadCommand         | RelayCommand? | 上传命令       |
| DownloadCommand       | RelayCommand? | 下载命令       |
| CloseCommand          | RelayCommand? | 关闭命令       |
| ClosingCommand        | RelayCommand? | 关闭中命令     |
| ClosedCommand         | RelayCommand? | 已关闭命令     |
| DialogCloseCommand    | RelayCommand? | 对话框关闭命令 |
| LoginCommand          | RelayCommand? | 登录命令       |
| IsModelEnabled        | bool          | 模块是否使能   |
| IsOn                  | bool          | 是否启动       |
| IsViewLoaded          | bool          | 是否已加载     |
| IsDataLoading         | bool          | 数据加载中     |
| IsEdit                | bool          | 是否启动编辑   |
| ViewTitle             | string?       | 标题           |
| Prompt                | string?       | 提示           |
| Visibility            | Visibility    | 可见属性       |

## 方法

| 函数                                               | 说明                                   |
| -------------------------------------------------- | -------------------------------------- |
| public virtual void Edit(object? sender)           | 编辑，默认半丁EditCommand              |
| public virtual void ViewLoaded(object? sender)     | 页面加载，加载后 IsViewLoaded置为true  |
| public virtual void ViewUnLoaded(object? sender)   | 卸载页面，卸载后 IsViewLoaded置为false |
| public virtual void VisibleChanged(object? sender) | 可见属性变更                           |
| public virtual void Import(object? sender)         | 导入函数                               |
| public virtual void Print(object? sender)          | 打印函数                               |
| public virtual void Preview(object? sender)        | 预览函数                               |
| public virtual void Export(object? sender)         | 导出函数                               |
| public virtual void Save(object? sender)           | 保存函数                               |
| public virtual void SaveAs(object? sender)         | 另存为                                 |
| public virtual void Add(object? sender)            | 添加函数                               |
| public virtual void Delete(object? sender)         | 删除                                   |
| public virtual void Modify(object? sender)         | 修改                                   |
| public virtual void Revert(object? sender)         | 恢复函数                               |
| public virtual void Query(object? sender)          | 查询函数                               |
| public virtual void Refresh(object? sender)        | 刷新                                   |
| public virtual void Cancel(object? sender)         | 取消                                   |
| public virtual void Confirm(object? sender)        | 确认                                   |
| public virtual void Upload(object? sender)         | 上传                                   |
| public virtual void Download(object? sender)       | 下载                                   |
| public virtual void Close(object? sender)          | 关闭                                   |
| public virtual void Closing(object? sender)        | 关闭中                                 |
| public virtual void Closed(object? sender)         | 已关闭                                 |
| public virtual void DialogClose(object? sender)    | 对话框关闭                             |
| public virtual void Login(object? sender)          | 登录                                   |

使用时，Xaml界面绑定对应的Command，C#页面直接重写对应的方法即可，基类模型默认关联对应的函数方法。

## 事件

| 事件                                                 | 说明                                                   |
| ---------------------------------------------------- | ------------------------------------------------------ |
| public Action? ViewCloseEvent { get; set; }          | 试图关闭事件，调用CloseCommand后触发                   |
| public Action<bool>? ViewClosingEvent { get; set; }  | 试图关闭中事件，调用ClosingCommand后触发，默认参数true |
| public Action? ViewClosedEvent { get; set; }         | 试图关闭事件，调用ClosedCommand后触发                  |
| public Action<bool?>? DialogCloseEvent { get; set; } | 对话框关闭事件，调用DialogCloseCommand后自动触发       |

## 示例

### 关闭窗体

#### 实现ICloseWindow接口，然后再ViewModel关闭

窗体实现接口

```CSharp
    public partial class LoginWindow : Window, ICloseWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        public void CloseWindow()
        {
            this.Close();
        }
    }

```

Xaml中传递窗体参数

```Xaml
    <zctrl:ZeroButton Command="{Binding CloseCommand}" 
    CommandParameter="{Binding RelativeSource={RelativeSource AncestorType=local:LoginWindow}}"  
    Style="{StaticResource AMAS.Button.Cancel.OnlyIcon.Style}"/>
```

ViewModel中通过接口关闭窗体。

```CSharp

        /// <summary>
        /// 关闭窗口事件
        /// </summary>
        /// <param name="sender"></param>
        public override void Close(object? sender)
        {
            if (sender == null) return;
            ICloseWindow window = (ICloseWindow)sender;
            window.CloseWindow();
        }
```

#### 通过ViewCloseEvent关闭窗体

View中关联事件。

```CSharp
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            var viewModel = this.DataContext as LoginWindowViewModel;
            viewModel?.ViewCloseEvent += this.Close();
        }
    }
```

Xaml中关联CloseCommand

```Xaml
    <zctrl:ZeroButton Command="{Binding CloseCommand}" 
    Style="{StaticResource AMAS.Button.Cancel.OnlyIcon.Style}"/>
```

ViewModel中触发关闭事件，这个事件默认再ViewModelBase中已经调用，若无其他逻辑需求，结成ViewModeBase的类可以不用重新重写，直接绑定CloseCommand即可自动触发。

```Csharp
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Close(object? sender)
        {
            ViewCloseEvent?.Invoke();
        }
```
