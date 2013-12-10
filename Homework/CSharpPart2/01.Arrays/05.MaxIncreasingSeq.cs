using System;
using System.Collections.Generic;

class MaxIncreasingSeq
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
            numbers[i] = int.Parse(Console.ReadLine());

        List<int> currentResult = new List<int>();
        int maxResultLength = currentResult.Count;
        List<List<int>> results = new List<List<int>>();

        for (int i = 1; i < n; i++)
        {
            currentResult = new List<int>();

            bool beenInside = false;

            while (numbers[i] - numbers[i - 1] == 1)
            {
                currentResult.Add(numbers[i - 1]);
                i++;
                beenInside = true;
                if (i > n - 1) break;
            }

            if (beenInside && numbers[i - 1] - numbers[i - 2] == 1) currentResult.Add(numbers[i - 1]);

            if (currentResult.Count > 1)
            {
                results.Add(currentResult);
                i--;
            }

            if (i >= n - 1) i = n - 1;
        }

        Console.WriteLine();
        int maxValue = results[0].Count;
        int maxIndex = 0;

        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].Count >= maxValue)
            {
                maxValue = results[i].Count;
                maxIndex = i;
            }
        }

        for (int i = 0; i < results[maxIndex].Count; i++)
        {
            if (i != results[maxIndex].Count - 1) Console.Write(results[maxIndex][i] + ", ");
            else Console.Write(results[maxIndex][i] + ".");
        }

        Console.WriteLine();
    }
}
