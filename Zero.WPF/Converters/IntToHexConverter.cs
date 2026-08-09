using System.Globalization;
using System.Windows.Data;

namespace Zero.WPF.Converters
{
    /// <summary>
    /// 十六进制值转换器
    /// </summary>
    public class IntToHexConverter : IValueConverter
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
                if (value is byte || value is int || value is long)
                {
                    int intValue = System.Convert.ToInt32(value);
                    return string.Format("0x{0:X2}", intValue);
                }
                return value;
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
            if (value is string && int.TryParse(value.ToString(), NumberStyles.HexNumber, null, out int result))
            {
                return result;
            }
            return null;
        }
    }
}
