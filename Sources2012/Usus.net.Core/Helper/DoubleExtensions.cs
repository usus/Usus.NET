
namespace andrena.Usus.net.Core.Helper
{
    public static class DoubleExtensions
    {
        public static string Percent(this double value)
        {
            return value.ToString("0.0%");
        }

        public static string Value(this double value)
        {
            return value.ToString("0.00");
        }
    }
}
