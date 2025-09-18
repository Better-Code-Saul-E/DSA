namespace Algorithms;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>
        { 1, 2, 3, 4, 5, 6, 7, 8,
        9, 1, 2, 3, 8, 11, 23, 56,
        12, 45, 67, 87, 12, 3, 4,
        87, 23, 45, 1, 1, 34, 90 };

        // Constant
        int firstNum = BigONotation.GetFirstElement(numbers);
        Console.WriteLine("This first element of numbers is: " + firstNum);

        // Linear
        int value = 90;
        bool containsValue = BigONotation.ContainsValue(numbers, value);
        Console.WriteLine($"Does numbers contain the value {value}?: " + containsValue);

        // Quadratic
        List<int> duplicates = BigONotation.GetDuplicates(numbers);
        Console.WriteLine("The duplicates in numbers are: " + string.Join(",", duplicates));
    }
}
