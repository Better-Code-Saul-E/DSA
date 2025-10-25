namespace DSA.DataStructures
{
    class CustomArray<T>
    {
        private T[] items;
        private int count;
        public int Size => count;

        public CustomArray(int capacity = 1)
        {
            items = new T[capacity];
            count = 0;
        }

        public void Append(T val)
        {
            if (count == items.Length)
            {
                Resize(Size + 1);
            }

            items[Size] = val;
            count++;
        }
        public void Prepend(T val)
        {
            if (count == items.Length)
            {
                Resize(Size + 1);
            }

            for (int i = Size; i > 0; i--)
            {
                items[i] = items[i - 1];
            }

            items[0] = val;
            count++;
        }
        public T Delete(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException("Trying to access non-existent value");
            }

            T removed = items[index];

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            count--;
            Resize(Size);
            return removed;
        }
        public T Index(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new IndexOutOfRangeException();
            }

            return items[index];
        }
        public void Print()
        {
            Console.Write($"Size: {Size} \n[");
            for (int i = 0; i < Size; i++)
            {
                if (i == Size - 1)
                {
                    Console.Write(items[i]);
                }
                else
                {
                    Console.Write(items[i] + ", ");
                }
            }
            Console.WriteLine("]\n");
        }
        private void Resize(int capacity)
        {
            T[] newArray = new T[capacity];

            for (int i = 0; i < Size; i++)
            {
                newArray[i] = items[i];
            }
            
            items = newArray;
        }
    }
}