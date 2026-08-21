# NavigationViewModel

分页浏览试图模型。

## 属性

| 属性名              | 参数         | 说明                                              |
| ------------------- | ------------ | ------------------------------------------------- |
| FirstPageCommand    | RelayCommand | 用于设置控件外边框的圆角属性                      |
| PreviousPageCommand | RelayCommand |                                                   |
| NextPageCommand     | RelayCommand | 用于设置图标相对应文本的位置                      |
| LastPageCommand     | RelayCommand | 设置图标的边距，默认设置图标在左，与右侧文本间距5 |
| GotoPageCommand     | RelayCommand | 蒙版颜色画刷，可设置鼠标移过和下按时的颜色属性    |
| TargetPage          | int          | 目标页数                                          |
| TotalCnt            | int          | 数据总数                                          |
| TotalPageCnt        | int          | 总页数                                            |
| CurrentPage         | int          | 当前页面                                          |
| StartIndex          | int          | 当前页面起始数据编号                              |
| OnePageCnt          | int          | 单页记录数量                                      |

## 私有方法

| 函数                                      | 说明                                                                 |
| ----------------------------------------- | -------------------------------------------------------------------- |
| private void FirstPage(object? sender)    | 第一页                                                               |
| private void NextPage(object? sender)     | 下一页                                                               |
| private void PreviousPage(object? sender) | 上一页                                                               |
| private void GoToPage(object? sender)     | 导航到指定页面                                                       |
| private void LastPage(object? sender)     | 最后一页                                                             |

## 可重写方法

| 函数                                                   | 说明                                                                 |
| ------------------------------------------------------ | -------------------------------------------------------------------- |
| protected virtual void OnGoToPage(int target)          | 导航到页面                                                          |
| protected virtual bool QueryPage()                     | 查询记录，需要重新方法，否则会报错。使使用时需要更新StartIndex属性。 |
| protected virtual void OnFirstPage(object? sender)     | 第一页                                                               |
| protected virtual void OnNextPage(object? sender)      | 下一页                                                               |
| protected virtual void OnPreviousPage(object? sender)  | 上一页                                                               |
| protected virtual void OnGoToPage(object? sender)      | 导航到指定页面                                                       |
| protected virtual void OnLastPage(object? sender)      | 最后一页                                                             |
| protected virtual void ShowGoToPageError(Exception ex) | 切换页面失败                                                         |
| protected virtual void ShowTargetPageTooLargeWarning() | 页数太大回调方法                                                     |
| protected virtual void ShowPageTooLessWarning()        | 页数太小方法                                                         |
| protected virtual void ShowFirstPageWarning()          | 已经是首页                                                           |
| protected virtual void ShowLastPageWarning()           | 已经是首页                                                           |
