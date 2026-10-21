using System.ComponentModel;

namespace Test
{
    /// <summary>
    /// 目标值比较运算符
    /// </summary>
    public enum CompareOperator
    {
        /// <summary>
        /// 等于
        /// </summary>
        [Description("等于 (==)")]
        Equal = 0,

        /// <summary>
        /// 不等于
        /// </summary>
        [Description("不等于 (!=)")]
        NotEqual = 1,

        /// <summary>
        /// 大于
        /// </summary>
        [Description("大于 (>)")]
        GreaterThan = 2,

        /// <summary>
        /// 大于等于
        /// </summary>
        [Description("大于等于 (>=)")]
        GreaterThanOrEqual = 3,

        /// <summary>
        /// 小于
        /// </summary>
        [Description("小于 (<)")]
        LessThan = 4,

        /// <summary>
        /// 小于等于
        /// </summary>
        [Description("小于等于 (<=)")]
        LessThanOrEqual = 5
    }
}