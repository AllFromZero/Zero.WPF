using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Zero.WPF.Core.Enums;

namespace Zero.WPF.Controls
{
    /// <summary>
    /// 自定义文本框控件
    /// </summary>
    public partial class ZeroTextBox : TextBox
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        static ZeroTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZeroTextBox), new FrameworkPropertyMetadata(typeof(ZeroTextBox)));
        }

        #region 文本

        /// <summary>
        /// 蒙版文本颜色属性委托
        /// </summary>
        public static readonly DependencyProperty MaskTextProperty =
            DependencyProperty.Register("MaskText", typeof(string), typeof(ZeroTextBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 蒙版文字
        /// </summary>
        [Bindable(true)]
        [Description("蒙版文本")]
        [Localizability(LocalizationCategory.Text)]
        public string? MaskText
        {
            get
            {
                return (string)GetValue(MaskTextProperty);
            }
            set
            {
                SetValue(MaskTextProperty, value);
            }
        }

        #endregion 文本

        #region 画笔

        /// <summary>
        /// 蒙版文本颜色属性委托
        /// </summary>
        public static readonly DependencyProperty MaskTextForegroundProperty =
            DependencyProperty.Register("MaskTextForeground", typeof(Brush), typeof(ZeroTextBox), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Gray), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 蒙版文本颜色
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [Description("蒙版文本颜色")]
        public Brush MaskTextForeground
        {
            get { return (Brush)GetValue(MaskTextForegroundProperty); }
            set { SetValue(MaskTextForegroundProperty, value); }
        }

        #endregion 画笔


        #region 布局

        /// <summary>
        /// 圆角属性委托
        /// CornerRadius：用于调用的委托名字
        /// typeof(ZeroTextBox)：指定控件
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ZeroTextBox), new FrameworkPropertyMetadata(new CornerRadius(5), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 定义圆角属性
        /// </summary>
        [Bindable(true)]
        [Category("Layout")]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        #endregion 布局
    }
}
