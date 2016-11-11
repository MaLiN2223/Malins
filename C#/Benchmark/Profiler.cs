using System;
using System.Text;
using DataStructures.Containers;

namespace Benchmark
{
    public class Profiler
    {
        public static void Main(string[] args)
        {
            GenerateRandom();
            var arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            foreach (var a in arr.Randomize())
            {
                Console.Write(a+",");
            }
            Console.ReadKey();
        }

        static Random rand = new Random();
        public static void GenerateRandom()
        {
            var builder = new StringBuilder(302);
            builder.Append("{");
            for (int i = 0; i < 300; ++i)
            {
                builder.Append(rand.Next(0, 10000) + ",");
            }
            builder.Length--;
            builder.Append("}");
            System.IO.File.WriteAllText("randomed.txt", builder.ToString());
        }
    }
}
