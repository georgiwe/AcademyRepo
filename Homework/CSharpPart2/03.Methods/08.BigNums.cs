// Write a method that adds two positive integer numbers represented as arrays 
// of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
// Each of the numbers that will be added could have up to 10 000 digits.

using System;

class BigNums
{
    static int[] SumUp(string firstStr, string secondStr)
    {
        int padTo = Math.Max(firstStr.Length, secondStr.Length);
        firstStr = firstStr.PadLeft(padTo, '0');
        secondStr = secondStr.PadLeft(padTo, '0');

        char[] firstChar = firstStr.ToCharArray();    // maybe this should
        Array.Reverse(firstChar);                     // have been inside
        char[] secondChar = secondStr.ToCharArray();  // the Main method?
        Array.Reverse(secondChar);                    // I can do this, cause 
                                                      // it is said that
        int[] first = new int[firstChar.Length];      // we only need to add up
        int[] second = new int[secondChar.Length];    // positive numbers

        for (int i = 0; i < padTo; i++)
        {
            first[i] = (int)firstChar[i] - 48; // cast for readability :P
            second[i] = (int)secondChar[i] - 48;
        }

        int[] result = new int[padTo + 1];
        int carryOver = 0;

        for (int i = 0; i < padTo; i++)
        {
            result[i] = (first[i] + second[i] + carryOver) % 10;
            carryOver = (first[i] + second[i] + carryOver - result[i]) / 10;
        }

        result[Math.Min(first.Length, second.Length)] += carryOver;

        Array.Reverse(result);
        return result;
    }

    static void Main()
    {
        int[] result = SumUp(Console.ReadLine(), Console.ReadLine());

        Console.WriteLine(String.Join("", result).TrimStart('0'));
    }
}
