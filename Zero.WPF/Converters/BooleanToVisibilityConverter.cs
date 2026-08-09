using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Zero.WPF.Converters
{
    /// <summary>
    /// Boolean值转可是结果取反转换器
    /// </summary>
    /// <remarks>可通过设置参数为Invert进行值取反</remarks>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// 正向转换
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter">可通过设置参数为Invert进行值取反</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                Visibility visibility = Visibility.Visible;
                if (value is bool?)
                { 
                    bool? boolValue = value as bool?;
                    bool isInvert = parameter?.ToString()?.Equals("Invert") == true;
                    visibility = boolValue switch
                    {
                        true => isInvert ? Visibility.Collapsed : Visibility.Visible,
                        false => isInvert ? Visibility.Visible : Visibility.Collapsed,
                        _ => Visibility.Hidden,
                    };
                }

                return visibility;

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
        /// <param name="parameter">可通过设置参数为Invert进行值取反</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                bool? result = null;
                if (value.GetType() == typeof(Visibility))
                {
                    Visibility visibility = (Visibility)value;
                    bool isInvert = parameter?.ToString()?.Equals("Invert") == true;
                    result = visibility switch
                    {
                        Visibility.Visible => !isInvert,
                        Visibility.Collapsed => isInvert,
                        Visibility.Hidden => null,
                        _ => throw new NotImplementedException(),
                    };
                }

                return result;

            }
            catch
            {
                return null;
            }
        }
    }
}
