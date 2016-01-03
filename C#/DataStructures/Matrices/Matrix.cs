using System;

namespace DataStructures.Matrices
{
    public abstract class Matrix<T> : IEquatable<Matrix<T>> where T : struct, IEquatable<T>
    {
        public readonly int RowCount;
        public readonly int ColumnCount;
        public abstract T Determinant();
        public abstract Matrix<T> ForceZeros(T epsylon);
        public abstract Matrix<T> Negate();
        public abstract Matrix<T> ForceRound(int precision);
        public abstract Tuple<Matrix<T>, Matrix<T>, Matrix<T>, int> DecomposeWithSign();
        public MatrixContainer<T> Container { get; set; }
        public abstract Matrix<T> Add(Matrix<T> another);
        public abstract Matrix<T> Multiply(Matrix<T> another);
        public abstract Matrix<T> Substract(Matrix<T> another);
        public abstract Matrix<T> Divide(T d);

        /// <summary>
        /// Swaps rows
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public void SwapRow(int first, int second)
        {
            T[] tmp = new T[ColumnCount];
            for (int i = 0; i < ColumnCount; ++i)
            {
                tmp[i] = this[first, i];
                this[first, i] = this[second, i];
                this[second, i] = tmp[i];
            }
        }
        /// <summary>
        /// Swaps columns
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public void SwapColumn(int first, int second)
        {
            T[] tmp = new T[ColumnCount];
            for (int i = 0; i < RowCount; ++i)
            {
                tmp[i] = this[i, first];
                this[i, first] = this[i, second];
                this[i, second] = tmp[i];
            }
        }
        /// <summary>
        /// Multiplies row by scalar
        /// </summary>
        /// <param name="target"></param>
        /// <param name="scalar"></param>
        public abstract void MultiplyRow(int target, T scalar);
        /// <summary>
        /// Multiplies column by scalar
        /// </summary>
        /// <param name="target"></param>
        /// <param name="scalar"></param>
        public abstract void MultiplyColumn(int target, T scalar);
        public abstract void SumColumn(int target, int source, T scalar);
        public abstract void SumRow(int target, int source, T scalar);
        public abstract Tuple<T, int> BiggestNonZeroInColumn(int column, int start, int end);
        public abstract Tuple<double, int> SmallestNonZeroInRow(int row, int start, int end);
        public abstract bool IsSquare { get; }
        public abstract Matrix<T> SubMatrix(int rowStart, int rowEnd, int colStart, int colEnd);
        protected Matrix(MatrixContainer<T> container)
        {
            RowCount = container.RowCount;
            ColumnCount = container.ColumnCount;
            Container = container;
        }
        public T this[int row, int column]
        {
            get { return Container[row, column]; }
            set
            {
                Container[row, column] = value;
            }
        }
        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            return first.Add(second);
        }
        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            return first.Substract(second);
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            return first.Multiply(second);
        }

        public static Matrix<T> operator -(Matrix<T> matrix)
        {
            return matrix.Negate();
        }

        public static Matrix<T> operator /(Matrix<T> m, T d)
        {
            return m.Divide(d);
        }


        public abstract bool Equals(Matrix<T> other);
        public bool IsReadOnly { get { return Container.IsReadOnly; } }
    }
}
