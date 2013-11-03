using System;
using System.Text;

class Triangle
{
    static void Main()
    {
        int numberOfSymbols = 1;
        int numberOfSpaces = 2;

        Console.OutputEncoding = Encoding.Unicode;

        for (int i = 0; i < 3; i++)
        {
            Console.Write(new string(' ', numberOfSpaces));
            Console.Write(new string((char)169, numberOfSymbols));
            Console.Write(new string(' ', numberOfSpaces));
            Console.WriteLine();

            numberOfSpaces--;
            numberOfSymbols += 2;
        }
    }
}
