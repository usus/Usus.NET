using System.Windows.Media;

namespace andrena.Usus.net.View.ViewModels
{
    public class HigherValueIsGood : BindingConverter<ValueInTime, SolidColorBrush>
    {
        public HigherValueIsGood()
        {
            Default = Brushes.Black;
            Converter = value =>
            {
                if (value.GotHigher) return Brushes.Green;
                if (value.GotLower) return Brushes.Red;
                return Brushes.Black;
            };
        }
    }
}