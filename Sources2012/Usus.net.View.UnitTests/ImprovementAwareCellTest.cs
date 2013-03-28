using andrena.Usus.net.View.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.View.UnitTests
{
    [TestClass]
    public class ImprovementAwareCellTest
    {
        [TestMethod]
        public void ToString_WithValue_ReturnsThatValueString()
        {
            ValueInTime<int> valueInTime = new ValueInTime<int>(5);
            Assert.AreEqual("5", valueInTime.ToString());
        }

        [TestMethod]
        public void ToString_WithUpdatedValue_ReturnsThatNewValueString()
        {
            ValueInTime<int> valueInTime = new ValueInTime<int>(5);
            valueInTime.Update(6);
            Assert.AreEqual("6", valueInTime.ToString());
        }

        [TestMethod]
        public void GotLower_WithSmallerUpdateValue_ReturnsTrue()
        {
            ValueInTime<int> valueInTime = new ValueInTime<int>(5);
            valueInTime.Update(4);
            Assert.IsTrue(valueInTime.GotLower);
        }

        [TestMethod]
        public void GotHigher_WithBiggerUpdateValue_ReturnsTrue()
        {
            ValueInTime<int> valueInTime = new ValueInTime<int>(5);
            valueInTime.Update(6);
            Assert.IsTrue(valueInTime.GotHigher);
        }

        [TestMethod]
        public void GotHigherAndGotLower_WithSameUpdateValue_ReturnFalse()
        {
            ValueInTime<int> valueInTime = new ValueInTime<int>(5);
            valueInTime.Update(5);
            Assert.IsFalse(valueInTime.GotHigher);
            Assert.IsFalse(valueInTime.GotLower);
        }

        [TestMethod]
        public void GotHigher_WithSmallerThenBiggerUpdateValue_ReturnsTrue()
        {
            ValueInTime<int> valueInTime = new ValueInTime<int>(5);
            valueInTime.Update(4);
            valueInTime.Update(6);
            Assert.IsTrue(valueInTime.GotHigher);
        }
    }
}
