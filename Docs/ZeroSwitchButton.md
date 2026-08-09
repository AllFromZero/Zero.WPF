# ZeroSwitchButton

开关按钮，基于ZeroButton开发，增加样式图标和状态。

## 属性

| 属性名           | 参数         | 说明                                              |
| ---------------- | ------------ | ------------------------------------------------- |
| CornerRadius     | CornerRadius | 用于设置控件外边框的圆角属性                      |
| Icon             | Object       | 设置按钮的图标样式                                |
| IconWidth        | double       | 图标宽度，默认自动宽度                            |
| IconHeight       | double       | 图标高度，默认自动高度                            |
| IconAlignment    | Dock         | 用于设置图标相对应文本的位置                      |
| IconMargin       | Thickness    | 设置图标的边距，默认设置图标在左，与右侧文本间距5 |
| MaskBackground   | Brush        | 蒙版颜色画刷，可设置鼠标移过和下按时的颜色属性    |
| IsOn             | bool?        | 开关状态，三种状态                                |
| IsOnContent      | object       | 开状态显示内容                                    |
| IsNullContent    | object       | Null状态显示内容                                  |
| IsOnIcon         | object       | 开状态图标                                        |
| IsNullIcon       | object       | Null状态图标                                      |
| IsOnForeground   | Brush        | 开状态字体颜色                                    |
| IsOnBackground   | Brush        | 开状态背景颜色                                    |
| IsNullForeground | Brush        | Null状态字体颜色                                  |
| IsNullBackground | Brush        | Null状态背景颜色                                  |
