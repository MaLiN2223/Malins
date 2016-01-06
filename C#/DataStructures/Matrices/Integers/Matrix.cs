using System;
using System.Runtime.Serialization;

namespace DataStructures.Matrices.Integers
{
    [Serializable]
    public class Matrix : Matrix<int>, ISerializable
    {
        [NonSerialized]
        private static MatrixFactory _factory;
        internal Matrix(MatrixContainer container) : base(container)
        {
            Container = (MatrixContainer)container.Clone();
        }

        private Matrix(int[,] data) : base(new MatrixContainer(data))
        {
            Container = new MatrixContainer(data);
        }

        public override int Determinant()
        {
            //TODO : Determinant 
            throw new NotImplementedException();
        }

        public override Matrix<int> ForceZeros(int epsylon)
        {
            for (int i = 0; i < RowCount; ++i)
                for (int k = 0; k < ColumnCount; ++k)
                {
                    if (Container[i, k] < epsylon)
                        Container[i, k] = 0;
                }
            return this;
        }

        public override Matrix<int> Negate()
        {
            return this * -1;
        }

        public override Matrix<int> ForceRound(int precision)
        {
            //TODO : rounding int?
            throw new NotImplementedException();
        }

        public override Tuple<Matrix<int>, Matrix<int>, Matrix<int>, int> DecomposeWithSign()
        {
            //TODO : decompose LUP
            throw new NotImplementedException();
        }

        public override Matrix<int> Add(Matrix<int> another)
        {
            var data = _factory.Create(this);
            for (int i = 0; i < data.RowCount; ++i)
            {
                for (int k = 0; k < data.ColumnCount; ++k)
                {
                    data[i, k] += another[i, k];
                }
            }
            return data;
        }

        public override Matrix<int> Multiply(Matrix<int> another)
        {
            throw new NotImplementedException();
        }

        public override Matrix<int> Multiply(int scalar)
        {
            throw new NotImplementedException();
        }

        public override Matrix<int> Substract(Matrix<int> another)
        {
            throw new NotImplementedException();
        }

        public override Matrix<int> Divide(int d)
        {
            throw new NotImplementedException();
        }

        public override void MultiplyRow(int target, int scalar)
        {

            for (int i = 0; i < ColumnCount; ++i)
            {
                this[target, i] *= scalar;
            }
        }

        public override void MultiplyColumn(int target, int scalar)
        {
            for (int i = 0; i < RowCount; ++i)
            {
                this[i, target] *= scalar;
            }
        }

        public override void SumColumn(int target, int source, int scalar)
        {
            for (int i = 0; i < RowCount; ++i)
                this[i, target] += this[i, source] * scalar;
        }
        /// <summary>
        /// Adds row source to target multiplied by scalar
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        /// <param name="scalar"></param>
        public override void SumRow(int target, int source, int scalar)
        {
            for (int i = 0; i < ColumnCount; ++i)
                this[target, i] += this[source, i] * scalar;
        } 
        public override Matrix<int> SubMatrix(int rowStart, int rowEnd, int colStart, int colEnd)
        {
            if (rowEnd < rowStart || rowEnd < 0 || rowStart < 0 || colStart < 0 || colEnd < 0 || colEnd < colStart || rowEnd > RowCount || colEnd > ColumnCount)
                throw new IndexOutOfRangeException($"Invalid range{rowStart},{rowEnd},{colStart},{colEnd}");
            var data = new int[rowEnd - rowStart + 1, colEnd - colStart + 1];
            int row = 0;
            for (int i = rowStart; i <= rowEnd; ++i)
            {
                var col = 0;
                for (int k = colStart; k <= colEnd; ++k)
                {
                    data[row, col] = this[i, k];
                    col++;
                }
                row++;
            }
            var output = new Matrix(data);
            return output;
        }

        public override bool IsEmpty()
        {
            for (int i = 0; i < RowCount; ++i)
            {
                for (int j = 0; j < ColumnCount; ++j)
                    if (this[i, j] != 0)
                        return false;

            }
            return true;
        }

        public override bool Equals(Matrix<int> other)
        {
            if (other == null)
                return false;
            if (other.ColumnCount != ColumnCount || other.RowCount != RowCount)
                return false;
            for (int i = 0; i < RowCount; ++i)
            {
                for (int j = 0; j < ColumnCount; ++j)
                {
                    if (this[i, j] != other[i, j])
                        return false;
                }
            }
            return true;
        }

        public override object Clone()
        {
            return new Matrix((MatrixContainer)Container.Clone());
        }

        protected Matrix(SerializationInfo info, StreamingContext context) : base((MatrixContainer)info.GetValue("_container", typeof(MatrixContainer)))
        {
            if (info == null)
                throw new ArgumentNullException("info");
            Container = (MatrixContainer)info.GetValue("_container", typeof(MatrixContainer));
            if (Container == null)
                throw new ArgumentNullException("Container");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            info.AddValue("_container", Container);
        }
    }
}
