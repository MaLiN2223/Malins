namespace DataStructures.Lists
{
    using System;

    public interface ILinkedListNode<T> : IDisposable
    {
        T Value { get; }
        ILinkedListNode<T> Next { get; }
    }
}
