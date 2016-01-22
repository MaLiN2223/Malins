namespace DataStructures.Matrices
{
    using System;

    public abstract class MatrixContainer<T> : ICloneable where T : struct, IEquatable<T>
    {
        public readonly int ColumnCount;
        public readonly int RowCount;

        protected MatrixContainer(int rowCount, int columnCount)
        {
            if (rowCount < 0)
                throw new ArgumentException(nameof(rowCount));
            if (columnCount <= 0)
                throw new ArgumentException(nameof(columnCount));
            this.RowCount = rowCount;
            this.ColumnCount = columnCount;
        }

        public abstract bool IsReadOnly { get; }

        public T this[int row, int column]
        {
            get
            {
                GoodRange(row, column);
                return Get(row, column);
            }
            set
            {
                GoodToWrite();
                GoodRange(row, column);
                Set(row, column, value);
            }
        }

        public abstract object Clone();

        public abstract T Get(int row, int column);
        public abstract void Set(int row, int column, T value);

        public void GoodToWrite()
        {
            if (IsReadOnly)
                throw new AccessViolationException("Matrix is read only");
        }

        private void GoodRange(int row, int column)
        {
            if (row < 0)
                throw new ArgumentOutOfRangeException(nameof(row), row, "Row must be non negative");
            if (column < 0)
                throw new ArgumentOutOfRangeException(nameof(column), column, "Column must be non negative");
            if (row >= this.RowCount)
                throw new ArgumentOutOfRangeException(nameof(row));
            if (column >= this.ColumnCount)
                throw new ArgumentOutOfRangeException(nameof(column));
        }

        public void Clear()
        {
            for (var i = 0; i < this.ColumnCount; ++i)
            {
                for (var j = 0; j < this.RowCount; ++j)
                    this[i, j] = default(T);
            }
        }
    }
}