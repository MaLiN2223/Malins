using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;

namespace DataStructures.Lists
{
    [Serializable]
    [ComVisible(false)]
    public partial class LinkedList<T> : ILinkedList<T>
    {
        public LinkedList()
        {
            Count = 0;
        }
        public LinkedList(IEnumerable<T> collection)
        {
            //TODO : sprawdzić największą wydajność (iteratory?)
            foreach (var data in collection)
            {
                Add(data);
            }
        }

        public int Count { get; private set; }
        public LinkedListNode<T> First { get; private set; }

        public LinkedListNode<T> Last { get; private set; }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            //TODO : implement
            throw new NotImplementedException();
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            //TODO : implement
            throw new NotImplementedException();
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            //TODO : implement
            throw new NotImplementedException();
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            //TODO : implement
            throw new NotImplementedException();
        }

        public LinkedListNode<T> AddFirst(T value)
        {
            var node = new LinkedListNode<T>(value);
            AddFirst(node);
            return node;
        }
        public void AddFirst(LinkedListNode<T> node)
        {
            if (First == null)
            {
                First = node;
                Last = node;
            }
            else
            {
                node.Next = First;
                First.Previous = node;
            }
            node.List = this;
            Count++;
        }

        public LinkedListNode<T> AddLast(T value)
        {
            var node = new LinkedListNode<T>(value);
            AddLast(node);
            return node;
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (First == null)
            {
                First = node;
                Last = First;
            }
            else
            {
                node.Previous = Last;
                Last.Next = node;
            }
            node.List = this;
            Count++;
        }

        public LinkedListNode<T> Find(T value)
        {
            throw new NotImplementedException();
        }
        public LinkedListNode<T> FindLast(T value)
        {
            throw new NotImplementedException();
        }

        protected new object MemberwiseClone()
        {
            throw new NotImplementedException();
        }
        public void Remove(LinkedListNode<T> node)
        {
            ValidateRemoveNode(node); 
        }

        private void ValidateRemoveNode(LinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (node.List != this) 
                throw new InvalidOperationException();
        }
        private void ValidateAddNode(LinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (node.List != null)
                throw new InvalidOperationException();
        }

        public void RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            if (Count == 1)
            {
                First = null;
                Last = null;
            }
            else
            {
                var next = First.Next;
                next.Previous = null;
                First = next;
            }
            Count--;


        }
        public void RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            if (Count == 1)
            {
                First = null;
                Last = null;
            }
            else
            {
                var prev = Last.Previous;
                prev.Next = null;
                Last = prev;
            }
            Count--;
        }
    }
}
