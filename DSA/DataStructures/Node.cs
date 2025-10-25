namespace DSA.DataStructures
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Next { get; set; }
        public Node(T data)
        {
            Value = data;
            Next = null;
        }
    }
}