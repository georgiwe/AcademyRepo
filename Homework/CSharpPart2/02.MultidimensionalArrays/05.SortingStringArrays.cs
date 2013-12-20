// You are given an array of strings. Write a method that sorts the array 
// by the length of its elements (the number of characters composing them).

using System;
using System.Collections.Generic;

class SortingStringArrays
{
    static string[] Qsort(string[] arr)
    {
        if (arr.Length <= 1) return arr;

        string pivot = arr[arr.Length - 1];

        var shorter = new List<string>();
        var longer = new List<string>();

        for (int i = 0; i < arr.Length - 1; i++)
            if (arr[i].Length < pivot.Length) shorter.Add(arr[i]);
            else longer.Add(arr[i]);

        shorter = new List<string>(Qsort(shorter.ToArray()));
        longer = new List<string>(Qsort(longer.ToArray()));

        shorter.Add(pivot);
        shorter.AddRange(longer);

        return shorter.ToArray();
    }

    static void Main()
    {
        string[] stringsBro = { "Ariana", "Staropramen", "Zagorka", "Shumensko",
                                "Bruhaha", "Astika", "Carlsberg", "Heineken" };

        stringsBro = Qsort(stringsBro);
    }
}
