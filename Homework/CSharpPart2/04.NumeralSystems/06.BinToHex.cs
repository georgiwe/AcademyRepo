// Write a program to convert binary numbers to hexadecimal numbers

using System;

class BinToHex
{
    static void Main()
    {
        //Console.WriteLine("The hexadecimal value is " + BinaryToHex(Console.ReadLine().TrimStart('0')));
        Console.WriteLine(BinaryToHex("1010101011001111111"));
    }

    static string BinaryToHex(string bin)
    {
        if (bin == "0" || bin == "1") return bin;

        int padTo = (bin.Length / 4 + 1) * 4; // Pad left side so we have a string length
        bin = bin.PadLeft(padTo, '0');        // that is divisable by 4 with no remainder.
        string result = "";

        for (int i = 0; i < bin.Length; i += 4) // Cycle through the segments with length 4.
        {
            string addition = bin.Substring(i, 4); // Extracts a string with length 4 from "bin".
            int currResult = 0; // Keeps the current number, delivered from the abovementioned binary number.

            for (int ii = addition.Length - 1; ii >= 0; ii--) // Gets each digit of the binary segment,
            {                                                 // in order to produce one hexadecimal digit.
                if (addition[ii] == '0') continue; // Skipping zeros.
                
                int value = (int)Math.Pow(2, (addition.Length - 1) - ii);
                
                currResult += value;
            }

            char[] chars = { 'A', 'B', 'C', 'D', 'E', 'F' };

            if (currResult > 9) result += chars[currResult - 10]; // Add the current hexadecimal digit
            else result += currResult;                            // to the final result.
        }

        return result;
    }
}
