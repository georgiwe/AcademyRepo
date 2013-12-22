// Write a program that reads an array of integers and removes from it a minimal number of elements 
// in such way that the remaining array is sorted in increasing order. Print the remaining sorted array. 

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class SortedSubarray
{
    static void Main()
    {
        int[] numbers = new int[] { 6, 1, 4, 3, 0, 3, 6, 4, 5, -5, -4, -3, -2, -1 };

        var allSortedSubarrays = new List<List<int>>(); // stores all sorted subarrays
        var subarrayWithMaxLength = new List<int>(); // stores the sorted array with maximum length

        for (int comb = 1; comb < Math.Pow(2, numbers.Length) - 1; comb++)
        {   // cycles through all possible combinations of elements
            var subarray = new List<int>();

            for (int pos = 0; pos < 31; pos++)
                if (((1 << pos) & comb) != 0) subarray.Add(numbers[pos]);

            var subarraySorted = new List<int>();   // creates a new List
            subarraySorted.AddRange(subarray);      // adds all the elements of the current subarray to it
            subarraySorted.Sort();                  // sorts it 

            if (subarray.SequenceEqual(subarraySorted) &&       // .SequenceEqual() checks if... the two 
                subarray.Count > 1 &&                           // sequences are equal. Element by element.
                subarray.Count >= subarrayWithMaxLength.Count)   // It's part of LINQ. Could also do it with a loop.
            {
                subarrayWithMaxLength = subarray;
                allSortedSubarrays.Add(subarray);
            }
        }

        for (int i = 0; i < allSortedSubarrays.Count; i++)
            if (allSortedSubarrays[i].Count == subarrayWithMaxLength.Count)
                Console.WriteLine(String.Join(", ", allSortedSubarrays[i]));
    }
}
