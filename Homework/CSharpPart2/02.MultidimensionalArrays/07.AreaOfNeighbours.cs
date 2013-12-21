// Write a program that finds the largest area of equal neighbor elements 
// in a rectangular matrix and prints its size.

using System;

class AreaOfNeighbours
{
    static int maxCount = 1;
    static int currCount = 1;
    static int? element = null;
    static int? maxElement = null;

    static void CheckAround(int?[,] arr, int row, int col)
    {
        Compare(arr, row, col, "right");
        Compare(arr, row, col, "downright");
        Compare(arr, row, col, "down");
        Compare(arr, row, col, "downleft");
        Compare(arr, row, col, "left");
        Compare(arr, row, col, "upleft");
        Compare(arr, row, col, "up");
        Compare(arr, row, col, "upright");
    }

    static void Compare(int?[,] arr, int row, int col, string direction)
    {
        arr[row, col] = null; //if (row < 0 || col < 0 || row > arr.GetLength(0) - 1 || col > arr.GetLength(1) - 1) return;

        switch (direction)
        {
            case "right": col++; break;
            case "left": col--; break;
            case "up": row--; break;
            case "down": row++; break;
            case "upright": row--; col++; break;
            case "upleft": row--; col--; break;
            case "downright": row++; col++; break;
            case "downleft": row++; col--; break;
        }

        if ((row < 0 || col < 0 || row > arr.GetLength(0) - 1 || col > arr.GetLength(1) - 1) == false && 
            element == arr[row, col])
        {
            currCount++;
            CheckAround(arr, row, col);
        }
    }

    static void Main()
    {
        int?[,] arr = {
            {1, 3, 2, 2, 2, 4},
            {3, 3, 3, 2, 4, 4},
            {4, 3, 1, 2, 3, 3},
            {4, 3, 1, 3, 3, 1},
            {4, 3, 3, 3, 1, 1}, };

        maxElement = arr[0, 0];

        for (int row = 0; row < arr.GetLength(0); row++)
        {
            for (int col = 0; col < arr.GetLength(1); col++)
            {
                if (arr[row, col] == null) continue;

                currCount = 1;
                element = arr[row, col];

                CheckAround(arr, row, col);

                if (currCount > maxCount) { maxCount = currCount; maxElement = element; }
            }
        }

        Console.WriteLine("The element with maximum area is {0}, and its area is {1}.\n", maxElement, maxCount);
    }
}
