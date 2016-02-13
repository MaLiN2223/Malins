namespace DataStructures.Lists
{
    public class DoubleLinkedListNode<T> : ILinkedListNode<T>
    {
        public DoubleLinkedListNode<T> Previous { get; internal set; }
        internal ILinkedList<T> list;
        public T Value { get; }
        public ILinkedListNode<T> Next { get; internal set; }

        public DoubleLinkedListNode(T data, DoubleLinkedListNode<T> next = null, DoubleLinkedListNode<T> prev = null)
        {
            Value = data;
        }

        public void Dispose()
        {
            Next = null;
            Previous = null;
            list = null;
        }
    }
}
