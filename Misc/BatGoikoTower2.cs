using System;

class BatGoikoTower2
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        int[] crossbeam = new int[height];
        int step = 2;

        crossbeam[0] = 1;
        for (int i = 1; i < height/2; i++, step++)
        {
            crossbeam[i] = crossbeam[i-1] + step;
        }

        int outerDots = height - 1;
        int innerDots = 0;
        step = 0;

        for (int i = 0; i < height; i++)
        {
            Console.Write(new string('.', outerDots));
            Console.Write("/");
            if (i == crossbeam[step]) { Console.Write(new string('-', innerDots)); step++; }
            else Console.Write(new string('.', innerDots));
            Console.Write("\\");
            Console.WriteLine(new string('.', outerDots));

            outerDots--;
            innerDots += 2;
        }
    }
}