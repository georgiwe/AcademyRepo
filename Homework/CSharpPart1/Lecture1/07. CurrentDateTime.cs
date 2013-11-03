using System;
using System.Globalization;
using System.Threading;

class CurrentDateTime
{
    static void Main()
    {
        //Create a console application that prints the current date and time.
        
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
        
        Console.WriteLine("Today is {0:MMMM dd, yyyy}.\nThe time is {0:HH:mm:ss}.\n", DateTime.Now);
    }
}
