using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Slides
{
    static List<string> commands = new List<string>();
    static int[] pos = new int[3];
    static int[] newPos = new int[3];
    static int width = 0;
    static int height = 0;
    static int depth = 0;
    static bool stop = false;

    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        
        width = int.Parse(input[0]);
        height = int.Parse(input[1]);
        depth = int.Parse(input[2]);

        GetCommands();

        string[, ,] cuboid = new string[width, height, depth];

        for (int h = 0, cmdInd = 0; h < height; h++)
            for (int d = 0; d < depth; d++)
                for (int w = 0; w < width; w++)
                    cuboid[w, h, d] = commands[cmdInd++];

        input = Console.ReadLine().Split();
        pos[0] = int.Parse(input[0]);
        pos[2] = int.Parse(input[1]);

        while (stop == false)
        {
            if (cuboid[pos[0], pos[1], pos[2]][0] == 'S')
            {
                if (pos[1] == height - 1) { End(getsOut: true); break; }

                Slide(cuboid[pos[0], pos[1], pos[2]]);
            }
            else if (cuboid[pos[0], pos[1], pos[2]][0] == 'B') End(getsOut: false);
            else if (cuboid[pos[0], pos[1], pos[2]][0] == 'T') Teteport(cuboid[pos[0], pos[1], pos[2]]);
            else if (cuboid[pos[0], pos[1], pos[2]][0] == 'E') 
                if (pos[1] + 1 < height) pos[1]++;
                else End(getsOut: true);
        }
    }

    static void Slide(string cellValue)
    {
        cellValue = cellValue.Substring(2);
        newPos = new int[] { pos[0], pos[1] + 1, pos[2] };

        switch (cellValue)
        {
            case "F": newPos[2]--; break;
            case "L": newPos[0]--; break;
            case "R": newPos[0]++; break;
            case "B": newPos[2]++; break;
            case "FL": newPos[0]--; newPos[2]--; break;
            case "FR": newPos[0]++; newPos[2]--; break;
            case "BL": newPos[0]--; newPos[2]++; break;
            case "BR": newPos[0]++; newPos[2]++; break;
        }

        if (IsInside()) pos = new int[] { newPos[0], newPos[1], newPos[2] };
        else End(getsOut: false);
    }

    static bool IsInside()
    {
        if (   newPos[0] == width || newPos[0] < 0
           || newPos[1] == height || newPos[1] < 0
           ||  newPos[2] == depth || newPos[2] < 0) return false;
    }

    private static void Teteport(string cellValue)
    {
        string[] coords = cellValue.Substring(2).Split();

        pos[0] = int.Parse(coords[0]);
        pos[2] = int.Parse(coords[1]);
    }

    static void End(bool getsOut)
    {
        Console.WriteLine(getsOut ? "Yes" : "No");
        Console.WriteLine(String.Join(" ", pos));
        stop = true;
    }

    static void GetCommands()
    {
        for (int i = 0; i < height; i++)
            foreach (var commandLine in Regex.Split(Console.ReadLine(), @" \| "))
                foreach (var command in Regex.Split(commandLine, @"\)\("))
                    commands.Add(command.Trim('(', ')', ' '));
    }
}
