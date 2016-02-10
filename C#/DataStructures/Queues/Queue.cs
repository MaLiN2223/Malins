namespace DataStructures.Queues
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class Queue<T> : IEnumerable<T>, ICollection, IReadOnlyCollection<T>
    {
        private T[] data;
        private int head;
        private int tail;

        public Queue(int size = 0)
        {
            data = new T[size];
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }


        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public object SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsSynchronized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private class Node
        {
            T data;
            Node prev;
            Node next;
        }
    }


}
