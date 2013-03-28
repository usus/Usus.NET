using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.Core.Verification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.IntegrationTests
{
    [TestClass]
    public class MetricsCollectorMethodTests : MetricsCollectorTests
    {
        [TestMethod]
        public void Verify_CyclomaticComplexities()
        {
            Verify.MethodsWith<ExpectCyclomaticComplexityAttribute>(Metrics);
        }

        [TestMethod]
        public void Verify_TypeDependencies()
        {
            Verify.MethodsWith<ExpectTypeDependencyAttribute>(Metrics);
        }

        [TestMethod]
        public void Verify_NoTypeDependencies()
        {
            Verify.MethodsWith<ExpectNoTypeDependencyAttribute>(Metrics);
        }

        [TestMethod]
        public void Verify_NumberOfStatements()
        {
            Verify.MethodsWith<ExpectNumberOfStatementsAttribute>(Metrics);
        }

        [TestMethod]
        public void Verify_NumberOfRealLines()
        {
            Verify.MethodsWith<ExpectNumberOfRealLinesAttribute>(Metrics);
        }

        [TestMethod]
        public void Verify_NumberOfLogicalLines()
        {
            Verify.MethodsWith<ExpectNumberOfLogicalLinesAttribute>(Metrics);
        }

        [TestMethod]
        public void MetricsForProperty_AutoImplementedPropertyGetterAndSetter_Found()
        {
            var propertyMetrics = Metrics.ForProperty(() => MethodMetrics.MethodLengths.PropertyAutoImplemented);
            Assert.IsTrue(propertyMetrics.Getter != null);
            Assert.IsTrue(propertyMetrics.Setter != null);
        }

        [TestMethod]
        public void MetricsForProperty_PropertyGetterNoSetter_Found()
        {
            var propertyMetrics = Metrics.ForProperty(() => MethodMetrics.MethodLengths.PropertyGetterWithLogic);
            Assert.IsTrue(propertyMetrics.Getter != null);
            Assert.IsTrue(propertyMetrics.Setter == null);
        }

        [TestMethod]
        public void MetricsForMethod_MethodWithReturnValue_Found()
        {
            var report = Metrics.ForMethod(() => MethodMetrics.TypeDependencies.MethodWithNoGenericsInSignature(null));
            Assert.IsTrue(report != null);
        }

        [TestMethod]
        public void MetricsForMethod_InterfaceMethod_IsJustDeclaration()
        {
            var report = Metrics.ForMethod("System.NullReferenceException Usus.net.Core.IntegrationTests.MethodMetrics.AbstractTypes.IInterface.DoSomething(System.Exception)");
            Assert.IsTrue(report.OnlyDeclaration);
        }

        [TestMethod]
        public void MetricsForMethod_AbstractClassMethod_IsJustDeclaration()
        {
            var report = Metrics.ForMethod("System.NullReferenceException Usus.net.Core.IntegrationTests.MethodMetrics.AbstractTypes.IAbstractClass.DoSomething(System.Exception)");
            Assert.IsTrue(report.OnlyDeclaration);
        }
    }
}
