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
                {1, -9.1, 2, 1},
                {1, 3, 1, 9.001}
            };
            Matrix m = new Matrix(data);
            AreEqual(data, m);
        }
        [TestMethod]
        public void AnotherMatrixConstruction()
        {
            int height = 3;
            int width = 3;
            var data = new double[3, 3]
            {
                {1, -9.1, 2},
                {1, 3, 1},
                {9.991,-99.1,11 }
            };
            var matrix = new Matrix(3, 3);
            for (int i = 0; i < height; ++i)
            {
                for (int k = 0; k < width; ++k)
                    matrix[i, k] = data[i, k];
            }
            AreEqual(data, matrix);
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

        [TestMethod]
        public void Determinant()
        {
            var data = new double[2, 2]
            {
                {2, 3},
                {-9, 2}
            };
            Matrix m = new Matrix(data);
            Assert.AreEqual(2 * 2 - (-9 * 3), m.Det);
            var data2 = new double[4, 4]
            {
                {1,2,3,4},
                {5,6,7,8},
                {9,10,11,12},
                {13,14,15,16}
            };
            Matrix m2 = new Matrix(data2, Math.Pow(10, -25));
            Assert.AreEqual(0, m2.Det, Math.Pow(10, -25));
            Assert.IsFalse(m2.IsReversible);
            var data3 = new double[4, 4]
           {
                {8,-9,44,4},
                {3,7,2,94 },
                {-98,-7,1,4 },
                {-7,0,7,7 }
           };
            Matrix m3 = new Matrix(data3);
            Assert.AreEqual(-624897, m3.Det);
            var data4 = new double[,]
            {
                {2, 0, 2, 0.6},
                {3, 3, 4, -2},
                {5, 5, 4, 2},
                {-1, -2, 3.4, -1}
            };
            Matrix m4 = new Matrix(data4);
            Assert.AreEqual(-120, m4.Determinant());
        }

        [TestMethod]
        public void Decompose()
        {
            var data = new double[,]
              {
                {2, 0, 2, 0.6},
                {3, 3, 4, -2},
                {5, 5, 4, 2},
                {-1, -2, 3.4, -1}
              };
            var dataL = new double[,]
            {
                {1,0,0,0 },
                {0.4,1,0,0 },
                {-0.2,0.5,1,0 },
                {0.6,0,0.4,1 }
            };
            var dataU = new double[,]
            {
             {   5,5,4,2 },
             {0,-2,0.4,-0.2 },
             {0,0,4,-0.5 },
             {0,0,0,-3 }
            };
            Matrix m = new Matrix(data);
            Matrix L = new Matrix(dataL);
            Matrix U = new Matrix(dataU,Math.Pow(10,-10));
            var dec = m.DecomposeWithSign();
            Assert.AreEqual(dec.Item4, -1);
            Assert.IsTrue(dec.Item1.Equals(L));
            Assert.IsTrue(dec.Item2.Equals(U));
        }


    }
}
