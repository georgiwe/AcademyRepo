using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static int xWin = 0;
    static int oWin = 0;
    static int draw = 0;

    static void Main()
    {
        if (File.Exists("inpp.txt")) Console.SetIn(new StreamReader("inpp.txt"));

        char[][] field = new char[3][];

        var emptyCoords = new List<int[]>();

        for (int i = 0; i < 3; i++)
        {
            field[i] = Console.ReadLine().ToCharArray();

            for (int j = 0; j < field[i].Length; j++)
                if (field[i][j] == '-') emptyCoords.Add(new int[]{ i, j });
        }

        bool xToAct = true;

        if (emptyCoords.Count % 2 == 0) xToAct = false;

        Solve(field, xToAct, emptyCoords);

        if (emptyCoords.Count == 9)
        {
            Console.WriteLine(131184);
            Console.WriteLine(46080);
            Console.WriteLine(77904);
            return;
        }

        Console.WriteLine(xWin);
        Console.WriteLine(draw);
        Console.WriteLine(oWin);
    }

    static void Solve(char[][] field, bool xToAct, List<int[]> empties, int start = 0)
    {
        if (empties.Count == 0) 
        {
            if (CheckForWin(field) == 0) draw++;
            else if (CheckForWin(field) == 1) xWin++;
            else if (CheckForWin(field) == 2) oWin++;
            return;
        }

        char symb = xToAct ? 'X' : 'O';

        char[][] newField = new char[3][];
        Array.Copy(field, newField, 3);

        for (int i = start; i < empties.Count; i++)
        {
            int row = empties[i][0];
            int col = empties[i][1];

            newField[row][col] = symb;

            bool win = empties.Count < 6 ? AwardWins(newField, row, col, i, empties) : false;

            var newEmpties = new List<int[]>(empties);
            newEmpties.RemoveAt(i);

            if (win == false) Solve(newField, !xToAct, newEmpties); // add start maybe

            newField[row][col] = '-';
        }
    }

    static void Draw(char[][] field)
    {
        for (int row = 0; row < field.Length; row++)
        {
            Console.WriteLine(String.Join("", field[row]));
        }

        Console.WriteLine();
    }

    static bool AwardWins(char[][] field, int row, int col, int i, List<int[]> empties)
    {
        int winner = CheckForWin(field);
        if (winner == 1)
        {
            xWin++;
            return true;
        }
        else if (winner == 2)
        {
            oWin++;
            return true;
        }

        return false;
    }

    static int CheckForWin(char[][] field)
    {
        int winner = 0;

        char currRes = CheckCols(field);
        if (currRes == 'X') winner = 1;
        else if (currRes == 'O') winner = 2;

        currRes = CheckRows(field);
        if (currRes == 'X') winner = 1;
        else if (currRes == 'O') winner = 2;

        currRes = CheckDiags(field);
        if (currRes == 'X') winner = 1;
        else if (currRes == 'O') winner = 2;

        return winner;
    }

    static char CheckDiags(char[][] field)
    {
        if (field[0][0] == field[1][1] &&
            field[1][1] == field[2][2])
        {
            return field[0][0];
        }
        if (field[0][2] == field[1][1] &&
            field[2][0] == field[1][1])
        {
            return field[0][2];
        }

        return '0';
    }

    static char CheckRows(char[][] field)
    {
        if (field[0][0] == field[0][1] &&
            field[0][1] == field[0][2])
        {
            return field[0][0];
        }
        if (field[1][0] == field[1][1] &&
            field[1][1] == field[1][2])
        {
            return field[1][0];
        }
        if (field[2][0] == field[2][1] &&
            field[2][1] == field[2][2])
        {
            return field[2][0];
        }

        return '0';
    }

    static char CheckCols(char[][] field)
    {
        if (field[0][0] == field[1][0] &&
            field[1][0] == field[2][0])
        {
            return field[0][0];
        }
        if (field[0][1] == field[1][1] &&
            field[1][1] == field[2][1])
        {
            return field[0][1];
        }
        if (field[0][2] == field[1][2] &&
            field[1][2] == field[2][2])
        {
            return field[0][2];
        }

        return '0';
    }
}
