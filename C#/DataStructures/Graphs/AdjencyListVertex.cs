using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.Exceptions;
using DataStructures.Graphs.Interfaces;
 
namespace DataStructures.Graphs
{
    /// <summary>
    /// Class provides Vertex with adjency list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AdjencyListVertex<T> : IVertex<T>
    {
        /// <summary>
        ///     Creates vertex with value
        /// </summary>
        /// <param name="value">Vertex's value</param>
        public AdjencyListVertex(T value)
        {
            Value = value;
        }

        /// <summary>
        ///     Check if current vertex contains other in it's adjency list
        /// </summary>
        /// <param name="other">vertex to check</param>
        /// <returns>true - current vertex contains other</returns>
        public bool IsAdjacent(IVertex<T> other)
        {
            return _vertices.Contains(other);
        }

        /// <summary>
        ///     Returns a IEnumerable collection of adjency list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IVertex<T>> Neighbors()
        {
            return _vertices;
        }

        /// <summary>
        ///     Returns current vertex value
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        ///     Connects current vertex to other
        /// </summary>
        /// <param name="other">vertex to connect.</param>
        /// <exception cref="System.ArgumentException">Thrown when : vertices are connected or trying to connect it self.</exception>
        /// <exception cref="System.NullReferenceException">Thrown when : trying to connect null. </exception>
        /// <exception cref="DataStructures.Exceptions.InvalidArgumentException">Thrown when : other is wrong type. </exception>
        public void Connect(IVertex<T> other)
        {
            if (other == null)
                throw new NullReferenceException("Vertex must not be null");
            if (ReferenceEquals(other, this))
                throw new ArgumentException("Cannot add himself");
            if ((other as AdjencyListVertex<T>) == null)
                throw new InvalidArgumentException("Wrong type");
            if (_vertices.Contains(other))
                throw new ArgumentException("Vertices are already connected");
            Connect((AdjencyListVertex<T>) other, this);
        }

        /// <summary>
        ///     Returns an enumerator that iterates through adjency list.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the IVertex{T} adjency list. </returns>
        public IEnumerator<IVertex<T>> GetEnumerator()
        {
            return _vertices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Connects two vertices one to another.
        /// </summary>
        /// <param name="v1">first to connect</param>
        /// <param name="v2">second to connect</param>
        private static void Connect(AdjencyListVertex<T> v1, AdjencyListVertex<T> v2)
        {
            v1._vertices.Add(v2);
            v2._vertices.Add(v1);
        }

        /// <summary>
        ///     Adjency list for current vertex
        /// </summary>
        private readonly List<IVertex<T>> _vertices = new List<IVertex<T>>();
    }
}