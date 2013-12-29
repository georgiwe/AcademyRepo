// Write a method that calculates the number of workdays between today and given date, 
// passed as parameter. Consider that workdays are all days from Monday to Friday 
// except a fixed list of public holidays specified preliminary as array.

using System;
using System.Globalization;

class Workdays
{
    static void Main()
    {
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
        DateTime now = DateTime.Now;
        Console.WriteLine("Enter Year, Month and Day - each on a separate line:");
        DateTime then = new DateTime(
            int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));

        GetWorkdaysBetween(now, then);
    }

    static void GetWorkdaysBetween(DateTime start, DateTime end)
    {
        if (start > end) { Console.WriteLine("Erroneous input!"); return; }

        start = new DateTime(start.Year, start.Month, start.Day); // Set the time to 00:00:00 o'clock,
                                                                  // so we compare equal days and can use ints.
        DateTime[] holidays = {
        new DateTime(2014,  1,  1),
        new DateTime(2014,  3,  3),
        new DateTime(2014,  5,  6),
        new DateTime(2014,  5, 24),
        new DateTime(2014, 10,  9), }; // My birthday, obv. 
                                                                               // If it is Sat/Sun, we
        if (start.DayOfWeek == DayOfWeek.Saturday) start = start.AddDays(2);   // start counting from the
        else if (start.DayOfWeek == DayOfWeek.Sunday) start = start.AddDays(1);// first upcoming Monday.

        int subtractedDays = 0;
        if (end.DayOfWeek == DayOfWeek.Sunday) // Don't count Sundays.
        {
            end = end.Subtract(new TimeSpan(1, 0, 0, 0)); // Subtracts one day.
            subtractedDays += 1; // We remember how many days we subtracted,
        }                        // in order to display the right date in the end.

        int daysBetweenDates = (int)end.Subtract(start).TotalDays;
        int resultDays = 0;

        resultDays = daysBetweenDates - ((daysBetweenDates / 7) * 2);
        
        for (int i = 0; i < holidays.Length; i++)
            if (holidays[i] < end && holidays[i] > start)
                Console.Write("\n{0:MMM, dd} has been excluded as a holiday.", holidays[i], resultDays--);

        Console.WriteLine("\n\nThere are {0} workdays until {1:dd.MM.yyyy HH:mm:ss}.", resultDays, end.AddDays(subtractedDays));
        Console.WriteLine("(Meaning {0:MMM, dd, yyyy} is not counted.)\n", end.AddDays(subtractedDays));
    }
}
