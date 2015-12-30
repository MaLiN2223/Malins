using System;

namespace DataStructures.Graphs.Interfaces
{
    internal interface IWeightedGraph<T1, T2> : IGraph<T1> where T2 : IComparable<T2> 
    {
    }
}