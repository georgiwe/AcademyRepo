using System;

class TestArea
{
    static void Main()
    {   // start - 15:25, end - 16:15
        string[] preJumps = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        var terrain = new int[preJumps.Length];

        for (int i = 0; i < terrain.Length; i++)
            terrain[i] = int.Parse(preJumps[i]);

        int terLen = terrain.Length;
        int maxJumps = 1;

        for (int startPos = 0; startPos < terrain.Length; startPos++)
        {
            for (int stepSize = 1; stepSize <= terrain.Length; stepSize++)
            {
                int curJumps = 1;

                for (int newPos = (startPos + stepSize) % terLen, oldPos = startPos; ; newPos = (oldPos + stepSize) % terLen)
                {
                    if (terrain[newPos] <= terrain[oldPos]) break;

                    curJumps++;
                    oldPos = newPos;
                }

                if (curJumps > maxJumps) maxJumps = curJumps;
            }
        }

        Console.WriteLine(maxJumps);
    }
}
