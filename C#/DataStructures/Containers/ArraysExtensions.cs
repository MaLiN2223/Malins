using System;

namespace DataStructures.Containers
{
    public static class ArraysExtensions
    {
        static ArraysExtensions()
        {
            Random = new Random();
        }
        private static readonly Random Random;
        public static T[] Randomize<T>(this T[] array)
        {
            int size = array.Length;
            Console.WriteLine("Size = " + size);
            for (int i = 0; i < size - 1; ++i)
            {
                var place = Random.Next(i+1, size-1);
                Console.WriteLine("Place = "+place);
                var tmp = array.GetValue(i);
                array.SetValue(array.GetValue(place), i);
                array.SetValue(tmp, place);
            }
            return array;
        }
    }
}
