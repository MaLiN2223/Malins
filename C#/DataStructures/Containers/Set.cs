namespace DataStructures.Containers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Trees;

    public class Set<T> : ISerializable, ISet<T>
    {
        public Set()
        {
            data = new SplayTree<T>();
        }

        public Set(IComparer<T> comparer)
        {
            data = new SplayTree<T>(comparer);
        }
        private readonly SplayTree<T> data;

        public void Add(T item)
        {
            if (!Contains(item))
            {
                data.Insert(item);
            }
            else
            {
                throw new ArgumentException($"Item {item} already in set");
            }
        }

        bool ISet<T>.Add(T item)
        {
            if (!Contains(item))
            {
                data.Insert(item);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Clear()
        {
            data.Clear();
        }

        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }
            data.Remove(item);
            return true;
        }

        public bool Contains(T item)
        {
            return data.Contains(item);
        }
        public int Count => data.Count;

        public bool IsReadOnly { get; } = false;
        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void UnionWith(IEnumerable<T> other)
        {
            throw new System.NotImplementedException();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            throw new System.NotImplementedException();
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            throw new System.NotImplementedException();
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            throw new System.NotImplementedException();
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            throw new System.NotImplementedException();
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            throw new System.NotImplementedException();
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            throw new System.NotImplementedException();
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            throw new System.NotImplementedException();
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            throw new System.NotImplementedException();
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            throw new System.NotImplementedException();
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
