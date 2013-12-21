using System;

class BinarySearch
{
    static void Main()
    {
        Console.Write("Enter N, followed by the elements: ");
        int n = int.Parse(Console.ReadLine());
        int[] integers = new int[n];

        for (int i = 0; i < n; i++) integers[i] = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int k = int.Parse(Console.ReadLine());

        Array.Sort(integers);

        if (k < integers[0]) { Console.WriteLine("K is smaller than all the elements of the array."); return; }
        if (k >= integers[n - 1]) { Console.WriteLine("The largest number is {0} and its index is {1}", integers[n - 1], n - 1); return; }
        // the check for k >= than the last (biggest) numbet of the array saves the binary search
        var index = Array.BinarySearch(integers, k);
        
        if (index < -1) index = ~index - 1;
        
        Console.WriteLine("The largest number <= K is {0} and its index is {1}.", integers[index], index);
    }
}
