using System;
using System.Text;

class Matrix
{
    public int Rows; // these will be
    public int Cols; // accessible from anywhere
    private int[,] matrixInstanceValues; // This will not. It will be initialized through the constructor
                                         // for each instance of the Matrix class. It holds the actual values
    // Constructor                          of the Matrix instance, in a two-dimensional array.
    public Matrix(int rows, int cols) // Receives parameters and sets the matrixInstanceValues property
    {                                 // for the current instance of the Matrix class.
        matrixInstanceValues = new int[rows, cols];
        Rows = rows;
        Cols = cols;
    }

    // Accessor, indexer
    public int this[int row, int col]     // This sets and gets the value of the matrixInstanceValues property.
    {                                     // It does it through these setter and getter methods. This is the only
        set { matrixInstanceValues[row, col] = value; } // way to do it, since matrixInstanceValues is *private*.
        get { return matrixInstanceValues[row, col]; }
    }

    /// <summary>
    /// This method adds up the members of two instances of the Matrix class. 
    /// Result matrix's rows and columns depend on the 
    /// respective count in the input matrices.
    /// Any new cells are filled with zeros.
    /// </summary>
    /// <param name="FirstMatrix"></param>
    /// <param name="SecondMatrix"></param>
    /// <returns>Returns a Matrix class </returns>
    public static Matrix operator +(Matrix first, Matrix second)
    {
        int maxRows = Math.Max(first.Rows, second.Rows);
        int maxCols = Math.Max(first.Cols, second.Cols);
        int minRows = Math.Min(first.Rows, second.Rows);
        int minCols = Math.Min(first.Cols, second.Cols);

        Matrix result = new Matrix(maxRows, maxCols);

        for (int row = 0; row < maxRows; row++)
        {
            for (int col = 0; col < maxCols; col++)
            {
                if (row < first.Rows && row < second.Rows && col < first.Cols && col < second.Cols)
                    result[row, col] = first[row, col] + second[row, col]; // both matrices have elements in those cells
                else if (row < first.Rows && col < first.Cols)
                    result[row, col] = first[row, col]; // first has an element
                else if (row < second.Rows && col < second.Cols)
                    result[row, col] = second[row, col]; // second has an element
            }
        }

        return result;
    }

    /// <summary>
    /// This method subtracts the members of two instances of the Matrix class. 
    /// Result matrix's rows and columns depend on the 
    /// respective count in the input matrices.
    /// Any new cells are filled with zeros.
    /// </summary>
    /// <param name="FirstMatrix"></param>
    /// <param name="SecondMatrix"></param>
    /// <returns>Returns a Matrix class </returns>
    public static Matrix operator -(Matrix first, Matrix second)
    {
        int maxRows = Math.Max(first.Rows, second.Rows);
        int maxCols = Math.Max(first.Cols, second.Cols);
        int minRows = Math.Min(first.Rows, second.Rows);
        int minCols = Math.Min(first.Cols, second.Cols);

        Matrix result = new Matrix(maxRows, maxCols);

        for (int row = 0; row < maxRows; row++)
        {
            for (int col = 0; col < maxCols; col++)
            {
                if (row < first.Rows && row < second.Rows && col < first.Cols && col < second.Cols)
                    result[row, col] = first[row, col] - second[row, col]; // both matrices have elements in those cells
                else if (row < first.Rows && col < first.Cols)
                    result[row, col] = first[row, col]; // first has an element
                else if (row < second.Rows && col < second.Cols)
                    result[row, col] = second[row, col]; // second has an element
            }
        }

        return result;
    }

    /// <summary>
    /// This method multiplies the members of two instances of the Matrix class. 
    /// Result matrix's rows and columns depend on the 
    /// respective count in the input matrices.
    /// Any new cells are filled with zeros.
    /// </summary>
    /// <param name="FirstMatrix"></param>
    /// <param name="SecondMatrix"></param>
    /// <returns>Returns a Matrix class </returns>
    public static Matrix operator *(Matrix first, Matrix second)
    {
        int maxRows = Math.Max(first.Rows, second.Rows);
        int maxCols = Math.Max(first.Cols, second.Cols);
        int minRows = Math.Min(first.Rows, second.Rows);
        int minCols = Math.Min(first.Cols, second.Cols);

        Matrix result = new Matrix(maxRows, maxCols);

        for (int row = 0; row < maxRows; row++)
        {
            for (int col = 0; col < maxCols; col++)
            {
                if (row < first.Rows && row < second.Rows && col < first.Cols && col < second.Cols)
                    result[row, col] = first[row, col] * second[row, col]; // both matrices have elements in those cells
                else if (row < first.Rows && col < first.Cols)
                    result[row, col] = first[row, col]; // first has an element
                else if (row < second.Rows && col < second.Cols)
                    result[row, col] = second[row, col]; // second has an element
            }
        }

        return result;
    }

    public string ToString(string separator = " ")
    {
        StringBuilder sb = new StringBuilder();

        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Cols; col++)
            {
                sb.Append(matrixInstanceValues[row, col].ToString());
                if (col != Cols - 1) sb.Append(separator);
                else sb.Append("\n");
            }
        }

        return sb.ToString();
    }
}
