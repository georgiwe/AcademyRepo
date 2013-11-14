using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.SetWindowSize(60, 21);
        //Console.BufferHeight = Console.WindowHeight;
        //Console.BufferWidth = Console.WindowWidth;
        Console.CursorVisible = false;
        Random rnd = new Random();
        string[] screen = new string[18];
        string dwarf = "(0)";
        int counter = 0;
        bool gameOver = false;
        int speed = 15;
        int score = 0;
        int difficulty = 1;
        int step = 0;
        int step2 = 0;
        int left = 8;
        byte lives = 3;
        bool lightshow = false;

        for (int i = 0; i < screen.Length; i++) screen[i] = new string(' ', 20);

        string[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
        char[] rocks = new char[] { '@', '^', '*', '&', '+', '%', '$', '#', '!', '.', ';' };

        Console.WriteLine("- Use the Left and Right arrow keys to move sideways.\n\n- Use '+' and '-' to adjust game speed.");
        Console.WriteLine("\n- Press 'P' to pause.");
        Console.WriteLine("- Press 'Delete' to toggle \"Lightshow mode\"");
        Console.WriteLine("\n\n\nIf you score 10 000 points - you win.");
        Console.WriteLine("\nPress any key to start game.");
        Console.ReadKey();

        while (true)
        {
            byte livesCheck = lives;
            Console.Clear();
            if (counter % speed == 0)
            {
                for (int i = 0; i < screen[screen.Length - 1].Length - 1; i++)
                {
                    if ((screen[screen.Length - 1][i] != ' ' && (i >= left && i < left + 3)) || (score >= 10000))
                    {
                        gameOver = true;

                        lives--;
                        break;
                    }
                    else if (screen[screen.Length - 1][i] != ' ')
                    {
                        score += 10;

                        if (score - step2 == 1000 && score != 0)
                        {
                            lives++;
                            step2 = score;
                        }
                        // increases difficulty until difficulty lvl 6
                        if (score - step == 2000 && score != 0 && difficulty <= 6) 
                            { difficulty++; step = score; counter = 0; } 
                    }
                }

                if ((gameOver && lives == 0) || (score >= 10000)) break;

                // pieces fall down
                for (int i = screen.Length - 1; i >= 1; i--)
                {
                    screen[i] = screen[i - 1];
                }

                // random number of pieces generated depending on difficulty level
                screen[0] = new string(' ', 20);
                int count = rnd.Next(1, difficulty + 1);
                for (int i = 1; i <= count; i++)
                 {
                    char[] tempChar = screen[0].ToCharArray();
                    tempChar[rnd.Next(0, tempChar.Length)] = rocks[rnd.Next(rocks.Length)];
                    screen[0] = (new string(tempChar)).PadRight(20, ' ');
                }
            }

            // prints the pieces after they have dropped one line
            for (int i = 0; i < screen.Length; i++)
            {
                if (score >= 9000 || lightshow)
                {
                    ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorNames[rnd.Next(colorNames.Length)]);
                    Console.ForegroundColor = color;
                    Console.WriteLine(screen[i]);
                }
                else Console.WriteLine(screen[i]);
            }

            // prints the dwarf and score
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string(' ', left) + dwarf);
            Console.WriteLine("Score: {0}   Lives: {1}", score, lives);
            // takes and conceals keyboard input
            Console.ForegroundColor = ConsoleColor.Black;
            if (Console.KeyAvailable == true)
            {
                ConsoleKeyInfo command = Console.ReadKey();
                if (command.Key == ConsoleKey.LeftArrow)
                {
                    if (left != 0) left = left - 1;
                }
                else if (command.Key == ConsoleKey.RightArrow)
                {
                    if (left != 17) left = left + 1;
                }
                else if (command.Key == ConsoleKey.Add)
                {
                    if (speed > 5) speed -= 5;
                }
                else if (command.Key == ConsoleKey.Subtract)
                {
                    if (speed <= 35) speed += 5;
                }
                else if (command.Key == ConsoleKey.P)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\bGame paused. Press any key to continue...");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    while (!Console.KeyAvailable) { }
                }
                else if (command.Key == ConsoleKey.L) lives++;
                else if (command.Key == ConsoleKey.Delete) lightshow = !lightshow;
            }

            if (lives < livesCheck)
            {
                Console.SetCursorPosition(30, 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have lost a life!");
                Console.SetCursorPosition(30, 11);
                Console.WriteLine("You have {0} lives left.", lives);
                Console.SetCursorPosition(30, 12);
                Console.WriteLine();
                Console.SetCursorPosition(30, 13);
                Console.WriteLine("Press Enter to continue.");
                Console.ForegroundColor = ConsoleColor.Black;
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 10);
                Console.WriteLine("Get ready!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Thread.Sleep(950);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Thread.Sleep(50);
            counter++;
        }

        if (score < 10000)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\n\n\n\n\n{0, 33}\n", "Game Over");
            Console.WriteLine("{0, 29}{1}{2}", "You scored ", score, " points!");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Black;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\n\n\n\n\n{0, 33}\n", "YOU WON!!");
            Console.WriteLine("{0, 28}{1}{2}", "You scored ", score, " points!");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
