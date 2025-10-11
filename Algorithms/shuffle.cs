namespace Algorithms
{
    public class Shuffle
    {

        /*
        *   The algorithm loops backward through the 
        *   then it picks a random number between 
        *   0 and the current index (i)
        *   Then it swaps those two elements
        *   The process is repeated until even number has 
        *   been swapped once
        */
        public static void FisherYates<T>(List<T> numbers)
        {
            Random rnd = new Random();

            for (int i = numbers.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);

                T temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }
        }
    }
}