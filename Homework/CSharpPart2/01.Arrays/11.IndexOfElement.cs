using System;
using System.Collections.Generic;

class IndexOfElement
{
    static void Main()
    {
        Console.Write("How many elements in the array: ");
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {                                                   // array
            Console.Write("Element {0} = ", i);             // input
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(numbers);
        Console.WriteLine("\nThe sorted array is: \n");              // sorting and
        for (int i = 0; i < numbers.Length; i++)                     // printing the
            Console.WriteLine("array[{0}] = {1}", i, numbers[i]);    // sorted array

        Console.Write("\nWe are looking for the index of: ");
        int numWeLookFor = int.Parse(Console.ReadLine());            // we input a number to search for

        Console.WriteLine();
        int firstIndex = 0;
        int lastIndex = numbers.Length - 1;
        int index = (firstIndex + lastIndex) / 2;

        // the actual search
        while (index != firstIndex && index != lastIndex)
        {
            index = (firstIndex + lastIndex) / 2;

            if (numWeLookFor > numbers[index]) firstIndex = index + 1;
            else if (numWeLookFor < numbers[index]) lastIndex = index - 1;
            else
            {
                Console.WriteLine(new string('=', 15) + "\n");
                int newIndex = index;
                var indices = new List<int>();
                int counter = 0;

                while (newIndex >= 0 && numbers[newIndex] == numWeLookFor)
                {
                    indices.Add(newIndex);                    // looking for more matches
                    counter++;                                // to the left
                    newIndex--;                               // since it's a sorted array
                }

                newIndex = index + 1;
                while ((newIndex <= (numbers.Length - 1)) && numbers[newIndex] == numWeLookFor)
                {
                    indices.Add(newIndex);                 // looking for more matches
                    counter++;                             // to the RIGHT
                    newIndex++;                            // since it's a sorted array
                }

                if (counter != 1)
                {
                    Console.WriteLine("Found {0} occurance of the number \"{1}\".", counter, numWeLookFor);
                    Console.Write("Their indices are: ");
                                                                            // making the output
                    indices.Sort();                                         // look all...
                                                                            // nice and pretty
                    for (int i = 0; i < counter; i++)
                    {
                        if (counter == 1) Console.WriteLine("");
                        else if (i < counter - 1) Console.Write(indices[i] + ", ");
                        else Console.WriteLine("\b\b and " + indices[i]);
                    }
                }
                else
                {
                    Console.Write("Found just one occurance of the number \"{0}\" and ", numWeLookFor);
                    Console.WriteLine("its index is {0}.", index);
                }

                Console.WriteLine();
                return;
            }
        }

        Console.WriteLine("{0} is not present in the given array.\n", numWeLookFor);
    }
}
