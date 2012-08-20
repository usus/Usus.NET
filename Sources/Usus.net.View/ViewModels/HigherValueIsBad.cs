using System.Windows.Media;

namespace andrena.Usus.net.View.ViewModels
{
    public class HigherValueIsBad : BindingConverter<ValueInTime, SolidColorBrush>
    {
        public HigherValueIsBad()
        {
            Default = Brushes.Black;
            Converter = value =>
            {
                if (value.GotHigher) return Brushes.Red;
                if (value.GotLower) return Brushes.Green;
                return Brushes.Black;
            };
        }
    }
}