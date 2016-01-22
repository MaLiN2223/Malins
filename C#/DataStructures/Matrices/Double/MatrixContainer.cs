namespace DataStructures.Matrices.Double
{
    public class MatrixContainer : MatrixContainer<double>
    {
        private double[,] _data;

        public MatrixContainer(int rowCount, int columnCount) : base(rowCount, columnCount)
        {
            this._data = new double[rowCount, columnCount];
        }

        private MatrixContainer(double[,] data) : base(data.Length/data.GetLength(1), data.GetLength(1))
        {
            this._data = data;
        }

        public override bool IsReadOnly => false;

        public override double Get(int row, int column)
        {
            return this._data[row, column];
        }

        public override void Set(int row, int column, double value)
        {
            this._data[row, column] = value;
        }

        public override object Clone()
        {
            return new MatrixContainer((double[,]) this._data.Clone());
        }

        public static explicit operator MatrixContainer(double[,] data)
        {
            var k = new MatrixContainer(data.Length/data.GetLength(1), data.GetLength(1)) {_data = data};
            return k;
        }
    }
}