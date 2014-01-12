using System;
using System.Collections.Generic;

class AirplaneDrinks
{
    static long moves = 0;
    static int drinksLeft = 0;
    static int currLoc = 0;

    static void Main(string[] args)
    {
        int totSeats = int.Parse(Console.ReadLine());
        int teaDrinkers = int.Parse(Console.ReadLine());

        var all = new byte[totSeats + 1];
        var tea = new List<int>(teaDrinkers);

        for (int i = 0; i < teaDrinkers; i++)
        {
            int drinker = int.Parse(Console.ReadLine());

            all[drinker]++;
            tea.Add(drinker);
        }

        tea.Sort();
        FillFlask(currLoc);

        for (int i = all.Length - 1; i >= 1; i--)
        {
            if (all[i] > 0) continue;
            if (drinksLeft == 0) FillFlask(currLoc);

            Serve(currLoc, i);
        }

        FillFlask(currLoc);

        for (int i = tea.Count - 1; i >= 0; i--)
        {
            if (drinksLeft == 0) FillFlask(currLoc);

            Serve(currLoc, tea[i]);
        }

        MoveToMachine(currLoc);

        Console.WriteLine(moves);
    }

    static void MoveToSeat(int startFrom, int moveTo)
    {
        moves += Math.Abs(moveTo - startFrom);
        currLoc = moveTo;
    }

    static void MoveToMachine(int startFrom)
    {
        moves += startFrom;
        currLoc = 0;
    }

    static void FillFlask(int startFrom)
    {
        MoveToMachine(startFrom);
        moves += 47;
        drinksLeft = 7;
    }

    static void Serve(int startFrom, int client)
    {
        MoveToSeat(startFrom, client);
        moves += 4;
        drinksLeft--;
    }
}
