using System.Collections.Generic; 
namespace DataStructures.Graphs.Generic
{
    interface IGraph<T> : IEnumerable<IVertex<T>>
    {
        int VerticesCount { get; } 
        int EdgesCount { get; }
    }
}
