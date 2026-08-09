using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
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
    /// 开关按钮
    /// </summary>
    public class ZeroSwitchButton : ZeroButton
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        static ZeroSwitchButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZeroSwitchButton), new FrameworkPropertyMetadata(typeof(ZeroSwitchButton)));
        }

        #region State

        /// <summary>
        /// 是否三态属性属性委托
        /// </summary>
        public static readonly DependencyProperty IsThreeStateProperty = DependencyProperty.Register("IsThreeState", typeof(bool), typeof(ZeroSwitchButton), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 开关状态属性
        /// </summary>  
        [Bindable(true)]
        [Category("Appearance")]
        public bool IsThreeState
        {
            get { return (bool)GetValue(IsThreeStateProperty); }
            set { SetValue(IsThreeStateProperty, value); }
        }

        /// <summary>
        /// 开关状态属性委托
        /// </summary>
        public static readonly DependencyProperty IsOnProperty = DependencyProperty.Register("IsOn", typeof(bool?), typeof(ZeroSwitchButton), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 开关状态属性
        /// </summary>  
        [Bindable(true)]
        [Category("Appearance")]
        [Description("三种状态，不同状态调用不同图标")]
        public bool? IsOn
        {
            get { return (bool?)GetValue(IsOnProperty); }
            set { SetValue(IsOnProperty, value); }
        }

        #endregion State

        #region Content

        /// <summary>
        /// 开状态文本属性委托
        /// </summary>
        public static readonly DependencyProperty IsOnContentProperty = DependencyProperty.Register("IsOnContent", typeof(object), typeof(ZeroSwitchButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 开状态文本属性
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        public object IsOnContent
        {
            get { return (object)GetValue(IsOnContentProperty); }
            set { SetValue(IsOnContentProperty, value); }
        }

        /// <summary>
        /// Null状态文本属性委托
        /// </summary>
        public static readonly DependencyProperty IsNullContentProperty = DependencyProperty.Register("IsNullContent", typeof(object), typeof(ZeroSwitchButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// Null状态文本属性
        /// </summary>
        [Bindable(true)]
        [Category("Content")]
        public object IsNullContent
        {
            get { return (object)GetValue(IsNullContentProperty); }
            set { SetValue(IsNullContentProperty, value); }
        }

        #endregion Content

        #region Icon

        /// <summary>
        /// 图标属性委托
        /// </summary>
        public static readonly DependencyProperty IsOnIconProperty = DependencyProperty.Register("IsOnIcon", typeof(object), typeof(ZeroSwitchButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 图标属性
        /// </summary>  
        [Bindable(true)]
        [Category("Appearance")]
        public object IsOnIcon
        {
            get { return (object)GetValue(IsOnIconProperty); }
            set { SetValue(IsOnIconProperty, value); }
        }

        /// <summary>
        /// 图标属性委托
        /// </summary>
        public static readonly DependencyProperty IsNullIconProperty = DependencyProperty.Register("IsNullIcon", typeof(object), typeof(ZeroSwitchButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 图标属性
        /// </summary>  
        [Bindable(true)]
        [Category("Appearance")]
        public object IsNullIcon
        {
            get { return (object)GetValue(IsNullIconProperty); }
            set { SetValue(IsNullIconProperty, value); }
        }

        #endregion Icon

        #region Brush

        /// <summary>
        /// 开状态字体属性
        /// </summary>
        public static readonly DependencyProperty IsOnForegroundProperty =
            DependencyProperty.Register("IsOnForeground", typeof(Brush), typeof(ZeroSwitchButton)
            , new FrameworkPropertyMetadata(new SolidColorBrush(Colors.White), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 开状态字体颜色
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        public Brush IsOnForeground
        {
            get { return (Brush)GetValue(IsOnForegroundProperty); }
            set { SetValue(IsOnForegroundProperty, value); }
        }

        /// <summary>
        /// 开状态背景属性
        /// </summary>
        public static readonly DependencyProperty IsOnBackgroundProperty =
            DependencyProperty.Register("IsOnBackground", typeof(Brush), typeof(ZeroSwitchButton)
            , new FrameworkPropertyMetadata(new SolidColorBrush(Colors.DarkGray), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 开状态的背景颜色
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        public Brush IsOnBackground
        {
            get { return (Brush)GetValue(IsOnBackgroundProperty); }
            set { SetValue(IsOnBackgroundProperty, value); }
        }

        /// <summary>
        /// 空状态字体属性
        /// </summary>
        public static readonly DependencyProperty IsNullForegroundProperty =
            DependencyProperty.Register("IsNullForeground", typeof(Brush), typeof(ZeroSwitchButton)
            , new FrameworkPropertyMetadata(new SolidColorBrush(Colors.White), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 空状态字体颜色
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        public Brush IsNullForeground
        {
            get { return (Brush)GetValue(IsNullForegroundProperty); }
            set { SetValue(IsNullForegroundProperty, value); }
        }

        /// <summary>
        /// 空状态背景属性
        /// </summary>
        public static readonly DependencyProperty IsNullBackgroundProperty =
            DependencyProperty.Register("IsNullBackground", typeof(Brush), typeof(ZeroSwitchButton)
            , new FrameworkPropertyMetadata(new SolidColorBrush(Colors.DarkGray), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 空状态的背景颜色
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        public Brush IsNullBackground
        {
            get { return (Brush)GetValue(IsNullBackgroundProperty); }
            set { SetValue(IsNullBackgroundProperty, value); }
        }

        #endregion Brush

        #region Method

        /// <summary>
        /// 点击事件
        /// </summary>
        protected override void OnClick()
        {
            base.OnClick();

            if (IsThreeState)
            {
                switch (IsOn)
                {
                    case true:
                        IsOn = null;
                        break;
                    case null:
                        IsOn = false;
                        break;
                    case false:
                        IsOn = true;
                        break;
                }
            }
            else
            {
                IsOn = IsOn == null? false : IsOn ^ true;
            }
        }

        #endregion Method
    }
}
