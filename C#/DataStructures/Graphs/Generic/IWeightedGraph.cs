using System;
namespace DataStructures.Graphs.Generic
{
    interface IWeightedGraph<T1, T2> :IGraph<T1> where T2 : IComparable<T2>
    {
    }
}
