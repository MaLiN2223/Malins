using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists.Operators
{
    public static class LinqRemover
    {
        public static ILinkedList<T> RemoveDuplicates<T>(this ILinkedList<T> list )
        {
            throw new NotImplementedException();
        }

        public static bool HasDuplicates<T>(this ILinkedList<T> list)
        {
            return list.Distinct().Count().Equals(list.Count);
        }
    }
     
}
