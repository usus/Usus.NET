
namespace andrena.Usus.net.Core.SQI
{
    public class SqiParameters : IParameterProvider
    {
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