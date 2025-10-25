namespace DSA.DataStructures
{
    class Stack<T>
    {
        private T[] data = new T[10];
        int size = 0;
        public void Push(T val)
        {
            if (size == data.Length)
            {
                Array.Resize(ref data, size * 2);
                data[size++] = val;
            }
        }
        
        public T Pop()
        {
            if(size == 0)
            {
                throw new InvalidOperationException("Emtpy Sack");
            }
                return data[--size];
        }
    }
}