using System.Collections.Generic;

namespace DataStructures.Graphs.Generic
{
    interface INotWeightedGraph<T>: IGraph<T> 
    { 
        INotWeightedGraph<T> SubGraph(IVertex<T> root);
        void Add(IVertex<T> vertex);
        void Add(IEdge<T,IVertex<T>> edge);
        bool Remove(IVertex<T> vertex);
        bool Remove(IEdge<T,IVertex<T>> edge);
        int Degree(IVertex<T> vertex);
        IEdge<T, IVertex<T>> Connect(IVertex<T> vertex1, IVertex<T> vertex2); 
        IEnumerable<IVertex<T>> Connected(IVertex<T> vertex);
        IEnumerable<IVertex<T>> SortedVertices();
        IEnumerable<IVertex<T>> SortedEdges();

    }

}
