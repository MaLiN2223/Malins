namespace DataStructuresTests.Matrices
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataStructures.Matrices.Generics;
    using Numeric;

    [TestClass]
    public class ComplexMatrixTests
    {
        [TestMethod]
        public void Init()
        {
            Matrix<Complex> m = Factory.Empty<Complex>(5, 10);
            Assert.AreEqual(5, m.RowCount);
            Assert.AreEqual(10, m.ColumnCount);
            Assert.AreEqual(Matrix<Complex>.MultiplyNeutral, Complex.MultiplyNeutral);
            Assert.AreEqual(Matrix<Complex>.SumNeutral, Complex.SumNeutral);
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
            Assert.AreEqual(Matrix<Complex>.MultiplyNeutral, Complex.MultiplyNeutral);
            Assert.AreEqual(Matrix<Complex>.SumNeutral, Complex.SumNeutral);
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    if (i == j)
                        Assert.AreEqual(Complex.MultiplyNeutral, m[i, j]);
                    else
                    {
                        Assert.AreEqual(Complex.SumNeutral, m[i, j]);
                    }
                }
            }
        }
    }
}
