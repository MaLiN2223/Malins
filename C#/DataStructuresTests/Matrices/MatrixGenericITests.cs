using System;
using DataStructures.Matrices.Generics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.Matrices
{
    [TestClass]
    public class MatrixGenericITests
    {
        public void AreEqual(int[,] data, Matrix<int> m)
        {
            int RowCount = data.GetLength(0);
            int ColumnCount = data.GetLength(1);
            for (int i = 0; i < RowCount; ++i)
                for (int k = 0; k < ColumnCount; ++k)
                    Assert.AreEqual(data[i, k], m[i, k], 0);
        }
        [TestMethod]
        public void TestMethod1()
        {
            var data = new int[,]
            {
                {1, -9, 2, 1},
                {1, 3, 1, 9}
            };
            Matrix<int> m = Factory<int>.Create(data);
            Assert.AreEqual(2, m.RowCount);
            Assert.AreEqual(4, m.ColumnCount);
            AreEqual(data, m);
        }
        [TestMethod]
        public void ColumnRowTest()
        {
            var data = new int[,]
            {
                {1, -9, 2, 1},
                {1, -9, 2, 1},
                {1, -9, 2, 1},
            };
            var matrix = Factory<int>.Create(data);
            Assert.AreEqual(4, matrix.ColumnCount);
            Assert.AreEqual(3, matrix.RowCount);
            data = new int[,]
             {
                {1, -9, 2, 1}
             };
            matrix = Factory<int>.Create(data);
            Assert.AreEqual(4, matrix.ColumnCount);
            Assert.AreEqual(1, matrix.RowCount);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WrongAddition()
        {
            var data = new int[1, 1];
            var data2 = new int[3, 3];
            var m = Factory<int>.Create(data);
            var m2 = Factory<int>.Create(data2);
            var k = m + m2;
        }
        [TestMethod]
        public void Addition()
        {
            int RowCount = 2;
            int ColumnCount = 4;
            var data = new int[2, 4]
            {
                {3, 4, 5,21},
                {-9, 23, 73,123}
            };
            var data2 = new int[2, 4]
            {
                {1, 1, 1, 0},
                {111, 1, 1, 0}
            };
            var data3 = new int[2, 4];

            for (int i = 0; i < RowCount; ++i)
                for (int k = 0; k < ColumnCount; ++k)
                    data3[i, k] = data[i, k] + data2[i, k];
            var m = Factory<int>.Create(data);
            var m2 = Factory<int>.Create(data2);
            var m3 = m2 + m;

            Assert.AreEqual(4, m.ColumnCount);
            Assert.AreEqual(2, m.RowCount);
            Assert.AreEqual(4, m2.ColumnCount);
            Assert.AreEqual(2, m2.RowCount);
            Assert.AreEqual(4, m3.ColumnCount);
            Assert.AreEqual(2, m3.RowCount);
            AreEqual(data3, m3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WrongSubstraction()
        {
            var data = new int[1, 1];
            var data2 = new int[3, 3];
            var m = Factory<int>.Create(data);
            var m2 = Factory<int>.Create(data2);
            var k = m - m2;

        }
        [TestMethod]
        public void Substraction()
        {
            int RowCount = 2;
            int ColumnCount = 4;
            var data = new int[2, 4]
            {
                {2, 4, 5,21},
                {-9, 23, 73,123}
            };
            var data2 = new int[2, 4]
            {
                {1, 1, 1, 01},
                {111, 1, 1, 0}
            };
            var data3 = new int[2, 4];

            for (int i = 0; i < RowCount; ++i)
                for (int k = 0; k < ColumnCount; ++k)
                    data3[i, k] = data[i, k] - data2[i, k];
            var m = Factory<int>.Create(data);
            var m2 = Factory<int>.Create(data2);
            var m3 = m - m2;

            Assert.AreEqual(4, m.ColumnCount);
            Assert.AreEqual(2, m.RowCount);
            Assert.AreEqual(4, m2.ColumnCount);
            Assert.AreEqual(2, m2.RowCount);
            Assert.AreEqual(4, m3.ColumnCount);
            Assert.AreEqual(2, m3.RowCount);
            AreEqual(data3, m3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WrongMultiplication()
        {
            var data = new int[1, 1];
            var data2 = new int[3, 3];
            var m = Factory<int>.Create(data);
            var m2 = Factory<int>.Create(data2);
            var k = m * m2;
        }
        [TestMethod]
        public void Multiplication()
        {
            var data = new int[,]
            {
                {5, 4, 3},
                {2, 5, 7}
            };
            var data2 = new int[,]
            {
                {5, 2, 5},
                {9, 7, 1},
                {3, 3, 2}
            };
            var data3 = new int[,]
            {
                {70, 47, 35},
                {76, 60, 29}
            };
            var m = Factory<int>.Create(data);
            var m2 = Factory<int>.Create(data2);
            var m3 = m * m2;
            Assert.AreEqual(3, m3.ColumnCount);
            Assert.AreEqual(2, m3.RowCount);
            AreEqual(data3, m3);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WrongDeterminant()
        {
            var data = new int[1, 3]
            {
                {1, 3, 3}
            };
            var m = Factory<int>.Create(data);
            m.Determinant();
        }
        [TestMethod]
        public void Determinant()
        {
            var data = new int[2, 2]
            {
                {2, 3},
                {-9, 2}
            };
            var m = Factory<int>.Create(data);
            Assert.AreEqual(2 * 2 - (-9 * 3), m.Determinant());
            var data2 = new int[4, 4]
            {
                {1,2,3,4},
                {5,6,7,8},
                {9,10,11,12},
                {13,14,15,16}
            };
            var m2 = Factory<int>.Create(data2);
            Assert.AreEqual(0, m2.Determinant(), Math.Pow(10, -25));
            var data3 = new int[4, 4]
           {
                {8,-9,44,4},
                {3,7,2,94 },
                {-98,-7,1,4 },
                {-7,0,7,7 }
           };
            var m3 = Factory<int>.Create(data3);
            Assert.AreEqual(-624897, m3.Determinant());
            var data4 = new int[,]
            {
                {2, 0, 2, 6},
                {3, 3, 4, -2},
                {5, 5, 4, 2},
                {-1, -2, 4, -1}
            };
            var m4 = Factory<int>.Create(data4);
            Assert.AreEqual(-120, m4.Determinant());
        }


        [TestMethod]
        public void Negation()
        {
            var data = new[,]
            {
                {5, 5, 4, 2},
                {0, -2, 0.4, -0.2},
                {0, 0, 4, -0.5},
                {0, 0, 0, -3}
            };
            var matrix = Factory<double>.CreateCopy(data);
            matrix.Negate();
            var m2 = -matrix;
            for (int i = 0; i < 4; ++i)
            {
                for (int k = 0; k < 4; ++k)
                {
                    Assert.AreEqual(-data[i, k], matrix[i, k]);
                }
            }
            Assert.AreNotSame(m2, matrix);
            for (int i = 0; i < 4; ++i)
            {
                for (int k = 0; k < 4; ++k)
                {
                    Assert.AreEqual(m2[i, k], -matrix[i, k]);
                }
            }
        }

        [TestMethod]
        public void Dividing()
        {
            var data = new[,]
            {
                {6, 6, 8, 2},
                {0, -2, 4, -2},
                {0, 98, 4, -50},
                {0, 12, 0, -15}
            };
            //TODO: dzielenie przez skalar
        }
    }
}
