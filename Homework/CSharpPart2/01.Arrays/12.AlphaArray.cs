using System;
class AlphaArray
{
    static void Main()
    {
        char[] alphabet = new char[]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
            'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R',
            'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        string word = Console.ReadLine().ToUpper();

        for (int i = 0; i < word.Length; i++)
            Console.WriteLine("alphabet[{0}] \t= \"{1}\"", word[i] - 65, alphabet[word[i] - 65]);
    }
}
