using System.Collections.Generic;

namespace DataStructures.Graphs.Interfaces
{
    internal interface IGraph<T> : IEnumerable<IVertex<T>>
    {
        int VerticesCount { get; }
        int EdgesCount { get; }
        IEnumerable<IVertex<T>> adjency(IVertex<T> vertex);
    }
}