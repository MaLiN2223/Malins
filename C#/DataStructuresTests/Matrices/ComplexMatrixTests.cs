namespace DataStructuresTests.Matrices
{
    using System.Numerics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataStructures.Matrices.Generics;

    [TestClass]
    public class ComplexMatrixTests
    {
        [TestMethod]
        public void Init()
        {
            Matrix<Complex> m = Factory.Empty<Complex>(5, 10);
            Assert.AreEqual(5, m.RowCount);
            Assert.AreEqual(10, m.ColumnCount);
            Assert.AreEqual(Matrix<Complex>.MultiplyNeutral, Complex.One);
            Assert.AreEqual(Matrix<Complex>.SumNeutral, Complex.Zero);
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Assert.AreEqual(default(Complex), m[i, j]);
                }
            }
            m = Factory.Identity<Complex>(5, 10);
            Assert.AreEqual(5, m.RowCount);
            Assert.AreEqual(10, m.ColumnCount);
            Assert.AreEqual(Matrix<Complex>.MultiplyNeutral, Complex.One);
            Assert.AreEqual(Matrix<Complex>.SumNeutral, Complex.Zero);
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    if (i == j)
                        Assert.AreEqual(Complex.One, m[i, j]);
                    else
                    {
                        Assert.AreEqual(Complex.Zero, m[i, j]);
                    }
                }
            }
        }
    }
}
