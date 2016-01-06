using System;
using DataStructures.Matrices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Matrices.Double;
namespace DataStructuresTests.Matrices
{
    [TestClass]
    public partial class FactoryTests
    {
        private static MatrixFactory factory = new MatrixFactory();
        private static Random random = new Random();

        private void AreEqual(Matrix<double> matrix, double[,] arr)
        {
            for (int i = 0; i < matrix.RowCount; ++i)
                for (int j = 0; j < matrix.ColumnCount; ++j)
                {
                    Assert.AreEqual(arr[i, j], matrix[i, j]);
                }
        }

        private void AreEqual(Matrix<double> matrix, MatrixContainer container)
        {
            for (int i = 0; i < matrix.RowCount; ++i)
                for (int j = 0; j < matrix.ColumnCount; ++j)
                {
                    Assert.AreEqual(container[i, j], matrix[i, j]);
                }
        }
        [TestMethod]
        public void EmptyDouble()
        {
            int x = 10;
            int y = 7;
            var matrix = factory.Empty(x, y);
            Assert.AreEqual(x, matrix.RowCount);
            Assert.AreEqual(y, matrix.ColumnCount);
            for (int i = 0; i < x; ++i)
                for (int j = 0; j < y; ++j)
                {
                    Assert.AreEqual(0.0, matrix[i, j]);
                }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyBadDouble()
        {
            var matrix = factory.Empty(-2, 3);
        }

        [TestMethod]
        public void IdentityDouble()
        {
            int x = 15;
            var matrix = factory.Identity(x);
            Assert.AreEqual(x, matrix.RowCount);
            Assert.AreEqual(x, matrix.ColumnCount);
            for (int i = 0; i < x; ++i)
                for (int j = 0; j < x; ++j)
                {
                    Assert.AreEqual(i == j ? 1.0 : 0.0, matrix[i, j]);
                }
            x = 1;
            matrix = factory.Identity(x);
            Assert.AreEqual(x, matrix.RowCount);
            Assert.AreEqual(x, matrix.ColumnCount);
            for (int i = 0; i < x; ++i)
                for (int j = 0; j < x; ++j)
                {
                    Assert.AreEqual(i == j ? 1.0 : 0.0, matrix[i, j]);
                }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IdentityBadDouble()
        {
            var matrix = factory.Identity(-1);
        }

        [TestMethod]
        public void FromContainerDouble()
        {
            int y = 500;
            int x = 600;
            MatrixContainer container = new MatrixContainer(x, y);
            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < y; ++j)
                {
                    container[i, j] = random.NextDouble();
                }
            }
            var matrix = factory.Create(container);
            Assert.AreNotSame(matrix.Container, container);
            AreEqual(matrix, container);
            container[0, 0] = container[0, 0] - 10;
            Assert.AreNotEqual(container[0, 0], matrix[0, 0]);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullContainerDouble()
        {
            var matrix = factory.Create((MatrixContainer)null);
        }

        [TestMethod]
        public void FromArrayDouble()
        {
            int y = 500;
            int x = 600;
            double[,] arr = new double[x, y];
            for (int i = 0; i < x; ++i)
                for (int j = 0; j < y; ++j)
                    arr[i, j] = random.NextDouble();
            var m = factory.Create(arr);
            Assert.AreEqual(x, m.RowCount);
            Assert.AreEqual(y, m.ColumnCount);
            AreEqual(m, arr);
            arr[0, 0] = arr[0, 0] - 10;
            Assert.AreNotEqual(arr[0, 0], m[0, 0]);
        }

        [TestMethod]
        public void FilledDouble()
        {
            int y = 500;
            int x = 600;
            for (int p = 0; p < 10; ++p)
            {
                double rand = random.NextDouble();
                var matrix = factory.Filled(x, y, rand);
                Assert.AreEqual(x, matrix.RowCount);
                Assert.AreEqual(y, matrix.ColumnCount);
                for (int i = 0; i < matrix.RowCount; ++i)
                {
                    for (int j = 0; j < matrix.ColumnCount; ++j)
                    {
                        Assert.AreEqual(rand, matrix[i, j]);
                    }
                }
            }
        }

        [TestMethod]
        public void DiagonalDouble()
        {
            int y = 500;
            int x = 600;
            for (int p = 0; p < 10; ++p)
            {
                double rand = random.NextDouble();
                var matrix = factory.Diagonal(x, y, rand);
                Assert.AreEqual(x, matrix.RowCount);
                Assert.AreEqual(y, matrix.ColumnCount);
                for (int i = 0; i < matrix.RowCount; ++i)
                {
                    for (int j = 0; j < matrix.ColumnCount; ++j)
                    {
                        Assert.AreEqual(i != j ? 0 : rand, matrix[i, j]);
                    }
                }
            }
        }
    }
}
