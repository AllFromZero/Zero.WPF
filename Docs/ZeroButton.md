# ZeroButton

按钮控件，在WPF基础控件的基础上增加圆角，图标等属性。

## 属性

| 属性名         | 参数         | 说明                                                                                                 |
| -------------- | ------------ | ---------------------------------------------------------------------------------------------------- |
| CornerRadius   | CornerRadius | 用于设置控件外边框的圆角属性                                                                         |
| Icon           | Object       | 设置按钮的图标样式，推荐使用TextBlock控件结合字体图标设置，参考[ZeroIcons.ttf](ZeroIcons.md)字体类库 |
| IconWidth      | double       | 图标宽度，默认自动宽度                                                                               |
| IconHeight     | double       | 图标高度，默认自动高度                                                                               |
| IconAlignment  | Dock         | 用于设置图标相对应文本的位置                                                                         |
| IconMargin     | Thickness    | 设置图标的边距，默认设置图标在左，与右侧文本间距5                                                    |
| MaskBackground | Brush        | 蒙版颜色画刷，可设置鼠标移过和下按时的颜色属性                                                       |
