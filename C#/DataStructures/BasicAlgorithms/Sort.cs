namespace DataStructures.BasicAlgorithms
{
    using System;
    using System.Diagnostics;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.Win32;

    public static class Sort
    {
        /// <summary>
        /// Insertion sort
        /// </summary>  
        /// <remarks>Sorts element to produce nondecreasing sequence</remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Array to sort</param>
        public static void InsertionSort<T>(this T[] array) where T : IComparable<T>
        {
            int size = array.Length;
            for (int i = 1; i < size; ++i)
            {
                var tmp = array[i];
                int counter = i - 1;
                while (counter >= 0 && tmp.CompareTo(array[counter]) < 0)
                {
                    counter--;
                }//counter < 0 || tmp>=array[counter]
                if (counter < 0 || counter == i - 1)
                    continue;
                for (int k = i; k > counter; --k)
                {
                    array[k] = array[k - 1];
                }
                array[counter] = tmp;
            }
        }
    }
}
