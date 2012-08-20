using System;
using System.Windows.Data;

namespace andrena.Usus.net.View.ViewModels
{
    public class BindingConverter<S, T> : IValueConverter
    {
        protected Func<S, T> Converter { get; set; }
        protected T Default { get; set; }
 
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is S)
                return Converter((S)value);
            else 
                return Default;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
