namespace DataStructures.Lists
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using Exceptions;

    public sealed class CircularLinkedList<T> : ILinkedList<T>
    {
        private DoubleLinkedListNode<T> Head { get; set; }
        public DoubleLinkedListNode<T> First => Head;
        public int Count { get; private set; }
        int ICollection.Count => Count;
        int ICollection<T>.Count => Count;
        int IReadOnlyCollection<T>.Count => Count;
        public object SyncRoot => Head;
        public bool IsSynchronized => false;
        public bool IsReadOnly { get; }
        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            if (current != null)
            {
                yield return current.Value;
                while (current.Next != Head)
                {
                    yield return current.Value;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds item on start - just after head
        /// </summary> 
        public void Add(T item)
        {
            if (Head != null)
            {
                Head = new DoubleLinkedListNode<T>(item);
            }
            else
            {
                var node = new DoubleLinkedListNode<T>(item);
                var tmp = Head.Next as DoubleLinkedListNode<T>;
                var last = tmp.Previous;
                Head.Next = node;
                node.Next = tmp;
                node.Previous = last;
                last.Next = node;
                tmp.Previous = node;
                Count++;
                node.list = this;
            }
        }

        public void Clear()
        {
            Head.Next = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Enumerable.Contains(this, item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0 || arrayIndex > array.Length || array.Length - arrayIndex < Count)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            var node = Head;
            if (node == null)
                return;
            do
            {
                array[arrayIndex++] = node.Value;
                node = node.Next as DoubleLinkedListNode<T>;
            } while (node != Head);
        }


        public void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (array.Rank != 1 || array.GetLowerBound(0) != 0)
                throw new ArgumentException(nameof(array));
            if (index < 0 || array.Length - index < Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            var tArray = array as T[];
            if (tArray != null)
                CopyTo(tArray, index);
            else
                throw new NotSupportedException(array.GetType().ToString());
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public void OnDeserialization(object sender)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(ILinkedListNode<T> node)
        {
            var toAdd = NodeValidation(node);
            var last = Head.Previous;
            Head.Previous = toAdd;
            last.Next = node;
            toAdd.Next = Head;
            Head = toAdd;
        }

        public void AddFirst(T data)
        {
            var node = new DoubleLinkedListNode<T>(data);
            AddFirst(node);
        }

        public void RemoveFirst()
        {
            Remove(Head);
        }

        public ILinkedListNode<T> Find(T data)
        {
            if (Head == null)
                return null;
            ILinkedListNode<T> node = Head;
            do
            {
                if (node.Value.Equals(data))
                    return node;
                node = node.Next;
            } while (node != null);
            return null;
        }

        public ILinkedListNode<T> FindLast(T data)
        {
            if (Head == null)
                return null;
            ILinkedListNode<T> node = Head;
            ILinkedListNode<T> outputNode = null;
            do
            {
                if (node.Value.Equals(data))
                    outputNode = node;
                node = node.Next;
            } while (node != null);
            return outputNode;
        }

        public bool Remove(T item)
        {
            var k = Find(item);
            if (k == null)
                return false;
            Remove(k);
            return true;
        }
        public bool RemoveLast(T item)
        {
            var k = FindLast(item);
            if (k == null)
                return false;
            Remove(k);
            return true;
        }
        public void Remove(ILinkedListNode<T> node)
        {
            var goodNode = NodeValidation(node);
            DoRemove(goodNode);
        }
        private DoubleLinkedListNode<T> NodeValidation(ILinkedListNode<T> node)
        {
            if (ReferenceEquals(node, null))
                throw new ArgumentNullException(nameof(node));
            var nod = node as DoubleLinkedListNode<T>;
            if (nod == null || !nod.list.Equals(this))
                throw new InvalidOperationException(nameof(node));
            return nod;
        }
        private void DoRemove(DoubleLinkedListNode<T> node)
        {

        }
    }
}
