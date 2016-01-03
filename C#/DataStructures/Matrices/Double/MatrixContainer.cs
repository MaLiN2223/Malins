
namespace DataStructures.Matrices.Double
{
    public class MatrixContainer : MatrixContainer<double>
    {
        private double[,] _data;
        public MatrixContainer(int rowCount, int columnCount) : base(rowCount, columnCount)
        {
            _data = new double[rowCount, columnCount];
        }

        public override bool IsReadOnly => false;

        public override double Get(int row, int column)
        {
            return _data[row, column];
        }

        public override void Set(int row, int column, double value)
        {
            _data[row, column] = value;
        }

        public static explicit operator MatrixContainer(double[,] data)
        {  
            var k = new MatrixContainer(data.Length / data.GetLength(1), data.GetLength(1)) { _data = data };
            return k;
        }
    }
}
