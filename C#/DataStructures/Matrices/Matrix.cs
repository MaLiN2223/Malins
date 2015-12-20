using System;
namespace DataStructures.Matrices
{
    /// <summary>
    /// Represents matrix
    /// </summary>
    public class Matrix
    {
        private readonly double[,] _data;
        /// <summary>
        /// Acces to Matrix
        /// </summary>
        /// <param name="a">row number</param>
        /// <param name="b">column number</param>
        /// <returns></returns>
        public double this[int a, int b]
        {
            get { return _data[a, b]; }
            set { _data[a, b] = value; }
        }
        /// <summary>
        /// Number of cols
        /// </summary>
        public int Cols { get; private set; }
        /// <summary>
        /// Number of rows
        /// </summary>
        public int Rows { get; private set; }
        /// <summary>
        /// Constructor - creates empty matrix
        /// </summary>
        /// <param name="rows">number of rows</param>
        /// <param name="cols">number of columns</param>
        public Matrix(int rows, int cols)
        {
            _data = new double[rows, cols];
            Rows = rows;
            Cols = cols;

        }
        /// <summary>
        /// Constructor - generates matrix from array
        /// </summary>
        /// <param name="data">array to generate matrix from</param>
        public Matrix(double[,] data)
        {
            Rows = data.GetLength(0);
            Cols = data.GetLength(1);
            _data = data;

        }
        /// <summary>
        /// Sum of two matrices
        /// </summary>
        /// <param name="first">first matrix</param>
        /// <param name="second">second matrix</param>
        /// <returns></returns>
        public static Matrix operator +(Matrix first, Matrix second)
        {
            if (first == null || second == null)
                throw new NullReferenceException("Matrix must not be null");
            if (first.Cols != second.Cols || first.Rows != second.Rows)
                throw new ArgumentException("Matrices must have good dimensions");
            var array = new double[first.Rows, first.Cols];
            for (int i = 0; i < first.Rows; ++i)
                for (int k = 0; k < first.Cols; ++k)
                    array[i, k] = first[i, k] + second[i, k];
            return new Matrix(array);
        }

        /// <summary>
        /// Substraction of two matrices
        /// </summary>
        /// <param name="first">first matrix</param>
        /// <param name="second">second matrix</param>
        /// <returns></returns>
        public static Matrix operator -(Matrix first, Matrix second)
        {
            if (first == null || second == null)
                throw new NullReferenceException("Matrix must not be null");
            if (first.Cols != second.Cols || first.Rows != second.Rows)
                throw new ArgumentException("Matrices must have the same dimension ");
            var array = new double[first.Rows, first.Cols];
            for (int i = 0; i < first.Rows; ++i)
                for (int k = 0; k < first.Cols; ++k)
                    array[i, k] = first[i, k] - second[i, k];
            return new Matrix(array);
        }

        /// <summary>
        /// Multiplication of two matrices
        /// </summary>
        /// <param name="first">first matrix</param>
        /// <param name="second">second matrix</param>
        /// <returns></returns>
        public static Matrix operator *(Matrix first, Matrix second)
        {
            if (first == null || second == null)
                throw new NullReferenceException("Matrix must not be null");
            if (first.Cols != second.Rows)
                throw new ArgumentException("Matrices must have good dimensions");
            var mOut = new Matrix(first.Rows, first.Cols);
            for (int i = 0; i < mOut.Rows; i++)
            {
                for (int j = 0; j < mOut.Cols; j++)
                {
                    mOut[i, j] = 0;
                    for (int k = 0; k < first.Cols; k++)
                    {
                        mOut[i, j] += first[i, k] * second[k, j];
                    }
                }
            }
            return mOut;
        }
        /// <summary>
        /// Converter to array
        /// </summary>
        /// <param name="m">matrix to convert</param>
        public static explicit operator double[,] (Matrix m)
        {
            return m._data;
        }

        public void ColumnSum(int target, int source, double scalar)
        {
            GoodRange(target, source);
            for (int i = 0; i < Rows; ++i)
                this[i, target] += this[i, source] * scalar;
        }
        public void RowSum(int target, int source, double scalar)
        {
            GoodRange(target, source);
            for (int i = 0; i < Cols; ++i)
                this[target, i] += this[source, i] * scalar;
        }

        public void RowMultiply(int target, double scalar)
        {
            GoodRange(target);
            for (int i = 0; i < Cols; ++i)
                this[target, i] *= scalar;
        }

        public void ColumntMultiply(int target, double scalar)
        {
            GoodRange(target);
            for (int i = 0; i < Cols; ++i)
                this[i, target] *= scalar;
        }

        public void RowSwap(int first, int second)
        {
            GoodRange(first);
            GoodRange(second);
            double[] tmp = new double[Cols];
            for (int i = 0; i < Cols; ++i)
            {
                tmp[i] = this[first, i];
                this[first, i] = this[second, i];
                this[second, i] = tmp[i];
            }
        }

        public void ColumnSwap(int first, int second)
        {
            GoodRange(0, first);
            GoodRange(0, second);
            double[] tmp = new double[Cols];
            for (int i = 0; i < Rows; ++i)
            {
                tmp[i] = this[i, first];
                this[i, first] = this[i, second];
                this[i, second] = tmp[i];
            }
        }
        private void GoodRange(int target, int source = 0)
        {
            if (target < 0 || source < 0)
                throw new ArgumentException("Range must be non-negative");
            if (target >= Rows || source >= Rows)
                throw new AccessViolationException("Range is too big");
        }
        /// <summary>
        /// Searches (absolute) smallest and non zero element in row
        /// </summary> 
        /// <param name="row"></param>
        /// <returns>Pair (minimum value, position)</returns>
        public Tuple<double, int> SmallestNonZeroRow(int row)
        {
            GoodRange(row);
            double min = double.MaxValue;
            int minI = 0;
            for (int i = 0; i < Cols; ++i)
            {
                var item = Math.Abs(this[row, i]);
                if (item > 0 && item < min)
                {
                    min = this[row, i];
                    minI = i;
                }
            }
            return new Tuple<double, int>(min, minI);
        }
    }
}
