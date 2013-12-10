using System;

class MaxSum
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K, such tha K <= N: ");
        int k = int.Parse(Console.ReadLine());

        if (k > n) { Console.WriteLine("K needs to be no larger than N."); return; }

        int[] array = new int[n];

        for (int i = 0; i < n; i++)
            array[i] = int.Parse(Console.ReadLine());

        Array.Sort(array);

        Console.Write("The elements with the largest sum are: ");
        long sum = 0;

        for (int i = k - 1, index = n - 1; i >= 0; i--, index--)
        {
            if (i == 0) Console.Write(array[index] + ".");
            else Console.Write(array[index] + ", ");
            sum += array[index];
            
        }

        Console.WriteLine(".");
        Console.WriteLine("Their sum is {0}", sum);
    }
}
