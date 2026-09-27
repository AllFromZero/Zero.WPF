using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// 自定义环形进度条控件
    /// </summary>
    /// <remarks></remarks>
    public class ZeroRingProgressBar : RangeBase
    {
        #region 常量定义
        private const string IndicatorTemplateName = "PART_Indicator";
        private const string PercentName = "PART_Percent";

        #endregion

        #region Private propery
        /// <summary>
        /// 进度
        /// </summary>
        private Ellipse? _indicator;
        /// <summary>
        /// 百分比文本框
        /// </summary>
        private TextBlock? _percent;


        #endregion private property

        /// <summary>
        /// 构造函数，初始化控件
        /// </summary>
        static ZeroRingProgressBar()
        {
            //                                              新创建的控件名                  模板名，资源字典（如ZeroRingProgressBar.xaml），如果要跟旧的一样，直接填“Button”
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZeroRingProgressBar), new FrameworkPropertyMetadata(typeof(ZeroRingProgressBar)));
        }

        /// <summary>
        /// 背景描边宽度
        /// CornerRadius：用于调用的委托名字
        /// typeof(ZeroRingProgressBar)：指定控件
        /// </summary>
        public static readonly DependencyProperty TrackStrokeThicknessProperty =
            DependencyProperty.Register("TrackStrokeThickness"
                , typeof(double)
                , typeof(ZeroRingProgressBar)
                , new FrameworkPropertyMetadata(5.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 背景描边宽度
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        public double TrackStrokeThickness
        {
            get
            {
                return (double)GetValue(TrackStrokeThicknessProperty);
            }
            set
            {
                SetValue(TrackStrokeThicknessProperty, value);
            }
        }

        /// <summary>
        /// 指示器描边宽度
        /// CornerRadius：用于调用的委托名字
        /// typeof(ZeroRingProgressBar)：指定控件
        /// </summary>
        public static readonly DependencyProperty IndicatorStrokeThicknessProperty =
            DependencyProperty.Register("IndicatorStrokeThickness"
                , typeof(double)
                , typeof(ZeroRingProgressBar)
                , new FrameworkPropertyMetadata(5.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 指示器描边宽度
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        public double IndicatorStrokeThickness
        {
            get
            {
                return (double)GetValue(IndicatorStrokeThicknessProperty);
            }
            set
            {
                SetValue(IndicatorStrokeThicknessProperty, value);
            }
        }

        /// <summary>
        /// 进度条样式属性委托
        /// </summary>
        public static readonly DependencyProperty StrokeDashCapProperty =DependencyProperty.Register("StrokeDashCap"
            , typeof(PenLineCap)
            , typeof(ZeroRingProgressBar)
            , new FrameworkPropertyMetadata(PenLineCap.Round, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 进度条样式属性
        /// </summary>
        public PenLineCap StrokeDashCap
        { 
            get
            {
                return (PenLineCap)GetValue(StrokeDashCapProperty);
            }
            set
            {
                SetValue(StrokeDashCapProperty, value);
            }
        }

        /// <summary>
        /// 百分比颜色属性委托
        /// </summary>
        public static readonly DependencyProperty PercentForegroundProperty =
            DependencyProperty.Register("PercentForeground", typeof(Brush), typeof(ZeroRingProgressBar), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Black) { Opacity = 0.2 }, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 百分比颜色属性
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [Description("百分比颜色")]
        public Brush PercentForeground
        {
            get { return (Brush)GetValue(PercentForegroundProperty); }
            set { SetValue(PercentForegroundProperty, value); }
        }

        /// <summary>
        /// 动效颜色属性委托
        /// </summary>
        public static readonly DependencyProperty AnimationForegroundProperty =
            DependencyProperty.Register("AnimationForeground", typeof(Brush), typeof(ZeroRingProgressBar), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.GreenYellow) { Opacity = 0.2 }, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 动效颜色属性
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [Description("动效颜色")]
        public Brush AnimationForeground
        {
            get { return (Brush)GetValue(AnimationForegroundProperty); }
            set { SetValue(AnimationForegroundProperty, value); }
        }

        /// <summary>
        /// 是否为不确定状态属性委托
        /// </summary>
        public static readonly DependencyProperty IsIndeterminateProperty =
            DependencyProperty.Register("IsIndeterminate", typeof(bool), typeof(ZeroRingProgressBar), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 是否为不确定状态属性
        /// </summary>
        public bool IsIndeterminate
        {
            get
            {
                return (bool)GetValue(IsIndeterminateProperty);
            }
            set
            {
                SetValue(IsIndeterminateProperty, value);
            }
        }

        /// <summary>
        /// 是否显示百分比属性委托
        /// </summary>
        public static readonly DependencyProperty IsShowPercentProperty =
            DependencyProperty.Register("IsShowPercent", typeof(bool), typeof(ZeroRingProgressBar), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 是否显示百分比属性
        /// </summary>
        public bool IsShowPercent
        {
            get
            {
                return (bool)GetValue(IsShowPercentProperty);
            }
            set
            {
                SetValue(IsShowPercentProperty, value);
            }
        }

        /// <summary>
        /// 角度委托属性
        /// </summary>
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle"
                , typeof(double)
                , typeof(ZeroRingProgressBar)
                , new FrameworkPropertyMetadata(-90.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        /// <summary>
        /// 角度属性
        /// </summary>
        [Bindable(true)]
        [Category("Transform")]
        [Description("角度")]
        public double Angle
        {
            get
            {
                return (double)GetValue(AngleProperty);
            }
            set
            {
                SetValue(AngleProperty, value);
            }
        }

        /// <summary>
        /// 指示器边距属性依赖
        /// </summary>
        public static readonly DependencyProperty IndicatorMarginProperty =
            DependencyProperty.Register("IndicatorMargin"
                , typeof(Thickness)
                , typeof(ZeroRingProgressBar)
                , new FrameworkPropertyMetadata(new Thickness(0), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 指示器边距属性
        /// </summary>
        public Thickness IndicatorMargin
        {
            get
            {
                return (Thickness)GetValue(IndicatorMarginProperty);
            }
            set
            {
                SetValue(IndicatorMarginProperty, value);
            }
        }

        /// <summary>
        /// 轨道边距属性依赖
        /// </summary>
        public static readonly DependencyProperty TracMarginProperty =
            DependencyProperty.Register("TracMargin"
                , typeof(Thickness)
                , typeof(ZeroRingProgressBar)
                , new FrameworkPropertyMetadata(new Thickness(0), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 轨道边距属性
        /// </summary>
        public Thickness TracMargin
        {
            get
            {
                return (Thickness)GetValue(TracMarginProperty);
            }
            set
            {
                SetValue(TracMarginProperty, value);
            }
        }

        /// <summary>
        /// 重写OnApplyTemplate方法，获取控件模板中的元素，并设置相关事件处理程序
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _indicator?.SizeChanged -= OnIndicatorSizeChanged;
            _indicator = GetTemplateChild(IndicatorTemplateName) as Ellipse;
            _percent = GetTemplateChild(PercentName) as TextBlock;
            _indicator?.SizeChanged += OnIndicatorSizeChanged;
        }

        /// <summary>
        /// 最小值变更
        /// </summary>
        /// <param name="oldMinimum"></param>
        /// <param name="newMinimum"></param>
        protected override void OnMinimumChanged(double oldMinimum, double newMinimum)
        {
            base.OnMinimumChanged(oldMinimum, newMinimum);
            SetProgressBarIndicator();
        }

        /// <summary>
        /// 最大值变更
        /// </summary>
        /// <param name="oldMaximum"></param>
        /// <param name="newMaximum"></param>
        protected override void OnMaximumChanged(double oldMaximum, double newMaximum)
        {
            base.OnMaximumChanged(oldMaximum, newMaximum);
            SetProgressBarIndicator();
        }

        /// <summary>
        /// 值变更
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        protected override void OnValueChanged(double oldValue, double newValue)
        {
            base.OnValueChanged(oldValue, newValue);
            SetProgressBarIndicator();
        }

        /// <summary>
        /// 设置进度条尺寸变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnIndicatorSizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetProgressBarIndicator();
        }

        /// <summary>
        /// 设置进度
        /// </summary>
        private void SetProgressBarIndicator()
        {
            _indicator ??= GetTemplateChild(IndicatorTemplateName) as Ellipse;
            _percent ??= GetTemplateChild(PercentName) as TextBlock;
            if (_indicator == null || _percent == null) return;

            double a = (_indicator.ActualWidth - IndicatorStrokeThickness) / 2;
            double b = (_indicator.ActualHeight - IndicatorStrokeThickness) / 2;
            double h = Math.Pow(a - b, 2) / Math.Pow(a + b, 2);
            // 周长
            double c = Math.PI * (a + b) * (1 + (3 * h) / (10 + Math.Sqrt(4 - 3 * h)));
            double percent = Value / (Maximum - Minimum);
            // 进度长度
            double dash = c * percent / IndicatorStrokeThickness;
            _indicator.StrokeDashArray = [dash, c];
            _percent.Text = string.Format("{0:F0}%", percent * 100);
        }
    }
}
