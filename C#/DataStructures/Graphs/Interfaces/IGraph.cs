using System;
using System.Collections.Generic;

namespace DataStructures.Graphs.Interfaces
{
    internal interface IGraph<T> : IEnumerable<IVertex<T>>
    {
        int VerticesCount { get; }
        int EdgesCount { get; }
        IVertex<T> Root { get; }
        bool HasRoot();
        void SetRoot(T d);
        IEnumerable<IVertex<T>> Adjency(IVertex<T> vertex);
        IVertex<T> GetVertex(T data);
    }
}