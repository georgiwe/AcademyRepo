// Write a program that replaces all occurrences of the substring "start" 
// with the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB)

using System;
using System.IO;

class Replace
{
    static void Main()
    {
        StreamReader reader = new StreamReader("input.txt");
        StreamWriter writer = new StreamWriter("output.txt");

        string line = reader.ReadLine();

        while (line != null)
        {
            writer.WriteLine(line.Replace("start", "finish"));
            line = reader.ReadLine();
        }

        reader.Dispose();
        writer.Dispose();
    }
}
