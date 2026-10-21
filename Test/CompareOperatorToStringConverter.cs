using System;
using System.Globalization;
using System.Windows.Data;

namespace Test
{
    /// <summary>
    /// CompareOperator 枚举转换器
    /// </summary>
    public class CompareOperatorToStringConverter : IValueConverter
    {
        /// <summary>
        /// 正向转换：CompareOperator 枚举 → 显示文本
        /// </summary>
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !Enum.TryParse(value.ToString(), out CompareOperator op))
            {
                return string.Empty;
            }

            return op switch
            {
                CompareOperator.Equal => "等于",
                CompareOperator.NotEqual => "不等于",
                CompareOperator.GreaterThan => "大于",
                CompareOperator.GreaterThanOrEqual => "大于等于",
                CompareOperator.LessThan => "小于",
                CompareOperator.LessThanOrEqual => "小于等于",
                _ => op.ToString()
            };
        }

        /// <summary>
        /// 反向转换：显示文本 → CompareOperator 枚举
        /// </summary>
        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            if (value.GetType() == typeof(CompareOperator))
            {
                return value;
            }

            string stringValue = value?.ToString() ?? string.Empty;
            if (string.IsNullOrEmpty(stringValue))
            {
                return null;
            }

            if (Enum.TryParse(stringValue, out CompareOperator op))
            {
                return op;
            }
            else if (stringValue.Equals("等于"))
            {
                return CompareOperator.Equal;
            }
            else if (stringValue.Equals("不等于"))
            {
                return CompareOperator.NotEqual;
            }
            else if (stringValue.Equals("大于"))
            {
                return CompareOperator.GreaterThan;
            }
            else if (stringValue.Equals("大于等于"))
            {
                return CompareOperator.GreaterThanOrEqual;
            }
            else if (stringValue.Equals("小于"))
            {
                return CompareOperator.LessThan;
            }
            else if (stringValue.Equals("小于等于"))
            {
                return CompareOperator.LessThanOrEqual;
            }

            return null;
        }
    }
}