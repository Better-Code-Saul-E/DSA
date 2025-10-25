namespace DSA.Algorithms
{

    static class BigONotation
    {
        // Constant o(1)
        /*
            Regardless of how big the List<int> is it will always 
            take the same amount of time to return the first element.
        */
        public static int GetFirstElement(List<int> integers)
        {
            return integers[0];
        }

        // Linear o(n)
        /*
            This method cannot skip values, It will have to sift through every 
            possible value in the List<int> in order to discover if it contains 
            the value you are looking for
        */
        public static bool ContainsValue(List<int> integers, int value)
        {
            foreach (int integer in integers)
            {
                if (integer == value)
                {
                    return true;
                }
            }
            return false;
        }

        // Quadratic o(n^2)
        /*
        Each element must be compared with every other element to discover 
        any duplicates. This nested loop grows proportionally to 
        the number of elements n * n
        */
        public static List<int> GetDuplicates(List<int> integers)
        {
            List<int> duplicates = new List<int>();

            for (int i = 0; i < integers.Count; i++)
            {
                for (int j = i + 1; j < integers.Count; j++)
                {
                    int dupe = integers[i];
                    if (dupe == integers[j] && !duplicates.Contains(dupe))
                    {
                        duplicates.Add(dupe);
                    }
                }
            }
            return duplicates;
        }

    }
}