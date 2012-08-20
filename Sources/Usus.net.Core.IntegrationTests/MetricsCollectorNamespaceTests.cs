using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.IntegrationTests
{
    [TestClass]
    public class MetricsCollectorNamespaceTests : MetricsCollectorTests
    {
        [TestMethod]
        public void Verify_NumberOfNamespacesInCycle_WithNoReferences()
        {
            var namespace1 = Metrics.Namespaces.First(n => n.Name == "Usus.net.Core.IntegrationTests.NamespaceMetrics.Test1");
            var namespace2 = Metrics.Namespaces.First(n => n.Name == "Usus.net.Core.IntegrationTests.NamespaceMetrics.Test2");
            var namespace3 = Metrics.Namespaces.First(n => n.Name == "Usus.net.Core.IntegrationTests.NamespaceMetrics.Test3");

            Assert.AreEqual(1, namespace1.NumberOfNamespacesInCycle);
            Assert.AreEqual(1, namespace2.NumberOfNamespacesInCycle);
            Assert.AreEqual(1, namespace3.NumberOfNamespacesInCycle);
        }

        [TestMethod]
        public void Verify_NumberOfNamespacesInCycle_WithOnBigCycle()
        {
            var namespace1 = Metrics.Namespaces.First(n => n.Name == "Usus.net.Core.IntegrationTests.NamespaceMetrics.Test4");
            var namespace2 = Metrics.Namespaces.First(n => n.Name == "Usus.net.Core.IntegrationTests.NamespaceMetrics.Test5");
            var namespace3 = Metrics.Namespaces.First(n => n.Name == "Usus.net.Core.IntegrationTests.NamespaceMetrics.Test6");

            Assert.AreEqual(3, namespace1.NumberOfNamespacesInCycle);
            Assert.AreEqual(3, namespace2.NumberOfNamespacesInCycle);
            Assert.AreEqual(3, namespace3.NumberOfNamespacesInCycle);
        }
    }
}
