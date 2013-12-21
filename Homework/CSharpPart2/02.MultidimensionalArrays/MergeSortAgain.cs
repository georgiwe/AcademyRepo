using System;

class Program
{
    static int[] Split(int[] arr)
    {
        if (arr.Length <= 1) return arr;

        int[] left = new int[arr.Length / 2];
        int[] right = new int[arr.Length - arr.Length / 2];

        for (int i = 0; i < left.Length; i++) left[i] = arr[i];

        for (int i = 0; i < right.Length; i++) right[i] = arr[i + left.Length];

        left = Split(left);
        right = Split(right);
        
        return Merge(left, right);
    }

    static int[] Merge(int[] left, int[] right)
    {
        int[] result = new int[left.Length + right.Length];

        for (int i = 0, indexLeft = 0, indexRight = 0; i < result.Length; i++)
            if ((indexRight > right.Length - 1) || (indexLeft <= left.Length - 1 && left[indexLeft] < right[indexRight]))
                result[i] = left[indexLeft++];
            else if ((indexLeft > left.Length - 1) || (indexRight <= right.Length - 1 && right[indexRight] < left[indexLeft])) 
                result[i] = right[indexRight++];

        return result;
    }

    static void Main()
    {
        int[] test = new int[9] { 5, 3, 6, 2, 4, 1, 0, 7, 8 };
        test = Split(test);

        Console.WriteLine(String.Join(" ", test));
    }
}
