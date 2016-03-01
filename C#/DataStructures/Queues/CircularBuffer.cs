namespace DataStructures.Queues
{
    using System; 
    //TODO : Tests
    public class CircularBuffer<T>
    {
        T[] data;
        private int head;
        private int tail;
        private int size;
        private readonly int capacity;

        public bool Empty => size == 0;
        public int MaxSize => capacity;

        public T this[int i]
        {
            get { return data[i]; }
        }
        public CircularBuffer(int capacity = 0)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Size must be not negative");
            data = new T[capacity];
            head = tail = size = 0;
            this.capacity = capacity;
        }

        private void IncrementHead()
        {
            head++;
            if (head == size)
                head = 0;
        }

        private void IncrementTail()
        {
            tail++;
            if (tail == size)
                tail = 0;
        }

        private void DecrementTail()
        {
            tail--;
            if (tail == -1)
                tail = size - 1;
        }

        private void DecrementHead()
        {
            head--;
            if (head == -1)
                head = size - 1;
        }
        public T PopBack()
        {
            var toOut = data[tail];
            data[tail] = default(T);
            DecrementTail();
            return toOut;
        }

        public T PopFront()
        {
            var toOut = data[head];
            data[head] = default(T);
            IncrementTail();
            return toOut;

        }

        public void PushFront(T item)
        {
            if (size == 0)
            {
                data[0] = item;
                size++;
            }
            else
            {
                DecrementHead();
                data[tail] = item;
                if (size == capacity)
                    DecrementTail();
                else
                    size++;
            }
        }

        public void PushBack(T item)
        {
            if (size == 0)
            {
                data[0] = item;
                size++;
            }
            else
            {
                IncrementTail();
                data[tail] = item;
                if (size == capacity)
                    IncrementHead();
                else
                    size++;
            }
        }

    }
}
