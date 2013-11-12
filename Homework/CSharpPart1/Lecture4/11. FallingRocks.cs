using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
        Console.CursorVisible = false;
        Random rnd = new Random();
        string[] screen = new string[19];
        string dwarf = "(0)";
        int counter = 0;
        bool gameOver = false;
        int speed = 15;
        int score = 0;

        for (int i = 0; i < 19; i++) screen[i] = new string(' ', 20);

        // string[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
        char[] rocks = new char[] { '@', '^', '*', '&', '+', '%', '$', '#', '!', '.', ';' };

        int left = 10;

        Console.WriteLine("Use the Left and Right arrow keys to move sideways.\nUse '+' and '-' to adjust game speed.");
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();

        while (true)
        {
            Console.Clear();
            if (counter % speed == 0)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (screen[17][i] != ' ' && (i >= left && i < left + 3))
                    {
                        gameOver = true;
                        break;
                    }
                }
                if (gameOver) break;

                for (int i = 19 - 1; i >= 1; i--)
                {
                    screen[i] = screen[i - 1];
                }

                foreach (var item in screen[18])
                {
                    if (item != ' ') score += 10;
                }

                int indent = rnd.Next(0, 20);
                //ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorNames[rnd.Next(colorNames.Length)]);
                //Console.ForegroundColor = color;
                screen[0] = new string(' ', indent) + rocks[rnd.Next(rocks.Length)] + new string(' ', 19 - indent);
            }

            for (int i = 0; i < 18;   i++) Console.WriteLine(screen[i]);

            Console.WriteLine(new string(' ', left) + dwarf);

            Console.WriteLine("Score: {0}", score);

            if (Console.KeyAvailable == true)
            {
                ConsoleKeyInfo command = Console.ReadKey();
                if (command.Key == ConsoleKey.LeftArrow)
                {
                    if (left == 0) { }
                    else left = left - 1;
                }
                else if (command.Key == ConsoleKey.RightArrow)
                {
                    if (left == 17) { }
                    else left = left + 1;
                }
                else if (command.Key == ConsoleKey.Add)
                {
                    if (speed >= 0) speed -= 10;
                }
                else if (command.Key == ConsoleKey.Subtract)
                {
                    if (speed <= 35) speed += 10;
                }
            }

            Thread.Sleep(50);
            counter++;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Game Over");
        Console.WriteLine("Your score is {0} points!", score);
        Console.ReadLine();
    }
}
