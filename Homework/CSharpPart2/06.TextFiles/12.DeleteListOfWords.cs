// Write a program that removes from a text file all words listed in given another text file.


using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class DeleteListOfWords
{
    static void Main()
    {
        StringBuilder result = new StringBuilder("\\b");

        using (StreamReader wordsToDel = new StreamReader("WordsToDelete.txt"))
        {                                         // I assume there is nothing more than spaces
            string word = wordsToDel.ReadLine();  // around the words in the list to delete.
                                                  // I append all of them, forming a regular expression,
            while (word != null)                  // which features all the words and checks for them
            {                                     // all at once. This way, I only need to traverse the file
                word = word.Trim();               // once, and can write immediately after that.
                result.Append(String.Join("", word, "\\b|\\b"));
                word = wordsToDel.ReadLine();
            }
        }
        // Remove the trailing "|\\b".
        string searchPattern = result.Remove(result.Length - 3, 3).ToString();
        result.Clear(); // Clear the variable, so I can use it again for the end result.

        using (StreamReader inputText = new StreamReader("Text.txt"))
        {
            string textLine = inputText.ReadLine();

            while (textLine != null)
            {   // Check for all words simultaneously and replace them with an empty string
                textLine = Regex.Replace(textLine, searchPattern, "", RegexOptions.IgnoreCase);
                result.AppendLine(textLine);     // Save all text here so I can write it all at once
                textLine = inputText.ReadLine(); // This way, I dont need to open the file
            }                                    // for reading and writing at the same time.
        }

        using (StreamWriter writer = new StreamWriter("Text.txt"))
        {
            writer.Write(result);
        }
    }
}
