using System;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ExpectDirectDependencyAttribute : TypeExpectation
    {
        public string ExpectedDependency { get; set; }

        public ExpectDirectDependencyAttribute(string value)
        {
            ExpectedDependency = value;
        }

        public override bool Verify(TypeMetricsReport metrics)
        {
            return metrics.DirectDependencies.Contains(ExpectedDependency);
        }

        public override string What
        {
            get { return ExpectedDependency; }
        }
    }
}
