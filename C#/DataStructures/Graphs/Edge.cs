using DataStructures.Graphs.Interfaces;

namespace DataStructures.Graphs
{
    /// <summary>
    /// Not directed, not weight edge
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Edge<T> : DirectedEdge<T>
    {
        /// <summary>
        /// Edge's constructor (order of vertices is not important)
        /// </summary>
        /// <param name="v1">first vertex</param>
        /// <param name="v2">first vertex</param>
        public Edge(IVertex<T> v1, IVertex<T> v2) : base(v1, v2, EdgeDirection.Double)
        {
        }
    }
}