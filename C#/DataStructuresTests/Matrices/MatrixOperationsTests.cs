using DataStructures.Matrices;
using DataStructures.Matrices.Integers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.Matrices
{
    [TestClass]
    public class MatrixOperationsTests
    {
        MatrixFactory factory = new MatrixFactory();


        private void AreEqual(int[,] data, Matrix<int> m)
        {
            for (int i = 0; i < m.RowCount; ++i)
            {
                for (int j = 0; j < m.ColumnCount; ++j)
                {
                    Assert.AreEqual(data[i, j], m[i, j]);
                }
            }
        }
        [TestMethod]
        public void ToSmith()
        {
            var data = new int[,]
            {
                {2,6,5},
                {4,1,2},
                {5,3,2}
            };
            var good = new int[,]
            {
                {1, 0, 0},
                {0, 1, 0},
                {0, 0, 39}
            };
            var matrix = factory.Create(data);
            matrix.ToSmith();
            Assert.IsTrue(matrix.IsSmithForm(2));
            AreEqual(good, matrix); 
        }
    }
}
