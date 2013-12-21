using System;

class DigitToWord
{
    static void GetLatsDigit(int number)
    {
        string[] digitNames = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

        var digit = number.ToString()[number.ToString().Length - 1] - 48;

        Console.WriteLine(digitNames[digit]);
    }

    static void Main()
    {
        GetLatsDigit(int.Parse(Console.ReadLine()));
    }
}
