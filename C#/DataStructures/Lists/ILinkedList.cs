using System.Collections.Generic;

namespace DataStructures.Lists
{
    using System.Collections;
    using System.Runtime.Serialization; 

    public interface ILinkedList<T> : ICollection<T>, ICollection, IReadOnlyCollection<T>, ISerializable, IDeserializationCallback
    {
        void AddFirst(ILinkedListNode<T> node);
        void AddFirst(T data);
        void RemoveFirst();
        void Remove(ILinkedListNode<T> node);
        bool RemoveLast(T data);
        ILinkedListNode<T> Find(T data);
        ILinkedListNode<T> FindLast(T data);
        new int Count { get; }
    }
}
