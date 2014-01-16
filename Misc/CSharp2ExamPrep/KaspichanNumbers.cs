using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class KaspichanNumbers
{
    static List<string> digits = new List<string>(256);

    static void Main()
    {
        BigInteger num = BigInteger.Parse(Console.ReadLine());

        for (int i = 65; i < 91; i++) digits.Add(((char)i).ToString());

        for (int i = 97; i < 123; i++)
        {
            for (int j = 65; j < 91; j++)
            {
                if (digits.Count == 256) break;

                digits.Add(((char)i).ToString() + (char)j);
            }

            if (digits.Count == 256) break;
        }

        var result = GetKasp(num);

        Console.WriteLine(result);
    }

    static string GetKasp(BigInteger num)
    {
        var result = new StringBuilder();

        do
        {
            int remainder = (int)(num % 256);

            result.Insert(0, digits[remainder]);

            num /= 256;

        } while (num != 0);

        return result.ToString();
    }
}
