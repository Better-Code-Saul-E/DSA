namespace DSA.DataStructures
{
    public class CustomLinkedList<T>
    {
        private Node<T>? head;
        public Node<T>? tail;
        private int count;
        public int Size => count;

        public CustomLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Append(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                tail = newNode;
            }

            count++;
        }
        public void Prepend(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.Next = head;
            head = newNode;
            if (tail == null)
            {
                tail = head;
            }

            count++;
        }
        public void DeleteFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty");
            }

            head = head.Next;
            count--;

            if (head == null)
            {
                tail = null;
            }
        }
        public void DeleteLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is emtpy.");
            }

            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                Node<T>? current = head;
                while (current.Next != tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                tail = current;
            }

            count--;
        }

        public void Print()
        {
            Node<T>? current = head;
            while (current != null)
            {
                Console.Write($"{current.Value} -> ");
                current = current.Next;
            }
            Console.Write("Null");
        }
    }
}