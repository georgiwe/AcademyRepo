using System;

class TenYearsLater
{
    static void Main()
    {
        // Write a program to read your age from the console and print how old you will be after 10 years

        bool correctInput = false;
        int currentAge = 0;

        // Input placed in a loop to avoid having to restart program upon incorrect input
        while (correctInput == false)
        {
            Console.Write("Gimme your current age, bro: ");
            correctInput = int.TryParse(Console.ReadLine(), out currentAge);

            if (currentAge > 116 || currentAge < 0)
            {
                Console.WriteLine("\nIncorrect input, bro!\nI'm pretty sure you're older than 0 and younger than 117.\n");
                correctInput = false;
            }
            else if (correctInput == false) Console.WriteLine("Incorrect input, bro!\n");
            else if (currentAge == 0) { Console.WriteLine("\nLiar!\n"); correctInput = false; }
        }

        if (currentAge + 10 >= 117) Console.WriteLine("\nIn ten years time, you will be {0} years old!\nThat would make you the oldest person alive. Fingers crossed!\n", currentAge + 10);
        else Console.WriteLine("\nIn ten years time, you will be {0} years old! Cool, eh?\n", currentAge + 10);
    }
}
