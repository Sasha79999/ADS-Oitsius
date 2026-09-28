using System;

class Lab04
{
    static int comparisons = 0;

    static int LinearSearch(int[] items, int target)
    {
        for (int i = 0; i < items.Length; i++)
        {
            comparisons++;
            if (items[i] == target)
                return i;
        }
        return -1;
    }

    static int BinarySearch(int[] items, int target)
    {
        int low = 0;
        int high = items.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            comparisons++;
            if (items[mid] == target)
                return mid;
            else if (items[mid] < target)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return -1;
    }

    static void Report(string name, int[] items, int target)
    {
        comparisons = 0;
        int index = name == "linear" ? LinearSearch(items, target) : BinarySearch(items, target);
        Console.WriteLine($"{name,-7} target={target,3} index={index,3} comparisons={comparisons}");
    }

    static void Main()
    {
        int[] data = { 42, 8, 60, 19, 3, 55, 12, 31, 68, 24, 49, 37, 71, 5, 27 };
        int[] sortedData = (int[])data.Clone();
        Array.Sort(sortedData);

        Console.WriteLine("sortedData: " + string.Join(", ", sortedData));

        Console.WriteLine("\n=== Частина 2 ===");
        int[] targets = { 3, 71, 31, 1, 99, 50 };
        foreach (var t in targets)
        {
            Report("linear", sortedData, t);
            Report("binary", sortedData, t);
        }

        int[] single = { 42 };
        Report("linear", single, 42);
        Report("binary", single, 42);

        int[] empty = Array.Empty<int>();
        Report("linear", empty, 42);
        Report("binary", empty, 42);

        Console.WriteLine("\n=== Частина 3 ===");
        comparisons = 0;
        int result = BinarySearch(data, 55);
        Console.WriteLine($"binary on unsorted, target=55, index={result}, comparisons={comparisons}");
    }
}
