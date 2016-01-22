namespace DataStructures.Graphs.Interfaces
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     Abstract graph
    /// </summary>
    /// <typeparam name="T">Type of vertices value</typeparam>
    public abstract class AbstractGraph<T> : IGraph<T>
    {

        /// <summary>
        ///     Returns number of vertices in graph
        /// </summary>
        public int VerticesCount { get; protected set; }

        /// <summary>
        ///     Returns number of edges in graph
        /// </summary>
        public int EdgesCount { get; protected set; }

        public virtual IVertex<T> Root { get; set; }
        public abstract bool HasRoot();
        public abstract void SetRoot(T d);
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
        ///     Returns an enumerator that iterates through adjency list of vertex.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the vertex adjency list. </returns>
        public IEnumerable<IVertex<T>> Adjency(IVertex<T> vertex)
        {
            return vertex.Neighbors();
        }

        public abstract IVertex<T> GetVertex(T data);

        /// <summary>
        ///     Returns depth first search list of graph starting from vertex
        /// </summary>
        /// <param name="vertex">Start vertex</param>
        /// <returns>Linked list of vertices in depth first search order</returns>
        public List<IVertex<T>> GetDfs(IVertex<T> vertex)
        {
            var visited = new HashSet<T>();
            var vertices = new List<IVertex<T>>();
            var stack = new Stack<IVertex<T>>(VerticesCount/2);
            stack.Push(vertex);
            while (stack.Count > 0)
            {
                var data = stack.Pop();
                if (visited.Contains(data.Value))
                    continue;
                vertices.Add(data);
                visited.Add(data.Value);
                //Debug.WriteLine(data.Value + " laczy sie z " + data.Neighbors().Aggregate("", (current, nr) => current + nr.Value + " "));      
                foreach (var inner in data.Where(inner => !visited.Contains(inner.Value)))
                {
                    stack.Push(inner);
                }
                // Debug.WriteLine("Stack " + stack.Aggregate("", (current, nr) => current + nr.Value + " "));
            }


            return vertices;
        }

        public List<IVertex<T>> GetDfs()
        {
            if (!HasRoot())
                throw new ArgumentException("No root available");

            return GetDfs(Root);
        }

        public List<IVertex<T>> GetBfs()
        {
            if (!HasRoot())
                throw new ArgumentException("No root available");

            return GetBfs(this.Root);
        }

        /// <summary>
        ///     Returns breath first search list of graph starting from vertex
        /// </summary>
        /// <param name="vertex">Start vertex</param>
        /// <returns>Linked list of vertices in breath first search order</returns>
        public List<IVertex<T>> GetBfs(IVertex<T> vertex)
        {
            var visited = new HashSet<T>();
            var vertices = new List<IVertex<T>>();
            var queue = new LinkedList<IVertex<T>>();
            queue.AddLast(vertex);
            while (queue.Count > 0)
            {
                var data = queue.First.Value;
                queue.RemoveFirst();
                if (visited.Contains(data.Value))
                    continue;
                vertices.Add(data);
                visited.Add(data.Value);
                foreach (var inner in data.Where(inner => !visited.Contains(inner.Value)))
                {
                    queue.AddLast(inner);
                }
            }
            return vertices;
        }
    }
}