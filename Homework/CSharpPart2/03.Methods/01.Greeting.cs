// Write a method that asks the user for his name and prints “Hello, <name>” 
// (for example, “Hello, Peter!”). Write a program to test this method.

using System;
using System.Globalization;

class HelloNameLOL
{
    static void Greeting(string name)
    {
        TextInfo ti = new CultureInfo("en-US").TextInfo;

        foreach (var character in name)
            if (!char.IsLetter(character) && !char.IsWhiteSpace(character)) 
                { Console.WriteLine("Try entering a proper name and then come back!"); return; }

        Console.WriteLine("\nHello, {0}!\n", ti.ToTitleCase(name));
    }

    static void Main()
    {
        Console.WriteLine("Enter your name, mofo! And no digits! ");
        Greeting(Console.ReadLine());
    }
}
