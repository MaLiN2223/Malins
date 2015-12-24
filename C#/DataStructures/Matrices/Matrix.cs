using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace DataStructures.Matrices
{
    /// <summary>
    /// Represents matrix
    /// </summary>
    public class Matrix : IEquatable<Matrix>
    {
        public readonly double Epsylon = Math.Pow(10, -100);
        private readonly double[,] _data;
        /// <summary>
        /// Acces to Matrix
        /// </summary>
        /// <param name="a">row number</param>
        /// <param name="b">column number</param>
        /// <returns></returns>
        public double this[int a, int b]
        {
            get { return _data[a, b]; }
            set { _data[a, b] = value; }
        }
        /// <summary>
        /// Number of cols
        /// </summary>
        public int Cols { get; private set; }
        /// <summary>
        /// Number of rows
        /// </summary>
        public int Rows { get; private set; }
        /// <summary>
        /// Constructor - creates empty matrix
        /// </summary>
        /// <param name="rows">number of rows</param>
        /// <param name="cols">number of columns</param>
        public Matrix(int rows, int cols, double epsylon = -1)
        {
            if (epsylon > 0)
                Epsylon = epsylon;
            _data = new double[rows, cols];
            Rows = rows;
            Cols = cols;

        }
        /// <summary>
        /// Constructor - generates matrix from array
        /// </summary>
        /// <param name="data">array to generate matrix from</param>
        public Matrix(double[,] data, double epsylon = -1)
        {
            if (epsylon > 0)
                Epsylon = epsylon;
            Rows = data.GetLength(0);
            Cols = data.GetLength(1);
            _data = data;

        }
        /// <summary>
        /// Sum of two matrices
        /// </summary>
        /// <param name="first">first matrix</param>
        /// <param name="second">second matrix</param>
        /// <returns></returns>
        public static Matrix operator +(Matrix first, Matrix second)
        {
            if (first == null || second == null)
                throw new NullReferenceException("Matrix must not be null");
            if (first.Cols != second.Cols || first.Rows != second.Rows)
                throw new ArgumentException("Matrices must have good dimensions");
            var array = new double[first.Rows, first.Cols];
            for (int i = 0; i < first.Rows; ++i)
                for (int k = 0; k < first.Cols; ++k)
                    array[i, k] = first[i, k] + second[i, k];
            return new Matrix(array);
        }

        /// <summary>
        /// Substraction of two matrices
        /// </summary>
        /// <param name="first">first matrix</param>
        /// <param name="second">second matrix</param>
        /// <returns></returns>
        public static Matrix operator -(Matrix first, Matrix second)
        {
            if (first == null || second == null)
                throw new NullReferenceException("Matrix must not be null");
            if (first.Cols != second.Cols || first.Rows != second.Rows)
                throw new ArgumentException("Matrices must have the same dimension ");
            var array = new double[first.Rows, first.Cols];
            for (int i = 0; i < first.Rows; ++i)
                for (int k = 0; k < first.Cols; ++k)
                    array[i, k] = first[i, k] - second[i, k];
            return new Matrix(array);
        }

        /// <summary>
        /// Multiplication of two matrices
        /// </summary>
        /// <param name="first">first matrix</param>
        /// <param name="second">second matrix</param>
        /// <returns></returns>
        public static Matrix operator *(Matrix first, Matrix second)
        {
            if (first == null || second == null)
                throw new NullReferenceException("Matrix must not be null");
            if (first.Cols != second.Rows)
                throw new ArgumentException("Matrices must have good dimensions");
            var mOut = new Matrix(first.Rows, second.Cols);
            for (int i = 0; i < mOut.Rows; i++)
            {
                for (int j = 0; j < mOut.Cols; j++)
                {
                    mOut[i, j] = 0;
                    for (int k = 0; k < second.Rows; k++)
                    {
                        mOut[i, j] += first[i, k] * second[k, j];
                    }
                }
            }

            return mOut;
        }
        /// <summary>
        /// Converter to array
        /// </summary>
        /// <param name="m">matrix to convert</param>
        public static explicit operator double[,] (Matrix m)
        {
            return m._data;
        }
        /// <summary>
        /// Adds column source to target multiplied by scalar
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        /// <param name="scalar"></param>
        public void ColumnSum(int target, int source, double scalar)
        {
            GoodRange(target, source);
            for (int i = 0; i < Rows; ++i)
                this[i, target] += this[i, source] * scalar;
        }/// <summary>
         /// Adds row source to target multiplied by scalar
         /// </summary>
         /// <param name="target"></param>
         /// <param name="source"></param>
         /// <param name="scalar"></param>
        public void RowSum(int target, int source, double scalar)
        {
            GoodRange(target, source);
            for (int i = 0; i < Cols; ++i)
                this[target, i] += this[source, i] * scalar;
        }
        /// <summary>
        /// Multiplies row by scalar
        /// </summary>
        /// <param name="target"></param>
        /// <param name="scalar"></param>
        public void RowMultiply(int target, double scalar)
        {
            GoodRange(target);
            for (int i = 0; i < Cols; ++i)
                this[target, i] *= scalar;
        }

        /// <summary>
        /// Multiplies column by scalar
        /// </summary>
        /// <param name="target"></param>
        /// <param name="scalar"></param>
        public void ColumnMultiply(int target, double scalar)
        {
            GoodRange(target);
            for (int i = 0; i < Cols; ++i)
                this[i, target] *= scalar;
        }
        /// <summary>
        /// Swaps rows
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        public void RowSwap(int first, int second)
        {
            GoodRange(first);
            GoodRange(second);
            double[] tmp = new double[Cols];
            for (int i = 0; i < Cols; ++i)
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
        public void ColumnSwap(int first, int second)
        {
            GoodRange(0, first);
            GoodRange(0, second);
            double[] tmp = new double[Cols];
            for (int i = 0; i < Rows; ++i)
            {
                tmp[i] = this[i, first];
                this[i, first] = this[i, second];
                this[i, second] = tmp[i];
            }
        }
        private void GoodRange(int row, int column = 0)
        {
            if (row < 0 || row >= Rows)
                throw new ArgumentOutOfRangeException(nameof(row));
            if (column >= Cols || column < 0)
                throw new ArgumentOutOfRangeException(nameof(column));

        }

        public Tuple<double, int> Biggest(int column, int start, int end)
        {
            GoodRange(0, column);
            double min = 0;
            int minI = 0;
            for (int i = start; i <= end; ++i)
            {
                var item = Math.Abs(this[i, column]);
                if (item > 0 && item > min)
                {
                    min = item;
                    minI = i;
                }
            }
            return new Tuple<double, int>(min, minI);

        }
        /// <summary>
        /// Searches (absolute) smallest and non zero element in row
        /// </summary> 
        /// <param name="row"></param>
        /// <returns>Pair (minimum value, position)</returns>
        public Tuple<double, int> SmallestNonZeroInRow(int row)
        {
            GoodRange(row);
            double min = double.MaxValue;
            int minI = 0;
            for (int i = 0; i < Cols; ++i)
            {
                var item = Math.Abs(this[row, i]);
                if (item > 0 && item < min)
                {
                    min = this[row, i];
                    minI = i;
                }
            }
            return new Tuple<double, int>(min, minI);
        }

        public bool IsSquare => Cols == Rows;
        public bool IsReversible
        {
            get
            {
                try
                {
                    return Math.Abs(Det) < Epsylon;
                }
                catch
                {
                    return false;
                }
            }
        }

        public double Det
        {
            get
            {
                if (IsSquare)
                {
                    return Determinant();
                }
                throw new NotSupportedException("Matrix must be quadric");
            }
        }
        public static Matrix operator /(Matrix m, double d)
        {
            for (int i = 0; i < m.Rows; ++i)
                for (int k = 0; k < m.Cols; ++k)
                {
                    m[i, k] /= d;
                }
            return m;
        }
        public double Determinant()
        {
            var dec = DecomposeWithSign();
            Matrix L = dec.Item1;
            Matrix U = dec.Item2;
            double counter = 1;
            for (int i = 0; i < Rows; ++i)
            {
                Debug.Write(U[i, i]);
                counter *= U[i, i];
            }

            return counter * dec.Item4;
        }

        public Tuple<Matrix, Matrix, Matrix, int> DecomposeWithSign()
        {
            bool sing = true;
            var tmp = new Matrix(_data);
            int[] pi = new int[tmp.Rows];
            for (int i = 0; i < tmp.Rows; ++i)
                pi[i] = i;
            for (int i = 0; i < Cols - 1; ++i)
            {
                var pair = Biggest(i, i, Cols - 1);
                if (Math.Abs(pair.Item1) <= 0)
                    throw new ArithmeticException("Matrix is singular");
                if (pair.Item2 != i)
                {
                    tmp.RowSwap(pair.Item2, i);
                    sing = !sing;
                    int sw = pi[i];
                    pi[i] = pi[pair.Item2];
                    pi[pair.Item2] = sw;
                }

                tmp[i, i] = _data[i, i];
                int row = 0;
                for (int k = i + 1; k < Rows; ++k)
                {
                    tmp[k, i] = tmp[k, i] / tmp[i, i];
                    int col = 0;
                    for (int j = i + 1; j < Cols; ++j)
                    {
                        tmp[k, j] -= tmp[k, i] * tmp[i, j];
                        col++;
                    }
                    row++;
                }
            }
            Matrix L = new Matrix(Rows, Cols);
            Matrix U = new Matrix(Rows, Cols);
            Matrix P = new Matrix(Rows, Cols);
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Cols; ++j)
                {
                    if (i > j)
                        L[i, j] = tmp[i, j];
                    else
                        U[i, j] = tmp[i, j];
                    if (i == j)
                        L[i, i] = 1;
                }
                P[i, pi[i]] = 1;
            }
            return new Tuple<Matrix, Matrix, Matrix, int>(L, U, P, sing ? 1 : -1);
        }
        public Tuple<Matrix, Matrix, Matrix> Decompose()
        {
            var d = DecomposeWithSign();
            return new Tuple<Matrix, Matrix, Matrix>(d.Item1, d.Item2, d.Item3);
        }

        private void Print(double[,] data, int rows, int cols)
        {
            for (int i = 0; i < rows; ++i)
            {
                for (int k = 0; k < cols; ++k)
                {
                    Debug.Write(data[i, k] + "\t\t");
                }
                Debug.WriteLine("");
            }
        }
        public Matrix SubMatrix(int rowStart, int rowEnd, int colStart, int colEnd)
        {
            if (rowEnd < rowStart || rowEnd < 0 || rowStart < 0 || colStart < 0 || colEnd < 0 || colEnd < colStart || rowEnd >= Rows || colEnd >= Cols)
                throw new IndexOutOfRangeException($"Invalid range{rowStart},{rowEnd},{colStart},{colEnd}");
            var data = new double[rowEnd - rowStart + 1, colEnd - colStart + 1];
            int row = 0, col;
            for (int i = rowStart; i <= rowEnd; ++i)
            {
                col = 0;
                for (int k = colStart; k <= colEnd; ++k)
                {
                    data[row, col] = _data[i, k];
                    col++;
                }
                row++;
            }
            return new Matrix(data);
        }
        private double NaiveDeterminant(double[,] data, int n)
        {
            double det = 0;
            double[,] tmp = new double[Rows, Cols];
            if (n == 1)
                return data[0, 0];
            if (n == 2)
            {
                return (data[0, 0] * data[1, 1] - (data[1, 0] * data[0, 1]));
            }
            for (int p = 0; p < n; ++p)
            {
                int h = 0, k = 0;
                for (int i = 1; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        if (j == p) continue;
                        tmp[h, k] = data[i, j];
                        ++k;
                        if (k != n - 1) continue;
                        k = 0;
                        ++h;
                    }
                }
                det += data[0, p] * Math.Pow(-1, p) * NaiveDeterminant(tmp, n - 1);
            }

            return det;
        }

        public bool Equals(Matrix other)
        {
            if (other.Rows != Rows || other.Cols != Cols)
                return false;
             
            Print(_data, Rows, Cols);
            double eps = Math.Max(other.Epsylon, Epsylon);
            for (int i = 0; i < Rows; ++i)
                for (int k = 0; k < Cols; ++k)
                    if (Math.Abs(this[i, k] - other[i, k]) > eps)
                    {
                        return false;
                    }
            return true;
        }
    }
}
