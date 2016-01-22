namespace DataStructuresTests.Matrices
{
    using DataStructures.Matrices;
    using DataStructures.Matrices.Integers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixOperationsTests
    {
        private readonly MatrixFactory factory = new MatrixFactory();


        private void AreEqual(int[,] data, Matrix<int> m)
        {
            for (var i = 0; i < m.RowCount; ++i)
            {
                for (var j = 0; j < m.ColumnCount; ++j)
                {
                    Assert.AreEqual(data[i, j], m[i, j]);
                }
            }
        }

        [TestMethod]
        public void ToSmith()
        {
            var data = new[,]
            {
                {2, 6, 5},
                {4, 1, 2},
                {5, 3, 2}
            };
            var good = new[,]
            {
                {1, 0, 0},
                {0, 1, 0},
                {0, 0, 39}
            };
            var matrix = this.factory.Create(data);
            matrix.ToSmith();
            Assert.IsTrue(matrix.IsSmithForm(2));
            AreEqual(good, matrix);
        }
    }
}