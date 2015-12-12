
using System;
using System.Runtime.InteropServices;

namespace DataStructures.Lists
{
    [ComVisible(false)]
    public sealed class LinkedListNode<T>
    {
        public LinkedListNode(T item)
        {
            
        }

        public LinkedList<T> List
        {
            get { throw new NotImplementedException();}
        }
        public LinkedListNode<T> Next { get; }
        public LinkedListNode<T> Previous { get; }
        public T Value { get; set; }

        public override bool Equals(object obj)
        {
        throw new NotImplementedException();
        } 
        public override int GetHashCode()
        { 
            throw new NotImplementedException();
        }

        public new Type GetType()
        {
            throw new NotImplementedException();
        } 
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
