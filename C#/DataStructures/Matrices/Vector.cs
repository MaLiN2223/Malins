using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Matrices
{
    public abstract class Vector<T> : IEquatable<Vector<T>>, IList, IList<T>, ICloneable where T : struct, IEquatable<T>
    {
        public VectorContainer<T> Container { get; set; }

        public bool Equals(Vector<T> other)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (!Container[i].Equals(other.Container[i]))
                    return false;
            }
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; ++i)
            {
                yield return Container[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public void CopyTo(Array array, int index)
        {
            for (int i = 0; i < Count; ++i)
            {
                array.SetValue(this[i], index);
                index++;
            }
        }

        public int Count
        {
            get { return Container.Count; }
        }

        bool ICollection<T>.IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public abstract object SyncRoot { get; }
        public abstract bool IsSynchronized { get; }

        public bool Contains(object value)
        {
            if (!(value is T))
                return false;
            return Contains((T)value);

        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (Container[i].Equals(item))
                    return true;
            }
            return false;
        }

        public abstract void CopyTo(T[] array, int arrayIndex);
        public void Clear()
        {
            Container.Clear();
        }

        public void Clear(int start, int count)
        {
            //TODO : Czyszczenie podwektora
        }

        public Vector<T> SubVector(int start, int count)
        {
            //TODO : Podwektor
            throw new NotImplementedException();
        }

        public T[] ToArray()
        {
            T[] arr = new T[Count];
            for (int i = 0; i < Count; ++i)
                arr[i] = this[i];
            return arr;
        }

        public Matrix<T> Combine(Angle angle, params Vector<T>[] arr)
        {
            if (angle.Equals(Angle.Vertical))
                throw new NotSupportedException();
            throw new NotImplementedException();
        }

        public Matrix<T> Combine(Angle angle, Vector<T> vector, Matrix<T> matrix)
        {
            if (angle.Equals(Angle.Vertical))
                throw new NotSupportedException();
            //TODO : Combine vector to matrix
            throw new NotImplementedException();
        }

        public Matrix<T> Combine(Angle angle, Matrix<T> matrix, Vector<T> vector)
        {
            if (angle.Equals(Angle.Vertical))
                throw new NotSupportedException();
            //TODO : Combine matrix to 
            throw new NotImplementedException();
        }
        public enum Angle
        {
            Vertical,
            Horizontal,
            Diagonal
        };
        public Matrix<T> ToMatrix(Angle angle)
        {
            //TODO : Converstion to matrix
            throw new NotImplementedException();
        }
        public int IndexOf(object value)
        {
            if (!(value is T))
                return -1;
            return IndexOf((T)value);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (Container[i].Equals(item))
                    return i;
            }
            return -1;
        }


        public T this[int index]
        {
            get { return Container[index]; }
            set { Container[index] = value; }
        }

        object IList.this[int index]
        {
            get { return Container[index]; }
            set { Container[index] = (T)value; }
        }
        public bool IsReadOnly { get; }
        public bool IsFixedSize { get { return true; } }
        public abstract object Clone();
        #region operators
        #region helpers

        public abstract Vector<T> Sum(Vector<T> another);
        public abstract Vector<T> Substract(Vector<T> another);
        public abstract Vector<T> Substract(T scalar);
        public abstract Vector<T> Multiply(T scalar);
        public abstract Vector<T> Divide(T scalar);
        public abstract T Multiply(Vector<T> scalar);
        public abstract Vector<T> Sum(T another);
        #endregion
        #endregion

        public static Vector<T> operator /(Vector<T> first, T scalar)
        {
            return first.Divide(scalar);
        }
        public static Vector<T> operator +(Vector<T> first, Vector<T> second)
        {
            return first.Sum(second);
        }

        public static Vector<T> operator +(Vector<T> first, T second)
        {
            return first.Sum(second);
        }

        public static T operator *(Vector<T> first, Vector<T> second)
        {
            return first.Multiply(second);
        }
        public static Vector<T> operator *(Vector<T> first, T second)
        {
            return first.Multiply(second);
        }
        public static Vector<T> operator *(T second, Vector<T> first)
        {
            return first.Multiply(second);
        }

        public static Vector<T> operator -(Vector<T> first, Vector<T> second)
        {
            return first.Substract(second);
        }
        public static Vector<T> operator -(Vector<T> first, T second)
        {
            return first.Substract(second);
        }
        #region NotSupported
        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public void Remove(object value)
        {
            throw new NotSupportedException();
        }
        public void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotSupportedException();
        }
        public void Add(T item)
        {
            throw new NotSupportedException();
        }

        public int Add(object value)
        {
            throw new NotSupportedException();
        }
        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }
        #endregion
    }
}
