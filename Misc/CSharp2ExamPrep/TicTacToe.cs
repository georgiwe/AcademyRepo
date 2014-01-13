using System;
using System.Collections.Generic;
using System.IO;

class TestArea2
{
    static int xWin = 0;
    static int oWin = 0;
    static int draws = 0;

    static void Main()
    {
        char[][] field = new char[3][];

        var empties = new List<int[]>();

        for (int i = 0; i < field.Length; i++)
        {
            field[i] = Console.ReadLine().ToCharArray();

            for (int j = 0; j < field[i].Length; j++)
                if (field[i][j] == '-') empties.Add(new int[] { i, j });
        }

        bool xToAct = empties.Count % 2 != 0;

        Solve(field, empties, xToAct);

        Console.WriteLine(xWin);
        Console.WriteLine(draws);
        Console.WriteLine(oWin);
    }

    static void Solve(char[][] field, List<int[]> empties, bool xToAct)
    {
        if (empties.Count == 0) { draws++; return; }

        char symb = xToAct ? 'X' : 'O';

        for (int i = 0; i < empties.Count; i++)
        {
            int row = empties[i][0];
            int col = empties[i][1];

            field[row][col] = symb;

            if (CheckForWin(field))
            {
                if (xToAct) xWin++;
                else if (!xToAct) oWin++;
            }
            else
            {
                empties.RemoveAt(i);

                Solve(field, empties, !xToAct);

                empties.Insert(i, new int[] { row, col });
            }

            field[row][col] = '-';
        }
    }

    private static bool CheckForWin(char[][] field)
    {
        return ((field[0][0] == field[0][1] && field[0][0] == field[0][2] && field[0][0] != '-') ||
                (field[1][0] == field[1][1] && field[1][0] == field[1][2] && field[1][0] != '-') ||
                (field[2][0] == field[2][1] && field[2][0] == field[2][2] && field[2][0] != '-') ||

                (field[0][0] == field[1][0] && field[0][0] == field[2][0] && field[0][0] != '-') ||
                (field[0][1] == field[1][1] && field[0][1] == field[2][1] && field[0][1] != '-') ||
                (field[0][2] == field[1][2] && field[0][2] == field[2][2] && field[0][2] != '-') ||

                (field[0][0] == field[1][1] && field[0][0] == field[2][2] && field[0][0] != '-') ||
                (field[0][2] == field[1][1] && field[0][2] == field[2][0] && field[0][2] != '-'));
    }
}
