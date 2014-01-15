using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static int n = 0;
    static int wordCount = 0;

    static void Main()
    {
        n = int.Parse(Console.ReadLine());

        char[] allLetts = new char[n];

        for (int i = 0; i < n; i++)
            allLetts[i] = char.Parse(Console.ReadLine());

        var letts = new List<char>();
        
        for (int i = 0; i < allLetts.Length; i++)
            if (!letts.Contains(allLetts[i])) letts.Add(allLetts[i]);

        //if (letts.Count == n) { Console.WriteLine(Fact(n)); return; }

        var counts = new List<int>(letts.Count);
        string allStr = String.Join("", allLetts);

        for (int i = 0; i < letts.Count; i++)
            counts.Add(Regex.Matches(allStr, letts[i].ToString()).Count);

        var soFar = new char[n];

        Solve(letts, counts, soFar);

        Console.WriteLine(wordCount);
    }

    static void Solve(List<char> letts, List<int> counts, char[] soFar, int index = 0)
    {
        if (index == n) { wordCount++; return; }

        for (int i = 0; i < letts.Count; i++)
        {
            if ((index == 0 || soFar[index - 1] != letts[i]) && counts[i] > 0)
            {
                soFar[index] = letts[i];
                counts[i]--;

                Solve(letts, counts, soFar, index + 1);

                counts[i]++;
                soFar[index] = '0';
            }
        }
    }

    static long Fact(int n)
    {
        for (int i = n - 1; i >= 2; i--) n *= i;

        return n;
    }
}