using System;
using System.Text.RegularExpressions;

class ZERG
{
    static void Main()
    {
        Console.WriteLine(ConvToDec(Console.ReadLine()));
    }

    static int GetDigit(string zerg)
    {
        switch (zerg)
        {
            case "Rawr": return 0;
            case "Rrrr": return 1;
            case "Hsst": return 2;
            case "Ssst": return 3;
            case "Grrr": return 4;
            case "Rarr": return 5;
            case "Mrrr": return 6;
            case "Psst": return 7;
            case "Uaah": return 8;
            case "Uaha": return 9;
            case "Zzzz": return 10;
            case "Bauu": return 11;
            case "Djav": return 12;
            case "Myau": return 13;
            case "Gruh": return 14;
        }

        return -1;
    }

    static long ConvToDec(string input)
    {
        long result = 0;

        MatchCollection digits = Regex.Matches(input, @"([A-Z])([a-z]{3})");

        for (int i = digits.Count - 1; i >= 0; i--)
            result += GetDigit(digits[i].Value) * (long)Math.Pow(15, digits.Count - 1 - i);

        return result;
    }
}
