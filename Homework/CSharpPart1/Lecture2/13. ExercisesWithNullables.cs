using System;

class ExercisesWithNullables
{
    static void Main()
    {
        int? a = null;
        double? b = null;

        Console.WriteLine("a = {0}\nb = {1}", a, b);

        a = a + 3;
        b = b + null;

        Console.WriteLine("\na = {0}\nb = {1}\n", a, b);
    }
}
