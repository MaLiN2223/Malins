using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataStructures.Graphs.Interfaces;

namespace DataStructures.Graphs
{
    public class AdjencyListVertex<T> : IVertex<T>
    {
        List<IVertex<T>> _vertices = new List<IVertex<T>>();
        public AdjencyListVertex(T value)
        {
            Value = value;
        }
        public bool IsAdjacent(IVertex<T> vertex)
        {
            return _vertices.Contains(vertex);
        }
        public IEnumerable<IVertex<T>> Neighbors()
        {
            return _vertices;
        }
        public T Value { get; set; }

        internal static void Connect(AdjencyListVertex<T> v1, AdjencyListVertex<T> v2)
        {
            if (v1 == null)
                throw new ArgumentException("Wrong vertex type!");
            v1._vertices.Add(v2);
            v2._vertices.Add(v1);
        }
        public void Connect(IVertex<T> vertex)
        {
            if (ReferenceEquals(vertex, this))
                throw new ArgumentException("Cannot add himself");
            if (vertex == null)
                throw new ArgumentException("Can't add null");
            if (!_vertices.Contains(vertex))
            {
                Connect(vertex as AdjencyListVertex<T>, this);
            }
            else
            {
                Debug.WriteLine(_vertices.Count);
                throw new ArgumentException("Vertices are already connected");
            }
        }
        public IEnumerator<IVertex<T>> GetEnumerator()
        {
            return _vertices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Equals(IVertex<T> other)
        {
            return ReferenceEquals(other, this);
        }
    }
}
