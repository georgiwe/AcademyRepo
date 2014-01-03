// Write a program that deletes from given text file all odd lines. 
// The result should be in the same file.

using System;
using System.IO;

class DeleteOddLines
{
    static void Main()
    {
        var sb = new System.Text.StringBuilder();

        using (StreamReader reader = new StreamReader("Input.txt"))
        {
            string line = reader.ReadLine();
            uint counter = 1; // I start from 1 since it's the first line. 

            while (line != null)
            {
                if (counter++ % 2 != 0) sb.AppendLine(line);
                line = reader.ReadLine();
            }
        }

        using (StreamWriter writer = new StreamWriter("Input.txt"))
        {
            writer.Write(sb);
        }
    }
}
