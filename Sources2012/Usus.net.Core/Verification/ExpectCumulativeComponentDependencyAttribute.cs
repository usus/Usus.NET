using System;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExpectCumulativeComponentDependencyAttribute : TypeExpectation
    {
        public int ExpectedCumulativeComponentDependency { get; set; }

        public ExpectCumulativeComponentDependencyAttribute(int value)
        {
            ExpectedCumulativeComponentDependency = value;
        }

        public override bool Verify(TypeMetricsReport metrics)
        {
            return metrics.CumulativeComponentDependency == ExpectedCumulativeComponentDependency;
        }

        public override string What
        {
            get { return ExpectedCumulativeComponentDependency.ToString(); }
        }
    }
}
