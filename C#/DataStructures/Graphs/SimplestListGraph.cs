namespace DataStructures.Graphs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    /// <summary>
    ///     Implements Not directed and not weighted graph with adjency list
    /// </summary>
    /// <typeparam name="T">values in vertices</typeparam>
    public class SimplestListGraph<T> : AbstractGraph<T>
    {
        private readonly List<AdjencyListVertex<T>> _vertices = new List<AdjencyListVertex<T>>();

        private IVertex<T> _root;

        public SimplestListGraph()
        {
        }

        public SimplestListGraph(AdjencyListVertex<T> root)
        {
            Add(root);
            this._root = root;
        }

        public SimplestListGraph(T root) : this(new AdjencyListVertex<T>(root))
        {
        }

        public new int VerticesCount
        {
            get { return this._vertices.Count; }
        }

        public new int EdgesCount { get; private set; }

        public override IVertex<T> Root
        {
            get { return this._root; }
            set
            {
                if (this._vertices.Contains(value))
                    this._root = Root;
                else
                    throw new ArgumentException("Root is not in graph!");
            }
        }

        public override bool HasRoot()
        {
            return this._root != null;
        }

        public override void SetRoot(T data)
        {
            this._root = this._vertices.First(vertex => vertex.Value.Equals(data));
        }

        /// <summary>
        ///     Adds vertex to graph
        /// </summary>
        /// <param name="vertex">vertex to add</param>
        /// <exception cref="ArgumentException"></exception>
        public void Add(IVertex<T> vertex)
        {
            var v = vertex as AdjencyListVertex<T>;
            if (v == null || vertex == null || this._vertices.Contains(v))
                throw new ArgumentException("Bad vertex");
            this._vertices.Add(v);
        }

        public void Add(T vertex)
        {
            Add(new AdjencyListVertex<T>(vertex));
        }

        public override IVertex<T> GetVertex(T data)
        {
            return this._vertices.First(v => v.Value.Equals(data));
        }

        /// <summary>
        ///     Removes vertex from graph
        /// </summary>
        /// <param name="vertex">vertex to remove</param>
        /// <returns></returns>
        public bool Remove(IVertex<T> vertex)
        {
            var i = 0;
            while (i < VerticesCount)
            {
                if (this._vertices[i].Equals(vertex))
                    break;
                ++i;
            }
            if (i == VerticesCount)
                return false;
            foreach (var v in this._vertices[i])
            {
                v.Disconnect(this._vertices[i]);
                EdgesCount--;
            }
            this._vertices.RemoveAt(i);
            return true;
        }

        public bool RemoveEdge(T vertex1, T vertex2)
        {
            IVertex<T> first = null;
            IVertex<T> second = null;
            var i = 0;
            if (vertex1.Equals(vertex2))
                return false;
            while (i < VerticesCount)
            {
                if (this._vertices[i].Value.Equals(vertex1))
                    first = this._vertices[i];
                else if (this._vertices[i].Value.Equals(vertex2))
                    second = this._vertices[i];
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
            var i = 0;
            while (i < VerticesCount)
            {
                if (this._vertices[i].Value.Equals(vertex))
                {
                    good = this._vertices[i];
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
            this._vertices.RemoveAt(i);
            return true;
        }

        public int Degree(IVertex<T> vertex)
        {
            return vertex.Neighbors().Count();
        }

        /// <summary>
        ///     Connects vertices in graph
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        public void Connect(IVertex<T> vertex1, IVertex<T> vertex2)
        {
            if (vertex2.Equals(vertex1))
                throw new ArgumentException("Cant connect vertice to itself");
            if (this._vertices.Contains(vertex1) && this._vertices.Contains(vertex2))
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

            foreach (var data in this._vertices)
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
            if (this._vertices.Contains(first) && this._vertices.Contains(second))
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
    }
}