using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Graphs.Interfaces;

namespace DataStructures.Graphs
{
    /// <summary>
    ///     Implements Not directed and not weighted graph with adjency list
    /// </summary>
    /// <typeparam name="T">values in vertices</typeparam>
    public class SimplestListGraph<T> : AbstractGraph<T>
    {
        /// <summary>
        /// Constuctor
        /// </summary>
        public SimplestListGraph()
        {
        }
        /// <summary>
        /// Construct graph from another
        /// </summary>
        /// <param name="graph"></param>
        public SimplestListGraph(SimplestListGraph<T> graph)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// How many vertices is in graph
        /// </summary>
        public new int VerticesCount { get; private set; }
        /// <summary>
        /// How many edges is in graph
        /// </summary>
        public new int EdgesCount { get; private set; }

        /// <summary>
        /// Adds vertex to graph
        /// </summary>
        /// <param name="vertex">vertex to add</param>
        /// <exception cref="ArgumentException"></exception>
        public void Add(IVertex<T> vertex)
        {
            var v = vertex as AdjencyListVertex<T>;
            if (v == null || vertex == null)
                throw new ArgumentException("Bad vertex");
            _vertices.Add(v);
            VerticesCount++;
        }
        /// <summary>
        /// Adds edge to graph
        /// </summary>
        /// <param name="edge">edge to add</param>
        public void Add(IEdge<T> edge)
        {
            var v1 = edge.First as AdjencyListVertex<T>;
            if (v1 == null)
                throw new ArgumentException("Bad vertex");
            var v2 = edge.Second as AdjencyListVertex<T>;
            if (v2 == null)
                throw new ArgumentException("Bad vertex");
            v1.Connect(v2);
            v2.Connect(v1);
            if (!_vertices.Contains(v1))
            {
                _vertices.Add(v1);
                VerticesCount++;
            }
            if (!_vertices.Contains(v2))
            {
                _vertices.Add(v2);
                VerticesCount++;
            }
            EdgesCount++;
        }
        /// <summary>
        /// Removes vertex from graph
        /// </summary>
        /// <param name="vertex">vertex to remove</param>
        /// <returns></returns>
        public bool Remove(IVertex<T> vertex)
        {
            int i;
            for (i = 0; i < VerticesCount; ++i)
            {
                if (_vertices[i].Equals(vertex))
                    break;
            }
            if (i == VerticesCount)
                return false;
            foreach (var v in _vertices[i])
            {
                v.Disconnect(_vertices[i]);
                EdgesCount--;
            }
            _vertices.RemoveAt(i);
            return true;
        }
        /// <summary>
        /// Removes edge from graph
        /// </summary>
        /// <param name="edge">edge to remove</param>
        /// <returns></returns>
        public bool Remove(IEdge<T> edge)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Degree of vertex
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public int Degree(IVertex<T> vertex)
        {
            return vertex.Neighbors().Count();
        }
        /// <summary>
        /// Connects two vertices with one edge
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        public void Connect(IVertex<T> vertex1, IVertex<T> vertex2)
        {
            if (vertex2.Equals(vertex1))
                throw new ArgumentException("Cant connect vertice to itself");
            if (_vertices.Contains(vertex1) && _vertices.Contains(vertex2))
            {
                if (vertex1.Contains(vertex2) || vertex2.Contains(vertex2))
                    throw new ArgumentException("Vertices are already connected");
                vertex1.Connect(vertex2);
                EdgesCount++;
            }
            else
            {
                throw new ArgumentException("Vertices must be in graph");
            }
        }
        /// <summary>
        /// Returns collection of topologycally sorted vertices
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IVertex<T>> SortedVertices()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns enumerator
        /// </summary>
        /// <returns></returns>
        public override IEnumerator<IVertex<T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private readonly List<AdjencyListVertex<T>> _vertices = new List<AdjencyListVertex<T>>();
    }
}