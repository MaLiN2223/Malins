using System;

namespace DataStructures.Matrices
{
    public abstract class Matrix<T> : IEquatable<Matrix<T>>, ICloneable where T : struct, IEquatable<T>
    {
        public readonly int RowCount;
        public readonly int ColumnCount;
        public MatrixContainer<T> Container { get; set; }
        public bool IsReadOnly { get { return Container.IsReadOnly; } }
        public bool IsSquare
        {
            get { return ColumnCount == RowCount; }
        }
        public T this[int row, int column]
        {
            get { return Container[row, column]; }
            set { Container[row, column] = value; }
        }
        protected Matrix(MatrixContainer<T> container)
        {
            RowCount = container.RowCount;
            ColumnCount = container.ColumnCount;
            Container = container;
        }
        #region fromInterface
        public abstract bool Equals(Matrix<T> other);
        public abstract object Clone();
        #endregion
        #region Calculation Methods
        public abstract T Determinant();
        public abstract bool IsEmpty();
        public abstract Tuple<Matrix<T>, Matrix<T>, Matrix<T>, int> DecomposeWithSign();
        #endregion
        #region utilities
        public abstract Matrix<T> ForceZeros(T epsylon);
        public abstract Matrix<T> Negate();
        public abstract Matrix<T> ForceRound(int precision);
        public abstract void MultiplyRow(int target, T scalar);
        public abstract void MultiplyColumn(int target, T scalar);
        public abstract void SumColumn(int target, int source, T scalar);
        public abstract void SumRow(int target, int source, T scalar);
        public abstract Matrix<T> SubMatrix(int rowStart, int rowEnd, int colStart, int colEnd);
        #region implemented
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
        #endregion
        #endregion
        #region Operator helpers
        public abstract Matrix<T> Add(Matrix<T> another);
        public abstract Matrix<T> Multiply(Matrix<T> another);
        public abstract Matrix<T> Multiply(T scalar);
        public abstract Matrix<T> Substract(Matrix<T> another);
        public abstract Matrix<T> Divide(T d);
        #endregion



        #region Operators
        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.ColumnCount != second.ColumnCount || first.RowCount != second.RowCount)
                throw new ArgumentException();
            return first.Add(second);
        }
        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.ColumnCount != second.ColumnCount || first.RowCount != second.RowCount)
                throw new ArgumentException();
            return first.Substract(second);
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.ColumnCount != second.RowCount)
                throw new ArgumentException();
            return first.Multiply(second);
        }

        public static Matrix<T> operator -(Matrix<T> matrix)
        {
            var k = (Matrix<T>)matrix.Clone();
            k.Negate();
            return k;
        }

        public static Matrix<T> operator /(Matrix<T> m, T d)
        {
            return m.Divide(d);
        }

        public static Matrix<T> operator *(Matrix<T> matrix, T d)
        {
            return matrix.Multiply(d);
        }
        #endregion
    }
}
