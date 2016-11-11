using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.BasicAlgorithms;
namespace DataStructuresTests.BasicAlgorithms
{
    [TestClass]
    public class SortTests
    {
        private static Random random = new Random();
        [TestMethod]
        public void InsertionSort()
        {
            int[] arr = new int[0];
            arr.InsertionSort();

            arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int[] sorted = new int[arr.Length];
            arr.CopyTo(sorted, 0);
            arr.InsertionSort();
            Array.Sort(sorted);
            for (int i = 0; i < arr.Length; ++i)
            {
                Assert.AreEqual(sorted[i], arr[i]);
            }
            arr = new[] { 7, 6, 5, 4, 3, 2, 1 };
            arr.CopyTo(sorted, 0);

            for (int i = 0; i < arr.Length; ++i)
            {
                Assert.AreEqual(sorted[i], arr[i]);
            }
            int N = 500;
            arr = new int[N];
            sorted = new int[N];
            for (int i = 0; i < N; ++i)
            {
                int tmp = random.Next();
                arr[i] = sorted[i] = tmp;
            }
            Array.Sort(sorted);
            for (int i = 0; i < arr.Length; ++i)
            {
                Assert.AreEqual(sorted[i], arr[i]);
            }
        }
    }
}
