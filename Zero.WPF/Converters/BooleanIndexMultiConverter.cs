using System.Globalization;
using System.Windows.Data;

namespace Zero.WPF.Converters
{
    /// <summary>
    /// True值列表序号转换器
    /// </summary>
    /// <remarks>返回列表第一个符合值的序号,从0开始</remarks>
    public class BooleanIndexMultiConverter : IMultiValueConverter
    {
        /// <summary>
        /// 正向转换
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter">设置参数为False或Null，则识别其他值的序号</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
            {
                return 0;
            }

            for (int i = 0; i < values.Length; i++)
            {
                bool? flag = true;
                if (parameter != null && parameter is bool?)
                {
                    flag = (bool?)parameter;
                }

                if (values[i] is bool? && (bool?)values[i] == flag)
                {
                    return i;
                }
            }
            return 0;
        }

        /// <summary>
        /// 反向转换
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetTypes"></param>
        /// <param name="parameter">设置参数为False，则识别False的序号</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object?[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            object?[] result = new object?[targetTypes.Length];
            bool? flag = true;
            if (parameter != null && parameter is bool?)
            {
                flag = (bool?)parameter;
            }

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = flag != null && !flag.Value;
            }

            if (value is int index)
            {
                if (index < targetTypes.Length && index >= 0)
                {
                    result[index] = flag;
                }
            }

            return result;
        }
    }
}
