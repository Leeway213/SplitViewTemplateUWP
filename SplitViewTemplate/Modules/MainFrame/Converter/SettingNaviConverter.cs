using System;
using Windows.UI.Xaml.Data;

namespace SplitViewTemplate.Modules.MainFrame.Converter
{
    public class SettingNaviConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value is SettingPage.View.SettingPage ? 0 : -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
