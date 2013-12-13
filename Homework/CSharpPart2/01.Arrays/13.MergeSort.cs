using System;

class MergeSort
{
    static int[] Split(int[] arr)
     {
        if (arr.Length == 1) return arr;

        int[] left = new int[arr.Length / 2];
        int[] right = new int[arr.Length - (arr.Length / 2)];

        for (int i = 0; i < left.Length; i++)
        {
            left[i] = arr[i];
        }

        for (int i = left.Length; i < arr.Length; i++)
        {
            right[i - left.Length] = arr[i];
        }

        left = Split(left);
        right = Split(right);

        return Merge(left, right);
    }

    static int[] Merge(int[] left, int[] right)
    {
        int[] resultArray = new int[left.Length + right.Length];

        bool skipLeft = false;
        bool skipRight = false;

        for (int i = 0, leftIndex = 0, rightIndex = 0; i < resultArray.Length; i++)
        {
            if (skipRight || (skipLeft == false && left[leftIndex] < right[rightIndex]))
            {
                resultArray[i] = left[leftIndex];
                if (leftIndex < left.Length - 1) leftIndex++;
                else skipLeft = true;
            }
            
            else if (skipLeft || (skipRight == false && left[leftIndex] >= right[rightIndex]))
            {
                resultArray[i] = right[rightIndex];
                if (rightIndex < right.Length - 1) rightIndex++;
                else skipRight = true;
            }
        }

        return resultArray;
    }

    static void Main()
    {
        int[] arr = new int[] { 6, 5, 3, 1, 8, 7, 2, 4 };

        int[] result = Split(arr);
    }
}
