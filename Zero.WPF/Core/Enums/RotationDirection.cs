using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Zero.WPF.Core.Enums
{
    /// <summary>
    /// 旋转方向
    /// </summary>
    [TypeConverter(typeof(EnumConverter))]
    public enum RotationDirection
    {
        /// <summary>
        /// 顺时针
        /// </summary>
        [Description("顺时针")]
        CW,
        /// <summary>
        /// 逆时针
        /// </summary>
        [Description("逆时针")]
        CCW,
    }
}
