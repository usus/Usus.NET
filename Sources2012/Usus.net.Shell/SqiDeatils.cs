using andrena.Usus.net.View.ExtensionPoints;

namespace andrena.Usus.net.Shell
{
    public class SqiDeatils : IKnowSqiDetails
    {
        public double TestCoverage
        {
            get { return double.NaN; }
        }

        public int CompilerWarnings
        {
            get { return 0; }
        }

        public string CurrentSolutionFile
        {
            get { return null; }
        }
    }
}
