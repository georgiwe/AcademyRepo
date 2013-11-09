using System;

class Bittris2
{
    static void Main()
    {   // input
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n / 4];
        string[] commands = new string[(n / 4)];

        for (int i = 0; i < n / 4; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
            for (int j = 0; j < 3; j++) commands[i] += Console.ReadLine();
        }

        int[] pointsPerNum = new int[n / 4];

        int mask = 1;
        // counting points per number entered so i can null the bits past the 8th
        for (int i = 0; i < n / 4; i++)
        {
            int pointCounter = 0;
            for (int j = 0; j < 32; j++)
            {
                mask = 1 << j;
                mask = mask & numbers[i];
                mask = mask >> j;

                if (mask == 1) pointCounter++;
            }
            pointsPerNum[i] = pointCounter;
        }
        // nulling bits 9 through 32 in order to avoid disturbance from irrelevant bits :)
        for (int i = 0; i < n / 4; i++)
        {
            for (int j = 8; j < 24; j++)
            {
                mask = ~(1 << j);
                numbers[i] = numbers[i] & mask;
            }
        }

        int[] screen = new int[4];
        bool gameOver = false;
        int totalScore = 0;
        bool landed = false;

        for (int i = 0; (i < n / 4) && (gameOver == false); i++) // cycles through each falling piece
        {
            landed = false;

            if (numbers[i] == 255) totalScore += 10 * pointsPerNum[i];
            else
            {
                screen[0] = numbers[i];

                for (int j = 0; (j < 3) && (landed == false); j++)
                {
                    switch (commands[i][j])  // checks that piece             checks that the piece
                    {                        // doesnt go offscreen           doesnt hit other, landed pieces
                        case 'L': if (((numbers[i] & 128) == 0) && (((numbers[i] << 1) & (screen[j] & (~numbers[i]))) == 0))
                            {                                                                 // virtually removes the piece 
                                numbers[i] = numbers[i] << 1;                                 // from the current "screen row"  
                                screen[j] = numbers[i] | (screen[j] & (~(numbers[i] >> 1)));  // to check whether shifting it
                            } break;                                                          //  would put it ontop of any
                        case 'R': if (((numbers[i] & 1) == 0) && (((numbers[i] >> 1) & (screen[j] & (~numbers[i]))) == 0))
                            {                                                                 // other, already landed, pieces
                                numbers[i] = numbers[i] >> 1;                                 // same thing for shifting right
                                screen[j] = numbers[i] | (screen[j] & (~(numbers[i] << 1)));
                            } break;
                    }
                    // piece drops down or lands due to collision or exhaustion of commands
                    if ((numbers[i] & screen[j + 1]) != 0 && j == 0) { gameOver = true; totalScore += pointsPerNum[i]; break; } // check if piece lands on first row
                    else if ((numbers[i] & screen[j + 1]) != 0) // check if piece lands on the following row
                    {
                        landed = true;
                        if (screen[j] == 255) // check if piece completed a line
                        {
                            totalScore += 10 * pointsPerNum[i];

                            for (int p = j; p >= 1; p--) // above rows shift down
                            {
                                screen[j] = screen[j - 1];
                                screen[j - 1] = 0;
                            }
                        }
                        else totalScore += pointsPerNum[i];
                    }
                    else // piece moves down
                    {
                        screen[j + 1] = screen[j + 1] | numbers[i]; // piece lands on the next row

                        screen[j] = screen[j] & ~numbers[i]; // removes the current piece from the previous row
                    }

                    if (j == 2 && landed == false) // checks if the piece has landed on the bottom row 
                    {                              // due to exhaustion of commands
                        landed = true;
                        if (screen[j + 1] == 255) // another check for a full line
                        {
                            totalScore += 10 * pointsPerNum[i];

                            for (int p = j + 1; p >= 1; p--) // shifting rows down again
                            {
                                screen[p] = screen[p - 1];
                            }
                        }
                        else totalScore += pointsPerNum[i]; // if no line was made, awards points for landing
                    }
                }
            }
        }
        Console.WriteLine(totalScore);
    }
}
