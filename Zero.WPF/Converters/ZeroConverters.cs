using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Zero.WPF.Converters
{
    /// <summary>
    /// 静态转换器类
    /// </summary>
    public static class ZeroConverters
    {
        /// <summary>
        /// 与计算转换器
        /// </summary>
        public static AndMultiConverter AndConverter { get; } = new AndMultiConverter();

        /// <summary>
        /// Bool值序号转换器
        /// </summary>
        public static BooleanIndexMultiConverter BooleanIndex { get; } = new BooleanIndexMultiConverter();

        /// <summary>
        /// Bool反转
        /// </summary>
        public static BooleanInverterConverter BooleanInverter { get; } = new BooleanInverterConverter();

        /// <summary>
        /// Bool转可见属性
        /// </summary>
        public static BooleanToVisibilityConverter BooleanToVisibility { get; } = new BooleanToVisibilityConverter();

        /// <summary>
        /// 性别转换
        /// </summary>
        public static GenderConverter GenderConverter { get; } = new GenderConverter();

        /// <summary>
        /// Int转16进制数
        /// </summary>
        public static IntToHexConverter IntToHex { get; } = new IntToHexConverter();
        
        /// <summary>
        /// Object转String
        /// </summary>
        public static ObjectToStringMultiConverter ObjectToString { get; } = new ObjectToStringMultiConverter();

        /// <summary>
        /// 或转换器
        /// </summary>
        public static OrMultiConverter OrConverter { get; } = new OrMultiConverter();
    }
}
