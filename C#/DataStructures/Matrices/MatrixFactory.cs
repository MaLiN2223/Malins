using System;

namespace DataStructures.Matrices
{
    public abstract class MatrixFactory<T> where T : struct, IEquatable<T>
    {
        public abstract T One { get; }
        public abstract T RandomData();
        protected static Random random = new Random();

        public abstract Matrix<T> Create(MatrixContainer<T> containter);
        public abstract Matrix<T> Create(T[,] data);

        public Matrix<T> Create(Matrix<T> matrix)
        {
            return (Matrix<T>)matrix.Clone();
        }

        public Matrix<T> Filled(int rows, int columns, T data)
        {
            GoodRange(rows, columns);
            var output = Empty(rows, columns);
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    output[i, j] = data;
                }
            }
            return output;
        }

        public Matrix<T> Diagonal(int rows, int columns, T data)
        {
            GoodRange(rows, columns);
            var item = Empty(rows, columns);
            int tmp = Math.Min(rows, columns);

            for (int i = 0; i < tmp; ++i)
            {
                item[i, i] = data;
            }
            return item;
        }

        public Matrix<T> Diagonal(Matrix<T> matrix)
        {
            int rows = matrix.RowCount;
            int columns = matrix.ColumnCount;
            var output = Empty(rows, columns);
            int tmp = Math.Min(rows, columns);
            for (int i = 0; i < tmp; ++i)
                output[i, i] = matrix[i, i];
            return output;
        }

        public Matrix<T> Diagonal(MatrixContainer<T> containter)
        {
            int rows = containter.RowCount;
            int columns = containter.ColumnCount;
            var output = Empty(rows, columns);
            int tmp = Math.Min(rows, columns);
            for (int i = 0; i < tmp; ++i)
                output[i, i] = containter[i, i];
            return output;
        }

        public Matrix<T> Identity(int count)
        {
            GoodRange(count, count);
            var output = Diagonal(count, count, One);
            return output;
        }

        public Matrix<T> Empty(int rows, int columns)
        {
            GoodRange(rows, columns);
            return Create(new T[rows, columns]);
        }

        public Matrix<T> Random(int rows, int columns)
        {
            GoodRange(rows, columns);
            var matrix = Empty(rows, columns);
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    matrix[i, j] = RandomData();
                }
            }
            return matrix;
        }

        public Matrix<T> Random()
        {
            return Random(random.Next(1), random.Next(1));
        }

        private void GoodRange(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
                throw new ArgumentException();
        }

    }
}
