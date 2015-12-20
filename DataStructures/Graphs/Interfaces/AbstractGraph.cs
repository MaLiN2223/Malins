using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Graphs.Interfaces
{
    /// <summary>
    /// Abstract graph
    /// </summary>
    /// <typeparam name="T">Type of vertices value</typeparam>
    public abstract class AbstractGraph<T> : IGraph<T>
    {
        /// <summary> 
        ///     Returns an enumerator that iterates through adjency list.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the IVertex{T} adjency list. </returns>
        public abstract IEnumerator<IVertex<T>> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Returns number of vertices in graph
        /// </summary>
        public int VerticesCount { get; protected set; }
        /// <summary>
        /// Returns number of edges in graph
        /// </summary>
        public int EdgesCount { get; protected set; }
        /// <summary>
        ///     Returns an enumerator that iterates through adjency list of vertex.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the vertex adjency list. </returns>
        public IEnumerable<IVertex<T>> adjency(IVertex<T> vertex)
        {
            return vertex.Neighbors();
        }
        /// <summary>
        /// Returns depth first search list of graph starting from vertex
        /// </summary>
        /// <param name="vertex">Start vertex</param>
        /// <returns>Linked list of vertices in depth first search order</returns>
        public LinkedList<IVertex<T>> GetDfs(IVertex<T> vertex)
        {
            var vertices = new LinkedList<IVertex<T>>();
            foreach (var v in vertex.Neighbors())
            {
                vertices.AddLast(v);
                var list = GetDfs(v);
                foreach (var listItem in list)
                {
                    vertices.AddLast(listItem);
                }
            }
            return vertices;
        }
        /// <summary>
        /// Returns breath first search list of graph starting from vertex
        /// </summary>
        /// <param name="vertex">Start vertex</param>
        /// <returns>Linked list of vertices in breath first search order</returns>
        public LinkedList<IVertex<T>> GetBfs(IVertex<T> vertex)
        {
            var vertices = new LinkedList<IVertex<T>>();
            foreach (var v in vertex.Neighbors())
            {
                vertices.AddLast(v);
            }
            foreach (var listItem in vertex.Neighbors().Select(GetBfs).SelectMany(list => list))
            {
                vertices.AddLast(listItem);
            }
            return vertices;
        }
    }
}