using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DataStructures.Graphs.Interfaces
{
    public interface IVertex<T> : IEnumerable<IVertex<T>>, IEquatable<IVertex<T>>
    {  
        bool IsAdjacent(IVertex<T> vertex);
        IEnumerable<IVertex<T>> Neighbors();
        T Value { get; set; } 
        void Connect(IVertex<T> vertex);
    }
}
