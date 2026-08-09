using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    /// 圆形容器
    /// </summary>
    public class ZeroCirclePanel : Panel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        static ZeroCirclePanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZeroCirclePanel), new FrameworkPropertyMetadata(typeof(ZeroCirclePanel)));
        }


        /// <summary>
        /// 旋转方向属性属性委托
        /// RotationDirection：用于调用的委托名字
        /// typeof(ZeroCirclePanel)：指定控件
        /// </summary>
        public static readonly DependencyProperty RotationDirectionProperty = DependencyProperty.Register("RotationDirection", typeof(RotationDirection), typeof(ZeroCirclePanel), new PropertyMetadata(RotationDirection.CW));

        /// <summary>
        /// 旋转方向属性
        /// </summary>
        [Bindable(true)]
        [Category("Layout")]
        public RotationDirection RotationDirection
        {
            get => (RotationDirection)GetValue(RotationDirectionProperty);
            set => SetValue(RotationDirectionProperty, value);
        }

        /// <summary>
        /// 半径属性委托
        /// </summary>
        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(ZeroCirclePanel), new PropertyMetadata(10.0));
        /// <summary>
        /// 半径属性
        /// </summary>
        [Bindable(true)]
        [Category("Layout")]
        public double Radius
        {
            get => Convert.ToDouble(GetValue(RadiusProperty));
            set => SetValue(RadiusProperty, value);
        }

        /// <summary>
        /// 初始角度属性委托
        /// </summary>
        public static readonly DependencyProperty StartAngleProperty = DependencyProperty.Register("StartAngle", typeof(double), typeof(ZeroCirclePanel), new PropertyMetadata(-90.0));
        /// <summary>
        /// 初始角度属性
        /// </summary>
        [Bindable(true)]
        [Category("Layout")]
        public double StartAngle
        {
            get => Convert.ToDouble(GetValue(StartAngleProperty));
            set => SetValue(StartAngleProperty, value);
        }

        /// <summary>
        /// 测量布局
        /// </summary>
        /// <param name="availableSize"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            Size resultSize = new(0, 0);
            foreach (UIElement item in Children)
            {
                //识别子控件尺寸
                item.Measure(availableSize);
                resultSize.Width = Math.Max(item.DesiredSize.Width, resultSize.Width);
                resultSize.Height = Math.Max(item.DesiredSize.Height, resultSize.Height);
            }

            resultSize.Width = Math.Min(resultSize.Width, availableSize.Width);
            resultSize.Height = Math.Min(resultSize.Height, availableSize.Height);

            return resultSize;
        }

        /// <summary>
        /// 重新绘制布局
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            double vDegree = StartAngle;
            double vDegreeSrep = (double)360 / this.Children.Count;
            if (double.IsNaN(this.Width))
            {
                this.Width = 200;
            }

            if (double.IsNaN(this.Height))
            {
                this.Height = 200;
            }
            double vOffset_X = this.Width / 2;
            double vOffset_Y = this.Height / 2;
            foreach (UIElement item in Children)
            {
                //角度转弧度
                double angle = Math.PI * vDegree / 180.0;
                //转换为直角坐标系 r*cos
                double x = Math.Cos(angle) * this.Radius;
                //转换为直角坐标系 r*sin
                double y = Math.Sin(angle) * this.Radius;

                RotateTransform rotate = new()
                {
                    Angle = vDegree,
                    CenterX = 0,
                    CenterY = item.DesiredSize.Height / 2
                };

                item.RenderTransform = rotate;
                //决定子控件的位置和大小
                item.Arrange(new Rect(vOffset_X + x, vOffset_Y + y - rotate.CenterY, item.DesiredSize.Width, item.DesiredSize.Height));
                vDegree += RotationDirection == RotationDirection.CW ? vDegreeSrep : -1 * vDegreeSrep;

            }
            return finalSize;
        }



    }
}
