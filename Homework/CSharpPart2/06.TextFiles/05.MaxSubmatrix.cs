using System;
using System.IO;

class MaxSubmatrix
{
    static void Main()
    {
        Console.SetIn(new StreamReader("..\\..\\..\\Prob5.txt"));
        //// Console.SetOut(new StreamWriter("Output.txt", false, System.Text.Encoding.Unicode));

        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            string[] tmp = Console.ReadLine().Split(' ');

            for (int j = 0; j < tmp.Length; j++)
                matrix[i, j] = int.Parse(tmp[j].ToString());
        }

        long maxSum = long.MinValue;

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                long currSum = matrix[row, col] + matrix[row, col + 1];
                currSum += matrix[row + 1, col] + matrix[row + 1, col + 1];

                if (currSum > maxSum) maxSum = currSum;
            }
        }

        using (StreamWriter writer = new StreamWriter("Output.txt"))
        {
            writer.WriteLine(maxSum);
        }
    }
}
