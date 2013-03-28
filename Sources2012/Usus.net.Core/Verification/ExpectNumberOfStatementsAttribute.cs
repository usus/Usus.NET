using System;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ExpectNumberOfStatementsAttribute : MethodExpectation
    {
        public int ExpectedNumberOfStatements { get; private set; }

        public ExpectNumberOfStatementsAttribute(int value)
        {
            ExpectedNumberOfStatements = value;
        }

        public override bool Verify(MethodMetricsReport metrics)
        {
            return metrics.NumberOfStatements == ExpectedNumberOfStatements;
        }

        public override string What
        {
            get { return ExpectedNumberOfStatements.ToString(); }
        }
    }
}
