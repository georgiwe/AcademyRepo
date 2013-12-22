// Write a class Matrix, to holds a matrix of integers. Overload the operators for 
// adding, subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().

using System;

class DefiningAclass
{
    // The Matrix class is in another .cs file in the same project folder!

    static void PrintMatrix(Matrix matrix)
    {
        for (int row = 0; row < matrix.Rows; row++)
        {
            for (int col = 0; col < matrix.Cols; col++)
                Console.Write("{0," + -5 + "}", matrix[row, col]);

            Console.WriteLine();
        }

        Console.WriteLine(new string('=', 70));
    }

    static void GiveRndValues(Matrix matrix)
    {
        Random rnd = new Random();

        for (int row = 0; row < matrix.Rows; row++)
            for (int col = 0; col < matrix.Cols; col++)
                matrix[row, col] = rnd.Next(-20, 20);
    }

    static void Main()
    {
        Matrix firstMatrix = new Matrix(5, 15);
        GiveRndValues(firstMatrix);
        Console.WriteLine("Matrix ONE:\n");
        PrintMatrix(firstMatrix);
        Matrix secondMatrix = new Matrix(7, 3);
        GiveRndValues(secondMatrix);
        Console.WriteLine("Matrix TWO:\n");
        PrintMatrix(secondMatrix);

        Matrix thirdMatrix = firstMatrix + secondMatrix;
        Console.WriteLine("Result of adding:\n");
        PrintMatrix(thirdMatrix);

        thirdMatrix = firstMatrix - secondMatrix;
        Console.WriteLine("Result of subtracting:\n");
        PrintMatrix(thirdMatrix);

        thirdMatrix = firstMatrix * secondMatrix;
        Console.WriteLine("Result of multiplying:\n");
        PrintMatrix(thirdMatrix);

        Console.WriteLine("Result of ToString:\n");
        string matrixString = thirdMatrix.ToString(); // ToString() takes optional arguments for separators, as strings.
                                // The default is " ", but you can choose "" for no separator, or something else.
        Console.WriteLine(matrixString);
    }
}
