using System; 

namespace DataStructures.Matrices
{
    public abstract class MatrixFactory<T> where T : struct, IEquatable<T>
    {
        public abstract T Zero { get; }
        public abstract T One { get; }  

        public abstract Matrix<T> Create(MatrixContainer<T> containter);

        public abstract Matrix<T> Create(Matrix<T> matrix);
        public abstract Matrix<T> Empty(int rows, int columns);
        public abstract Matrix<T> Create(T[,] data);
        public abstract Matrix<T> Filled(int rows, int columns, T data);
        public abstract Matrix<T> Diagonal(int rows, int columns, T data);
        public abstract Matrix<T> Diagonal(Matrix<T> matrix);
        public abstract Matrix<T> Diagonal(MatrixContainer<T> containter);
        public abstract Matrix<T> Identity(int count);

        public Matrix<T> Clean(int rows, int columns)
        {
            return Filled(rows, columns, Zero);
        }

        public abstract Matrix<T> Random(int rows, int columns);


    }
}
