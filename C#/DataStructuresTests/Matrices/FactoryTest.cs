using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.Matrices
{
    using System.Numerics;
    using DataStructures.Matrices.Generics; 

    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        public void Empty()
        {
            Matrix<int> m1 = Factory.Empty<int>(30, 15);
            Assert.AreEqual(30, m1.RowCount);
            Assert.AreEqual(15, m1.ColumnCount);
            for (int i = 0; i < 30; ++i)
            {
                for (int j = 0; j < 15; ++j)
                {
                    Assert.AreEqual(0, m1[i, j]);
                }
            }
            try
            {
                Matrix<int> m2 = Factory.Empty<int>(-1, 3);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {

            }
        }

        [TestMethod]
        public void Filled()
        {
            Matrix<int> m1 = Factory.Filled(30, 30, Matrix<int>.MultiplyNeutral);
            Assert.AreEqual(30, m1.RowCount);
            Assert.AreEqual(30, m1.ColumnCount);
            for (int i = 0; i < 30; ++i)
            {
                for (int j = 0; j < 30; ++j)
                {
                    Assert.AreEqual(1, m1[i, j]);
                }
            }
            int k = -3;
            m1 = Factory.Filled(30, 30, k);
            Assert.AreEqual(30, m1.RowCount);
            Assert.AreEqual(30, m1.ColumnCount);
            for (int i = 0; i < 30; ++i)
            {
                for (int j = 0; j < 30; ++j)
                {
                    Assert.AreEqual(k, m1[i, j]);
                }
            }
            Matrix<TestStruct> m2 = Factory.Filled(30, 30, new TestStruct(30));
            var item = new TestStruct(30);
            Assert.AreEqual(30, m1.RowCount);
            Assert.AreEqual(30, m1.ColumnCount);
            for (int i = 0; i < 30; ++i)
            {
                for (int j = 0; j < 30; ++j)
                {
                    Assert.AreEqual(item, m2[i, j]);
                }
            }
        }
        [TestMethod]
        public void Id()
        {
            var m = Factory.Identity<int>(8, 9);
            Assert.AreEqual(8, m.RowCount);
            Assert.AreEqual(9, m.ColumnCount);
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 9; ++j)
                {
                    Assert.AreEqual(i == j ? 1 : 0, m[i, j]);
                }
            }
            var m2 = Factory.Identity<Complex>(8, 9);
            Assert.AreEqual(8, m.RowCount);
            Assert.AreEqual(9, m.ColumnCount);
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 9; ++j)
                {
                    Assert.AreEqual(i == j ? Complex.One : Complex.Zero, m2[i, j]);
                }
            }
            var m3 = Factory.Identity<double>(9, 9);
            Assert.AreEqual(9, m3.ColumnCount);
            Assert.AreEqual(9, m3.RowCount);
            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 9; ++j)
                {
                    Assert.AreEqual(i == j ? 1.0 : 0.0, m3[i, j]);
                }
            }
        }

        [TestMethod]
        public void Copy()
        {
            var m = Factory.Identity<int>(9, 10);
            var m1 = Factory.Clone(m);
            Assert.IsFalse(ReferenceEquals(m1, m));
            Assert.IsTrue(m == m1);
            var m2 = Factory.Identity<Complex>(9, 10);
            var m3 = Factory.Clone(m2);
            Assert.IsFalse(ReferenceEquals(m2, m3));
            Assert.IsTrue(m2 == m3);
        }
    }
}
