using System;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ExpectNoInterestingDirectDependencyAttribute : TypeExpectation
    {
        public string ExpectedNoInterestingDependency { get; set; }

        public ExpectNoInterestingDirectDependencyAttribute(string value)
        {
            ExpectedNoInterestingDependency = value;
        }

        public override bool Verify(TypeMetricsReport metrics)
        {
            return !metrics.InterestingDirectDependencies.Contains(ExpectedNoInterestingDependency);
        }

        public override string What
        {
            get { return ExpectedNoInterestingDependency; }
        }
    }
}
