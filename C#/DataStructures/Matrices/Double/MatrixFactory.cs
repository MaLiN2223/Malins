using System; 
namespace DataStructures.Matrices.Double
{
    public class MatrixFactory : MatrixFactory<double>
    {
        public override double One => 1.0;
        public override double RandomData()
        {
            return random.NextDouble();
        } 
        public override Matrix<double> Create(MatrixContainer<double> containter)
        {
            if (containter == null)
                throw new ArgumentNullException();
            return new Matrix(containter.Clone() as MatrixContainer);
        }

        public override Matrix<double> Create(double[,] data)
        {
            if (data == null)
                throw new ArgumentNullException();
            return new Matrix((double[,])data.Clone());
        }
    }
}
