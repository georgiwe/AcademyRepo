// Write a method that asks the user for his name and prints “Hello, <name>” 
// (for example, “Hello, Peter!”). Write a program to test this method.

using System;
using System.Globalization;

class HelloNameLOL
{
    static string Greeting(string name)
    {
        TextInfo ti = new CultureInfo("en-US").TextInfo;

        foreach (var character in name)
            if (!char.IsLetter(character) && !char.IsWhiteSpace(character)) 
                return "Try entering a proper name and then come back!";

        return "Hello, " + ti.ToTitleCase(name) + "!";
    }

    static void Main()
    {
        Console.WriteLine("Enter your name, mofo! And no digits! ");
        Console.WriteLine(Greeting(Console.ReadLine().ToLower()));
    }
}
