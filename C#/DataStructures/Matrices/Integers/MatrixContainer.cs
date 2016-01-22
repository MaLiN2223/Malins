namespace DataStructures.Matrices.Integers
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public sealed class MatrixContainer : MatrixContainer<int>, ISerializable
    {
        private readonly int[,] _data;

        public MatrixContainer(int rowCount, int columnCount) : base(rowCount, columnCount)
        {
            this._data = new int[rowCount, columnCount];
        }

        internal MatrixContainer(int[,] data) : base(data.Length/data.GetLength(1), data.GetLength(1))
        {
            this._data = (int[,]) data.Clone();
        }

        private MatrixContainer(SerializationInfo info, StreamingContext context)
            : base(info.GetInt32("RowCount"), info.GetInt32("ColumnCount"))
        {
            this._data = (int[,]) info.GetValue("_data", typeof (int[,]));
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ColumnCount", this.ColumnCount);
            info.AddValue("RowCount", this.RowCount);
            info.AddValue("_data", this._data);
        }

        public override int Get(int row, int column)
        {
            return this._data[row, column];
        }

        public override void Set(int row, int column, int value)
        {
            this._data[row, column] = value;
        }

        public override object Clone()
        {
            return new MatrixContainer((int[,]) this._data.Clone());
        }
    }
}