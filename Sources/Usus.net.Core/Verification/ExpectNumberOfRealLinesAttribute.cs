using System;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = false, Inherited = true)]
    public class ExpectNumberOfRealLinesAttribute : MethodExpectation
    {
        public int ExpectedNumberOfRealLines { get; private set; }

        public ExpectNumberOfRealLinesAttribute(int value)
        {
            ExpectedNumberOfRealLines = value;
        }

        public override bool Verify(MethodMetricsReport metrics)
        {
            return metrics.NumberOfRealLines == ExpectedNumberOfRealLines;
        }

        public override string What
        {
            get { return ExpectedNumberOfRealLines.ToString(); }
        }
    }
}
