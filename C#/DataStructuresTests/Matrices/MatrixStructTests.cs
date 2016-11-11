using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.Matrices
{
    using System.Diagnostics;
    using DataStructures.Matrices.Generics;

    [TestClass]
    public class MatrixStructTests
    {
        [TestMethod]
        public void Create()
        {
            Matrix<TestStruct> data = Factory<TestStruct>.Empty(10, 10);
            Assert.AreEqual(10, data.ColumnCount);
            Assert.AreEqual(10, data.RowCount);
            Assert.AreEqual(Matrix<TestStruct>.MultiplyNeutral, TestStruct.MultiplyNeutral);
            Assert.AreEqual(Matrix<TestStruct>.SumNeutral, TestStruct.SumNeutral);
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Assert.AreEqual(default(TestStruct), data[i, j]);
                }
            }
            data = Factory<TestStruct>.Identity(10, 10);
            Assert.AreEqual(10, data.ColumnCount);
            Assert.AreEqual(10, data.RowCount);
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Assert.AreEqual(i == j ? TestStruct.MultiplyNeutral : TestStruct.SumNeutral, data[i, j]);
                }
            }
        }
    }
}
