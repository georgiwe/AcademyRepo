using System;

class CompareSafely
{
    static void Main()
    {
        //Write a program that safely compares floating-point numbers 
        //with precision of 0.000001. Examples:(5.3 ; 6.01) -> false;  
        //(5.00000001 ; 5.00000003) -> true

        Console.Write("Enter the first number: ");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        double secondNumber = double.Parse(Console.ReadLine());

        if (firstNumber == secondNumber) Console.WriteLine("True.");
        else Console.WriteLine("False.");
    }
}
