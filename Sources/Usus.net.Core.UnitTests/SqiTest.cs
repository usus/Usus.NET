using andrena.Usus.net.Core.SQI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class SqiTest
    {
        [TestMethod]
        public void SoftwareQualityIndex_SampleParameters_SampleSqi()
        {
            IParameterProvider parameters = new SqiParameters
                                                {
                                                    TestCoverage = 54,
                                                    NamespaceCycles = 3,
                                                    ComplicatedMethods = 11,
                                                    AverageComponentDependency = 0.05,
                                                    BigClasses = 17,
                                                    BigMethods = 2,
                                                    CompilerWarnings = 0,
                                                    Classes = 311,
                                                    Methods = 1305,
                                                    Namespaces = 54,
                                                    Rloc = 4831
                                                };
            Assert.AreEqual(76.4, parameters.SoftwareQualityIndex(), Constants.BIG_DELTA);
        }
    }
}