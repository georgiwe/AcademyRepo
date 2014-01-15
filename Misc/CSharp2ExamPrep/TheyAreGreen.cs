using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class TheyAreGreen
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

        if (letts.Count == n) { Console.WriteLine(Fact(n)); return; }

        var counts = new List<int>(letts.Count);
        var allStr = new string(allLetts);

        for (int i = 0; i < letts.Count; i++)
            counts.Add(Regex.Matches(allStr, letts[i].ToString()).Count);

        var sb = new StringBuilder();
        Solve(letts, counts, sb);

        Console.WriteLine(wordCount);
    }

    static void Solve(List<char> letts, List<int> counts, StringBuilder soFar)
    {
        if (soFar.Length == n) { wordCount++; return; }

        for (int i = 0; i < letts.Count; i++)
        {
            if (counts[i] > 0 && (soFar.Length == 0 || soFar[soFar.Length - 1] != letts[i]))
            {
                soFar.Append(letts[i]);
                counts[i]--;

                Solve(letts, counts, soFar);

                counts[i]++;
                soFar.Length--;
            }
        }
    }

    static long Fact(int n)
    {
        for (int i = n - 1; i >= 2; i--) n *= i;

        return n;
    }
}
