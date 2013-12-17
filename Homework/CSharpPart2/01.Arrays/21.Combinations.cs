using System;
using System.Collections.Generic;

class Combinations
{
    static void Work(List<int> elements, int k, int start = 0, string toPrint = "")
    {
        if (toPrint.Length >= k) return;

        for (int i = start; i < elements.Count; i++)
        {
            if (toPrint.Contains(elements[i].ToString()) == false)
            {
                toPrint += elements[i];
                Work(elements, k, i + 1, toPrint);

                if (toPrint.Length == k) Console.WriteLine(toPrint);
                if (toPrint.Length > 0) toPrint = toPrint.Substring(0, toPrint.Length - 1);
            }
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        var elements = new List<int>();
        for (int i = 1; i <= n; i++) elements.Add(i);

        Work(elements, k);
    }
}
