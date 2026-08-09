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
    /// 密码框样式
    /// </summary>
    public class ZeroPasswordBox : ZeroTextBox
    {

        /// <summary>
        /// 是否正在更新文本的标志
        /// </summary>
        private bool _isUpadteText = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        static ZeroPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZeroPasswordBox), new FrameworkPropertyMetadata(typeof(ZeroPasswordBox)));
        }

        /// <summary>
        /// 密码掩码字符属性委托
        /// PasswordChar：用于调用的委托名字
        /// typeof(ZeroPasswordBox)：指定控件
        /// </summary>
        public static readonly DependencyProperty PasswordCharProperty = DependencyProperty.Register("PasswordChar", typeof(char), typeof(ZeroPasswordBox), new FrameworkPropertyMetadata('●', FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 定义密码掩码字符属性
        /// </summary>
        [Bindable(true)]
        [Category("Password")]
        public char PasswordChar
        {
            get { return (char)GetValue(PasswordCharProperty); }
            set { SetValue(PasswordCharProperty, value); }
        }

        /// <summary>
        /// 显示明文密码属性委托
        /// IsShowPlainPassword：用于调用的委托名字
        /// typeof(ZeroPasswordBox)：指定控件
        /// </summary>
        public static readonly DependencyProperty IsShowPlainPasswordProperty = DependencyProperty.Register("IsShowPlainPassword", typeof(bool), typeof(ZeroPasswordBox), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 定义显示明文密码属性
        /// </summary>
        [Bindable(true)]
        [Category("Password")]
        public bool IsShowPlainPassword
        {
            get { return (bool)GetValue(IsShowPlainPasswordProperty); }
            set { SetValue(IsShowPlainPasswordProperty, value); }
        }

        /// <summary>
        /// 密码参数委托
        /// Password：用于调用的委托名字
        /// typeof(ZeroPasswordBox)：指定控件
        /// </summary>
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string)
                , typeof(ZeroPasswordBox)
                , new FrameworkPropertyMetadata(string.Empty
                    , FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPasswordChanged));

        /// <summary>
        /// 定义密码属性
        /// </summary>
        [Bindable(true)]
        [Category("Password")]
        [DefaultValue("")]
        [Localizability(LocalizationCategory.Text)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
        public string Password
        {
            get
            {
                return (string)GetValue(PasswordProperty);
            }
            set
            {
                SetValue(PasswordProperty, value);
            }
        }

        /// <summary>
        /// 密码属性改变时的回调方法
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var box = (ZeroPasswordBox)d;
            box._isUpadteText = true;
            box.Text = box.IsShowPlainPassword ? (string)e.NewValue : new string(box.PasswordChar, ((string)e.NewValue).Length);
            box._isUpadteText = false;
        }

        /// <summary>
        /// 重写文本改变事件，更新密码属性
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            if (!_isUpadteText)
            {
                if (Password.Length > this.Text.Length)
                {
                    Password = Password[..Text.Length];
                }
                else if (Password.Length < Text.Length)
                {
                    Password += this.Text[Password.Length..];
                }
            }

            this.SelectionStart = this.Text.Length;
        }

        /// <summary>
        /// 重写选择事件，屏蔽框选
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSelectionChanged(RoutedEventArgs e)
        {
            if (base.SelectionLength > 0)
            {
                base.SelectionStart = Password.Length + 1;
            }

            base.OnSelectionChanged(e);
        }
    }
}
