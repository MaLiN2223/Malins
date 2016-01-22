namespace NumericTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Numeric;

    [TestClass]
    public class ComplexTests
    {
        [TestMethod]
        public void Creation()
        {
            var c1 = new Complex(1.0/2, 2);
            Assert.AreEqual(0.5, c1.Re);
            Assert.AreEqual(2, c1.Im);
            Assert.AreEqual("0.5+2i", c1.ToString());

            c1 = new Complex(9, -17.3);
            Assert.AreEqual(9, c1.Re);
            Assert.AreEqual(-17.3, c1.Im);
            Assert.AreEqual("9-17.3i", c1.ToString());
        }

        [TestMethod]
        public void Equality()
        {
            var c1 = new Complex(1.0/2, 2);
            var c2 = new Complex(1.0/2, 2);
            var c3 = new Complex(1.0/2, 5);
            Assert.AreEqual(c1, c2);
            Assert.AreNotSame(c2, c3);
        }

        [TestMethod]
        public void Add()
        {
            var c1 = new Complex(3, 2);
            var c2 = new Complex(3, 3);
            var c3 = c1 + c2;
            Assert.AreEqual(6, c3.Re);
            Assert.AreEqual(5, c3.Im);
            c1 = c2 + c3;
            Assert.AreEqual(9, c1.Re);
            Assert.AreEqual(8, c1.Im);
        }

        [TestMethod]
        public void Power()
        {
            var compl = new Complex(10, 7);
            var arr = new[]
            {
                new Complex(10, 7),
                new Complex(51, 140),
                new Complex(-470, 1757)
            };
            for (var i = 1; i <= 3; ++i)
                Assert.AreEqual(arr[i - 1], compl ^ i);
            compl = new Complex(2, 3);
            arr = new[]
            {
                new Complex(2, 3),
                new Complex(-5, 12),
                new Complex(-46, 9)
            };
        }

        [TestMethod]
        public void MultiplicationInt()
        {
            var compl = new Complex(10, 7);
            Assert.AreEqual(20, (compl*2).Re);
            Assert.AreEqual(14, (compl*2).Im);
        }
    }
}