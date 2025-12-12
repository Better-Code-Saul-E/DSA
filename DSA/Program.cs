using System;
using DSA.Algorithms;
using DSA.DataStructures;


/// make a  custom hanoi tower

namespace DSA
{

    class Program
    {

        static void Main()
        {
            List<int> numbers = new List<int>
        { 1, 2, 3, 4, 5, 6, 7, 8,
        9, 1, 2, 3, 8, 11, 23, 56,
        12, 45, 67, 87, 12, 3, 4,
        87, 23, 45, 1, 1, 34, 90 };

            List<int> orderedNumbers = new List<int>
        {
            1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20
        };


            // Constant
            Console.WriteLine("\n===== Constant =====");
            int firstNum = BigONotation.GetFirstElement(numbers);
            Console.WriteLine("This first element of numbers is: " + firstNum);

            // Linear
            Console.WriteLine("\n===== Linear =====");
            int value = 90;
            bool containsValue = BigONotation.ContainsValue(numbers, value);
            Console.WriteLine($"Does numbers contain the value {value}?: " + containsValue);

            // Quadratic
            Console.WriteLine("\n===== Quadratic =====");
            List<int> duplicates = BigONotation.GetDuplicates(numbers);
            Console.WriteLine("The duplicates in numbers are: " + string.Join(",", duplicates));



            // Fisher Yates
            Console.WriteLine("\n===== Fisher Yates =====");
            Console.WriteLine("Original: " + string.Join(", ", orderedNumbers));
            Shuffle.FisherYates(orderedNumbers);
            Console.WriteLine("Fisher Yates: " + string.Join(", ", orderedNumbers));



            // LinkedList
            orderedNumbers.Sort();
            Console.WriteLine("\n===== Custom Linked List =====");
            CustomLinkedList<int> list = new CustomLinkedList<int>();

            for (int i = 0; i < orderedNumbers.Count; i++)
            {
                int n = orderedNumbers[i];
                if (n % 2 == 0)
                {
                    list.Prepend(n);
                    Console.WriteLine($"Even -> Prepended {n}");
                }
                else if (n % 3 == 0)
                {
                    try
                    {
                        list.DeleteFirst();
                        Console.WriteLine($"Divisible by 3 -> Deleted first");
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Divisible by 3 -> List empty, can't delete first");
                    }
                }
                else if (n % 5 == 0)
                {
                    try
                    {
                        list.DeleteLast();
                        Console.WriteLine($"Divisible by 5 -> Deleted last");
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Divisible by 5 -> List empty, can't delete last");
                    }
                }
                else
                {
                    list.Append(n);
                    Console.WriteLine($"Appended {n}");
                }

                Console.Write("Current List: ");
                list.Print();
                Console.WriteLine($"  (Size: {list.Size})");
            }
            Console.WriteLine("\nFinal List:");
            list.Print();
            Console.WriteLine($"\nFinal size: {list.Size}");





            // Array
            Console.WriteLine("\n===== Custom Array =====");
            CustomArray<int> arr = new CustomArray<int>();

            for (int i = 0; i < orderedNumbers.Count; i++)
            {
                int n = orderedNumbers[i];
                if (n % 2 == 0)
                {
                    list.Prepend(n);
                    Console.WriteLine($"Even -> Prepended {n}");
                }
                else if (n % 3 == 0 && arr.Size > 0)
                {
                    int middle = arr.Size / 2;
                    int deleted = arr.Delete(middle);
                    Console.WriteLine($"Divisible by 3 -> Deleted middle element: {middle}");
                }
                else if (n % 5 == 0 && arr.Size >= 5)
                {
                    int fourthElement = arr.Index(5);
                    Console.WriteLine($"Divisible by 5 -> Indexed 5th element: {fourthElement}");
                }
                else
                {
                    arr.Append(n);
                    Console.WriteLine($"Appended {n}");
                }
                arr.Print();
            }
            Console.WriteLine("\nFinal Array:");
            arr.Print();
            Console.WriteLine($"\nFinal size: {arr.Size}");




            //stack
            Console.WriteLine("\n===== Custom Stack =====");
            CustomStack<int> stack = new CustomStack<int>();
            try
            {
                for (int i = 1; i <= 10; i++)
                {
                    stack.Push(i);
                    Console.WriteLine($"Pushed: {i}, Size:{stack.Size}");
                }
                Console.WriteLine($"Top element: {stack.Peek()}");

                while (!stack.IsEmpty())
                {
                    Console.WriteLine($"Popped: {stack.Pop()}, Size: {stack.Size}");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }




            // Queue
            Console.WriteLine("\n===== Custom Queue =====");
            CustomQueue<string> queue = new CustomQueue<string>();

            try
            {
                string[] names = { "saul", "sal", "sault", "sat", "aul" };

                foreach (var name in names)
                {
                    queue.Enqueue(name);
                    Console.WriteLine($"Enququed: {name}, Size: {queue.Size}");
                }

                Console.WriteLine($"Front: {queue.Peek()}");

                while (!queue.IsEmpty())
                {
                    Console.WriteLine($"Deququed: {queue.Dequeue()}, Size: {queue.Size}");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }


            // Dictionary
            Console.WriteLine("\n===== Custom Dictionary =====");
            CustomDictionary<int, string> dict = new CustomDictionary<int, string>();

            try
            {
                Console.WriteLine("\nAdding values:");
                dict.Add(1, "one");
                dict.Add(2, "two");
                dict.Add(3, "three");
                dict.Add(4, "four");
                dict.Add(5, "five");

                Console.WriteLine("Dictionary Count: " + dict.Size);
                Console.WriteLine("Keys: " + string.Join(", ", dict.Keys()));
                Console.WriteLine("Values: " + string.Join(", ", dict.Values()));

                Console.WriteLine("\nChecking for keys and values");
                Console.WriteLine("ContainsKey(3): " + dict.ContainsKey(3));
                Console.WriteLine("ContainsValue(\"four\"): " + dict.ContainsValue("four"));

                Console.WriteLine("\nRemoving: ");
                dict.Remove(3);
                Console.WriteLine("Removed key 3");
                Console.WriteLine("ContainsKey(3): " + dict.ContainsKey(3));

                Console.WriteLine("Count After Remove: " + dict.Size);
                Console.WriteLine("Keys: " + string.Join(", ", dict.Keys()));
                Console.WriteLine("Values: " + string.Join(", ", dict.Values()));

                dict.Clear();
                Console.WriteLine("Dictionary Cleared!");

                Console.WriteLine("Final Count: " + dict.Size);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<int> bubbleSorted = new List<int>(numbers);
            Sorting.BubbleSort(bubbleSorted);
            Console.WriteLine("Bubble Sort: " + string.Join(", ", bubbleSorted));

            List<int> insertionSorted = new List<int>(numbers);
            Sorting.BubbleSort(insertionSorted);
            Console.WriteLine("Insertion Sort: " + string.Join(", ", insertionSorted));

            List<int> selectionSorted = new List<int>(numbers);
            Sorting.BubbleSort(selectionSorted);
            Console.WriteLine("Selection Sort: " + string.Join(", ", selectionSorted));







            // end of main
        }
    }
}
