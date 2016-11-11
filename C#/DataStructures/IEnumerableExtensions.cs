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
        public static bool HasDuplicatesDistinct<T>(this IEnumerable<T> collection)
        {
            return collection.Count().Equals(collection.Distinct().Count());
        }
        public static bool HasDuplicatesSelect<T>(this IEnumerable<T> collection)
        {
            return collection.Any(variable => collection.Select(x => x.Equals(variable)).Count() > 1);
        }
        public static bool HasDuplicatesSelectOnArray<T>(this IEnumerable<T> collection)
        {
            var enumerable = collection as T[] ?? collection.ToArray();
            return enumerable.Any(variable =>
            {
                return enumerable.Select(x => x.Equals(variable)).Count() > 1;
            });
        }

        public static bool HasDuplicatesArray<T>(this IEnumerable<T> collection)
        {
            var array = collection as T[] ?? collection.ToArray();
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = i + 1; j < array.Length; ++j)
                {
                    bool iIsNull = ReferenceEquals(array[i], null);
                    bool jIsNull = ReferenceEquals(array[j], null);
                    if (iIsNull && jIsNull)
                        return true;
                    if (iIsNull || jIsNull)
                        continue;
                    if (array[i].Equals(array[j]))
                        return true;
                }
            }
            return false;
        }
    }
}
