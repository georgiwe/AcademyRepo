using System;
using System.Diagnostics;
using System.Text;

class Eratosthenes
{
    static void Main()
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();

        int[] numbers = new int[80];

        for (int p = 2; p < Math.Sqrt(numbers.Length); p++)
            if (numbers[p] == 0) // means it's unmarked, means it's prime
                for (int j = 2 * p; j < numbers.Length; j += p) // counts to 10 000 000 in increments of p and marks nums
                    numbers[j]++;

        StringBuilder sb = new StringBuilder();

        for (int i = 2; i < numbers.Length; i++)
            if (numbers[i] == 0) sb.Append(i + "\n");

        Console.WriteLine(sb);

        sw.Stop();

        Console.WriteLine(sw.Elapsed);
    }
}
