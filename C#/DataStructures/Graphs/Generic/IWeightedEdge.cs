using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs.Generic
{
    interface IWeightedEdge<T0,T1,T2> where T2: IComparable<T2> where T1: IVertex<T0>
    {
    }
}
