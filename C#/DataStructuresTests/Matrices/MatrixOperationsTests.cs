using DataStructures.Matrices;
using DataStructures.Matrices.Double;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests.Matrices
{
    [TestClass]
    public class MatrixOperationsTests
    {
        MatrixFactory factory = new MatrixFactory();
        [TestMethod]
        public void IsSmith()
        {

            double[,] data = 
            {
                {1, 0, 0},
                {0, 2, 0},
                {0, 0, 0}
            };
            Matrix<double> m = factory.Create(data);
            Assert.IsTrue(m.IsSmithForm(2));
            data = new double[,]
            {
                {10, 0, 0},
                {0, 20, 0},
                {0, 0, 0}
            };
            m = (Matrix)factory.Create(data);
            Assert.IsTrue(m.IsSmithForm(2));
            data = new double[,]
            {
                {10, 0, 1},
                {0, 20, 0},
                {0, 0, 0}
            };
            m = (Matrix)factory.Create(data);
            Assert.IsFalse(m.IsSmithForm(2));
        }

        [TestMethod]
        public void ToSmith()
        {
            
        }
    }
}
