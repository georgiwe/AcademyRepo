using System;
using System.Collections.Generic;

class StringSeqs
{
    static int maxLen = 1;
    static string maxLenSymbol = "";

    static void Vertical(string[,] matrix)
    {
        int currSeqLen = 1;

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            currSeqLen = 1;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if (matrix[row, col] == matrix[row + 1, col]) currSeqLen++;
                else currSeqLen = 1;

                if (currSeqLen > maxLen)
                {
                    maxLen = currSeqLen;
                    maxLenSymbol = matrix[row, col];
                }
            }
        }
    }

    static void Horizontal(string[,] matrix)
    {
        int currSeqLen = 1;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            currSeqLen = 1;

            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                if (matrix[row, col] == matrix[row, col + 1]) currSeqLen++;
                else currSeqLen = 1;

                if (currSeqLen > maxLen)
                {
                    maxLen = currSeqLen;
                    maxLenSymbol = matrix[row, col];
                }
            }
        }
    }

    static void LeftRightDiagonal(string[,] matrix)
    {
        int currSeqLen = 1;
        int startRow = matrix.GetLength(0) - 1;
        int startCol = 0;

        while (startRow != 0 && startCol != matrix.GetLength(1))
        {
            if (startRow == 0) startCol++;

            if (startRow > 0) { startCol = 0; startRow--; }

            int currRow = startRow;
            int currCol = startCol;

            while (currRow < matrix.GetLength(0) - 1 && currCol < matrix.GetLength(1) - 1)
            {
                if (matrix[currRow, currCol] == matrix[currRow + 1, currCol + 1]) currSeqLen++;
                else currSeqLen = 1;

                currRow++;
                currCol++;

                if (currSeqLen > maxLen)
                {
                    maxLen = currSeqLen;
                    maxLenSymbol = matrix[currRow, currCol];
                }
            }
        }
    }

    static void RightLeftDiagonal(string[,] matrix)
    {
        string[,] reverseMatrix = new string[matrix.GetLength(0), matrix.GetLength(1)];

        for (int row = 0; row < reverseMatrix.GetLength(0); row++)
            for (int col = 0; col < reverseMatrix.GetLength(1); col++)
                reverseMatrix[row, col] = matrix[row, matrix.GetLength(1) - col - 1];

        LeftRightDiagonal(reverseMatrix);
    }

    static void Main()
    {
        string[,] matrix = 
        {
            {"ha", "fifi", "fifi", "hi"},
            {"fo", "ha", "hi", "xx"},
            {"xxx", "hi", "ha", "xx"},
            {"hi", "mo", "lol", "mh"}
        };

        maxLenSymbol = matrix[0, 0];

        Vertical(matrix);
        Horizontal(matrix);
        LeftRightDiagonal(matrix);
        RightLeftDiagonal(matrix);

        Console.WriteLine("The max length is {0}.\n", maxLen);
        Console.Write("It is \"");

        for (int i = 0; i < maxLen; i++) Console.Write(maxLenSymbol + ", ");

        Console.WriteLine("\b\b\".\n");
    }
}
