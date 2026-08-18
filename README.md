# Zero.WPF

WPF控件库

| 命名空间                     | 说明           |
| :--------------------------- | :------------- |
| [Controls](#zerowpfcontrols) | 自定义控件控件 |
| [Core](#zerowpfcore)         | 核心资源集合   |
| [Resource](#zerowpfresource) | 嵌入的资源集合 |
| [Themes](#themes)            | 资源入库       |

## Zero.WPF.Controls

自定义控件命名空间。

### [ZeroButton](Docs/ZeroButton.md)

按钮控件，在WPF基础控件的基础上增加圆角，图标等属性。

### [ZeroCirclePanel](Docs/ZeroCirclePanel.md)

圆形面板，用于支持控件按照圆形分布展示。

### [ZeroComboBox](Docs/ZeroComboBox.md)

组合框，在WPF基础控件的基础上增加圆角，图标等属性。

### [ZeroDatePicker](Docs/ZeroDatePicker.md)

日期选择控件，在WPF基础控件的基础上增加圆角等属性。

### [ZeroLabel](Docs/ZeroLabel.md)

标签控件，在WPF基础控件的基础上增加圆角等属性。

### [ZeroTextBox](Docs/ZeroTextBox.md)

文本输入框，基于WPF控件扩展，增加圆角等属性。

### [ZeroNumericBox](Docs/ZeroNumericBox.md)

数字框，用于数字输入，基于[ZeroTextBox](ZeroTextBox.md)扩展。

### [ZeroPasswordBox](Docs/ZeroPasswordBox.md)

密码框，用于数字输入，基于[ZeroTextBox](ZeroTextBox.md)扩展。

### [ZeroRadioButton](Docs/ZeroRadioButton.md)

单选按钮控件，在WPF基础控件的基础上增加圆角，图标等属性。

### [ZeroSwitchButton](Docs/ZeroSwitchButton.md)

开关按钮，基于ZeroButton开发，增加样式图标和状态。

## Zero.WPF.Converters

转换器资源.
使用方法：

- 可通过合并资源字典添加静态引用[ZeroConverters.xaml](#zeroconvertersxaml)。
- 通过[ZeroConverters](#zeroconverters)静态类直接引用。

### ZeroConverters

转换器静态资源类，将转换器整合合并到该类中。

### AndMultiConverter

与值转换器，对多值绑定的数据执行与操作，并返回结果。

### BooleanIndexMultiConverter

返回多值绑定的bool值类型值第一个符合参数的序号；
ConverterParameter为空是默认为true, 可选状态：False, null。

### BooleanInverterConverter

Bool值取反转换器。

### BooleanToVisibilityConverter

Boolean值转换为可见属性。
ConverterParameter配置为Invert时，会将bool值取反再转换。

| Boolean |      无转换参数      |        Invert        |
| :-----: | :------------------: | :------------------: |
|  true   |  Visibility.Visible  | Visibility.Collapsed |
|  false  | Visibility.Collapsed |  Visibility.Visible  |
|  null   |  Visibility.Hidden   |  Visibility.Hidden   |

### GenderConverter

性别转换器。

|    Gender     | 无转换参数 |
| :-----------: | :--------: |
|  Gender.Male  |     男     |
| Gender.Female |     女     |
| Gender.Other  |    其他    |
| Gender.Unknow |    未知    |

### IntToHexConverter

int值转换为十六进制字符串，默认添加“0x”字符。

### ObjectToStringMultiConverter

将绑定的数据转换为字符串，默认分割字符为空格。
可通过ConverterParameter配置分割字符串。

### OrMultiConverter

将绑定的数据进行或操作，并返回结果。

## Zero.WPF.Core

核心资源空间，如枚举，转换器等等共用的类。

### Zero.WPF.Core.Enums

枚举类型资源

#### IconVariant

图标样式。

| 枚举值   | 说明                                  |
| -------- | ------------------------------------- |
| Normal   | 正常样式，一般时WPF基础控件自带的样式 |
| Hidden   | 隐藏图标                              |
| OnlyIcon | 仅显示图标                            |

#### RotationDirection

旋转方向。

| 枚举值 | 说明   |
| ------ | ------ |
| CW     | 顺时针 |
| CCW    | 逆时针 |

### Interfaces

接口文件空间。

#### ICloseWindow

关闭窗体接口

方法：void CloseWindow();

### MVVM

WPF项目MVVM相关基础配置类型。

#### BrowserPageViewModel

分页浏览试图模型，继承自[ViewModelBase](#viewmodelbase)

详见：[BrowserPageViewModel.md](/Docs/BrowserPageViewModel.md)

#### NotifyPropertyChanged

实现接口INotifyPropertyChanged，用户绑定参数更新。
默认更新委托名为属性名称。

#### RelayCommand

实现ICommand接口，用于绑定命令。

#### ViewModelBase

试图模型基类。
详见：[ViewModelBase.md](/Docs/ViewModelBase.md)

## Zero.WPF.Resource

wpf相关的资源集合，如字体，图标等等。

### Fonts

字体资源空间。

#### ZeroIcons.ttf

图标库基于微软的[Segoe Fluent Icons font](https://learn.microsoft.com/en-us/windows/apps/design/iconography/segoe-fluent-icons-font)图标库进一步完善和补充。

- 图标字体空间，保存1800多个图形。
- 可参考资源[IconCodes.xaml](#iconcodesxaml)的字符串封装。
- 有关Icon图标和名称信息详见[ZeroIcons.md](Docs/ZeroIcons.md)。

### Strings.resx

类库预置的字符串资源。

### Styles

自定义的样式集。

#### TextBlockStyles.xaml

TextBlock的样式集，详[TextBlockStyles.md](/Docs/Styles/TextBlockStyles.md)

## Themes

主题资源空间，WPF类库默认的空间文件夹。

### Generic.xaml

资源入口文件。

### IconCodes.xaml

对ZeroIcons.ttf字体的进一步封装，将字体代码，封装成可识别的文本名称。

### ZeroDefault.xaml

一些默认的样式设置资源，如背景颜色，边框，边距，字体，图标字体等资源，用户设置控件的默认样式。

### ZeroConverters.xaml

预置转换器（[Zero.WPF.Converters](#zerowpfconverters)）的资源字典，默认添加到[Generic.xaml](#genericxaml)

```Xaml
    <zcvt:AndMultiConverter x:Key="Zero.Converter.And"/>
    <zcvt:BooleanIndexMultiConverter x:Key="Zero.Converter.BooleanIndex"/>
    <zcvt:BooleanInverterConverter x:Key="Zero.Converter.BooleanInverter"/>
    <zcvt:BooleanToVisibilityConverter x:Key="Zero.Converter.BooleanToVisibility"/>
    <zcvt:GenderConverter x:Key="Zero.Converter.Gender"/>
    <zcvt:IntToHexConverter x:Key="Zero.Converter.IntToHex"/>
    <zcvt:ObjectToStringMultiConverter x:Key="Zero.Converter.ObjectToString"/>
    <zcvt:OrMultiConverter x:Key="Zero.Converter.Or"/>
```

## 致谢

MIT License
SPDX identifier
MIT
License text
MIT License

Copyright (c) <year> <copyright holders>

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice (including the next paragraph) shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

SPDX web page
https://spdx.org/licenses/MIT.html
Notice
This license content is provided by the SPDX project. For more information about licenses.nuget.org, see our documentation.

Data pulled from spdx/license-list-data on November 6, 2024.