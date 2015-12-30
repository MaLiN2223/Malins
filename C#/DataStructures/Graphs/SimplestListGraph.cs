using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public SimplestListGraph(AdjencyListVertex<T> root)
        {
            Add(root);
            _root = root;
        }

        public SimplestListGraph(T root) : this(new AdjencyListVertex<T>(root))
        {

        }

        public new int VerticesCount { get { return _vertices.Count; } }
        public new int EdgesCount { get; private set; }
        public override bool HasRoot()
        {
            return _root != null;
        }

        private IVertex<T> _root;
        public override IVertex<T> Root
        {
            get
            {
                return _root;
            }
            set
            {
                if (_vertices.Contains(value))
                    _root = Root;
                else
                    throw new ArgumentException("Root is not in graph!");
            }
        }

        public override void SetRoot(T data)
        {
            _root = _vertices.First(vertex => vertex.Value.Equals(data));
        }

        /// <summary>
        /// Adds vertex to graph
        /// </summary>
        /// <param name="vertex">vertex to add</param>
        /// <exception cref="ArgumentException"></exception>
        public void Add(IVertex<T> vertex)
        {
            var v = vertex as AdjencyListVertex<T>;
            if (v == null || vertex == null || _vertices.Contains(v))
                throw new ArgumentException("Bad vertex");
            _vertices.Add(v);
        }

        public void Add(T vertex)
        {
            Add(new AdjencyListVertex<T>(vertex));
        }

        public override IVertex<T> GetVertex(T data)
        {
            return _vertices.First(v => v.Value.Equals(data));
        }
        /// <summary>
        /// Removes vertex from graph
        /// </summary>
        /// <param name="vertex">vertex to remove</param>
        /// <returns></returns>
        public bool Remove(IVertex<T> vertex)
        {
            int i = 0;
            while (i < VerticesCount)
            {
                if (_vertices[i].Equals(vertex))
                    break;
                ++i;
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
        public bool RemoveEdge(T vertex1, T vertex2)
        {
            IVertex<T> first = null;
            IVertex<T> second = null;
            int i = 0;
            if (vertex1.Equals(vertex2))
                return false;
            while (i < VerticesCount)
            {
                if (_vertices[i].Value.Equals(vertex1))
                    first = _vertices[i];
                else if (_vertices[i].Value.Equals(vertex2))
                    second = _vertices[i];
                else if (second != null && first != null)
                    break;
                ++i;
            }
            if (second == null || first == null)
                return false;
            second.Disconnect(first);
            first.Disconnect(second);
            EdgesCount--;
            return true;
        }
        public bool Remove(T vertex)
        {
            IVertex<T> good = null;
            int i = 0;
            while (i < VerticesCount)
            {
                if (_vertices[i].Value.Equals(vertex))
                {
                    good = _vertices[i];
                    break;
                }
                ++i;
            }
            if (good == null)
                return false;
            foreach (var v in good)
            {
                v.Disconnect(good);
                EdgesCount--;
            }
            _vertices.RemoveAt(i);
            return true;
        }
        public int Degree(IVertex<T> vertex)
        {
            return vertex.Neighbors().Count();
        }
        /// <summary>
        /// Connects vertices in graph
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        public void Connect(IVertex<T> vertex1, IVertex<T> vertex2)
        {
            if (vertex2.Equals(vertex1))
                throw new ArgumentException("Cant connect vertice to itself");
            if (_vertices.Contains(vertex1) && _vertices.Contains(vertex2))
            {
                if (vertex1.Contains(vertex2))
                    throw new ArgumentException("Vertices are already connected");
                vertex1.Connect(vertex2);
                EdgesCount++;
            }
            else
                throw new ArgumentException("Vertices must be in graph");
        }

        public void Connect(T vertex1, T vertex2)
        {
            if (vertex1.Equals(vertex2))
                throw new ArgumentException("Cant connect vertice to itself");
            IVertex<T> first = null;
            IVertex<T> second = null;

            foreach (var data in _vertices)
            {
                if (data.Value.Equals(vertex1))
                {
                    first = data;
                    continue;
                }
                if (data.Value.Equals(vertex2))
                {
                    second = data;
                    continue;
                }
                if (first != null && second != null)
                    break;
            }
            if (first == null || second == null)
                throw new ArgumentException("Vertices must be in graph");
            if (_vertices.Contains(first) && _vertices.Contains(second))
            {
                if (first.Contains(second))
                    throw new ArgumentException("Vertices are already connected");
                first.Connect(second);
                EdgesCount++;
            }
            else
                throw new ArgumentException("Vertices must be in graph");

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