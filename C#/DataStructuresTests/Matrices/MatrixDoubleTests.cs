using System;
using DataStructures.Matrices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Matrices.Double;

namespace DataStructuresTests.Matrices
{
    [TestClass]
    public class MatrixDoubleTests
    {
        private MatrixFactory DoubleFactory = new MatrixFactory();
        [TestMethod]
        public void ArrayType()
        {
            var data = new double[,]
            {
                {1, -9.1, 2, 1},
                {1, 3, 1, 9.001}
            };
            Matrix m = (Matrix)DoubleFactory.Create(data);
            Assert.AreEqual(2, m.RowCount);
            Assert.AreEqual(4, m.ColumnCount);
            AreEqual(data, m);
        }

        [TestMethod]
        public void ColumnRowTest()
        {
            var data = new double[,]
            {
                {1, -9.1, 2, 1},
                {1, -9.1, 2, 1},
                {1, -9.1, 2, 1},
            };
            var matrix = DoubleFactory.Create(data);
            Assert.AreEqual(4, matrix.ColumnCount);
            Assert.AreEqual(3, matrix.RowCount);
            data = new double[,]
             {
                {1, -9.1, 2, 1}
             };
            matrix = DoubleFactory.Create(data);
            Assert.AreEqual(4, matrix.ColumnCount);
            Assert.AreEqual(1, matrix.RowCount);
        }

        public void AreEqual(double[,] data, Matrix<double> m)
        {
            int RowCount = data.GetLength(0);
            int ColumnCount = data.GetLength(1);
            for (int i = 0; i < RowCount; ++i)
                for (int k = 0; k < ColumnCount; ++k)
                    Assert.AreEqual(data[i, k], m[i, k], 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WrongAddition()
        {
            var data = new double[1, 1];
            var data2 = new double[3, 3];
            var m = DoubleFactory.Create(data);
            var m2 = DoubleFactory.Create(data2);
            var k = m + m2;
        }
        [TestMethod]
        public void Addition()
        {
            int RowCount = 2;
            int ColumnCount = 4;
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

            for (int i = 0; i < RowCount; ++i)
                for (int k = 0; k < ColumnCount; ++k)
                    data3[i, k] = data[i, k] + data2[i, k];
            var m = DoubleFactory.Create(data);
            var m2 = DoubleFactory.Create(data2);
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
            var data = new double[1, 1];
            var data2 = new double[3, 3];
            var m = DoubleFactory.Create(data);
            var m2 = DoubleFactory.Create(data2);
            var k = m - m2;

        }
        [TestMethod]
        public void Substraction()
        {
            int RowCount = 2;
            int ColumnCount = 4;
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

            for (int i = 0; i < RowCount; ++i)
                for (int k = 0; k < ColumnCount; ++k)
                    data3[i, k] = data[i, k] - data2[i, k];
            var m = DoubleFactory.Create(data);
            var m2 = DoubleFactory.Create(data2);
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
            var data = new double[1, 1];
            var data2 = new double[3, 3];
            var m = DoubleFactory.Create(data);
            var m2 = DoubleFactory.Create(data2);
            var k = m * m2;
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
            var m = DoubleFactory.Create(data);
            var m2 = DoubleFactory.Create(data2);
            var m3 = m * m2;
            Assert.AreEqual(3, m3.ColumnCount);
            Assert.AreEqual(2, m3.RowCount);
            AreEqual(data3, m3);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WrongDeterminant()
        {
            var data = new double[1, 3]
            {
                {1, 3, 3}
            };
            var m = DoubleFactory.Create(data);
            m.Determinant();
        }
        [TestMethod]
        public void Determinant()
        {
            var data = new double[2, 2]
            {
                {2, 3},
                {-9, 2}
            };
            var m = DoubleFactory.Create(data);
            Assert.AreEqual(2 * 2 - (-9 * 3), m.Determinant());
            var data2 = new double[4, 4]
            {
                {1,2,3,4},
                {5,6,7,8},
                {9,10,11,12},
                {13,14,15,16}
            };
            var m2 = DoubleFactory.Create(data2);
            Assert.AreEqual(0, m2.Determinant(), Math.Pow(10, -25));
            var data3 = new double[4, 4]
           {
                {8,-9,44,4},
                {3,7,2,94 },
                {-98,-7,1,4 },
                {-7,0,7,7 }
           };
            var m3 = DoubleFactory.Create(data3);
            Assert.AreEqual(-624897, m3.Determinant());
            var data4 = new double[,]
            {
                {2, 0, 2, 0.6},
                {3, 3, 4, -2},
                {5, 5, 4, 2},
                {-1, -2, 3.4, -1}
            };
            var m4 = DoubleFactory.Create(data4);
            Assert.AreEqual(-120, m4.Determinant());
        }

        [TestMethod]
        public void Decompose()
        {
            var data = new[,]
              {
                {2, 0, 2, 0.6},
                {3, 3, 4, -2},
                {5, 5, 4, 2},
                {-1, -2, 3.4, -1}
              };
            var dataL = new[,]
            {
                {1,0,0,0 },
                {0.4,1,0,0 },
                {-0.2,0.5,1,0 },
                {0.6,0,0.4,1 }
            };
            var dataU = new[,]
            {
             {5,    5,  4,      2},
             {0,    -2, 0.4,    -0.2},
             {0,    0,  4,      -0.5},
             {0,    0,  0,      -3 }
            };
            var m = DoubleFactory.Create(data);
            var L = DoubleFactory.Create(dataL);
            var U = DoubleFactory.Create(dataU);
            var dec = m.DecomposeWithSign();
            var U2 = dec.Item2.ForceRound(4);
            Assert.AreEqual(dec.Item4, -1);
            Assert.IsTrue(dec.Item1.Equals(L));
            Assert.IsTrue(U2.Equals(U));
        }

        [TestMethod]
        public void Clonning()
        {
            var data = new[,]
            {
             {5,    5,  4,      2},
             {0,    -2, 0.4,    -0.2},
             {0,    0,  4,      -0.5},
             {0,    0,  0,      -3 }
            };
            var m1 = DoubleFactory.Create(data);
            var m2 = (Matrix)m1.Clone();
            Assert.AreNotSame(m1, m2);
            Assert.AreNotSame(m1.Container, m2.Container);
            Assert.AreEqual(m1.ColumnCount, m2.ColumnCount);
            Assert.AreEqual(m1.RowCount, m2.RowCount);
            Assert.AreEqual(m1.IsReadOnly, m2.IsReadOnly);
            for (int i = 0; i < m1.RowCount; ++i)
                for (int k = 0; k < m1.ColumnCount; ++k)
                {
                    Assert.AreEqual(m1[i, k], m2[i, k]);
                }
            m2[0, 0] = m1[0, 0] - 1;
            Assert.AreNotEqual(m2[0, 0], m1[0, 0]);
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
            var matrix = DoubleFactory.Create(data);
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
            //TODO: 
        }

        [TestMethod]
        public void SubMatrix()
        {
            var data = new double[,]
            {
                {3, 2, 5, 7, 8, 9},
                {2, 0, 3, 5, 3, 2},
                {5, 2, 9, 0, -10, -1},
                {3, 9, 2, 9, 9, 0},
                {7, -5, 7, 5, 3, 4}
            };
            var data2 = new double[,]
            {
                {3, 2},
                {2, 0},
            };
            var data3 = new double[,]
            {
                { 0, 3, 5},
                { 2, 9, 0},
                { 9, 2, 9},
                { -5, 7, 5}
        };
            var matrix = DoubleFactory.Create(data);
            var sub = matrix.SubMatrix(0, 1, 0, 1);
            Assert.AreEqual(2, sub.ColumnCount);
            Assert.AreEqual(2, sub.RowCount);
            AreEqual(data2, sub);
            sub = matrix.SubMatrix(1, 4, 1, 3);
            Assert.AreEqual(3, sub.ColumnCount);
            Assert.AreEqual(4, sub.RowCount);
            AreEqual(data3, sub);

        }
    }
}
