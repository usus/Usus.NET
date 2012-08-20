using System;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ExpectInterestingDirectDependencyAttribute : TypeExpectation
    {
        public string ExpectedInterestingDependency { get; set; }

        public ExpectInterestingDirectDependencyAttribute(string value)
        {
            ExpectedInterestingDependency = value;
        }

        public override bool Verify(TypeMetricsReport metrics)
        {
            return metrics.InterestingDirectDependencies.Contains(ExpectedInterestingDependency);
        }

        public override string What
        {
            get { return ExpectedInterestingDependency; }
        }
    }
}
