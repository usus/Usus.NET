using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class HotspotMethodLengthTest
    {
        [TestMethod]
        public void Hotspots_3MethodLengths1OverLimit_1Hotspot()
        {
            var hotspots = CreateHotspotOf.MethodLength(2, 9, 10);
            Assert.IsTrue(hotspots.Count() == 1);
        }

        [TestMethod]
        public void Hotspots_3MethodLengthsNoOverLimit_NoHotspot()
        {
            var hotspots = CreateHotspotOf.MethodLength(2, 9, 9);
            Assert.IsTrue(hotspots.Count() == 0);
        }

        [TestMethod]
        public void Hotspots_NoMethodLengths_NoHotspot()
        {
            var hotspots = CreateHotspotOf.MethodLength();
            Assert.IsTrue(hotspots.Count() == 0);
        }
    }
}
