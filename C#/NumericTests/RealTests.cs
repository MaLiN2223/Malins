namespace NumericTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Numeric;

    [TestClass]
    public class RealTests
    {
        [TestMethod]
        public void Creating()
        {
            SymbolicObject r = 3.5;
            var number = r as Real;
            Assert.IsNotNull(number);
            Assert.AreEqual(5, number.FractionalPart);
            Assert.AreEqual(3, number.IntegerPart);
            Assert.AreEqual(3.5, number);
            Assert.IsTrue(3.5 == number);
            r = 3.3333333333333;
            number = r as Real;
            Assert.IsNotNull(number);
            Assert.AreEqual(3, number.FractionalPart);
            Assert.AreEqual(3333333333333, number.IntegerPart);
            Assert.AreEqual(3.3333333333333, number);
        }
    }
}