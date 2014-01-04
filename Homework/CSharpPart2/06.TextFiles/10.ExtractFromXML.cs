// Write a program that extracts from given XML file all the text without the tags

using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractFromXML
{
    static void Main()
    {
        string fileData = File.ReadAllText("xml.txt");
        string searchPattern = @">[^(<.*>)]+?<";

        // Creates an IEnumerable object of class MatchCollection, which contains all the
        // objects of class Match, which contain info (the value, index and so on) about
        // all matches of the pattern, found in the file text.
        MatchCollection matches = Regex.Matches(fileData, searchPattern);

        foreach (Match match in matches) 
            Console.WriteLine(match.Value.Trim(' ', '<', '>'));
    }
}
