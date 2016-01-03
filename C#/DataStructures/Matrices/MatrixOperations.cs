using System;
using DataStructures.Matrices.Double;

namespace DataStructures.Matrices
{
    public static class MatrixOperations
    {
        public static bool IsSmithForm(this Matrix<double> m, int p)
        {
            int rows = m.RowCount;
            int cols = m.ColumnCount;
            if (p > cols || p > rows)
                throw new ArgumentException();

            return true;
        }






        public static Tuple<Matrix<double>, Matrix<double>, Matrix<double>, Matrix<double>, Matrix<double>, int, int> ToSmith(this Matrix<double> B)
        {
            int m = B.RowCount;
            int n = B.ColumnCount;
            var Q = new MatrixFactory().Identity(m);
            var Q2 = new MatrixFactory().Identity(m);
            var R = new MatrixFactory().Identity(n);
            var R2 = new MatrixFactory().Identity(n);
            int s = 0;
            int t = 0;
            while (t + 1 < m && t + 1 < n && (int)B[t + 1, t + 1] != 0)
            {
                t++;
                PartialSmithForm(ref B, ref Q, ref Q2, ref R, ref R2, t);
                if (B[t, t] < 0)
                {
                    B.MultiplyRow(t, -1);
                    Q.MultiplyRow(t, -1);
                    Q2.MultiplyRow(t, -1);
                }
                if ((int)B[t, t] == 1)
                {
                    s++;
                }
            }
            return new Tuple<Matrix<double>, Matrix<double>, Matrix<double>, Matrix<double>, Matrix<double>, int, int>(B, Q, Q2, R, R2, s, t);
        }

        private static void PartialSmithForm(ref Matrix<double> B, ref Matrix<double> Q, ref Matrix<double> Q2,
            ref Matrix<double> R, ref Matrix<double> R2, int k)
        {
            int m = B.RowCount;
            MoveMinNonZero(ref B, ref Q, ref Q2, ref R, ref R2, k);
            PartRowReduce(ref B, ref Q, ref Q2, k, k);
            for (int i = k + 1; i < m; ++i)
            {
                if ((int)B[i, k] != 0)
                    break;
                PartColumnReduce(ref B, ref R, ref R2, k, k);
            }


        }

        private static void PartColumnReduce(ref Matrix<double> matrix, ref Matrix<double> matrix1, ref Matrix<double> r2, int i, int i1)
        {
            throw new NotImplementedException();
        }

        private static void PartRowReduce(ref Matrix<double> B, ref Matrix<double> Q, ref Matrix<double> Q2, int k,
            int l)
        {
            for (int i = k + 1; i < B.RowCount; i++)
            {
                int q = (int)Math.Floor((decimal)B[i, l] / (decimal)B[k, l]);
                B.SumRow(i, k, -q);
                Q.SumRow(i, k, -q);
                Q2.SumRow(i, k, -q);

            }
        }
        private static void MoveMinNonZero(ref Matrix<double> B, ref Matrix<double> Q, ref Matrix<double> Q2, ref Matrix<double> R, ref Matrix<double> R2, int k)
        {
            var tuple = SmallestNonZero(B, k);
            B.SwapRow(k, tuple.Item1);
            Q.SwapRow(k, tuple.Item1);
            Q2.SwapRow(k, tuple.Item1);
            B.SwapColumn(k, tuple.Item2);
            R.SwapColumn(k, tuple.Item2);
            R2.SwapColumn(k, tuple.Item2);
        }

        private static Tuple<int, int> SmallestNonZero(Matrix<double> m, int k)
        {
            double min = double.MinValue;
            int x = -1;
            int y = -1;
            for (int i = k; i < m.RowCount; ++i)
            {
                for (int j = k; j < m.ColumnCount; ++j)
                {
                    var p = (int)Math.Abs(m[i, j]);
                    if (p != 0 && p < min)
                    {
                        min = p;
                        x = i;
                        y = j;
                    }
                }
            }
            return new Tuple<int, int>(x, y);
        }

    }
}
