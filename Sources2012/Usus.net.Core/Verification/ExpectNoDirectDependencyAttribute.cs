using System;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ExpectNoDirectDependencyAttribute : TypeExpectation
    {
        public string ExpectedNoDependency { get; set; }

        public ExpectNoDirectDependencyAttribute(string value)
        {
            ExpectedNoDependency = value;
        }

        public override bool Verify(TypeMetricsReport metrics)
        {
            return !metrics.DirectDependencies.Contains(ExpectedNoDependency);
        }

        public override string What
        {
            get { return ExpectedNoDependency; }
        }
    }
}
