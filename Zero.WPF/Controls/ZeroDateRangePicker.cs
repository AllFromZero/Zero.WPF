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
    public class ZeroDateRangePicker : Control
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        static ZeroDateRangePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZeroDateRangePicker), new FrameworkPropertyMetadata(typeof(ZeroDateRangePicker)));
        }

        /// <summary>
        /// 圆角属性委托
        /// CornerRadius：用于调用的委托名字
        /// typeof(ZeroDateRangePicker)：指定控件
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = 
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ZeroDateRangePicker), new FrameworkPropertyMetadata(new CornerRadius(5), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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
        /// 开始时间属性委托
        /// </summary>
        public static readonly DependencyProperty StartTimeProperty = 
            DependencyProperty.Register("StartTime", typeof(DateTime?), typeof(ZeroDateRangePicker), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 开始时间属性
        /// </summary>
        [Bindable(true)]
        [Category("Layout")]
        public DateTime? StartTime
        {
            get { return (DateTime?)GetValue(StartTimeProperty); }
            set { SetValue(StartTimeProperty, value); }
        }

        /// <summary>
        /// 结束时间属性委托
        /// </summary>
        public static readonly DependencyProperty EndTimeProperty = 
            DependencyProperty.Register("EndTime", typeof(DateTime?), typeof(ZeroDateRangePicker), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 结束时间属性
        /// </summary>
        [Bindable(true)]
        [Category("Layout")]
        public DateTime? EndTime
        {
            get 
            { return (DateTime?)GetValue(EndTimeProperty); }
            set { SetValue(EndTimeProperty, value); }
        }

    }
}
