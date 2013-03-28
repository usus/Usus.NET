
namespace andrena.Usus.net.View.ExtensionPoints
{
    public interface IKnowSqiDetails
    {
        double TestCoverage { get; }
        int CompilerWarnings { get; }
        string CurrentSolutionFile { get; }
    }
}
