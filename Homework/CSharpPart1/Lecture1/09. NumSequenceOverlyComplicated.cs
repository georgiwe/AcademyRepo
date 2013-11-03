using System;
using System.Text;

class NumSequenceOverlyComplicated
{
    static void Main()
    {
        //Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
        
        for (int sequenceMember = 2; sequenceMember <= 11; sequenceMember++)
        {
            if (sequenceMember == 11)
            {
                Console.Write("{0}.", -sequenceMember);
            }
            else if (sequenceMember % 2 == 0)
            {
                Console.Write("{0}, ", sequenceMember);
            }
            else
            {
                Console.Write("{0}, ", -sequenceMember);
            }
        }

        Console.WriteLine("\n");
    }
}
