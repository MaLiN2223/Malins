namespace DataStructures.Matrices.Double
{
    using System;

    public class Matrix : Matrix<double>
    {
        private readonly MatrixContainer _data;

        /// <summary>
        ///     Constructor - creates empty matrix
        /// </summary>
        internal Matrix(MatrixContainer container) : base(container)
        {
            this._data = (MatrixContainer) container.Clone();
        }

        /// <summary>
        ///     Constructor - generates matrix from array
        /// </summary>
        /// <param name="data">array to generate matrix from</param>
        internal Matrix(double[,] data) : base((MatrixContainer) data)
        {
            this._data = (MatrixContainer) data;
        }


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
            return new Matrix((MatrixContainer) this._data.Clone());
        }

        private bool Equals(Matrix other)
        {
            if (other.RowCount != this.RowCount || other.ColumnCount != this.ColumnCount)
                return false;
            for (var i = 0; i < this.RowCount; ++i)
                for (var k = 0; k < this.ColumnCount; ++k)
                    if (Math.Abs(this[i, k] - other[i, k]) > 0)
                    {
                        return false;
                    }
            return true;
        }

        public override Matrix<double> Add(Matrix<double> second)
        {
            var first = new MatrixFactory().Create(this);
            if (first == null || second == null)
                throw new NullReferenceException("Matrix must not be null");
            if (first.ColumnCount != second.ColumnCount || first.RowCount != second.RowCount)
                throw new ArgumentException("Matrices must have good dimensions");
            var array = new double[first.RowCount, first.ColumnCount];
            for (var i = 0; i < first.RowCount; ++i)
                for (var k = 0; k < first.ColumnCount; ++k)
                    array[i, k] = first[i, k] + second[i, k];
            return new Matrix(array);
        }

        public override Matrix<double> Multiply(Matrix<double> second)
        {
            var first = new MatrixFactory().Create(this);
            if (first == null || second == null)
                throw new NullReferenceException("Matrix must not be null");
            if (first.ColumnCount != second.RowCount)
                throw new ArgumentException("Matrices must have good dimensions");
            var mOut = new MatrixFactory().Empty(first.RowCount, second.ColumnCount);
            for (var i = 0; i < mOut.RowCount; i++)
            {
                for (var j = 0; j < mOut.ColumnCount; j++)
                {
                    mOut[i, j] = 0;
                    for (var k = 0; k < second.RowCount; k++)
                    {
                        mOut[i, j] += first[i, k]*second[k, j];
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
            var first = new MatrixFactory().Create(this);
            if (first == null || second == null)
                throw new NullReferenceException("Matrix must not be null");
            if (first.ColumnCount != second.ColumnCount || first.RowCount != second.RowCount)
                throw new ArgumentException("Matrices must have the same dimension ");
            var array = new double[first.RowCount, first.ColumnCount];
            for (var i = 0; i < first.RowCount; ++i)
                for (var k = 0; k < first.ColumnCount; ++k)
                    array[i, k] = first[i, k] - second[i, k];
            return new Matrix(array);
        }

        /// <summary>
        ///     Adds column source to target multiplied by scalar
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        /// <param name="scalar"></param>
        public override void SumColumn(int target, int source, double scalar)
        {
            for (var i = 0; i < this.RowCount; ++i)
                this[i, target] += this[i, source]*scalar;
        }

        /// <summary>
        ///     Adds row source to target multiplied by scalar
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        /// <param name="scalar"></param>
        public override void SumRow(int target, int source, double scalar)
        {
            for (var i = 0; i < this.ColumnCount; ++i)
                this[target, i] += this[source, i]*scalar;
        }

        public override void MultiplyRow(int target, double scalar)
        {
            for (var i = 0; i < this.ColumnCount; ++i)
                this[target, i] *= scalar;
        }

        public override void MultiplyColumn(int target, double scalar)
        {
            for (var i = 0; i < this.ColumnCount; ++i)
                this[i, target] *= scalar;
        }

        private Tuple<double, int> BiggestNonZeroInColumn(int column, int start, int end)
        {
            double min = 0;
            var minI = 0;
            for (var i = start; i <= end; ++i)
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
            var min = double.MaxValue;
            var minI = 0;
            for (var i = start; i <= end; ++i)
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
            for (var i = 0; i < m.RowCount; ++i)
                for (var k = 0; k < m.ColumnCount; ++k)
                {
                    m[i, k] /= d;
                }
            return m;
        }

        public override double Determinant()
        {
            var dec = DecomposeWithSign();
            var L = dec.Item1;
            var U = dec.Item2;
            double counter = 1;
            for (var i = 0; i < this.RowCount; ++i)
            {
                counter *= U[i, i];
            }

            return counter*dec.Item4;
        }

        public override Matrix<double> ForceZeros(double epsylon)
        {
            for (var i = 0; i < this.ColumnCount; ++i)
                for (var j = 0; j < this.RowCount; ++j)
                {
                    if (this[i, j] <= epsylon)
                        this[i, j] = 0;
                }
            return this;
        }

        public override Matrix<double> Negate()
        {
            for (var i = 0; i < this.RowCount; ++i)
                for (var k = 0; k < this.ColumnCount; ++k)
                {
                    this._data[i, k] = -this._data[i, k];
                }
            return this;
        }

        public override Matrix<double> ForceRound(int precision)
        {
            for (var i = 0; i < this.ColumnCount; ++i)
                for (var j = 0; j < this.RowCount; ++j)
                {
                    this[i, j] = Math.Round(this[i, j], precision, MidpointRounding.ToEven);
                }
            return this;
        }

        public override Tuple<Matrix<double>, Matrix<double>, Matrix<double>, int> DecomposeWithSign()
        {
            if (!IsSquare)
                throw new InvalidOperationException("Matrix must be square");
            var sing = true;
            var tmp = new Matrix(this._data);
            var pi = new int[tmp.RowCount];

            for (var i = 0; i < tmp.RowCount; ++i)
                pi[i] = i;

            for (var i = 0; i < this.ColumnCount - 1; ++i)
            {
                var pair = BiggestNonZeroInColumn(i, i, this.ColumnCount - 1);
                if (Math.Abs(pair.Item1) <= 0)
                    throw new ArithmeticException("Matrix is singular");
                if (pair.Item2 != i)
                {
                    tmp.SwapRow(pair.Item2, i);
                    sing = !sing;
                    var sw = pi[i];
                    pi[i] = pi[pair.Item2];
                    pi[pair.Item2] = sw;
                }

                tmp[i, i] = this._data[i, i];
                var row = 0;
                for (var k = i + 1; k < this.RowCount; ++k)
                {
                    tmp[k, i] = tmp[k, i]/tmp[i, i];
                    var col = 0;
                    for (var j = i + 1; j < this.ColumnCount; ++j)
                    {
                        tmp[k, j] -= tmp[k, i]*tmp[i, j];
                        col++;
                    }
                    row++;
                }
            }
            var factory = new MatrixFactory();
            var L = (Matrix) factory.Empty(this.RowCount, this.ColumnCount);
            var U = (Matrix) factory.Empty(this.RowCount, this.ColumnCount);
            var P = (Matrix) factory.Empty(this.RowCount, this.ColumnCount);
            for (var i = 0; i < this.RowCount; ++i)
            {
                for (var j = 0; j < this.ColumnCount; ++j)
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
            if (rowEnd < rowStart || rowEnd < 0 || rowStart < 0 || colStart < 0 || colEnd < 0 || colEnd < colStart ||
                rowEnd >= this.RowCount || colEnd >= this.ColumnCount)
                throw new IndexOutOfRangeException($"Invalid range{rowStart},{rowEnd},{colStart},{colEnd}");
            var data = new double[rowEnd - rowStart + 1, colEnd - colStart + 1];
            int row = 0, col;
            for (var i = rowStart; i <= rowEnd; ++i)
            {
                col = 0;
                for (var k = colStart; k <= colEnd; ++k)
                {
                    data[row, col] = this._data[i, k];
                    col++;
                }
                row++;
            }
            return new Matrix(data);
        }

        #region inherited

        #endregion
    }
}