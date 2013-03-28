using System;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = false, Inherited = true)]
    public class ExpectNumberOfLogicalLinesAttribute : MethodExpectation
    {
        public int ExpectedNumberOfLogicalLines { get; private set; }

        public ExpectNumberOfLogicalLinesAttribute(int value)
        {
            ExpectedNumberOfLogicalLines = value;
        }

        public override bool Verify(MethodMetricsReport metrics)
        {
            return metrics.NumberOfLogicalLines == ExpectedNumberOfLogicalLines;
        }

        public override string What
        {
            get { return ExpectedNumberOfLogicalLines.ToString(); }
        }
    }
}
