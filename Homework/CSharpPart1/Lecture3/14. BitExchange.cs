using System;

        // * Write a program that exchanges bits {p, p+1, …, p+k-1) 
        // with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.


class BitExchange
{
    static void Main()
    {   // input
        Console.Write("We are messing with the bits of what positive integer? ");
        uint number = uint.Parse(Console.ReadLine());
        Console.Write("The utmost right bit we start switching from: ");
        int frontStartingBit = int.Parse(Console.ReadLine());
        Console.Write("The utmost left bit we start switching from: ");
        int endStartingBit = int.Parse(Console.ReadLine());
        Console.Write("How many bits are we switching? : ");
        int numberOfBitsToChange = int.Parse(Console.ReadLine());
        int resultNumber = (int) number;

        // presenting the number, divided in sequences of 4 bits
        string numberBitwise = Convert.ToString(number, 2).PadLeft(32, '0');
        string numberBitwiseSorted = "";

        for (int i = 0; i < numberBitwise.Length; i++)
        {
            if (i % 4 == 0) numberBitwiseSorted = numberBitwiseSorted + " " + numberBitwise[i];
            else numberBitwiseSorted = numberBitwiseSorted + numberBitwise[i];
        }

        Console.WriteLine("\n\n{0} {1,15} {2, 4} {3, 4} {4, 4} {5, 4} {6, 4} {7, 3} {8, 4}","", 32, 28, 24, 20, 16, 12, 8, 4);
        Console.WriteLine("{0, 11} ={1, 32}", number, numberBitwiseSorted);

        // the bit exchange
        for (int i = -1; i < numberOfBitsToChange - 1; i++)
        {
            int mask = 1 << frontStartingBit + i;
            mask = resultNumber & mask;
            int frontBit = mask >> frontStartingBit + i;

            mask = 1 << endStartingBit + i;
            mask =  resultNumber & mask;
            int endBit = mask >> endStartingBit + i;

            if (frontBit == endBit) continue;           // checks if bits are identical. if not,
            if (frontBit == 1)                          // checks if one bit is 1. that means that
            {                                           // the other is 0. then switches each to the opposite
                mask = 1 << endStartingBit + i;
                resultNumber = (resultNumber | mask);

                mask = 1 << frontStartingBit + i;
                resultNumber = (resultNumber & ~mask);
            }
            else                                        // checks if the other one is 1 and 
            {                                           // switches the each bit to the opposite
                mask = 1 << endStartingBit + i;
                resultNumber = (resultNumber & ~mask);

                mask = 1 << frontStartingBit + i;
                resultNumber = (resultNumber | mask);
            }
        }

        // converts the resulting number into binary, separated in 4 bit sequences
        numberBitwise = Convert.ToString(resultNumber, 2).PadLeft(32, '0');
        numberBitwiseSorted = "";

        for (int i = 0; i < numberBitwise.Length; i++)
        {
            if (i % 4 == 0) numberBitwiseSorted = numberBitwiseSorted + " " + numberBitwise[i];
            else numberBitwiseSorted = numberBitwiseSorted + numberBitwise[i];
        }
        // prints the resulting number and its string representation
        Console.WriteLine("{0, 11} ={1, 32}", resultNumber, numberBitwiseSorted);
    }
}
