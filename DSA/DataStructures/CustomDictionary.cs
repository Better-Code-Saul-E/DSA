using System.Collections.Generic;
using System;

namespace DSA.DataStructures
{
    public class CustomDictionary<TKey, TValue>
    {
        private PairedNode<TKey, TValue>? head;
        private int count;
        public int Size => count;

        public bool ContainsKey(TKey key)
        {
            var current = head;
            while (current != null)
            {
                if (current.Key!.Equals(key))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public bool ContainsValue(TValue value)
        {
            var current = head;
            while(current != null)
            {
                if (current.Value!.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                throw new ArgumentException("Duplicate key.");
            }

            var newNode = new PairedNode<TKey, TValue>(key, value);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }

            count++;
        }
        public bool Remove(TKey key)
        {
            PairedNode<TKey, TValue>? previous = null;
            var current = head;

            while (current != null)
            {
                if (current.Key!.Equals(key))
                {
                    if (previous == null)
                    {
                        head = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }

                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }

            return false;
        }
        public void Clear()
        {
            head = null;
            count = 0;
        }
        public List<TKey> Keys()
        {
            var keys = new List<TKey>();
            var current = head;

            while (current != null)
            {
                keys.Add(current.Key);
                current = current.Next;
            }

            return keys;
        }
        public List<TValue> Values()
        {
            var values = new List<TValue>();
            var current = head;

            while (current != null)
            {
                values.Add(current.Value);
                current = current.Next;
            }

            return values;
        }
    }
}