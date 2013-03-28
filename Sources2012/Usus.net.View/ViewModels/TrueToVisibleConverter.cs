using System.Windows;

namespace andrena.Usus.net.View.ViewModels
{
    public class TrueToVisibleConverter : BindingConverter<bool, Visibility>
    {
        public TrueToVisibleConverter()
        {
            Converter = b => b ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
