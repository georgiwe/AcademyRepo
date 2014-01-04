// Write a program that extracts from given XML file all the text without the tags

using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractFromXML
{
    static void Main()
    {
        string text = File.ReadAllText("xml.txt");

        MatchCollection matches = Regex.Matches(text, @">[^(<.*>)]+?<", RegexOptions.IgnoreCase);

        foreach (Match match in matches) Console.WriteLine(match.Value.Trim(' ', '<', '>'));
    }
}
