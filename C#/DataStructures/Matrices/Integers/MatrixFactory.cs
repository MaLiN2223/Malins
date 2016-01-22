namespace DataStructures.Matrices.Integers
{
    using System;

    public class MatrixFactory : MatrixFactory<int>
    {
        public override int One
        {
            get { return 1; }
        }

        public override int RandomData()
        {
            return random.Next();
        }

        public override Matrix<int> Create(MatrixContainer<int> containter)
        {
            if (containter == null)
                throw new ArgumentNullException();
            return new Matrix(containter.Clone() as MatrixContainer);
        }

        public override Matrix<int> Create(int[,] data)
        {
            if (data == null)
                throw new ArgumentNullException();
            var tmp = data.Clone() as int[,];
            return new Matrix(new MatrixContainer(tmp));
        }
    }
}