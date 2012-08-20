using System;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExpectNumberOfNonStaticPublicFieldsAttribute : TypeExpectation
    {
        public int ExpectedNumberOfNonStaticPublicFields { get; set; }

        public ExpectNumberOfNonStaticPublicFieldsAttribute(int value)
        {
            ExpectedNumberOfNonStaticPublicFields = value;
        }

        public override bool Verify(TypeMetricsReport metrics)
        {
            return metrics.NumberOfNonStaticPublicFields == ExpectedNumberOfNonStaticPublicFields;
        }

        public override string What
        {
            get { return ExpectedNumberOfNonStaticPublicFields.ToString(); }
        }
    }
}
