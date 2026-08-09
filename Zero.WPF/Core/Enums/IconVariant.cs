using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Zero.WPF.Core.Enums
{
    /// <summary>
    /// 图标样式枚举类
    /// </summary>
    [TypeConverter(typeof(EnumConverter))]
    public enum IconVariant
    {
        /// <summary>
        /// 正常样式
        /// </summary>
        [Description("正常图标样式")]
        Normal = 0,

        /// <summary>
        /// 隐藏样式
        /// </summary>
        [Description("隐藏图标样式")]
        Hidden = 1,

        /// <summary>
        /// 仅显示图标样式
        /// </summary>
        [Description("仅显示图标样式")]
        OnlyIcon = 2,
    }
}
