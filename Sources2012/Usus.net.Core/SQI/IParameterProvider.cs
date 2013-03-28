
namespace andrena.Usus.net.Core.SQI
{
    public interface IParameterProvider
    {
        double TestCoverage { get; }
        int NamespaceCycles { get; }
        int ComplicatedMethods { get; }
        double AverageComponentDependency { get; }
        int BigClasses { get; }
        int BigMethods { get; }
        int CompilerWarnings { get; }
        int Namespaces { get; }
        int Classes { get; }
        int Methods { get; }
        int Rloc { get; }
    }
}
