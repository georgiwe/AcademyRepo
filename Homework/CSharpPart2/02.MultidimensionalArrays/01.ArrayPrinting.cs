using System;

class ArrayPrinting
{
    public static int filler = 1;
    
    static void ColDown(int[,] arr, int col, int numOfCellsToFill, int row = 0)
    {
        for (int i = 0; i < numOfCellsToFill; i++, row++, filler++) arr[row, col] = filler;
    }

    static void ColUp(int[,] arr, int col, int numOfCellsToFill, int row = 0)
    {
        for (int i = numOfCellsToFill - 1; i >= 0; i--, row--, filler++) arr[row, col] = filler;
    }

    static void RowRight(int[,] arr, int row, int col, int numOfCellsToFill)
    {
        for (int i = 0; i < numOfCellsToFill; i++, col++, filler++) arr[row, col] = filler;
    }

    static void RowLeft(int[,] arr, int row, int col, int numOfCellsToFill)
    {
        for (; numOfCellsToFill > 0; numOfCellsToFill--, col--, filler++) arr[row, col] = filler;
    }

    static void FillArrayTopDown(int[,] arr)
    {
        for (int col = 0; col < arr.GetLength(0); col++) ColDown(arr, col, arr.GetLength(0));
    }

    static void FillArrayAlternating(int[,] arr)
    {
        for (int col = 0; col < arr.GetLength(0); col++)
            if (col % 2 == 0) ColDown(arr, col, arr.GetLength(0));
            else ColUp(arr, col, arr.GetLength(0), arr.GetLength(0) - 1);
    }

    static void FillArraySideways(int[,] arr)
    {
        int n = arr.GetLength(0);
        int startRow = n;
        int startCol = 0;

        while (filler <= n * n)
        {
            if (startRow == 0) startCol++;
            else startCol = 0;

            if (startRow > 0) startRow--;

            int currentRow = startRow;
            int currentCol = startCol;

            while (currentRow < n && currentCol < n)
            {
                arr[currentRow, currentCol] = filler++;

                currentCol++;
                currentRow++;
            }
        }
    }

    static void FillArraySpirally(int[,] arr)
    {
        int cellsToFill = arr.GetLength(0);
        int startCol = 0;
        int startRow = 0;

        while (filler <= Math.Pow(arr.GetLength(0), 2))
        {
            ColDown(arr, startCol, cellsToFill, startRow);
            startCol++;
            startRow += cellsToFill-- - 1;

            RowRight(arr, startRow, startCol, cellsToFill);
            startRow--;
            startCol += cellsToFill - 1;

            ColUp(arr, startCol, cellsToFill, startRow);
            startRow -= cellsToFill-- - 1;
            startCol--;

            RowLeft(arr, startRow, startCol, cellsToFill);
            startRow++;
            startCol -= cellsToFill - 1;
        }
    }

    static void PrintArray(int[,] arr)
    {
        int spacing = Math.Pow(arr.GetLength(0), 2).ToString().Length + 1;

        for (int row = 0; row < arr.GetLength(0); row++)
        {
            for (int col = 0; col < arr.GetLength(0); col++)
                Console.Write("{0," + (-spacing) + "}", arr[row, col]);

            Console.WriteLine();
        }
    }

    static void Main()
    {
        Console.Write("Enter the size of the matrix: ");
        int n = int.Parse(Console.ReadLine());

        int[,] arr = new int[n, n];

        Console.Write("Choose between option a, b, c or d: ");

        switch (Console.ReadLine().ToLower().Replace(" ", ""))
        {
            case "a": FillArrayTopDown(arr); break;
            case "b": FillArrayAlternating(arr); break;
            case "c": FillArraySideways(arr); break;
            case "d": FillArraySpirally(arr); break;
            default: Console.WriteLine("\nError. Only enter a letter between a and d (including d)."); return;
        }

        PrintArray(arr);
    }
}
