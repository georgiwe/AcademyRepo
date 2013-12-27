// Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;

class HexToBin
{
    static void Main()
    {
        Console.WriteLine(HexToBinary(Console.ReadLine().ToUpper()));
    }

    static string HexToBinary(string hex)
    {
        string result = "";
        string addition = "";

        for (int i = hex.Length - 1; i >= 0; i--)
        {
            int value;
            if (hex[i] > 57) value = hex[i] - 65 + 10;
            else value = hex[i] - 48;

            addition = "";
            while (value != 0) // converts the number into binary
            {
                addition = (value & 1).ToString() + addition;
                value >>= 1;
            }

            result = addition.PadLeft(4, '0') + result; // padds the binary representation of the digit
        }                                               // and adds it to the left of the binary number so far

        return result.TrimStart('0');
    }
}
