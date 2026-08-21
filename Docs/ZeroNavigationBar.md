# ZeroNavigationBar

通用导航栏控件；
![alt text](Images/ZeroNavigationBar.png)
可配合[NavigationViewModel](NavigationViewModel.md)控件使用。
默认样式已经全部绑定视图模型指令和参数。

```Csharp
        <Setter Property="TargetPage" Value="{Binding TargetPage}"/>
        <Setter Property="TotalPageCnt" Value="{Binding TotalPageCnt}"/>
        <Setter Property="CurrentPage" Value="{Binding CurrentPage}"/>
        <Setter Property="StartIndex" Value="{Binding StartIndex}"/>
        <Setter Property="TotalDataCnt" Value="{Binding TotalDataCnt}"/>
        <Setter Property="OnePageCnt" Value="{Binding OnePageCnt}"/>
        <Setter Property="FirstPageCommand" Value="{Binding FirstPageCommand}"/>
        <Setter Property="PreviousPageCommand" Value="{Binding PreviousPageCommand}"/>
        <Setter Property="GoToPageCommand" Value="{Binding GoToPageCommand}"/>
        <Setter Property="NextPageCommand" Value="{Binding NextPageCommand}"/>
        <Setter Property="LastPageCommand" Value="{Binding LastPageCommand}"/>
```

## 基本使用

使用时只需将控件添加到Xaml中，该xaml的DataContext绑定NavigationViewModel或其子类，既可以，直接使用。
对应属性和按钮指令直接绑定到ViewModel中。

```CSharp

<zctrl:ZeroNavigationBar VerticalAlignment="Bottom"></zctrl:ZeroNavigationBar>

```
