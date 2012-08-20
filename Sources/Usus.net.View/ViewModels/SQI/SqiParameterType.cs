using System;
using System.Windows;

namespace andrena.Usus.net.View.ViewModels.SQI
{
    public static class SqiParameterType
    {
        public static string Number(int value)
        {
            return value.ToString();
        }

        public static void Number(int value, Action<string> valueAssignment)
        {
            valueAssignment(Number(value));
        }

        public static void Number(string newValue, Action<int> valueAssignment)
        {
            try
            {
                var parsed = int.Parse(newValue);
                valueAssignment(parsed);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid number!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static string Percentage(double value)
        {
            return value.ToString("0.00");
        }

        public static void Percentage(double value, Action<string> valueAssignment)
        {
            if (!double.IsNaN(value)) valueAssignment(Percentage(value));
        }

        public static void Percentage(string newValue, Action<double> valueAssignment)
        {
            try
            {
                var parsed = double.Parse(newValue);
                valueAssignment(parsed);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid percentage!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
