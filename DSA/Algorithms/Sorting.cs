namespace DSA.Algorithms
{
    public class Sorting
    {
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