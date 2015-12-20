using System;

namespace DataStructures.Graphs.Interfaces
{
    internal interface IDirectedGraph<T1, T2> : IGraph<T1> where T2 : IComparable<T2>
    {
    }
}