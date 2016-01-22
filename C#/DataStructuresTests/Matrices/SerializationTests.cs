namespace DataStructuresTests.Matrices
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using DataStructures.Matrices.Integers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SerializationTests
    {
        private readonly MatrixFactory factory = new MatrixFactory();

        [TestMethod]
        public void IntMatrix()
        {
            var data = new[,]
            {
                {1, 2, 3},
                {4, 4, 4}
            };
            var matrix = this.factory.Create(data);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Tmp.bin",
                FileMode.Create,
                FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, matrix);
            stream.Close();
            stream = new FileStream("Tmp.bin",
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read);
            var obj = (Matrix) formatter.Deserialize(stream);
            stream.Close();
            Assert.AreEqual(obj.ColumnCount, matrix.ColumnCount);
            Assert.AreEqual(obj.RowCount, matrix.RowCount);
            Assert.AreEqual(obj[0, 0], matrix[0, 0]);
            Assert.IsTrue(obj.Equals(matrix));
        }
    }
}