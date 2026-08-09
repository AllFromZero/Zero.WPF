using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zero.WPF.Controls
{
    /// <summary>
    /// 分页控件
    /// </summary>
    public class ZeroTabControl : TabControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        static ZeroTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZeroTabControl), new FrameworkPropertyMetadata(typeof(ZeroTabControl)));
        }

        /// <summary>
        /// 页标题可见性委托
        /// TabHeaderVisibility：用于调用的委托名字
        /// typeof(UdTabControl)：指定控件
        /// </summary>
        public static readonly DependencyProperty TabHeaderVisibilityProperty = DependencyProperty.Register("TabHeaderVisibility", typeof(Visibility), typeof(ZeroTabControl), new FrameworkPropertyMetadata(Visibility.Visible, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 页标题可见性
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        public Visibility TabHeaderVisibility
        {
            get { return (Visibility)GetValue(TabHeaderVisibilityProperty); }
            set { SetValue(TabHeaderVisibilityProperty, value); }
        }
    }
}
