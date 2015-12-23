using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace DataStructures.Matrices
{
    /// <summary>
    /// Represents matrix
    /// </summary>
    public class Matrix
    {
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
        public Matrix(int rows, int cols)
        {
            _data = new double[rows, cols];
            Rows = rows;
            Cols = cols;

        }
        /// <summary>
        /// Constructor - generates matrix from array
        /// </summary>
        /// <param name="data">array to generate matrix from</param>
        public Matrix(double[,] data)
        {
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
            var mOut = new Matrix(first.Rows, first.Cols);
            for (int i = 0; i < mOut.Rows; i++)
            {
                for (int j = 0; j < mOut.Cols; j++)
                {
                    mOut[i, j] = 0;
                    for (int k = 0; k < first.Cols; k++)
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
        private void GoodRange(int target, int source = 0)
        {
            if (target < 0 || target >= Rows)
                throw new ArgumentOutOfRangeException(nameof(target));
            if (source >= Rows || source < 0)
                throw new ArgumentOutOfRangeException(nameof(source));

        }
        /// <summary>
        /// Searches (absolute) smallest and non zero element in row
        /// </summary> 
        /// <param name="row"></param>
        /// <returns>Pair (minimum value, position)</returns>
        public Tuple<double, int> SmallestNonZeroRow(int row)
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
                    return (Det > 0 || Det < 0);
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
                    return NaiveDeterminant(_data, Cols);
                }
                throw new NotSupportedException("Matrix must be quadric");
            }
        }

        private double NaiveDeterminant(double[,] data, int n)
        {
            double det = 0;
            double[,] tmp = new double[Rows, Cols];
            if (n == 1)
                return data[0, 0];
            else if (n == 2)
            {
                return (data[0, 0] * data[1, 1] - (data[1, 0] * data[0, 1]));
            }
            else
            {
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
            
        } 
    }
}
