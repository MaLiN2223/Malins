using System;
using System.Runtime.Serialization;

namespace DataStructures.Matrices.Integers
{
    [Serializable]
    public sealed class MatrixContainer : MatrixContainer<int>, ISerializable
    {
        private int[,] _data;
        public MatrixContainer(int rowCount, int columnCount) : base(rowCount, columnCount)
        {
            _data = new int[rowCount, columnCount];
        }

        internal MatrixContainer(int[,] data) : base(data.Length / data.GetLength(1), data.GetLength(1))
        {
            _data = (int[,])data.Clone();
        }
        public override bool IsReadOnly { get { return false; } }
        public override int Get(int row, int column)
        {
            return _data[row, column];
        }

        public override void Set(int row, int column, int value)
        {
            _data[row, column] = value;
        }

        public override object Clone()
        {
            return new MatrixContainer((int[,])_data.Clone());
        }
        protected MatrixContainer(SerializationInfo info, StreamingContext context) : base(info.GetInt32("RowCount"), info.GetInt32("ColumnCount"))
        {
            _data = (int[,])info.GetValue("_data", typeof(int[,]));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ColumnCount", ColumnCount);
            info.AddValue("RowCount", RowCount);
            info.AddValue("_data", _data);

        }
    }
}
