// Write a program that reverses the words in given sentence.
//	Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".

using System;
using System.Text;
using System.Text.RegularExpressions;

class ReverseAsentence
{
    static void Main()
    {
        string text = "For, the 100th    time - C# is not C++, not   PHP, and  not Delphi..?";
        text = Regex.Replace(text, @" {2,}", " ");
        Console.WriteLine(text);

        MatchCollection wordMatches = Regex.Matches(text, @"[^ !,:;\.\?]+");
        MatchCollection punctuationMatches = Regex.Matches(text, @"[,:;]+");

        var result = new StringBuilder(text.Length);
        foreach (Match match in wordMatches) result.Insert(0, match.Value + " ");

        foreach (Match match in punctuationMatches)
        {
            string textSnippet = text.Substring(0, match.Index);
            int spacesCount = Regex.Matches(textSnippet, @" ").Count + 1;
            int insertAtIndex = GetIndexOfNthSpace(result, spacesCount);

            result.Insert(insertAtIndex, match.Value);
        }

        string sentenceEnding = Regex.Match(text, @"[!\.\?(\.\.\.)]+").Value;
        string final = result.ToString().Trim() + sentenceEnding;
        Console.WriteLine(final);
    }

    static int GetIndexOfNthSpace(StringBuilder text, int reqSpaces)
    {
        int result = -1;
        string txt = text.ToString();
        int currSpaceCount = 0;

        do {
            result = txt.IndexOf(" ", result + 1);
            currSpaceCount++;
        } while (result != -1 && currSpaceCount < reqSpaces);

        return result;
    }
}
