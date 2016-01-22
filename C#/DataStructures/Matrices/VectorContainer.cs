namespace DataStructures.Matrices
{
    using System;

    public abstract class VectorContainer<T> where T : struct, IEquatable<T>
    {
        public abstract int Count { get; }

        public T this[int i]
        {
            get
            {
                GoodRange(i);
                return At(i);
            }
            set
            {
                GoodRange(i);
                At(i, value);
            }
        }

        public abstract T At(int i);
        public abstract T At(int i, T value);
        public abstract void Clear();

        private void GoodRange(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException($"{nameof(index)}", index, "Index must be non-negative");
            if (index >= Count)
                throw new ArgumentOutOfRangeException($"{nameof(index)}", index, "Index must be smaller than count");
        }
    }
}