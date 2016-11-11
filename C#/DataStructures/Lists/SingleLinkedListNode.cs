namespace DataStructures.Lists
{
    using System.Collections.Generic;
    using System.Xml.Schema;

    public class SingleLinkedListNode<T> : ILinkedListNode<T>
    {
        public SingleLinkedListNode(T data)
        {
            Value = data;
        }
        public void Dispose()
        {
            Next = null;
            List = null;
        }

        public T Value { get; }
        public ILinkedListNode<T> Next { get; internal set; }
        public ILinkedList<T> List { get; private set; }
    }
}
