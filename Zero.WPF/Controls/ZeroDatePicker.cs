using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Zero.WPF.Controls
{
    /// <summary>
    /// 日期框
    /// </summary>
    public class ZeroDatePicker : DatePicker
    {

        static ZeroDatePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZeroDatePicker), new FrameworkPropertyMetadata(typeof(ZeroDatePicker)));
        }

        /// <summary>
        /// 按键属性委托
        /// CornerRadius：用于调用的委托名字
        /// typeof(UdButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ZeroDatePicker), new FrameworkPropertyMetadata());

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
    }
}
