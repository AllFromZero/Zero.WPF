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
    /// 标签
    /// </summary>
    public class ZeroLabel : Label
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        static ZeroLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZeroLabel), new FrameworkPropertyMetadata(typeof(ZeroLabel)));
        }

        /// <summary>
        /// 按键属性委托
        /// CornerRadius：用于调用的委托名字
        /// typeof(UdButton)：指定控件
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty = 
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ZeroLabel), new FrameworkPropertyMetadata(new CornerRadius(5), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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
