using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.Graphs.Interfaces;

namespace DataStructures.Graphs
{
    public class AdjencyListVertex<T> : IVertex<T>
    {
        readonly List<IVertex<T>> _vertices = new List<IVertex<T>>();
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
 
        public void Connect(IVertex<T> vertex)
        {
            if (ReferenceEquals(vertex, this))
                throw new ArgumentException("Cannot add himself");
            if(vertex==null)
                throw new ArgumentException("Can't add null");
            if(!_vertices.Contains(vertex))
                _vertices.Add(vertex);
            else 
                throw  new ArgumentException("Vertices are already connected"); 
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
