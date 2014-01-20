// Write a program that extracts from a given text all sentences containing given word.

using System;
using System.Text.RegularExpressions;

class ExtractSentences
{
    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. " + 
        "Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

        MatchCollection matches = Regex.Matches(text, @"[^\.]*\bin\b[^\.]*\.", RegexOptions.IgnoreCase);

        foreach (Match match in matches) Console.WriteLine(match.Value.Trim());
    }
}
