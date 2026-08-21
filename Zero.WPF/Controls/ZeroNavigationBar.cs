using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// 导航栏
    /// </summary>
    public class ZeroNavigationBar : Control
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        static ZeroNavigationBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(typeof(ZeroNavigationBar)));
        }

        /// <summary>
        /// 按钮圆角属性委托
        /// ButtonBorderThickness：用于调用的委托名字
        /// typeof(ZeroNavigationBar)：指定控件
        /// </summary>
        public static readonly DependencyProperty ButtonBorderThicknessProperty = 
            DependencyProperty.Register("ButtonBorderThickness", typeof(Thickness), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(new Thickness(0), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 按钮圆角属性
        /// </summary>
        [Bindable(true)]
        [Category("Layout")]
        public Thickness ButtonBorderThickness
        {
            get { return (Thickness)GetValue(ButtonBorderThicknessProperty); }
            set { SetValue(ButtonBorderThicknessProperty, value); }
        }

        /// <summary>
        /// 按钮圆角属性委托
        /// ButtonCornerRadius：用于调用的委托名字
        /// typeof(ZeroNavigationBar)：指定控件
        /// </summary>
        public static readonly DependencyProperty ButtonCornerRadiusProperty = 
            DependencyProperty.Register("ButtonCornerRadius", typeof(CornerRadius), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(new CornerRadius(5), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 按钮圆角属性
        /// </summary>
        [Bindable(true)]
        [Category("Layout")]
        public CornerRadius ButtonCornerRadius
        {
            get { return (CornerRadius)GetValue(ButtonCornerRadiusProperty); }
            set { SetValue(ButtonCornerRadiusProperty, value); }
        }

        /// <summary>
        /// 圆角属性委托
        /// CornerRadius：用于调用的委托名字
        /// typeof(ZeroNavigationBar)：指定控件
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = 
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(new CornerRadius(5), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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

        /// <summary>
        /// 控件宽度属性委托
        /// InputWidth：用于调用的委托名字
        /// typeof(ZeroNavigationBar)：指定控件
        /// </summary>
        public static readonly DependencyProperty ControlWidthProperty = 
            DependencyProperty.Register("ControlWidth", typeof(double), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(80.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 控件宽度属性
        /// </summary>
        [Bindable(true)]
        [Category("Layout")]
        public double ControlWidth
        {
            get { return (double)GetValue(ControlWidthProperty); }
            set { SetValue(ControlWidthProperty, value); }
        }

        #region Button Brush

        /// <summary>
        /// 按钮边框颜色属性委托
        /// </summary>
        public static readonly DependencyProperty ButtonBorderBrushProperty =
            DependencyProperty.Register("ButtonBorderBrush", typeof(Brush), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Gray), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 边框颜色
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [Description("按钮背景色")]
        public Brush ButtonBorderBrush
        {
            get { return (Brush)GetValue(ButtonBorderBrushProperty); }
            set { SetValue(ButtonBorderBrushProperty, value); }
        }

        /// <summary>
        /// 输入背景色属性委托
        /// </summary>
        public static readonly DependencyProperty InputBackgroundProperty =
            DependencyProperty.Register("InputBackground", typeof(Brush), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.White), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 按钮背景色
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [Description("输入背景色")]
        public Brush InputBackground
        {
            get { return (Brush)GetValue(InputBackgroundProperty); }
            set { SetValue(InputBackgroundProperty, value); }
        }

        /// <summary>
        /// 按钮背景色属性委托
        /// </summary>
        public static readonly DependencyProperty ButtonBackgroundProperty =
            DependencyProperty.Register("ButtonBackground", typeof(Brush), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.DarkGray), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 按钮背景色
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [Description("按钮背景色")]
        public Brush ButtonBackground
        {
            get { return (Brush)GetValue(ButtonBackgroundProperty); }
            set { SetValue(ButtonBackgroundProperty, value); }
        }

        /// <summary>
        /// 输入前景色属性委托
        /// </summary>
        public static readonly DependencyProperty InputForegroundProperty =
            DependencyProperty.Register("InputForeground", typeof(Brush), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Black), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 输入前景色
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [Description("输入前景色")]
        public Brush InputForeground
        {
            get { return (Brush)GetValue(InputForegroundProperty); }
            set { SetValue(InputForegroundProperty, value); }
        }

        /// <summary>
        /// 按钮前景色属性委托
        /// </summary>
        public static readonly DependencyProperty ButtonForegroundProperty =
            DependencyProperty.Register("ButtonForeground", typeof(Brush), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Black), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 按钮前景色
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [Description("按钮背景色")]
        public Brush ButtonForeground
        {
            get { return (Brush)GetValue(ButtonForegroundProperty); }
            set { SetValue(ButtonForegroundProperty, value); }
        }

        #endregion Button Brush

        #region Page Navigation Property

        #region Page Property

        /// <summary>
        /// 目标页属性委托
        /// </summary>
        public static readonly DependencyProperty TargetPageProperty =
            DependencyProperty.Register("TargetPage", typeof(int), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 目标页属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public int TargetPage
        {
            get { return (int)GetValue(TargetPageProperty); }
            set { SetValue(TargetPageProperty, value); }
        }

        /// <summary>
        /// 总页数属性委托
        /// </summary>
        public static readonly DependencyProperty TotalPageCntProperty =
            DependencyProperty.Register("TotalPageCnt", typeof(int), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 总页数属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public int TotalPageCnt
        {
            get { return (int)GetValue(TotalPageCntProperty); }
            set { SetValue(TotalPageCntProperty, value); }
        }

        /// <summary>
        /// 当前页属性委托
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register("CurrentPage", typeof(int), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 当前页属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public int CurrentPage
        {
            get { return (int)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        /// <summary>
        /// 起始数据编号属性委托
        /// </summary>
        public static readonly DependencyProperty StartIndexProperty =
            DependencyProperty.Register("StartIndex", typeof(int), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 起始数据编号属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public int StartIndex
        {
            get { return (int)GetValue(StartIndexProperty); }
            set { SetValue(StartIndexProperty, value); }
        }

        /// <summary>
        /// 数据总数属性委托
        /// </summary>
        public static readonly DependencyProperty TotalDataCntProperty =
            DependencyProperty.Register("TotalDataCnt", typeof(int), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 数据总数属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public int TotalDataCnt
        {
            get { return (int)GetValue(TotalDataCntProperty); }
            set { SetValue(TotalDataCntProperty, value); }
        }

        /// <summary>
        /// 单页数据数属性委托
        /// </summary>
        public static readonly DependencyProperty OnePageCntProperty =
            DependencyProperty.Register("OnePageCnt", typeof(int), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(100, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 单页数据数属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public int OnePageCnt
        {
            get { return (int)GetValue(OnePageCntProperty); }
            set { SetValue(OnePageCntProperty, value); }
        }

        #endregion Page Property

        #region Content

        /// <summary>
        /// 总页数内容属性委托
        /// </summary>
        public static readonly DependencyProperty TotalPageLabelProperty =
            DependencyProperty.Register("TotalPageLabel", typeof(string), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata("总页数：", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 总页数内容属
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public string TotalPageLabel
        {
            get { return (string)GetValue(TotalPageLabelProperty); }
            set { SetValue(TotalPageLabelProperty, value); }
        }

        /// <summary>
        /// 首页命令属性委托
        /// </summary>
        public static readonly DependencyProperty FirstPageContentProperty =
            DependencyProperty.Register("FirstPageContent", typeof(object), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata("首页", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 首页命令属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public object FirstPageContent
        {
            get { return GetValue(FirstPageContentProperty); }
            set { SetValue(FirstPageContentProperty, value); }
        }

        /// <summary>
        /// 下一页命令属性委托
        /// </summary>
        public static readonly DependencyProperty NextPageContentProperty =
            DependencyProperty.Register("NextPageContent", typeof(object), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata("下一页", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 下一页命令属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public object NextPageContent
        {
            get { return GetValue(NextPageContentProperty); }
            set { SetValue(NextPageContentProperty, value); }
        }

        /// <summary>
        /// 上一页命令属性委托
        /// </summary>
        public static readonly DependencyProperty PreviousPageContentProperty =
            DependencyProperty.Register("PreviousPageContent", typeof(object), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata("上一页", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 上一页命令属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public object PreviousPageContent
        {
            get { return GetValue(PreviousPageContentProperty); }
            set { SetValue(PreviousPageContentProperty, value); }
        }

        /// <summary>
        /// 最后一页命令属性委托
        /// </summary>
        public static readonly DependencyProperty LastPageContentProperty =
            DependencyProperty.Register("LastPageContent", typeof(object), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata("尾页", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 最后一页命令属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public object LastPageContent
        {
            get { return GetValue(LastPageContentProperty); }
            set { SetValue(LastPageContentProperty, value); }
        }

        /// <summary>
        /// 导航到指定页命令属性委托
        /// </summary>
        public static readonly DependencyProperty GoToPageContentProperty =
            DependencyProperty.Register("GoToPageContent", typeof(object), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata("跳转", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 导航到指定页命令属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public object GoToPageContent
        {
            get { return GetValue(GoToPageContentProperty); }
            set { SetValue(GoToPageContentProperty, value); }
        }

        #endregion Content

        #region Icon

        /// <summary>
        /// 首页命令属性委托
        /// </summary>
        public static readonly DependencyProperty FirstPageIconProperty =
            DependencyProperty.Register("FirstPageIcon", typeof(object), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 首页命令属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public object FirstPageIcon
        {
            get { return GetValue(FirstPageIconProperty); }
            set { SetValue(FirstPageIconProperty, value); }
        }

        /// <summary>
        /// 下一页命令属性委托
        /// </summary>
        public static readonly DependencyProperty NextPageIconProperty =
            DependencyProperty.Register("NextPageIcon", typeof(object), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 下一页命令属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public object NextPageIcon
        {
            get { return GetValue(NextPageIconProperty); }
            set { SetValue(NextPageIconProperty, value); }
        }

        /// <summary>
        /// 上一页命令属性委托
        /// </summary>
        public static readonly DependencyProperty PreviousPageIconProperty =
            DependencyProperty.Register("PreviousPageIcon", typeof(object), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 上一页命令属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public object PreviousPageIcon
        {
            get { return GetValue(PreviousPageIconProperty); }
            set { SetValue(PreviousPageIconProperty, value); }
        }

        /// <summary>
        /// 最后一页命令属性委托
        /// </summary>
        public static readonly DependencyProperty LastPageIconProperty =
            DependencyProperty.Register("LastPageIcon", typeof(object), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 最后一页命令属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public object LastPageIcon
        {
            get { return GetValue(LastPageIconProperty); }
            set { SetValue(LastPageIconProperty, value); }
        }

        /// <summary>
        /// 导航到指定页命令属性委托
        /// </summary>
        public static readonly DependencyProperty GoToPageIconProperty =
            DependencyProperty.Register("GoToPageIcon", typeof(object), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 导航到指定页命令属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public object GoToPageIcon
        {
            get { return GetValue(GoToPageIconProperty); }
            set { SetValue(GoToPageIconProperty, value); }
        }

        #endregion Icon

        #region Command

        /// <summary>
        /// 首页命令属性委托
        /// </summary>
        public static readonly DependencyProperty FirstPageCommandProperty =
            DependencyProperty.Register("FirstPageCommand", typeof(ICommand), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata());

        /// <summary>
        /// 首页命令属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public ICommand FirstPageCommand
        {
            get { return (ICommand)GetValue(FirstPageCommandProperty); }
            set { SetValue(FirstPageCommandProperty, value); }
        }

        /// <summary>
        /// 下一页命令属性委托
        /// </summary>
        public static readonly DependencyProperty NextPageCommandProperty =
            DependencyProperty.Register("NextPageCommand", typeof(ICommand), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata());

        /// <summary>
        /// 下一页命令属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public ICommand NextPageCommand
        {
            get { return (ICommand)GetValue(NextPageCommandProperty); }
            set { SetValue(NextPageCommandProperty, value); }
        }

        /// <summary>
        /// 上一页命令属性委托
        /// </summary>
        public static readonly DependencyProperty PreviousPageCommandProperty =
            DependencyProperty.Register("PreviousPageCommand", typeof(ICommand), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata());

        /// <summary>
        /// 上一页命令属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public ICommand PreviousPageCommand
        {
            get { return (ICommand)GetValue(PreviousPageCommandProperty); }
            set { SetValue(PreviousPageCommandProperty, value); }
        }

        /// <summary>
        /// 最后一页命令属性委托
        /// </summary>
        public static readonly DependencyProperty LastPageCommandProperty =
            DependencyProperty.Register("LastPageCommand", typeof(ICommand), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata());

        /// <summary>
        /// 最后一页命令属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public ICommand LastPageCommand
        {
            get { return (ICommand)GetValue(LastPageCommandProperty); }
            set { SetValue(LastPageCommandProperty, value); }
        }

        /// <summary>
        /// 导航到指定页命令属性委托
        /// </summary>
        public static readonly DependencyProperty GoToPageCommandProperty =
            DependencyProperty.Register("GoToPageCommand", typeof(ICommand), typeof(ZeroNavigationBar), new FrameworkPropertyMetadata());

        /// <summary>
        /// 导航到指定页命令属性
        /// </summary>
        [Bindable(true)]
        [Category("Page")]
        public ICommand GoToPageCommand
        {
            get { return (ICommand)GetValue(GoToPageCommandProperty); }
            set { SetValue(GoToPageCommandProperty, value); }
        }

        #endregion Command

        #endregion Page Navigation Property

    }
}
