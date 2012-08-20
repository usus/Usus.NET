using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    public abstract class TypeExpectation : Expectation
    {
        public abstract bool Verify(TypeMetricsReport metrics);
    }
}
