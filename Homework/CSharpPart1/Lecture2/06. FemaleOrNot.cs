using System;
using System.Threading;

class FemaleOrNot
{
    static void Main()
    {
        //Declare a boolean variable called isFemale and assign
        //an appropriate value corresponding to your gender.

        bool isFemale = false; // All done. This is all that was required, the rest is play.






        byte attempt = 0;
        bool guessed = false;

        while (!guessed)
        {
            attempt++;
            Console.CursorVisible = true;
            if (attempt == 1) { Console.Write("Q: Are you a female?\nA: "); }
            else { Console.Clear(); Console.Write("Q: Are you a male?\nA: "); }

            while (true)
            {
                string input = Console.ReadLine().ToLower().Replace(" ", "");

                if (input == "yes" || input == "y" || input == "yep" 
                    || input == "yup")
                {
                    if (attempt == 1) 
                    { 
                        isFemale = true; 
                        Console.BackgroundColor = ConsoleColor.Magenta; 
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.CursorVisible = false; 
                        Console.Clear(); 
                        Console.WriteLine("Girl power!!\n"); 
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }

                    else 
                    { 
                        isFemale = false; 
                        Console.BackgroundColor = ConsoleColor.Blue; 
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.CursorVisible = false; 
                        Console.Clear(); 
                        Console.WriteLine(
                            "I'm getting good at this. Highfive, bro!\n"); 
                        Console.ForegroundColor = ConsoleColor.Blue; 
                    }

                    guessed = true;
                    break;
                }
                else if (input == "no" || input == "n" || input == "nope")
                {
                    if (attempt == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Red; 
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.CursorVisible = false; 
                        Console.Clear(); 
                        Console.WriteLine("Liar!! I'm not playing anymore!\n"); 
                        Console.ForegroundColor = ConsoleColor.Red; guessed = true; break;
                    }
                    Console.CursorVisible = false;
                    Console.Clear();
                    Console.WriteLine("Damn. Let's try again!\n");
                    Thread.Sleep(2220);
                    break;
                }
                else {  Console.Write("\nWrong input. Try again: "); }
            }
        }
    }
}
