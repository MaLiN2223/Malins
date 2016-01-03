using System;
using DataStructures.Exceptions;

namespace DataStructures.Matrices.Double
{
    public class MatrixFactory : MatrixFactory<double>
    {
        public override double Zero => 0.0;

        public override double One => 1.0;

        private MatrixContainer GetMatrixContainer(MatrixContainer<double> containter)
        {
            if (containter == null)
                throw new ArgumentNullException();
            var data = containter as MatrixContainer;
            if (data == null)
                throw new InvalidArgumentException(nameof(containter));
            return data;
        }
        private Matrix GetMatrixContainer(Matrix<double> containter)
        {
            if (containter == null)
                throw new ArgumentNullException();
            var data = containter as Matrix;
            if (data == null)
                throw new InvalidArgumentException(nameof(containter));
            return data;
        }
        public override Matrix<double> Create(MatrixContainer<double> containter)
        {
            return new Matrix(GetMatrixContainer(containter));
        }

        public override Matrix<double> Create(Matrix<double> matrix)
        {
            Matrix output = new Matrix((MatrixContainer)matrix.Container);
            return output;

        }

        public override Matrix<double> Empty(int rows, int columns)
        {
            return new Matrix(new MatrixContainer(rows, columns));
        }

        public override Matrix<double> Create(double[,] data)
        {
            return new Matrix(data);
        }

        public override Matrix<double> Filled(int rows, int columns, double data)
        {
            throw new NotImplementedException();
        }

        public override Matrix<double> Diagonal(int rows, int columns, double data)
        {
            var matrix = new Matrix(new double[rows, columns]);
            for (int i = 0; i < rows; ++i)
            {
                matrix[i, i] = data;
            }
            return matrix;
        }

        public override Matrix<double> Diagonal(Matrix<double> matrix)
        {
            throw new NotImplementedException();
        }

        public override Matrix<double> Diagonal(MatrixContainer<double> containter)
        {
            throw new NotImplementedException();
        }

        public override Matrix<double> Identity(int count)
        {
            return Diagonal(count, count, 1);
        }

        public override Matrix<double> Random(int rows, int columns)
        {
            throw new NotImplementedException();
        }
    }
}
