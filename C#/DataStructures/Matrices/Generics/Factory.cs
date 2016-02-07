namespace DataStructures.Matrices.Generics
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

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
        /// Creates matrix by copy.
        /// WARNING : CLONES every element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix<T> Clone<T>(Matrix<T> matrix)
        {
            if (typeof(T).IsClass) //is class
            {
                if (!typeof(T).IsSerializable)
                {
                    throw new NotSupportedException("Object must be serializable to clone");
                }
                if (ReferenceEquals(matrix, null))
                {
                    throw new ArgumentNullException(nameof(matrix), "Matrixt must not be null");
                } 
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new MemoryStream();
                using (stream)
                {
                    formatter.Serialize(stream, matrix);
                    stream.Seek(0, SeekOrigin.Begin);
                    return (Matrix<T>)formatter.Deserialize(stream);
                }
            }
            throw new NotImplementedException();
        }
        /// <summary>
        /// Creates empty array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rows">Array row count</param>
        /// <param name="columns">Array column count</param>
        /// <returns></returns>
        public static Matrix<T> Create<T>(int rows, int columns)
        {
            GoodRange(rows, columns);
            return new Matrix<T>(new MatrixContainer<T>(rows, columns));
        }
        /// <summary>
        /// Creates matrix by coping data from array.
        /// WARNING : DO copy items from array to matrix
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Matrix<T> CreateCopy<T>(T[,] data) => Create((T[,])data.Clone());

        public static Matrix<T> Diagonal<T>(int rows, int columns, T data)
        {
            GoodRange(rows, columns);
            int min = Math.Min(rows, columns);
            var matrix = Create<T>(rows, columns);
            for (int i = 0; i < rows; ++i)
            {
                if (i <= min)
                    matrix[i, i] = Matrix<T>.MultiplyNeutral;
                for (int j = 0; j < columns; ++j)
                {
                    if (j != i)
                        matrix[i, j] = Matrix<T>.SumNeutral;
                }
            }
            return matrix;
        }

        public static Matrix<T> Identity<T>(int rows, int columns)
        {
            GoodRange(rows, columns);
            if (Matrix<T>.MultiplyNeutral == null)
                throw new NotSupportedException();
            return Diagonal(rows, columns, Matrix<T>.MultiplyNeutral);
        }

        public static Matrix<T> Filled<T>(int rows, int cols, T data)
        {
            GoodRange(rows, cols);
            T[] arr = new T[rows * cols];
            for (int i = 0; i < rows * cols; ++i)
                arr[i] = data;
            var container = new MatrixContainer<T>(rows, cols, arr);
            return new Matrix<T>(container);
        }

        public static Matrix<T> Empty<T>(int rows, int cols)
        {
            GoodRange(rows, cols);
            return new Matrix<T>(new MatrixContainer<T>(rows, cols));
        }
        private static void GoodRange(int rows, int columns)
        {
            if (rows <= 0) throw new ArgumentOutOfRangeException(nameof(rows));
            if (columns <= 0) throw new ArgumentOutOfRangeException(nameof(columns));
        }
    }
}
