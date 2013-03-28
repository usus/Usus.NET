using System;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExpectNumberOfMethodsAttribute : TypeExpectation
    {
        public int ExpectedNumberOfMethods { get; set; }

        public ExpectNumberOfMethodsAttribute(int value)
        {
            ExpectedNumberOfMethods = value;
        }

        public override bool Verify(TypeMetricsReport metrics)
        {
            return metrics.NumberOfMethods == ExpectedNumberOfMethods;
        }

        public override string What
        {
            get { return ExpectedNumberOfMethods.ToString(); }
        }
    }
}
