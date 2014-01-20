using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class TestArea
{
    static Stack<dynamic> stack = new Stack<dynamic>();
    static Queue<dynamic> queue = new Queue<dynamic>();

    static void Main()
    {
        if (File.Exists("inpp2.txt")) Console.SetIn(new StreamReader("inpp2.txt"));

        int lines = int.Parse(Console.ReadLine());

        var text = "";

        for (int i = 0; i < lines; i++)
        {
            text += Console.ReadLine();
            text = Regex.Replace(text, @"<del>.*</del>", "");

            bool rec = CheckForNestedTags(text);
            bool write = true;

            while (text.IndexOf('<') != -1)
            {
                FindOpeningTag(new StringBuilder(text), rec: rec);
                FindClosingTag(new StringBuilder(text), rec: rec);

                if (stack.Count == 0 || queue.Count == 0) { write = false; break; }
                var open = stack.Pop();
                var close = queue.Dequeue();

                string subThis = text.Substring(open.Start, close.End - open.Start + 1);
                string subWith = ChoosOp(open.Op, text, open.End + 1, close.Start - 1);

                text = text.Replace(subThis, subWith);

                if (stack.Count == queue.Count)
                {
                    stack.Clear();
                    queue.Clear();
                }
            }

            if (write) { Console.WriteLine(text); text = ""; }
        }
    }

    private static bool CheckForNestedTags(string text)
    {
        bool wut = Regex.IsMatch(text, @"<\w+>[^<]*<[^/]+>");

        return wut;
    }

    static void FindOpeningTag(StringBuilder text, int offset = 0, bool rec = true)
    {
        int stInd = Regex.Match(text.ToString(), @"<\w+>").Index;

        if (text[stInd] != '<') stInd = -1;

        if (stInd == -1) return;

        int endInd = text.ToString().IndexOf('>', stInd);

        var val = new { Op = text.ToString().Substring(stInd, endInd + 1 - stInd), Start = stInd + offset, End = endInd + offset };

        stack.Push(val);

        if (rec) FindOpeningTag(new StringBuilder(text.Remove(0, endInd + 1).ToString()), offset + endInd + 1);
    }

    static void FindClosingTag(StringBuilder text, int offset = 0, bool rec = true)
    {
        int stInd = Regex.Match(text.ToString(), @"</\w+>").Index;

        if (text.Length == 0 || text[stInd + 1] != '/') stInd = -1;

        if (stInd == -1) return; // ??

        int endInd = text.ToString().IndexOf('>', stInd);

        var val = new
        {
            Op = text.ToString().
                Substring(stInd, endInd + 1 - stInd),
            Start = stInd + offset,
            End = endInd + offset
        };

        queue.Enqueue(val);

        if (rec) FindClosingTag(new StringBuilder(text.Remove(0, endInd + 1).ToString()), offset + endInd + 1);
    }

    static string ChoosOp(string op, string text, int stInd, int endInd)
    {
        switch (op)
        {
            case "<rev>": return Rev(text, stInd, endInd);
            case "<upper>": return Upper(text, stInd, endInd);
            case "<lower>": return Lower(text, stInd, endInd);
            case "<toggle>": return Toggle(text, stInd, endInd);

            default: return "from choose op";
        }
    }

    static string Rev(string text, int stInd, int endInd)
    {
        string txt = text.Substring(stInd, endInd - stInd + 1);

        char[] reversed = txt.ToCharArray();
        Array.Reverse(reversed);

        return new string(reversed);
    }

    static string Toggle(string text, int stInd, int endInd)
    {
        var txt = text.Substring(stInd, endInd - stInd + 1);

        char[] doo = txt.ToCharArray();

        for (int i = 0; i < doo.Length; i++)
        {
            if (char.IsLower(doo[i])) doo[i] = (char)(doo[i] - 32);
            else if (char.IsUpper(doo[i])) doo[i] = (char)(doo[i] + 32);
        }

        return new string(doo);
    }

    static string Lower(string text, int stInd, int endInd)
    {
        var txt = text.Substring(stInd, endInd - stInd + 1);

        return txt.ToLower();
    }

    static string Upper(string text, int stInd, int endInd)
    {
        var txt = text.ToString().Substring(stInd, endInd - stInd + 1);

        return txt.ToUpper();
    }
}
