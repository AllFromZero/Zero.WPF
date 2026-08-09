# ZeroNumericBox

数字框，用于数字输入，基于[ZeroTextBox](ZeroTextBox.md)扩展。

## 属性

| 属性名         | 参数         | 说明                                                             |
| -------------- | ------------ | ---------------------------------------------------------------- |
| CornerRadius   | CornerRadius | 用于设置控件外边框的圆角属性                                     |
| DecimalPlaces  | byte         | 小数位数，用于设置小数行驶小数点之后的数据位数，默认四舍五入取整 |
| MaxValue       | decimal      | 数字框允许输入的最大值，超出最大值值时自动将结果修改成最大值     |
| MinValue       | decimal      | 数字框允许输入的最小值，超出最小值值时自动将结果修改成最小值     |
| DecimalValue   | decimal？    | 数值，可空类型，输入空字符串时为null值                           |
| MaskTextForeground | Brush        | 掩码文本的字体颜色           |
| MaskText           | string?      | 掩码文本，默认Text为空时显示 |

## 注意事项

Xaml中绑定数据时需要有注意顺序，将参数值设置在前，DecimalValue最后设置，才可正常展示。
如：小数位数默认为0，设置为2，但是设置参数在DecimalValue之后，则编辑器不会刷新，需要编译后才能刷新。
正确示例如下：

```Wpf
<zctrl:ZeroNumericBox x:Name="zeroNumBox" MinValue="-100" DecimalPlaces="2" DecimalValue="-10.10" InputScope="Number"/>

```
