using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Graphs.Generic
{
    internal abstract class AbstractGraph<T> : IGraph<T>
    {
        public abstract IEnumerator<IVertex<T>> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int VerticesCount { get; private set; }
        public int EdgesCount { get; private set; }
        public IEnumerable<IVertex<T>> getDFS()
        {

            throw new NotImplementedException();
        }
        public IEnumerable<IVertex<T>> getBFS()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IVertex<T>> getDFS(IVertex<T> vertex )
        {

            throw new NotImplementedException();
        }
        public IEnumerable<IVertex<T>> getBFS(IVertex<T> vertex)
        {
            throw new NotImplementedException();
        }

    }
}
