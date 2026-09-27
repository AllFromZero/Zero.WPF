# ZeroRingProgressBar

环形进度条控件

## 属性

| 属性名                   | 参数       | 说明                                 |
| ------------------------ | ---------- | ------------------------------------ |
| TrackStrokeThickness     | double     | 设置进度条轨道的粗细                 |
| IndicatorStrokeThickness | double     | 设置进度条的粗细                     |
| StrokeDashCap            | PenLineCap | 设置进度条两端样式                   |
| PercentForeground        | Brush      | 设置中间进度的颜色                   |
| IsIndeterminate          | bool       | 是否不确定状态                       |
| IsShowPercent            | bool       | 是否展示百分比进度                   |
| Angle                    | double     | 控件角度，默认-90.0，从顶部开始      |
| IndicatorMargin          | Thickness  | 进度的边距，可以配合调整进度条的位置 |
| TracMargin               | Thickness  | 轨道边距，可以调整轨道的位置         |
| AnimationForeground      | Brush      | 动效颜色，设置进度条转圈时的颜色     |

## 示例

![环形进度条](/Docs/Images/ZeroRingProgressBar.png)

![环形进度条](/Docs/Images/ZeroRingProgressBar1.png)

以上四种样式分别对应如下配置：

```Xaml
    <zctrl:ZeroRingProgressBar Maximum="100" Value="{Binding ElementName=valueSlider, Path=Value}" IsIndeterminate="True" IsShowPercent="False" Minimum="0" Height="50" Width="50" Margin="10"></zctrl:ZeroRingProgressBar>
    <zctrl:ZeroRingProgressBar Maximum="100" Value="{Binding ElementName=valueSlider, Path=Value}" TrackStrokeThickness="10" IndicatorMargin="2.5" Minimum="0" Height="50" Width="50" Margin="10"></zctrl:ZeroRingProgressBar>
    <zctrl:ZeroRingProgressBar Maximum="100" Value="{Binding ElementName=valueSlider, Path=Value}" TrackStrokeThickness="1" TracMargin="2" Minimum="0" Height="50" Width="50" Margin="10"></zctrl:ZeroRingProgressBar>
    <zctrl:ZeroRingProgressBar Maximum="100" Value="{Binding ElementName=valueSlider, Path=Value}" Minimum="0" Height="50" Width="30" Margin="10"></zctrl:ZeroRingProgressBar>

```
