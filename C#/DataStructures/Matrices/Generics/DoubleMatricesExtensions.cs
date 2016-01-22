using System;
namespace DataStructures.Matrices.Generics
{
    public static class DoubleMatricesExtensions
    {
        public static void Round(this Matrix<double> matrix, int digits, MidpointRounding rounding = MidpointRounding.ToEven)
        {
            for (int i = 0; i < matrix.RowCount; ++i)
            {
                for (int j = 0; j < matrix.ColumnCount; ++j)
                {
                    matrix[i, j] = Math.Round(matrix[i, j], digits, rounding);
                }
            }
        }
    }
}
