namespace DataStructuresTests.Matrices
{
    using System;
    using DataStructures.Matrices;
    using DataStructures.Matrices.Double;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public partial class FactoryTests
    {
        private static readonly MatrixFactory factory = new MatrixFactory();
        private static readonly Random random = new Random();

        private void AreEqual(Matrix<double> matrix, double[,] arr)
        {
            for (var i = 0; i < matrix.RowCount; ++i)
                for (var j = 0; j < matrix.ColumnCount; ++j)
                {
                    Assert.AreEqual(arr[i, j], matrix[i, j]);
                }
        }

        private void AreEqual(Matrix<double> matrix, MatrixContainer container)
        {
            for (var i = 0; i < matrix.RowCount; ++i)
                for (var j = 0; j < matrix.ColumnCount; ++j)
                {
                    Assert.AreEqual(container[i, j], matrix[i, j]);
                }
        }

        [TestMethod]
        public void EmptyDouble()
        {
            var x = 10;
            var y = 7;
            var matrix = factory.Empty(x, y);
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
        public void EmptyBadDouble()
        {
            var matrix = factory.Empty(-2, 3);
        }

        [TestMethod]
        public void IdentityDouble()
        {
            var x = 15;
            var matrix = factory.Identity(x);
            Assert.AreEqual(x, matrix.RowCount);
            Assert.AreEqual(x, matrix.ColumnCount);
            for (var i = 0; i < x; ++i)
                for (var j = 0; j < x; ++j)
                {
                    Assert.AreEqual(i == j ? 1.0 : 0.0, matrix[i, j]);
                }
            x = 1;
            matrix = factory.Identity(x);
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
        public void IdentityBadDouble()
        {
            var matrix = factory.Identity(-1);
        }

        [TestMethod]
        public void FromContainerDouble()
        {
            var y = 500;
            var x = 600;
            var container = new MatrixContainer(x, y);
            for (var i = 0; i < x; ++i)
            {
                for (var j = 0; j < y; ++j)
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
        [ExpectedException(typeof (ArgumentNullException))]
        public void NullContainerDouble()
        {
            var matrix = factory.Create((MatrixContainer) null);
        }

        [TestMethod]
        public void FromArrayDouble()
        {
            var y = 500;
            var x = 600;
            var arr = new double[x, y];
            for (var i = 0; i < x; ++i)
                for (var j = 0; j < y; ++j)
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
            var y = 500;
            var x = 600;
            for (var p = 0; p < 10; ++p)
            {
                var rand = random.NextDouble();
                var matrix = factory.Filled(x, y, rand);
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
        public void DiagonalDouble()
        {
            var y = 500;
            var x = 600;
            for (var p = 0; p < 10; ++p)
            {
                var rand = random.NextDouble();
                var matrix = factory.Diagonal(x, y, rand);
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