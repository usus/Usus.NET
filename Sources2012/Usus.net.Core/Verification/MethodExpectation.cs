using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    public abstract class MethodExpectation : Expectation
    {
        public abstract bool Verify(MethodMetricsReport metrics);
    }
}
