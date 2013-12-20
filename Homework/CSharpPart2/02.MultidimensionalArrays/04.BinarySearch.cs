using System;

class BinarySearch
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] integers = new int[n];

        for (int i = 0; i < n; i++) integers[i] = int.Parse(Console.ReadLine());

        int k = int.Parse(Console.ReadLine());

        Array.Sort(integers);

        var resultIndex = Array.BinarySearch(integers, k);

        while ((resultIndex = Array.BinarySearch(integers, k)) < 0) k--;

        Console.WriteLine(integers[resultIndex]);
    }
}
