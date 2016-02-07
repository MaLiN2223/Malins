namespace DataStructures.Graphs.Interfaces
{
    using System;

    internal interface IWeightedGraph<T1, T2> : IGraph<T1> where T2 : IComparable<T2>
    {
    }
}