using andrena.Usus.net.Core.Verification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.IntegrationTests
{
    [TestClass]
    public class MetricsCollectorTypeTests : MetricsCollectorTests
    {
        [TestMethod]
        public void Verify_NumberOfNonStaticPublicFields()
        {
            Verify.TypesWith<ExpectNumberOfNonStaticPublicFieldsAttribute>(Metrics);
        }

        [TestMethod]
        public void Verify_NumberOfMethods()
        {
            Verify.TypesWith<ExpectNumberOfMethodsAttribute>(Metrics);
        }

        [TestMethod]
        public void Verify_DirectDependencies()
        {
            Verify.TypesWith<ExpectDirectDependencyAttribute>(Metrics);
        }

        [TestMethod]
        public void Verify_NoDirectDependencies()
        {
            Verify.TypesWith<ExpectNoDirectDependencyAttribute>(Metrics);
        }

        [TestMethod]
        public void Verify_InterestingDependencies()
        {
            Verify.TypesWith<ExpectInterestingDirectDependencyAttribute>(Metrics);
        }

        [TestMethod]
        public void Verify_NoInterestingDependencies()
        {
            Verify.TypesWith<ExpectNoInterestingDirectDependencyAttribute>(Metrics);
        }

        [TestMethod]
        public void Verify_CumulativeComponentDependencies()
        {
            Verify.TypesWith<ExpectCumulativeComponentDependencyAttribute>(Metrics);
        }

        [TestMethod]
        public void Verify_Namespaces()
        {
            Verify.TypesWith<ExpectNamespaceAttribute>(Metrics);
        }
    }
}
