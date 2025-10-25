using System;
using DSA.Algorithms;
using DSA.DataStructures;


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





            // end of main
        }
    }
}
