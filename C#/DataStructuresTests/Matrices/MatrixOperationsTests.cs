using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Matrices;

namespace DataStructuresTests.Matrices
{
    [TestClass]
    public class MatrixOperationsTests
    {
        [TestMethod]
        public void ArrayType()
        {
            var data = new double[2, 4]
            {
                {1, 1, 1, 1},
                {1, 1, 1, 1}
            };
            Matrix m = new Matrix(data);
            AreEqual(data, m);
        }

        public void AreEqual(double[,] data, Matrix m)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);
            for (int i = 0; i < rows; ++i)
                for (int k = 0; k < cols; ++k)
                    Assert.AreEqual(data[i, k], m[i, k], 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WrongAddition()
        {
            var data = new double[1, 1];
            var data2 = new double[3, 3];
            Matrix m = new Matrix(data);
            Matrix m2 = new Matrix(data2);
            var k = m + m2;
        }
        [TestMethod]
        public void Addition()
        {
            int rows = 2;
            int cols = 4;
            var data = new double[2, 4]
            {
                {3.22, 4.3, 5,21},
                {-9.9, 23, 73,123}
            };
            var data2 = new double[2, 4]
            {
                {1.12, 1.12, 1.1, 0.1},
                {111.1, 1.12, 1, 0.991}
            };
            var data3 = new double[2, 4];

            for (int i = 0; i < rows; ++i)
                for (int k = 0; k < cols; ++k)
                    data3[i, k] = data[i, k] + data2[i, k];
            Matrix m = new Matrix(data);
            Matrix m2 = new Matrix(data2);
            var m3 = m2 + m;

            Assert.AreEqual(4, m.Cols);
            Assert.AreEqual(2, m.Rows);
            Assert.AreEqual(4, m2.Cols);
            Assert.AreEqual(2, m2.Rows);
            Assert.AreEqual(4, m3.Cols);
            Assert.AreEqual(2, m3.Rows);
            AreEqual(data3, m3);
        }
        [TestMethod]
        public void Substraction()
        {
            int rows = 2;
            int cols = 4;
            var data = new double[2, 4]
            {
                {3.22, 4.3, 5,21},
                {-9.9, 23, 73,123}
            };
            var data2 = new double[2, 4]
            {
                {1.12, 1.12, 1.1, 0.1},
                {111.1, 1.12, 1, 0.991}
            };
            var data3 = new double[2, 4];

            for (int i = 0; i < rows; ++i)
                for (int k = 0; k < cols; ++k)
                    data3[i, k] = data[i, k] - data2[i, k];
            Matrix m = new Matrix(data);
            Matrix m2 = new Matrix(data2);
            var m3 = m - m2;

            Assert.AreEqual(4, m.Cols);
            Assert.AreEqual(2, m.Rows);
            Assert.AreEqual(4, m2.Cols);
            Assert.AreEqual(2, m2.Rows);
            Assert.AreEqual(4, m3.Cols);
            Assert.AreEqual(2, m3.Rows);
            AreEqual(data3, m3);
        }

        [TestMethod]
        public void Multiplication()
        {
            var data = new double[,]
            {
                {5, 4, 3},
                {2, 5, 7}
            };
            var data2 = new double[,]
            {
                {5, 2, 5},
                {9, 7, 1},
                {3, 3, 2}
            };
            var data3 = new double[,]
            {
                {70, 47, 35},
                {76, 60, 29}
            };
            Matrix m = new Matrix(data);
            var m2 = new Matrix(data2);
            var m3 = m * m2;
            Assert.AreEqual(3, m3.Cols);
            Assert.AreEqual(2, m3.Rows);
            AreEqual(data3, m3);
        }
    }
}
