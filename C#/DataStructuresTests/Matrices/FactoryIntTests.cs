namespace DataStructuresTests.Matrices
{
    using System;
    using DataStructures.Matrices;
    using DataStructures.Matrices.Integers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class FactoryTests
    {
        private readonly MatrixFactory IntFactory = new MatrixFactory();

        private void AreEqual(Matrix<int> matrix, int[,] arr)
        {
            for (var i = 0; i < matrix.RowCount; ++i)
                for (var j = 0; j < matrix.ColumnCount; ++j)
                {
                    Assert.AreEqual(arr[i, j], matrix[i, j]);
                }
        }

        private void AreEqual(Matrix<int> matrix, MatrixContainer container)
        {
            for (var i = 0; i < matrix.RowCount; ++i)
                for (var j = 0; j < matrix.ColumnCount; ++j)
                {
                    Assert.AreEqual(container[i, j], matrix[i, j]);
                }
        }

        [TestMethod]
        public void EmptyInt()
        {
            var x = 10;
            var y = 7;
            var matrix = this.IntFactory.Empty(x, y);
            Assert.AreEqual(x, matrix.RowCount);
            Assert.AreEqual(y, matrix.ColumnCount);
            for (var i = 0; i < x; ++i)
                for (var j = 0; j < y; ++j)
                {
                    Assert.AreEqual(0.0, matrix[i, j]);
                }
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void EmptyBadInt()
        {
            var matrix = this.IntFactory.Empty(-2, 3);
        }

        [TestMethod]
        public void IdentityInt()
        {
            var x = 15;
            var matrix = this.IntFactory.Identity(x);
            Assert.AreEqual(x, matrix.RowCount);
            Assert.AreEqual(x, matrix.ColumnCount);
            for (var i = 0; i < x; ++i)
                for (var j = 0; j < x; ++j)
                {
                    Assert.AreEqual(i == j ? 1.0 : 0.0, matrix[i, j]);
                }
            x = 1;
            matrix = this.IntFactory.Identity(x);
            Assert.AreEqual(x, matrix.RowCount);
            Assert.AreEqual(x, matrix.ColumnCount);
            for (var i = 0; i < x; ++i)
                for (var j = 0; j < x; ++j)
                {
                    Assert.AreEqual(i == j ? 1.0 : 0.0, matrix[i, j]);
                }
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void IdentityBadInt()
        {
            var matrix = this.IntFactory.Identity(-1);
        }

        [TestMethod]
        public void FromContainerInt()
        {
            var y = 500;
            var x = 600;
            var container = new MatrixContainer(x, y);
            for (var i = 0; i < x; ++i)
            {
                for (var j = 0; j < y; ++j)
                {
                    container[i, j] = random.Next();
                }
            }
            var matrix = this.IntFactory.Create(container);
            Assert.AreNotSame(matrix.Container, container);
            AreEqual(matrix, container);
            container[0, 0] = container[0, 0] - 10;
            Assert.AreNotEqual(container[0, 0], matrix[0, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void NullContainerInt()
        {
            var matrix = this.IntFactory.Create((MatrixContainer) null);
        }

        [TestMethod]
        public void FromArrayInt()
        {
            var y = 500;
            var x = 600;
            var arr = new int[x, y];
            for (var i = 0; i < x; ++i)
                for (var j = 0; j < y; ++j)
                    arr[i, j] = random.Next();
            var m = this.IntFactory.Create(arr);
            Assert.AreEqual(x, m.RowCount);
            Assert.AreEqual(y, m.ColumnCount);
            AreEqual(m, arr);
            arr[0, 0] = arr[0, 0] - 10;
            Assert.AreNotEqual(arr[0, 0], m[0, 0]);
        }

        [TestMethod]
        public void FilledInt()
        {
            var y = 500;
            var x = 600;
            for (var p = 0; p < 10; ++p)
            {
                var rand = random.Next();
                var matrix = this.IntFactory.Filled(x, y, rand);
                Assert.AreEqual(x, matrix.RowCount);
                Assert.AreEqual(y, matrix.ColumnCount);
                for (var i = 0; i < matrix.RowCount; ++i)
                {
                    for (var j = 0; j < matrix.ColumnCount; ++j)
                    {
                        Assert.AreEqual(rand, matrix[i, j]);
                    }
                }
            }
        }

        [TestMethod]
        public void DiagonalInt()
        {
            var y = 500;
            var x = 600;
            for (var p = 0; p < 10; ++p)
            {
                var rand = random.Next();
                var matrix = this.IntFactory.Diagonal(x, y, rand);
                Assert.AreEqual(x, matrix.RowCount);
                Assert.AreEqual(y, matrix.ColumnCount);
                for (var i = 0; i < matrix.RowCount; ++i)
                {
                    for (var j = 0; j < matrix.ColumnCount; ++j)
                    {
                        Assert.AreEqual(i != j ? 0 : rand, matrix[i, j]);
                    }
                }
            }
        }
    }
}