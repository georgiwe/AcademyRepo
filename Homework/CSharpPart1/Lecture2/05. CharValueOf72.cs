using System;

class CharValueOf72
{
    static void Main()
    {
        //Declare a character variable and assign it with the symbol 
        //that has Unicode code 72. Hint: first use the Windows Calculator 
        //to find the hexadecimal representation of 72.

        char valueOf72 = (char)0x0048; // or (char)72, or '\u0048'
        Console.WriteLine(valueOf72);
    }
}
