using System;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization; 

namespace DataStructures.Lists
{
    public interface ILinkedList<T> : ICollection<T>, ICollection, IReadOnlyCollection<T>, ISerializable, IDeserializationCallback
    {
    }
}
