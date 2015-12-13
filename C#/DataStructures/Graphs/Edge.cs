using System;
using System.Linq;
using DataStructures.Graphs.Interfaces;

namespace DataStructures.Graphs
{
    public class Edge<T> : DirectedEdge<T>
    {
        public Edge(IVertex<T> v1, IVertex<T> v2) : base(v1, v2, Direction.Double)
        {
        }

    }
}
