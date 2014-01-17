using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ConsoleJustification
{
    static void Main()
    {
        int numOfLines = int.Parse(Console.ReadLine());
        int lineWidth = int.Parse(Console.ReadLine());

        var input = new StringBuilder(numOfLines);

        for (int i = 0; i < numOfLines; i++) input.AppendLine(Console.ReadLine());

        string[] words = input.ToString().Trim(' ', '\n', '\r').Split(
            "\n \r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        var lines = new List<string>(numOfLines);

        for (int i = 0, wordsInd = 0; wordsInd < words.Length; i++)
        {
            var currLine = new StringBuilder(lineWidth);

            while (currLine.Length < lineWidth && wordsInd < words.Length)
            {
                string currWord = words[wordsInd];

                if (currLine.Length + currWord.Length <= lineWidth)
                {
                    currLine.Append(currWord + ' ');
                    wordsInd++;
                }
                else break;
            }

            if (currLine.Length > 0) lines.Add(currLine.ToString().TrimEnd(' '));
        }

        for (int i = 0; i < lines.Count; i++)
        {
            while (lines[i].Length < lineWidth)
            {
                int indexOffset = 0;
                var currLine = new StringBuilder(lines[i]);

                MatchCollection spaces = Regex.Matches(lines[i], @"\s+");

                if (spaces.Count == 0) break;

                foreach (Match space in spaces)
                    if (currLine.Length < lineWidth) currLine.Insert(space.Index + indexOffset++, ' ');
                    else break;

                lines[i] = currLine.ToString();
            }
        }

        for (int i = 0; i < lines.Count; i++) Console.WriteLine(lines[i]);
    }
}
