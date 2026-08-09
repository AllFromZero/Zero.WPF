using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace Zero.WPF.Converters
{
    /// <summary>
    /// Boolean值取反转换器
    /// </summary>
    public class BooleanInverterConverter : IValueConverter
    {
        /// <summary>
        /// 正向转换
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {

                if (value.GetType() != typeof(bool))
                {
                    return null;
                }

                return !(bool)value;

            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 反向转换
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value.GetType() != typeof(bool))
                {
                    return null;
                }

                return !(bool)value;

            }
            catch
            {
                return null;
            }
        }
    }
}
