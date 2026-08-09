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
using Zero.WPF.Core.Enums;

namespace Zero.WPF.Controls
{
    /// <summary>
    /// 自定义单选按钮控件
    /// </summary>
    public class ZeroRadioButton : RadioButton
    {
        /// <summary>
        /// 初始化 <see cref="ZeroRadioButton"/> 类的新实例。
        /// </summary>
        static ZeroRadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZeroRadioButton), new FrameworkPropertyMetadata(typeof(ZeroRadioButton)));
        }

        #region 画笔

        /// <summary>
        /// 蒙板背景色属性委托
        /// </summary>
        public static readonly DependencyProperty MaskBackgroundProperty =
            DependencyProperty.Register("MaskBackground", typeof(Brush), typeof(ZeroRadioButton)
            , new FrameworkPropertyMetadata(new SolidColorBrush(Colors.DarkGray) { Opacity = 0.2 }, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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

        /// <summary>
        /// 选中字体属性
        /// typeof(ZeroRadioButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty IsCheckedForegroundProperty =
            DependencyProperty.Register("IsCheckedForeground", typeof(Brush), typeof(ZeroRadioButton)
            , new FrameworkPropertyMetadata(new SolidColorBrush(Colors.White), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 选中后的字体颜色
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        public Brush IsCheckedForeground
        {
            get { return (Brush)GetValue(IsCheckedForegroundProperty); }
            set { SetValue(IsCheckedForegroundProperty, value); }
        }

        /// <summary>
        /// 选中背景属性
        /// typeof(ZeroRadioButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty IsCheckedBackgroundProperty =
            DependencyProperty.Register("IsCheckedBackground", typeof(Brush), typeof(ZeroRadioButton)
            , new FrameworkPropertyMetadata(new SolidColorBrush(Colors.DarkGray), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 选中后的背景颜色
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        public Brush IsCheckedBackground
        {
            get { return (Brush)GetValue(IsCheckedBackgroundProperty); }
            set { SetValue(IsCheckedBackgroundProperty, value); }
        }


        /// <summary>
        /// 选中模式字体样式委托
        /// typeof(ZeroRadioButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty IsCheckedFontWeightProperty =
            DependencyProperty.Register("IsCheckedFontWeight", typeof(FontWeight), typeof(ZeroRadioButton)
            , new FrameworkPropertyMetadata(FontWeights.Bold, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 选中模式字体样式
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        public FontWeight IsCheckedFontWeight
        {
            get
            {
                return (FontWeight)GetValue(IsCheckedFontWeightProperty);
            }
            set
            {
                SetValue(IsCheckedFontWeightProperty, value);
            }
        }

        #endregion 画笔

        #region Icon

        /// <summary>
        /// 图标属性委托
        /// Icon：用于调用的委托名字
        /// typeof(ZeroRadioButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(object), typeof(ZeroRadioButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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
        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register("IconWidth", typeof(double), typeof(ZeroRadioButton), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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
        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register("IconHeight", typeof(double), typeof(ZeroRadioButton), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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
        /// 选中图标属性委托
        /// Icon：用于调用的委托名字
        /// typeof(ZeroRadioButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty IsCheckedIconProperty = DependencyProperty.Register("IsCheckedIcon", typeof(object), typeof(ZeroRadioButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 选中图标属性
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        public object IsCheckedIcon
        {
            get { return (object)GetValue(IsCheckedIconProperty); }
            set { SetValue(IsCheckedIconProperty, value); }
        }

        /// <summary>
        /// 图标对齐属性委托
        /// IconAlignment：用于调用的委托名字
        /// typeof(ZeroRadioButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty IconAlignmentProperty = DependencyProperty.Register("IconAlignment", typeof(Dock), typeof(ZeroRadioButton), new FrameworkPropertyMetadata(Dock.Left, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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
        /// typeof(ZeroRadioButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register("IconMargin", typeof(Thickness), typeof(ZeroRadioButton), new FrameworkPropertyMetadata(new Thickness(0, 0, 5, 0), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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

        #region 布局

        /// <summary>
        /// 圆角属性委托
        /// CornerRadius：用于调用的委托名字
        /// typeof(ZeroRadioButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ZeroRadioButton), new FrameworkPropertyMetadata(new CornerRadius(5), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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
