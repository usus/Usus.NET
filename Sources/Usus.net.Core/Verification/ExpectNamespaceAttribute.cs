using System;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ExpectNamespaceAttribute : TypeExpectation
    {
        public string ExpectedNamespace { get; set; }

        public ExpectNamespaceAttribute(string value)
        {
            ExpectedNamespace = value;
        }

        public override bool Verify(TypeMetricsReport metrics)
        {
            return metrics.Namespaces.Contains(ExpectedNamespace);
        }

        public override string What
        {
            get { return ExpectedNamespace; }
        }
    }
}
