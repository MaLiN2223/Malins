namespace DataStructures.Matrices.Generics
{
    using System;
    /// <summary>
    /// Factory for creating arrays
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Creates matrix by putting array into matrix.
        /// WARNING : DO NOT copy items from array to matrix
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Matrix<T> Create<T>(T[,] data)
        {
            if (data == null)
                throw new ArgumentNullException();
            return new Matrix<T>(new MatrixContainer<T>(data));
        }
        /// <summary>
        /// Creates empty array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rowCount">Array row count</param>
        /// <param name="columnCount">Array column count</param>
        /// <returns></returns>
        public static Matrix<T> Create<T>(int rowCount, int columnCount)
        {
            return new Matrix<T>(new MatrixContainer<T>(rowCount, columnCount));
        }
        /// <summary>
        /// Creates matrix by coping data from array.
        /// WARNING : DO copy items from array to matrix
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Matrix<T> CreateCopy<T>(T[,] data) => Create((T[,])data.Clone());

        public static Matrix<T> Diagonal<T>(int rowCount, int columnCount, T data)
        {
            var matrix = Create<T>(rowCount, columnCount);
            int size = Math.Min(rowCount, columnCount);
            for (int i = 0; i < columnCount; ++i)
            {
                matrix[i, i] = data;
                for (int j = 0; j < rowCount; ++j)
                {
                    if (j != i)
                        matrix[i, j] = Matrix<T>.SumNeutral;
                }
            }
            return matrix;
        }

        public static Matrix<T> Identity<T>(int rowCount, int columnCount)
        {
            if (Matrix<T>.MultiplyNeutral == null)
                throw new NotSupportedException();
            return Diagonal(rowCount, columnCount, Matrix<T>.MultiplyNeutral);
        }
    }
}
