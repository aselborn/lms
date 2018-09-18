using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WPFReportViewer.Converters
{
    public class Level : IValueConverter
    {
        const int oneLevelMargin = 10;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int level = (int)value;
            return new Thickness(level * oneLevelMargin, 0, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public static IValueConverter LevelToMarginConverter = new Level();

    }
}
