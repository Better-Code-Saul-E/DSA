namespace DSA.DataStructures
{
    class CustomStack<T>
    {
        private T[] data = new T[5];
        private int size = 0;
        public int Size => size;




        public void Push(T val)
        {
            if (size == data.Length)
            {
                Array.Resize(ref data, size + 1);
            }

            data[size++] = val;
        }

        public T Pop()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Emtpy Sack");
            }

            return data[--size];
        }
        public T Peek()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Emtpy Sack");
            }

            return data[size - 1];
        }
        public bool IsEmpty()
        {
            return size == 0;
        }
    }
}