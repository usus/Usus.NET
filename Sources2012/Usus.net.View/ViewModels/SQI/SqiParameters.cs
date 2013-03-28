using System;
using andrena.Usus.net.Core.SQI;

namespace andrena.Usus.net.View.ViewModels.SQI
{
    public class SqiParameters : IParameterProvider
    {
        public double CurrentSqi { get; private set; }
        public event Action<double> SqiChanged;
        
        public SqiParameters()
        {
            SqiChanged += sqi => CurrentSqi = sqi;
        }

        public SqiParameter Assign(string parameter, int value, Action<SqiParameters, int> valueAssignment)
        {
            valueAssignment(this, value);
            var sqiParameter = new SqiParameter(parameter) { Value = SqiParameterType.Number(value) };
            sqiParameter.PropertyChanged += (_, __) => SqiParameterType.Number(sqiParameter.Value, v =>
            {
                valueAssignment(this, v);
                SqiChanged(CalculateSqi());
            });
            return sqiParameter;
        }

        public SqiParameter Assign(string parameter, double value, Action<SqiParameters, double> valueAssignment)
        {
            valueAssignment(this, value);
            var sqiParameter = new SqiParameter(parameter) { Value = SqiParameterType.Percentage(value) };
            sqiParameter.PropertyChanged += (_, __) => SqiParameterType.Percentage(sqiParameter.Value, v =>
            {
                valueAssignment(this, v);
                SqiChanged(CalculateSqi());
            });
            return sqiParameter;
        }

        private double CalculateSqi()
        {
            return this.SoftwareQualityIndex();
        }

        public double TestCoverage { get; set; }
        public int NamespaceCycles { get; set; }
        public int ComplicatedMethods { get; set; }
        public double AverageComponentDependency { get; set; }
        public int BigClasses { get; set; }
        public int BigMethods { get; set; }
        public int CompilerWarnings { get; set; }
        public int Namespaces { get; set; }
        public int Classes { get; set; }
        public int Methods { get; set; }
        public int Rloc { get; set; }
    }
}
