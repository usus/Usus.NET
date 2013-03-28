using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class HotspotClassSizeTest
    {
        [TestMethod]
        public void Hotspots_3ClassSizes1OverLimit_1Hotspot()
        {
            var hotspots = CreateHotspotOf.ClassSize(13, 4, 5);
            Assert.IsTrue(hotspots.Count() == 1);
        }
     
        [TestMethod]
        public void Hotspots_3ClassSizesNoOverLimit_NoHotspot()
        {
            var hotspots = CreateHotspotOf.ClassSize(2, 4, 5);
            Assert.IsTrue(hotspots.Count() == 0);
        }
     
        [TestMethod]
        public void Hotspots_NoClassSizes_NoHotspot()
        {
            var hotspots = CreateHotspotOf.ClassSize();
            Assert.IsTrue(hotspots.Count() == 0);
        }
    }
}
