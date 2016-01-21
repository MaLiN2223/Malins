using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DataStructures.Matrices.Generics
{
    public class MatrixContainer<T>
    {
        private T[,] data;
        public readonly int RowCount;
        public readonly int ColumnCount;

        public MatrixContainer(int rowCount, int columnCount)
        {
            if (rowCount < 0)
                throw new ArgumentException(nameof(rowCount));
            if (columnCount <= 0)
                throw new ArgumentException(nameof(columnCount));
            RowCount = rowCount;
            ColumnCount = columnCount;
            data = new T[rowCount, columnCount];
        }

        public MatrixContainer(T[,] data)
        {
            RowCount = data.Length / data.GetLength(1);
            ColumnCount = data.GetLength(1);
            this.data = data;

        }


        public T Get(int row, int column)
        {
            return data[row, column];
        }

        public void Set(int row, int column, T value)
        {
            data[row, column] = value;
        }

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
        public void GoodToWrite()
        {
            if (false)
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

    }
}
