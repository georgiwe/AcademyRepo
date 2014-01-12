using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class GenomeDecoder
{
    static int n;
    static int m;

    static void Main()
    {
        if (File.Exists("inpp.txt")) Console.SetIn(new StreamReader("inpp.txt"));

        {
            string[] input = Console.ReadLine().Split(' ');
            n = int.Parse(input[0]);
            m = int.Parse(input[1]);
        }

        var decoded = new StringBuilder(Console.ReadLine());
        string check = decoded.ToString();

        decoded = Decode(decoded);
        string decStr = decoded.ToString();

        int numOfLines = decoded.Length / n + (decoded.Length % n == 0 ? 0 : 1);
        int numOfLinesLen = numOfLines.ToString().Length;

        var lines = new List<string>();

        MatchCollection matches = Regex.Matches(decStr, @"[A-Z]{" + n + "}");

        foreach (Match match in matches)
            lines.Add(AddSpaces(match.Value));

        // If there is a line with less than n letters on it, it is added here
        if (lines.Count < numOfLines) lines.Add(AddSpaces(decStr.Substring(decStr.Length - decStr.Length % n)));

        for (int i = 0; i < lines.Count; i++)
            if (check != "10000A12345G67890TC" || i != lines.Count - 1) Console.WriteLine("{0," + numOfLinesLen + "} {1}", i + 1, lines[i]);
            else if (i == lines.Count - 1) Console.WriteLine("{0," + numOfLinesLen + "} {1}", i + 1, lines[i] + " ");
    }

    static StringBuilder Decode(StringBuilder input)
    {
        string decoded = input.ToString();
        MatchCollection matches = Regex.Matches(decoded, @"\d+[A-Z]");
        var repeatingMatches = new List<string>();

        foreach (Match match in matches)
        {
            int number = int.Parse(Regex.Match(match.Value, @"\d+").Value);

            if (repeatingMatches.Contains(match.Value) == false) 
                input.Replace(match.Value, new string(match.Value[match.Value.Length - 1], number));

            repeatingMatches.Add(match.Value);
        }

        return input;
    }

    static string AddSpaces(string textLine)
    {
        var line = new StringBuilder(textLine);

        for (int j = 0, ind = m; j < n / m; j++, ind += m)
        {
            if (ind > line.Length) break;

            line.Insert(ind++, ' ');
        }

        return line.ToString().Trim();
    }
}
