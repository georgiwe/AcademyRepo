using System;
using System.Collections.Generic;

class Permutations
{
    static void Work(List<int> elements, string toPrint = "")
     {
        if (toPrint.Length >= elements.Count) return;

        for (int i = 0; i < elements.Count; i++)
        {
            if (toPrint.Contains(elements[i].ToString()) == false) 
            {
                toPrint += elements[i];
                Work(elements, toPrint);

                if (toPrint.Length == elements.Count) Console.WriteLine(toPrint);
                if (toPrint.Length > 0) toPrint = toPrint.Substring(0, toPrint.Length - 1);
            }
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var elements = new List<int>();
        for (int i = 1; i <= n; i++) elements.Add(i);

        Work(elements);
    } 
}
