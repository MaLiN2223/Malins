using System;
using DataStructures.Graphs.Interfaces;

namespace DataStructures.Graphs
{
    /// <summary>
    /// Edge with direction
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DirectedEdge<T> : IDirectedEdge<T>
    {
        /// <summary>
        /// Directed edge construction
        /// </summary>
        /// <param name="v1">First vertex</param>
        /// <param name="v2">Second vertex</param>
        /// <param name="dir">Direction</param>
        public DirectedEdge(IVertex<T> v1, IVertex<T> v2, EdgeDirection dir)
        {
            if (v1 == null || v2 == null)
                throw new NullReferenceException("Vertex must not be null");
            EdgeDirection = dir;
            if (dir == EdgeDirection.Right || dir == EdgeDirection.Double)
                v1.Connect(v2);
            if (dir == EdgeDirection.Left)
                v2.Connect(v1);
            First = v1;
            Second = v2;
        }
        /// <summary>
        /// Returns first vertex
        /// </summary>
        public IVertex<T> First { get; } 
        /// <summary>
        /// Returns second vertex
        /// </summary>
        public IVertex<T> Second { get; }
        /// <summary>
        /// Returns edge's direction
        /// </summary>
        public EdgeDirection EdgeDirection { get; }
    } 
}