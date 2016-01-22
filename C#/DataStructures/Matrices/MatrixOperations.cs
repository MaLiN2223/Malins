namespace DataStructures.Matrices
{
    using System;
    using Integers;

    public static class MatrixOperations
    {
        private static readonly MatrixFactory _factory = new MatrixFactory();

        public static bool IsSmithForm(this Matrix<int> m, int p)
        {
            var rows = m.RowCount;
            var cols = m.ColumnCount;
            if (p > cols || p > rows)
                throw new ArgumentException();

            return true;
        }

        public static Tuple<Matrix<int>, Matrix<int>, Matrix<int>, Matrix<int>, Matrix<int>, int, int> ToSmith(
            this Matrix<int> B)
        {
            var m = B.RowCount;
            var n = B.ColumnCount;
            var Q = _factory.Identity(m);
            var Q2 = _factory.Identity(m);
            var R = _factory.Identity(n);
            var R2 = _factory.Identity(n);
            var s = 0;
            var t = 0;
            while (!Empty(B, t, m - 1, t, n - 1))
            {
                PartialSmithForm(ref B, ref Q, ref Q2, ref R, ref R2, t);
                if (B[t, t] < 0)
                    RowMultiplyOperation(ref B, ref Q, ref Q2, t);
                if (B[t, t] == 1)
                    ++s;
                t++;
            }
            return new Tuple<Matrix<int>, Matrix<int>, Matrix<int>, Matrix<int>, Matrix<int>, int, int>(B, Q, Q2, R, R2,
                s, t);
        }

        private static Tuple<bool, int, int, int> Divisibility(this Matrix<int> m, int k)
        {
            for (var i = k + 1; i < m.RowCount; ++i)
            {
                for (var j = k + 1; j < m.ColumnCount; ++j)
                {
                    var q = (int) Math.Floor(m[i, j]/(double) m[k, k]);
                    if (q*m[k, k] != m[i, j])
                        return new Tuple<bool, int, int, int>(false, i, j, q);
                }
            }
            return new Tuple<bool, int, int, int>(true, 0, 0, 0);
        }


        private static void RowMultiplyOperation(ref Matrix<int> B, ref Matrix<int> Q, ref Matrix<int> Q2, int t)
        {
            B.MultiplyRow(t, -1);
            Q.MultiplyRow(t, -1);
            Q2.MultiplyColumn(t, -1);
        }

        private static void PartialSmithForm(ref Matrix<int> B, ref Matrix<int> Q, ref Matrix<int> Q2,
            ref Matrix<int> R, ref Matrix<int> R2, int k)
        {
            var m = B.RowCount;
            var n = B.ColumnCount;
            var divisibility = new Tuple<bool, int, int, int>(false, 0, 0, 0);
            do
            {
                MoveMinNonZero(ref B, ref Q, ref Q2, ref R, ref R2, k);
                PartRowReduce(ref B, ref Q, ref Q2, k, k);
                //if (!B.SubMatrix(k + 1, m - 1, k, k).IsEmpty())
                if (!Empty(B, k + 1, m - 1, k, k))
                    continue;
                PartColumnReduce(ref B, ref R, ref R2, k, k);
                //if (k + 1 <= n - 1 && !B.SubMatrix(k, k, k + 1, n - 1).IsEmpty()) 
                if (!Empty(B, k, k, k + 1, n - 1))
                    continue;
                divisibility = B.Divisibility(k);
                if (!divisibility.Item1)
                {
                    RowAddOperation(ref B, ref Q, ref Q2, divisibility.Item2, k, 1);
                    ColumnAddOperation(ref B, ref R, ref R2, k, divisibility.Item3, -divisibility.Item4);
                }
            } while (!divisibility.Item1);
        }

        private static bool Empty(Matrix<int> B, int s1, int e1, int s2, int e2)
        {
            for (var i = s1; i <= e1; ++i)
            {
                for (var j = s2; j <= e2; ++j)
                {
                    if (B[i, j] != 0)
                        return false;
                }
            }
            return true;
        }

        private static void ColumnAddOperation(ref Matrix<int> matrix, ref Matrix<int> R, ref Matrix<int> R2, int i,
            int item3,
            int i1)
        {
            matrix.SumColumn(i, item3, i1);
            R.SumColumn(i, item3, i1);
            R2.SumRow(i, item3, -i1);
        }


        private static void PartColumnReduce(ref Matrix<int> B, ref Matrix<int> R, ref Matrix<int> R2, int k, int l)
        {
            for (var i = k + 1; i < B.RowCount; i++)
            {
                var q = (int) Math.Floor(B[l, i]/(decimal) B[l, k]);
                ColumnAddOperation(ref B, ref R, ref R2, i, k, -q);
            }
        }

        private static void RowAddOperation(ref Matrix<int> B, ref Matrix<int> Q, ref Matrix<int> Q2, int i, int j,
            int q)
        {
            B.SumRow(i, j, q);
            Q2.SumRow(i, j, q);
            Q.SumColumn(i, j, -q);
        }

        private static void PartRowReduce(ref Matrix<int> B, ref Matrix<int> Q, ref Matrix<int> Q2, int k,
            int l)
        {
            for (var i = k + 1; i < B.RowCount; i++)
            {
                var q = (int) Math.Floor(B[i, l]/(decimal) B[k, l]);
                RowAddOperation(ref B, ref Q, ref Q2, i, k, -q);
            }
        }

        private static void MoveMinNonZero(ref Matrix<int> B, ref Matrix<int> Q, ref Matrix<int> Q2, ref Matrix<int> R,
            ref Matrix<int> R2, int k)
        {
            var tuple = SmallestNonZero(B, k);
            B.SwapRow(k, tuple.Item1);
            Q.SwapRow(k, tuple.Item1);
            Q2.SwapRow(k, tuple.Item1);
            B.SwapColumn(k, tuple.Item2);
            R.SwapColumn(k, tuple.Item2);
            R2.SwapColumn(k, tuple.Item2);
        }

        private static Tuple<int, int> SmallestNonZero(Matrix<int> m, int k)
        {
            var min = int.MaxValue;
            var x = -1;
            var y = -1;
            for (var i = k; i < m.RowCount; ++i)
            {
                for (var j = k; j < m.ColumnCount; ++j)
                {
                    var p = Math.Abs(m[i, j]);
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