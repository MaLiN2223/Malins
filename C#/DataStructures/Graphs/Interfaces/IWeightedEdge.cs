using System;

namespace DataStructures.Graphs.Interfaces
{
    internal interface IWeightedEdge<T0, out T1> where T1 : IComparable<T1>, IEdge<T0>
    {
        T1 Weight { get; }
    }
}