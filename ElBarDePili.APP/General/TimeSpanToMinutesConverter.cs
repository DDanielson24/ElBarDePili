using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.General
{
    public class TimeSpanToMinutesConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is TimeSpan timeSpan)
            {
                return timeSpan.TotalMinutes;
            }

            return 0;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (double.TryParse((string?)value, out double minutes))
            {
                return TimeSpan.FromMinutes(minutes);
            }

            return TimeSpan.Zero;
        }
    }
}
