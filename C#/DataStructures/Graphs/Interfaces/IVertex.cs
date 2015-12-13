using System.Collections.Generic;

namespace DataStructures.Graphs.Interfaces
{
    /// <summary>
    /// Interface for vertex
    /// </summary>
    /// <typeparam name="T">Type of value contained by vertex</typeparam>
    public interface IVertex<T> : IEnumerable<IVertex<T>>
    {
        /// <summary>
        /// Value contained by vertex
        /// </summary>
        T Value { get; set; }
        /// <summary>
        /// Checks if other is connected to current vertex
        /// </summary>
        /// <param name="other">other vertex</param>
        /// <returns>true - if {param is adjacent to current vertex </returns>
        bool IsAdjacent(IVertex<T> other);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<IVertex<T>> Neighbors();
        /// <summary>
        /// Connects current vertex to other
        /// </summary>
        /// <param name="other">other vertex to connect</param>
        void Connect(IVertex<T> other);
    }
}