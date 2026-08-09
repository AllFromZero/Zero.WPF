# ZeroComboBox

组合框，在WPF基础控件的基础上增加圆角，图标等属性。

## 属性

| 属性名                 | 参数         | 说明                                              |
| ---------------------- | ------------ | ------------------------------------------------- |
| CornerRadius           | CornerRadius | 用于设置控件外边框的圆角属性                      |
| MaskBackground         | Brush        | 蒙版颜色画刷，可设置鼠标移过和下按时的颜色属性    |
| ToggleButtonForeground | Brush        | 下拉列表按钮字体颜色                              |
| SelectedItems          | IList?       | 多选模式下，下下拉列表的多多选项。                |
| IsMultiSelect          | bool         | 是否支持多选的配置项                              |
| SplitChar              | char         | 多选时用于分割组合框中显示值的分割字符，默认时‘;’ |

## ZeroComboBox 方法

| 属性名        | 参数 | 说明     |
| ------------- | ---- | -------- |
| SelectedAll   | void | 全选方法 |
| UnSelectedAll | void | 取消全选 |
