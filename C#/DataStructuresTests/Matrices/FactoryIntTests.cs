using DataStructures.Matrices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataStructures.Matrices.Integers;

namespace DataStructuresTests.Matrices
{
    public partial class FactoryTests
    {
        private MatrixFactory IntFactory = new MatrixFactory();
        private void AreEqual(Matrix<int> matrix, int[,] arr)
        {
            for (int i = 0; i < matrix.RowCount; ++i)
                for (int j = 0; j < matrix.ColumnCount; ++j)
                {
                    Assert.AreEqual(arr[i, j], matrix[i, j]);
                }
        }

        private void AreEqual(Matrix<int> matrix, MatrixContainer container)
        {
            for (int i = 0; i < matrix.RowCount; ++i)
                for (int j = 0; j < matrix.ColumnCount; ++j)
                {
                    Assert.AreEqual(container[i, j], matrix[i, j]);
                }
        }
        [TestMethod]
        public void EmptyInt()
        {
            int x = 10;
            int y = 7;
            var matrix = IntFactory.Empty(x, y);
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
        public void EmptyBadInt()
        {
            var matrix = IntFactory.Empty(-2, 3);
        }

        [TestMethod]
        public void IdentityInt()
        {
            int x = 15;
            var matrix = IntFactory.Identity(x);
            Assert.AreEqual(x, matrix.RowCount);
            Assert.AreEqual(x, matrix.ColumnCount);
            for (int i = 0; i < x; ++i)
                for (int j = 0; j < x; ++j)
                {
                    Assert.AreEqual(i == j ? 1.0 : 0.0, matrix[i, j]);
                }
            x = 1;
            matrix = IntFactory.Identity(x);
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
        public void IdentityBadInt()
        {
            var matrix = IntFactory.Identity(-1);
        }

        [TestMethod]
        public void FromContainerInt()
        {
            int y = 500;
            int x = 600;
            MatrixContainer container = new MatrixContainer(x, y);
            for (int i = 0; i < x; ++i)
            {
                for (int j = 0; j < y; ++j)
                {
                    container[i, j] = random.Next();
                }
            }
            var matrix = IntFactory.Create(container);
            Assert.AreNotSame(matrix.Container, container);
            AreEqual(matrix, container);
            container[0, 0] = container[0, 0] - 10;
            Assert.AreNotEqual(container[0, 0], matrix[0, 0]);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullContainerInt()
        {
            var matrix = IntFactory.Create((MatrixContainer)null);
        }

        [TestMethod]
        public void FromArrayInt()
        {
            int y = 500;
            int x = 600;
            int[,] arr = new int[x, y];
            for (int i = 0; i < x; ++i)
                for (int j = 0; j < y; ++j)
                    arr[i, j] = random.Next();
            var m = IntFactory.Create(arr);
            Assert.AreEqual(x, m.RowCount);
            Assert.AreEqual(y, m.ColumnCount);
            AreEqual(m, arr);
            arr[0, 0] = arr[0, 0] - 10;
            Assert.AreNotEqual(arr[0, 0], m[0, 0]);
        }

        [TestMethod]
        public void FilledInt()
        {
            int y = 500;
            int x = 600;
            for (int p = 0; p < 10; ++p)
            {
                int rand = random.Next();
                var matrix = IntFactory.Filled(x, y, rand);
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
        public void DiagonalInt()
        {
            int y = 500;
            int x = 600;
            for (int p = 0; p < 10; ++p)
            {
                int rand = random.Next();
                var matrix = IntFactory.Diagonal(x, y, rand);
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
