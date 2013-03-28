using System;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ExpectNoTypeDependencyAttribute : MethodExpectation
    {
        public string NotExpectedTypeDependency { get; private set; }

        public ExpectNoTypeDependencyAttribute(string value)
        {
            NotExpectedTypeDependency = value;
        }

        public override bool Verify(MethodMetricsReport metrics)
        {
            return !metrics.TypeDependencies.Contains(NotExpectedTypeDependency);
        }

        public override string What
        {
            get { return NotExpectedTypeDependency; }
        }
    }
}
