namespace DSA.DataStructures
{
    class CustomQueue<T>
    {
        private T[] data;
        private int head;
        private int tail;
        private int count;
        public int Size => count;

        public CustomQueue(int capacity = 5)
        {
            data = new T[capacity];
            head = 0;
            tail = 0;
            count = 0;
        }

        public void Enqueue(T item)
        {
            if (count == data.Length)
            {
                Resize(data.Length + 1);
            }

            data[tail] = item;
            tail = (tail + 1) % data.Length;
            count++;
        }
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is emtpy");
            }

            T item = data[head];
            head = (head + 1) % data.Length;
            count--;

            return item;
        }
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is emtpy");
            }

            return data[head];
        }
        public bool IsEmpty()
        {
            return count == 0;
        }

        private void Resize(int capacity)
        {
            T[] newArray = new T[capacity];

            for (int i = 0; i < count; i++)
            {
                newArray[i] = data[(head + i) % data.Length];
            }

            data = newArray;
            head = 0;
            tail = count;
        }

        public void Print()
        {
            Console.Write("Head -> ");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{data[(head + 1) % data.Length]}");
            }

            Console.WriteLine(" <- Tail");
        }

    }
}