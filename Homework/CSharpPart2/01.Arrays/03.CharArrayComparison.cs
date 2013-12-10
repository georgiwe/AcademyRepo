// Write a program that compares two char arrays lexicographically (letter by letter).

using System;

class CharArrayComparison
{
    static void Main()
    {
        // This program treats the two arrays like words in a dictionary.
        // This means that while both letters are the same, we keep checking the next letter.
        // Once they are different, or the shorter array has been checked, we decide which array comes first.

        Console.Write("Enter the FIRST word (no digits, please): ");
        string wordOne = Console.ReadLine().ToLower();
        wordOne = wordOne[0].ToString().ToUpper() + wordOne.Substring(1).ToLower();
        Console.Write("Enter the SECOND word (no digits, please): ");
        string wordTwo = Console.ReadLine().ToLower();
        wordTwo = wordTwo[0].ToString().ToUpper() + wordTwo.Substring(1).ToLower();

        Console.WriteLine();

        char[] arrayOne = wordOne.ToCharArray();
        char[] arrayTwo = wordTwo.ToCharArray();

        int count = Math.Min(wordOne.Length, wordTwo.Length);

        for (int i = 0; i < count; i++)
        {
            if (arrayOne[i] < arrayTwo[i])
            {
                Console.WriteLine("\"{0}\" is before \"{1}\", in the dictionary.\n", wordOne, wordTwo);
                return; // this means that we are done comparing and the program may terminate
            }
            else if (arrayOne[i] > arrayTwo[i])
            {
                Console.WriteLine("\"{0}\" is before \"{1}\", in the dictionary.\n", wordTwo, wordOne);
                return; // this means that we are done comparing and the program may terminate
            }
        }
        
        if (arrayOne[count - 1] == arrayTwo[count - 1]) // in case the words are identical, up to the
        {                                               // length of the shorter word
            if (wordOne.Length == wordTwo.Length) Console.WriteLine("The two words are identical.");
            else if (wordOne.Length < wordTwo.Length) Console.WriteLine("\"{0}\" is before \"{1}\", in the dictionary.", wordOne, wordTwo);
            else Console.WriteLine("\"{0}\" is before \"{1}\", in the dictionary.", wordTwo, wordOne);
        }

        Console.WriteLine();
    }
}
