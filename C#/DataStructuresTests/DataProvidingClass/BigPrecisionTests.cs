using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.DataProvidingClass
{
    using System;
    using DataStructures.DataProvidingClass;

    [TestClass]
    public class BigPrecisionTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Random r = new Random();
            int k;
            for (int i = 0; i < 500000; i += k)
            {
                BigPrecision num = new BigPrecision(i);
                Assert.AreEqual(i, num);
                k = r.Next(1, 10);
            }
        }
    }
}
