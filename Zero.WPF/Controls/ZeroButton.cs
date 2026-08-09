using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Automation;
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
    /// 自定义按钮控件
    /// </summary>
    /// <remarks>在控件基础上，增加圆角等自定义内容</remarks>
    public class ZeroButton : Button
    {
        static ZeroButton()
        {
            //                                              新创建的控件名                  模板名，资源字典（如ZeroButton.xaml），如果要跟旧的一样，直接填“Button”
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZeroButton), new FrameworkPropertyMetadata(typeof(ZeroButton)));
        }

        /// <summary>
        /// 圆角属性委托
        /// CornerRadius：用于调用的委托名字
        /// typeof(ZeroButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ZeroButton), new FrameworkPropertyMetadata(new CornerRadius(5), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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

        #region Icon

        /// <summary>
        /// 图标属性委托
        /// Icon：用于调用的委托名字
        /// typeof(ZeroButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(object), typeof(ZeroButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 图标属性
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        public object Icon
        {
            get { return (object)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// 图标宽度属性委托
        /// Icon：用于调用的委托名字
        /// typeof(ZeroButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register("IconWidth", typeof(double), typeof(ZeroButton), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 图标宽度属性
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public double IconWidth
        {
            get { return (double)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        /// <summary>
        /// 图标高度属性委托
        /// Icon：用于调用的委托名字
        /// typeof(ZeroButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register("IconHeight", typeof(double), typeof(ZeroButton), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 图标高度属性
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [TypeConverter(typeof(LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public double IconHeight
        {
            get { return (double)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }

        /// <summary>
        /// 图标对齐属性委托
        /// IconAlignment：用于调用的委托名字
        /// typeof(ZeroButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty IconAlignmentProperty = DependencyProperty.Register("IconAlignment", typeof(Dock), typeof(ZeroButton), new FrameworkPropertyMetadata(Dock.Left, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 定义图标对齐属性
        /// </summary>
        [Bindable(true)]
        [Category("Layout")]
        public Dock IconAlignment
        {
            get { return (Dock)GetValue(IconAlignmentProperty); }
            set { SetValue(IconAlignmentProperty, value); }
        }

        /// <summary>
        /// 图标边距属性委托
        /// IconMargin：用于调用的委托名字
        /// typeof(ZeroButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register("IconMargin", typeof(Thickness), typeof(ZeroButton), new FrameworkPropertyMetadata(new Thickness(0,0,5,0), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 图标边距属性
        /// </summary>
        [Bindable(true)]
        [Category("Layout")]
        public Thickness IconMargin
        {
            get { return (Thickness)GetValue(IconMarginProperty); }
            set { SetValue(IconMarginProperty, value); }
        }

        #endregion Icon

        /// <summary>
        /// 蒙板背景色属性委托
        /// </summary>
        public static readonly DependencyProperty MaskBackgroundProperty =
            DependencyProperty.Register("MaskBackground", typeof(Brush), typeof(ZeroButton), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.DarkGray) { Opacity = 0.2 }, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 鼠标覆盖或者点击时控件表面覆盖的蒙版颜色
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [Description("鼠标覆盖或者点击时控件表面覆盖的蒙版颜色")]
        public Brush MaskBackground
        {
            get { return (Brush)GetValue(MaskBackgroundProperty); }
            set { SetValue(MaskBackgroundProperty, value); }
        }



    }
}
