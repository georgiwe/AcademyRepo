using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class TestArea
{
    static void Main()
    {
        if (File.Exists("inpp.txt")) Console.SetIn(new StreamReader("inpp.txt"));

        int inpLines = int.Parse(Console.ReadLine());
        string ident = Console.ReadLine();

        var inputText = new StringBuilder();

        for (int i = 0; i < inpLines; i++)
            inputText.AppendLine(Console.ReadLine());

        string txt = Regex.Replace(inputText.ToString(), @" +", " ");

        string[] lines = txt.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        inputText.Clear();

        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = Regex.Replace(lines[i], @"{", "\n{\n");
            lines[i] = Regex.Replace(lines[i], @"}", "\n}\n");

            inputText.AppendLine(lines[i]);
        }

        lines = Regex.Split(inputText.ToString().Replace("\r", ""), "\n");

        for (int i = 0, cnt = 0; i < lines.Length; i++)
        {
            //lines[i].Trim();
            
            //if (lines[i] == " " || lines[i] == "") continue;
            
            lines[i] = Regex.Replace(lines[i], @"(^\s*)|(\s*$)", "");

            if (lines[i] == "") continue;

            if (lines[i][lines[i].Length - 1] == '}') cnt--;

            inputText.Clear();

            for (int j = 0; j < cnt; j++) inputText.Append(ident);

            lines[i] = inputText.ToString() + lines[i];

            if (lines[i][lines[i].Length - 1] == '{') cnt++;

            Console.WriteLine(lines[i]);
        }
    }
}
