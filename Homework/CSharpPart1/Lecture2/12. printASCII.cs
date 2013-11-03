using System;

class printASCII
{
    static void Main()
    {
        for (int i = 0; i < 128; i++)
        {
            Console.WriteLine("{0} -> {1}",i, (char)i);
        }
    }
}
