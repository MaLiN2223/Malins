using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace DataStructures.Lists
{
    [Serializable]
    [ComVisible(false)]
    public partial class LinkedList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T>, ISerializable, IDeserializationCallback
    {
        public LinkedList()
        {

        }
        public LinkedList(IEnumerable<T> data)
        {

        }
        protected LinkedList(SerializationInfo info, StreamingContext context)
        {

        }
        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public T First
        {
            get { throw new NotImplementedException(); }
        }
        public T Last
        {
            get { throw new NotImplementedException(); }
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            throw new NotImplementedException();
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            throw new NotImplementedException();
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            throw new NotImplementedException();
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            throw new NotImplementedException();
        }

        public LinkedListNode<T> AddFirst(T value)
        {
            throw new NotImplementedException();
        }
        public void AddFirst(LinkedListNode<T> node)
        {
            throw new NotImplementedException();
        }

        public LinkedListNode<T> AddLast(T value)
        {
            throw new NotImplementedException();
        }

        public void AddLast(LinkedListNode<T> node)
        {
            throw new NotImplementedException();
        }

        public LinkedListNode<T> Find(T value)
        {
            throw new NotImplementedException(); 
        } 
        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        } 
        public LinkedListNode<T> FindLast(T value)
        { 
            throw new NotImplementedException();
        }

        public new Type GetType()
        {
            throw new NotImplementedException();
        }

        protected new object MemberwiseClone()
        { 
            throw new NotImplementedException();
        } 
        public void Remove(LinkedListNode<T> node)
        { 
            throw new NotImplementedException();
        }
        public void RemoveFirst()
        {
            throw new NotImplementedException();
        }
        public void RemoveLast()
        {
            throw new NotImplementedException();
        } 
        public override string ToString()
        {
            throw new NotImplementedException(); 
        }
    }
}
