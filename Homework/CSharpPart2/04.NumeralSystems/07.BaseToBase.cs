// Write a program to convert from any numeral system of given base s 
// to any other numeral system of base d (2 ≤ s, d ≤  16).

using System;

class BaseToBase
{
    static void Main()
    {
        Console.WriteLine(ConvFromBaseToBase("8483184".ToUpper(), 10, 36));
    }

    static string ConvFromBaseToBase(string number, int fromBase, int toBase)
    {
        if (fromBase == toBase) return number;

        string result = "";
        long decResult = 0;
        char[] chars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
                         'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', };

        for (int i = number.Length - 1; i >= 0; i--)
            if (number[i] >= 'A') decResult += (number[i] - 55) * (long)BinToDec.Pow(fromBase, number.Length - 1 - i);
            else decResult += (number[i] - 48) * (long)BinToDec.Pow(fromBase, number.Length - 1 - i);

        do
        {
            long remainder = decResult % toBase;

            if (remainder > 9) result = chars[remainder - 10] + result;
            else result = remainder + result;

            decResult /= toBase;
        } while (decResult != 0);

        return result;
    }
}
