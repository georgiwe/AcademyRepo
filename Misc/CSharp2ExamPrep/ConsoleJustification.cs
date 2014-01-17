using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class TestArea
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        int width = int.Parse(Console.ReadLine());

        var input = new StringBuilder(lines);

        for (int i = 0; i < lines; i++) input.AppendLine(Console.ReadLine());

        string[] words = input.ToString().Trim(' ', '\n', '\r').Split(" \n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        var linez = new List<string>(lines);

        for (int i = 0, wInd = 0; wInd < words.Length; i++)
        {
            var currLine = new StringBuilder(width);

            while (currLine.Length < width && wInd < words.Length)
            {
                string currWord = words[wInd];

                if (currLine.Length + currWord.Length <= width)
                {
                    currLine.Append(currWord + ' ');
                    wInd++;
                }
                else break;
            }

            if (currLine.Length > 0) linez.Add(currLine.ToString().TrimEnd(' '));
        }

        for (int i = 0; i < linez.Count; i++)
        {
            while (linez[i].Length < width)
            {
                int startInd = 0;
                var currLine = new StringBuilder(linez[i]);

                MatchCollection spaces = Regex.Matches(linez[i], @"\s+");

                if (spaces.Count == 0) break;

                foreach (Match space in spaces)
                    if (currLine.Length < width) currLine.Insert(space.Index + startInd++, ' ');
                    else break;

                linez[i] = currLine.ToString();
            }
        }

        for (int i = 0; i < linez.Count; i++) Console.WriteLine(linez[i]);
    }
}
