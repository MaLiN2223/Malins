
using System.Runtime.InteropServices;

namespace DataStructures.Lists
{
    [ComVisible(false)]
    public sealed class LinkedListNode<T>
    {
        private LinkedList<T> refToList;
        private LinkedListNode<T> next, prev;
        private LinkedListNode()
        {

        }
        public LinkedListNode(T item)
        {
            Value = item;
        }

        public LinkedList<T> List
        {
            get { return refToList; }
            internal set { refToList = value; }
        }

        public LinkedListNode<T> Next
        {
            get { return next; }
            internal set { next = value; }
        }
        public LinkedListNode<T> Previous
        {
            get { return prev; }
            internal set { prev = value; }
        }
        public T Value { get; set; }

    }
}
