// Write a method GetMax() with two parameters that returns the bigger of two integers. 
// Write a program that reads 3 integers from the console and prints the biggest of them 
// using the method GetMax()

using System;
using System.Collections.Generic;

class GetDAMax
{
    static int? GetMax(List<int> numbers)
    {
        if (numbers.Count == 0) { Console.WriteLine("You didnt enter anything!"); return null; }

        numbers.Sort();
        return numbers[numbers.Count - 1];
    }

    static void Main()
    {
        Console.WriteLine("Enter as many numbers as you wish. Enter \"Quit\" when you are done.");
        
        int input = 0;
        var numbers = new List<int>();
        
        while (int.TryParse(Console.ReadLine(), out input)) numbers.Add(input);

        int? theMAX = GetMax(numbers);
        if (theMAX != null) Console.WriteLine("The max is {0}.", theMAX);
    }
}
