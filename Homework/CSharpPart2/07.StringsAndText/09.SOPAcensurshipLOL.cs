// We are given a string containing a list of forbidden words and a text 
// containing some of these words. Write a program that replaces the forbidden words with asterisks.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class CensurshipSOPAwhuuut
{
    static void Main()
    {
        string text = "Microsoft announced its next generation PHP compiler today. It is " + 
            "based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

        string rawForbWords = "PHP, CLR, Microsoft";
        
        // Extract only words from the string.
        string[] forbWords = rawForbWords.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        string pattern = String.Join("|", forbWords); // Join them so they form a Regex pattern to search with.
        
        // Find all matches of all words through the text.
        MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

        var used = new List<string>(); // This will hold every word that we
                                       // have already replaced in the text.
        foreach (Match match in matches)
        {
            if (used.Contains(match.Value) == false) // Check if we have already replaced all
            {                                        // occurances of the word in the text.
                text = text.Replace(match.Value, new string('*', match.Value.Length));
                used.Add(match.Value);  // If not, we substitute and add it to the list of used words.
            }                          // This saves us having to substitute the same word multiple times
        }                             // and also saves blindly substituting with words that are not in the text.
        
        Console.WriteLine(text);
    }
}
