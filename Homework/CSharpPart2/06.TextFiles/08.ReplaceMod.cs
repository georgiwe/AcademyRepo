// Modify the solution of the previous problem to replace only whole words (not substrings).

using System;
using System.IO;

class ReplaceModification
{
    static void Main()
    {
        StreamReader reader = new StreamReader("input.txt");
        StreamWriter writer = new StreamWriter("output.txt");
        string wordWeSeek = "start";
        string wordWeSubWith = "finish";

        string line = reader.ReadLine();

        while (line != null)
        {
            int index = line.ToLower().IndexOf("start");

            while (index != -1)
            {
                if (index == 0 ||                                   // These check if 
                    (index == (line.Length - wordWeSeek.Length) &&  // the word is first 
                    !char.IsLetterOrDigit(line[index - 1])) ||      // or last on the line.
                    ((index > 0 && index < line.Length - wordWeSeek.Length) && // Otherwise, these check
                    (!char.IsLetterOrDigit(line[index - 1]) &&                 // if the chars on each side of
                    !char.IsLetterOrDigit(line[index + wordWeSeek.Length]))))  // the word are not 
                {   // This produces a new string, with the words exchanged    // letters or digits.
                    line = string.Join("", line.Substring(0, index), wordWeSubWith, line.Substring(index + wordWeSeek.Length));
                }

                index = line.ToLower().IndexOf("start", index + 1);
            }

            writer.WriteLine(line);
            line = reader.ReadLine();

        }

        reader.Dispose();
        writer.Dispose();
    }
}
