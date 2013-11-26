using System;

class SubsetSum
{
    static void Main()
    {
        Console.WriteLine("Enter 5 numbers: ");
        int[] numbers = new int[5];

        for (int i = 0; i < 5; i++)
            numbers[i] = int.Parse(Console.ReadLine());

        Console.WriteLine("\nWe are looking for any combination of numbers,\nwhich added up, amounts to 0.\n");

        int lookingForThisSum = 0;
        int counter = 0;
        
        // The idea is, that there are (2^5 - 1 = 31) ways to combine these 5 numbers.
        // We use the binary representation of the numbers between 1 and 31 (00001 to 11111)
        // to indicate which numbers from the 5 entered we use. For example,
        // if we get to 14 (01110) - we use the 2nd, 3rd and 4th numbers, we add them up, and check that sum.

        for (int comb = 1; comb < 32; comb++) // we cycle the numbers 1 to 31
        {
            int sumWeCheckWith = 0; // our sum, created by adding up the numbers in positions where we have 1s
            string combination = ""; // stores the numbers that we are combining

            for (int pos = 0; pos < 5; pos++)
            {
                int mask = 1 << pos;

                if ((mask & comb) != 0) // we check which digits in the binary representation of the
                {                       // current number are 1s
                    sumWeCheckWith += numbers[pos]; // we add the numbers with corresponding positions
                    combination += numbers[pos] + " + "; // we create a string with the numbers to show the combinations
                }
            }

            if (sumWeCheckWith == lookingForThisSum) // we check the sum of the numbers, with positions
            {                                        // corresponding to 1s in the "comb" number
                counter++; // if the sums match - we increase the counter
                Console.WriteLine("{0}\b\b= {1}", combination, lookingForThisSum); // we print the combination
            }
        }

        Console.WriteLine("\nI counted {0} combinations there. You?\n\n", counter); // we print the number of combinations
    }
}
