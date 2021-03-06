using System;
class AngryBits
{
    static void Main()
    {   // start 5th 21:21, end - 00:15
        ushort[] field = new ushort[8];
        for (int i = 0; i < 8; i++)
            field[i] = ushort.Parse(Console.ReadLine());

        int birdX = 0;
        int birdY = 0;
        int birdXstart = 0;
        int totalScore = 0;
        int destroyedPigCounter = 0;
        bool foundAbird = false;
        bool hitSth = false;

        for (ushort bird = 8; bird < 16; bird++)
        {
            destroyedPigCounter = 0;
            foundAbird = false;
            hitSth = false;

            int mask = 1 << bird;

            for (int i = 0; i < 8; i++)
            {   // finding the bird in this column
                if ((mask & field[i]) != 0)
                {
                    birdX = birdXstart = bird;
                    birdY = i;
                    field[i] = (ushort)((~mask) & field[i]);
                    foundAbird = true;
                    break;
                }
            }

            bool movingUp = true;
            while (foundAbird == true)
            {   // flying up/right
                if (birdY >= 1 && movingUp == true) { birdX--; birdY--; }

                mask = 1 << birdX;
                if ((mask & field[birdY]) != 0)
                {
                    hitSth = true;
                    int pigMask = 1;

                    if (birdY == 0)
                        for (int i = birdX - 1; i <= birdX + 1; i++)
                        {   // counting and clearing pigs
                            pigMask = 1 << i;

                            if ((pigMask & field[birdY]) != 0) 
                            {
                                destroyedPigCounter++; 
                                field[birdY] = (ushort)((~pigMask) & field[birdY]); 
                            }
                            if ((pigMask & field[birdY + 1]) != 0) 
                            {
                                destroyedPigCounter++; 
                                field[birdY + 1] = (ushort)((~pigMask) & field[birdY + 1]); 
                            }
                        }
                    else if (birdY == 7)
                        for (int i = birdX - 1; i <= birdX + 1; i++)
                        {
                            pigMask = 1 << i;

                            if ((pigMask & field[birdY]) != 0) 
                            {
                                destroyedPigCounter++; 
                                field[birdY] = (ushort)((~pigMask) & field[birdY]); 
                            }
                            if ((pigMask & field[birdY - 1]) != 0) 
                            {
                                destroyedPigCounter++; 
                                field[birdY - 1] = (ushort)((~pigMask) & field[birdY - 1]); 
                            }
                        }
                    else
                        for (int i = birdX - 1; i <= birdX + 1; i++)
                        {
                            pigMask = 1 << i;

                            if ((pigMask & field[birdY]) != 0) 
                            {
                                destroyedPigCounter++; 
                                field[birdY] = (ushort)((~pigMask) & field[birdY]); 
                            }
                            if ((pigMask & field[birdY + 1]) != 0) 
                            {
                                destroyedPigCounter++; 
                                field[birdY + 1] = (ushort)((~pigMask) & field[birdY + 1]); 
                            }
                            if ((pigMask & field[birdY - 1]) != 0) 
                            {
                                destroyedPigCounter++; 
                                field[birdY - 1] = (ushort)((~pigMask) & field[birdY - 1]); 
                            }
                        }

                    break;
                }

                if (birdY == 7) break; // checking break parameters
                else if (birdY == 0 || movingUp == false) { birdX--; birdY++; movingUp = false; }
                else if (birdX == 0) break;
            }

            if (hitSth == true) totalScore += destroyedPigCounter * (birdXstart - birdX); // awarding points
        }

        int livingPigs = 0;

        for (int i = 0; i < 8; i++)
            if (field[i] != 0) { livingPigs++; break; }

        if (livingPigs == 0) Console.WriteLine("{0} Yes", totalScore);
        else Console.WriteLine("{0} No", totalScore);
    }
}
