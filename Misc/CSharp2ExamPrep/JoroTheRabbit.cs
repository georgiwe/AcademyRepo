using System;

class JoroTheRabbit
{
    static void Main()
    {   // start - 15:25, end - 16:15
        string[] preJumps = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        var jumps = new int[preJumps.Length];

        for (int i = 0; i < jumps.Length; i++)
            jumps[i] = int.Parse(preJumps[i]);

        int terLen = jumps.Length;
        int maxJumps = 1;

        for (int startPos = 0; startPos < jumps.Length; startPos++)
        {
            for (int stepSize = 1; stepSize <= jumps.Length; stepSize++)
            {
                int curJumps = 1;

                for (int newPos = (startPos + stepSize) % terLen, oldPos = startPos; ; newPos = (oldPos + stepSize) % terLen)
                {
                    if (jumps[newPos] <= jumps[oldPos]) break;

                    curJumps++;
                    oldPos = newPos;
                }

                if (curJumps > maxJumps) maxJumps = curJumps;
            }
        }

        Console.WriteLine(maxJumps);
    }
}
