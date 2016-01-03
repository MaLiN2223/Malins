using System;

namespace DataStructures.Matrices
{
    public abstract class MatrixContainer<T> where T : struct, IEquatable<T>
    {
        public readonly int RowCount;
        public readonly int ColumnCount;

        protected MatrixContainer(int rowCount, int columnCount)
        {
            if (rowCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(rowCount));
            if (columnCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(columnCount));
            RowCount = rowCount;
            ColumnCount = columnCount;
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
            if (row >= RowCount)
                throw new ArgumentOutOfRangeException(nameof(row));
            if (column >= ColumnCount)
                throw new ArgumentOutOfRangeException(nameof(column));
        }
        public void Clear()
        {
            for (int i = 0; i < ColumnCount; ++i)
            {
                for (int j = 0; j < RowCount; ++j)
                    this[i, j] = default(T);
            }
        }
    }
}
