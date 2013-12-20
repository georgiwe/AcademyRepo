using System;

class MaxSumSquare
{
    static void Main()
    {
        int submatrixSize = 3;

        int[,] matrix = 
        {
            {1,  2,  3,  4},
            {5,  6,  7,  8},
            {9,  10, 11, 12},
            {13, 14, 15, 16},
            {17, 18, 19, 20}
        };

        //int n = int.Parse(Console.ReadLine());
        //int m = int.Parse(Console.ReadLine());

        //for (int i = 0; i < n; i++)
        //{
        //    for (int ii = 0; ii < m; ii++)
        //    {
        //        matrix[i, ii] = int.Parse(Console.ReadLine());
        //    }
        //}

        long currentSum = 0;
        long maxSum = 0;
        int maxRow = 0;
        int maxCol = 0;

        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                currentSum = 0;

                for (int currRow = row; currRow < row + submatrixSize; currRow++) 
                    for (int currCol = col; currCol < col + submatrixSize; currCol++) 
                        currentSum += matrix[currRow, currCol];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxRow = row;
                    maxCol = col;
                }
            }
        }

        int spacing = (matrix.GetLength(0) * matrix.GetLength(1)).ToString().Length + 1;

        for (int row = maxRow; row < submatrixSize + maxRow; row++)
        {
            for (int col = maxCol; col < submatrixSize + maxCol; col++)
                Console.Write("{0," + (-spacing) + "}", matrix[row, col]);

            Console.WriteLine();
        }
    }
}
