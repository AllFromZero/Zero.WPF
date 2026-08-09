# ZeroRadioButton

单选按钮控件，在WPF基础控件的基础上增加圆角，图标等属性。

## 属性

| 属性名              | 参数         | 说明                                              |
| ------------------- | ------------ | ------------------------------------------------- |
| CornerRadius        | CornerRadius | 用于设置控件外边框的圆角属性                      |
| Icon                | Object       | 设置按钮的图标，为空时默认使用WPF默认的原点图标   |
| IconWidth           | double       | 图标宽度，默认自动宽度                            |
| IconHeight          | double       | 图标高度，默认自动高度                            |
| IsCheckedIcon       | Object       | 选中图标选中时的图标                              |
| IsCheckedFontWeight | FontWeight   | 用于设置选中时的字体                              |
| IconAlignment       | Dock         | 用于设置图标相对应文本的位置                      |
| IconMargin          | Thickness    | 设置图标的边距，默认设置图标在左，与右侧文本间距5 |
| MaskBackground      | Brush        | 蒙版颜色画刷，可设置鼠标移过和下按时的颜色属性    |
| IsCheckedForeground | Brush        | 选中时的字体颜色                                  |
| IsCheckedBackground | Brush        | 选中时的背景颜色                                  |
