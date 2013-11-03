using System;
using System.Threading;

class SwitchValues
{
    static void Main()
    {
        Console.CursorVisible = false;

        byte a = 5, b = 10;
        Console.WriteLine("a = {0}\nb = {1}\n", a, b);

        Thread.Sleep(2000);
        Console.Clear();
        

        for (int i = 0; i < 2; i++)
        {
            Console.Clear();
            Thread.Sleep(800);
            Console.Write("Witchcraft is happening...\n");
            Thread.Sleep(1000);
            Console.Clear();
        }

        Thread.Sleep(1000);
        Console.Clear();

        Console.WriteLine("a = {0}\nb = {1}\n", b, a);

        // Just kidding. It's below
        byte switcharoo = b;
        b = a;
        a = switcharoo;

        /* With numbers, it can also work like this:
         *      a = a + b;
         *      b = a - b;
         *      a = a - b;
         */
    }
}
