using System;

class FloatBinRep
{
    static void Main()
    {
        string input = Console.ReadLine();
        float number = float.Parse(input);

        string result = number >= 0 ? "0" : "1";
        
        if (number < 0) number = -number;

        string intPartBin = GetBinaryInt((int)number);
        string floPartBin = GetBinaryFraction(number - (int)number);
                                               // Adding the exponent
        if (intPartBin != "0") result += " " + GetBinaryInt(127 + intPartBin.Length - 1).PadLeft(8, '0');
        else result += " " + GetBinaryInt(127 - (floPartBin.IndexOf('1') + 1)).PadLeft(8, '0');
                                               // Adding the mantissa
        if (intPartBin != "0") result += " " + (intPartBin + floPartBin).Substring(1).PadRight(23, '0');
        else result += " " + (intPartBin + floPartBin).Substring(floPartBin.IndexOf('1') + 2).PadRight(23, '0');

        // If the number entered is 0, we differentiate between "-0" and "0", as per IEEE754.
        if (intPartBin == "0" && floPartBin == "0") result = new string('0', 8) + " " + new string('0', 23);
        if (input[0] == '-' && intPartBin == "0" && floPartBin == "0") result = '1' + result;
        else if (input[0] != '-' && intPartBin == "0" && floPartBin == "0") result = '0' + result;

        Console.WriteLine("S E\t   M");
        Console.WriteLine(result);
    }

    static string GetBinaryInt(int num)
    {
        string result = "";

        do
        {
            result = (num & 1) + result;
            num >>= 1;
        } while (num != 0);

        return result;
    }

    static string GetBinaryFraction(float fl)
    {
        string result = "";

        do
        {
            fl = fl * 2;
            result += (int)fl;
            fl = fl - (int)fl;
        } while (fl != 0 || result.Length == 23); // Because we can only use 23 bits 
                                                  // for the mantissa in a 32 bit float.
        return result;
    }
}
