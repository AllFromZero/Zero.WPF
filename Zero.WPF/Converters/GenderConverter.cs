using System.Globalization;
using System.Windows.Data;
using Zero.WPF.Core.Enums;
using Zero.WPF.Resources;

namespace Zero.WPF.Converters
{
    /// <summary>
    /// 性别转换器
    /// </summary>
    public class GenderConverter : IValueConverter
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
                Gender gender = (Gender)value;
                return gender switch
                {
                    Gender.Male => Strings.Male,
                    Gender.Female => Strings.Female,
                    Gender.Other => Strings.Other,
                    _ => Strings.Unknown,
                };
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
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Gender.Unknown;
            }
            else if (value.Equals(Strings.Male))
            {
                return Gender.Male;
            }
            else if (value.Equals(Strings.Female))
            {
                return Gender.Female;
            }
            else if (value.Equals(Strings.Other))
            {
                return Gender.Other;
            }
            else
            {
                return Gender.Unknown;
            }

        }
    }
}
