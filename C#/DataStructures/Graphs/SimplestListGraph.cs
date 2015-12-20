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
        public SimplestListGraph()
        {
        }

        public SimplestListGraph(SimplestListGraph<T> graph)
        {
            throw new NotImplementedException();
        }

        public new int VerticesCount { get; private set; }
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
        public bool Remove(IEdge<T> edge)
        {
            throw new NotImplementedException();
        }

        public int Degree(IVertex<T> vertex)
        {
            return vertex.Neighbors().Count();
        }

        public void Connect(IVertex<T> vertex1, IVertex<T> vertex2)
        {
            if(vertex2.Equals(vertex2))
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

        public IEnumerable<IVertex<T>> SortedVertices()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<IVertex<T>> SortedEdges()
        {
            throw new NotImplementedException();
        }

        public override IEnumerator<IVertex<T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private readonly List<AdjencyListVertex<T>> _vertices = new List<AdjencyListVertex<T>>();
    }
}