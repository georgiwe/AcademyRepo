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
                                                        
        int[] first = new int[firstStr.Length];     // maybe this should
        int[] second = new int[secondStr.Length];   // have been inside
                                                    // the Main method?
        for (int i = 0; i < padTo; i++)
        {                                           // I can do this, because 
            first[i] = (int)firstStr[i] - 48;       // it is said that
            second[i] = (int)secondStr[i] - 48;     // we only need to add up
        }                                           // positive integers

        Array.Reverse(first);
        Array.Reverse(second);

        int[] result = new int[padTo + 1];
        int carryOver = 0;

        for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
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
