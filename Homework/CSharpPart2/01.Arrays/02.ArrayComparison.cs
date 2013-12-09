// Write a program that reads two arrays from the console and compares them element by element

using System;

class ArrayComparison
{
    static void Main()
    {
        Console.Write("How many elements for array one: ");
        int m = int.Parse(Console.ReadLine());

        Console.Write("How many elements for array two: ");
        int n = int.Parse(Console.ReadLine());

        // I am using a string array, so that it can compare both numbers and letters
        string[] arrayOne = new string[m];
        string[] arrayTwo = new string[n];

        Console.WriteLine();
        int count = Math.Min(m, n);

        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter element {0} for array ONE: ", i);
            arrayOne[i] = Console.ReadLine().Replace(" ", "");
            Console.Write("Enter element {0} for array TWO: ", i);
            arrayTwo[i] = Console.ReadLine().Replace(" ", "");

            int zero = 0;
            Console.Write("The elements with index {0} are ", i);
            if (int.TryParse(arrayOne[i], out zero) &&                               // We make sure that 000
                int.TryParse(arrayTwo[i], out zero)) Console.WriteLine("the same."); // and 0 are the same thing.
            else if (arrayOne[i] == arrayTwo[i]) Console.WriteLine("the same.");     // If both elements are not 0,
            else Console.WriteLine("not the same.");                                 // we compare them.

            Console.WriteLine();
        }

        if (m != n)
        {
            Console.Write("The two arrays have different sizes, ");
            Console.WriteLine("so we only compared their first {0} members.", count);
            Console.WriteLine("Make of that as you wish.");
        }
    }
}
