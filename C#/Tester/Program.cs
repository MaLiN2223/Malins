using DataStructures.Matrices;
using DataStructures.Matrices.Integers;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixFactory factory = new MatrixFactory();

            var data = new int[,]
             {
                 {2,6,5},
                 {4,1,2},
                 {5,3,2}
             };
            /*
           var data = new int[,]
           {
               {3, 2, 3},
               {0, 2, 0},
               {2, 2, 2}
           };*/
            var matrix = factory.Create(data);
            matrix.ToSmith();

        }
    }
}
