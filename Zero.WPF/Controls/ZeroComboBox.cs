using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// 组合框控件
    /// </summary>
    public class ZeroComboBox : ComboBox
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        static ZeroComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ZeroComboBox), new FrameworkPropertyMetadata(typeof(ZeroComboBox)));
        }

        #region 圆角属性

        /// <summary>
        /// 圆角属性委托
        /// CornerRadius：用于调用的委托名字
        /// typeof(ZeroComboBox)：指定控件
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ZeroComboBox), new FrameworkPropertyMetadata());

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

        #endregion 圆角属性

        #region 颜色属性

        /// <summary>
        /// 按钮前景色属性委托
        /// </summary>
        public static readonly DependencyProperty ToggleButtonForegroundProperty =
            DependencyProperty.Register("ToggleButtonForeground", typeof(Brush), typeof(ZeroComboBox), new FrameworkPropertyMetadata());

        /// <summary>
        /// 下拉按钮前景色
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        public Brush ToggleButtonForeground
        {
            get { return (Brush)GetValue(ToggleButtonForegroundProperty); }
            set { SetValue(ToggleButtonForegroundProperty, value); }
        }

        /// <summary>
        /// 蒙板背景色属性委托
        /// </summary>
        public static readonly DependencyProperty MaskBackgroundProperty =
            DependencyProperty.Register("MaskBackground", typeof(Brush), typeof(ZeroComboBox), new FrameworkPropertyMetadata());

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

        #endregion 颜色属性

        #region 多选模式

        /// <summary>
        /// ListBox控件
        /// </summary>
        private ListBox? _listBox;

        /// <summary>
        /// 获取多选的项信息
        /// </summary>
        public IList? SelectedItems => IsMultiSelect ? _listBox?.SelectedItems : null;

        /// <summary>
        /// 多选属性委托
        /// </summary>
        public static readonly DependencyProperty IsMultiSelectProperty =
            DependencyProperty.Register("IsMultiSelect", typeof(bool), typeof(ZeroComboBox), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 多选属性
        /// </summary>
        [Bindable(true)]
        [Category("Appearance")]
        [Description("多选模式,该模式下IsTextSearchEnabled为false,并且资源需要使用ItemSource或者代码添加，不能使用xaml界面添加")]
        public bool IsMultiSelect
        {
            get { return (bool)GetValue(IsMultiSelectProperty); }
            set { SetValue(IsMultiSelectProperty, value); }
        }

        /// <summary>
        /// 结果显示分割符属性委托
        /// </summary>
        public static readonly DependencyProperty SplitCharProperty =
            DependencyProperty.Register("SplitChar", typeof(char), typeof(ZeroComboBox), new FrameworkPropertyMetadata(';', FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// 结果显示分割符
        /// </summary>
        [Category("Appearance")]
        [Description("多选模式,用户分割多选项目的显示信息")]
        public char SplitChar
        {
            get { return (char)GetValue(SplitCharProperty); }
            set { SetValue(SplitCharProperty, value); }
        }

        /// <summary>
        /// 获取UI中的ListBox控件
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this.IsMultiSelect == true)
            {
                this._listBox = Template.FindName("PART_ListBox", this) as ListBox;
                this._listBox?.SelectionChanged += ListBox_SelectionChanged;
            }
        }

        /// <summary>
        /// ListBox控件选择变更事件
        /// 变更后更新combBox的显示内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //可变字符串，存储选择内容
            StringBuilder _sb = new();
            if (_listBox == null) return;
            foreach (object item in _listBox.SelectedItems)
            {
                if (item == null) return;
                if (item.GetType().GetProperty(this.DisplayMemberPath) == null)
                {
                    if (item.GetType() != typeof(DataRowView))
                    {
                        _sb.Append(item.ToString()).Append(SplitChar);
                    }
                    else
                    {
                        _sb.Append(((DataRowView)item).Row[this.DisplayMemberPath].ToString()).Append(SplitChar);
                    }
                }
                else
                {
                    _sb.Append(item.GetType()?.GetProperty(_listBox.DisplayMemberPath)?.GetValue(item, null)?.ToString()).Append(SplitChar);
                }
            }
            base.Text = _sb.ToString().Trim(SplitChar);
        }

        /// <summary>
        /// 更新选中项，多选模式下有效；
        /// 绑定数据时需要在设定DisplayMemberPath后使用。
        /// </summary>
        /// <param name="items">资源显示信息内容的字符串，不同项之间用“;”隔开</param>
        private void UpdateSelectedItems(string items)
        {
            //判断是否为多选模式,并且items不为空
            if (IsMultiSelect && !string.IsNullOrWhiteSpace(items))
            {
                string[] strAray = items.Split(SplitChar);
                Int32 itemsCnt = 0;

                //清除旧的数据
                UnSelectedAll();

                //遍历文本查找数据
                for (int i = 0; i < strAray.Length; i++)
                {
                    if (_listBox == null) return;
                    //遍历所有选项，确认是否包含包含该选项
                    foreach (object item in _listBox.Items)
                    {
                        if (item == null) return;
                        if (item.GetType().GetProperty(_listBox.DisplayMemberPath) == null)
                        {
                            string? content;
                            if (item.GetType() != typeof(DataRowView))
                            {
                                content = item.ToString();
                            }
                            else
                            {
                                content = ((DataRowView)item).Row[this.DisplayMemberPath]?.ToString();
                            }

                            if (content?.Equals(strAray[i], StringComparison.InvariantCulture) == true)
                            {
                                _listBox.SelectedItems.Add(item);
                                itemsCnt++;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (item?.GetType()?.GetProperty(_listBox.DisplayMemberPath)?.GetValue(item, null)?.ToString()?.Equals(strAray[i], StringComparison.InvariantCulture) == true)
                            {
                                _listBox.SelectedItems.Add(item);
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 全选所有选项
        /// </summary>
        public void SelectedAll()
        {
            if (IsMultiSelect) _listBox?.SelectAll();
        }

        /// <summary>
        /// 取消全选
        /// </summary>
        public void UnSelectedAll()
        {
            if (IsMultiSelect) _listBox?.UnselectAll();
        }

        /// <summary>
        /// Text属性
        /// </summary>
        public new string Text
        {
            get { return base.Text; }
            set
            {
                if (IsMultiSelect)
                {
                    UpdateSelectedItems(value);
                }
                else
                {
                    base.Text = value;
                }
            }
        }

        #endregion 多选

    }
}
