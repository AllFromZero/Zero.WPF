using System.Globalization;
using System.Windows.Data;

namespace Zero.WPF.Converters
{
    /// <summary>
    /// 多绑定转换器
    /// </summary>
    /// <remarks>可通过转换参数修改分割字符串</remarks>
    public class ObjectToStringMultiConverter : IMultiValueConverter
    {
        /// <summary>
        /// 正向绑定
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string str = "";
            char splitChar = ' ';
            for (int i = 0; i < values.Length; i++)
            {
                str = string.Format("{0}{1}{2}", str, splitChar, values[i]);  
            }
            return str.Trim(splitChar, ' ');
        }

        /// <summary>
        /// 反向绑定
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetTypes"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
