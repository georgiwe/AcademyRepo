using System;

class BitExchange
{
    static void Main()
    {
        Console.Write("We are messing with the bits of what positive integer? ");
        uint number = uint.Parse(Console.ReadLine());
        Console.Write("The utmost right bit we start switching from: ");
        int frontStartingBit = int.Parse(Console.ReadLine()); 
        Console.Write("The utmost left bit we start switching from: ");
        int endStartingBit = int.Parse(Console.ReadLine());
        Console.Write("How many bits are we switching? : ");
        int numberOfBitsToChange = int.Parse(Console.ReadLine());
        int resultNumber = (int) number;

        string numberBitwise = Convert.ToString(number, 2).PadLeft(32, '0');
        string numberBitwiseSorted = "";

        for (int i = 0; i < numberBitwise.Length; i++)
        {
            if (i % 4 == 0) numberBitwiseSorted = numberBitwiseSorted + " " + numberBitwise[i];
            else numberBitwiseSorted = numberBitwiseSorted + numberBitwise[i];
        }

        Console.WriteLine("\n\n{0} {1,14} {2, 4} {3, 4} {4, 4} {5, 4} {6, 4} {7, 3} {8, 4}","", 32, 28, 24, 20, 16, 12, 8, 4);
        Console.WriteLine("{0,-10} ={1, 32}", number, numberBitwiseSorted);

        for (int i = -1; i < numberOfBitsToChange; i++)
        {
            int mask = 1 << frontStartingBit + i;
            mask = resultNumber & mask;
            int frontBit = mask >> frontStartingBit + i;

            mask = 1 << endStartingBit + i;
            mask =  resultNumber & mask;
            int endBit = mask >> endStartingBit + i;

            if (frontBit == endBit) { continue; }
            if (frontBit == 1)
            {
                mask = 1 << endStartingBit + i;
                resultNumber = (resultNumber | mask);

                mask = 1 << frontStartingBit + i;
                resultNumber = (resultNumber & ~mask);
            }
            else
            {
                mask = 1 << endStartingBit + i;
                resultNumber = (resultNumber & ~mask);

                mask = 1 << frontStartingBit + i;
                resultNumber = (resultNumber | mask);
            }
        }

        numberBitwise = Convert.ToString(resultNumber, 2).PadLeft(32, '0');
        numberBitwiseSorted = "";

        for (int i = 0; i < numberBitwise.Length; i++)
        {
            if (i % 4 == 0) numberBitwiseSorted = numberBitwiseSorted + " " + numberBitwise[i];
            else numberBitwiseSorted = numberBitwiseSorted + numberBitwise[i];
        }

        Console.WriteLine("{0,-10} ={1, 32}", resultNumber, numberBitwiseSorted);
    }
}
