using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class HistogramFittingTests
    {
        [TestMethod]
        public void FitExponentialDistribution_3Methods321Lines_LambdaPoint5()
        {
            var distribution = CreateDistribution.ForMethodLengths(1, 2, 3);
            Assert.AreEqual(0.5, distribution.GeometricalFit.Parameter, Constants.DELTA);
        }
     
        [TestMethod]
        public void FitExponentialDistribution_3Classes000PublicFields_Lambda1()
        {
            var distribution = CreateDistribution.ForPublicFields(0, 0, 0);
            Assert.AreEqual(1.0, distribution.GeometricalFit.Parameter, Constants.DELTA);
        }

        [TestMethod]
        public void FitExponentialDistribution_3Methods321Lines_WorseThan111()
        {
            var distributionBad = CreateDistribution.ForMethodLengths(1, 2, 3);
            var distributionGood = CreateDistribution.ForMethodLengths(1, 1, 1);
            Assert.IsTrue(
                distributionBad.GeometricalFit.Parameter <
                distributionGood.GeometricalFit.Parameter);
        }
    }
}
