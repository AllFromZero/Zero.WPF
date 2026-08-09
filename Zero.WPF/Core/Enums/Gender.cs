using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Zero.WPF.Core.Enums
{
    /// <summary>
    /// 性别
    /// </summary>
    [TypeConverter(typeof(EnumConverter))]
    public enum Gender : byte
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown,
        /// <summary>
        /// 男
        /// </summary>
        Male,
        /// <summary>
        /// 女
        /// </summary>
        Female,
        /// <summary>
        /// 其他
        /// </summary>
        Other,
    }
}
