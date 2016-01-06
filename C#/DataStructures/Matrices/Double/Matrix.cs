using System;

namespace DataStructures.Matrices.Double
{
    public class Matrix : Matrix<double>
    {
        private MatrixContainer _data;

        #region inherited



        #endregion





        public override bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(Matrix<double> other)
        {
            var m = other as Matrix;
            return m != null && Equals(m);
        }

        public override object Clone()
        {
            return new Matrix((MatrixContainer)_data.Clone());
        }

        private bool Equals(Matrix other)
        {
            if (other.RowCount != RowCount || other.ColumnCount != ColumnCount)
                return false;
            for (int i = 0; i < RowCount; ++i)
                for (int k = 0; k < ColumnCount; ++k)
                    if (Math.Abs(this[i, k] - other[i, k]) > 0)
                    {
                        return false;
                    }
            return true;
        }
        /// <summary>
        /// Constructor - creates empty matrix
        /// </summary> 
        internal Matrix(MatrixContainer container) : base(container)
        {
            _data = (MatrixContainer)container.Clone();

        }
        /// <summary>
        /// Constructor - generates matrix from array
        /// </summary>
        /// <param name="data">array to generate matrix from</param>
        internal Matrix(double[,] data) : base((MatrixContainer)data)
        {
            _data = (MatrixContainer)data;

        }

        public override Matrix<double> Add(Matrix<double> second)
        {
            Matrix<double> first = new MatrixFactory().Create(this);
            if (first == null || second == null)
                throw new NullReferenceException("Matrix must not be null");
            if (first.ColumnCount != second.ColumnCount || first.RowCount != second.RowCount)
                throw new ArgumentException("Matrices must have good dimensions");
            var array = new double[first.RowCount, first.ColumnCount];
            for (int i = 0; i < first.RowCount; ++i)
                for (int k = 0; k < first.ColumnCount; ++k)
                    array[i, k] = first[i, k] + second[i, k];
            return new Matrix(array);
        }

        public override Matrix<double> Multiply(Matrix<double> second)
        {
            Matrix<double> first = new MatrixFactory().Create(this);
            if (first == null || second == null)
                throw new NullReferenceException("Matrix must not be null");
            if (first.ColumnCount != second.RowCount)
                throw new ArgumentException("Matrices must have good dimensions");
            var mOut = new MatrixFactory().Empty(first.RowCount, second.ColumnCount);
            for (int i = 0; i < mOut.RowCount; i++)
            {
                for (int j = 0; j < mOut.ColumnCount; j++)
                {
                    mOut[i, j] = 0;
                    for (int k = 0; k < second.RowCount; k++)
                    {
                        mOut[i, j] += first[i, k] * second[k, j];
                    }
                }
            }

            return mOut as Matrix;
        }

        public override Matrix<double> Multiply(double scalar)
        {
            throw new NotImplementedException();
        }

        public override Matrix<double> Substract(Matrix<double> second)
        {
            Matrix<double> first = new MatrixFactory().Create(this);
            if (first == null || second == null)
                throw new NullReferenceException("Matrix must not be null");
            if (first.ColumnCount != second.ColumnCount || first.RowCount != second.RowCount)
                throw new ArgumentException("Matrices must have the same dimension ");
            var array = new double[first.RowCount, first.ColumnCount];
            for (int i = 0; i < first.RowCount; ++i)
                for (int k = 0; k < first.ColumnCount; ++k)
                    array[i, k] = first[i, k] - second[i, k];
            return new Matrix(array);
        }
        /// <summary>
        /// Adds column source to target multiplied by scalar
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        /// <param name="scalar"></param>
        public override void SumColumn(int target, int source, double scalar)
        {
            for (int i = 0; i < RowCount; ++i)
                this[i, target] += this[i, source] * scalar;
        }
        /// <summary>
        /// Adds row source to target multiplied by scalar
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        /// <param name="scalar"></param>
        public override void SumRow(int target, int source, double scalar)
        {
            for (int i = 0; i < ColumnCount; ++i)
                this[target, i] += this[source, i] * scalar;
        }
        public override void MultiplyRow(int target, double scalar)
        {
            for (int i = 0; i < ColumnCount; ++i)
                this[target, i] *= scalar;
        }
        public override void MultiplyColumn(int target, double scalar)
        {
            for (int i = 0; i < ColumnCount; ++i)
                this[i, target] *= scalar;
        }
        private Tuple<double, int> BiggestNonZeroInColumn(int column, int start, int end)
        {
            double min = 0;
            int minI = 0;
            for (int i = start; i <= end; ++i)
            {
                var item = Math.Abs(this[i, column]);
                if (item > 0 && item > min)
                {
                    min = item;
                    minI = i;
                }
            }
            return new Tuple<double, int>(min, minI);
        }
        private Tuple<double, int> SmallestNonZeroInRow(int row, int start, int end)
        {
            double min = double.MaxValue;
            int minI = 0;
            for (int i = start; i <= end; ++i)
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
        public override Matrix<double> Divide(double d)
        {
            var m = new MatrixFactory().Create(this);
            for (int i = 0; i < m.RowCount; ++i)
                for (int k = 0; k < m.ColumnCount; ++k)
                {
                    m[i, k] /= d;
                }
            return m;
        }
        public override double Determinant()
        {
            var dec = DecomposeWithSign();
            Matrix<double> L = dec.Item1;
            Matrix<double> U = dec.Item2;
            double counter = 1;
            for (int i = 0; i < RowCount; ++i)
            {
                counter *= U[i, i];
            }

            return counter * dec.Item4;
        }

        public override Matrix<double> ForceZeros(double epsylon)
        {
            for (int i = 0; i < ColumnCount; ++i)
                for (int j = 0; j < RowCount; ++j)
                {
                    if (this[i, j] <= epsylon)
                        this[i, j] = 0;
                }
            return this;
        }

        public override Matrix<double> Negate()
        {
            for (int i = 0; i < RowCount; ++i)
                for (int k = 0; k < ColumnCount; ++k)
                {
                    _data[i, k] = -_data[i, k];
                }
            return this;
        }

        public override Matrix<double> ForceRound(int precision)
        {
            for (int i = 0; i < ColumnCount; ++i)
                for (int j = 0; j < RowCount; ++j)
                {
                    this[i, j] = Math.Round(this[i, j], precision, MidpointRounding.ToEven);
                }
            return this;
        }

        public override Tuple<Matrix<double>, Matrix<double>, Matrix<double>, int> DecomposeWithSign()
        {
            if (!IsSquare)
                throw new InvalidOperationException("Matrix must be square");
            bool sing = true;
            var tmp = new Matrix(_data);
            int[] pi = new int[tmp.RowCount];

            for (int i = 0; i < tmp.RowCount; ++i)
                pi[i] = i;

            for (int i = 0; i < ColumnCount - 1; ++i)
            {
                var pair = BiggestNonZeroInColumn(i, i, ColumnCount - 1);
                if (Math.Abs(pair.Item1) <= 0)
                    throw new ArithmeticException("Matrix is singular");
                if (pair.Item2 != i)
                {
                    tmp.SwapRow(pair.Item2, i);
                    sing = !sing;
                    int sw = pi[i];
                    pi[i] = pi[pair.Item2];
                    pi[pair.Item2] = sw;
                }

                tmp[i, i] = _data[i, i];
                int row = 0;
                for (int k = i + 1; k < RowCount; ++k)
                {
                    tmp[k, i] = tmp[k, i] / tmp[i, i];
                    int col = 0;
                    for (int j = i + 1; j < ColumnCount; ++j)
                    {
                        tmp[k, j] -= tmp[k, i] * tmp[i, j];
                        col++;
                    }
                    row++;
                }
            }
            var factory = new MatrixFactory();
            Matrix L = (Matrix)factory.Empty(RowCount, ColumnCount);
            Matrix U = (Matrix)factory.Empty(RowCount, ColumnCount);
            Matrix P = (Matrix)factory.Empty(RowCount, ColumnCount);
            for (int i = 0; i < RowCount; ++i)
            {
                for (int j = 0; j < ColumnCount; ++j)
                {
                    if (i > j)
                        L[i, j] = tmp[i, j];
                    else
                        U[i, j] = tmp[i, j];
                    if (i == j)
                        L[i, i] = 1;
                }
                P[i, pi[i]] = 1;
            }
            return new Tuple<Matrix<double>, Matrix<double>, Matrix<double>, int>(L, U, P, sing ? 1 : -1);
        }
        public override Matrix<double> SubMatrix(int rowStart, int rowEnd, int colStart, int colEnd)
        {
            if (rowEnd < rowStart || rowEnd < 0 || rowStart < 0 || colStart < 0 || colEnd < 0 || colEnd < colStart || rowEnd >= RowCount || colEnd >= ColumnCount)
                throw new IndexOutOfRangeException($"Invalid range{rowStart},{rowEnd},{colStart},{colEnd}");
            var data = new double[rowEnd - rowStart + 1, colEnd - colStart + 1];
            int row = 0, col;
            for (int i = rowStart; i <= rowEnd; ++i)
            {
                col = 0;
                for (int k = colStart; k <= colEnd; ++k)
                {
                    data[row, col] = _data[i, k];
                    col++;
                }
                row++;
            }
            return new Matrix(data);
        }
    }
}
