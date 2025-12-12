namespace DSA.Algorithms
{
    public class Sorting
    {
        /*
        Bubble sort swifts through every pair in the list and compares.
        if they are in the wrong order, it swaps them.
        */
        public static void BubbleSort(List<int> integers)
        {
            int amount = integers.Count;

            for(int i = 0; i < amount - 1; i++)
            {
                for(int j = 0; j < amount - i - 1; j++)
                {
                    if(integers[j] > integers[j + 1])
                    {
                        (integers[j], integers[j + 1]) = (integers[j + 1], integers[j]);
                    }
                }
            }
        }

        /*
        Insertion sort makes a sorted list one elemnt at a time
        It takes the current element and inserts in into the position 
        corrent position from what is already sorted
        */
        public static void InsertionSort(List<int> integers)
        {
            for(int i = 1; i < integers.Count; i++)
            {
                int key = integers[i];
                int j = i - 1;

                while(j >= 0 && integers[j] > key)
                {
                    integers[j + 1] = integers[j];
                    j--;
                }
                integers[j + 1] = key;
            }
        }

        /*
        Selection sort finds the smallest elemnt and swaps it
        with an element of an unsorted section
        */
        public static void SelectionSort(List<int> integers)
        {
            int amount = integers.Count;

            for(int i = 0; i < amount - 1; i++)
            {
                int minIndex = i;

                for(int j = i + 1; j < amount; j++)
                {
                    if(integers[j] < integers[minIndex])
                    {
                        minIndex = j;
                    }
                }
                
                (integers[i], integers[minIndex]) = (integers[minIndex], integers[i]);
            }
        }



    }
}