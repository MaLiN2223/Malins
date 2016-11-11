using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    static class IEnumerableExtensions
    {
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public static bool HasDuplicatesLinq<T>(this IEnumerable<T> collection)
        {
            return collection.Count().Equals(collection.Distinct().Count());
        }
        public static bool HasDuplicatesForeach<T>(this IEnumerable<T> collection)
        {
            var enumerable = collection.ToArray();
            foreach (var variable in enumerable)
            { 
            }
            return false;
        }
    }
}
