using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfDemo
{
    internal class KilogramToPoundConverter : IValueConverter
    {
        private const double pound = 2.20462262;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double result = (double)value;
            return result * pound;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double result = (double)value;
            return result / pound;
        }
    }

    internal class KilogramToStoneConverter : IValueConverter
    {
        private const double stone = 0.157473044;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double result = (double)value;
            return result * stone;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double result = (double)value;
            return result / stone;
        }
    }
}
