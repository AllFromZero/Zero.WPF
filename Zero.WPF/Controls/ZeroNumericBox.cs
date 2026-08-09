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
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zero.WPF.Controls
{
    /// <summary>
    /// 数字框
    /// </summary>
    public class ZeroNumericBox : ZeroTextBox
    {
        /// <summary>
        /// 是否正在更新文本的标志
        /// </summary>
        private bool _isUpadteText = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        static ZeroNumericBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZeroNumericBox), new FrameworkPropertyMetadata(typeof(ZeroNumericBox)));
        }

        /// <summary>
        /// 小数位数参数委托
        /// </summary>
        public static readonly DependencyProperty DecimalPlacesProperty =
            DependencyProperty.Register("DecimalPlaces", typeof(byte), typeof(ZeroNumericBox), new FrameworkPropertyMetadata((byte)0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 小数位数参数
        /// </summary>
        [Bindable(true)]
        [DefaultValue(0)]
        [Category("Decimal")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public byte DecimalPlaces
        {
            get
            {
                return Convert.ToByte(GetValue(DecimalPlacesProperty));
            }
            set
            {
                SetValue(DecimalPlacesProperty, value);
            }
        }

        /// <summary>
        /// 最大值参数属性委托
        /// </summary>
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(decimal), typeof(ZeroNumericBox), new FrameworkPropertyMetadata(100m, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 最大值参数属性
        /// </summary>
        [Bindable(true)]
        [Category("Decimal")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal MaxValue { get => Convert.ToDecimal(GetValue(MaxValueProperty)); set => SetValue(MaxValueProperty, value); }

        /// <summary>
        /// 最小值参数属性委托
        /// </summary>
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(decimal), typeof(ZeroNumericBox), new FrameworkPropertyMetadata(0m, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 最小值参数属性
        /// </summary>
        [Bindable(true)]
        [Category("Decimal")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal MinValue{ get=> Convert.ToDecimal(GetValue(MinValueProperty)); set => SetValue(MinValueProperty, value); }


        /// <summary>
        /// 密码参数委托
        /// DecimalValue：用于调用的委托名字
        /// typeof(ZeroNumericBox)：指定控件
        /// </summary>
        public static readonly DependencyProperty DecimalValueProperty =
            DependencyProperty.Register("DecimalValue", typeof(decimal?), typeof(ZeroNumericBox)
            , new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnDecimalValueChanged));

        /// <summary>
        /// 获取或设置数值
        /// 未输入时，默认值为0
        /// </summary>
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal? DecimalValue
        {
            get
            {
                return (decimal?)GetValue(DecimalValueProperty);
            }
            set
            {
                SetValue(DecimalValueProperty, value);
            }
        }

        /// <summary>
        /// 属性变更
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnDecimalValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var numBox = (ZeroNumericBox)d;

            if (e.NewValue != null)
            {
                // e.NewValue 对应于 DecimalValue 的新值（boxed decimal），先把它解箱为 decimal
                decimal newVal = (decimal)e.NewValue;

                if (newVal > numBox.MaxValue)
                {
                    // 使用 SetCurrentValue 以不破坏绑定的方式调整值到 MaxValue
                    numBox.SetCurrentValue(DecimalValueProperty, numBox.MaxValue);
                    return;
                }
                else if (newVal < numBox.MinValue)
                {
                    numBox.SetCurrentValue(DecimalValueProperty, numBox.MinValue);
                    return;
                }
            }

            numBox._isUpadteText = true;
            numBox.Text = numBox.DecimalValue?.ToString("F" + numBox.DecimalPlaces);
            numBox._isUpadteText = false;
        }

        /// <summary>
        /// 文本输入事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            if (_isUpadteText) return;
            int oldSelectionStart = this.SelectionStart;
            if (string.IsNullOrWhiteSpace(this.Text))
            {
                DecimalValue = null;
            }
            else
            {
                if (this.Text.StartsWith('-') && this.Text.Length <= 1)
                {
                    return;
                }

                DecimalValue = Convert.ToDecimal(this.Text);
                // 超出最大值或者最小值后由于DecimalValue值固定，不会触发变更事件，需要手动刷新Text字符串值
                if (DecimalValue >= MaxValue || DecimalValue <= MinValue)
                {
                    Text = this.DecimalValue?.ToString("F" + this.DecimalPlaces);
                }
            }

            this.SelectionStart = oldSelectionStart;
        }


        /// <summary>
        /// 按键预按下响应
        /// System.Windows.UIElement.KeyDown 发生时调用。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            //屏蔽空格键输入
            if (e != null && e.Key == Key.Space)
            {
                e.Handled = true;
            }

            base.OnPreviewKeyDown(e);
        }


        /// <summary>
        /// 按键按下事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            //确认是否为空
            if (e == null) return;

            //说明：
            //e.Handled = true;  //设置事件已处理，忽略输入
            //e.Handled = false;  //设置事件未处理，忽略输入

            //屏蔽特殊功能键 ctrl alt shift space
            if ((e.KeyboardDevice.Modifiers == ModifierKeys.Shift || e.KeyboardDevice.Modifiers == ModifierKeys.Control || e.KeyboardDevice.Modifiers == ModifierKeys.Alt || e.Key == Key.Space))
            {
                e.Handled = true;
            }
            //识别数字键
            else if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || (e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                e.Handled = false;
            }
            //识别小数点
            else if (e.Key == Key.Decimal || e.Key == Key.OemPeriod)
            {
                //只允许输入一个小数点
                if (this.Text.Contains('.') || this.Text.Length <= 0)
                {
                    e.Handled = true;
                }
                else
                {
                    if (DecimalPlaces <= 0)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
            }
            //识别负号键
            else if (e.Key == Key.Subtract)
            {
                if (!this.Text.Contains('-') && this.SelectionStart == 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            //识别删除键
            else if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                e.Handled = false;
            }
            else
            { 
                
            }

            base.OnKeyDown(e);
        }
    }
}
