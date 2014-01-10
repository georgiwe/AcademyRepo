using System;
using System.Collections.Generic;
using System.IO;

class TestArea
{
    static List<int[]> dirs = new List<int[]>();

    static void Main()
    {
        if (File.Exists("inp2.txt")) Console.SetIn(new StreamReader("inp2.txt"));

        int[] dims = new int[3];
        dims = GetInput(dims);

        char[, ,] cuboid = new char[dims[0], dims[1], dims[2]];

        // [0, 0, 0] is top left front cube
        for (int h = 0; h < dims[1]; h++)
        {
            string[] floor = new string[dims[2]];
            floor = GetInput(floor);

            for (int d = 0; d < dims[2]; d++)
                for (int w = 0; w < dims[0]; w++)
                    cuboid[w, h, d] = floor[d][w];
        }

        int maxLine = 1;
        int maxLineCount = 1;
        int currLine = 1;
        GenerateAllDirections();

        for (int w = 0; w < dims[0]; w++)
        {
            for (int h = 0; h < dims[1]; h++)
            {
                for (int d = 0; d < dims[2]; d++)
                {
                    int[] startPos = new int[3];
                    startPos[0] = w;
                    startPos[1] = h;
                    startPos[2] = d;

                    for (int curDir = 0; curDir < dirs.Count; curDir++)
                    {
                        int[] currPos = new int[startPos.Length];
                        for (int i = 0; i < currPos.Length; i++) currPos[i] = startPos[i];

                        currLine = 1;

                        while (true)
                        {
                            bool outt = false;
                            int[] newPos = new int[3];

                            for (int i = 0; i < 3; i++)
                            {
                                newPos[i] = currPos[i] + dirs[curDir][i];

                                if (newPos[i] < 0) outt = true;
                            }

                            if (outt) break;

                            if (newPos[0] >= dims[0] ||
                                newPos[1] >= dims[1] ||
                                newPos[2] >= dims[2])
                            {
                                break;
                            }

                            if (cuboid[currPos[0], currPos[1], currPos[2]] ==
                                cuboid[newPos[0], newPos[1], newPos[2]])
                            {
                                currLine++;
                            }
                            else break;

                            for (int i = 0; i < 3; i++) currPos[i] = newPos[i];
                        }

                        if (currLine > maxLine)
                        {
                            maxLine = currLine;
                            maxLineCount = 1;
                        }
                        else if (currLine == maxLine) maxLineCount++;

                        for (int i = 0; i < 3; i++) currPos[i] = startPos[i];
                    }
                }
            }
        }

        if (maxLine == 1) { Console.WriteLine(-1); return; }
        Console.WriteLine("{0} {1}", maxLine, maxLineCount);
    }

    static int[] GetInput(int[] arr)
    {
        string[] input = Console.ReadLine().Split();

        for (int i = 0; i < input.Length; i++) arr[i] = int.Parse(input[i]);

        return arr;
    }

    static string[] GetInput(string[] arr)
    {
        string[] input = Console.ReadLine().Split();

        for (int i = 0; i < input.Length; i++) arr[i] = input[i];

        return arr;
    }

    static void GenerateAllDirections()
    {
        dirs = new List<int[]>();

        for (int i = -1; i <= 1; i++)
            for (int j = -1; j <= 1; j++)
                for (int k = -1; k <= 1; k++)
                    dirs.Add(new int[] { i, j, k });

        dirs.RemoveAt(13); // Removing { 0, 0, 0 }

        for (int i = 0; i < dirs.Count - 1; i++)
        {
            for (int j = i + 1; j < dirs.Count; j++)
            {

                if (dirs[i][0] + dirs[j][0] == 0 &&
                    dirs[i][1] + dirs[j][1] == 0 &&
                    dirs[i][2] + dirs[j][2] == 0)
                {
                    dirs[i] = new int[] { 5, 5, 5 };
                }
            }
        }

        int initialCount = dirs.Count;
        for (int i = 0; i < initialCount; i++)
        {
            if (dirs.Count <= i) break;
            if (dirs[i][0] == 5) dirs.RemoveAt(i--);
        }
    }
}
