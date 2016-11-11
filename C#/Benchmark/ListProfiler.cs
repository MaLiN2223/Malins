using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using DataStructures.Lists;

namespace Benchmark
{
    public class IEnumerableExtensionsProfiler
    {
        static IEnumerableExtensionsProfiler()
        {
            InitIntList();
        }
        private static LinkedList<int> list;
        private static Random random = new Random();
        private static void InitIntList()
        {
            list = new LinkedList<int>();
            int duplicatesCount = 300;
            var range = new Tuple<int, int>(0, 10000);
            for (int i = range.Item1; i < range.Item2; ++i)
            {
                list.AddLast(random.Next(0, range.Item2 / 5));
            }
        }
        [Benchmark]
        public IEnumerable<int> RemoveDuplicates()
        {
            return null;
        }
    }
}
